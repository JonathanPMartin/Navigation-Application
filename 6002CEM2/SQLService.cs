
using Android.Gms.Common.Api.Internal;
using Android.Util;
using Java.Lang;
using Javax.Security.Auth;
using SQLite;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace _6002CEM2
{
    
    public partial class SQLService
    {
        int UserID = -1;
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "myData3  .db");
             db = new SQLiteAsyncConnection(path);
            await db.CreateTableAsync<Users>();
            await db.CreateTableAsync<Group>();
            await db.CreateTableAsync<Locations>();
        }
        public static async Task AddLoc(double Long2, double Lat2)
        {
            await Init();
            var loc = new Locations()
            {
                Long = Long2,
                Lat = Lat2
            };
            await db.InsertAsync(loc);
        }
        public static async Task AddGroup(string Name,string Password, int Loc,int owner)
        {
            await Init();
            var group = new Group()
            {
                name=Name,
                Password=Password,
                Loc=Loc,
                owner=owner
            };
            await db.InsertAsync(group);
        }
        public static async Task Adduser(string UserName, string PassWord,int Loc)
        {
            await Init();
            var user = new Users()
            {
                Username = UserName,
                Password = PassWord,
                Loc = Loc,
                group = -1
            };
            try
            {
                await db.InsertAsync(user);
            }
            finally
            {
                var useless = 0;
            }
        }
        public static async Task<int> logIn(string UserName, string PassWord)
        {
            await Init();
         var user=from u in db.Table<Users>()
                where u.Username==UserName && u.Password==PassWord
                select u;
            var test= await db.Table<Users>().Where(t => t.Username==UserName && t.Password==PassWord).ToListAsync();

            var tem = test.FirstOrDefault();
            return tem.Id;
           
        }
        public static async Task UpdateuserPassword(int id, string password)
        {

        }
        public static async Task<Locations> GetUserLocation(int UserID)
        {
            await Init();
            // "select * from Users where id="+UserId+";"
            //update users where id = x Set loc to y;
            var LocationId = await db.Table<Users>().Where(t => t.Id == UserID).ToListAsync();
            var tem = LocationId.FirstOrDefault();
            var location= await db.Table<Locations>().Where(t =>t.Id==tem.Loc).ToListAsync();
            var tem2= location.FirstOrDefault();
            return tem2;
           
        }
        public static async Task GetGroupLocation()
        {

        }
        public static async Task<int> GetLocID(double Long, double Lat)
        {
            await Init();
            var Location=await db.Table<Locations>().Where(t =>t.Lat==Lat && t.Long==Long).ToListAsync();
            var tem=Location.FirstOrDefault();
            var Locationid = tem.Id;
            return Locationid;
        }
        public static async Task UpdateUserLocation(Users user)
        {

            await Init();
            //tem.Loc=LocID;
            await db.UpdateAsync(user);
            //var query="update Users where Id="+UserID.ToString()+" Set Loc="+LocID.ToString();
            //await db.QueryAsync<Locations>(query);
            
        }
        public static async Task UpdateUser(Users user)
        {
            await Init();
            //tem.Loc=LocID;
            await db.UpdateAsync(user);
            //var query="update Users where Id="+UserID.ToString()+" Set Loc="+LocID.ToString();
            //await db.QueryAsync<Locations>(query);

        }
        public static async Task<double[]> calMeetingPoint(int groupID)
        {
            await Init();
            double Long= 0;
            double lat= 0;
           var group= await db.Table<Group>().Where(t => t.Id == groupID).ToListAsync();
            for(int i=0; i<group.Count; i++) {
                var user=await db.Table<Users>().Where(t => t.Id == group[i].Id).ToListAsync();
                var tem=user.FirstOrDefault();
                var location=await db.Table<Locations>().Where(t =>t.Id== tem.Loc).ToListAsync();
                var tem2=location.FirstOrDefault();
                Long=Long+tem2.Long;
                lat=lat+tem2.Lat;
            }
            lat = lat / group.Count;
            Long= Long/group.Count;
           
            double[] Data = { lat, Long };
            return Data;
        }
       
        public static async Task UpdateLocation(Locations Location)
        {
            await Init();
            await db.UpdateAsync(Location);
        }

        public static async Task<Users> GetUser(int UserID)
        {
            await Init();
            var users=await db.Table<Users>().Where(t => t.Id==UserID).ToListAsync();
            var user=users.FirstOrDefault();
            return user;
           
        }
        
         public static  async Task Removeuser(int id)
        {
            await Init();
            await db.DeleteAsync<Users>(id);
        }
        public static async Task<Locations> GetLocation(int id)
        {
            await Init();
            var Location = await db.Table<Locations>().Where(t => t.Id == id).ToListAsync();
            var tem = Location.FirstOrDefault();
            return tem;
           
        }
    }
   // [Serializable]
    
}