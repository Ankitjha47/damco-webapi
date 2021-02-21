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
    [Route("api/v1/supplierrate")]
    [ApiController]
    public class SupplierRateController : ControllerBase
    {

        private readonly ISupplierFacade _supplierFacade;
        private readonly ILogger<SupplierController> _logger;
        public SupplierRateController(ISupplierFacade supplierFacade, ILogger<SupplierController> logger)
        {
            _supplierFacade = supplierFacade;
            _logger = logger;
        }

        [HttpPost]
        public JsonResult Post(SupplierRateRequest request)
        {
            _logger.LogInformation("Data Insertion started" + JsonSerializer.Serialize(request.ToString()));
            int status = StatusCodes.Status200OK;
            var result = ItemResult<object>.SuccessResult;
            try
            {
                result = _supplierFacade.CreateSupplierRate(request);
                _logger.LogInformation("Data Insertion completed" + request.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in api/v1/supplier-rate:" + ex.Message);
                status = StatusCodes.Status500InternalServerError;
                result.Failed(ex.Message);
            }
            return new JsonResult(result)
            {
                StatusCode = status
            };
        }
        [HttpGet]
        public JsonResult Get()
        {
            _logger.LogInformation("Data load started");
            int status = StatusCodes.Status200OK;
            var result = ListResult<object>.SuccessResult;
            try
            {
                result = _supplierFacade.GetAll();
                _logger.LogInformation("Data loaded successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in api/v1/supplier-rate:" + ex.Message);
                result.Failed(ex.Message);
                status = StatusCodes.Status500InternalServerError;
            }
            return new JsonResult(result) { StatusCode = status };
        }
        [HttpGet("overlap-suppliers")]
        public JsonResult Get(Guid? supplier_number = null)
        {
            _logger.LogInformation("Data load started");
            int status = StatusCodes.Status200OK;
            var result = ListResult<object>.SuccessResult;
            try
            {
                result = _supplierFacade.GetAllOverlappingSuppliers(supplier_number);
                _logger.LogInformation("Data loaded successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in api/v1/supplier-rate:" + ex.Message);
                result.Failed(ex.Message);
                status = StatusCodes.Status500InternalServerError;
            }
            return new JsonResult(result) { StatusCode = status };
        }
    }
}