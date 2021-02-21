using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Damco.Facade.SupplierFacade;
using Damco.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Damco.Api.Controllers.v1
{
    [Route("api/v1/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplierFacade _supplierFacade;
        private readonly ILogger<SupplierController> _logger;
        public SupplierController(ISupplierFacade supplierFacade, ILogger<SupplierController> logger)
        {
            _supplierFacade = supplierFacade;
            _logger = logger;
        }

        [HttpPost]
        public JsonResult Post(SupplierRequest request)
        {
            _logger.LogInformation("Data Insertion started" + JsonSerializer.Serialize(request.ToString()));
            int status = StatusCodes.Status200OK;
            var result = ItemResult<object>.SuccessResult;

            try
            {
                result = _supplierFacade.CreateSupplier(request);
                _logger.LogInformation("Data Insertion completed" + request.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in api/v1/supplier:" + ex.Message);
                status = StatusCodes.Status500InternalServerError;
                result.Failed(ex.Message);
            }
            return new JsonResult(result)
            {
                StatusCode = status
            };
        }
    }
}