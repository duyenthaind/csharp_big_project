// @author duyenthai

using System;
using System.Collections.Generic;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using LeagueManagement.thaind.mapper;
using log4net;

namespace LeagueManagement.thaind.dao
{
    public class DhLeagueRankingDAO : BaseDAO<DhLeagueRanking>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DhLeagueRankingDAO));

        private static readonly DhLeagueRankingMapper DhLeagueRankingMapper = new DhLeagueRankingMapper();

        private const string QueryInsertData =
            "insert into dh_league_ranking(league_id,season_id,team_id,point,num_win,num_draw,num_lost,played_matches,difference) output inserted.id"
            + " values (@leagueId, @seasonID, @teamId, @point, @numWin, @numDraw, @numLost,@playedMatches, @diffrence) ";

        private const string QueryUpdateData =
            "update dh_league_ranking set league_id=@leagueId, season_id=@seasonId, team_id=@teamId, point=@point, num_win=@numWin, num_draw=@numDraw,"
            + " num_lost=@numLost, played_match=@playedMatches, differnce=@difference where id=@id";

        private const string QueryDeleteById = "delete from dh_league_ranking where id=@id";
        private const string QueryGetById = "select top 1 *from dh_league_ranking where id=@id";
        private const string QueryDeleteButId = "delete from dh_league_ranking where id!=@id";

        private const string QueryGetByLeagueSeasonTeam =
            "select *from dh_league_ranking where leaguage_id=@leagueId and season_id=@seasonId and team_id=@teamId";

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
                    Update(entity);
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
    }
}