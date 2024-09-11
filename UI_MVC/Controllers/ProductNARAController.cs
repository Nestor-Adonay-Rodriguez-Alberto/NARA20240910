using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NARA20240910.DTOs.ProductDTOs;

namespace UI_MVC.Controllers
{
    public class ProductNARAController : Controller
    {
        private readonly HttpClient _httpClientCRMAPI;

        // Constructor que recibe una instancia de IHttpClientFactory para crear el cliente HTTP
        public ProductNARAController(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        // Método para mostrar la lista de clientes
        public async Task<IActionResult> Index(SearchQueryProductDTO searchQueryProductDTO, int CountRow = 0)
        {
            // Configuración de valores por defecto para la búsqueda
            if (searchQueryProductDTO.SendRowCount == 0)
                searchQueryProductDTO.SendRowCount = 2;
            if (searchQueryProductDTO.Take == 0)
                searchQueryProductDTO.Take = 10;


            var result = new SearchResultProductDTO();

            // Realizar una solicitud HTTP POST para buscar clientes en el servicio web
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/ProductNARA/search", searchQueryProductDTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultProductDTO>();

            result = result != null ? result : new SearchResultProductDTO();

            // Configuración de valores para la vista
            if (result.CountRow == 0 && searchQueryProductDTO.SendRowCount == 1)
                result.CountRow = CountRow;

            ViewBag.CountRow = result.CountRow;
            searchQueryProductDTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryProductDTO;

            return View(result);
        }


        // Método para mostrar los detalles de un cliente
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultProductDTO();

            // Realizar una solicitud HTTP GET para obtener los detalles del cliente por ID
            var response = await _httpClientCRMAPI.GetAsync("/ProductNARA/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();

            return View(result ?? new GetIdResultProductDTO());
        }


        // Método para mostrar el formulario de creación de un cliente
        public ActionResult Create()
        {
            return View();
        }


        // Método para procesar la creación de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDTO createProductDTO)
        {
            try
            {
                // Realizar una solicitud HTTP POST para crear un nuevo cliente
                var response = await _httpClientCRMAPI.PostAsJsonAsync("/ProductNARA", createProductDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar guardar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Método para mostrar el formulario de edición de un cliente
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultProductDTO();
            var response = await _httpClientCRMAPI.GetAsync("/ProductNARA/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();

            return View(new EditProductDTO(result ?? new GetIdResultProductDTO()));
        }

        // Método para procesar la edición de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductDTO editProductDTO)
        {
            try
            {
                // Realizar una solicitud HTTP PUT para editar el cliente
                var response = await _httpClientCRMAPI.PutAsJsonAsync("/ProductNARA", editProductDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar editar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Método para mostrar la página de confirmación de eliminación de un cliente
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultProductDTO();
            var response = await _httpClientCRMAPI.GetAsync("/ProductNARA/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();

            return View(result ?? new GetIdResultProductDTO());
        }

        // Método para procesar la eliminación de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultProductDTO getIdResultProductDTO)
        {
            try
            {
                // Realizar una solicitud HTTP DELETE para eliminar el cliente por ID
                var response = await _httpClientCRMAPI.DeleteAsync("/ProductNARA/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar eliminar el registro";
                return View(getIdResultProductDTO);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(getIdResultProductDTO);
            }
        }

    }
}
