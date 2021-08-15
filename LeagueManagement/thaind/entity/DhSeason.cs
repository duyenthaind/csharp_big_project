// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_nation")]
    public class DhSeason
    {
        private int id;
        private string name;
        private long startTime;
        private long endTime;

        public DhSeason()
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

        [Column(Name = "start_time")]
        public long StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        [Column(Name = "end_time")]
        public long EndTime
        {
            get => endTime;
            set => endTime = value;
        }
    }
}