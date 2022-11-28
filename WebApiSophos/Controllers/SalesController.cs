using Business;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;
using System.Configuration;

namespace WebApiSophos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SalesController : ApiController
    {
        public ApiBusiness Business = new ApiBusiness(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
        [HttpGet]
        public List<SalesGDto> Get()
        {
            return Business.GetSales();
        }

        [HttpPost]
        public IHttpActionResult Post(SalesDto SaleDto)
        {
            try
            {
                var sale = Business.PostSale(SaleDto);
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
