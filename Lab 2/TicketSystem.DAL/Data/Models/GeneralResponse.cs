using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Data.Models
{
    internal class GeneralResponse
    {
        public string Message { get; set; }
        public GeneralResponse(string message) 
        { 
            Message = message;
        }
    }
}
