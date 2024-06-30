namespace Task1;

internal class NotificationService : INotificationService
{
    public void ErrorCodeNotification(string? code)
    {
        switch (code)
        {
            case AuthorizationCodes.AuthorizationPending:
                Console.WriteLine("Autoryzacja w toku. Kontynuowanie odpytywania...");
                break;

            case AuthorizationCodes.SlowDown:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zbyt częste odpytywanie. Zwiększenie interwału o 5 sekund.");
                Console.ResetColor();
                break;

            case AuthorizationCodes.TimeOut:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Czas wygasł dla kodu urządzenia.");
                Console.ResetColor();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd podczas uzyskiwania tokena: {code}");
                Console.ResetColor();
                break;
        }
    }

    public void verificationUriNotification(string? userCode, string? verificationUri)
    {
        Console.WriteLine($"Wprowadź kod użytkownika \"{userCode}\" na stronie: {verificationUri}");
    }
}
