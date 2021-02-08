using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Dtos
{
    public class UserForBlogDto
    {
        [Required]  
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string PhotoUrl { get; set; }
    }
}