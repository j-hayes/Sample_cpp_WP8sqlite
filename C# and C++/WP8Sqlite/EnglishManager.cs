using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using WP8Sqlite.Entities;

namespace WP8Sqlite
{
    class EnglishManager 
    {
        private readonly SQLiteConnection _connection;
        private string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
           "Dictionary.sqlite");
        public EnglishManager()
        {
            _connection = new SQLiteConnection("Dictionary.sqlite");
            _connection.CreateTable<English>();

        }

      
        public List<English> EnglishesMatching(string filter)
        {
            using (var connection1 = new SQLiteConnection(dbPath))
            {
                var queryString =
                    string.Format(
                        "Select * from English WHERE definition match '{0}' ORDER BY definitionLength asc limit 50", filter);
                List<English> englishResutlsList = connection1.Query<English>(queryString).ToList();
                return englishResutlsList;
            }
        }

        public void Insert(English English)
        {
            _connection.Insert(English);
        }

        public void Update(English English)
        {
            _connection.Update(English);
        }

        public void Delete(English English)
        {
            _connection.Delete(English);
        }



        public List<English> GetEnglishesByChineseIds(List<int> chineseIds)
        {

            string query = "select * from English where ChineseID in";
            string chineseIdsForQuery = " (";

            foreach (int id in chineseIds)
            {
                chineseIdsForQuery += string.Format("{0},", id);
            }
            chineseIdsForQuery = chineseIdsForQuery.Remove(chineseIdsForQuery.Length - 1) + ")";

            query = query + chineseIdsForQuery;

            List<English> results = _connection.Query<English>(query).ToList();
            return results;
        }


    }
}