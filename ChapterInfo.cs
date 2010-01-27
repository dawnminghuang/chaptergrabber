﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace JarrettVance.ChapterTools
{
  public class ChapterInfo
  {
    public string Title { get; set; }
    public string LangCode { get; set; }
    public string SourceName { get; set; }
    public string SourceType { get; set; }
    public string SourceHash { get; set; }
    public double FramesPerSecond { get; set; }
    public TimeSpan Duration { get; set; }
    public List<Chapter> Chapters { get; set; }

    public override string ToString()
    {
      return string.Format("{0}, {1}, {2} chapter(s)", SourceName, Duration.ToShortString(), Chapters.Count);
    }

    public void ChangeFps(double fps)
    {
      for (int i = 0; i < Chapters.Count; i++)
      {
        Chapter c = Chapters[i];
        double frames = c.Time.TotalSeconds * FramesPerSecond;
        Chapters[i] = new Chapter() { Name = c.Name, Time = new TimeSpan((long)Math.Round(frames / fps * TimeSpan.TicksPerSecond)) };
      }

      double totalFrames = Duration.TotalSeconds * FramesPerSecond;
      Duration = new TimeSpan((long)Math.Round((totalFrames / fps) * TimeSpan.TicksPerSecond));
      FramesPerSecond = fps;
    }

    public void SaveText(string filename)
    {
      List<string> lines = new List<string>();
      int i = 0;
      foreach (Chapter c in Chapters)
      {
        i++;
        lines.Add("CHAPTER" + i.ToString("00") + "=" + c.Time.ToShortString());
        lines.Add("CHAPTER" + i.ToString("00") + "NAME=" + c.Name);
      }
      File.WriteAllLines(filename, lines.ToArray());
    }

    public void SaveQpfile(string filename)
    {
      List<string> lines = new List<string>();
      foreach (Chapter c in Chapters)
      {
        lines.Add(string.Format("{0} I -1", (long)Math.Round(c.Time.TotalSeconds * FramesPerSecond)));
      }
      File.WriteAllLines(filename, lines.ToArray());
    }

    public void SaveCelltimes(string filename)
    {
      List<string> lines = new List<string>();
      foreach (Chapter c in Chapters)
      {
        lines.Add(((long)Math.Round(c.Time.TotalSeconds * FramesPerSecond)).ToString());
      }
      File.WriteAllLines(filename, lines.ToArray());
    }

    public void SaveTsmuxerMeta(string filename)
    {
      string text = "--custom-" + Environment.NewLine + "chapters=";
      foreach (Chapter c in Chapters)
      {
        text += c.Time.ToShortString() + ";";
      }
      text = text.Substring(0, text.Length - 1);
      File.WriteAllText(filename, text);
    }

    public void SaveTimecodes(string filename)
    {
      List<string> lines = new List<string>();
      foreach (Chapter c in Chapters)
      {
        lines.Add(c.Time.ToShortString());
      }
      File.WriteAllLines(filename, lines.ToArray());
    }

    static readonly XNamespace cgNs = "http://jvance.com/2008/ChapterGrabber";

    public static ChapterInfo Load(string filename)
    {
      ChapterInfo ci = new ChapterInfo();
      XDocument doc = XDocument.Load(filename);
      if (doc.Element(cgNs + "chapterInfo").Element(cgNs + "title") != null)
        ci.Title = (string)doc.Element(cgNs + "chapterInfo").Element(cgNs + "title");
      XElement src = doc.Element(cgNs + "chapterInfo").Element(cgNs + "source");

      ci.SourceName = (string)src.Element("name");
      if (src.Element(cgNs + "type") != null)
        ci.SourceType = (string)src.Element(cgNs + "type");
      ci.SourceHash = (string)src.Element(cgNs + "hash");
      ci.FramesPerSecond = Convert.ToDouble(src.Element(cgNs + "fps").Value, new System.Globalization.NumberFormatInfo());
      ci.Duration = TimeSpan.Parse(src.Element(cgNs + "duration").Value);
      ci.Chapters = doc.Element(cgNs + "chapterInfo").Element(cgNs + "chapters").Elements(cgNs + "chapter")
        .Select(e => new Chapter() { Name = (string)e.Attribute("name"), Time = TimeSpan.Parse((string)e.Attribute("time")) }).ToList();
      return ci;
    }

    public void Save(string filename)
    {
      new XDocument(new XElement(cgNs + "chapterInfo",
        new XAttribute(XNamespace.Xml + "lang", LangCode),
        new XAttribute("version", "1"),
        new XComment("This file was generated by ChapterGrabber " + Application.ProductVersion),
        new XComment("For more information visit http://jvance.com/pages/ChapterGrabber.xhtml"),
        Title != null ? new XElement(cgNs + "title", Title) : null,
        new XElement(cgNs + "source",
          new XElement(cgNs + "name", SourceName),
          SourceType != null ? new XElement(cgNs + "type", SourceType) : null,
          new XElement(cgNs + "hash", SourceHash),
          new XElement(cgNs + "fps", FramesPerSecond),
          new XElement(cgNs + "duration", Duration.ToString())),
        new XElement(cgNs + "chapters",
          Chapters.Select(c =>
            new XElement(cgNs + "chapter",
              new XAttribute("time", c.Time.ToString()),
              new XAttribute("name", c.Name)))))).Save(filename);
    }

    public void SaveXml(string filename)
    {
      new XDocument(new XElement("Chapters",
        new XElement("EditionEntry",
          new XElement("EditionFlagHidden", "0"),
          new XElement("EditionFlagDefault", "0"),
          //new XElement("EditionUID", "1"),
          Chapters.Select(c =>
            new XElement("ChapterAtom",
            new XElement("ChapterDisplay", 
              new XElement("ChapterString", c.Name),
              new XElement("ChapterLanguage", LangCode == null ? "und" : LangCode)),
            new XElement("ChapterTimeStart", c.Time.ToString()),
            new XElement("ChapterFlagHidden", "0"),
            new XElement("ChapterFlagEnabled", "1")))
          ))).Save(filename);
    
  //    <Chapters>
  //<EditionEntry>
  //  <EditionFlagHidden>0</EditionFlagHidden>
  //  <EditionFlagDefault>0</EditionFlagDefault>
  //  <EditionUID>62811788</EditionUID>
  //  <ChapterAtom>
  //    <ChapterDisplay>
  //      <ChapterString>Test1</ChapterString>
  //      <ChapterLanguage>und</ChapterLanguage>
  //    </ChapterDisplay>
  //    <ChapterUID>2401693056</ChapterUID>
  //    <ChapterTimeStart>00:01:40.000000000</ChapterTimeStart>
  //    <ChapterFlagHidden>0</ChapterFlagHidden>
  //    <ChapterFlagEnabled>1</ChapterFlagEnabled>
  //  </ChapterAtom>
    }
  }
}
