using NARA20240910.DTOs.ProductDTOs;

namespace UI_Blazor.Data
{
    public class ProductNARAService 
    {
        readonly HttpClient _httpClientCRMAPI;

        // Constructor que recibe una instancia de IHttpClientFactory para crear el cliente HTTP
        public ProductNARAService(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        // Método para buscar clientes utilizando una solicitud HTTP POST
        public async Task<SearchResultProductDTO> Search(SearchQueryProductDTO searchQueryProductDTO)
        {
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/ProductNARA/search", searchQueryProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultProductDTO>();
                return result ?? new SearchResultProductDTO();
            }
            return new SearchResultProductDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }


        // Método para obtener un cliente por su ID utilizando una solicitud HTTP GET
        public async Task<GetIdResultProductDTO> GetById(int id)
        {
            var response = await _httpClientCRMAPI.GetAsync("/ProductNARA/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultProductDTO>();
                return result ?? new GetIdResultProductDTO();
            }
            return new GetIdResultProductDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para crear un nuevo cliente utilizando una solicitud HTTP POST
        public async Task<int> Create(CreateProductDTO createProductDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/ProductNARA", createProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para editar un cliente existente utilizando una solicitud HTTP PUT
        public async Task<int> Edit(EditProductDTO editProductDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PutAsJsonAsync("/ProductNARA", editProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para eliminar un cliente por su ID utilizando una solicitud HTTP DELETE
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.DeleteAsync("/ProductNARA/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

    }
}
