using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarAssistance.Data
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;
        public RepositoryBase(DbContext context) 
        {
            if(context == null)
            {
                throw new NullReferenceException(nameof(DbContext));
            }
            _entities = context.Set<T>();
        }

        #region Синхронные методы действий

        /// <summary>
        /// Добавление в БД
        /// </summary>
        /// <param name="entity">Еденица сущности</param>
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// Добавление множества едениц в БД
        /// </summary>
        /// <param name="entities">Множество едениц</param>
        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        /// <summary>
        /// Поиск множества с условием
        /// </summary>
        /// <param name="predicate">Условие поиска</param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        /// <summary>
        /// Возвращает множество едениц по фильтру с сортировкой, включая свойства объекта
        /// </summary>
        /// <param name="filter">Включаемый фильтр</param>
        /// <param name="orderBy">Способ сортировки</param>
        /// <param name="includeProperties">Свойства, по которым идёт выборка</param>
        /// <returns></returns>
        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Получение всех едениц
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        /// <summary>
        /// Удаление еденицы
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        /// <summary>
        /// Удаление множетсва из БД
        /// </summary>
        /// <param name="entities">Множества</param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        #endregion

        #region Ассинхронные методы действий

        /// <summary>
        /// Ассинхронный поиск можнества по Id
        /// </summary>
        public async Task<T> FindAsync(int id)
        {
            return await _entities.FindAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Получение всего множества из таблицы БД
        /// </summary>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Получение еденицы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await FindAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Удаление еденицы из множества
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveAsync(T entity)
        {
            await Task.Run(()=> _entities.Remove(entity)).ConfigureAwait(false);
        }

        /// <summary>
        /// Удаление множества из БД
        /// </summary>
        /// <param name="entities">Множество едениц</param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => _entities.RemoveRange(entities)).ConfigureAwait(false);
        }

        /// <summary>
        /// Добавить ассинхронно еденицу в БД
        /// </summary>
        /// <param name="entity">Еденица сущности</param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity).ConfigureAwait(false);
        }
        #endregion
    }
}
