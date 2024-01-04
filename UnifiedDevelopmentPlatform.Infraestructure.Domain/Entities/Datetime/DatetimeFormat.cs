namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Datetime
{
    /// <summary>
    /// DatetimeFormat
    /// </summary>
    public static class DatetimeFormat
    {
        /// <summary>
        /// 08/4/21
        /// </summary>
        public static string Format_01 { get; } = "MM/dd/yy";

        /// <summary>
        /// 08/04/2021
        /// </summary>
        public static string Format_02 { get; } = "MM/dd/yyyy";

        /// <summary>
        /// 04/08/21
        /// </summary>
        public static string Format_03 { get; } = "dd/MM/yy";

        /// <summary>
        /// 04-08-21
        /// </summary>
        public static string Format_04 { get; } = "dd-MM-yy";

        /// <summary>
        /// Wed, 04 Aug 2021
        /// </summary>
        public static string Format_05 { get; } = "ddd, dd MMM yyyy";

        /// <summary>
        /// Wednesday, 04 August 21
        /// </summary>
        public static string Format_06 { get; } = "dddd, dd MMMM yy";

        /// <summary>
        /// Wednesday, 04 August 2021 23:58
        /// </summary>
        public static string Format_07 { get; } = "dddd, dd MMMM yyyy HH:mm";

        /// <summary>
        /// 08/04/21 23:58
        /// </summary>
        public static string Format_08 { get; } = "MM/dd/yy HH:mm";

        /// <summary>
        /// 08/04/2021 11:58 PM
        /// </summary>
        public static string Format_09 { get; } = "MM/dd/yyyy hh:mm tt";

        /// <summary>
        ///  Wed, 04 Aug 2021 P
        /// </summary>
        public static string Format_10 { get; } = "MM/dd/yyyy H:mm t";

        /// <summary>
        /// 08/04/2021 23:58:30
        /// </summary>
        public static string Format_11 { get; } = "MM/dd/yyyy H:mm:ss";

        /// <summary>
        /// Aug 04
        /// </summary>
        public static string Format_12 { get; } = "MMM dd";

        /// <summary>
        /// 08-04-2021T23:58:30.999
        /// </summary>
        public static string Format_13 { get; } = "MM-dd-yyyTHH:mm:ss.fff";

        /// <summary>
        /// 08-04-2021 A.D.
        /// </summary>
        public static string Format_14 { get; } = "MM-dd-yyy g";

        /// <summary>
        /// 23:58
        /// </summary>
        public static string Format_15 { get; } = "HH:mm";

        /// <summary>
        /// 11:58 PM
        /// </summary>
        public static string Format_16 { get; } = "hh:mm tt";

        /// <summary>
        /// 23:58:30
        /// </summary>
        public static string Format_17 { get; } = "HH:mm:ss";

        /// <summary>
        /// Full DateTime: 08-04-2021T23:58:30
        /// </summary>
        public static string Format_18 { get; } = "MM-dd-yyyTHH:mm:ss";
    }
}