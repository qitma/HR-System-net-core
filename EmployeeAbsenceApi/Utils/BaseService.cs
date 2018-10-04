using System;
using System.Collections.Generic;
using System.Linq;
using HRSystemApi.Context;
using Microsoft.EntityFrameworkCore;

namespace HRSystemApi.Utils
{
    public abstract class BaseService<TModel> : IBaseService<TModel>, IDisposable
        where TModel : BaseModel
    {
        private string _Actor{get;set;}
        public  HRSystemContext _dbContext {get; private set;}
        public BaseService(HRSystemContext dbContext, string actor)
        {
            _dbContext = dbContext;
            _Actor = actor;
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
                
              _model.CreatedBy = _Actor ?? string.Empty;
              _model.CreatedDate = DateTime.UtcNow;  
              _dbContext.Set<TModel>().Add(_model);
              return _dbContext.SaveChanges();
          }
          catch(Exception)
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
                TModel _model = GetById(id);
                _model = BeforeDelete(_model);
                _model.IsDeleted = true;
                _model.UpdatedBy = _Actor ?? string.Empty;
                _model.UpdatedDate = DateTime.UtcNow;
                _dbContext.Set<TModel>().Update(_model);
                
                return _dbContext.SaveChanges();
            }
            catch(Exception)
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
            catch(Exception)
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
            catch(Exception)
            {
                throw;
            }
        }
        protected virtual TModel BeforeUpdate(TModel local, TModel db)
        {
            return local;
        }
        public TModel Update(TModel model)
        {
            try
            {
                List<ValidationResult> errors = new List<ValidationResult>(Validate(model));

                if(errors.Count > 0)
                    throw new ValidationException(errors, "Error Found");

                TModel _modelDB = GetById(model.Id);
                var _modelUpdate = BeforeUpdate(model,_modelDB);
                _dbContext.Entry(_modelUpdate).State = EntityState.Modified;

                _dbContext.SaveChanges();
                return _modelUpdate;
            }
            catch(Exception)
            {
                throw;
            }
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