
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMO.Models
{
    [Table("EMPLEADOS", Schema = "JB")]
    [Index(nameof(ID_EMPLEADO),IsUnique =true)]
    public class EMPLEADOS
    {

        [Key]
        [Display(Name = "ID")]
        public int? ID_EMPLEADO { get; set; }

        [Required]
        [Display(Name = "Nombre Empleado")]
        [Column(TypeName = "varchar(250)")]
        public string N_EMPLEADO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Apellido Paterno")]
        [Column(TypeName = "varchar(250)")]
        public string A_PATERNO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Apellido Materno")]
        [Column(TypeName = "varchar(250)")]
        public string A_MATERNO { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime F_NACIMIENTO { get; set; } 


        [Required]
        [Display(Name = "Sueldo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SUELDO { get; set; }

        public int ID_DEPARTAMENTO{ get; set; }

        [ForeignKey("ID_DEPARTAMENTO")]
        public DEPARTAMENTO? DEPARTAMENTO { get; set; }
    }
}
