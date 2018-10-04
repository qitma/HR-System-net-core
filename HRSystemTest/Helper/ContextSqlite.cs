using System;
using System.Data.Common;
using HRSystemApi.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTest.Helper
{
    public class HelperDbContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<HRSystemContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<HRSystemContext>()
                .UseSqlite(_connection).Options;
        }

        public HRSystemContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("Datasource=:memory");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new HRSystemContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new HRSystemContext(CreateOptions());
        }
        public void Dispose()
        {
            if(_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}