namespace EmployeeAttendanceApi.Interfaces
{
    public interface IAttendanceService{
        void AttendanceIn(string userId);
        void AttendanceOut(string userId);
    }
}