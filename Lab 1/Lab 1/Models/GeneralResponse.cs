using System.Reflection.Metadata;

namespace Lab_1.Models
{
    public class GeneralResponse
    {
        public string Message { get; set; } = "";
        public GeneralResponse(string msg) 
        {
            Message = msg;
        }
    }
}
