using AirConditionerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL.Repositories
{
    public class AirConRepository
    {
        private AirConditionerShop2024DBContext? _context;

        //CRUD
        public List<AirConditioner> GetAll()
        {
            List<AirConditioner> list = new List<AirConditioner>();
            try
            {
                using (_context = new())
                {
                    list = _context.AirConditioners.Include("Supplier").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public void Add(AirConditioner airConditioner)
        {
            try
            {
                using (_context = new())
                {
                    _context.AirConditioners.Add(airConditioner);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(AirConditioner airConditioner)
        {
            try
            {
                using (_context = new())
                {
                    _context.AirConditioners.Update(airConditioner);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(AirConditioner airConditioner)
        {
            try
            {
                using (_context = new())
                {
                    _context.AirConditioners.Remove(airConditioner);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
