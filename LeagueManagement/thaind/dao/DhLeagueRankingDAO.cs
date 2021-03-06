// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.entity;
using LeagueManagement.thaind.mapper;
using log4net;
using Newtonsoft.Json;

namespace LeagueManagement.thaind.dao
{
    public class DhLeagueRankingDAO : BaseDAO<DhLeagueRanking>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DhLeagueRankingDAO));

        private static readonly DhLeagueRankingMapper DhLeagueRankingMapper = new DhLeagueRankingMapper();

        private const string QueryInsertData =
            "insert into dh_league_ranking(league_id,season_id,team_id,point,num_win,num_draw,num_lost,played_matches,difference, num_goal_scored, num_goal_received) output inserted.id"
            + " values (@leagueId, @seasonId, @teamId, @point, @numWin, @numDraw, @numLost,@playedMatches, @difference, @numGoalScored, @numGoalReceived) ";

        private const string QueryUpdateData =
            "update dh_league_ranking set league_id=@leagueId, season_id=@seasonId, team_id=@teamId, point=@point, num_win=@numWin, num_draw=@numDraw,"
            + " num_lost=@numLost, played_match=@playedMatches, difference=@difference, num_goal_scored=@numGoalScored, num_goal_received=@numGoalReceived "
            + " where id=@id";

        private const string QueryDeleteById = "delete from dh_league_ranking where id=@id";
        private const string QueryGetById = "select top 1 *from dh_league_ranking where id=@id";
        private const string QueryDeleteButId = "delete from dh_league_ranking where id!=@id";

        private const string QueryGetByLeagueSeasonTeam =
            "select *from dh_league_ranking where league_id=@leagueId and season_id=@seasonId and team_id=@teamId";

        private const string QueryAllByLeagueSeason =
            "select ROW_NUMBER() over(order by point desc, difference desc, num_win desc, num_lost asc) AS rowNum, name, point, num_win, num_draw, num_lost, played_matches, num_goal_scored, num_goal_received, difference "
            + " from dh_league_ranking r join dh_team t on r.team_id = t.id where r.league_id=@leagueId and r.season_id=@seasonId order by point desc, difference desc, num_win desc, num_lost asc";

        public override int Save(DhLeagueRanking entity)
        {
            var result = -1;
            try
            {
                var value = AbstractDAO.ExecuteScalar(QueryInsertData,
                    DhLeagueRankingMapper.MapParamsFromEntity(entity));
                if (value != null)
                {
                    result = Convert.ToInt32(value);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error save entity, trace: ", ex);
            }

            return result;
        }

        public override int Update(DhLeagueRanking entity)
        {
            var result = -1;
            try
            {
                var parameters = DhLeagueRankingMapper.MapParamsFromEntity(entity);
                AbstractDAO.ExecuteNonQuery(QueryUpdateData, parameters);
                result = 0;
            }
            catch (Exception ex)
            {
                Log.Error("Error update entity, trace: ", ex);
            }

            return result;
        }

        public override void SaveOrUpdate(DhLeagueRanking entity)
        {
            try
            {
                var dbEntity = GetByLeagueSeasonTeam(entity);
                var isExists = dbEntity != null;
                if (isExists)
                {
                    entity.Id = dbEntity.Id;
                    Update(entity, true);
                }
                else
                {
                    Save(entity);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error save or update, trace: ", ex);
            }
        }

        public override void Delete(DhLeagueRanking entity)
        {
            if (entity == null) return;
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", entity.Id);
            AbstractDAO.ExecuteNonQuery(QueryDeleteById, parameters);
        }

        public override DhLeagueRanking GetById(int id)
        {
            DhLeagueRanking result = null;
            try
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("id", id);
                var dataTable = AbstractDAO.FetchData(QueryGetById, parameters);
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    result = DhLeagueRankingMapper.MapEntityFromRow(row);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error get dh_league_ranking record by id, trace: ", ex);
            }

            return result;
        }

        public void DeleteExcept(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            AbstractDAO.ExecuteNonQuery(QueryDeleteButId, parameters);
        }

        public DhLeagueRanking GetByLeagueSeasonTeam(DhLeagueRanking entity)
        {
            DhLeagueRanking result = null;
            try
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("leagueId", entity.LeagueId);
                parameters.Add("seasonId", entity.SeasonId);
                parameters.Add("teamId", entity.TeamId);
                var dataTable = AbstractDAO.FetchData(QueryGetByLeagueSeasonTeam, parameters);
                var targetedId = -1;
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    result = DhLeagueRankingMapper.MapEntityFromRow(row);
                    targetedId = result.Id;
                }

                if (dataTable.Rows.Count > 1 && targetedId != -1)
                {
                    // there is ambiguous record, delete others
                    DeleteExcept(targetedId);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error get by league,season and team, trace: ", ex);
            }

            return result;
        }

        public DhLeagueRanking GetByLeagueSeasonTeam(int leagueId, int seasonId, int teamId)
        {
            DhLeagueRanking result = null;
            try
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("leagueId", leagueId);
                parameters.Add("seasonId", seasonId);
                parameters.Add("teamId", teamId);
                var dataTable = AbstractDAO.FetchData(QueryGetByLeagueSeasonTeam, parameters);
                var targetedId = -1;
                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    result = DhLeagueRankingMapper.MapEntityFromRow(row);
                    targetedId = result.Id;
                }

                if (dataTable.Rows.Count > 1 && targetedId != -1)
                {
                    // there is ambiguous record, delete others
                    DeleteExcept(targetedId);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error get by league,season and team, trace: ", ex);
            }

            return result;
        }

        public DhLeagueRanking GetByLeagueSeasonTeam(int leagueId, int seasonId, int teamId, bool useLinq)
        {
            DhLeagueRanking result = null;
            try
            {
                if (useLinq)
                {
                    var databaseObject = DatabaseObject.GetDatabaseContext();
                    var dhLeagueRankings = databaseObject.DhLeagueRankings;
                    var query = dhLeagueRankings.Where(p =>
                        (p.LeagueId == leagueId) && (p.SeasonId == seasonId) && (p.TeamId == teamId));
                    var list = query.ToList();
                    if (list.Any())
                    {
                        result = list[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error get by league,season and team, trace: ", ex);
            }

            return result;
        }

        public void Update(DhLeagueRanking entity, bool useLinq)
        {
            try
            {
                if (useLinq)
                {
                    var dbObject = DatabaseObject.GetDatabaseContext();
                    var toUpdate = dbObject.DhLeagueRankings.First(p => p.Id == entity.Id);
                    toUpdate.LeagueId = entity.LeagueId;
                    toUpdate.SeasonId = entity.SeasonId;
                    toUpdate.TeamId = entity.TeamId;
                    toUpdate.Point = entity.Point;
                    toUpdate.NumWin = entity.NumWin;
                    toUpdate.NumDraw = entity.NumDraw;
                    toUpdate.NumLost = entity.NumLost;
                    toUpdate.PlayedMatches = entity.PlayedMatches;
                    toUpdate.Difference = entity.Difference;
                    dbObject.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error, trace: ", ex);
            }
        }

        public void Save(DhLeagueRanking entity, bool useLinq)
        {
            try
            {
                if (useLinq)
                {
                    var dbObject = DatabaseObject.GetDatabaseContext();
                    dbObject.DhLeagueRankings.InsertOnSubmit(entity);
                    dbObject.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error, trace: ", ex);
            }
        }

        public DataTable GetDataTableAllRankingByLeagueSeasonId(int leagueId, int seasonId)
        {
            DataTable result = null;
            try
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("leagueId", leagueId);
                parameters.Add("seasonId", seasonId);
                result = AbstractDAO.FetchData(QueryAllByLeagueSeason, parameters);
            }
            catch (Exception ex)
            {
                Log.Error("Error, trace: ", ex);
            }

            return result;
        }

        public List<DhLeagueRanking> GetListAllRankingByLeagueId(int leagueId)
        {
            var result = new List<DhLeagueRanking>();
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                var query = databaseContext.DhLeagueRankings.Where(p => p.LeagueId == leagueId);
                result = query.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Error, trace: ", ex);
            }

            return result;
        }

        public List<DhLeagueRanking> GetListAllRankingByLeagueSeasonId(int leagueId, int seasonId)
        {
            var result = new List<DhLeagueRanking>();
            try
            {
                var databaseContext = DatabaseObject.GetDatabaseContext();
                var query = databaseContext.DhLeagueRankings.Where(p =>
                    (p.LeagueId == leagueId) && (p.SeasonId == seasonId));
                result = query.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("Error, trace: ", ex);
            }

            return result;
        }

        public DataTable GetDataTableMostWin(int leagueId, int seasonId)
        {
            DataTable result = null;
            try
            {
                var listAllRankingByLeagueSeasonId = GetListAllRankingByLeagueSeasonId(leagueId, seasonId);
                var mostWin = -1;
                if (listAllRankingByLeagueSeasonId.Any())
                {
                    mostWin = listAllRankingByLeagueSeasonId.Max(p => p.NumWin);
                }

                var listAllMostWin = listAllRankingByLeagueSeasonId.Where(p => p.NumWin == mostWin).ToList();
                result = DbUtil.GetDisplayRankingFromDhLeagueRanking(listAllMostWin, listAllRankingByLeagueSeasonId);
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }

            return result;
        }

        public DataTable GetDataTableMostLost(int leagueId, int seasonId)
        {
            DataTable result = null;
            try
            {
                var listAllRankingByLeagueSeasonId = GetListAllRankingByLeagueSeasonId(leagueId, seasonId);
                var mostLost = -1;
                if (listAllRankingByLeagueSeasonId.Any())
                {
                    mostLost = listAllRankingByLeagueSeasonId.Max(p => p.NumLost);
                }

                var listAllMostLost = listAllRankingByLeagueSeasonId.Where(p => p.NumLost == mostLost).ToList();
                result = DbUtil.GetDisplayRankingFromDhLeagueRanking(listAllMostLost, listAllRankingByLeagueSeasonId);
            }
            catch (Exception ex)
            {
                Log.Error("Error, ", ex);
            }

            return result;
        }
    }
}