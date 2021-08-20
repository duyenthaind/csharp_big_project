// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_league")]
    public class DhLeague
    {
        private int id;
        private string name;
        private int nationId;
        private int numMatches;
        private int numTeam;

        public DhLeague()
        {
        }

        [Column(IsPrimaryKey = true, Name = "id", IsDbGenerated = true)]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [Column(Name = "name")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [Column(Name = "nation_id")]
        public int NationId
        {
            get => nationId;
            set => nationId = value;
        }

        [Column(Name = "num_matches")]
        public int NumMatches
        {
            get => numMatches;
            set => numMatches = value;
        }

        [Column(Name = "num_team")]
        public int NumTeam
        {
            get => numTeam;
            set => numTeam = value;
        }
    }
}