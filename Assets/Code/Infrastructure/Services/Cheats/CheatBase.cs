namespace Code.Infrastructure.Services.Cheats
{
    public class CheatBase
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }

        public CheatBase(string id, string description, string format)
        {
            ID = id;
            Description = description;
            Format = format;
        }
    }
}