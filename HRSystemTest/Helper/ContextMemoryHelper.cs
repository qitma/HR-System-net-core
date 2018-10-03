using EmployeeAttendanceApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace HRSystemTest.Helper
{
    public static class ContextMemoryHelper
    {
        public static HRSystemContext GetContext (string contextName)
        {
            var options = new DbContextOptionsBuilder<HRSystemContext>()
                .UseInMemoryDatabase(contextName)
                .Options;

            return new HRSystemContext(options);
        }
    }
}