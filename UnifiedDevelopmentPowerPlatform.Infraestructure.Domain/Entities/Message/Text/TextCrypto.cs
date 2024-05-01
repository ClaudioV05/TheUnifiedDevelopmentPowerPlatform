using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the crypto.
/// </summary>
[ComplexType]
public static class TextCrypto
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the encrypt.
    /// </summary>
    public static string CallStartToTheEncrypt => "CALL START TO THE ENCRYPT.";

    /// <summary>
    /// Success start to the encrypt.
    /// </summary>
    public static string SuccessToTheEncrypt => "SUCCESS START TO THE ENCRYPT.";

    /// <summary>
    /// Error start to the encrypt.
    /// </summary>
    public static string ErrorToTheEncrypt => "ERROR START TO THE ENCRYPT.";

    /// <summary>
    /// Call start to the decrypt.
    /// </summary>
    public static string CallStartToTheDecrypt => "CALL START TO THE DECRYPT.";

    /// <summary>
    /// Success start to the decrypt.
    /// </summary>
    public static string SuccessToTheDecrypt => "SUCCESS START TO THE DECRYPT.";

    /// <summary>
    /// Error start to the decrypt.
    /// </summary>
    public static string ErrorToTheDecrypt => "ERROR START TO THE DECRYPT.";

    /// <summary>
    /// Call start to the decode from base 64.
    /// </summary>
    public static string CallStartToTheDecodeFromBase64 => "CALL START TO THE DECODE FROM BASE 64.";

    /// <summary>
    /// Success start to the decode from base 64.
    /// </summary>
    public static string SuccessToTheDecodeFromBase64 => "SUCCESS START TO THE DECODE FROM BASE 64.";

    /// <summary>
    /// Error start to the decode base 64.
    /// </summary>
    public static string ErrorToTheDecodeFromBase64 => "ERROR START TO THE DECODE FROM BASE 64.";

    /// <summary>
    /// Call start to the encode to base 64.
    /// </summary>
    public static string CallStartToTheEncodeToBase64 => "CALL START TO THE ENCODE TO BASE 64.";

    /// <summary>
    /// Success start to the encode to base 64.
    /// </summary>
    public static string SuccessToTheEncodeToBase64 => "SUCCESS START TO THE ENCODE TO BASE 64.";

    /// <summary>
    /// Error start to the encode to base 64.
    /// </summary>
    public static string ErrorToTheEncodeToBase64 => "ERROR START TO THE ENCODE TO BASE 64.";
}