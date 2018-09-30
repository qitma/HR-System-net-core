using System;
using System.Collections.Generic;
namespace EmployeeAttendanceApi.Utils
{
    public interface IBaseService<TModel>{
        ICollection<TModel> GetAll();
        TModel GetById(int id);
        int Create(TModel model);
        int UpdateById(TModel model);
        int DeleteById(int id);
    }
}