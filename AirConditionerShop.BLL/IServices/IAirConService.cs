using AirConditionerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.BLL.IServices
{
    public interface IAirConService
    {
        List<AirConditioner> GetAllAirCons();
        void AddAirCon(AirConditioner airCon);
        void UpdateAirCon(AirConditioner airCon);
        void DeleteAirCon(AirConditioner airCon);

        List<AirConditioner> SearchAirConByFeatureAndQuantity(string feature, int? quantity);
    }
}
