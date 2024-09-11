using System.ComponentModel.DataAnnotations;


namespace NARA20240910.DTOs.ProductDTOs
{
    public class SearchQueryProductDTO
    {
        [Display(Name = "NombreNARA")]
        public string? NombreNARA_Like { get; set; }


        [Display(Name = "DescripcionNARA")]
        public string? DescripcionNARA_Like { get; set; }


        [Display(Name = "Pagina")]
        public int Skip { get; set; }


        [Display(Name = "CantReg X Pagina")]
        public int Take { get; set; }

        /// <summary>
        /// 1 = No se cuenta los resultados de la busqueda
        /// 2= Cuenta los resultados de la busqueda
        /// </summary>
        public byte SendRowCount { get; set; }
    }
}
