namespace OCBCDemo.Business.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BirthDate { get; set; }

        [StringLength(10)]
        public string Sexy { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public decimal PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
