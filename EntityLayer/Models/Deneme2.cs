﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    [Table("Deneme2Table")]
    public class Deneme2
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string? SecondName { get; set; }

        [StringLength(50, MinimumLength = 2)]

        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}
