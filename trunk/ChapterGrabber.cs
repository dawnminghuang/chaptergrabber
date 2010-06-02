using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JarrettVance.ChapterTools
{
  public abstract class ChapterGrabber
  {
    public abstract void PopulateNames(SearchResult result, ChapterInfo chapterInfo, bool includeDurations);
    public abstract List<SearchResult> Search(ChapterInfo chapterInfo);
    public abstract ChapterInfo DirectHit(string hash);
    public bool SupportsHash { get; set; }

    public event EventHandler SearchComplete;

    protected void OnSearchComplete()
    {
      if (SearchComplete != null) SearchComplete(this, EventArgs.Empty);
    }
  }
  
  public class SearchResult
  {
    public string Id { get; set; }
    public string Name { get; set; }
  }
}
