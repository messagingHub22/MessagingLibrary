namespace MessagingLibrary.Data
{
    public class MessageUser
    {
        public int Id { get; set; }
        public DateTime SentTime { get; set; }
        public string? Content { get; set; }
        public string? MessageTo { get; set; }
        public string? MessageFrom { get; set; }

    }
}
