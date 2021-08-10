// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using LeagueManagement.thaind.entity;
using LeagueManagement.thaind.mapper;
using log4net;

namespace LeagueManagement.thaind.dao
{
    public class DhMatchDAO : BaseDAO<DhMatch>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DhMatchDAO));

        private static readonly DhMatchMapper DhMatchMapper = new DhMatchMapper();

        private const string QueryGetById = "select *from dh_match where id=@id";

        public override int Save(DhMatch entity)
        {
            var result = -1;
            try
            {
                result = 1;
                var databaseObject = DatabaseObject.GetDatabaseContext();
                databaseObject.DhMatches.InsertOnSubmit(entity);
                databaseObject.SubmitChanges();
            }
            catch (Exception ex)
            {
                Log.Error("Error save match, trace: ", ex);
            }

            return result;
        }

        public override int Update(DhMatch entity)
        {
            var result = 1;
            try
            {
                var databaseObject = DatabaseObject.GetDatabaseContext();
                var dhMatches = databaseObject.DhMatches;
                var toUpdate = dhMatches.First(p => p.Id == entity.Id);
                toUpdate.LeagueId = entity.LeagueId;
                toUpdate.SeasonId = entity.SeasonId;
                toUpdate.TeamHostId = entity.TeamHostId;
                toUpdate.TeamAwayId = entity.TeamAwayId;
                toUpdate.TeamHostGoal = entity.TeamHostGoal;
                toUpdate.TeamAwayGoal = entity.TeamAwayGoal;
                toUpdate.StartTime = entity.StartTime;
                toUpdate.EndTime = entity.EndTime;
                databaseObject.SubmitChanges();
            }
            catch (Exception ex)
            {
                result = -1;
                Log.Error("Error update entity, trace: ", ex);
            }

            return result;
        }

        public override void SaveOrUpdate(DhMatch entity)
        {
            if (GetById(entity.Id, true) != null)
            {
                Update(entity);
            }
            else
            {
                Save(entity);
            }
        }

        public override void Delete(DhMatch entity)
        {
            try
            {
                var databaseObject = DatabaseObject.GetDatabaseContext();
                var dhMatches = databaseObject.DhMatches;
                var toDelete = dhMatches.First(p => p.Id == entity.Id);
                dhMatches.DeleteOnSubmit(toDelete);
            }
            catch (Exception ex)
            {
                Log.Error("Get match by id error, trace: ", ex);
            }
        }

        public override DhMatch GetById(int id)
        {
            DhMatch result = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var dataTable = AbstractDAO.FetchData(QueryGetById, parameters);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                result = DhMatchMapper.MapEntityFromRow(row);
            }

            return result;
        }

        public DhMatch GetById(int id, bool useLinq)
        {
            DhMatch result = null;
            try
            {
                if (useLinq)
                {
                    var databaseObject = DatabaseObject.GetDatabaseContext();
                    var dhMatches = databaseObject.DhMatches;
                    dhMatches.Where(p => p.Id == id);
                    var list = dhMatches.ToList();
                    if (list.Any())
                    {
                        result = list[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Get match by id error, trace: ", ex);
            }

            return result;
        }
    }
}