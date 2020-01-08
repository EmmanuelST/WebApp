﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAplication.BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> Expression);
        T Buscar(int id);
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Elimimar(int id);
    }
}