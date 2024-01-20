namespace SparkleAir.Infa.EFModel.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageBoxId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime SendTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3000)]
        public string MessageContent { get; set; }

        public int? MemberId { get; set; }

        public int? CompanyStaffId { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsReaded { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReadedTime { get; set; }

        public virtual CompanyStaff CompanyStaff { get; set; }

        public virtual Member Member { get; set; }

        public virtual MessageBox MessageBox { get; set; }
    }
}
