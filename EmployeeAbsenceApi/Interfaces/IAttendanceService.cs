using System;

namespace HRSystemApi.Interfaces
{
    public interface IAttendanceService{
        void Attendance(DateTime timeAttend,string userId);
    }
}