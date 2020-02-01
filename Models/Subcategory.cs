using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvcproject.Models
{
    public class Subcategory:Category
    {
       
        public string Sub_id { get; set; }
        public string Sub_name { get; set; }
        public int Gst_per { get; set; }
        public Subcategory()
        {

        }
        public Subcategory(string sub_id,string sub_name,int gst_per)
        {
            this.Sub_id = sub_id;
            this.Sub_name = sub_name;
            this.Gst_per = gst_per;
        }
    }
}
