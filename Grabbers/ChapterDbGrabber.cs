using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace JarrettVance.ChapterTools.Grabbers
{
    public class ChapterDbGrabber : ChapterGrabber
    {
        private static List<ChapterInfo> searchResults;

        public ChapterDbGrabber()
        {
            SupportsHash = true;
        }

        public override void PopulateNames(SearchResult result, ChapterInfo chapterInfo, bool includeDurations)
        {
            var chapters = searchResults.Where(r => r.ChapterSetId == int.Parse(result.Id)).First();

            if (chapterInfo.Chapters.Count > 0)
            {
                for (int i = 0; i < chapterInfo.Chapters.Count; i++)
                {
                    chapterInfo.Chapters[i] = new ChapterEntry() { Name = chapters.Chapters[i].Name, 
                      Time = includeDurations ? chapters.Chapters[i].Time : chapterInfo.Chapters[i].Time };
                }
            }
            else
            {
                chapterInfo.Chapters = chapters.Chapters;
            }
        }

        public override List<SearchResult> Search(ChapterInfo chapterInfo)
        {
            string url = "http://localhost:18916/chapters/search?title={0}&chapterCount={1}";
            url = string.Format(url, Uri.EscapeUriString(chapterInfo.Title), chapterInfo.Chapters.Count);

            string xml = null;
            using (WebClient client = new WebClient())
            {
                client.Headers["ApiKey"] = "a784c7d08e5fe192ca247d1a2dd5c27f";
                client.Headers["UserName"] = "ChapterGrabber";
                try
                {
                    xml = client.DownloadString(url);
                }
                catch (WebException webex)
                {
                    string error = new StreamReader(webex.Response.GetResponseStream()).ReadToEnd();
                    throw new Exception(error, webex);
                }
            }

            var searchXml = XDocument.Parse(xml);
            searchResults = searchXml.Root.Elements(ChapterInfo.CgNs + "chapterInfo").Select(x => ChapterInfo.Load(x)).ToList();

            var titles = searchResults.Select(m => new SearchResult()
                            {
                                Id = (m.ChapterSetId ?? 0).ToString(),
                                Name = m.Title
                            });
            OnSearchComplete();
            return titles.ToList();
        }

        public override ChapterInfo DirectHit(string hash)
        {
            try
            {
                string url = "http://localhost:18916/chapters/disc-{0}";
                url = string.Format(url, hash);

                XDocument doc = XDocument.Load(url);
                return ChapterInfo.Load(new XmlTextReader(url));
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return null;
        }
    }
}
