using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public double Rating { get; set; }
        public UserDTO Teacher { get; set; }
        public UserDTO Student { get; set; }
        public TopicDTO Topic { get; set; }
    }
}
