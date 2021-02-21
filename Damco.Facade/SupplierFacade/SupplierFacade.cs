using Damco.Domain.Entites;
using Damco.Models.Request;
using Damco.Service.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Facade.SupplierFacade
{
    
    public class SupplierFacade : ISupplierFacade
    {
        private readonly ISuppliersService _suppliersService;
        public SupplierFacade(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }
        public ItemResult<object> CreateSupplier(SupplierRequest supplierRequest)
        {
            var result = ItemResult<object>.SuccessResult;
            try
            {
                result.data = _suppliersService.AddSupplier(SupplierRequest2Entity(supplierRequest));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemResult<object> CreateSupplierRate(SupplierRateRequest supplierRateRequest)
        {
            var result = ItemResult<object>.SuccessResult;
            try
            {
                result.data = _suppliersService.AddSupplierRate(SupplierRateRequest2Entity(supplierRateRequest));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Viewmodel 2 Entities
        private damco_supplier SupplierRequest2Entity(SupplierRequest data)
        {
            var entity = new damco_supplier
            {
                name = data.name,
            };
            return entity;
        }
        private damco_supplier_rate SupplierRateRequest2Entity(SupplierRateRequest data)
        {
            var entity = new damco_supplier_rate
            {
                rate = data.rate,
                fk_supplier_id = data.fk_supplier_id,
                start_date = data.start_date,
                end_date = data.end_date,
            };
            return entity;
        }
        public ListResult<object> GetAll()
        {
            var result = ListResult<object>.SuccessResult;
            try
            {
                result.data = _suppliersService.GetAllSuppliers();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult<object> GetAllOverlappingSuppliers(Guid? supplier_number = null)
        {
            var result = ListResult<object>.SuccessResult;
            try
            {
                result.data = _suppliersService.GetAllOverlappingSuppliers(supplier_number);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
