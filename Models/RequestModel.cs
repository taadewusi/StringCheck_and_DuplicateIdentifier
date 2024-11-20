namespace StringCheck.Models
{
    public class RequestModel
    {
        public List<IFormFile> Files { get; set; }       
        public string SearchValue { get; set; }
    }
}
