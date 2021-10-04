using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiceLandPOCOs
{
    public abstract class BaseModel
    {
        [Column(TypeName = "datetime")]
        [Display(Name = "Create Date")]
        [ReadOnly(true)]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Create User")]
        [ReadOnly(true)]
        [StringLength(254)]
        public string CreateUser { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Maintenance Date")]
        [ReadOnly(true)]
        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MaintenanceDate { get; set; }

        [Display(Name = "Maintenance User")]
        [ReadOnly(true)]
        [StringLength(256)]
        public string MaintenanceUser { get; set; }
    }
}