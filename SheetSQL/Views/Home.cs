using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entities.Sheets;
using static Methods.Sheet.SheetLibrary;

namespace SheetSQL.Views
{
    public partial class Home : Form
    {
        #region Attributes
        SheetLibrary.SheetListEntities ListSheet;
        ImageList imageList;
        DataTable _tableSelected;
        #endregion

        #region Constructores
        public Home()
        {
            InitializeComponent();
            this.ListSheet = new SheetLibrary.SheetListEntities();
            this.imageList = new ImageList();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            LoadSheetsViewsImage();
        }
        #endregion

        #region Methods
        void ManageMenu(string Tag)
        {
            try
            {
                switch (Tag)
                {
                    case "open":
                        ManageMenu_Open();
                        break;
                    case "playConsult":
                        ManageMenu_Search();
                        break;
                    default:
                        throw new Exception("No options found");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        void ManageMenu_Open()
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Planilha do Excel | *.xlsx";
                    dlg.Title = "Abri planilha";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        using (SheetMethods sm = new SheetMethods(ref this.ListSheet))
                        {
                            if (sm.IncludeSpreadsheet(dlg.FileName))
                            {
                                sm.LoadTreeView(ref SheetsViews);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        void ManageMenu_Search()
        {
            try
            {
                string Query = RichTextBox.Text;
                if (!string.IsNullOrEmpty(Query))
                {
                    if (!string.IsNullOrWhiteSpace(Query))
                    {
                        int pSelect = Query.IndexOf("SELECT") + "SELECT ".Length;
                        int pFrom = Query.LastIndexOf(" FROM");

                        string columns = string.Empty;
                        List<string> columnsLst = Query.Substring(pSelect, pFrom - pSelect).Split(',').ToList();
                        if(columnsLst.Count > 0)
                            columns = string.Join(",",columnsLst.ToArray()).Replace("\n","").Replace("\t","").TrimStart().TrimEnd();

                        columns = columns == "*" ? "" : columns;

                        pFrom = Query.IndexOf("FROM") + "FROM ".Length;
                        int pWhere = Query.LastIndexOf(" WHERE");

                        string tables = Query.Substring(pFrom, (pWhere == -1 ? Query.Length : pWhere) - pFrom);

                        string wheres = string.Empty;
                        if (Query.Contains("WHERE"))
                        {
                            pWhere = Query.IndexOf("WHERE") + "WHERE ".Length;
                            wheres = Query.Substring(pWhere);
                        }

                        if(this._tableSelected != null)
                        {
                            DataView vw = this._tableSelected.DefaultView;
                            if (vw != null)
                            {
                                vw.RowFilter = wheres;
                                DataTable _tb = columns.Length != 0 ? vw.ToTable(true, columns.Split(',')) : vw.ToTable();
                                LoadGrid(_tb);
                            }
                        }

                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        void LoadGrid(DataTable table)
        {
            try
            {
                dataGridVisualize.DataSource = null;
                dataGridVisualize.DataSource = table;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        void LoadSheetsViewsImage()
        {
            try
            {
                this.imageList.Images.Clear();
                this.imageList.Images.Add(new Bitmap(1,1));
                this.imageList.Images.Add(Properties.Resources.database);
                SheetsViews.ImageList = imageList;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion

        #region Events
        void Menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripMenuItem obj_tsmi)
                    ManageMenu(obj_tsmi.Tag.ToString());
                if(sender is ToolStripButton obj_tsb)
                    ManageMenu(obj_tsb.Tag.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void SheetsViews_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode node = e.Node;
                TreeNode nodeDad = null;
                do
                {
                    nodeDad = node.Parent;
                    if (nodeDad == null) return;
                } while (nodeDad.Level != 0);

                using (SheetMethods sm = new SheetMethods(ref this.ListSheet))
                {
                    this._tableSelected = sm.LoadSheet(Convert.ToInt32(nodeDad.Name),node.Text);
                    SearchsTab.Text = String.Format("[{0}] - {1}",nodeDad.Text, node.Text);
                    LoadGrid(_tableSelected);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(RichTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(RichTextBox.Text))
                    {
                        if (this._tableSelected != null)
                        {
                            TreeNode node = SheetsViews.SelectedNode;
                            TreeNode nodeDad = null;
                            do
                            {
                                nodeDad = node.Parent;
                                if (nodeDad == null) return;
                            } while (nodeDad.Level != 0);

                            string[] strLst = RichTextBox.Text.TrimEnd().Split(' ');
                            string str = strLst[strLst.Length - 1];
                            if (!string.IsNullOrEmpty(str))
                            {
                                str = str.ToUpper();
                                switch (str)
                                {
                                    case "SELECT":
                                    case "WHERE":
                                        RichTextBox_AutoComplete.SetAutocompleteItems(this.ListSheet.Find(Convert.ToInt32(nodeDad.Name)).ListColumns);
                                        break;
                                    case "FROM":
                                        RichTextBox_AutoComplete.SetAutocompleteItems(this.ListSheet.Find(Convert.ToInt32(nodeDad.Name)).ListTabs);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion
    }
}
