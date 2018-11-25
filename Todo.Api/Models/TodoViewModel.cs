using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Api.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string CreationDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string ModificationDate { get; set; }
        public bool Status { get; set; }
        public int ListaTodoId {get;set;}
    }
}
