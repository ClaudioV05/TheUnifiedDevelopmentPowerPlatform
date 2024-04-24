namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql
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
        /// The key constraint.
        /// </summary>
        public static string KeyConstraint => "constraint";

        /// <summary>
        /// The key index.
        /// </summary>
        public static string KeyIndex => "index";

        /// <summary>
        /// The key primary key.
        /// </summary>
        public static string PrimaryKey => "primary key";

        /// <summary>
        /// The key not.
        /// </summary>
        public static string KeyNot => "not";

        /// <summary>
        /// SQL null constraint.
        /// </summary>
        public static string SqlConstraintNull => "null";

        /// <summary>
        /// SQL not null constraint.
        /// </summary>
        public static string SqlConstraintNotNull => "not null";

        /// <summary>
        /// The key of auto increment from database.
        /// </summary>
        public static string KeyAutoIncrement => "auto_increment";

        /// <summary>
        /// The database object.
        /// </summary>
        public static string DatabaseObject => "dbo";

        /// <summary>
        /// SQL Collate constraint.
        /// </summary>
        public static string SqlConstraintCollate => "collate";

        /// <summary>
        /// UTF-8 with mb4 general ci.
        /// </summary>
        public static string Utf8WithMb4GeneralCi => "utf8mb4_general_ci";

        /// <summary>
        /// SQL Default constraint.
        /// </summary>
        public static string SqlConstraintDefault => "default";
    }
}