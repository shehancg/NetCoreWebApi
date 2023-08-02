using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class SubjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string SubjectName { get; set; }
    }
}
