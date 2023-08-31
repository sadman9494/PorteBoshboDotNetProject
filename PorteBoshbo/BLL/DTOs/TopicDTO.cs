using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TopicDTO
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public EducationLevelDTO EducationLevel { get; set; }
        public DepartmentDTO Department { get; set; }
        public CourseDTO Course { get; set; }

    }
}
