// @author duyenthai

namespace LeagueManagement.thaind.dao
{
    public abstract class BaseDAO<T>
    {
        public abstract int Save(T entity);
        public abstract int Update(T entity);
        public abstract void SaveOrUpdate(T entity);
        public abstract void Delete(T entity);
        public abstract T GetById(int id);
    }
}