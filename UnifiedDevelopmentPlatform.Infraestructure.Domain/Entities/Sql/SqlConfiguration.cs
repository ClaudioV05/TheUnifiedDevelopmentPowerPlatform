namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql
{
    /// <summary>
    /// Structured Query Language - SQL Configuration
    /// </summary>
    public static class SqlConfiguration
    {
        /// <summary>
        /// Create table position.
        /// </summary>
        public static int CreateTablePosition => 13;

        /// <summary>
        /// Create table default position.
        /// </summary>
        public static int CreateTableDefaultPosition => 5;

        /// <summary>
        /// Create table with space.
        /// </summary>
        public static string CreateTableWithSpace => "create table ";

        /// <summary>
        /// Key constraint.
        /// </summary>
        public static string KeyConstraint => "constraint";

        /// <summary>
        /// Key primary key.
        /// </summary>
        public static string KeyPrimaryKey => "primary key";

        /// <summary>
        /// Key not.
        /// </summary>
        public static string KeyNot => "not";

        /// <summary>
        /// Key null value.
        /// </summary>
        public static string KeyNullValue => "null";

        /// <summary>
        /// Key not null value.
        /// </summary>
        public static string KeyNotNullValue => "not null";
    }
}