using System.Collections.Generic;
using Dto;

namespace Dal
{
    public class ApiDal : DapperDal
    {
        public ApiDal(string conString)
        {
            Conexion = conString;
        }
        public List<ProductsDto> Get()
        {
            return ListQuery<object, ProductsDto>("dbo.GetAllProducts", new { });
        }
        public ProductsDto GetById(int id)
        {
            return SingleQuery<object, ProductsDto>("dbo.GetProductById", new { idProducto=id});
        }
        public ProductsDto Post(ProductsDto productDto)
        {
            var resp=SingleQuery<ProductsDto, bool>("dbo.CreateProduct", productDto);
            return productDto;
        }
        public ProductsDto Update(ProductsDto productDto, int id)
        {
            var resp = SingleQuery<object, ProductsDto>("dbo.UpdateProduct", new { idProducto = id ,Nombre=productDto.Nombre,ValorUnitario=productDto.ValorUnitario});
            return productDto;
        }
        public bool Delete(int id)
        {
            var resp= SingleQuery<object, ProductsDto>("dbo.DeleteProduct", new { idProducto = id });
            return true;
        }
        /******  Metodos Controlador Clientes  ***********/
        public List<ClientsDto> GetClients()
        {
            return ListQuery<object, ClientsDto>("dbo.GetAllClients", new { });
        }
        public ClientsDto GetClientById(int id)
        {
            return SingleQuery<object, ClientsDto>("dbo.GetClientById", new { idCliente = id });
        }
        public ClientsDto PostClient(ClientsDto clientDto)
        {
            var resp = SingleQuery<ClientsDto, bool>("dbo.CreateClient", clientDto);
            return clientDto;
        }
        public ClientsDto UpdateClient(ClientsDto clientDto, int id)
        {
            var resp = SingleQuery<object, ClientsDto>("dbo.UpdateClient", new { idCliente = id, Cedula = clientDto.Cedula, Nombre = clientDto.Nombre, Apellido = clientDto.Apellido, Telefono = clientDto.Telefono });
            return clientDto;
        }
        public bool DeleteClient(int id)
        {
            var resp = SingleQuery<object, ClientsDto>("dbo.DeleteClient", new { idCliente = id });
            return true;
        }
        /******  Metodos Controlador Ventas  ***********/
        public List<SalesGDto> GetSales()
        {
            return ListQuery<object, SalesGDto>("dbo.GetAllSales", new { });
        }
        public SalesDto PostSale(SalesDto SaleDto)
        {
            var resp = SingleQuery<SalesDto, bool>("dbo.CreateSale", SaleDto);
            return SaleDto;
        }
    }
}
