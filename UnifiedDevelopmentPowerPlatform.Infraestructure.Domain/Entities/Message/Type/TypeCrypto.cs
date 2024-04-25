using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the crypto.
    /// </summary>
    public enum TypeCrypto : int
    {
        [Description("The Message type do not specified")]
        DoNotSpecified = 0,
        [Description("Call start to the encrypt")]
        CallStartToTheEncrypt = 1,
        [Description("Success to the encrypt")]
        SuccessToTheEncrypt = 2,
        [Description("Error to the encrypt")]
        ErrorToTheEncrypt = 3,
        [Description("Call start to the decrypt")]
        CallStartToTheDecrypt = 4,
        [Description("Success to the decrypt")]
        SuccessToTheDecrypt = 5,
        [Description("Error to the decrypt")]
        ErrorToTheDecrypt = 6,
        [Description("Call start to the decode from base 64")]
        CallStartToTheDecodeFromBase64 = 7,
        [Description("Success to the decode from base 64")]
        SuccessToTheDecodeFromBase64 = 8,
        [Description("Error to the decode from base 64")]
        ErrorToTheDecodeFromBase64 = 9,
        [Description("Call start to the encode to base 64")]
        CallStartToTheEncodeToBase64 = 10,
        [Description("Success to the encode to base 64")]
        SuccessToTheEncodeToBase64 = 11,
        [Description("Error to the encode to base 64")]
        ErrorToTheEncodeToBase64 = 12
    }
}