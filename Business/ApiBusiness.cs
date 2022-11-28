using Dal;
using Dto;
using System.Collections.Generic;

namespace Business
{
    public class ApiBusiness
    {
        public ApiDal Dal;
        /******  Metodos Controlador Productos  ***********/
        public ApiBusiness(string Conexion)
        {
            Dal = new ApiDal(Conexion);
        }
        public List<ProductsDto> Get()
        {
            return Dal.Get();
        }
        public ProductsDto GetById(int id)
        {
            return Dal.GetById(id);
        }
        public ProductsDto Post(ProductsDto productDto)
        {
            return Dal.Post(productDto);
        }
        public ProductsDto Update(ProductsDto productDto, int id)
        {
            return Dal.Update(productDto, id);
        }
        public bool Delete(int id)
        {
            return Dal.Delete(id);
        }
        /******  Metodos Controlador Clientes  ***********/
        public List<ClientsDto> GetClients()
        {
            return Dal.GetClients();
        }
        public ClientsDto GetClientById(int id)
        {
            return Dal.GetClientById(id);
        }
        public ClientsDto PostClient(ClientsDto clientDto)
        {
            return Dal.PostClient(clientDto);
        }
        public ClientsDto UpdateClient(ClientsDto clientDto, int id)
        {
            return Dal.UpdateClient(clientDto, id);
        }
        public bool DeleteClient(int id)
        {
            return Dal.DeleteClient(id);
        }
        public List<SalesGDto> GetSales()
        {
            return Dal.GetSales();
        }
        public SalesDto PostSale(SalesDto SaleDto)
        {
            return Dal.PostSale(SaleDto);
        }        
    }
}
