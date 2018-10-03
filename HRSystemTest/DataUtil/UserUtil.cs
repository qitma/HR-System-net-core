using System.Collections.Generic;
using EmployeeAttendanceApi.Models;

namespace HRSystemTest.DataUtil
{
    public class UserDataUtil
    {
        public User GetUserUtil()
        {
            return new User()
            {
                Code = "MMH",
                Email = "dataTest@gmail.com",
                FullName = "Qitma Hendra",
                Name = "Qitma",
                PhoneNumber = "082126153031"
            };
        }
    }
}