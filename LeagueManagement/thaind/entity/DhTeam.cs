// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_team")]
    public class DhTeam
    {
        private int id;
        private int name;
        private string host;
        private int nationId;
        private int numAtheletes;

        public DhTeam()
        {
        }

        [Column(IsPrimaryKey = true, Name = "id", IsDbGenerated = true)]
        public int Id
        {
            get => id;
            set => id = value;
        }

        [Column(Name = "name")]
        public int Name
        {
            get => name;
            set => name = value;
        }

        [Column(Name = "host")]
        public string Host
        {
            get => host;
            set => host = value;
        }

        [Column(Name = "nation_id")]
        public int NationId
        {
            get => nationId;
            set => nationId = value;
        }

        [Column(Name = "num_atheletes")]
        public int NumAtheletes
        {
            get => numAtheletes;
            set => numAtheletes = value;
        }
    }
}