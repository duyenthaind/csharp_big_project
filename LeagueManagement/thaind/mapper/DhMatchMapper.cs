// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.mapper
{
    public class DhMatchMapper : AbstractRowMapper<DhMatch>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DhMatchMapper));
        public override DhMatch MapEntityFromRow(DataRow row)
        {
            DhMatch result = null;
            try
            {
                result = new DhMatch();
                result.Id = Convert.ToInt32(row["id"]);
                result.LeagueId = Convert.ToInt32(row["league_id"]);
                result.SeasonId = Convert.ToInt32(row["season_id"]);
                result.TeamHostId = Convert.ToInt32(row["team_host_id"]);
                result.TeamAwayId = Convert.ToInt32(row["team_away_id"]);
                result.TeamHostGoal = Convert.ToInt32(row["team_host_goal"]);
                result.TeamAwayGoal = Convert.ToInt32(row["team_away_goal"]);
                result.StartTime = Convert.ToInt64(row["start_time"]);
                result.EndTime = Convert.ToInt64(row["end_time"]);
            }
            catch (Exception ex)
            {
                Log.Error("Error map entity, trace: ", ex);
            }

            return result;
        }

        public override Dictionary<string, object> MapParamsFromEntity(DhMatch entity)
        {
            var result = new Dictionary<string, object>();
            result.Add("id", entity.Id);
            result.Add("league_id", entity.LeagueId);
            result.Add("season_id", entity.SeasonId);
            result.Add("team_host_id", entity.TeamHostId);
            result.Add("team_away_id", entity.TeamAwayId);
            result.Add("team_away_id", entity.TeamAwayId);
            result.Add("start_time", entity.StartTime);
            result.Add("end_time", entity.EndTime);
            return result;
        }
    }
}