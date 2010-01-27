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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JarrettVance.ChapterTools;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading;
using System.Diagnostics;
using JarrettVance.ChapterTools.Extractors;
using System.Collections.Specialized;
namespace JarrettVance.ChapterTools
{
  /// <summary>
  /// Summary description for frmMain.
  /// </summary>
  public partial class frmMain : System.Windows.Forms.Form
  {
    public System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem menuFile;
    private System.Windows.Forms.MenuItem menuEdit;
    private System.Windows.Forms.MenuItem menuEditClipboardImport;
    private System.Windows.Forms.MenuItem miSearch;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.MenuItem menuFileSave;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuFileExit;
    private System.Windows.Forms.MenuItem menuFileNew;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem miImportDurations;


    private System.Windows.Forms.ListView listChapters;
    private System.Windows.Forms.Button btnDn;
    private System.Windows.Forms.Button btnUp;
    private System.Windows.Forms.Button btnClipboard;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.TextBox txtChapterName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtChapterTime;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox grpChapters;

    private System.Windows.Forms.MenuItem menuHelp;
    private System.Windows.Forms.MenuItem menuHelpAbout;
    private SplitContainer splitContainer1;
    private GroupBox grpResults;
    private Button btnSearch;
    private ListBox lstResults;
    private Button btnLookup;
    private MenuItem menuResetNames;
    private MenuItem menuItem2;
    private MenuItem miOpenFile;
    private MenuItem miOpenDisc;
    private MenuItem miIgnoreShortLastChapter;
    private MenuItem menuChangeFps;
    private MenuItem menuRecentFiles;
    private MenuItem menuItem13;
    private IContainer components;

    public frmMain()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
      this.menuFile = new System.Windows.Forms.MenuItem();
      this.menuFileNew = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.miOpenFile = new System.Windows.Forms.MenuItem();
      this.miOpenDisc = new System.Windows.Forms.MenuItem();
      this.menuFileSave = new System.Windows.Forms.MenuItem();
      this.menuItem13 = new System.Windows.Forms.MenuItem();
      this.menuRecentFiles = new System.Windows.Forms.MenuItem();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuFileExit = new System.Windows.Forms.MenuItem();
      this.menuEdit = new System.Windows.Forms.MenuItem();
      this.menuResetNames = new System.Windows.Forms.MenuItem();
      this.menuEditClipboardImport = new System.Windows.Forms.MenuItem();
      this.miSearch = new System.Windows.Forms.MenuItem();
      this.menuChangeFps = new System.Windows.Forms.MenuItem();
      this.menuLang = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.miImportDurations = new System.Windows.Forms.MenuItem();
      this.miIgnoreShortLastChapter = new System.Windows.Forms.MenuItem();
      this.menuHelp = new System.Windows.Forms.MenuItem();
      this.menuHelpAbout = new System.Windows.Forms.MenuItem();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.lblTitle = new System.Windows.Forms.Label();
      this.listChapters = new System.Windows.Forms.ListView();
      this.btnDn = new System.Windows.Forms.Button();
      this.btnUp = new System.Windows.Forms.Button();
      this.btnClipboard = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.txtChapterName = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtChapterTime = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.grpChapters = new System.Windows.Forms.GroupBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.grpResults = new System.Windows.Forms.GroupBox();
      this.lstResults = new System.Windows.Forms.ListBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.btnLookup = new System.Windows.Forms.Button();
      this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslDuration = new System.Windows.Forms.ToolStripStatusLabel();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.menuCurrentFps = new System.Windows.Forms.MenuItem();
      this.tsslFps = new System.Windows.Forms.ToolStripDropDownButton();
      this.tsslLang = new System.Windows.Forms.ToolStripDropDownButton();
      this.grpChapters.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.grpResults.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // mainMenu
      // 
      this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
      // 
      // menuFile
      // 
      this.menuFile.Index = 0;
      this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileNew,
            this.menuItem4,
            this.miOpenFile,
            this.miOpenDisc,
            this.menuFileSave,
            this.menuItem13,
            this.menuRecentFiles,
            this.menuItem1,
            this.menuFileExit});
      this.menuFile.MergeType = System.Windows.Forms.MenuMerge.Replace;
      this.menuFile.Text = "File";
      // 
      // menuFileNew
      // 
      this.menuFileNew.Index = 0;
      this.menuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
      this.menuFileNew.Text = "New";
      this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 1;
      this.menuItem4.Text = "-";
      // 
      // miOpenFile
      // 
      this.miOpenFile.Index = 2;
      this.miOpenFile.Text = "Open File";
      this.miOpenFile.Click += new System.EventHandler(this.menuFileOpen_Click);
      // 
      // miOpenDisc
      // 
      this.miOpenDisc.Index = 3;
      this.miOpenDisc.Text = "Open Disc";
      this.miOpenDisc.Click += new System.EventHandler(this.menuItem5_Click);
      // 
      // menuFileSave
      // 
      this.menuFileSave.Index = 4;
      this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
      this.menuFileSave.Text = "Save";
      this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
      // 
      // menuItem13
      // 
      this.menuItem13.Index = 5;
      this.menuItem13.Text = "-";
      // 
      // menuRecentFiles
      // 
      this.menuRecentFiles.Index = 6;
      this.menuRecentFiles.Text = "Recent Files";
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 7;
      this.menuItem1.Text = "-";
      // 
      // menuFileExit
      // 
      this.menuFileExit.Index = 8;
      this.menuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
      this.menuFileExit.Text = "Exit";
      this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
      // 
      // menuEdit
      // 
      this.menuEdit.Index = 1;
      this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuResetNames,
            this.menuChangeFps,
            this.menuEditClipboardImport,
            this.miSearch,
            this.menuCurrentFps,
            this.menuLang,
            this.menuItem2,
            this.miImportDurations,
            this.miIgnoreShortLastChapter});
      this.menuEdit.Text = "Edit";
      // 
      // menuResetNames
      // 
      this.menuResetNames.Index = 0;
      this.menuResetNames.Text = "Reset Chapter Names";
      this.menuResetNames.Click += new System.EventHandler(this.menuResetNames_Click);
      // 
      // menuEditClipboardImport
      // 
      this.menuEditClipboardImport.Index = 2;
      this.menuEditClipboardImport.Shortcut = System.Windows.Forms.Shortcut.F2;
      this.menuEditClipboardImport.Text = "Import Names from Clipboard";
      this.menuEditClipboardImport.Click += new System.EventHandler(this.menuEditClipboardImport_Click);
      // 
      // miSearch
      // 
      this.miSearch.Index = 3;
      this.miSearch.Shortcut = System.Windows.Forms.Shortcut.F3;
      this.miSearch.Text = "Search Names on Internet";
      this.miSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // menuChangeFps
      // 
      this.menuChangeFps.Index = 1;
      this.menuChangeFps.Text = "Convert Chapter Times by FPS";
      // 
      // menuLang
      // 
      this.menuLang.Index = 5;
      this.menuLang.Text = "Current Language";
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 6;
      this.menuItem2.Text = "-";
      // 
      // miImportDurations
      // 
      this.miImportDurations.Checked = true;
      this.miImportDurations.Index = 7;
      this.miImportDurations.Text = "Import Duration on Names";
      this.miImportDurations.Click += new System.EventHandler(this.menuEditTimesImport_Click);
      // 
      // miIgnoreShortLastChapter
      // 
      this.miIgnoreShortLastChapter.Checked = true;
      this.miIgnoreShortLastChapter.Index = 8;
      this.miIgnoreShortLastChapter.Text = "Ignore Short Last Chapter";
      this.miIgnoreShortLastChapter.Click += new System.EventHandler(this.miIgnoreShortLastChapter_Click);
      // 
      // menuHelp
      // 
      this.menuHelp.Index = 2;
      this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
      this.menuHelp.Text = "Help";
      // 
      // menuHelpAbout
      // 
      this.menuHelpAbout.Index = 0;
      this.menuHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
      this.menuHelpAbout.Text = "About";
      this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.FileName = "doc1";
      // 
      // txtTitle
      // 
      this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTitle.Location = new System.Drawing.Point(40, 7);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(265, 20);
      this.txtTitle.TabIndex = 0;
      this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
      // 
      // lblTitle
      // 
      this.lblTitle.Location = new System.Drawing.Point(0, 9);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(32, 16);
      this.lblTitle.TabIndex = 1;
      this.lblTitle.Text = "Title";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // listChapters
      // 
      this.listChapters.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.listChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.listChapters.FullRowSelect = true;
      this.listChapters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listChapters.HideSelection = false;
      this.listChapters.LabelWrap = false;
      this.listChapters.Location = new System.Drawing.Point(6, 16);
      this.listChapters.MultiSelect = false;
      this.listChapters.Name = "listChapters";
      this.listChapters.Size = new System.Drawing.Size(286, 181);
      this.listChapters.TabIndex = 10;
      this.listChapters.UseCompatibleStateImageBehavior = false;
      this.listChapters.View = System.Windows.Forms.View.Details;
      this.listChapters.SelectedIndexChanged += new System.EventHandler(this.listChapters_SelectedIndexChanged);
      // 
      // btnDn
      // 
      this.btnDn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDn.Image = ((System.Drawing.Image)(resources.GetObject("btnDn.Image")));
      this.btnDn.Location = new System.Drawing.Point(206, 199);
      this.btnDn.Name = "btnDn";
      this.btnDn.Size = new System.Drawing.Size(24, 24);
      this.btnDn.TabIndex = 9;
      this.btnDn.Click += new System.EventHandler(this.ChapterControls_Click);
      // 
      // btnUp
      // 
      this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
      this.btnUp.Location = new System.Drawing.Point(182, 199);
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(24, 24);
      this.btnUp.TabIndex = 8;
      this.btnUp.Click += new System.EventHandler(this.ChapterControls_Click);
      // 
      // btnClipboard
      // 
      this.btnClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnClipboard.Image")));
      this.btnClipboard.Location = new System.Drawing.Point(311, 5);
      this.btnClipboard.Name = "btnClipboard";
      this.btnClipboard.Size = new System.Drawing.Size(24, 24);
      this.btnClipboard.TabIndex = 7;
      this.btnClipboard.Click += new System.EventHandler(this.menuEditClipboardImport_Click);
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
      this.btnDelete.Location = new System.Drawing.Point(262, 199);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(24, 24);
      this.btnDelete.TabIndex = 6;
      this.btnDelete.Click += new System.EventHandler(this.ChapterControls_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
      this.btnAdd.Location = new System.Drawing.Point(238, 199);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(24, 24);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Click += new System.EventHandler(this.ChapterControls_Click);
      // 
      // txtChapterName
      // 
      this.txtChapterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtChapterName.Location = new System.Drawing.Point(48, 226);
      this.txtChapterName.MaxLength = 300;
      this.txtChapterName.Name = "txtChapterName";
      this.txtChapterName.Size = new System.Drawing.Size(239, 20);
      this.txtChapterName.TabIndex = 4;
      this.txtChapterName.Text = "Chapter 0";
      this.txtChapterName.TextChanged += new System.EventHandler(this.txtChapter_TextChanged);
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.Location = new System.Drawing.Point(8, 228);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(48, 16);
      this.label6.TabIndex = 3;
      this.label6.Text = "Name";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtChapterTime
      // 
      this.txtChapterTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtChapterTime.Location = new System.Drawing.Point(48, 202);
      this.txtChapterTime.MaxLength = 12;
      this.txtChapterTime.Name = "txtChapterTime";
      this.txtChapterTime.Size = new System.Drawing.Size(116, 20);
      this.txtChapterTime.TabIndex = 2;
      this.txtChapterTime.Text = "00:00:00.000";
      this.txtChapterTime.TextChanged += new System.EventHandler(this.txtChapter_TextChanged);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.Location = new System.Drawing.Point(8, 204);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(48, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "Time";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // grpChapters
      // 
      this.grpChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.grpChapters.Controls.Add(this.listChapters);
      this.grpChapters.Controls.Add(this.btnDn);
      this.grpChapters.Controls.Add(this.btnUp);
      this.grpChapters.Controls.Add(this.btnDelete);
      this.grpChapters.Controls.Add(this.btnAdd);
      this.grpChapters.Controls.Add(this.txtChapterName);
      this.grpChapters.Controls.Add(this.label6);
      this.grpChapters.Controls.Add(this.txtChapterTime);
      this.grpChapters.Controls.Add(this.label3);
      this.grpChapters.Location = new System.Drawing.Point(3, 3);
      this.grpChapters.Name = "grpChapters";
      this.grpChapters.Size = new System.Drawing.Size(298, 253);
      this.grpChapters.TabIndex = 7;
      this.grpChapters.TabStop = false;
      this.grpChapters.Text = "Chapters";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(3, 32);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.grpChapters);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.grpResults);
      this.splitContainer1.Size = new System.Drawing.Size(479, 259);
      this.splitContainer1.SplitterDistance = 304;
      this.splitContainer1.TabIndex = 8;
      // 
      // grpResults
      // 
      this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.grpResults.Controls.Add(this.lstResults);
      this.grpResults.Location = new System.Drawing.Point(3, 3);
      this.grpResults.Name = "grpResults";
      this.grpResults.Size = new System.Drawing.Size(165, 253);
      this.grpResults.TabIndex = 0;
      this.grpResults.TabStop = false;
      this.grpResults.Text = "Results";
      // 
      // lstResults
      // 
      this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lstResults.FormattingEnabled = true;
      this.lstResults.Location = new System.Drawing.Point(6, 16);
      this.lstResults.Name = "lstResults";
      this.lstResults.Size = new System.Drawing.Size(152, 225);
      this.lstResults.TabIndex = 0;
      this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
      this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnSearch.Location = new System.Drawing.Point(341, 5);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(67, 24);
      this.btnSearch.TabIndex = 9;
      this.btnSearch.Text = "Search";
      this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // btnLookup
      // 
      this.btnLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLookup.Enabled = false;
      this.btnLookup.Image = ((System.Drawing.Image)(resources.GetObject("btnLookup.Image")));
      this.btnLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnLookup.Location = new System.Drawing.Point(412, 5);
      this.btnLookup.Name = "btnLookup";
      this.btnLookup.Size = new System.Drawing.Size(67, 24);
      this.btnLookup.TabIndex = 10;
      this.btnLookup.Text = "Lookup";
      this.btnLookup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      // 
      // tsslStatus
      // 
      this.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
      this.tsslStatus.Name = "tsslStatus";
      this.tsslStatus.Size = new System.Drawing.Size(215, 17);
      this.tsslStatus.Spring = true;
      this.tsslStatus.Text = "Ready";
      this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tsslDuration
      // 
      this.tsslDuration.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
      this.tsslDuration.Name = "tsslDuration";
      this.tsslDuration.Size = new System.Drawing.Size(122, 17);
      this.tsslDuration.Text = "Duration: 00:00:00.000";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslDuration,
            this.tsslFps,
            this.tsslLang});
      this.statusStrip1.Location = new System.Drawing.Point(0, 294);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(484, 22);
      this.statusStrip1.TabIndex = 11;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // menuCurrentFps
      // 
      this.menuCurrentFps.Index = 4;
      this.menuCurrentFps.Text = "Current FPS";
      // 
      // tsslFps
      // 
      this.tsslFps.Name = "tsslFps";
      this.tsslFps.Size = new System.Drawing.Size(69, 20);
      this.tsslFps.Text = "29.970fps";
      // 
      // tsslLang
      // 
      this.tsslLang.Name = "tsslLang";
      this.tsslLang.Size = new System.Drawing.Size(89, 20);
      this.tsslLang.Text = "eng (English)";
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(484, 316);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.btnLookup);
      this.Controls.Add(this.btnSearch);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.btnClipboard);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu;
      this.Name = "frmMain";
      this.Text = "ChapterGrabber";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
      this.grpChapters.ResumeLayout(false);
      this.grpChapters.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.grpResults.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
      Application.EnableVisualStyles();      
      Application.Run(new frmMain());
    }

    private MenuItem menuLang;
    private ToolStripStatusLabel tsslStatus;
    private ToolStripStatusLabel tsslDuration;
    private StatusStrip statusStrip1;
    private MenuItem menuCurrentFps;
    private ToolStripDropDownButton tsslFps;
    private ToolStripDropDownButton tsslLang;
  }
}

