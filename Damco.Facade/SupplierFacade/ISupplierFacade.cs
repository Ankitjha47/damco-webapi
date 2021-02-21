using Damco.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Facade.SupplierFacade
{
    public interface ISupplierFacade
    {
        ItemResult<object> CreateSupplier(SupplierRequest supplierRequest);
        ItemResult<object> CreateSupplierRate(SupplierRateRequest supplierRateRequest);
        ListResult<object> GetAll();
        ListResult<object> GetAllOverlappingSuppliers(Guid? supplier_number = null);
    }
}
