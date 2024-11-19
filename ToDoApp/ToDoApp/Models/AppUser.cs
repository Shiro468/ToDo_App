using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class AppUser //: IdentityUser
    {
        public int Id { get; set; }
        public DateTime Creation_time { get; set; }

        [ForeignKey("FinishTime")]
        public int FinishTimeID { get; set; }
    }
}