using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RegExTester {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.RichTextBox rtbText;
		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.TextBox txtRegEx;
		private System.Windows.Forms.Label lblRegEx;
		private System.Windows.Forms.ListView lvResult;
		private System.Windows.Forms.ColumnHeader chMatch;
		private System.Windows.Forms.ColumnHeader chPosition;
		private System.Windows.Forms.ColumnHeader chLength;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel sbpMatchCount;
        private System.Windows.Forms.StatusBarPanel sbpInfo;
        private System.Windows.Forms.Label label1;
        private TextBox txtReplace;
        private RichTextBox rtxtOutput;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem mnuIgnore;
        private ToolStripMenuItem mnuMultiLine;
        private ToolStripMenuItem mnuReplace;
        private ToolStripMenuItem mnuTest;
        private Label label2;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private RegExProj _Project;
        private string _FileName;
        private SplitContainer splitContainer2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

		public MainForm() {
            _Project = new RegExProj();

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            this.Text = "Regular Expression Tester (untitled)";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.lblRegEx = new System.Windows.Forms.Label();
            this.lvResult = new System.Windows.Forms.ListView();
            this.chMatch = new System.Windows.Forms.ColumnHeader();
            this.chPosition = new System.Windows.Forms.ColumnHeader();
            this.chLength = new System.Windows.Forms.ColumnHeader();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpInfo = new System.Windows.Forms.StatusBarPanel();
            this.sbpMatchCount = new System.Windows.Forms.StatusBarPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMultiLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatchCount)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.HideSelection = false;
            this.rtbText.Location = new System.Drawing.Point(0, 16);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(584, 107);
            this.rtbText.TabIndex = 8;
            this.rtbText.Text = "";
            this.rtbText.WordWrap = false;
            this.rtbText.TextChanged += new System.EventHandler(this.rtbText_TextChanged);
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(584, 16);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "Text";
            // 
            // txtRegEx
            // 
            this.txtRegEx.AcceptsReturn = true;
            this.txtRegEx.AcceptsTab = true;
            this.txtRegEx.AllowDrop = true;
            this.txtRegEx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegEx.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegEx.HideSelection = false;
            this.txtRegEx.Location = new System.Drawing.Point(0, 17);
            this.txtRegEx.Multiline = true;
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegEx.Size = new System.Drawing.Size(314, 469);
            this.txtRegEx.TabIndex = 3;
            this.txtRegEx.TextChanged += new System.EventHandler(this.txtRegEx_TextChanged);
            // 
            // lblRegEx
            // 
            this.lblRegEx.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegEx.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegEx.Location = new System.Drawing.Point(0, 0);
            this.lblRegEx.Name = "lblRegEx";
            this.lblRegEx.Size = new System.Drawing.Size(314, 17);
            this.lblRegEx.TabIndex = 5;
            this.lblRegEx.Text = "Regular Expression";
            // 
            // lvResult
            // 
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMatch,
            this.chPosition,
            this.chLength});
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.FullRowSelect = true;
            this.lvResult.GridLines = true;
            this.lvResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvResult.Location = new System.Drawing.Point(3, 3);
            this.lvResult.MultiSelect = false;
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(570, 277);
            this.lvResult.TabIndex = 10;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            this.lvResult.SelectedIndexChanged += new System.EventHandler(this.lvResult_SelectedIndexChanged);
            // 
            // chMatch
            // 
            this.chMatch.Text = "Match";
            this.chMatch.Width = 435;
            // 
            // chPosition
            // 
            this.chPosition.Text = "Position";
            this.chPosition.Width = 87;
            // 
            // chLength
            // 
            this.chLength.Text = "Length";
            this.chLength.Width = 98;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 510);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpInfo,
            this.sbpMatchCount});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(902, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 12;
            this.statusBar1.Text = "statusBar1";
            // 
            // sbpInfo
            // 
            this.sbpInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpInfo.Name = "sbpInfo";
            this.sbpInfo.Width = 821;
            // 
            // sbpMatchCount
            // 
            this.sbpMatchCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpMatchCount.Name = "sbpMatchCount";
            this.sbpMatchCount.Text = "Match Count:";
            this.sbpMatchCount.Width = 81;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Results";
            // 
            // txtReplace
            // 
            this.txtReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtReplace.Enabled = false;
            this.txtReplace.Location = new System.Drawing.Point(0, 13);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(584, 21);
            this.txtReplace.TabIndex = 18;
            this.txtReplace.TextChanged += new System.EventHandler(this.txtReplace_TextChanged);
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.AutoWordSelection = true;
            this.rtxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtOutput.HideSelection = false;
            this.rtxtOutput.Location = new System.Drawing.Point(3, 3);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtOutput.Size = new System.Drawing.Size(398, 251);
            this.rtxtOutput.TabIndex = 19;
            this.rtxtOutput.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 309);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matches";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtxtOutput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(404, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRegEx);
            this.splitContainer1.Panel1.Controls.Add(this.lblRegEx);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(902, 486);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(584, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Replace";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.mnuTest});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIgnore,
            this.mnuMultiLine,
            this.mnuReplace});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // mnuIgnore
            // 
            this.mnuIgnore.Checked = true;
            this.mnuIgnore.CheckOnClick = true;
            this.mnuIgnore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuIgnore.Name = "mnuIgnore";
            this.mnuIgnore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuIgnore.Size = new System.Drawing.Size(173, 22);
            this.mnuIgnore.Text = "&Ignore Case";
            this.mnuIgnore.Click += new System.EventHandler(this.mnuIgnore_Click);
            // 
            // mnuMultiLine
            // 
            this.mnuMultiLine.Checked = true;
            this.mnuMultiLine.CheckOnClick = true;
            this.mnuMultiLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuMultiLine.Name = "mnuMultiLine";
            this.mnuMultiLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuMultiLine.Size = new System.Drawing.Size(173, 22);
            this.mnuMultiLine.Text = "&MultiLine";
            this.mnuMultiLine.Click += new System.EventHandler(this.mnuMultiLine_Click);
            // 
            // mnuReplace
            // 
            this.mnuReplace.CheckOnClick = true;
            this.mnuReplace.Name = "mnuReplace";
            this.mnuReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuReplace.Size = new System.Drawing.Size(173, 22);
            this.mnuReplace.Text = "&Replace";
            this.mnuReplace.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuTest.Size = new System.Drawing.Size(41, 20);
            this.mnuTest.Text = "&Test";
            this.mnuTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "regex";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Regular Expression Projects|*.regex|All Files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "regex";
            this.saveFileDialog1.Filter = "Regular Expression Projects|*.regex|All Files|*.*";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtbText);
            this.splitContainer2.Panel1.Controls.Add(this.lblText);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.txtReplace);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(584, 486);
            this.splitContainer2.SplitterDistance = 123;
            this.splitContainer2.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(902, 532);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "RegExTester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbpInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatchCount)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new MainForm());
		}

		/// <summary>
		/// Handle click on "Test" button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTest_Click(object sender, System.EventArgs e) {
            mnuTest.Text = "Testing....";
            mnuTest.Enabled = false;

			DoTest();

            if (mnuReplace.Checked)
                doReplace();

            mnuTest.Text = "Test";
            mnuTest.Enabled = true;
		}

		/// <summary>
		/// Perform Regular Expression Test
		/// </summary>
		private void DoTest() {
			// Setup options
			RegexOptions ro = new RegexOptions();
            if (mnuIgnore.Checked) ro = ro | RegexOptions.IgnoreCase;
            if (mnuMultiLine.Checked) ro = ro | RegexOptions.Multiline;
            ro = ro | RegexOptions.IgnorePatternWhitespace;

			// Create Regular Expression Engine
			Regex re = null;
			MatchCollection mc = null;
			try {
                string reg = txtRegEx.Text;

                if (txtRegEx.SelectionLength > 0)
                    reg = txtRegEx.SelectedText;

                //reg = reg.Replace("\r\n", "").Replace("\n", "").Replace("\t", "");

				re = new Regex(reg, ro);
				mc = re.Matches(rtbText.Text);
			} 
			catch (Exception ex){
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Setup ListView
			int[] ag = re.GetGroupNumbers();

			lvResult.Clear();

			lvResult.Columns.Add("Match", 435, HorizontalAlignment.Left);
			lvResult.Columns.Add("Position", 87, HorizontalAlignment.Left);
			lvResult.Columns.Add("Length", 98, HorizontalAlignment.Left);

			foreach(int c in ag) {
				if (c > 0)
					lvResult.Columns.Add("Group " + c.ToString(), 100, HorizontalAlignment.Left);
			}
			
			lvResult.Items.Clear();

			// Setup RichTextBox
			rtbText.HideSelection = true;
			rtbText.SelectAll();
			rtbText.SelectionColor = Color.Black;

			// Match!
			foreach(Match m in mc) {
				ListViewItem lvi = lvResult.Items.Add(m.ToString());

				lvi.SubItems.Add(m.Index.ToString());
				lvi.SubItems.Add(m.Length.ToString());
				
				for (int c=1; c<m.Groups.Count; c++) {
					lvi.SubItems.Add(m.Groups[c].Value);
				}

				rtbText.Select(m.Index, m.Length);
				rtbText.SelectionColor = Color.Red;
			}

			// Reset RichTextBox
			rtbText.Select(0,0);
			rtbText.SelectionColor = Color.Black;

			// Show matching count
			sbpMatchCount.Text = "Match count: " + mc.Count.ToString();
		}

        private void doReplace()
        {
            RegexOptions ro = new RegexOptions();
            if (mnuIgnore.Checked) ro = ro | RegexOptions.IgnoreCase;
            if (mnuMultiLine.Checked) ro = ro | RegexOptions.Multiline;
            ro = ro | RegexOptions.IgnorePatternWhitespace;

            // Create Regular Expression Engine
            Regex re = null;
            try
            {
                string reg = txtRegEx.Text;

                if (txtRegEx.SelectionLength > 0)
                    reg = txtRegEx.SelectedText;

                //reg = reg.Replace("\r\n", "").Replace("\n", "").Replace("\t", "");

                re = new Regex(reg, ro);
                rtxtOutput.Text = re.Replace(rtbText.Text, txtReplace.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

		/// <summary>
		/// Setup application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, System.EventArgs e) {
			Assembly ea = Assembly.GetExecutingAssembly();
			//this.Text = "RegExTest v." +  ea.GetName().Version.ToString();

			sbpInfo.Text = "Using CLR v. " + CLRInfos.Version();
			sbpMatchCount.Text = "Nothing searched yet.";
            SetTabStops(txtRegEx);
		}

		/// <summary>
		/// Handle click on a match result row
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvResult_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (lvResult.SelectedItems.Count == 0) return;

			rtbText.HideSelection = false;
			rtbText.Select(0, 0);

			int position = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[1].Text);
			int lenght = Convert.ToInt32(lvResult.SelectedItems[0].SubItems[2].Text);

			rtbText.Select(position, lenght);
		}

		/// <summary>
		/// Handle click 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void llAbout_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			AboutForm af = new AboutForm();

			af.ShowDialog();

			af.Dispose();
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtReplace.Enabled = mnuReplace.Checked;
            _Project.Replace = mnuReplace.Checked;
            setModified(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtRegEx.Text = string.Empty;
            txtReplace.Text = string.Empty;
            rtbText.Text = string.Empty;
            rtxtOutput.Text = string.Empty;
            lvResult.Items.Clear();
            _FileName = string.Empty;
            _Project = new RegExProj();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = _FileName;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            _FileName = openFileDialog1.FileName;
            _Project = RegExProj.Open(_FileName);
            txtRegEx.Text = _Project.RegularExpression.Replace("\n", "\r\n");
            txtReplace.Text = _Project.ReplaceText;
            rtbText.Text = _Project.TestText;
            rtxtOutput.Text = string.Empty;
            lvResult.Items.Clear();

            mnuIgnore.Checked = _Project.IgnoreCase;
            mnuMultiLine.Checked = _Project.MultiLine;
            mnuReplace.Checked = _Project.Replace;
            txtReplace.Enabled = _Project.Replace;

            setTitle(_FileName);
        }

        private void setTitle(string FileName)
        {
            this.Text = "Regular Expression Tester ";

            string name = System.IO.Path.GetFileNameWithoutExtension(FileName);
            this.Text += '(' + name + ')';
        }

        private void setModified(bool isModified)
        {
            if (isModified & !this.Text.EndsWith("*"))
                this.Text += "*";
            else if (!isModified & this.Text.EndsWith("*"))
                this.Text = this.Text.Substring(0, this.Text.Length - 1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_FileName))
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            _Project.Save(_FileName);
            setTitle(_FileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = _FileName;

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            _FileName = saveFileDialog1.FileName;
            saveToolStripMenuItem_Click(sender, e);
        }

        private void txtRegEx_TextChanged(object sender, EventArgs e)
        {
            _Project.RegularExpression = txtRegEx.Text;
            setModified(true);
        }

        private void rtbText_TextChanged(object sender, EventArgs e)
        {
            if (_Project.TestText == rtbText.Text)
                return;

            _Project.TestText = rtbText.Text;
            setModified(true);
        }

        private void txtReplace_TextChanged(object sender, EventArgs e)
        {
            _Project.ReplaceText = txtReplace.Text;
            setModified(true);
        }

        private void mnuIgnore_Click(object sender, EventArgs e)
        {
            _Project.IgnoreCase = mnuIgnore.Checked;
            setModified(true);
        }

        private void mnuMultiLine_Click(object sender, EventArgs e)
        {
            _Project.MultiLine = mnuMultiLine.Checked;
            setModified(true);
        }

        private const int EM_SETTABSTOPS = 0x00CB;

        private void SetTabStops(TextBox ctlTextBox)
        {
            const int EM_SETTABSTOPS = 203;
            int[] tabs = { 16 };
            SendMessage(ctlTextBox.Handle, EM_SETTABSTOPS, tabs.Length, tabs);
        }

	}
}
