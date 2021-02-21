using Damco.Domain.Entites;
using Damco.Models.Request;
using Damco.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Service.Suppliers
{
    public interface ISuppliersService
    {
        SupplierResponce AddSupplier(damco_supplier entity);
        SupplierRateResponce AddSupplierRate(damco_supplier_rate entity);
        List<SupplierRateResponce> GetAllSuppliers();
        List<SupplierRateResponce> GetAllOverlappingSuppliers(Guid? supplier_number = null);
    }
}
