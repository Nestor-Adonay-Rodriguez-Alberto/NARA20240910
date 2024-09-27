using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NARA20240910.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string NombreNARA { get; set; }

        [Display(Name = "DescripcionNARA")]
        [MaxLength(50, ErrorMessage = "El campo Descripcion no puede tener más de 50 caracteres.")]
        public string? DescripcionNARA { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo Precio es obligatorio.")] 
        public decimal Precio { get; set; }
    }
}
