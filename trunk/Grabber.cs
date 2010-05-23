/********************************************************************************
*
*    Copyright(C) 2003-2008 Jarrett Vance http://jvance.com
*
*    This file is part of ChapterGrabber
*
*	 ChapterGrabber is free software; you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation; either version 2 of the License, or
*    (at your option) any later version.
*
*    ChapterGrabber is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with this program; if not, write to the Free Software
*    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*
********************************************************************************/
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;


namespace JarrettVance.ChapterTools
{
	/// <summary>
	/// Summary description for ChapterGrabber.
	/// </summary>
	public static class Grabber
	{ 
		//this is a bullshit method because 
		//   TimeSpan.ToString(string format) is missing
		public static string ToShortString(this TimeSpan ts)
		{
			string time;
			time = ts.Hours.ToString("00");
			time = time + ":" + ts.Minutes.ToString("00");
			time = time + ":" + ts.Seconds.ToString("00");
			time = time + "." + ts.Milliseconds.ToString("000");
			return time;
		}


    //public static List<Chapter> LoadTextChapters(string filename)
    //{
    //  List<Chapter> list = new List<Chapter>();

    //  int num = 0;
    //  TimeSpan ts = new TimeSpan(0);
    //  string time = String.Empty;
    //  string name = String.Empty;
    //  bool onTime = true;
    //  string[] lines = File.ReadAllLines(filename);
    //  foreach (string line in lines)
    //  {
    //    if (onTime)
    //    {
    //      num++;
    //      //read time
    //      time = line.Replace("CHAPTER" + num.ToString("00") + "=", "");
    //      ts = TimeSpan.Parse(time);
    //    }
    //    else
    //    {
    //      //read name
    //      name = line.Replace("CHAPTER" + num.ToString("00") + "NAME=", "");
    //      //add it to list
    //      list.Add(new Chapter() { Name = name, Time = ts });
    //    }
    //    onTime = !onTime;
    //  }
    //  return list;
    //}

		public static void ImportFromClipboard(List<Chapter> chapters, string clipboard, bool includeDuration)
		{
      for (int i = 0; i < chapters.Count; i++)
        chapters[i] = new Chapter() { Time = chapters[i].Time, Name = ExtractFromCopy(clipboard, i + 1, includeDuration) };
		}

      //  public static bool ImportFromWeb(List<Chapter> chapters, string title, string ean, bool includeDuration)
      //  {
      //throw new NotImplementedException();
      //      //first download page
      //      string html = "";
      //      WebResponse result = null;
      //      try 
      //      {
      //          string URL = "http://video.barnesandnoble.com/search/product.asp?EAN="+ean+"&VIEW=SCN";
      //          WebRequest req = WebRequest.Create(URL);
      //          result = req.GetResponse();
      //          Stream ReceiveStream = result.GetResponseStream();
      //          Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
      //          StreamReader sr = new StreamReader( ReceiveStream, encode );

      //          Char[] read = new Char[256];
      //          int count = sr.Read( read, 0, 256 );

      //          while (count > 0) 
      //          {
      //              String str = new String(read, 0, count);
      //              html = html + str;
      //              count = sr.Read(read, 0, 256);
      //          }
      //      } 
      //      catch(Exception) 
      //      {
      //      } 
      //      finally 
      //      {
      //          if ( result != null ) 
      //          {
      //              result.Close();
      //          }
      //      }
      //      //try and get movie title
      //      string strTitle = "";

      //      int intB, intL;
      //      string strFind = "<title>Barnes&nbsp;&amp;&nbsp;Noble.com - ";

      //      intB = html.IndexOf(strFind) + strFind.Length;
      //      intL = html.IndexOf("</title>") - intB;

      //      try
      //      {
      //          title = html.Substring(intB, intL);
      //      }
      //      catch (Exception) {
      //      }

      //      for(int i=0; i<chapters.Count; i++)
      //          //chapters[i].Name = ExtractFromHtml(html, i+1, includeDuration);
      //      return true;
      //  }

	

		private static string ExtractFromHtml(string html, int chapterNum, bool includeDuration)
		{
			int searchAt = html.IndexOf("<a name=\"SCN\"><b>Scene Index</b></a>");
			if (searchAt == -1) return "Chapter " + chapterNum.ToString();
			string lookfor = "<br><br> " + chapterNum.ToString() + ". ";
			if (chapterNum > 9) lookfor = "<br><br>" + chapterNum.ToString() + ". ";
			int nameAt = html.IndexOf(lookfor,searchAt);
			int nameTo = html.IndexOf("<br>", nameAt + 5);
			if (nameAt == -1 || nameTo == -1) return "ChapterName " + chapterNum.ToString();
			string name = html.Substring(nameAt, nameTo - nameAt).Replace(lookfor, String.Empty);
			if (!includeDuration && name.LastIndexOf('[') > 1) name = name.Substring(0,name.LastIndexOf('[')-1);
			return name;
		}

		private static string ExtractFromCopy(string clipboard, int chapterNum, bool includeDuration)
		{
			int nameAt = clipboard.IndexOf(chapterNum.ToString() + ". ");
			int nameTo = clipboard.IndexOf("\n", nameAt + 2 + chapterNum.ToString().Length);
			if (nameAt == -1 || nameTo == -1) return "Chapter " + chapterNum.ToString();
			string name = clipboard.Substring(nameAt + 2 + chapterNum.ToString().Length, nameTo - (nameAt + 2 + chapterNum.ToString().Length));
      if (!includeDuration) return name.RemoveDuration();
      else return name.Trim();
		}

    public static string RemoveDuration(this string val)
    {
      if (val.LastIndexOf('[') > 1) val = val.Substring(0, val.LastIndexOf('[') - 1);
      return val.Trim();
    } 
	}
}
