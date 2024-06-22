using Google.Cloud.SecretManager.V1;

namespace AuthenticationMicroService.SecretManager
{
    public static class SecretManager
    {
        static SecretManagerServiceClient client = SecretManagerServiceClient.Create();

        public static string GetSecretKey(string secretKey)
        {
            SecretVersionName secretVersionName = new SecretVersionName("centered-song-423220-i0", secretKey, "1");
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
            return result.Payload.Data.ToStringUtf8();
        }
    }
}
