using System;
using System.Collections.Generic;
using System.Linq;
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

        protected virtual TModel BeforeDelete(TModel model)
        {
            return model;
        }

        public int DeleteById(int id)
        {
            try
            {
                TModel model = GetById(id);
                model = BeforeDelete(model);
                model.IsDeleted = true;
                _dbContext.Set<TModel>().Update(model);
                
                return _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<TModel> GetAll()
        {
            try
            {
                return _dbContext.Set<TModel>().AsEnumerable();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public TModel GetById(int id)
        {
            try
            {
                return _dbContext.Set<TModel>().Find(id);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int UpdateById(TModel model)
        {
            throw new System.NotImplementedException();
        }

        
        protected abstract TModel BeforeUpdate(TModel local, TModel db);

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