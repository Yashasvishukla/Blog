using System;
namespace ToDo.API.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreationTime { get; set; }

    }
}