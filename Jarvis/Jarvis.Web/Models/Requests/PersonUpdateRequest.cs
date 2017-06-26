using System.ComponentModel.DataAnnotations;

namespace Jarvis.Web.Models.ViewModels
{
    public class PersonUpdateRequest : PersonAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}