using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        public Item()
        {
        }
        [Key]
        public int Id { get; set; }

        [DisplayName("Borrower")]
        public string Borrower { get; set; }

        [DisplayName("Lender")]
        public string Lender { get; set; }

        [DisplayName("Item Name")]
        public string Name { get; set; }

    }
}
