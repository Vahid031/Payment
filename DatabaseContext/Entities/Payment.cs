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

        public int? OriginalKey { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Amount { get; set; }

        [MaxLength(1000)]
        public string Data { get; set; }

        [MaxLength(100)]
        public string ReturnUrl { get; set; }

        [MaxLength(100)]
        public string Signature { get; set; }

        public ICollection<PaymentDetail> PaymentDetail { get; set; }

        public bool? IsClose { get; set; } = false;
    }
}
