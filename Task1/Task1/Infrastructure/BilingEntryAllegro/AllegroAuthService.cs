using Task1.Application;

namespace Task1.Infrastructure.BilingEntryAllegro;

public class AllegroAuthService(INotificationService notificationService,
    IHttpRestClient client,
    string clientId)
{

    private readonly INotificationService notificationService = notificationService;
    private readonly string clientId = clientId;

    public async Task<string?> GetAccessTokenAsync()
    {
        var (interval, expiresIn, deviceCode) = await DeviceOauth();
        var startTime = DateTime.Now;

        while (true)
        {
            if ((DateTime.Now - startTime).TotalSeconds > expiresIn)
            {
                notificationService.ErrorCodeNotification("time_out");
                break;
            }

            Thread.Sleep(interval * 1000);

            var token = await client.Post<DeviceAuthTokenDto>(
                "auth/oauth/token", 
                $"grant_type=urn:ietf:params:oauth:grant-type:device_code&device_code={deviceCode}");

            if (!string.IsNullOrWhiteSpace(token?.Error))
            {
                notificationService.ErrorCodeNotification(token.Error);

                if (token?.Error != "authorization_pending" && token?.Error != "slow_down")
                {
                    break;
                }
            }

            if (token?.Error == "slow_down")
            {
                interval += 5;
            }

            if (!string.IsNullOrWhiteSpace(token?.AccessToken))
            {
                return token?.AccessToken;
            }
        }

        return null;
    }

    private async Task<(int interval, int expiresIn, string? deviceCode)> DeviceOauth()
    {
        var deviceFlow = await client.Post<DeviceCodeDto>("auth/oauth/device", $"client_id={clientId}");

        notificationService.verificationUriNotification(
            deviceFlow?.UserCode, 
            deviceFlow?.VerificationUriComplete);

        return (deviceFlow?.Interval ?? 0, deviceFlow?.ExpiresIn ?? 0, deviceFlow?.DeviceCode);
    }

}

