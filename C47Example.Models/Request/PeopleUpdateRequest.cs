using System.ComponentModel.DataAnnotations;

namespace C47Example.Models.Request
{
    public class PeopleUpdateRequest : PeopleAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
