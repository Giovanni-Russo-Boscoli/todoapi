using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Model
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string CreationDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string ModificationDate { get; set; }
        public bool Status { get; set; }
    }
}
