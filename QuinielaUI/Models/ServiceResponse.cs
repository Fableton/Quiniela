namespace QuinielaUI.Models
{
    public class ServiceResponse
    {
        public object data { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}
