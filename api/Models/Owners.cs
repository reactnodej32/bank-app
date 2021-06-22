using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankapp
{

    [Table("owner")]
    public class Owner
    {
        [Column("OwnerId")]
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }


    }
}