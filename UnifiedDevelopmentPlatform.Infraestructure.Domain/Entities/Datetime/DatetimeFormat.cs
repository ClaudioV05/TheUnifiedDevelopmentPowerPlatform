namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Datetime
{
    /// <summary>
    /// DatetimeFormat
    /// </summary>
    public abstract class DatetimeFormat
    {
        /// <summary>
        /// 08/4/21
        /// </summary>
        public const string FORMAT_01 = "MM/dd/yy";

        /// <summary>
        /// 08/04/2021
        /// </summary>
        public const string FORMAT_02 = "MM/dd/yyyy";

        /// <summary>
        /// 04/08/21
        /// </summary>
        public const string FORMAT_03 = "dd/MM/yy";

        /// <summary>
        /// 04-08-21
        /// </summary>
        public const string FORMAT_04 = "dd-MM-yy";

        /// <summary>
        /// Wed, 04 Aug 2021
        /// </summary>
        public const string FORMAT_05 = "ddd, dd MMM yyyy";

        /// <summary>
        /// Wednesday, 04 August 21
        /// </summary>
        public const string FORMAT_06 = "dddd, dd MMMM yy";

        /// <summary>
        /// Wednesday, 04 August 2021 23:58
        /// </summary>
        public const string FORMAT_07 = "dddd, dd MMMM yyyy HH:mm";

        /// <summary>
        /// 08/04/21 23:58
        /// </summary>
        public const string FORMAT_08 = "MM/dd/yy HH:mm";

        /// <summary>
        /// 08/04/2021 11:58 PM
        /// </summary>
        public const string FORMAT_09 = "MM/dd/yyyy hh:mm tt";

        /// <summary>
        ///  Wed, 04 Aug 2021 P
        /// </summary>
        public const string FORMAT_10 = "MM/dd/yyyy H:mm t";

        /// <summary>
        /// 08/04/2021 23:58:30
        /// </summary>
        public const string FORMAT_11 = "MM/dd/yyyy H:mm:ss";

        /// <summary>
        /// Aug 04
        /// </summary>
        public const string FORMAT_12 = "MMM dd";

        /// <summary>
        /// 08-04-2021T23:58:30.999
        /// </summary>
        public const string FORMAT_13 = "MM-dd-yyyTHH:mm:ss.fff";

        /// <summary>
        /// 08-04-2021 A.D.
        /// </summary>
        public const string FORMAT_14 = "MM-dd-yyy g";

        /// <summary>
        /// 23:58
        /// </summary>
        public const string FORMAT_15 = "HH:mm";

        /// <summary>
        /// 11:58 PM
        /// </summary>
        public const string FORMAT_16 = "hh:mm tt";

        /// <summary>
        /// 23:58:30
        /// </summary>
        public const string FORMAT_17 = "HH:mm:ss";

        /// <summary>
        /// Full DateTime: 08-04-2021T23:58:30
        /// </summary>
        public const string FORMAT_18 = "MM-dd-yyyTHH:mm:ss";
    }
}