using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Windows.Networking.Connectivity;
using SQLite;
using WP8Sqlite.Entities;

namespace WP8Sqlite
{
    public class ChineseManager : IChineseManager
    {
        private string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
            "Dictionary.sqlite");

        private SQLiteConnection _connection = new SQLiteConnection("Dictionary.sqlite");


        public ChineseManager()
        {


        }

        public List<Chinese> ChinesesMatching(string searchFilter)
        {
            using (var _connection1 = new SQLiteConnection(dbPath))
            {
                List<Chinese> matchingChinese = _connection1.Query<Chinese>(
                    "Select * from Chinese WHERE Simplified = ? limit 100", searchFilter);
                   return matchingChinese;
            }



        
        }

        public List<Chinese> ChinesesRelated(string searchFilter)
        {
            throw new NotImplementedException("");
            //todo: This should get more results than the match query
        }

        public List<Chinese> PinyinMatching(string searchTerm)
        {
            List<Chinese> matchingChinese =
                _connection.Query<Chinese>("Select * from Chinese WHERE SearchablePinyin match ? Limit 100", searchTerm);


            return matchingChinese;
        }

        public void Insert(Chinese chinese)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.RunInTransaction(() => db.Insert(chinese));
            }
        }

        public void Update(Chinese chinese)
        {
            _connection.Update(chinese);
        }

        public void Delete(Chinese chinese)
        {
            _connection.Delete(chinese);
        }

        public int Count
        {
            get { return _connection.Table<Chinese>().Count(); }
        }


        public Chinese GetById(int id)
        {
            return _connection.Table<Chinese>()
                .Where((x => x.ID == (id)))
                .FirstOrDefault();
        }

        public List<Chinese> GetById(List<int> ids)
        {
      
            string chineseIntsForQuery = " (";
            foreach (int id in ids)
            {
                chineseIntsForQuery += string.Format("{0},", id);
            }
            chineseIntsForQuery = chineseIntsForQuery.Remove(chineseIntsForQuery.Length - 1) + ")";

            string query = "select * from Chinese where ID in";
            query = query + chineseIntsForQuery;

            using (var connection = new SQLiteConnection(dbPath))
            {
               var results =  connection.Query<Chinese>(query).ToList();
                return results;
            }
            //List<Chinese> results = _connection.Query<Chinese>(query).ToList();//dosent work
            //return results;
        }

        public List<Chinese> GetAll()
        {
            List<Chinese> result = new List<Chinese>();
            using (var db = new SQLiteConnection(dbPath))
            {
                result = db.Query<Chinese>("Select * from Chinese").ToList();

            }
            return result;
        }
    }
}