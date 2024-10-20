public static class KeyManager
{
    private const string ValidKey = "hello"; // Replace with your actual key

    public static bool ValidateKey(string key)
    {
        return key == ValidKey;
    }
}
