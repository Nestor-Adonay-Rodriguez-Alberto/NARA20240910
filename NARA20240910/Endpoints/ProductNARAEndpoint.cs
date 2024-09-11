using NARA20240910.DTOs.ProductDTOs;
using NARA20240910.Models.DAL;
using NARA20240910.Models.EN;

namespace NARA20240910.Endpoints
{
    public static class ProductNARAEndpoint
    {
        // Método para configurar los endpoints relacionados con los clientes
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            // BUSCA TODOS:
            // Configurar un endpoint de tipo POST para buscar clientes
            app.MapPost("/ProductNARA/search", async (SearchQueryProductDTO productNARADTO, ProductNARADAL productNARADAL) =>
            {
                // Crear un objeto 'Customer' a partir de los datos proporcionados
                var Objeto_Producto = new ProductNARA
                {
                    NombreNARA = productNARADTO.NombreNARA_Like != null ? productNARADTO.NombreNARA_Like : string.Empty,
                    DescripcionNARA = productNARADTO.DescripcionNARA_Like != null ? productNARADTO.DescripcionNARA_Like : string.Empty
                };

                // Inicializar una lista de clientes y una variable para contar las filas
                var Lista_Productos = new List<ProductNARA>();
                int countRow = 0;

                // Verificar si se debe enviar la cantidad de filas
                if (productNARADTO.SendRowCount == 2)
                {
                    // Realizar una búsqueda de productos y contar las filas
                    Lista_Productos = await productNARADAL.Search(Objeto_Producto, skip: productNARADTO.Skip, take: productNARADTO.Take);
                   
                    if (Lista_Productos.Count > 0)
                        countRow = await productNARADAL.CountSearch(Objeto_Producto);
                }
                else
                {
                    // Realizar una búsqueda de clientes sin contar las filas
                    Lista_Productos = await productNARADAL.Search(Objeto_Producto, skip: productNARADTO.Skip, take: productNARADTO.Take);
                }

                // Crear un objeto 'SearchResultCustomerDTO' para almacenar los resultados
                var customerResult = new SearchResultProductDTO
                {
                    Data = new List<SearchResultProductDTO.ProductNARADTO>(),
                    CountRow = countRow
                };

                // Mapear los resultados a objetos 'CustomerDTO' y agregarlos al resultado
                Lista_Productos.ForEach(s => {
                    customerResult.Data.Add(new SearchResultProductDTO.ProductNARADTO
                    {
                        Id = s.Id,
                        NombreNARA = s.NombreNARA,
                        DescripcionNARA = s.DescripcionNARA,
                        Precio = s.Precio
                    });
                });

                // Devolver los resultados
                return customerResult;
            });


            // OBTENER 1:
            // Configurar un endpoint de tipo GET para obtener un cliente por ID
            app.MapGet("/ProductNARA/{id}", async (int id, ProductNARADAL productNARADAL) =>
            {
                // Obtener un cliente por ID
                var Objeto_Obtenido = await productNARADAL.GetById(id);

                // Crear un objeto 'GetIdResultCustomerDTO' para almacenar el resultado
                var ProductResult = new GetIdResultProductDTO
                {
                    Id = Objeto_Obtenido.Id,
                    NombreNARA = Objeto_Obtenido.NombreNARA,
                    DescripcionNARA = Objeto_Obtenido.DescripcionNARA,
                    Precio = Objeto_Obtenido.Precio
                };

                // Verificar si se encontró el Producto y devolver la respuesta correspondiente
                if (ProductResult.Id > 0)
                    return Results.Ok(ProductResult);
                else
                    return Results.NotFound(ProductResult);
            });


            // CREAR:
            // Configurar un endpoint de tipo POST para crear un nuevo cliente
            app.MapPost("/ProductNARA", async (CreateProductDTO createProductDTO, ProductNARADAL productNARADAL) =>
            {
                // Crear un objeto 'Customer' a partir de los datos proporcionados
                var Objeto_Producto = new ProductNARA
                {
                    NombreNARA = createProductDTO.NombreNARA,
                    DescripcionNARA = createProductDTO.DescripcionNARA,
                    Precio = createProductDTO.Precio
                };

                // Intentar crear el cliente y devolver el resultado correspondiente
                int result = await productNARADAL.Create(Objeto_Producto);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });


            // MODIFICAR:
            // Configurar un endpoint de tipo PUT para editar un cliente existente
            app.MapPut("/ProductNARA", async (EditProductDTO editProductDTO, ProductNARADAL productNARADAL) =>
            {
                // Crear un objeto 'ProductoNARA' a partir de los datos proporcionados
                var Objeto_Producto = new ProductNARA
                {
                    Id = editProductDTO.Id,
                    NombreNARA = editProductDTO.NombreNARA,
                    DescripcionNARA = editProductDTO.DescripcionNARA,
                    Precio = editProductDTO.Precio
                };

                // Intentar editar el cliente y devolver el resultado correspondiente
                int result = await productNARADAL.Edit(Objeto_Producto);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });


            // ELIMINAR:
            // Configurar un endpoint de tipo DELETE para eliminar un cliente por ID
            app.MapDelete("/ProductNARA/{id}", async (int id, ProductNARADAL productNARADAL) =>
            {
                // Intentar eliminar el cliente y devolver el resultado correspondiente
                int result = await productNARADAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

        }


    }
}
