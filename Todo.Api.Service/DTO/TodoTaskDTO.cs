using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Service.DTO
{
    public class TodoTaskDTO
    {
        public string CreationDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string ModificationDate { get; set; }
        public bool Status { get; set; }
        public int Id { get; set; }
    }
}
