using AirConditionerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerShop.DAL.Repositories
{
    public class StaffMemberRepository
    {
        private AirConditionerShop2024DBContext _repo;

        public StaffMember? GetOne(string email, string password)
        {
            StaffMember? member;
            try
            {
                using (_repo = new())
                {
                    member = _repo.StaffMembers.FirstOrDefault(x => x.EmailAddress.ToLower() == email.ToLower() && x.Password == password);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
    }
}
