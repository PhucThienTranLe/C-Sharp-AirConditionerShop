using AirConditionerShop.BLL.IServices;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.BLL.Services
{
    public class StaffMemberService : IStaffMemberService
    {
        private StaffMemberRepository _repo = new();

        public StaffMember? Authenticate(string email, string password) => _repo.GetOne(email, password);
    }
}
