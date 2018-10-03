using System;

namespace EmployeeAttendanceApi.Interfaces
{
    public interface IAttendanceService{
        void AttendanceIn(DateTime timeIn,string userId);
        void AttendanceOut(DateTime timeOut,string userId);
    }
}