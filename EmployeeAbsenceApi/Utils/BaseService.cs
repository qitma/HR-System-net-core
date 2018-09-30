using System;
using System.Collections.Generic;
using EmployeeAttendanceApi.Context;

namespace EmployeeAttendanceApi.Utils
{
    public abstract class BaseService<TModel> : IBaseService<TModel>, IDisposable
        where TModel : BaseModel
    {
        public  AttendanceContext _dbContext {get; private set;}
        public BaseService(AttendanceContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected abstract IEnumerable<ValidationResult> Validate(TModel model);

        protected virtual TModel BeforeCreating(TModel model)
        {
            return model;
        }

        public int Create(TModel model)
        {
          try
          {
              List<ValidationResult> errors = new List<ValidationResult>(Validate(model));
              if(errors.Count != 0)
              {
                  throw new ValidationException(errors,"Error Found");
              }
              var _model = BeforeCreating(model);  
              _dbContext.Set<TModel>().Add(_model);
              return _dbContext.SaveChanges();
          }
          catch(Exception ex)
          {
              throw;
          }
        }

        public int DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateById(TModel model)
        {
            throw new System.NotImplementedException();
        }

        

        protected virtual TModel AfterCreating(TModel model)
        {
            return model;
        }

        protected abstract TModel BeforeUpdate(TModel local, TModel db);

        protected virtual TModel AfterUpdate(TModel model)
        {
            return model;
        }

        protected virtual TModel BeforeDelete(TModel model)
        {
            return model;
        }

        protected virtual TModel AfterDelete(TModel model)
        {
            return model;
        }

        public void Dispose()
        {
            if(this._dbContext != null)
            {
                this._dbContext.Dispose();
                this._dbContext = null;
            }
        }


        
    }
}