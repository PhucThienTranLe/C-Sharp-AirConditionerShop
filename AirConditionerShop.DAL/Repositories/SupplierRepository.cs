using AirConditionerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL.Repositories
{
    public class SupplierRepository
    {
        private AirConditionerShop2024DBContext? _context;
        public List<SupplierCompany> GetAll()
        {
            List<SupplierCompany> list = new List<SupplierCompany>();
            try
            {
                using (_context = new())
                {
                    list = _context.SupplierCompanies.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

    }
}
