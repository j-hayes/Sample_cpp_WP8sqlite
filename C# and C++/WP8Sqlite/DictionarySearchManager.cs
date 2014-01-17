﻿using System;
using System.Collections.Generic;
using System.Linq;
using FlashCardApp.Core.ViewModels.Dictionary;
using WP8Sqlite;
using WP8Sqlite.Entities;

namespace FlashCardApp.Core.Managers
{
    public class DictionarySearchManager 
    {
        private List<SearchResult> _searchResults = new List<SearchResult>();

        private readonly ChineseManager _chineseManager;
        private readonly EnglishManager _englishManager;

        public DictionarySearchManager()
        {
            _chineseManager = new ChineseManager();
            _englishManager = new EnglishManager();
        }

        public List<SearchResult> SearchByEnglish(string searchTerm)
        {
            searchTerm = clearnSearchTerm(searchTerm);
            List<English> englishResults = _englishManager.EnglishesMatching(searchTerm);
            if (englishResults.Count > 0)
            {
                List<Chinese> chineseReuslts =
                    _chineseManager.GetById(englishResults.Select(englishResult => englishResult.ChineseId).ToList());

                List<SearchResult> results = CreateSearchResultsFromEnglishesandChinese(englishResults, chineseReuslts);
                return results;
            }
            return null;
        }
    


        public List<SearchResult> SearchByChinese(string searchTerm)
        {
            searchTerm = clearnSearchTerm(searchTerm);
            List<Chinese> chineseResults = _chineseManager.ChinesesMatching(searchTerm);

            List<English> englishResults = new List<English>();

            if (chineseResults.Count > 0)
            {
                englishResults =
                    _englishManager.GetEnglishesByChineseIds(chineseResults.Select(cr => cr.ID).ToList());
            }
            List<SearchResult> results = CreateSearchResultsFromEnglishesandChinese(englishResults, chineseResults);
            return results;
        }

        public List<SearchResult> SearchForMoreChinese(string searchTerm)
        {
            searchTerm = clearnSearchTerm(searchTerm);
            List<Chinese> chineseResults = _chineseManager.ChinesesRelated(searchTerm);
            throw new NotImplementedException();
            return createSearchResultFromListOfChinese(chineseResults);
        }


        public List<SearchResult> SearchByPinYin(string searchTerm)
        {
            searchTerm = clearnSearchTerm(searchTerm);
            List<Chinese> chineseResults = _chineseManager.PinyinMatching(searchTerm);
            List<English> englishResults = new List<English>();

            if (chineseResults.Count > 0)
            {
                englishResults =
                    _englishManager.GetEnglishesByChineseIds(chineseResults.Select(cr => cr.ID).ToList());
            }
            List<SearchResult> results = CreateSearchResultsFromEnglishesandChinese(englishResults, chineseResults);
            return results;
        }

        #region privates

        //todo: this is the problem right here for the displaying slow. Too many queries

        private List<SearchResult> CreateSearchResultsFromEnglishesandChinese(List<English> englishDefinitions,
            List<Chinese> chineses)
        {
            var dictionarySearchResults = from english in englishDefinitions
                join chinese in chineses
                    on english.ChineseId equals chinese.ID
                orderby chinese.ID
                select
                    new DictionarySearchResult(chinese.ID, chinese.Traditional, chinese.Simplified, chinese.Pinyin,
                        english.Definition);

            SearchResult searchResult = new SearchResult();
            List<SearchResult> results = new List<SearchResult>();

            List<int> dictionaryIds = new List<int>();
            results.Add(searchResult);
            int searchResultsAddIndex = 0;
            foreach (DictionarySearchResult dictionarySearchResult in dictionarySearchResults)
            {
                if (dictionarySearchResult.ChineseID != results[searchResultsAddIndex].ChineseId)
                {
                    searchResult = new SearchResult
                    {
                        ChineseId = dictionarySearchResult.ChineseID,
                        Pinyin = dictionarySearchResult.Pinyin,
                        Traditional = dictionarySearchResult.Traditional,
                        Simplified = dictionarySearchResult.Simplified,
                        Definitions = new List<string>()
                    };
                    searchResult.Definitions.Add(dictionarySearchResult.Definition);
                    results.Add(searchResult);
                    searchResultsAddIndex++;
                }
                else
                {
                    results[searchResultsAddIndex].Definitions.Add(dictionarySearchResult.Definition);
                }
               
            }
            results.RemoveAt(0);
            results = results.OrderBy(x => x.Pinyin.Length).ToList();
            return results;
        }

        private List<SearchResult> createSearchResultFromListOfChinese(List<Chinese> chineses)
        {
            throw new NotImplementedException();
            /*List<SearchResult> searchResults = new List<SearchResult>();
            foreach (var chinese in chineses)
            {
                var englishesForChineseId = _englishManager.getEnglishesByChineseId(chinese.ID);
                searchResults.Add(CreateSearchResultsFromEnglishesandChinese(englishesForChineseId, chinese));
            }
            return searchResults;
             */
        }

        private string clearnSearchTerm(string searchTerm)
        {
            string cleanedSearchTerm = searchTerm;
            for (int i = 0; i < cleanedSearchTerm.Length - 1; i++)
            {
                if (searchTerm[i] == '\'')
                {
                    cleanedSearchTerm = cleanedSearchTerm.Insert(i, '\''.ToString());
                }
            }
            return cleanedSearchTerm;
        }

        #endregion
    }
}