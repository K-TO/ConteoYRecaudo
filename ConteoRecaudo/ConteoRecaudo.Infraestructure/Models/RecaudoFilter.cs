using System.ComponentModel.DataAnnotations;

namespace ConteoRecaudo.API.Models
{
    public class RecaudoFilter
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        //[RegularExpression("^$[a-zA-Z 0-9áéíóúñÁÉÍÓÚÑ]", ErrorMessage = "El nombre de la estación tiene caracteres no permitidos.")]
        [MaxLength(50, ErrorMessage = "La estación no debe tener mas de 50 caracteres.")]
        //[MinLength(2, ErrorMessage = "La estación no debe tener menos de 2 caracteres.")]
        public string? Estacion { get; set; }

        [RangeUntilCurrentYear(2000)]
        public int? Anio { get; set; }
    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {

        }
    }

}