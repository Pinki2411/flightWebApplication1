using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace flightWebApplication1.Models.Repository
{
    public class RepositoryClass<T> : Ifunction<T> where T : class
    {
        private flightContext Fcontext=null;
        private DbSet<T> dbEntity=null;
        public RepositoryClass()
        {
            Fcontext = new flightContext();
            dbEntity = Fcontext.Set<T>();
        }
        public RepositoryClass(flightContext Fcontext)
        {
           this.Fcontext = Fcontext;
            dbEntity = Fcontext.Set<T>();
        }   

        public void DeleteModel(int modelId)
        {
            T model = dbEntity.Find(modelId);
            dbEntity.Remove(model);
            Fcontext.SaveChanges();
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetModelbyID(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void InsertModel(T model)
        { 
                if (model == null)
                {
                    throw new ArgumentNullException("model");
                }
                dbEntity.Add(model);
                Fcontext.SaveChanges();
        }

        public void UpdateModel(T model)
        {
            Fcontext.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}