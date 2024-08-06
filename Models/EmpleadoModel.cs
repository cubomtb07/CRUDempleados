using System.ComponentModel.DataAnnotations;

namespace CRUDempleados.Models
{
    public class EmpleadoModel
    {
        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio"), MinLength(3, ErrorMessage = "El Nombre debe tener mínimo 3 letras"), MaxLength(20)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Celular es obligatorio"), MinLength(10, ErrorMessage = "El celular al menos debe tener 10 números"), MaxLength(15)]
        public string? Celular { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un Cargo")]
        public string? Cargo { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

    }
}