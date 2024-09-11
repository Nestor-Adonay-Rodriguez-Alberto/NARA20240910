using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NARA20240910.Models.EN;

namespace NARA20240910.Models.DAL
{
    public class ProductNARADAL
    {
        // Representa La DB:
        readonly DBContext _context;

        // Constructor:
        public ProductNARADAL(DBContext dBContext)
        {
            _context = dBContext;
        }



        // Método para crear un nuevo cliente en la base de datos.
        public async Task<int> Create(ProductNARA productNARA)
        {
            _context.Add(productNARA);
            return await _context.SaveChangesAsync();
        }


        // Método para obtener un cliente por su ID.
        public async Task<ProductNARA> GetById(int id)
        {
            var Objeto_Obtenido = await _context.ProductsNARA.FirstOrDefaultAsync(s => s.Id == id);
            return Objeto_Obtenido != null ? Objeto_Obtenido : new ProductNARA();
        }


        // Método para editar un cliente existente en la base de datos.
        public async Task<int> Edit(ProductNARA productNARA)
        {
            int result = 0;
            var Objeto_Obtenido = await GetById(productNARA.Id);

            if (Objeto_Obtenido.Id != 0)
            {
                // Actualiza los datos del cliente.
                Objeto_Obtenido.NombreNARA = productNARA.NombreNARA;
                Objeto_Obtenido.DescripcionNARA = productNARA.DescripcionNARA;
                Objeto_Obtenido.Precio = productNARA.Precio;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }


        // Método para eliminar un cliente de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var Objeto_Obtenido = await GetById(id);
            if (Objeto_Obtenido.Id > 0)
            {
                // Elimina el cliente de la base de datos.
                _context.ProductsNARA.Remove(Objeto_Obtenido);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }


        // Método privado para construir una consulta IQueryable para buscar clientes con filtros.
        private IQueryable<ProductNARA> Query(ProductNARA productNARA)
        {
            var query = _context.ProductsNARA.AsQueryable();

            if (!string.IsNullOrWhiteSpace(productNARA.NombreNARA))
                query = query.Where(s => s.NombreNARA.Contains(productNARA.NombreNARA));

            return query;
        }


        // Método para contar la cantidad de resultados de búsqueda con filtros.
        public async Task<int> CountSearch(ProductNARA productNARA)
        {
            return await Query(productNARA).CountAsync();
        }


        // Método para buscar clientes con filtros, paginación y ordenamiento.
        public async Task<List<ProductNARA>> Search(ProductNARA productNARA, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(productNARA);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }



    }
}
