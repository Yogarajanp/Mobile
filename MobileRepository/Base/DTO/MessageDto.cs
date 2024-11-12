namespace MobileRepository.Base.DTO
{
    public class MessageDto
    {
        public List<string> Messages { get; set; } = new List<string>();

        // Return this instance to allow chaining
        public MessageDto AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }
    }


}
