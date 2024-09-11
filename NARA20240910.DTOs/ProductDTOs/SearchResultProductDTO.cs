using System.ComponentModel.DataAnnotations;

namespace NARA20240910.DTOs.ProductDTOs
{
    public class SearchResultProductDTO
    {
        // ATRIBUTOS:
        public int CountRow { get; set; }
        public List<ProductNARADTO> Data { get; set; }

        // CLASE:
        public class ProductNARADTO
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
}
