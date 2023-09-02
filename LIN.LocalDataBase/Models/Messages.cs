
namespace LIN.LocalDataBase.Models
{
    public class Message
    {
        public int ID { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Remitente { get; set; } = string.Empty;
        public int Conversation { get; set; }
        public int RemitenteID { get; set; }
    }
}
