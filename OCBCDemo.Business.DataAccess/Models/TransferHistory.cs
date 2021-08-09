namespace OCBCDemo.Business.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransferHistory")]
    public partial class TransferHistory
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }

        [Required]
        [StringLength(100)]
        public string RecipientEmail { get; set; }

        public DateTime TransferDate { get; set; }

        public decimal TransferAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
