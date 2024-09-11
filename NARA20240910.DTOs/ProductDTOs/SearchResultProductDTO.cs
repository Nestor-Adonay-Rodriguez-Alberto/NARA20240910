using System.ComponentModel.DataAnnotations;

namespace NARA20240910.DTOs.ProductDTOs
{
    public class SearchResultProductDTO
    {
        // ATRIBUTOS:
        public int CountRow { get; set; }
        public List<ProductNARA> Data { get; set; }

        // CLASE:
        public class ProductNARA
        {
            public int Id { get; set; }

            [Display(Name = "NombreNARA")]
            public string Name { get; set; }


            [Display(Name = "DescripcionNARA")]
            public string? DescripcionNARA { get; set; }


            [Display(Name = "Precio")]
            public string Precio { get; set; }
        }

    }
}
