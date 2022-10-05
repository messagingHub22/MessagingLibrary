namespace MessagingLibrary.Data
{
    public class MessageData
    {
        public DateTime sentTime { get; set; }
        public int id { get; set; }
        public bool messageRead { get; set; }
        public string? content { get; set; }
        public string? messageCategory { get; set; }
        public string? messageUser { get; set; }

    }
}
