namespace EBS.Shared
{
    public enum ExecutionStatus
    {
        Success,
        Failed
    }

    public enum MessageType
    {
        Success,
        Error,
        Warning,
        Information
    }

    public enum Status
    {
        Inactive = 0,
        Active = 1
    }
}