namespace Core.Constants
{
    public static class DefaultConstantValues
    {
        public const string DICTIONARIES = "dictionaries";
        public const string HR = "hr";
        public const string EDUCATION = "education";
        public const string FINANCE = "finance";
        public const string STUDENT = "student";
        public const string ADMIN_TOOL = "admintool";
        public const string APPLICATION_MESSAGE_CACHE_KEY = "application_message_cache_key_!@#$%";




        public static readonly TimeSpan DEFAULT_CACHE_EXPIRATION_TIME = TimeSpan.FromHours(DEFAULT_CACHE_EXPIRATION_HOUR);
        private static readonly int DEFAULT_CACHE_EXPIRATION_HOUR = 1;
        public static readonly string LOG_TABLE_NAME = "LogModel";
        public static readonly string CONFIGURATION_LOGGING_SECTION = "Logging";
        public static readonly string CONFIGURATION_FILE_PATH_SECTION = "FilePath";
        public static readonly string CONFIGURATION_FILE_PATH_SECTION_VALUE = "Path";
        public static readonly string DEFAULT_ADMIN_USER_NAME = "admin";
        public static readonly int DEFAULT_DELETED_COLUMN_VALUE = 0;
        public static readonly string DATA_ADDED_SUCCESSFULLY = "Data added Successfully";
        public static readonly string DATA_UPDATED_SUCCESSFULLY = "Data updated successfully";
        public static readonly string DATA_DELETED_SUCCESSFULLY = "Data deleted successfully";
        public static readonly string RECORD_NOT_FOUND = "Record not found";
        public static readonly string DUPLICATE_RECORD_FOUND = "Duplicate record found";
        public static readonly int DEFAULT_PRIMARY_KEY_INCREMENT_VALUE = 100;
        public static readonly string INVALID_DATE_FORMAT = "Invalid Date format";
        public static readonly string INVALID_EMAIL_ADDRESS_FORMAT = "Invalid email adress format";
    }
}
