using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain.Entities
{
    [Table("Payments", Schema = "General")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [MaxLength(15)]
        public string BilligId { get; set; }

        [MaxLength(15)]
        public string PaymentCode { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Amount { get; set; }

        [MaxLength(100)]
        public string ReturnUrl { get; set; }

        [MaxLength(300)]
        public string Signature { get; set; }

        [MaxLength(20)]
        public string OriginalUserId { get; set; }

        public IList<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
    }
}
