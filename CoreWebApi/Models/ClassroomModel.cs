using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models
{
    public class ClassroomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ClassroomName { get; set;}
    }
}
