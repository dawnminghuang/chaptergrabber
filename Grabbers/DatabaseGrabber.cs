using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace JarrettVance.ChapterTools.Grabbers
{
    public class DatabaseGrabber : ChapterGrabber
    {
        private static List<ChapterInfo> searchResults;

        public DatabaseGrabber()
        {
            SupportsHash = true;
            SupportsUpload = true;
        }

        public override void PopulateNames(SearchResult result, ChapterInfo chapterInfo, bool includeDurations)
        {
            var chapters = searchResults.Where(r => r.ChapterSetId == int.Parse(result.Id)).First();

            if (chapterInfo.Chapters.Count > 0)
            {
                for (int i = 0; i < chapterInfo.Chapters.Count; i++)
                {
                    chapterInfo.Chapters[i] = new ChapterEntry() 
                    { 
                        Name = chapters.Chapters[i].Name, 
                        Time = chapterInfo.Chapters[i].Time 
                    };
                }
            }
            else
            {
                chapterInfo.Chapters = chapters.Chapters;
            }
        }

        public override List<SearchResult> Search(ChapterInfo chapterInfo)
        {
            string url = "{0}/chapters/search?title={1}&chapterCount={2}";
            url = string.Format(url, Settings.Default.DatabaseSite, Uri.EscapeUriString(chapterInfo.Title), chapterInfo.Chapters.Count);

            string xml = GetXml(url);

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

        private string GetXml(string url)
        {
            string xml = null;
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = Application.ProductName + " " + Application.ProductVersion;
                client.Headers["ApiKey"] = "a784c7d08e5fe192ca247d1a2dd5c27f";
                client.Headers["UserName"] = "ChapterGrabber";
                xml = client.DownloadString(url);
            }
            return xml;
        }

        public override void PopulateNames(string hash, ChapterInfo chapterInfo)
        {
            try
            {
                string url = "{0}/chapters/disc-{1}";
                url = string.Format(url, Settings.Default.DatabaseSite, hash);

                string xml = GetXml(url);

                XDocument doc = XDocument.Parse(xml);
                var chapters = ChapterInfo.Load(doc.Root);
                chapterInfo.Title = chapters.Title;

                for (int i = 0; i < chapterInfo.Chapters.Count; i++)
                {
                    chapterInfo.Chapters[i] = new ChapterEntry()
                    {
                        Name = chapters.Chapters[i].Name,
                        Time = chapterInfo.Chapters[i].Time
                    };
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        public override void Upload(ChapterInfo chapterInfo)
        {
            try
            {
                string url = "{0}/chapters/";
                url = string.Format(url, Settings.Default.DatabaseSite);

                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] = Application.ProductName + " " + Application.ProductVersion;
                    client.Headers["ApiKey"] = Settings.Default.DatabaseApiKey;
                    client.Headers["UserName"] = Settings.Default.DatabaseUserName;
                    client.UploadString(url, "POST", chapterInfo.ToXElement().ToString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }            
        }
    }
}
