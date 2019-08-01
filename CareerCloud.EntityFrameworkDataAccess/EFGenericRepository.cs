﻿using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
   public class EFGenericRepository<T> : IDataRepository<T> where T:class
    {
        private CareerCloudContext _contex;
        public EFGenericRepository()
        {
            _contex = new CareerCloudContext();
        }
        public void Add(params T[] items)
        {
            foreach(T item in items)
            {
                _contex.Entry(item).State=EntityState.Added;
            }
            _contex.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbquery = _contex.Set<T>();

            foreach(Expression<Func<T, object>> property in navigationProperties)
            {
                dbquery = dbquery.Include<T, object>(property);
            }

            return dbquery.ToList<T>();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _contex.Entry(item).State = EntityState.Deleted;
            }
            _contex.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _contex.Entry(item).State = EntityState.Modified;
            }
            _contex.SaveChanges();
        }
    }
}
