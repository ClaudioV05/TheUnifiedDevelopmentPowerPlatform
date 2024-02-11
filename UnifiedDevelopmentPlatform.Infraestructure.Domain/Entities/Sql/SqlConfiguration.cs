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
    }
}