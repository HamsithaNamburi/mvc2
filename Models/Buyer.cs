using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Mvcproject.Models
{
    public class Buyer
    {
        [Key]
        [Required(ErrorMessage ="Id feild is mandatory")]
        [MaxLength(5,ErrorMessage ="The length should be five 5")]
        public string b_id { get; set; }
        [Required(ErrorMessage = "Name feild is mandatory")]
        [StringLength(maximumLength:20,MinimumLength =5,ErrorMessage ="the  name should between 5 to 20")]
        public string Name { get; set; }
       [Required(ErrorMessage = "Password feild is mandatory")]
       [DataType(DataType.Password)]
       [RegularExpression(@"[a-z0-9]{6,8}",ErrorMessage ="Password invalid")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email feild is mandatory")]
        [EmailAddress(ErrorMessage ="InvalidEmail address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "contact number feild is mandatory")]
        [Phone(ErrorMessage ="invalid phn number")]
        public string C_no { get; set; }//contact number
        public DateTime C_date { get; set; }//creation date

        public Buyer()
        {

        }
        public Buyer(string b_id,string Name,string password,string email,string C_no,DateTime c_date)
        {
            this.b_id = b_id;
            this.Name = Name;
            this.Password = password;
            this.Email = email;
            this.C_no = C_no;
            this.C_date = c_date;
        }
    }
}
