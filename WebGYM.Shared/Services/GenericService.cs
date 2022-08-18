using System.Linq.Expressions;
using WebGYM.Shared.Models;
using WebGYM.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace WebGYM.Shared.Services
{
    public interface IGenericService
    {
        public Result<List<T>> List<T>(int? limit = ConstantsBucket.GET_LIMIT, int? skip = null, Expression<Func<T, bool>>? filter = null) where T : ServiceObject;
        public Result<T> Get<T>(int? id) where T : ServiceObject;
        public Result<T> Create<T>(T entity, Func<T, Result<T>>? validationLogic = null) where T : ServiceObject;
        public Result<T> Update<T>(T entity, Func<T, Result<T>>? validationLogic = null) where T : ServiceObject;
        public Result<T> Delete<T>(int? id) where T : ServiceObject;
        public IQueryable<T> ListQuery<T>(int? limit = ConstantsBucket.GET_LIMIT, int? skip = null, Expression<Func<T, bool>>? filter = null) where T : ServiceObject;
    }

    public class GenericService : IGenericService
    {
        private readonly DbContext _context;

        public GenericService(DbContext context) => _context = context;

        public DbSet<T> Set<T>() where T : ServiceObject => _context.Set<T>();

        public IQueryable<T> ListQuery<T>(int? limit = ConstantsBucket.GET_LIMIT, int? skip = null, Expression<Func<T, bool>>? filter = null) where T : ServiceObject
        {
            var query = _context.Set<T>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (limit != null)
                query = query.Take(limit.Value);

            if (skip != null)
                query = query.Skip(skip.Value);

            return query;
        }

        public virtual Result<List<T>> List<T>(int? limit = ConstantsBucket.GET_LIMIT, int? skip = null, Expression<Func<T, bool>>? filter = null) where T : ServiceObject
        {
            try
            {
                return new Result<List<T>>
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = ListQuery(limit, skip, filter).ToList()
                };
            }
            catch (Exception ex)
            {
                return new Result<List<T>>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public virtual Result<T> Get<T>(int? id) where T : ServiceObject
        {
            try
            {
                if (id == null)
                {
                    return new Result<T>
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id was not provided"
                    };
                }

                var result = List<T>(filter: e => e.Id == id);

                if (result.CustomObject == null || !result.CustomObject.Any())
                {
                    return new Result<T>
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = $"{typeof(T).Name} entity was not found"
                    };
                }

                var entity = result.CustomObject.First();

                return new Result<T>
                {
                    Id = entity.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = entity
                };
            } 
            catch (Exception ex)
            {
                return new Result<T>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public virtual Result<T> Create<T>(T entity, Func<T, Result<T>>? validationLogic = null) where T : ServiceObject
        {
            try
            {
                if (validationLogic != null)
                {
                    var validationResult = validationLogic.Invoke(entity);
                    if (validationResult.StatusCode != System.Net.HttpStatusCode.OK)
                        return validationResult;
                }

                entity.Id = null;
                var result = _context.Set<T>().Add(entity);

                _context.SaveChanges();

                return new Result<T>
                {
                    Id = result?.Entity?.Id,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    CustomObject = result?.Entity
                };
            }
            catch (Exception ex)
            {
                return new Result<T>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public virtual Result<T> Update<T>(T entity, Func<T, Result<T>>? validationLogic = null) where T : ServiceObject
        {
            try
            {
                if (validationLogic != null)
                {
                    var validationResult = validationLogic.Invoke(entity);
                    if (validationResult.StatusCode != System.Net.HttpStatusCode.OK)
                        return validationResult;
                }

                var result = _context.Set<T>().Update(entity);

                _context.SaveChanges();

                return new Result<T>
                {
                    Id = result?.Entity?.Id,
                    StatusCode = System.Net.HttpStatusCode.Created,
                    CustomObject = result?.Entity
                };
            }
            catch (Exception ex)
            {
                return new Result<T>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public virtual Result<T> Delete<T>(int? id) where T : ServiceObject
        {
            try
            {
                if (id == null)
                {
                    return new Result<T>
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id was not provided"
                    };
                }
                var result = List<T>(filter: e => e.Id == id);
                if (result.CustomObject == null || !result.CustomObject.Any())
                {
                    return new Result<T>
                    {
                        Id = id,
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = $"{typeof(T).Name} with specified Id was not found"
                    };
                }

                var entity = result.CustomObject.First();
                var removedEntity = _context.Remove(entity);

                _context.SaveChanges();

                return new Result<T>
                {
                    Id = removedEntity?.Entity?.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = removedEntity?.Entity
                };
            }
            catch (Exception ex)
            {
                return new Result<T>
                {
                    Id = id,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
