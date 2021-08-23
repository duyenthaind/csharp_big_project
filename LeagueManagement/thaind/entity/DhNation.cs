// @author duyenthai

using System.Data.Linq.Mapping;

namespace LeagueManagement.thaind.entity
{
    [Table(Name = "dh_nation")]
    public class DhNation
    {
        private int id;
        private string name;

        public DhNation()
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
    }
}