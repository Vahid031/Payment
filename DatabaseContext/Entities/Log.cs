using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("Logs", Schema = "General")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(2000)]
        public string Data { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        public DateTime Date { get; set; }
    }
}
