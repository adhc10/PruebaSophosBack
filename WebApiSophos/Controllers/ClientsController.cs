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
    public class ClientsController : ApiController
    {
        public ApiBusiness Business = new ApiBusiness(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);

        [HttpGet]
        public List<ClientsDto> Get()
        {
            return Business.GetClients();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var client = Business.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        [HttpPost]
        public IHttpActionResult Post(ClientsDto clientDto)
        {
            try
            {
                var client = Business.PostClient(clientDto);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(ClientsDto clientDto, int id)
        {
            if (clientDto.idCliente != id)
            {
                return BadRequest();
            }
            var flag = Business.GetClientById(id);
            if (flag == null)
            {
                return NotFound();
            }
            try
            {
                var client = Business.UpdateClient(clientDto, id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var flag = Business.GetClientById(id);

            if (flag == null)
                return NotFound();

            try
            {
                Business.DeleteClient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
