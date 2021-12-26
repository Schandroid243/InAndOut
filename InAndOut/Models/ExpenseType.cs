using System;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        public ExpenseType()
        {
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
