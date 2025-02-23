using AirConditionerShop.BLL.IServices;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.BLL.Services
{
    public class AirConService : IAirConService
    {
        private AirConRepository _repo = new();
        public List<AirConditioner> GetAllAirCons() => _repo.GetAll();
        public void AddAirCon(AirConditioner airCon) => _repo.Add(airCon);
        public void UpdateAirCon(AirConditioner airCon) => _repo.Update(airCon);
        public void DeleteAirCon(AirConditioner airCon) => _repo.Delete(airCon);

        public List<AirConditioner> SearchAirConByFeatureAndQuantity(string feature, int? quantity)
        {
            List<AirConditioner> result = _repo.GetAll();
            if (feature.IsNullOrEmpty() && !quantity.HasValue) return result;

            if(!feature.IsNullOrEmpty()) result = result.Where(x => x.FeatureFunction.ToLower().Contains(feature.ToLower()))
                                                        .ToList();
            if(quantity.HasValue) result = result.Where(x => x.Quantity == quantity)
                                                 .ToList();      
            return result;
        }
    }

}

