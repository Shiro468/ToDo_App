using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Tytuł jest za długi, maksymalna ilość liter wynosi 10")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Czas ukończenia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        //[DataType(DataType.DateTime,ErrorMessage = "Shit still aint work")] Still doesnt work custom message for DateTime
        public DateTime FinishTime { get; set; }

    }
}