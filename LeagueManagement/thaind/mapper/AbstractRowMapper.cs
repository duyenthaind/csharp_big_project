// @author duyenthai

using System.Collections.Generic;
using System.Data;

namespace LeagueManagement.thaind.mapper
{
    public abstract class AbstractRowMapper<T>
    {
        public abstract T MapEntityFromRow(DataRow row);
        public abstract Dictionary<string, object> MapParamsFromEntity (T entity);
    }
}