using Damco.Domain;
using Damco.Domain.Entites;
using Damco.Models.Request;
using Damco.Models.Response;
using Damco.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Damco.Service.Suppliers
{

    public class SuppliersService : ISuppliersService
    {
        private readonly IBaseService<damco_supplier> _damcoSupplierRepository;
        private readonly IBaseService<damco_supplier_rate> _damcoSupplierRateRepository;
        private readonly DamcoContext _context;
        public SuppliersService(IBaseService<damco_supplier> damcoSupplierRepository, IBaseService<damco_supplier_rate> damcoSupplierRateRepository, DamcoContext context)
        {
            _damcoSupplierRepository = damcoSupplierRepository;
            _damcoSupplierRateRepository = damcoSupplierRateRepository;
            _context = context;
        }
        public SupplierResponce AddSupplier(damco_supplier entity)
        {
            try
            {
                _damcoSupplierRepository.Insert(entity);
                var result = new SupplierResponce
                {
                    id = entity.id,
                    name = entity.name,
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SupplierRateResponce AddSupplierRate(damco_supplier_rate entity)
        {
            try
            {
                _damcoSupplierRateRepository.Insert(entity);
                var result = new SupplierRateResponce
                {
                    id = entity.id,
                    fk_supplier_id = entity.fk_supplier_id,
                    rate = entity.rate,
                    start_date = entity.start_date.ToString("dd MMM yyyy"),
                    end_date = entity.end_date != null ? entity.end_date.Value.ToString("dd MMM yyyy") : "",
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SupplierRateResponce> GetAllSuppliers()
        {
            try
            {
                var data = _context.damco_supplier_rate.Where(x => x.deleted_at == null).Select(x => new SupplierRateResponce
                {
                    id = x.id,
                    rate = x.rate,
                    fk_supplier_id = x.fk_supplier_id,
                    start_date = x.start_date.ToString("dd MMM yyyy"),
                    end_date = x.end_date != null ? x.end_date.Value.ToString("dd MMM yyyy") : "",
                }).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SupplierRateResponce> GetAllOverlappingSuppliers(Guid? supplier_number = null)
        {
            try
            {
                List<Guid> supplier_ids = new List<Guid>();

                List<SupplierRateResponce> _supplier_rate = new List<SupplierRateResponce>();
                var data = _context.damco_supplier_rate.Where(x => x.deleted_at == null && (supplier_number == null || (supplier_number != null && x.fk_supplier_id == supplier_number.Value))).Select(x => new SupplierRateResponce
                {
                    id = x.id,
                    rate = x.rate,
                    fk_supplier_id = x.fk_supplier_id,
                    start_date = x.start_date.ToString("dd MMM yyyy"),
                    end_date = x.end_date != null ? x.end_date.Value.ToString("dd MMM yyyy") : "",
                }).ToList();

                var unique_supplier = data.GroupBy(x => x.fk_supplier_id).Select(x => x.Key);

                foreach (var supplierID in unique_supplier)
                {
                    bool check_overlap = false;
                    var suppliers = data.Where(x => x.fk_supplier_id == supplierID).ToList();
                    if (suppliers.Count > 1)
                    {
                        for (int i = 0; i < suppliers.Count(); i++)
                        {
                            if((i + 1) != suppliers.Count())
                            {
                                if (suppliers[i].rate != suppliers[i + 1].rate)
                                {
                                    check_overlap = true;
                                    break;
                                }
                            }
                            
                        }
                    }
                    if (check_overlap)
                    {
                        supplier_ids.Add(supplierID);
                    }
                }

                if (supplier_ids.Count > 0)
                {
                    _supplier_rate = data.Where(x => supplier_ids.Contains(x.fk_supplier_id)).ToList();
                }

                return _supplier_rate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
