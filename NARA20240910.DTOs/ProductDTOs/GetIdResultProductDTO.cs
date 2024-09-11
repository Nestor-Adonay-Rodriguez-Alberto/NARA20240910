using System.ComponentModel.DataAnnotations;


namespace NARA20240910.DTOs.ProductDTOs
{
    public class GetIdResultProductDTO
    {
        public int Id { get; set; }

        [Display(Name = "NombreNARA")]
        public string NombreNARA { get; set; }

        [Display(Name = "DescripcionNARA")]
        public string? DescripcionNARA { get; set; }

        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
