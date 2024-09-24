using Core.Entities;

namespace Core.Exceptions
{
    public class ExceptionModel : IEntity
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public int UserId { get; set; }
    }
}