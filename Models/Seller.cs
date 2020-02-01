using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mvcproject.Models
{
    public class Seller
    {
        [Key]
        [Required(ErrorMessage = "Id feild is mandatory")]
        [MaxLength(5, ErrorMessage = "The length should be five 5")]
        public string s_id { get; set; }
        [Required(ErrorMessage = "Name feild is mandatory")]
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "the  name should between 5 to 20")]
        public string Uname { get; set; }
        [Required(ErrorMessage = "Password feild is mandatory")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[a-z0-9]{6,8}", ErrorMessage = "Password invalid")]
        public string Pwd { get; set; }
        public string C_name { get; set; }
        [Required(ErrorMessage = "Email feild is mandatory")]
        [EmailAddress(ErrorMessage = "InvalidEmail address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "contact number feild is mandatory")]
        [Phone(ErrorMessage = "invalid phn number")]
        public string C_No { get; set; }
        public int GSTIN { get; set; }
        public string Photopath { get; set; }
        public Seller()
        {

        }
        public Seller(string s_id,string uname,string pwd,string C_name,string C_No,int gstin)
        {
            this.s_id = s_id;
            this.Uname = uname;
            this.Pwd = pwd;
            this.C_name = C_name;
            this.C_No = C_No;
            this.GSTIN = gstin;
        }
    }
}
