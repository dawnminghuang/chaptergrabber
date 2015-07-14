ChapterGrabber will extract chapter times from DVD, HD-DVD, and BluRay discs and combine them with chapter names from the internet.  It produces chapter text that are useful when muxing ogg media and matroska files. It is particularly useful for those who like to convert their movies to a portable format for on the go watching.


**Install**
You must have .NET Framework 3.5 available from WindowsUpdate.

**Whats New?**
2009-05-01 : v3.7newDownload
Attempt to fix globalization issues for non-US cultures
Source code included download

2009-01-23 : v3.6
HD-DVD support added. You can now extract chapters from the disc or directly from an XPL file.
4 new output formats added: TsMuxeR Meta, Timecodes, Celltimes, x264 QP File.
You can now change current FPS without recalculating chapter times.

2009-01-09 : v3.5
New source for chapter names can now be grabbed from metaservices.
ChapterGrabber now stores last open directory in settings and points to parent directory when it doesn't exist.

2008-12-19 : v3.4
ChapterGrabber can now detect the fps of BluRay discs via the CLIPINFO data.  However, it does not yet support extracting the fps when directly opening a MPLS file.
The new ChapterGrabber format has been finalized and can be properly loaded and saved.
When moving the chapters up or down, only the names are moved and not the times.
I also added some additional framerates to the config file, 50fps and 60/1.001fps.

2008-12-06 : v3.3
Two new output formats added: Matroska XML and ChapterGrabber XML formats (no support yet for loading these files). You can now choose a language to apply to all chapter names through a new menu. ChapterGrabber now detects and removes invalid characters in the tagChimp search results.

2008-12-03 : v3.2
IFO parsing was re-written with increased accuracy. It also no longer depends on vStrip.dll for IFO parsing. You can now change the FPS of your chapters in case you do a pulldown or want to switch chapter times from NTSC to PAL. A new menu for recently opened files is now available. Please note that Bluray FPS is not yet detected. A new configuration file stores user and app settings.

2008-11-25 : v3.1
New support for reading chapters directly from BluRay discs. Also, IFO parsing was optimized and you can now read chapters directly from DVD discs without having to choose the IFO file. A new setting allows you to ignore the short last chapter that sometimes occur at the very end.

2008-11-19 : v3.0
Updated to .NET Framework 3.5.  All changes prior to 2.0 were lost. :( IFO parsing was rewritten based on Zulu's previous work. I've added tagchimp chapter title import.  You can search for your title and then choose from the search results.  I've disabled the import from web as amazon no longer has chapter names on their website.

**Directions**
1. Open your IFO, MPLS, or text file containing chapter times
OR Open your BluRay, HD-DVD, or DVD disc
2. Type in the title of your movie
3. Click search to download chapter names
4. Choose the best result
5. Save your new text file

**Discussion**
Doom9 Forum New and alternative a/v containers