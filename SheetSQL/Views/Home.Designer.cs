namespace SheetSQL.Views
{
    partial class Home
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.Container = new System.Windows.Forms.SplitContainer();
            this.SheetsViews = new System.Windows.Forms.TreeView();
            this.tabsControls = new System.Windows.Forms.TabControl();
            this.SearchsTab = new System.Windows.Forms.TabPage();
            this.dataGridVisualize = new System.Windows.Forms.DataGridView();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.RichTextBox_AutoComplete = new AutocompleteMenuNS.AutocompleteMenu();
            this.BotaoPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.sobreSheetSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.tabsControls.SuspendLayout();
            this.SearchsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVisualize)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.BotaoPlay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(917, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Topbar";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton1.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Tag = "open";
            this.abrirToolStripMenuItem.Text = "Importar";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripDropDownButton2.Text = "Editar";
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 25);
            this.Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.SheetsViews);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.tabsControls);
            this.Container.Size = new System.Drawing.Size(917, 476);
            this.Container.SplitterDistance = 188;
            this.Container.TabIndex = 1;
            // 
            // SheetsViews
            // 
            this.SheetsViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetsViews.Location = new System.Drawing.Point(0, 0);
            this.SheetsViews.Name = "SheetsViews";
            this.SheetsViews.Size = new System.Drawing.Size(188, 476);
            this.SheetsViews.TabIndex = 0;
            this.SheetsViews.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SheetsViews_NodeMouseClick);
            // 
            // tabsControls
            // 
            this.tabsControls.Controls.Add(this.SearchsTab);
            this.tabsControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsControls.Location = new System.Drawing.Point(0, 0);
            this.tabsControls.Name = "tabsControls";
            this.tabsControls.SelectedIndex = 0;
            this.tabsControls.Size = new System.Drawing.Size(725, 476);
            this.tabsControls.TabIndex = 0;
            // 
            // SearchsTab
            // 
            this.SearchsTab.BackColor = System.Drawing.SystemColors.Control;
            this.SearchsTab.Controls.Add(this.dataGridVisualize);
            this.SearchsTab.Controls.Add(this.RichTextBox);
            this.SearchsTab.Location = new System.Drawing.Point(4, 22);
            this.SearchsTab.Name = "SearchsTab";
            this.SearchsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchsTab.Size = new System.Drawing.Size(717, 450);
            this.SearchsTab.TabIndex = 1;
            // 
            // dataGridVisualize
            // 
            this.dataGridVisualize.AllowUserToOrderColumns = true;
            this.dataGridVisualize.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridVisualize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVisualize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVisualize.EnableHeadersVisualStyles = false;
            this.dataGridVisualize.Location = new System.Drawing.Point(3, 101);
            this.dataGridVisualize.Name = "dataGridVisualize";
            this.dataGridVisualize.RowHeadersVisible = false;
            this.dataGridVisualize.Size = new System.Drawing.Size(711, 346);
            this.dataGridVisualize.TabIndex = 3;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AcceptsTab = true;
            this.RichTextBox_AutoComplete.SetAutocompleteMenu(this.RichTextBox, this.RichTextBox_AutoComplete);
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox.BulletIndent = 1;
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.RichTextBox.Location = new System.Drawing.Point(3, 3);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.Size = new System.Drawing.Size(711, 98);
            this.RichTextBox.TabIndex = 2;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // RichTextBox_AutoComplete
            // 
            this.RichTextBox_AutoComplete.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("RichTextBox_AutoComplete.Colors")));
            this.RichTextBox_AutoComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.RichTextBox_AutoComplete.ImageList = null;
            this.RichTextBox_AutoComplete.Items = new string[0];
            this.RichTextBox_AutoComplete.TargetControlWrapper = null;
            // 
            // BotaoPlay
            // 
            this.BotaoPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BotaoPlay.Image = ((System.Drawing.Image)(resources.GetObject("BotaoPlay.Image")));
            this.BotaoPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BotaoPlay.Name = "BotaoPlay";
            this.BotaoPlay.Size = new System.Drawing.Size(23, 22);
            this.BotaoPlay.Tag = "playConsult";
            this.BotaoPlay.Text = "Play Consult";
            this.BotaoPlay.Click += new System.EventHandler(this.Menu_Click);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreSheetSQLToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(51, 22);
            this.toolStripDropDownButton3.Text = "Ajuda";
            // 
            // sobreSheetSQLToolStripMenuItem
            // 
            this.sobreSheetSQLToolStripMenuItem.Name = "sobreSheetSQLToolStripMenuItem";
            this.sobreSheetSQLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobreSheetSQLToolStripMenuItem.Text = "Sobre SheetSQL";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 501);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SheetSQL";
            this.Load += new System.EventHandler(this.Home_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.tabsControls.ResumeLayout(false);
            this.SearchsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVisualize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.SplitContainer Container;
        private System.Windows.Forms.TreeView SheetsViews;
        private System.Windows.Forms.RichTextBox RichTextBox;
        private System.Windows.Forms.TabControl tabsControls;
        private System.Windows.Forms.TabPage SearchsTab;
        private System.Windows.Forms.DataGridView dataGridVisualize;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private AutocompleteMenuNS.AutocompleteMenu RichTextBox_AutoComplete;
        private System.Windows.Forms.ToolStripButton BotaoPlay;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem sobreSheetSQLToolStripMenuItem;
    }
}

