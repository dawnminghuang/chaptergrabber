using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace JarrettVance.ChapterTools
{
  enum Option
  {
    OUTPUT_FILENAME = 0,
    OUT_FORMAT,
    TITLE_NUMBER,
  };

  public static class Program
  {
    [DllImport("kernel32.dll")]
    static extern bool AttachConsole(int dwProcessId);

    const int ATTACH_PARENT_PROCESS = -1;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      if (args.Length > 1)
      {
        AttachConsole(ATTACH_PARENT_PROCESS);
        ProcessCommandlineInput(args);
        return;
      }

      // register file association
      Register(".chapters", "application/xml+chapters", "Video Chapters", Application.ExecutablePath, Application.ExecutablePath, 0);

      Updater();

      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
      Application.EnableVisualStyles();
      var f = new frmMain();
      if (args.Length > 0) f.StartupFile = args[0];
      Application.Run(f);
    }

    enum OutputFormat
    {
      OGG_TEXT,
      TS_MUX_TEXT,
      CELL_TIMES_TEXT,
      QPF_TEXT,
      TIME_CODES_TEXT,
      MATROSKA_XML,
      CHAPTER_GRABBER_XML,
    };

    static IDictionary<string, Option> cmdLineOptions;
    static IDictionary<string, OutputFormat> outputFormats;

    private static void ProcessCommandlineInput(string[] args)
    {
      if (outputFormats == null)
      {
        outputFormats = new Dictionary<string, OutputFormat>();
        outputFormats.Add("ogg", OutputFormat.OGG_TEXT);
        outputFormats.Add("tsmux", OutputFormat.TS_MUX_TEXT);
        outputFormats.Add("cell", OutputFormat.CELL_TIMES_TEXT);
        outputFormats.Add("qpf", OutputFormat.QPF_TEXT);
        outputFormats.Add("time", OutputFormat.TIME_CODES_TEXT);
        outputFormats.Add("matroska", OutputFormat.MATROSKA_XML);
        outputFormats.Add("grabber", OutputFormat.CHAPTER_GRABBER_XML);
      }

      if (cmdLineOptions == null)
      {
        cmdLineOptions = new Dictionary<string, Option>();
        cmdLineOptions.Add("-o", Option.OUTPUT_FILENAME);
        cmdLineOptions.Add("--output-format", Option.OUT_FORMAT);
        cmdLineOptions.Add("--title-number", Option.TITLE_NUMBER);
        cmdLineOptions.Add("-f", Option.OUT_FORMAT);
        cmdLineOptions.Add("-t", Option.TITLE_NUMBER);
      }

      string inputFile = args[0];
      int iTitle = 0;
      string outputFile = "";
      var outFormat = OutputFormat.CHAPTER_GRABBER_XML;
      for (int iArg = 1; iArg < args.Length; iArg++)
      {
        try
        {
          Option theOption = cmdLineOptions[args[iArg]];

          switch (theOption)
          {
            case Option.OUTPUT_FILENAME:
              outputFile = args[iArg + 1];
              iArg++;
              break;
            case Option.OUT_FORMAT:
              try
              {
                outFormat = outputFormats[args[iArg + 1]];
              }
              catch (KeyNotFoundException)
              {
                System.Console.Out.WriteLine("Unknown output format \"{0}\".", args[iArg + 1]);
                System.Environment.ExitCode = 1;
                return;
              }
              iArg++;
              break;
            case Option.TITLE_NUMBER:
              iTitle = System.Convert.ToInt32(args[iArg + 1]);
              iArg++;
              break;
          }
        }
        catch (KeyNotFoundException)
        {
          System.Console.Out.WriteLine("Invalid Option \"{0}\".", args[iArg]);
          System.Environment.ExitCode = 1;
          return;
        }
      }

      if (outputFile.Length == 0)
      {
        System.Console.Out.WriteLine("No output file specified.");
        System.Environment.ExitCode = 1;
        return;
      }

      List<ChapterInfo> chapterList = frmMain.ReadPgcListFromFile(inputFile);

      if(iTitle >= chapterList.Count)
      {
        System.Console.Out.WriteLine("There are only {1} titles, so we cannot find the {0}th title.",
          iTitle, chapterList.Count);
        System.Environment.ExitCode = 1;
        return;
      }

      System.Console.Out.WriteLine("Outputing title {0}, with {1} chapters.",
        iTitle, chapterList[iTitle].Chapters.Count);

      switch(outFormat)
      {
        case OutputFormat.OGG_TEXT:
          chapterList[iTitle].SaveText(outputFile);
          break;
        case OutputFormat.TS_MUX_TEXT:
          chapterList[iTitle].SaveTsmuxerMeta(outputFile);
          break;
        case OutputFormat.CELL_TIMES_TEXT:
          chapterList[iTitle].SaveCelltimes(outputFile);
          break;
        case OutputFormat.QPF_TEXT:
          chapterList[iTitle].SaveQpfile(outputFile);
          break;
        case OutputFormat.TIME_CODES_TEXT:
          chapterList[iTitle].SaveTimecodes(outputFile);
          break;
        case OutputFormat.MATROSKA_XML:
          chapterList[iTitle].SaveXml(outputFile);
          break;
        case OutputFormat.CHAPTER_GRABBER_XML:
          chapterList[iTitle].Save(outputFile);
          break;
      }
    }

    private static void Updater()
    {
      ThreadPool.QueueUserWorkItem((x) =>
          {
            Thread.Sleep(1000);

            // rename updater after update
            try
            {
              string appPath = Path.GetDirectoryName(Application.ExecutablePath);
              string tmpUpdaterPath = Path.Combine(appPath, "Updater.exe.tmp");
              string updaterPath = tmpUpdaterPath.Replace(".exe.tmp", ".exe");
              if (File.Exists(tmpUpdaterPath))
              {
                File.Delete(updaterPath);
                File.Move(tmpUpdaterPath, updaterPath);
              }
            }
            catch (Exception ex)
            {
              Trace.WriteLine(ex);
            }
          });
    }

    /// <summary>
    /// Registers a file type via it's extension. If the file type is already registered, nothing is changed.
    /// </summary>
    /// <param name="extension">The extension to register</param>
    /// <param name="progId">A unique identifier for the program to work with the file type</param>
    /// <param name="description">A brief description of the file type</param>
    /// <param name="executeable">Where to find the executeable.</param>
    /// <param name="iconFile">Location of the icon.</param>
    /// <param name="iconIdx">Selects the icon within <paramref name="iconFile"/></param>
    public static void Register(string extension, string progId, string description, string executeable, string iconFile, int iconIdx)
    {
      try
      {
        if (extension.Length != 0)
        {
          if (extension[0] != '.')
          {
            extension = "." + extension;
          }

          // register the extension, if necessary
          using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension))
          {
            if (key == null)
            {
              using (RegistryKey extKey = Registry.ClassesRoot.CreateSubKey(extension))
              {
                extKey.SetValue(string.Empty, progId);
              }
            }
          }

          // register the progId, if necessary
          using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(progId))
          {
            if (key == null)
            {
              using (RegistryKey progIdKey = Registry.ClassesRoot.CreateSubKey(progId))
              {
                progIdKey.SetValue(string.Empty, description);
                using (RegistryKey defaultIcon = progIdKey.CreateSubKey("DefaultIcon"))
                {
                  defaultIcon.SetValue(string.Empty, String.Format("\"{0}\",{1}", iconFile, iconIdx));
                }

                using (RegistryKey command = progIdKey.CreateSubKey("shell\\open\\command"))
                {
                  command.SetValue(string.Empty, String.Format("\"{0}\" \"%1\"", executeable));
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        Trace.WriteLine(ex);
      }
    }

  }
}
