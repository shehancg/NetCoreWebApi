using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{
    public class AllocateSubjectsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllocateSubjectID { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int SubjectID { get; set; }

        [ForeignKey("TeacherID")]
        public TeacherModel Teacher { get; set; }

        [ForeignKey("SubjectID")]
        public SubjectModel Subject { get; set; }
    }
}
