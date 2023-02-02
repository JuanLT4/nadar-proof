
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using spProof.Models;
using System.Data;
using System.Data.SqlClient;

using System.Threading.Tasks;


namespace spProof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ClientController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> getAllClient()
        {

                    {
                        var parameters = new DynamicParameters();
                        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                        var clients = await connection.QueryAsync<Client>("[dbo].[paCrudPruebaN]", parameters, commandType: CommandType.StoredProcedure);
                        var jsonClients = JsonConvert.SerializeObject(clients);

                        return Ok(jsonClients);
                        
                      
                    }
                }

         [HttpPost]

            public async Task<ActionResult> CreateOrDeleteClientesSectorMinero(ClientParametersClass parameters)
            {
              var intId = parameters.intId;

              var strNombre = parameters.strNombre;

              var strDocumento = parameters.strDocumento;

              var intEdad = parameters.intEdad;

              var strDomicilio = parameters.strDomicilio;

              var strNumeroTel = parameters.strNumeroTel;

              var strCorreo = parameters.strCorreo;

              var intAccion = parameters.intAccion;


              using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
              {

                await connection.QueryAsync("[dbo].[paAccionesCrudN]", new { intId = intId, strNombre = strNombre, strDocumento = strDocumento, intEdad = intEdad, strDomicilio = strDomicilio, strNumeroTel = strNumeroTel, strCorreo = strCorreo, intAccion = intAccion }, commandType: CommandType.StoredProcedure);

                return StatusCode(200);
              }

            }
         }



}
