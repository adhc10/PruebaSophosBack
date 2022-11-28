using Business;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;
using System.Configuration;

namespace WebApiSophos.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ProductsController : ApiController
    {
        public ApiBusiness Business = new ApiBusiness(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);

        [HttpGet]
        public List<ProductsDto> Get()
        {
            return Business.Get();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = Business.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IHttpActionResult Post(ProductsDto productDto)
        {            
            try
            {
                var product = Business.Post(productDto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(ProductsDto productDto, int id)
        {
            if (productDto.idProducto != id)
            {
                return BadRequest();
            }
            var flag = Business.GetById(id);
            if (flag == null)
            {
                return NotFound();
            }
            try
            {               
                var product = Business.Update(productDto, id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var flag = Business.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                Business.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
