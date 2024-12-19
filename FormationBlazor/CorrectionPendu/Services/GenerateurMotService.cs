namespace CorrectionPendu.Services;

public class GenerateurMotService
{
    private static Random _random = new Random();
    private static string[] mots = { "google", "facebook", "microsoft", "amazon" };
    public static string GenererMot()
    {
        return mots[_random.Next(mots.Length)];
    }
}