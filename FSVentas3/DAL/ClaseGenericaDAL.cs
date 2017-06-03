using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FSVentas3.DAL
{
    public class ClaseGenericaDAL
    {
        public interface ClaseGenerica<TEntity> : IDisposable where TEntity : class
        {

            TEntity Guardar(TEntity laEntidad);

            bool Modificar(TEntity laEntidad);

            bool Eliminar(TEntity laEntidad);

            TEntity Buscar(Expression<Func<TEntity, bool>> criterioBusqueda);

            List<TEntity> Lista(Expression<Func<TEntity, bool>> criterioBusqueda);
        }
    }
}