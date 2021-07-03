using System.ComponentModel.DataAnnotations;


namespace bankapp.Models
{

    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        // public int EmployeeId { get; set; }

        public string FirstName { get; set; }


    }
}