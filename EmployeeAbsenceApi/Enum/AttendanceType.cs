using System;

namespace EmployeeAttendanceApi.AbsenceEnum
{
    [Flags]public enum AttendanceType
    {
        IN = 0,
        OUT = 1
    }
}