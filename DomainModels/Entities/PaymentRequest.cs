using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DomainModels.Enums;

namespace DomainModels.Entities
{
    [Table("PaymentRequests", Schema = "General")]
    public class PaymentRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public int? OriginalKey { get; set; }

        [MaxLength(1000)]
        public string Data { get; set; }

        public State? State { get; set; }

        public DateTime? Date { get; set; }

        public int? OriginalUserId { get; set; }
    }
}
