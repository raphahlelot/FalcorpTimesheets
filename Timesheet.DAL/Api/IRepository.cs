using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Falcorp.Timesheet.DAL.Api
{
    public interface IRepository<TEntity> where TEntity : class  //only class types can be passed as 
    {

        ///<summary>
        ///   Adds a new row to your table
        ///</summary
        void Create(TEntity entity);

        ///<summary>
        /// Adds a range of values to your table 
        ///</summary
        void AddRange(IEnumerable<TEntity> entities);

        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> Many(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///  
        ///</summary
        TEntity Single(int id);

        ///<summary>
        ///
        ///</summary
        void Remove(TEntity entity);

        ///<summary>
        ///
        ///</summary
        void RemoveRange(IEnumerable<TEntity> entities);

        ///<summary>
        ///
        ///</summary
        Task<TEntity> SingleAsync(int id);

        // Searches your tables by passing an lambda expression
        ///<summary>
        ///  Searches your tables by passing an lambda expression
        ///  <return name="IEnumerable<TEntity>"> IEnumerable<TEntity> of results se based on the condition build by the passed expression </return>
        /// <param name="Expression<Funct<TEntity,bool>>"> Lamdba expression</param>
        ///</summary
        IEnumerable<TEntity> ManyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
