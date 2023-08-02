﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class TeacherModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string ContactNo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string EmailAddress { get; set; }
    }
}