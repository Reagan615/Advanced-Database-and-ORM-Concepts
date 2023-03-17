
using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Lab03.Models
{
    public class Room
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(1, 6, ErrorMessage = "Capacity must be between 1 and 6.")]
        public int Capacity { get; set; }
        public enum Section
        {
            First,
            Second,
            Third
        }
    }
}
