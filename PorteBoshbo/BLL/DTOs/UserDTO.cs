using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name should be at least 5 charecters")]
        [RegularExpression(@"^[a-zA-Z-. ]*$", ErrorMessage = "can not contain any digit and special charecter")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-]+)(\.[a-zA-Z]{2,5}){1,2}$", ErrorMessage = "invalid email")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "User Name should be at least 5 charecters")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string Password { get; set; }
        //public string PasswordConfirmed { get; set; }
        public string Role { get; set;}
        public double Balance { get; set; }
        //public bool IsStudent { get; set; }
        //public bool IsTeacher { get; set; }
        public List<PaymentDTO> ReceivedPayments { get; set; }
        public List<PaymentDTO> PaidPayments { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public DepartmentDTO Department { get; set; }
        public EducationLevelDTO EducationLevel { get; set; }
        public List<ReviewDTO> SubmittedReviews { get; set; }
        public List<ReviewDTO> ReceivedReviews { get; set; }
        public List<SessionDTO> Sessions { get; set; }

    }
}
