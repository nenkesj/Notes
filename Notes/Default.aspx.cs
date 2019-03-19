using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Notes
{
    public partial class Default : System.Web.UI.Page
    {

        // 
        // To check the Notes page do the following
        // 
        // 1.  Select another node than the one displayed check the new node is displayed - OK
        // 2.  Find a node that has keys and check that the keys drop down has been updated - OK
        // 3.  Check Down buttons functions as expected - OK
        // 4.  Check Up buttons functions as expected - OK
        // 5.  Go to a node with multiple pictures Scroll forward and back through the Pictures - OK
        // 6.  Find a node with a summary and click the sizing radio buttons - OK
        // 7.  Edit a node + Save, Go to another node come back + check the changes are there - OK
        // 8.  Edit a summary and save it go to another node come back and check the summary changes are still there - OK
        // 9.  Filter nodes on a heading + clear filter - OK
        // 10. Filter keys + clear filter - OK
        // 11. Select a key click the Find button - OK 
        // 12. Filter keys, select a key and do a search on the key then clear the search - OK
        // 13. Filter keys, select a key and do a search then page up
        // 14. Filter keys, select a key and do a search then page down
        // 15. Filter keys, select a key and do a search, select a node then click Restore After Search button and check it
        //     returns you to the node being viewed before the search - OK
        // 16. Try the Words Text Operation on a Node - OK
        // 17. Try the Sentences Text Operation on a Node - OK
        // 18. Try the Debugging Text Operation on a Node - OK
        // 19. Swap from Notes to Info mode and Swap Back - OK
        // 20. Swap from Notes to Info, select a diff Info Node, click the Source Node button, click back to Info,
        //     then back to Notes - OK 
        // 
        //     The following tests require a little more work and can be left
        //     if not convenient - probably best to tick these when your actually creating nodes for real
        // 
        // 21. Create a new node and format the text before saving - OK
        // 22. Create a new child node + Save - OK
        // 23. Add some pictures to a node - OK
        // 24. Add a new key for a node -
        // 25. Create a new Summary -
        // 26. Create a Chapter Summary - 
        // 27. Create a new Info Node -  
        // 28. Test combining a key filter with a node filter + clear both 
        //     as follows 
        //     1st select key then filter nodes then clear - OK 
        //     2nd set node filter then set search key then clear - OK
        //     3rd select key search then select another key + search then clear - OK
        //     4th try select keys search then search again on same key + Clear - OK
        // 

        NoteTree Notes;

        protected void Page_Load(object sender, EventArgs e)
        {

            int NodeType, TreeType;

            Notes = new NoteTree(
                gvSummarize,
                lblPercentReduction,
                lblNoteTools,
                lblInfoTools,
                lbxNodes,
                lbxInfo,
                lbxKeys,
                drpKeys,
                drpFilterOn,
                drpSearchOn,
                drpTxtOpr,
                drpInfoTypes,
                drpSummaries,
                drpPictureType,
                btnUp,
                btnDown,
                btnSummary,
                btnRefresh,
                btnRefreshInfo,
                btnEdit,
                btnEditInfo,
                btnNew,
                btnNewInfo,
                btnNewChild,
                btnInfoNode,
                btnRestoreInfo,
                btnSave,
                btnSaveInfo,
                btnAddKeyWord,
                btnNewSummary,
                btnSaveSummary,
                btnPrevPicture,
                btnNextPicture,
                btnSavePicture,
                btnGo,
                btnBackOut,
                btnSearch,
                btnSrchBack,
                rdoNotes,
                rdoInfo,
                rdoSmallSumm,
                rdoLargeSumm,
                rdoLargestSumm,
                filUpload,
                Picture,
                txtFilterText,
                txtSearchFilter,
                txtKeyWord,
                txtHeading,
                txtNodeText,
                txtPictureTitle,
                txtSummText,
                txtTxtSpecs);
            if (!Page.IsPostBack)
            {
                // Initialize all settings
                NodeType = 5;
                TreeType = 2;
                Notes.InitialSettings(TreeType, NodeType);
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    var nodes =
                      from n in db.Nodes
                      where n.TreeID == 2 && n.TreeLevel == 1
                      orderby n.Heading
                      select new
                      {
                          n.Heading,
                          n.NodeID
                      };
                    if (nodes.Count() > 0)
                    {
                        lbxNodes.DataSource = nodes.ToList();
                        lbxNodes.DataBind();
                    }
                    var infos =
                        from i in db.Infoes
                        where i.TreeID == 2 
                        select i;
                    if (infos.Count() > 0)
                    {
                        lbxInfo.DataSource = infos.ToList();
                        lbxInfo.DataBind();
                    }
                    var keys =
                      (from n in db.Keys
                      where n.TreeID == 2 
                      orderby n.KeyText
                      select new
                      {
                          n.KeyText,
                      }).Distinct();
                    if (keys.Count() > 0)
                    {
                        lbxKeys.DataSource = keys.ToList();
                        lbxKeys.DataBind();
                    }
                    var infotypes =
                        from t in db.Typs
                        where t.Category == "Info"
                        select t;
                    if (infotypes.Count() > 0)
                    {
                        drpInfoTypes.DataSource = infotypes.ToList();
                        drpInfoTypes.DataBind();
                    }
                    var picturetypes =
                        from t in db.Typs
                        where t.Category == "Pictures"
                        select t;
                    if (infos.Count() > 0)
                    {
                        drpPictureType.DataSource = picturetypes.ToList();
                        drpPictureType.DataBind();
                    }
                }
                Notes.NodeChanged();
                SetViewStates("Define");
                SetViewStates("All");
            }
            else
            {
                // Copy from viewstate variables
                SetViewStates("PostBack");
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    var infotypes =
                        from t in db.Typs
                        where t.Category == "Info"
                        select t;
                    if (infotypes.Count() > 0)
                    {
                        drpInfoTypes.DataSource = infotypes.ToList();
                        drpInfoTypes.DataBind();
                    }
                    var picturetypes =
                        from t in db.Typs
                        where t.Category == "Pictures"
                        select t;
                    if (picturetypes.Count() > 0)
                    {
                        drpPictureType.DataSource = picturetypes.ToList();
                        drpPictureType.DataBind();
                    }
                }
            }
        }

        private void SetViewStates(string TypeID)
        {
            // This is all the info we dont want to lose after a postback
            switch (TypeID)
            {
                case "Define":
                    ViewState.Add(ViewState.Count.ToString(), "Mode");
                    ViewState.Add(ViewState.Count.ToString(), "CurrentTree");
                    ViewState.Add(ViewState.Count.ToString(), "NodeType");
                    ViewState.Add(ViewState.Count.ToString(), "InfoType");
                    ViewState.Add(ViewState.Count.ToString(), "SelectedNode");
                    ViewState.Add(ViewState.Count.ToString(), "SelectedInfo");
                    ViewState.Add(ViewState.Count.ToString(), "InfoNode");
                    ViewState.Add(ViewState.Count.ToString(), "ParentNode");
                    ViewState.Add(ViewState.Count.ToString(), "CurrentLevel");
                    ViewState.Add(ViewState.Count.ToString(), "Operation");
                    ViewState.Add(ViewState.Count.ToString(), "InfoOperation");
                    ViewState.Add(ViewState.Count.ToString(), "SearchDisplayed");
                    ViewState.Add(ViewState.Count.ToString(), "SelectCmd");
                    ViewState.Add(ViewState.Count.ToString(), "NodeSelectCmd");
                    ViewState.Add(ViewState.Count.ToString(), "InfoSelectCmd");
                    ViewState.Add(ViewState.Count.ToString(), "NodeFilter");
                    ViewState.Add(ViewState.Count.ToString(), "InfoFilter");
                    ViewState.Add(ViewState.Count.ToString(), "SearchFilter");
                    ViewState.Add(ViewState.Count.ToString(), "SelectedKey");
                    ViewState.Add(ViewState.Count.ToString(), "Item");
                    ViewState.Add(ViewState.Count.ToString(), "SavedYet");
                    ViewState.Add(ViewState.Count.ToString(), "InfoSavedYet");
                    ViewState.Add(ViewState.Count.ToString(), "HasPicture");
                    ViewState.Add(ViewState.Count.ToString(), "HasSummary");
                    ViewState.Add(ViewState.Count.ToString(), "NodeText");
                    ViewState.Add(ViewState.Count.ToString(), "NodeAlteredText");
                    ViewState.Add(ViewState.Count.ToString(), "NodeTextLength");
                    ViewState.Add(ViewState.Count.ToString(), "NodeAlteredTextLength");
                    ViewState.Add(ViewState.Count.ToString(), "NodeTextOpr");
                    ViewState.Add(ViewState.Count.ToString(), "InfoType");
                    ViewState.Add(ViewState.Count.ToString(), "NodeTextSpecs");
                    ViewState.Add(ViewState.Count.ToString(), "RestoreSelectedInfo");
                    ViewState.Add(ViewState.Count.ToString(), "RestoreSelectedNode");
                    ViewState.Add(ViewState.Count.ToString(), "RestoreParentNode");
                    ViewState.Add(ViewState.Count.ToString(), "RestoreCurrentLevel");
                    ViewState.Add(ViewState.Count.ToString(), "RestoreNodeFilter");
                    ViewState.Add(ViewState.Count.ToString(), "RestorePrevSelectedNode");
                    ViewState.Add(ViewState.Count.ToString(), "RestorePrevParentNode");
                    ViewState.Add(ViewState.Count.ToString(), "RestorePrevCurrentLevel");
                    ViewState.Add(ViewState.Count.ToString(), "RestorePrevNodeFilter");
                    break;
                case "All":
                    ViewState["Mode"] = Notes.Mode;
                    ViewState["CurrentTree"] = Notes.CurrentTree;
                    ViewState["NodeType"] = Notes.NodeType;
                    ViewState["InfoType"] = Notes.InfoType;
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["SelectedInfo"] = Notes.SelectedInfo;
                    ViewState["InfoNode"] = Notes.InfoNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    ViewState["SearchDisplayed"] = Notes.SearchDisplayed;
                    ViewState["InfoSelectCmd"] = Notes.InfoSelectCmd;
                    ViewState["InfoFilter"] = Notes.InfoFilter;
                    ViewState["SelectedKey"] = Notes.SelectedKey;
                    ViewState["Item"] = Notes.Item;
                    ViewState["SavedYet"] = Notes.SavedYet;
                    ViewState["InfoSavedYet"] = Notes.InfoSavedYet;
                    ViewState["HasPicture"] = Notes.HasPicture;
                    ViewState["HasSummary"] = Notes.HasSummary;
                    ViewState["NodeText"] = Notes.NodeText;
                    ViewState["NodeAlteredText"] = Notes.NodeAlteredText;
                    ViewState["NodeTextLength"] = Notes.NodeTextLength;
                    ViewState["NodeAlteredTextLength"] = Notes.NodeAlteredTextLength;
                    ViewState["NodeTextOpr"] = Notes.NodeTextOpr;
                    ViewState["InfoType"] = Notes.InfoType;
                    ViewState["NodeTextSpecs"] = Notes.NodeTextSpecs;
                    ViewState["RestoreSelectedInfo"] = Notes.RestoreSelectedInfo;
                    ViewState["RestoreSelectedNode"] = Notes.RestoreSelectedNode;
                    ViewState["RestoreParentNode"] = Notes.RestoreParentNode;
                    ViewState["RestoreCurrentLevel"] = Notes.RestoreCurrentLevel;
                    ViewState["RestorePrevSelectedNode"] = Notes.RestorePrevSelectedNode;
                    ViewState["RestorePrevParentNode"] = Notes.RestorePrevParentNode;
                    ViewState["RestorePrevCurrentLevel"] = Notes.RestorePrevCurrentLevel;
                    break;
                case "PostBack":
                    Notes.Mode = (string)ViewState["Mode"];
                    Notes.CurrentTree = (int)ViewState["CurrentTree"];
                    Notes.NodeType = (int)ViewState["NodeType"];
                    Notes.InfoType = (short)ViewState["InfoType"];
                    Notes.SelectedNode = (int)ViewState["SelectedNode"];
                    Notes.SelectedInfo = (int)ViewState["SelectedInfo"];
                    Notes.InfoNode = (int)ViewState["InfoNode"];
                    Notes.ParentNode = (int)ViewState["ParentNode"];
                    Notes.CurrentLevel = (int)ViewState["CurrentLevel"];
                    Notes.Operation = (string)ViewState["Operation"];
                    Notes.InfoOperation = (string)ViewState["InfoOperation"];
                    Notes.SearchDisplayed = (bool)ViewState["SearchDisplayed"];
                    Notes.InfoSelectCmd = (string)ViewState["InfoSelectCmd"];
                    Notes.InfoFilter = (string)ViewState["InfoFilter"];
                    Notes.SelectedKey = (string)ViewState["SelectedKey"];
                    Notes.Item = (int)ViewState["Item"];
                    Notes.SavedYet = (bool)ViewState["SavedYet"];
                    Notes.InfoSavedYet = (bool)ViewState["InfoSavedYet"];
                    Notes.HasPicture = (bool)ViewState["HasPicture"];
                    Notes.HasSummary = (bool)ViewState["HasSummary"];
                    Notes.NodeText = (string)ViewState["NodeText"];
                    Notes.NodeAlteredText = (string)ViewState["NodeAlteredText"];
                    Notes.NodeTextLength = (int)ViewState["NodeTextLength"];
                    Notes.NodeAlteredTextLength = (int)ViewState["NodeAlteredTextLength"];
                    Notes.NodeTextOpr = (string)ViewState["NodeTextOpr"];
                    Notes.InfoType = (short)ViewState["InfoType"];
                    Notes.NodeTextSpecs = (string)ViewState["NodeTextSpecs"];
                    Notes.RestoreSelectedInfo = (int)ViewState["RestoreSelectedInfo"];
                    Notes.RestoreSelectedNode = (int)ViewState["RestoreSelectedNode"];
                    Notes.RestoreParentNode = (int)ViewState["RestoreParentNode"];
                    Notes.RestoreCurrentLevel = (int)ViewState["RestoreCurrentLevel"];
                    Notes.RestorePrevSelectedNode = (int)ViewState["RestorePrevSelectedNode"];
                    Notes.RestorePrevParentNode = (int)ViewState["RestorePrevParentNode"];
                    Notes.RestorePrevCurrentLevel = (int)ViewState["RestorePrevCurrentLevel"];
                    break;
                case "Refresh":
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["Item"] = Notes.Item;
                    break;
                case "RefreshInfo":
                    ViewState["SelectedInfo"] = Notes.SelectedInfo;
                    ViewState["InfoNode"] = Notes.InfoNode;
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    break;
                case "Edit":
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SavedYet"] = Notes.SavedYet;
                    break;
                case "EditInfo":
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    ViewState["InfoSavedYet"] = Notes.InfoSavedYet;
                    break;
                case "New":
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SavedYet"] = Notes.SavedYet;
                    ViewState["HasPicture"] = Notes.HasPicture;
                    ViewState["HasSummary"] = Notes.HasSummary;
                    break;
                case "NewInfo":
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    ViewState["InfoSavedYet"] = Notes.InfoSavedYet;
                    break;
                case "Save":
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SavedYet"] = Notes.SavedYet;
                    ViewState["HasPicture"] = Notes.HasPicture;
                    ViewState["HasSummary"] = Notes.HasSummary;
                    ViewState["Item"] = Notes.Item;
                    ViewState["NodeTextOpr"] = Notes.NodeTextOpr;
                    break;
                case "SaveInfo":
                    ViewState["SelectedInfo"] = Notes.SelectedInfo;
                    ViewState["InfoNode"] = Notes.InfoNode;
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    ViewState["InfoSavedYet"] = Notes.InfoSavedYet;
                    ViewState["NodeTextOpr"] = Notes.NodeTextOpr;
                    break;
                case "NodeChanged":
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["Item"] = Notes.Item;
                    break;
                case "InfoChanged":
                    ViewState["SelectedInfo"] = Notes.SelectedInfo;
                    ViewState["InfoNode"] = Notes.InfoNode;
                    ViewState["InfoOperation"] = Notes.InfoOperation;
                    break;
                case "UpOrDown":
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["SelectedKey"] = Notes.SelectedKey;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SearchDisplayed"] = Notes.SearchDisplayed;
                    ViewState["Item"] = Notes.Item;
                    break;
                case "Search":
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SearchDisplayed"] = Notes.SearchDisplayed;
                    ViewState["Item"] = Notes.Item;
                    break;
                case "SrchBack":
                    ViewState["SelectedKey"] = Notes.SelectedKey;
                    ViewState["SelectedNode"] = Notes.SelectedNode;
                    ViewState["ParentNode"] = Notes.ParentNode;
                    ViewState["CurrentLevel"] = Notes.CurrentLevel;
                    ViewState["Operation"] = Notes.Operation;
                    ViewState["SearchDisplayed"] = Notes.SearchDisplayed;
                    ViewState["Item"] = Notes.Item;
                    break;
                case "SaveNodeLocation":
                    ViewState["RestoreSelectedNode"] = Notes.SelectedNode;
                    ViewState["RestoreParentNode"] = Notes.ParentNode;
                    ViewState["RestoreCurrentLevel"] = Notes.CurrentLevel;
                    break;
                case "RestoreNodeLocation":
                    Notes.SelectedNode = (int)ViewState["RestoreSelectedNode"];
                    Notes.ParentNode = (int)ViewState["RestoreParentNode"];
                    Notes.CurrentLevel = (int)ViewState["RestoreCurrentLevel"];
                    break;
                case "SavePrevLocation":
                    ViewState["RestorePrevSelectedNode"] = ViewState["RestoreSelectedNode"];
                    ViewState["RestorePrevParentNode"] = ViewState["RestoreParentNode"];
                    ViewState["RestorePrevCurrentLevel"] = ViewState["RestoreCurrentLevel"];
                    break;
                case "RestorePrevLocation":
                    Notes.SelectedNode = (int)ViewState["RestorePrevSelectedNode"];
                    Notes.ParentNode = (int)ViewState["RestorePrevParentNode"];
                    Notes.CurrentLevel = (int)ViewState["RestorePrevCurrentLevel"];
                    break;
                case "SaveInfoLocation":
                    ViewState["RestoreSelectedInfo"] = Notes.SelectedInfo;
                    break;
                case "RestoreInfoLocation":
                    Notes.SelectedInfo = (int)ViewState["RestoreSelectedInfo"];
                    break;
                case "NodeTextOperation":
                    ViewState["NodeText"] = Notes.NodeText;
                    ViewState["NodeAlteredText"] = Notes.NodeAlteredText;
                    ViewState["NodeTextLength"] = Notes.NodeTextLength;
                    ViewState["NodeAlteredTextLength"] = Notes.NodeAlteredTextLength;
                    ViewState["NodeTextSpecs"] = Notes.NodeTextSpecs;
                    break;
                case "SelectedKey":
                    ViewState["SelectedKey"] = Notes.SelectedKey;
                    break;
                case "SelectedTextOpr":
                    ViewState["NodeTextOpr"] = Notes.NodeTextOpr;
                    break;
                case "InfoType":
                    ViewState["InfoType"] = Notes.InfoType;
                    break;
                case "Item":
                    ViewState["Item"] = Notes.Item;
                    break;
                case "Summary":
                    ViewState["HasSummary"] = Notes.HasSummary;
                    ViewState["NodeText"] = Notes.NodeText;
                    break;
                case "Mode":
                    ViewState["Mode"] = Notes.Mode;
                    break;
            }
        }

        protected void lbxNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("NodeChanged");
        }

        protected void lbxKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            Notes.SelectedKey = lbxKeys.SelectedItem.Text;
            SetViewStates("SelectedKey");
        }

        protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Refresh();
            Notes.NodeChanged();
            Notes.Item = 0;
            SetViewStates("Refresh");
        }

        protected void btnUp_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Up();
            Notes.SearchDisplayed = false;
            if (Notes.SelectedNode > 0)
                lbxNodes.Items.FindByValue(Notes.SelectedNode.ToString()).Selected = true;
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("UpOrDown");
        }

        protected void btnDown_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Down();
            Notes.SearchDisplayed = false;
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("UpOrDown");
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Operation = "Edit";
            Notes.EditNode();
            SetViewStates("Edit");
        }

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Operation = "New";
            Notes.NewNode();
            SetViewStates("New");
        }

        protected void btnNewChild_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Operation = "NewChild";
            Notes.NewChildNode();
            SetViewStates("New");
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Save();
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("Save");
            // Save happens in the Tree Class but cant be bothered passing all these down through NoteTree && Tree
            drpTxtOpr.ClearSelection();
            txtTxtSpecs.Enabled = false;
            txtTxtSpecs.Text = "";
            btnGo.Enabled = false;
            btnGo.ImageUrl = "images/Icons/Go_Disabled.png";
            btnBackOut.Enabled = false;
            btnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
        }

        protected void btnSearchRefresh_Click(object sender, ImageClickEventArgs e)
        {
            Notes.SearchRefresh();
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (btnSrchBack.Enabled == false)
                SetViewStates("SaveNodeLocation");
            Notes.Search();
            Notes.SearchDisplayed = true;
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("Search");
        }

        protected void btnSrchBack_Click(object sender, ImageClickEventArgs e)
        {
            SetViewStates("RestoreNodeLocation");
            Notes.SrchBack();
            Notes.SearchDisplayed = false;
            if (Notes.SelectedNode > 0)
                lbxNodes.Items.FindByValue(Notes.SelectedNode.ToString()).Selected = true;
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("SrchBack");
            // Same thing cant be bothered passing these down to Tree Class
            drpSearchOn.ClearSelection();
            txtSearchFilter.Text = "";
        }

        protected void btnAddKeyWord_Click(object sender, ImageClickEventArgs e)
        {
            Notes.AddKeyWord();
            lbxKeys.Items.FindByText(txtKeyWord.Text).Selected = true;
            txtKeyWord.Text = "";
        }

        protected void rdoNotes_CheckedChanged(object sender, EventArgs e)
        {
            SetViewStates("InfoChanged");
            SetViewStates("SaveInfoLocation");
            SetViewStates("RestoreNodeLocation");
            Notes.BackToNodes();
            if (Notes.SelectedNode > 0)
                lbxNodes.Items.FindByValue(Notes.SelectedNode.ToString()).Selected = true;
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            Notes.Mode = "Notes";
            SetViewStates("NodeChanged");
            SetViewStates("Mode");
        }

        protected void rdoInfo_CheckedChanged(object sender, EventArgs e)
        {
            Notes.Mode = "Info";
            SetViewStates("Mode");
            SetViewStates("NodeChanged");
            SetViewStates("SaveNodeLocation");
            SetViewStates("RestoreInfoLocation");
            drpInfoTypes.ClearSelection();
            if (Notes.SelectedInfo > 0)
                lbxInfo.Items.FindByValue(Notes.SelectedInfo.ToString()).Selected = true;
            Notes.InfoChanged();
            Notes.Item = 0;
            Notes.InfoOperation = "BrowseInfo";
            SetViewStates("InfoChanged");
        }

        protected void btnInfoNode_Click(object sender, ImageClickEventArgs e)
        {
            SetViewStates("InfoChanged");
            SetViewStates("SaveInfoLocation");
            Notes.BackToInfoNode();
            if (Notes.InfoNode > 0)
                lbxNodes.Items.FindByValue(Notes.InfoNode.ToString()).Selected = true;
            Notes.Mode = "Notes";
            SetViewStates("Mode");
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("NodeChanged");
            btnRestoreInfo.Enabled = true;
            btnRestoreInfo.Visible = true;
        }

        protected void btnRestoreInfo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Mode = "Info";
            SetViewStates("Mode");
            SetViewStates("NodeChanged");
            SetViewStates("RestoreInfoLocation");
            //SetViewStates("RestoreNodeLocation");
            drpInfoTypes.ClearSelection();
            if (Notes.SelectedInfo > 0)
                lbxInfo.Items.FindByValue(Notes.SelectedInfo.ToString()).Selected = true;
            Notes.InfoChanged();
            Notes.InfoOperation = "BrowseInfo";
            SetViewStates("InfoChanged");
            btnRestoreInfo.Enabled = false;
            btnRestoreInfo.Visible = false;
        }

        protected void lbxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpInfoTypes.ClearSelection();
            Notes.InfoOperation = "BrowseInfo";
            Notes.InfoChanged();
            SetViewStates("InfoChanged");
            drpInfoTypes.Items.FindByValue(Notes.InfoType.ToString()).Selected = true;
        }

        protected void drpTxtOpr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Notes.TextOpSelected();
            SetViewStates("SelectedTextOpr");
        }

        protected void drpInfoTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Notes.InfoType = Int16.Parse(drpInfoTypes.SelectedItem.Value.ToString());
            btnSaveInfo.Enabled = true;
            btnSaveInfo.ImageUrl = "images/Icons/Save.png";
            SetViewStates("InfoType");
        }

        protected void btnRefreshInfo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.Refresh();
            Notes.NodeChanged();
            Notes.Item = 0;
            SetViewStates("Refresh");
        }

        protected void btnEditInfo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.InfoOperation = "EditInfo";
            Notes.EditInfo();
            SetViewStates("EditInfo");
        }

        protected void btnNewInfo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.InfoOperation = "NewInfo";
            Notes.NewInfo();
            drpInfoTypes.ClearSelection();
            SetViewStates("NewInfo");
        }

        protected void btnSaveInfo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.SaveInfo();
            Notes.InfoChanged();
            Notes.InfoOperation = "BrowseInfo";
            drpInfoTypes.Items.FindByValue(Notes.InfoType.ToString()).Selected = true;
            Notes.InfoOperation = "BrowseInfo";
            SetViewStates("SaveInfo");
            // Save happens in the Tree Class but cant be bothered passing all these down through NoteTree && Tree
            drpTxtOpr.ClearSelection();
            txtTxtSpecs.Enabled = false;
            txtTxtSpecs.Text = "";
            btnGo.Enabled = false;
            btnGo.ImageUrl = "images/Icons/Go_Disabled.png";
            btnBackOut.Enabled = false;
            btnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
        }

        protected void btnGo_Click(object sender, ImageClickEventArgs e)
        {
            Notes.TextOperation();
            Notes.EnableGo = true;
            SetViewStates("NodeTextOperation");
        }

        protected void btnBackOut_Click(object sender, ImageClickEventArgs e)
        {
            btnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
            btnBackOut.Enabled = false;
            if (Notes.EnableGo)
            {
                btnGo.ImageUrl = "images/Icons/Go.png";
                btnGo.Enabled = true;
            }
            else
            {
                btnGo.ImageUrl = "images/Icons/Go_Disabled.png";
                btnGo.Enabled = false;
            }
            Notes.BackOut();
            SetViewStates("NodeTextOperation");
        }

        protected void rdoSmallSumm_CheckedChanged(object sender, EventArgs e)
        {
            txtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(85);
        }

        protected void rdoLargeSumm_CheckedChanged(object sender, EventArgs e)
        {
            txtSummText.Height = System.Web.UI.WebControls.Unit.Percentage(90);
        }

        protected void rdoLargestSumm_CheckedChanged(object sender, EventArgs e)
        {
            txtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(670);
        }

        protected void btnSaveSummary_Click(object sender, ImageClickEventArgs e)
        {
            drpSummaries.ClearSelection();
            Notes.SaveSummary();
        }

        protected void btnPrevPicture_Click(object sender, ImageClickEventArgs e)
        {
            Notes.PrevPicture();
            SetViewStates("Item");
        }

        protected void btnNextPicture_Click(object sender, ImageClickEventArgs e)
        {
            Notes.NextPicture();
            SetViewStates("Item");
        }

        protected void btnSavePicture_Click(object sender, ImageClickEventArgs e)
        {
            Notes.SavePicture();
            SetViewStates("Item");
        }

        protected void gvSummarize_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page.  
            gvSummarize.PageIndex = e.NewPageIndex;
            // Rebind the GridView control to show data in the new page.
            BindGridView();
        }

        protected void gvSummarize_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Make the GridView control into edit mode for the selected row. 
            gvSummarize.EditIndex = e.NewEditIndex;
            // Rebind the GridView control to show data in edit mode.
            BindGridView();
        }

        protected void gvSummarize_RowUpdated(object sender, GridViewUpdateEventArgs e)
        {
            int i;
            i = 1;
        }

        protected void gvSummarize_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dtSummarize;
            DataRow drSummarize;
            int SentenceNo;
            string str;
            CheckBox cntl;
            // Get the DataTable from ViewState.
            dtSummarize = (DataTable)ViewState["dtSummarize"];
            // Get the Index of the selected row.
            str = gvSummarize.Rows[e.RowIndex].Cells[3].Text;
            SentenceNo = (int)Int64.Parse(str);
            // Find the row in DateTable.
            drSummarize = dtSummarize.Rows.Find(SentenceNo);
            // Retrieve edited values && updating respective items.
            cntl = (CheckBox)gvSummarize.Rows[SentenceNo % gvSummarize.PageSize].FindControl("CheckBox1");
            drSummarize["Include"] = cntl.Checked;
            // Exit edit mode.
            gvSummarize.EditIndex = -1;
            // Rebind the GridView control to show data after updating.
            BindGridView();
        }

        protected void gvSummarize_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Exit edit mode.
            gvSummarize.EditIndex = -1;
            // Rebind the GridView control to show data in view mode.
            BindGridView();
        }

        protected void gvSummarize_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int i;
            i = 1;
        }

        protected void BindGridView()
        {
            DataTable dtSummarize;
            DataView dvSummarize;
            int lastParagraph, currParagraph, reduction;
            decimal calc;
            bool SomethingSelected;
            SomethingSelected = false;
            // Get the DataTable from ViewState.
            dtSummarize = (DataTable)ViewState["dtSummarize"];
            // Convert the DataTable to DataView.
            dvSummarize = new DataView(dtSummarize);
            // Bind the GridView control.
            gvSummarize.DataSource = dvSummarize;
            gvSummarize.DataBind();
            // Create Summary
            lastParagraph = 0;
            txtSummText.Text = "Summary: " + txtHeading.Text + (Char)13 + (Char)10 + (Char)13 + (Char)10;
            foreach (DataRow row in dtSummarize.Rows)
            {
                currParagraph = Int32.Parse(row["Paragraph"].ToString());
                if (currParagraph != lastParagraph)
                {
                    if (SomethingSelected)
                    {
                        txtSummText.Text += " " + (Char)13 + (Char)10 + (Char)13 + (Char)10;
                        SomethingSelected = false;
                    }
                    lastParagraph = currParagraph;
                }
                if ((bool)row["Include"])
                {
                    txtSummText.Text += row["Sentence"].ToString() + " ";
                    SomethingSelected = true;
                }
            }
            if (SomethingSelected)
            {
                txtSummText.Text += " " + (Char)13 + (Char)10 + (Char)13 + (Char)10;
            }
            calc = 100 - (100 * ((decimal)txtSummText.Text.Length / (decimal)txtNodeText.Text.Length));
            reduction = (int)calc;
            lblPercentReduction.Text = "Summary text reduction is : " + reduction.ToString() + " %";
        }

        // Initialize the DataTable.

        protected void InitializeDataSource()
        {
            int ParagraphsNoOf, SentencesNoOf, LinesNoOf, SentNoOf;
            string debugText, SentenceNo, Sentence, Paragraph;
            DataTable dtSummarize;
            DataColumn[] dcSummarize = new DataColumn[1];
            SummarizeSentence tempSummarize;
            List<SummarizeSentence> SummSentences = new List<SummarizeSentence>();
            Text txt;
            List<string> Paragraphs, Sentences, Lines;
            List<int> SentenceInParagraph;
            txt = new Text();
            Paragraphs = new List<string>();
            Sentences = new List<string>();
            Lines = new List<string>();
            SentenceInParagraph = new List<int>();
            // Create a DataTable object named dtSummarize.
            dtSummarize = new DataTable();
            // Add four columns to the DataTable.
            DataColumn Incl = new DataColumn("Include", System.Type.GetType("System.Boolean"));
            DataColumn Para = new DataColumn("Paragraph", System.Type.GetType("System.Int64"));
            DataColumn SentNo = new DataColumn("SentenceNo", System.Type.GetType("System.Int64"));
            DataColumn Sent = new DataColumn("Sentence", System.Type.GetType("System.String"));
            dtSummarize.Columns.Add(Incl);
            dtSummarize.Columns.Add(Para);
            dtSummarize.Columns.Add(SentNo);
            dtSummarize.Columns.Add(Sent);
            // Specify SentenceNo column as an auto increment column
            // && set the starting value && increment.
            dtSummarize.Columns["SentenceNo"].AutoIncrement = true;
            dtSummarize.Columns["SentenceNo"].AutoIncrementSeed = 1;
            dtSummarize.Columns["SentenceNo"].AutoIncrementStep = 1;
            // Set SentenceNo column as the primary key.
            // Set PersonID column as the primary key.
            dcSummarize[0] = dtSummarize.Columns["SentenceNo"];
            dtSummarize.PrimaryKey = dcSummarize;
            // Get the Text
            txt.TheText = txtNodeText.Text;
            txt.NoOfChars = txt.TheText.Length;
            txt.DivideText(out ParagraphsNoOf, ref Paragraphs, out SentencesNoOf, ref Sentences, ref SentenceInParagraph, out LinesNoOf, ref Lines, out debugText, 0, false, true, true, false, false);
            for (int i = 0; i <= SentencesNoOf - 1; i++)
            {
                tempSummarize = new SummarizeSentence();
                tempSummarize.Include = false;
                tempSummarize.Paragraph = SentenceInParagraph[i];
                tempSummarize.SentenceNo = i;
                tempSummarize.Sentence = Sentences[i];
                SummSentences.Add(tempSummarize);
            } 
            foreach (SummarizeSentence sentence in SummSentences)
            {
                dtSummarize.Rows.Add(sentence.Include, sentence.Paragraph, sentence.SentenceNo, sentence.Sentence);
            }
            // Store the DataTable in ViewState. 
            ViewState["dtSummarize"] = dtSummarize;
        }

        protected void btnNewSummary_Click(object sender, ImageClickEventArgs e)
        {
            Notes.EnableGo = false;
            gvSummarize.Visible = true;
            gvSummarize.Enabled = true;
            // Initialize the DataTable && store it in ViewState.
            InitializeDataSource();
            // Enable the GridView paging option && specify the page size.
            gvSummarize.AllowPaging = true;
            gvSummarize.PageSize = 10;
            // Populate the GridView.
            BindGridView();
            // Create the Summary
            Notes.NewSummary();
            drpSummaries.ClearSelection();
            SetViewStates("Summary");
        }

        protected void btnSummary_Click(object sender, ImageClickEventArgs e)
        {
            Notes.ChapterSummary();
            Notes.SavedYet = true;
            Notes.Operation = "New";
            Notes.NodeChanged();
            Notes.Item = 0;
            Notes.Operation = "Browse";
            SetViewStates("UpOrDown");
            SetViewStates("New");
        }

    }
}