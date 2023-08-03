using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models
{
    public class AllocateClassroomsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllocateClassroomID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int ClassroomID { get; set; }

        [ForeignKey("TeacherID")]
        public TeacherModel Teacher { get; set; }

        [ForeignKey("ClassroomID")]
        public ClassroomModel Classroom { get; set; }
    }
}
