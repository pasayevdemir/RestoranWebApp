namespace Core.Constants
{
    public enum LoggingMechanism
    {
        Database,
        File,
    }

    public enum DatabaseSchemas
    {
        Dictionary = 1,
        Student = 2,
        Finance = 3,
        HR = 4,
        Education = 5,
        AdminTool = 6

    }

    public enum ApplicationMessageCommonKeys
    {
        DataAddedSuccessfully = 1,
        DataRemovedSuccessfully = 2,
        DataUpdatedSuccessfully = 3,
        InvalidDateFormat = 4,
        InvalidMailFormat = 5
    }

    public enum ApplicationLanguages
    {
        AZ = 100002,
        RU = 100003,
        EN = 100004
    }
}
