using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebAplication.DAL;

namespace WebAplication.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto db;

        public RepositorioBase()
        {
            db = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;


            try
            {
                if (db.Set<T>().Add(entity) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;


            try
            {
                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public virtual T Buscar(int id)
        {
            T entity;


            try
            {
                entity = db.Set<T>().Find(id);

            }
            catch (Exception)
            {
                throw;
            }


            return entity;
        }
        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> lista = new List<T>();


            try
            {
                lista = db.Set<T>().Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }


            return lista;

        }
        public virtual bool Elimimar(int id)
        {
            bool paso = false;


            try
            {
                T entity = this.Buscar(id);
                if (entity is null)
                    return false;

                db.Entry(entity).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }
        public virtual void Dispose()
        {
            db.Dispose();
        }

        public virtual bool Repetido(Expression<Func<T, bool>> expression)
        {
            bool paso;

            try
            {
                paso = db.Set<T>().Any(expression);

            }
            catch (Exception)
            {
                throw;
            }



            return paso;
        }
    }
}