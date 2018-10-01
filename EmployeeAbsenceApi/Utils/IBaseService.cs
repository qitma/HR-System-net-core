using System;
using System.Collections.Generic;
namespace EmployeeAttendanceApi.Utils
{
    public interface IBaseService<TModel>{
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
        int Create(TModel model);
        int Update(TModel model);
        int DeleteById(int id);
    }
}