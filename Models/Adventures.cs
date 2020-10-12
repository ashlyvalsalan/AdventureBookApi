using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adventure.Models
{
    public class Adventures

    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int adventureId { get; set; }
        [Required]
        public string adventureName { get; set; }
        [Required]
        public string adventureDescription { get; set; }
    }
}
