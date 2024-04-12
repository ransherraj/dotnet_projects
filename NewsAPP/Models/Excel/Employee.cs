using System.ComponentModel.DataAnnotations;

namespace NewsAPP.Models.Excel
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }
        public string? emp_name { get; set; }    
        public int emp_salary { get; set; } 
        public string? emp_address { get; set; }
  
    }
}
