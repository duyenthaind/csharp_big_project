// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.mapper
{
    public class DhLeagueRankingMapper : AbstractRowMapper<DhLeagueRanking>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DhLeagueRankingMapper));

        public override DhLeagueRanking MapEntityFromRow(DataRow row)
        {
            DhLeagueRanking result = null;
            try
            {
                result = new DhLeagueRanking();
                result.Id = Convert.ToInt32(row["id"]);
                result.LeagueId = Convert.ToInt32(row["league_id"]);
                result.SeasonId = Convert.ToInt32(row["season_id"]);
                result.TeamId = Convert.ToInt32(row["team_id"]);
                result.Point = Convert.ToInt32(row["point"]);
                result.NumWin = Convert.ToInt32(row["num_win"]);
                result.NumDraw = Convert.ToInt32(row["num_draw"]);
                result.NumLost = Convert.ToInt32(row["num_lost"]);
                result.PlayedMatches = Convert.ToInt32(row["played_matches"]);
                result.Difference = Convert.ToInt32(row["differnce"]);
            }
            catch (Exception ex)
            {
                Log.Error("Error map entity, trace: ", ex);
            }

            return result;
        }

        public override Dictionary<string, object> MapParamsFromEntity(DhLeagueRanking entity)
        {
            var result = new Dictionary<string, object>();
            result.Add("id", entity.Id);
            result.Add("leagueId", entity.LeagueId);
            result.Add("seasonId", entity.SeasonId);
            result.Add("teamId", entity.TeamId);
            result.Add("point", entity.Point);
            result.Add("numWin", entity.NumWin);
            result.Add("numDraw", entity.NumDraw);
            result.Add("numLost", entity.NumLost);
            result.Add("playedMatches", entity.PlayedMatches);
            result.Add("difference", entity.Difference);
            return result;
        }
    }
}