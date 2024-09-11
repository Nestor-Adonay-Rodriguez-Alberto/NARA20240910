using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NARA20240910.DTOs.ProductDTOs
{
    public class EditProductDTO
    {
        // Constructor #1:
        public EditProductDTO(GetIdResultProductDTO getIdResultProductDTO)
        {
            Id = getIdResultProductDTO.Id;
            NombreNARA = getIdResultProductDTO.NombreNARA;
            DescripcionNARA = getIdResultProductDTO.DescripcionNARA;
            Precio = getIdResultProductDTO.Precio;
        }

        // Constructor #2:
        public EditProductDTO()
        {
            NombreNARA = string.Empty;
            DescripcionNARA = string.Empty;
        }


        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "NombreNARA")]
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
