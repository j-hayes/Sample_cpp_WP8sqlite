using System.Collections.Generic;
using WP8Sqlite.Entities;

namespace WP8Sqlite
{
    public interface IChineseManager
    {
        List<Chinese> ChinesesMatching(string searchFilter);
        List<Chinese> ChinesesRelated(string searchFilter);
        List<Chinese> PinyinMatching(string searchTerm);

        void Insert(Chinese chinese);
        void Update(Chinese chinese);
        void Delete(Chinese chinese);

        Chinese GetById(int p);
        List<Chinese> GetById(List<int> ids);

    }
}
