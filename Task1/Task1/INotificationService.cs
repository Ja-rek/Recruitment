namespace Task1;

public interface INotificationService
{
    void ErrorCodeNotification(string? code);
    void verificationUriNotification(string? userCode, string? verificationUri);
}
