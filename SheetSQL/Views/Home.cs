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

        Dictionary<string, List<string>> _querySQL;
        #endregion

        #region Constructores
        public Home()
        {
            InitializeComponent();
            this.ListSheet = new SheetLibrary.SheetListEntities();
            this.imageList = new ImageList();
            this._querySQL = new Dictionary<string, List<string>>();
            this._querySQL.Add("SELECT", new List<string>());
            this._querySQL.Add("FROM", new List<string>());
            this._querySQL.Add("WHERE", new List<string>());
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
                        string _select = "SELECT";
                        string _from = "FROM";
                        string _where = "WHERE";

                        string _dado = string.Empty;
                        int posSelect = Query.IndexOf(_select) + "SELECT ".Length;
                        if (posSelect >= 0)
                        {
                            int posFrom = Query.IndexOf(_from,posSelect);
                            if(posFrom >= 0)
                            {
                                _dado = Query.Substring(posSelect,posFrom - posSelect);
                                this._querySQL["SELECT"].Clear();
                                this._querySQL["SELECT"].AddRange(_dado.Split(','));

                                int posWhere = Query.IndexOf(_where, posFrom);
                                if(posWhere >= 0)
                                {
                                    _dado = Query.Substring(posFrom + "FROM".Length,posWhere - (posFrom + "FROM".Length));
                                    this._querySQL["FROM"].Clear();
                                    this._querySQL["FROM"].AddRange(_dado.Split(','));

                                    _dado = Query.Substring(posWhere + "WHERE".Length, Query.Length - (posWhere + "WHERE".Length));
                                    this._querySQL["WHERE"].Clear();
                                    this._querySQL["WHERE"].AddRange(_dado.Replace("AND",",").Split(','));
                                }
                                else
                                {
                                    _dado = Query.Substring(posFrom + "FROM".Length, Query.Length - (posFrom + "FROM".Length));
                                    this._querySQL["FROM"].Clear();
                                    this._querySQL["FROM"].AddRange(_dado.Split(','));
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma tabela selecionada.");
                            }
                        }

                        
                        string queryFinaly = "SELECT ";
                        queryFinaly += String.Join(",", this._querySQL["SELECT"]);
                        queryFinaly += " FROM ";
                        queryFinaly += String.Join(",", this._querySQL["FROM"]);
                        if (this._querySQL["WHERE"].Count() > 0)
                        {
                            queryFinaly += " WHERE ";
                            queryFinaly += String.Join(" AND ", this._querySQL["WHERE"]);
                        }
                        MessageBox.Show(queryFinaly);
                        

                        /*
                        if (this._tableSelected != null)
                        {
                            DataView vw = this._tableSelected.DefaultView;
                            if (vw != null)
                            {
                                vw.RowFilter = wheres;
                                DataTable _tb = columns.Length != 0 ? vw.ToTable(true, columns.Split(',')) : vw.ToTable();
                                LoadGrid(_tb);
                            }
                        }
                        */
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
                                //str = str.ToUpper();
                                if(this.ListSheet.GetAllTabs(Convert.ToInt32(nodeDad.Name)).ToList().Exists(t => t.Trim() == str.Trim().Replace(".", "")))
                                {
                                    RichTextBox_AutoComplete.SetAutocompleteItems(this.ListSheet.Find(Convert.ToInt32(nodeDad.Name), str.Trim().Replace(".", "")).Columns);
                                }

                                /*
                                switch (str)
                                {
                                    case "SELECT":
                                    case "WHERE":
                                        var teste = this.ListSheet.Find(Convert.ToInt32(nodeDad.Name))
                                        RichTextBox_AutoComplete.SetAutocompleteItems(this.ListSheet.Find(Convert.ToInt32(nodeDad.Name)).);
                                        break;
                                    case "FROM":
                                        RichTextBox_AutoComplete.SetAutocompleteItems(this.ListSheet.Find(Convert.ToInt32(nodeDad.Name)).ListTabs);
                                        break;
                                    default:
                                        break;
                                }
                                */
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
