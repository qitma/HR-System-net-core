using EmployeeAttendanceApi.Utils;
using EmployeeAttendanceApi.Models;
using EmployeeAttendanceApi.Context;

namespace EmployeeAttendanceApi.Service
{
    public class AttendanceService : BaseService<Attendance>
    {
        public AttendanceService(AttendanceContext dbContext) : base(dbContext)
        {
        }
    }
}