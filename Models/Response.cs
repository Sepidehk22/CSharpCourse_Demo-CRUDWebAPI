namespace WebApplication5.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Employee employee { get; set; }
        public List<Employee> employees { get; set;}
    }
}
