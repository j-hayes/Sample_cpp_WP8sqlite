using SQLite;

namespace WP8Sqlite.Entities
{

   public class Chinese
    {
       [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }
        public string Pinyin { get; set; } 
        public string SearchablePinyin { get; set; }
     
       
       [Ignore]
       public string AccentedPinyin {
           get { return Pinyin; }
           
       }

       



    }
  
}