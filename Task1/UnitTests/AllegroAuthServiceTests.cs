using FluentAssertions;
using Moq;
using Task1;
using Task1.Infrastructure.BilingEntryAllegro;

namespace UnitTests;

public class AllegroAuthServiceTests
{
    private AllegroAuthService authService;
    private Mock<IHttpRestClient> mockHttpClient;
    private Mock<INotificationService> mockNotificationService;
    private const string clientId = "test_client_id";
    private const string userCode = "test_user_code";
    private const string accessToken = "test_access_token";

    [SetUp]
    public void Setup()
    {
        mockHttpClient = new Mock<IHttpRestClient>();
        mockNotificationService = new Mock<INotificationService>();

        authService = new AllegroAuthService(
            mockNotificationService.Object,
            mockHttpClient.Object,
            clientId
        );

        var deviceCodeDto = new DeviceCodeDto
        {
            DeviceCode = "test_device_code",
            UserCode = userCode,
            Interval = 0,
            ExpiresIn = 9000,
            VerificationUriComplete = "https://verification.uri"
        };
        mockHttpClient.Setup(c => c.Post<DeviceCodeDto>("auth/oauth/device", $"client_id={clientId}"))
                      .ReturnsAsync(deviceCodeDto);
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldReturnAccessToken_WhenRequestIsSuccessful()
    {
        // Arrange
        SetupSequenceForPostToAuthToken();

        // Act
        var accessToken = await authService.GetAccessTokenAsync();

        // Assert
        accessToken.Should().NotBeNull();
        accessToken.Should().Be(accessToken);

        // Verify interactions
        mockNotificationService.Verify(n => n.verificationUriNotification(userCode, "https://verification.uri"), Times.Once);
        mockNotificationService.Verify(n => n.ErrorCodeNotification(It.IsAny<string?>()), Times.Never);
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldReturnNull_WhenRequestTimesOut()
    {
        // Arrange
        SetupSequenceForPostToAuthToken(AuthorizationCodes.TimeOut);

        // Act
        var accessToken = await authService.GetAccessTokenAsync();

        // Assert
        accessToken.Should().BeNull();

        // Verify interactions
        mockNotificationService.Verify(n => n.verificationUriNotification(userCode, "https://verification.uri"), Times.Once);
        mockNotificationService.Verify(n => n.ErrorCodeNotification("time_out"), Times.Once);
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldRetryAndReturnAccessToken_WhenRequestSlowsDown()
    {
        // Arrange
        SetupSequenceForPostToAuthToken(AuthorizationCodes.SlowDown);

        // Act
        var accessToken = await authService.GetAccessTokenAsync();

        // Assert
        accessToken.Should().NotBeNull();
        accessToken.Should().Be(accessToken);

        // Verify interactions
        mockNotificationService.Verify(n => n.verificationUriNotification(userCode, "https://verification.uri"), Times.Once);
        mockNotificationService.Verify(n => n.ErrorCodeNotification("slow_down"), Times.Once);
    }

    private void SetupSequenceForPostToAuthToken(string? error = null)
    {
        mockHttpClient.SetupSequence(c => c.Post<DeviceAuthTokenDto>("auth/oauth/token", "grant_type=urn:ietf:params:oauth:grant-type:device_code&device_code=test_device_code"))
            .ReturnsAsync(new DeviceAuthTokenDto { AccessToken = accessToken, Error = error });
    }
}

