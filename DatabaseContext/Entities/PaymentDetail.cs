using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities
{
    [Table("PaymentDetails", Schema = "General")]
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public State? State { get; set; }

        public DateTime? DateTime { get; set; }

        public int? OriginalUserId { get; set; }

        public int? PaymentRequestId { get; set; }

        [ForeignKey(nameof(PaymentRequestId))]
        public Payment PaymentRequest { get; set; }
    }
}
