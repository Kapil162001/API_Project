using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.Models.DTO
{
    public class LoginResponseDTO
    {
        public Register User { get; set; }
        public string Token { get; set; }
    }
}
