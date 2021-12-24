using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expenses
    {
        public Expenses()
        {
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string ExpenseName { get; set; }

        [DisplayName("Amount")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0 !")]
        public int Amount { get; set; }
    }
}
