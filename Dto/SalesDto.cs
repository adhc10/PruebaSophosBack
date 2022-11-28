using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class SalesDto
    {
        public int idVenta { get; set; }
        public int Cantidad { get; set; }
        public string ValorTotal { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
    }
    public class SalesGDto
    {
        public int idVenta { get; set; }
        public int Cantidad { get; set; }
        public string ValorTotal { get; set; }
        public string NombreProducto { get; set; }
        public string NombreCliente { get; set; }
    }
}
