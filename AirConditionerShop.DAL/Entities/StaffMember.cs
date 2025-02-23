using System;
using System.Collections.Generic;

namespace AirConditionerShop.DAL.Entities
{
    public partial class StaffMember
    {
        public int MemberId { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int? Role { get; set; }
    }
}
