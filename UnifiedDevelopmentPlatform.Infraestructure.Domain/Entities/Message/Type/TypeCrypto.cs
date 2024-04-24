using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the crypto.
    /// </summary>
    public enum TypeCrypto : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Call start to the encrypt")] CallStartToTheEncrypt = 1,
        [Description("Success to the encrypt")] SuccessToTheEncrypt = 2,
        [Description("Error to the encrypt")] ErrorToTheEncrypt = 3,
        [Description("Call start to the decrypt")] CallStartToTheDecrypt = 4,
        [Description("Success to the decrypt")] SuccessToTheDecrypt = 5,
        [Description("Error to the decrypt")] ErrorToTheDecrypt = 6,
        [Description("Call start to the decode base 64")] CallStartToTheDecodeBase64 = 7,
        [Description("Success to the decode base 64")] SuccessToTheDecodeBase64 = 8,
        [Description("Error to the decode base 64")] ErrorToTheDecodeBase64 = 9
    }
}