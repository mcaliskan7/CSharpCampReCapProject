using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T> where T:IEntity
    {
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}