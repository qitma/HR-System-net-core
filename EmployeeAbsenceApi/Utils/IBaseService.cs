using System;
using System.Collections.Generic;
namespace HRSystemApi.Utils
{
    public interface IBaseService<TModel>{
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
        int Create(TModel model);
        int DeleteById(int id);
        TModel Update(TModel model);
    }
}