namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceCrypto
    {
        string UPDEncrypt(string value);
        string UPDDecrypt(string value);
        string UPDDecodeBase64(string? value);
    }
}