using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMO.Models
{
    [Table ("DEPARTAMENTO",Schema="JB")]
    [Index(nameof(ID_DEPARTAMENTO), IsUnique = true)]
    public class DEPARTAMENTO
    {
        
        [Key]
        [Display(Name="ID")]
        public int ID_DEPARTAMENTO { get; set; }
        [Required]
        [Display(Name ="Nombre del Departamento")]
        [Column(TypeName ="varchar(50)")]
        public string N_DEPARTAMENTO { get; set; }= string.Empty;



    }
}
