using SQLite;
namespace _6002CEM2
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public int Loc { get; set; }
        public int group { get; set; }
        public string Music { get; set; }
    }
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public string Password { get; set; }
        public int Loc { get; set; }
        public int owner { get; set; }
    }
    public class Locations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

    }
}
