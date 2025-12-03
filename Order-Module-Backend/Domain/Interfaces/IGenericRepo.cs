using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepo<T, Tkey> where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(Tkey id);
        /// <summary>
        /// Lấy bản ghi theo ID (khóa chính).
        /// </summary>
        Task<T?> GetByIdAsync(Tkey id);

        /// <summary>
        /// Lấy một bản ghi đầu tiên thỏa mãn điều kiện (có thể include).
        /// </summary>
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Lấy danh sách bản ghi (tùy chọn filter và include).
        /// </summary>
        //Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IQueryable<T>>? include = null);
    }
}
