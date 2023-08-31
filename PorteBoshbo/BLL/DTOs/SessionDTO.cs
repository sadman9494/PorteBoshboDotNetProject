using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SessionDTO
    {
        public int SessionId { get; set; }
        public UserDTO Teacher { get; set; }
        public UserDTO Student { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string Link { get; set; }
    }
}
