using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mvcproject.Models
{
    public class Item:Subcategory
    {
       
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int price { get; set; }
        public int stock_no { get; set; }
        public Item()
        {

        }
    }
}
