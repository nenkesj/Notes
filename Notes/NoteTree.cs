using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Notes
{

    public class NoteTree : BaseTree
    {

        public NoteTree(
            GridView gvSummarize,
            Label lblPercentReduction,
            Label lblNoteTools,
            Label lblInfoTools,
            ListBox lbxNodes,
            ListBox lbxInfo,
            ListBox lbxKeys,
            DropDownList drpKeys,
            DropDownList drpFilterOn,
            DropDownList drpSearchOn,
            DropDownList drpTxtOpr,
            DropDownList drpInfoTypes,
            DropDownList drpSummaries,
            DropDownList drpPictureType,
            ImageButton btnUp,
            ImageButton btnDown,
            ImageButton btnSummary,
            ImageButton btnRefresh,
            ImageButton btnRefreshInfo,
            ImageButton btnEdit,
            ImageButton btnEditInfo,
            ImageButton btnNew,
            ImageButton btnNewInfo,
            ImageButton btnNewChild,
            ImageButton btnInfoNode,
            ImageButton btnRestoreInfo,
            ImageButton btnSave,
            ImageButton btnSaveInfo,
            ImageButton btnAddKeyWord,
            ImageButton btnNewSummary,
            ImageButton btnSaveSummary,
            ImageButton btnPrevPicture,
            ImageButton btnNextPicture,
            ImageButton btnSavePicture,
            ImageButton btnGo,
            ImageButton btnBackOut,
            ImageButton btnSearch,
            ImageButton btnSrchBack,
            RadioButton rdoNotes,
            RadioButton rdoInfo,
            RadioButton rdoSmallSumm,
            RadioButton rdoLargeSumm,
            RadioButton rdoLargestSumm,
            FileUpload filUpload,
            System.Web.UI.WebControls.Image Picture,
            TextBox txtFilterText,
            TextBox txtSearchFilter,
            TextBox txtKeyWord,
            TextBox txtHeading,
            TextBox txtNodeText,
            TextBox txtPictureTitle,
            TextBox txtSummText,
            TextBox txtTxtSpecs)
            : base(lbxNodes,
                   lbxKeys,
                   drpKeys,
                   drpFilterOn,
                   txtFilterText,
                   txtKeyWord,
                   txtHeading,
                   txtNodeText,
                   txtSearchFilter,
                   drpSearchOn,
                   btnRefresh,
                   btnEdit,
                   btnNew,
                   btnNewChild,
                   btnSave,
                   btnAddKeyWord,
                   btnSearch,
                   btnSrchBack,
                   btnUp,
                   btnDown,
                   btnSummary)
        {
            notegvSummarize = gvSummarize;
            notelblPercentReduction = lblPercentReduction;
            notelblNoteTools = lblNoteTools;
            notelblInfoTools = lblInfoTools;
            notelbxNodes = lbxNodes;
            notelbxInfo = lbxInfo;
            notelbxKeys = lbxKeys;
            notedrpKeys = drpKeys;
            notedrpFilterOn = drpFilterOn;
            notedrpSearchOn = drpSearchOn;
            notedrpTxtOpr = drpTxtOpr;
            notedrpInfoTypes = drpInfoTypes;
            notedrpSummaries = drpSummaries;
            notedrpPictureType = drpPictureType;
            notebtnUp = btnUp;
            notebtnDown = btnDown;
            notebtnSummary = btnSummary;
            notebtnRefresh = btnRefresh;
            notebtnRefreshInfo = btnRefreshInfo;
            notebtnEdit = btnEdit;
            notebtnEditInfo = btnEditInfo;
            notebtnNew = btnNew;
            notebtnNewInfo = btnNewInfo;
            notebtnNewChild = btnNewChild;
            notebtnInfoNode = btnInfoNode;
            notebtnRestoreInfo = btnRestoreInfo;
            notebtnSave = btnSave;
            notebtnSaveInfo = btnSaveInfo;
            notebtnAddKeyWord = btnAddKeyWord;
            notebtnNewSummary = btnNewSummary;
            notebtnSaveSummary = btnSaveSummary;
            notebtnPrevPicture = btnPrevPicture;
            notebtnNextPicture = btnNextPicture;
            notebtnSavePicture = btnSavePicture;
            notebtnGo = btnGo;
            notebtnBackOut = btnBackOut;
            notebtnSearch = btnSearch;
            notebtnSrchBack = btnSrchBack;
            noterdoNotes = rdoNotes;
            noterdoInfo = rdoInfo;
            noterdoSmallSumm = rdoSmallSumm;
            noterdoLargeSumm = rdoLargeSumm;
            noterdoLargestSumm = rdoLargestSumm;
            notefilUpload = filUpload;
            notePicture = Picture;
            notetxtFilterText = txtFilterText;
            notetxtSearchFilter = txtSearchFilter;
            notetxtKeyWord = txtKeyWord;
            notetxtHeading = txtHeading;
            notetxtNodeText = txtNodeText;
            notetxtPictureTitle = txtPictureTitle;
            notetxtSummText = txtSummText;
            notetxtTxtSpecs = txtTxtSpecs;
        }

        GridView notegvSummarize;
        Label notelblNoteTools, notelblInfoTools, notelblPercentReduction;
        ListBox notelbxNodes, notelbxInfo, lbxInfo, notelbxKeys;
        DropDownList notedrpKeys, notedrpFilterOn, notedrpSearchOn, notedrpTxtOpr, notedrpInfoTypes, notedrpSummaries, notedrpPictureType;
        ImageButton notebtnUp, notebtnDown, notebtnSummary, notebtnRefresh, notebtnRefreshInfo, notebtnEdit, notebtnEditInfo, notebtnNew, notebtnNewInfo, notebtnNewChild, notebtnInfoNode, notebtnRestoreInfo, notebtnSave, btnSave, notebtnSaveInfo, notebtnAddKeyWord, notebtnNewSummary, notebtnSaveSummary, notebtnPrevPicture, notebtnNextPicture, notebtnSavePicture, notebtnGo, notebtnBackOut, notebtnSearch, notebtnSrchBack;
        RadioButton noterdoNotes, noterdoInfo, noterdoSmallSumm, noterdoLargeSumm, noterdoLargestSumm;
        FileUpload notefilUpload;
        System.Web.UI.WebControls.Image notePicture;
        TextBox notetxtFilterText, notetxtSearchFilter, notetxtKeyWord, notetxtHeading, notetxtNodeText, notetxtPictureTitle, notetxtSummText, notetxtTxtSpecs;

        public bool HasPicture { get; set; }
        public bool HasSummary { get; set; }
        public string NodeText { get; set; }
        public string NodeAlteredText { get; set; }
        public int NodeTextLength { get; set; }
        public int NodeAlteredTextLength { get; set; }
        public string NodeTextOpr { get; set; }
        public string NodeTextSpecs { get; set; }
        public string Mode { get; set; }
        public string InfoFilter { get; set; }
        public short InfoType { get; set; }
        public string InfoSelectCmd { get; set; }
        public int SelectedInfo { get; set; }
        public int RestoreSelectedInfo { get; set; }
        public int InfoNode { get; set; }
        public bool InfoSavedYet { get; set; }
        public bool EnableGo { get; set; }
        public string InfoOperation { get; set; }

        public void InitialInfoSettings(string InfoSelectCommand)
        {
            // Subs called :- None
            // Properties Altered:- NodeType, CurrentTree, DefaultSelectCmd,
            // NodeSelectCmd, ParentNode, SelectedNode, CurrentLevel, Item,
            // Operation, SelectedKey, NodeFilter, SearchFilter
            //
            //The initial value of these ones vary depending on the caller
            //
            //
            // These ones always have the same initial value independent of caller
            //
            // Start with the 1st info at the top of the tree
            this.SelectedInfo = 0;
            // Same with Restore Info
            this.RestoreSelectedInfo = 0;
            // Start with zero Info Node
            this.InfoNode = 0;
            // Start as though were not in the process of Editing something
            this.InfoSavedYet = true;
            // Filter the keywords listbox to only those that belong to the 
            // current tree
            this.InfoFilter = "";
            // Deafault info type
            this.InfoType = 18;
        }

        public override void NodeChanged()
        {
            //Subs called:- DisplayPicture DisplaySummary
            //Properties Altered:- Item HasPicture HasSummary
            base.NodeChanged();
            // Has this node got any pictures? if (so display them + adjust
            // text width
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var pictures = from p in db.Pictures
                            where p.NodeID == this.SelectedNode
                            select p;
                if (pictures.Count() < 1)
                {
                    this.HasPicture = false;
                    notePicture.Visible = false;
                    notetxtPictureTitle.Text = "";
                    notebtnNextPicture.Enabled = false;
                    notebtnNextPicture.ImageUrl = "images/icons/Forward_Disabled.png";
                }
                else
                {
                    this.HasPicture = true;
                    DisplayPicture(pictures.First().Title, pictures.First().Picture1);
                    notePicture.Visible = true;
                    // if (there is more pictures enable next picture button
                    if (pictures.Count() > 1)
                    {
                        notebtnNextPicture.Enabled = true;
                        notebtnNextPicture.ImageUrl = "images/Icons/Forward.png";
                    }
                    else
                    {
                        notebtnNextPicture.Enabled = false;
                        notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                    }
                }
                // We always display the 1st picture so always diable the Prev Picture button
                notebtnPrevPicture.Enabled = false;
                notebtnPrevPicture.ImageUrl = "images/Icons/Back_Disabled.png";
                //
                if (this.Mode == "Info" && HasSummary)
                {
                    this.HasSummary = false;
                }
                else
                {
                    // if summary exists display it 
                    var summaries = from s in db.Summaries
                                   where s.NodeID == this.SelectedNode
                                   select s;
                    if (summaries.Count() < 1)
                    {
                        this.HasSummary = false;
                        noterdoSmallSumm.Checked = false;
                        noterdoSmallSumm.Enabled = false;
                        noterdoLargeSumm.Checked = false;
                        noterdoLargeSumm.Enabled = false;
                        noterdoLargestSumm.Checked = false;
                        noterdoLargestSumm.Enabled = false;
                        notetxtSummText.Visible = false;
                        notedrpSummaries.Enabled = false;
                        notebtnNewSummary.Enabled = true;
                        notebtnNewSummary.Visible = true;
                        notebtnSaveSummary.Enabled = false;
                        notebtnSaveSummary.ImageUrl = "images/Icons/Save_Disabled.png";
                    }
                    else
                    {
                        this.HasSummary = true;
                        noterdoSmallSumm.Checked = true;
                        noterdoSmallSumm.Enabled = true;
                        noterdoLargeSumm.Checked = false;
                        noterdoLargeSumm.Enabled = true;
                        noterdoLargestSumm.Checked = false;
                        noterdoLargestSumm.Enabled = true;
                        notetxtSummText.Visible = true;
                        notedrpSummaries.Enabled = true;
                        notebtnNewSummary.Enabled = false;
                        notebtnNewSummary.Visible = false;
                        notebtnSaveSummary.Enabled = true;
                        notebtnSaveSummary.ImageUrl = "images/Icons/Save.png";
                        notetxtSummText.Width = System.Web.UI.WebControls.Unit.Percentage(42);
                        notetxtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(85);
                        DisplaySummary(summaries.First().Summary1);
                    }
                }
            }
        }

        public void InfoChanged()
        {
            // Subs called:- InitialSettings BindNodes BindKeys InitPage 
            // DisplayNoNodeFound DisplayNode FillKeysForNode AlsoChanged
            // Properties Altered:- Operation SelectedNode ParentNode CurrentLevel
            //Get Selected treelbxNodes Node
            if (notelbxInfo.Items.Count < 1)
            {
                // if (there arent any nodes in the list box reset to initial
                // settings && display a message saying no nodes selected
                DisplayNoInfoFound();
            }
            else
            {
                // if (this is a new node that//s just been saved select the new 
                // node so its displayed in the nodes listbox as opposed to 
                // selecting the 1st node in the list
                // if (this is a new child just drop through to below which selects 1st item (New Child will always be 1st item)
                if (this.InfoOperation == "NewInfo" && this.InfoSavedYet && this.SelectedInfo > 0)
                {
                    notelbxInfo.Items.FindByValue(this.SelectedInfo.ToString()).Selected = true;
                }
                if (this.InfoOperation == "EditInfo" && this.InfoSavedYet && this.SelectedInfo > 0)
                {
                    notelbxInfo.Items.FindByValue(this.SelectedInfo.ToString()).Selected = true;
                }
                // There are nodes in the nodes list box if none have been selected select the 1st node
                if (notelbxInfo.SelectedIndex < 0)
                {
                    notelbxInfo.Items[0].Selected = true;
                }
                // Given the above a node should always now be selected
                this.SelectedInfo = Int32.Parse(notelbxInfo.SelectedValue);
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    Info info = db.Infoes.First(i => i.InfoID == this.SelectedInfo);
                    this.InfoNode = info.NodeID;
                    this.InfoType = info.TypeID;
                    notedrpInfoTypes.Items.FindByValue(this.InfoType.ToString()).Selected = true;
                    // Display 1st row with this NodeID (should only be one as NodeID is the Primary Key)
                    DisplayInfo(info.Heading, info.InfoText);
                    var pics = from p in db.Pictures
                        where p.InfoID == this.SelectedInfo
                        select p;
                    if (pics.Count() < 1)
                    {
                        notePicture.Visible = false;
                        notetxtPictureTitle.Text = "";
                        notebtnNextPicture.Enabled = false;
                        notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                    }
                    else
                    {
                        DisplayPicture(pics.First().Title, pics.First().Picture1);
                        notePicture.Visible = true;
                        // if (there is more pictures enable next picture button
                        if (pics.Count() > 1)
                        {
                            notebtnNextPicture.Enabled = true;
                            notebtnNextPicture.ImageUrl = "images/Icons/Forward.png";
                        }
                        else
                        {
                            notebtnNextPicture.Enabled = false;
                            notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                        }
                    }
                    // We always display the 1st picture so always diable the Prev Picture button
                    notebtnPrevPicture.Enabled = false;
                    notebtnPrevPicture.ImageUrl = "images/Icons/Back_Disabled.png";
                }
            }
            // Set up page in Browse Mode 
            InitPage("BrowseInfo");
        }

        public override void InitPage(string TypeID)
        {
            //Subs called:- NoteReadOnly
            //Properties Altered:- None
            base.InitPage(TypeID);
            switch (TypeID)
            {
                case "Browse":
                    // Disable Text Operations
                    notedrpTxtOpr.Enabled = false;
                    notetxtNodeText.Visible = true;
                    notebtnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
                    notebtnBackOut.Enabled = false;
                    notebtnGo.ImageUrl = "images/Icons/Go_Disabled.png";
                    notebtnGo.Enabled = false;
                    //Enable Picture Tools
                    notefilUpload.Enabled = true;
                    notetxtPictureTitle.Enabled = true;
                    notetxtPictureTitle.Text = "";
                    notedrpPictureType.Enabled = true;
                    notebtnSavePicture.Enabled = true;
                    notebtnSavePicture.ImageUrl = "images/Icons/Save.png";
                    // Enable New Summaries
                    notebtnNewSummary.Enabled = true;
                    notebtnNewSummary.Visible = true;
                    // Buttons dependent on Node or Info Mode
                    noterdoNotes.Checked = true;
                    noterdoInfo.Checked = false;
                    notelblNoteTools.Visible = true;
                    notelblInfoTools.Visible = false;
                    notebtnRefreshInfo.Enabled = false;
                    notebtnRefreshInfo.Visible = false;
                    notebtnEditInfo.Enabled = false;
                    notebtnEditInfo.Visible = false;
                    notebtnNewInfo.Enabled = false;
                    notebtnNewInfo.Visible = false;
                    notebtnInfoNode.Enabled = false;
                    notebtnInfoNode.Visible = false;
                    notebtnSaveInfo.Enabled = false;
                    notebtnSaveInfo.Visible = false;
                    notedrpInfoTypes.Enabled = false;
                    notedrpInfoTypes.Visible = false;
                    notelbxInfo.Enabled = false;
                    notelbxInfo.Visible = false;
                    //notelblPercentReduction.Visible = false;
                    break;
                case "BrowseInfo":
                    // Disable save button
                    notebtnSaveInfo.Enabled = false;
                    notebtnSaveInfo.ImageUrl = "images/Icons/Save_Disabled.png";
                    notebtnSaveInfo.Visible = true;
                    // Enable edit button
                    notebtnEditInfo.Enabled = true;
                    notebtnEditInfo.Visible = true;
                    // Disable Search 
                    notebtnSearch.Enabled = false;
                    notelbxKeys.Enabled = false;
                    // Disable Add Key Word
                    notebtnAddKeyWord.Enabled = false;
                    notetxtKeyWord.Enabled = false;
                    notetxtKeyWord.Text = "";
                    // Disable Text Operations
                    notedrpTxtOpr.Enabled = false;
                    notetxtNodeText.Visible = true;
                    notebtnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
                    notebtnBackOut.Enabled = false;
                    notebtnGo.ImageUrl = "images/Icons/Go_Disabled.png";
                    notebtnGo.Enabled = false;
                    //Enable Picture Tools
                    notefilUpload.Enabled = true;
                    notetxtPictureTitle.Enabled = true;
                    notetxtPictureTitle.Text = "";
                    notedrpPictureType.Enabled = true;
                    notebtnSavePicture.Enabled = true;
                    notebtnSavePicture.ImageUrl = "images/Icons/Save.png";
                    // Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                    notebtnNewSummary.Enabled = false;
                    notebtnNewSummary.Visible = false;
                    // Buttons dependent on Node or Info Mode
                    noterdoNotes.Checked = false;
                    noterdoInfo.Checked = true;
                    notelblNoteTools.Visible = false;
                    notelblInfoTools.Visible = true;
                    notebtnRefresh.Enabled = false;
                    notebtnRefresh.Visible = false;
                    notebtnRefreshInfo.Enabled = true;
                    notebtnRefreshInfo.Visible = true;
                    notebtnEdit.Enabled = false;
                    notebtnEdit.Visible = false;
                    notebtnNew.Enabled = false;
                    notebtnNew.Visible = false;
                    notebtnNewInfo.Enabled = true;
                    notebtnNewInfo.Visible = true;
                    notebtnNewChild.Enabled = false;
                    notebtnNewChild.Visible = false;
                    notebtnInfoNode.Enabled = true;
                    notebtnInfoNode.Visible = true;
                    notebtnSave.Enabled = false;
                    notebtnSave.Visible = false;
                    notebtnUp.Enabled = false;
                    notebtnUp.Visible = false;
                    notebtnDown.Enabled = false;
                    notebtnDown.Visible = false;
                    notedrpInfoTypes.Enabled = true;
                    notedrpInfoTypes.Visible = true;
                    notelbxNodes.Enabled = false;
                    notelbxNodes.Visible = false;
                    notelbxInfo.Enabled = true;
                    notelbxInfo.Visible = true;
                    //Set to Browse Mode i.e. default to no updates
                    SetReadOnly(true);
                    break;
                case "New":
                    //Enable Text Operations (prior to Saving)
                    notedrpTxtOpr.Enabled = true;
                    // New Nodes dont have pictures so disabled everything related to pictures (until Save)
                    this.HasPicture = false;
                    notePicture.Visible = false;
                    notebtnNextPicture.Enabled = false;
                    notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                    notebtnPrevPicture.Enabled = false;
                    notebtnPrevPicture.ImageUrl = "images/Icons/Back_Disabled.png";
                    notefilUpload.Enabled = false;
                    notetxtPictureTitle.Enabled = false;
                    notetxtPictureTitle.Text = "";
                    notedrpPictureType.Enabled = false;
                    notebtnSavePicture.Enabled = false;
                    notebtnSavePicture.ImageUrl = "images/Icons/Save_Disabled.png";
                    // New Notes wont have Summaries yet
                    this.HasSummary = false;
                    notetxtSummText.Visible = false;
                    noterdoSmallSumm.Checked = false;
                    noterdoLargeSumm.Checked = false;
                    noterdoLargestSumm.Checked = false;
                    notedrpSummaries.Enabled = false;
                    notebtnNewSummary.Enabled = false;
                    notebtnNewSummary.Visible = false;
                    notebtnSaveSummary.Enabled = false;
                    notebtnSaveSummary.ImageUrl = "images/Icons/Save_Disabled.png";
                    break;
                case "NewInfo":
                    // Keep Save button disabled until InfoType drop down item selected 
                    // (easy to forget and everything will be default Info Type)
                    notebtnSaveInfo.Enabled = false;
                    notebtnSaveInfo.ImageUrl = "images/Icons/Save_Disabled.png";
                    // Disable edit button
                    notebtnEditInfo.Enabled = false;
                    // Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved)
                    notebtnSearch.Enabled = false;
                    notelbxKeys.Enabled = false;
                    // Disable Add Key Word (cant add Key Word until node is saved)
                    notebtnAddKeyWord.Enabled = false;
                    notetxtKeyWord.Enabled = false;
                    notetxtKeyWord.Text = "";
                    //Enable Text Operations (prior to Saving)
                    notedrpTxtOpr.Enabled = true;
                    // Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                    notebtnNewSummary.Enabled = false;
                    notebtnNewSummary.Visible = false;
                    //Set to Browse Mode i.e. default to no updates
                    SetReadOnly(false);
                    // Havent Saved Yet
                    this.InfoSavedYet = false;
                    break;
                case "NewChild":
                    //Enable Text Operations (prior to Saving)
                    notedrpTxtOpr.Enabled = true;
                    // New Notes wont have pictures yet so disabled everything related to pictures (until Save)
                    this.HasPicture = false;
                    notePicture.Visible = false;
                    notebtnNextPicture.Enabled = false;
                    notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                    notebtnPrevPicture.Enabled = false;
                    notebtnPrevPicture.ImageUrl = "images/Icons/Back_Disabled.png";
                    notefilUpload.Enabled = false;
                    notetxtPictureTitle.Enabled = false;
                    notetxtPictureTitle.Text = "";
                    notedrpPictureType.Enabled = false;
                    notebtnSavePicture.Enabled = false;
                    // New Notes wont have Summaries yet
                    this.HasSummary = false;
                    notetxtSummText.Visible = false;
                    noterdoSmallSumm.Checked = false;
                    noterdoLargeSumm.Checked = false;
                    noterdoLargestSumm.Checked = false;
                    notedrpSummaries.Enabled = false;
                    notebtnNewSummary.Enabled = false;
                    notebtnNewSummary.Visible = false;
                    notebtnSaveSummary.Enabled = false;
                    notebtnSaveSummary.ImageUrl = "images/Icons/Save_Disabled.png";
                    break;
                case "Edit":
                    //Enable Text Operations (prior to Saving)
                    notedrpTxtOpr.Enabled = true;
                    //
                    // Note we dont disable the AddKeyWord button or Picture or Summary Tool Buttons as the node were   
                    // editing is an existing node i.e. it isnt new and unsaved, so we can successfully add a key word, 
                    // Picture or Summary to the node while were editing it even if we dont save our editing changes
                    //
                    break;
                case "EditInfo":
                    // Enable save button
                    notebtnSaveInfo.Enabled = true;
                    notebtnSaveInfo.ImageUrl = "images/Icons/Save.png";
                    // Disable edit button
                    notebtnEditInfo.Enabled = false;
                    //Enable Text Operations (prior to Saving)
                    notedrpTxtOpr.Enabled = true;
                    //Set to Edit Mode i.e. default to allow updates
                    // Info maybe displaying a Note Summary which we want to edit however we dont want new summaries
                    notebtnNewSummary.Enabled = false;
                    notebtnNewSummary.Visible = false;
                    SetReadOnly(false);
                    //Havent Saved Yet
                    this.InfoSavedYet = false;
                    break;
            }
        }

        // Info Tools Buttons

        public void RefreshInfo()
        {
            //Subs called:- BindNodes NodeChanged
            //Properties Altered:- NodeFilter
            switch (notedrpFilterOn.SelectedItem.Text)
            {
            case "Heading":
                // Display only info with headings like that specified
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    var infos =
                        from i in db.Infoes
                        where i.Heading.Contains(notetxtFilterText.Text) == true
                        select i;
                    if (infos.Count() > 0)
                    {
                        notelbxInfo.DataSource = infos.ToList();
                        notelbxInfo.DataBind();
                    }
                }

                break;
            default:
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    var infos =
                        from i in db.Infoes
                        select i;
                    if (infos.Count() > 0)
                    {
                        notelbxInfo.DataSource = infos.ToList();
                        notelbxInfo.DataBind();
                    }
                }
                break;
            }
        }

        public void EditInfo()
        {
            //Subs called:- InitPage 
            //Properties Altered:- None
            // Note page is already displayed so dont need to call DisplayNode
            InitPage("EditInfo");
        }

        public void NewInfo()
        {
            //Subs called:- InitPage DisplayNewNode
            //Properties Altered:- None
            DisplayNewInfo();
            InitPage("NewInfo");
        }

        public void BackToInfoNode()
        {
            this.RestorePrevSelectedNode = this.SelectedNode;
            this.RestorePrevParentNode = this.ParentNode;
            this.RestorePrevCurrentLevel = this.CurrentLevel;
            // Set selected node to the node associated with this info
            this.SelectedNode = this.InfoNode;
            // Retrieve this node + set parent + current level
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var nodes =
                  from n in db.Nodes
                  where n.NodeID == this.InfoNode 
                  select n;
                if (nodes.Count() > 0)
                {
                    notelbxNodes.DataSource = nodes.ToList();
                    notelbxNodes.DataBind();
                }
                this.ParentNode = nodes.First().ParentNodeID;
                this.CurrentLevel = nodes.First().TreeLevel;
            }
        }

        public void BackToNodes()
        {
            //Subs called:- ResetSearch BindNodes ResetFilters NodeChanged 
            //Properties Altered:- ParentNode CurrentLevel SelectedNode 
            using (HowToDBEntities db = new HowToDBEntities())
            {
                if (this.CurrentLevel == 1)
                {
                    var nodes =
                        from n in db.Nodes
                        where n.TreeID == 2 && n.ParentNodeID == this.ParentNode
                        orderby n.Heading
                        select n;
                    if (nodes.Count() > 0)
                    {
                        notelbxNodes.DataSource = nodes.ToList();
                        notelbxNodes.DataBind();
                    }
                }
                else
                {
                    var nodes =
                        from n in db.Nodes
                        where n.TreeID == 2 && n.ParentNodeID == this.ParentNode
                        select n;
                    if (nodes.Count() > 0)
                    {
                        notelbxNodes.DataSource = nodes.ToList();
                        notelbxNodes.DataBind();
                    }
                }
                var keys =
                    (from k in db.Keys
                     where k.TreeID == 2
                     orderby k.KeyText
                     select new
                     {
                         k.KeyText
                     }).Distinct();
                if (keys.Count() > 0)
                {
                    notelbxKeys.DataSource = keys.ToList();
                    notelbxKeys.DataBind();
                }
            }
        }

        public void SaveInfo()
        {
            // Subs called:- CreateNewNode BindNodes NodeChanged BindKeys 
            // UpdateNode InitPage  
            // Properties Altered:- SavedYet SelectedNode ParentNode CurrentLevel
            // NodeFilter
            int InfoID;
            switch (this.InfoOperation)
            {
            case "NewInfo":
                //Create the new node
                InfoID = CreateNewInfo();
                // Selected Node changes to the new child
                this.SelectedInfo = InfoID;
                // New Node has been Saved
                this.InfoSavedYet = true;
                break;
            case "EditInfo":
                // Retrieve + Update the Node 
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    Info info = db.Infoes.First(i => i.InfoID == this.SelectedInfo);
                    UpdateInfo(info.InfoID);
                    // Edited Node has been Saved
                    this.InfoSavedYet = true;
                }
                break;
            }
        }

        // Text Operation Buttons

        public void TextOpSelected()
        {
            NodeTextOpr = notedrpTxtOpr.SelectedItem.Text;
            notetxtTxtSpecs.Enabled = true;
            notebtnGo.ImageUrl = "images/Icons/Go.png";
            notebtnGo.Enabled = true;
        }

        public void TextOperation()
        {
            //Subs called:- 
            //Properties Altered:-
            int noteWordsNoOf, noteLinesNoOf, noteSentencesNoOf, noteParagraphsNoOf, noteParmsNoOf, lineWidth;
            string parm;
            bool eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF, debug;
            List<string> noteWords, noteLines, noteSentences, noteParagrphs, Parms;
            List<int> noteSentenceInParagraph;
            Paragraphs noteParagraphs;
            PlainText noteOprSpecs;
            notebtnBackOut.Enabled = true;
            notebtnBackOut.ImageUrl = "images/Icons/No.png";
            this.EnableGo = true;
            notebtnGo.ImageUrl = "images/Icons/Go_Disabled.png";
            notebtnGo.Enabled = false;
            notebtnBackOut.ImageUrl = "images/Icons/No.png";
            notebtnBackOut.Enabled = true;
            notebtnSave.ImageUrl = "images/Icons/Save.png";
            notebtnSave.Enabled = true;
            NodeTextSpecs = notetxtTxtSpecs.Text;
            NodeText = notetxtNodeText.Text;
            NodeTextLength = notetxtNodeText.Text.Length;
            NodeAlteredText = "";
            NodeAlteredTextLength = 0;
            Parms = new List<string>();
            noteOprSpecs = new PlainText();
            noteOprSpecs.TheText = notetxtTxtSpecs.Text;
            noteWordsNoOf = 0;
            noteLinesNoOf = 0;
            noteSentencesNoOf = 0;
            noteParagraphsNoOf = 0;
            noteParmsNoOf = 0;
            lineWidth = 0;
            debug = false;
            if (notetxtTxtSpecs.Text == "")
            {
                lineWidth = 0;
                eliminateWhiteSpace = true;
                splitHeaders = false;
                splitOnColon = false;
                splitOnLF = false;
            }
            else
            {
                noteOprSpecs.DivideAfterChar(',', out noteParmsNoOf, ref Parms);
                lineWidth = 0;
                eliminateWhiteSpace = true;
                splitHeaders = false;
                splitOnColon = false;
                splitOnLF = false;
                if (noteParmsNoOf >= 1)
                {
                    lineWidth = (int)Int64.Parse(Parms[0]);
                }
                if (noteParmsNoOf >= 2)
                {
                    parm = Parms[1];
                    parm = parm.Substring(0, 1);
                    if (parm == "T" || parm == "t" || parm == "Y" || parm == "y")
                    {
                        debug = true;
                    }
                    else
                    {
                        debug = false;
                    }
                }
                if (noteParmsNoOf >= 3)
                {
                    parm = Parms[2];
                    parm = parm.Substring(0, 1);
                    if (parm == "T" || parm == "t" || parm == "Y" || parm == "y")
                    {
                        eliminateWhiteSpace = true;
                    }
                    else
                    {
                        eliminateWhiteSpace = false;
                    }
                }
                if (noteParmsNoOf >= 4)
                {
                    parm = Parms[3];
                    parm = parm.Substring(0, 1);
                    if (parm == "T" || parm == "t" || parm == "Y" || parm == "y")
                    {
                        splitHeaders = true;
                    }
                    else
                    {
                        splitHeaders = false;
                    }
                }
                if (noteParmsNoOf >= 5)
                {
                    parm = Parms[4];
                    parm = parm.Substring(0, 1);
                    if (parm == "T" || parm == "t" || parm == "Y" || parm == "y")
                    {
                        splitOnColon = true;
                    }
                    else
                    {
                        splitOnColon = false;
                    }
                }
                if (noteParmsNoOf >= 6)
                {
                    parm = Parms[5];
                    parm = parm.Substring(0, 1);
                    if (parm == "T" || parm == "t" || parm == "Y" || parm == "y")
                    {
                        splitOnLF = true;
                    }
                    else
                    {
                        splitOnLF = false;
                    }
                }
            }
            switch (notedrpTxtOpr.SelectedValue)
            {
                case "Format Text":
                    noteParagrphs = new List<string>();
                    noteSentences = new List<string>();
                    noteSentenceInParagraph = new List<int>();
                    noteLines = new List<string>();
                    noteParagraphs = new Paragraphs();
                    noteParagraphs.TheText = this.NodeText;
                    noteParagraphs.NoOfChars = noteParagraphs.TheText.Length;
                    noteParagraphs.Paragrphs(out noteParagraphsNoOf, ref noteParagrphs, out noteSentencesNoOf, ref noteSentences, ref noteSentenceInParagraph, out noteLinesNoOf, ref noteLines, lineWidth, debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF);
                    this.NodeAlteredText = noteParagraphs.TheAlteredText;
                    this.NodeAlteredTextLength = noteParagraphs.TheAlteredText.Length;
                    break;
                case "Words":
                    noteParagraphs = new Paragraphs();
                    noteWords = new List<string>();
                    noteParagraphs.TheText = this.NodeText;
                    noteParagraphs.NoOfChars = noteParagraphs.TheText.Length;
                    noteParagraphs.Words(noteWordsNoOf, noteWords);
                    this.NodeAlteredText = noteParagraphs.TheAlteredText;
                    this.NodeAlteredTextLength = noteParagraphs.TheAlteredText.Length;
                    break;
                case "Sentences":
                    noteOprSpecs = new PlainText();
                    noteParagraphs = new Paragraphs();
                    noteSentences = new List<string>();
                    noteSentenceInParagraph = new List<int>();
                    noteParagraphs.TheText = this.NodeText;
                    noteParagraphs.NoOfChars = noteParagraphs.TheText.Length;
                    noteParagraphs.Sentences(out noteSentencesNoOf, ref noteSentences, ref noteSentenceInParagraph, lineWidth, debug, eliminateWhiteSpace, splitOnLF);
                    this.NodeAlteredText = noteParagraphs.TheAlteredText;
                    this.NodeAlteredTextLength = noteParagraphs.TheAlteredText.Length;
                    break;
                case "Debugging Text":
                    noteParagrphs = new List<string>();
                    noteSentences = new List<string>();
                    noteSentenceInParagraph = new List<int>();
                    noteLines = new List<string>();
                    noteParagraphs = new Paragraphs();
                    lineWidth = 0;
                    debug = true;
                    eliminateWhiteSpace = true;
                    splitHeaders = false;
                    splitOnColon = false;
                    splitOnLF = false;
                    noteParagraphs.TheText = this.NodeText;
                    noteParagraphs.NoOfChars = noteParagraphs.TheText.Length;
                    noteParagraphs.Paragrphs(out noteParagraphsNoOf, ref noteParagrphs, out noteSentencesNoOf, ref noteSentences, ref noteSentenceInParagraph, out noteLinesNoOf, ref noteLines, lineWidth, debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF);
                    this.NodeAlteredText = noteParagraphs.TheAlteredText;
                    this.NodeAlteredTextLength = noteParagraphs.TheAlteredText.Length;
                    break;
                case "Sort":
                    break;
                case "Remove Column":
                    break;
            }
            notedrpTxtOpr.ClearSelection();
            notetxtNodeText.Text = NodeAlteredText;
        }

        public void BackOut()
        {
            notetxtNodeText.Visible = true;
            notetxtSummText.Visible = false;
            notetxtSummText.Enabled = false;
            notebtnNewSummary.Enabled = true;
            notebtnNewSummary.Visible = true;
            notedrpSummaries.Enabled = false;
            notelblPercentReduction.Visible = false;
            NodeAlteredText = "";
            NodeAlteredTextLength = 0;
            NodeTextSpecs = "";
            notetxtNodeText.Text = this.NodeText;
        }

        // Summary Buttons

        public void NewSummary()
        {
            //Subs called:- DisplayNewSummary DisplaySummary
            //Properties Altered:- None
            // Now has a summary
            this.HasSummary = true;
            // Control Changes
            notebtnSaveSummary.ImageUrl = "images/Icons/Save.png";
            notebtnSaveSummary.Enabled = true;
            notetxtSummText.Visible = true;
            notetxtSummText.Enabled = true;
            notetxtSummText.Height = System.Web.UI.WebControls.Unit.Percentage(90);
            notetxtSummText.Width = System.Web.UI.WebControls.Unit.Percentage(42);
            noterdoSmallSumm.Checked = false;
            noterdoSmallSumm.Enabled = true;
            noterdoLargeSumm.Checked = true;
            noterdoLargeSumm.Enabled = true;
            noterdoLargestSumm.Checked = false;
            noterdoLargestSumm.Enabled = true;
            notebtnNewSummary.Enabled = false;
            notebtnNewSummary.Visible = false;
            notedrpSummaries.Enabled = true;
            notebtnSaveSummary.Enabled = true;
            notebtnSaveSummary.ImageUrl = "images/icons/Save.png";
            notebtnBackOut.Enabled = true;
            notebtnBackOut.ImageUrl = "images/Icons/No.png";
            notebtnSave.Enabled = false;
            notebtnSave.ImageUrl = "images/Icons/Save_Disabled.png";
            notetxtNodeText.Visible = false;
            notelblPercentReduction.Visible = true;
            this.NodeText = notetxtNodeText.Text;
            this.NodeTextLength = notetxtNodeText.Text.Length;
        }

        public void SaveSummary()
        {
            //Subs called:- CreateNewSummary UpdateSummary
            //Properties Altered:- None
            // Save Summ Btn always enabled (we can edit text && click save anytime)
            notebtnSaveSummary.Enabled = true;
            notebtnSaveSummary.ImageUrl = "images/icons/Save.png";
            notetxtNodeText.Visible = true;
            notebtnNewSummary.Enabled = false;
            notedrpSummaries.Enabled = false;
            notelblPercentReduction.Visible = false;
            noterdoLargeSumm.Checked = false;
            noterdoLargeSumm.Enabled = true;
            noterdoLargestSumm.Checked = false;
            noterdoLargestSumm.Enabled = true;
            noterdoSmallSumm.Checked = true;
            noterdoSmallSumm.Enabled = true;
            notetxtSummText.Height = System.Web.UI.WebControls.Unit.Pixel(85);
            notebtnBackOut.ImageUrl = "images/Icons/No_Disabled.png";
            notebtnBackOut.Enabled = false;
            // Determine if were dealing with a new or existing summary
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var summaries =
                    from s in db.Summaries
                    where s.NodeID == this.SelectedNode 
                    select s;
                if (summaries.Count() < 1)
                {
                    CreateNewSummary();
                }
                else
                {
                    UpdateSummary(summaries.First().SummaryID);
                }
            }
        }

        // Picture Buttons

        public void PrevPicture()
        {
            //Subs called:- DisplayPicture
            //Properties Altered:- Item
            Item -= 1;
            // Disable Prev button if now at Picture 0
            if (this.Item == 0)
            {
                notebtnPrevPicture.Enabled = false;
                notebtnPrevPicture.ImageUrl = "images/Icons/Back_Disabled.png";
            }
            else
            {
                notebtnPrevPicture.Enabled = true;
                notebtnPrevPicture.ImageUrl = "images/Icons/Back.png";
            }
            // Enable Next Picture button
            notebtnNextPicture.Enabled = true;
            notebtnNextPicture.ImageUrl = "images/Icons/Forward.png";
            // Get Pictures
            using (HowToDBEntities db = new HowToDBEntities())
            {
                if (this.Mode == "Info")
                {
                    var pictures =
                        from p in db.Pictures
                        where p.InfoID == this.SelectedInfo
                        select p;
                    DisplayPicture(pictures.ToArray()[Item].Title, pictures.ToArray()[Item].Picture1);
                }
                else
                {
                    var pictures =
                        from p in db.Pictures
                        where p.NodeID == this.SelectedNode
                        select p;
                    DisplayPicture(pictures.ToArray()[Item].Title, pictures.ToArray()[Item].Picture1);
                }
            }
        }

        public void NextPicture()
        {
            //Subs called:- DisplayPicture
            //Properties Altered:- Item
            int UpperBound;
            using (HowToDBEntities db = new HowToDBEntities())
            {
                // Get Pictures
                if (this.Mode == "Info")
                {
                    var pictures =
                        from p in db.Pictures
                        where p.InfoID == this.SelectedInfo
                        select p;
                    UpperBound = pictures.Count() - 1;
                    Item += 1;
                    DisplayPicture(pictures.ToArray()[Item].Title, pictures.ToArray()[Item].Picture1);
                }
                else
                {
                    var pictures =
                        from p in db.Pictures
                        where p.NodeID == this.SelectedNode
                        select p;
                    UpperBound = pictures.Count() - 1;
                    Item += 1;
                    DisplayPicture(pictures.ToArray()[Item].Title, pictures.ToArray()[Item].Picture1);
                }
                if (Item == UpperBound)
                {
                    notebtnNextPicture.Enabled = false;
                    notebtnNextPicture.ImageUrl = "images/Icons/Forward_Disabled.png";
                }
                else
                {
                    notebtnNextPicture.Enabled = true;
                    notebtnNextPicture.ImageUrl = "images/Icons/Forward.png";
                }
                notebtnPrevPicture.Enabled = true;
                notebtnPrevPicture.ImageUrl = "images/Icons/Back.png";
            }
        }

        public void SavePicture()
        {
            //Subs called:- CreateNewPicture DisplayPicture
            //Properties Altered:- Item
            int RecordID;
            RecordID = CreateNewPicture(SelectedNode);
            if (RecordID > 0)
            {
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    Picture picture = db.Pictures.First(p => p.PictureID == RecordID);
                    DisplayPicture(picture.Title, picture.Picture1);

                }
                this.Item += 1;
                notePicture.Visible = true;
                this.HasPicture = true;
            }
            else
            {
                notetxtPictureTitle.Text = "Error: Couldnt Save Picture";
            }
        }

        // Summary Methods

        public int CreateNewSummary()
        {
            int RecordID;
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Summary s = new Summary
                {
                    NodeID = this.SelectedNode,
                    Summary1 = notetxtSummText.Text
                };

                db.Summaries.Add(s);
                db.SaveChanges();
                RecordID = s.SummaryID;
            }
            return RecordID;

        }

        public void DisplayNewSummary()
        {
            notetxtSummText.Text = "Enter Summary Here";
        }

        public void DisplaySummary(string SummaryText)
        {
            notetxtSummText.Text = SummaryText;
        }

        public void UpdateSummary(int i)
        {
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Summary summary = db.Summaries.First(s => s.SummaryID == i);
                summary.Summary1 = notetxtSummText.Text;
                db.SaveChanges();
            }
        }

        // Picture Methods

        public int CreateNewPicture(int RecordID)
        {
            int pictureNamePtr;
            pictureNamePtr = notefilUpload.PostedFile.FileName.ToString().IndexOf("images");
            if (pictureNamePtr >= 0)
            {
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    Picture p = new Picture
                    {
                        Picture1 = notefilUpload.PostedFile.FileName.ToString().Substring(pictureNamePtr),
                        Title = notetxtPictureTitle.Text,
                        TypeID = Int16.Parse(notedrpPictureType.SelectedItem.Value.ToString()),
                        PictureSize = 0,
                        DisplayAt = 0,
                        DisplayStopAt = 0,
                        InfoID = 0,
                        NodeID = RecordID
                    };
                    if (this.Mode == "Info")
                    {
                        p.InfoID = this.SelectedInfo;
                        p.NodeID = 8801;
                    }

                    db.Pictures.Add(p);
                    db.SaveChanges();
                    RecordID = p.PictureID;
                }
            }
            else
            {
                RecordID = -1;
            }
            return RecordID;
        }

        public void DisplayPicture(string Title, string Url)
        {
            string filePath;
            Bitmap img;
            notetxtPictureTitle.Text = Title;
            notePicture.ImageUrl = Url;
            filePath = "C:\\Users\\Stephen\\Documents\\My Web Apps\\Notes\\" + Url;
            img = new Bitmap(filePath);

            if (img.Size.Height > 500)
            {
                notePicture.Height = System.Web.UI.WebControls.Unit.Percentage(95);
            }
            else
            {
                notePicture.Height = img.Size.Height;
            }
            if (img.Size.Width > 650)
            {
                notePicture.Width = System.Web.UI.WebControls.Unit.Percentage(42);
            }
            else
            {
                notePicture.Width = img.Size.Width;
            }
            img.Dispose();
        }

        // Info Methods

        public int CreateNewInfo()
        {
            int RecordID;
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Info i = new Info
                {
                    TreeID = (short)this.CurrentTree,
                    NodeID = this.SelectedNode,
                    TypeID = this.InfoType,
                    Heading = notetxtHeading.Text,
                    InfoText = notetxtNodeText.Text
                };

                db.Infoes.Add(i);
                db.SaveChanges();
                RecordID = i.InfoID;
            }
            return RecordID;
        }

        public void DisplayNewInfo()
        {
            notetxtHeading.Text = "Enter Heading Here";
            notetxtNodeText.Text = "Enter Text Here";
        }

        public void DisplayInfo(string Heading, string InfoText)
        {
            notetxtHeading.Text = Heading;
            notetxtNodeText.Text = InfoText;
        }

        public void DisplayNoInfoFound()
        {
            notetxtHeading.Text = "No Info Satisfies Filter";
            notetxtNodeText.Text = "Filter Reset";
            notetxtFilterText.Text = "";
            notedrpFilterOn.SelectedIndex = 0;
        }

        public void UpdateInfo(int i)
        {
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Info info = db.Infoes.First(inf => inf.InfoID == i);
                info.Heading = notetxtHeading.Text;
                info.InfoText = notetxtNodeText.Text;
                db.SaveChanges();
            }
        }

        public void SpanBranch(ref string Summaries, int Node, ref int ChapterSummNode)
        {
            string Heading;
            int i, nodePtr;
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Node node = db.Nodes.First(n => n.NodeID == Node);
                Heading = node.Heading;
                if (Heading == "Chapter Summary")
                {
                    ChapterSummNode = Node;
                }
                else
                {
                    Heading = Heading.ToUpper();
                }
                Heading += " " + (Char)13 + (Char)10;
                var summaries = from s in db.Summaries
                    where s.NodeID == Node
                    select s;
                if (summaries.Count() > 0)
                {
                    if (summaries.First().Summary1.Substring(0, 9) == "Summary: ")
                    {
                        Summaries += Heading + summaries.First().Summary1.Substring((summaries.First().Summary1.IndexOf((Char)10) + 1));
                    }
                    else
                    {
                        Summaries += Heading + summaries.First().Summary1;
                    }
                }
                var nodes = from n in db.Nodes
                    where n.ParentNodeID == Node
                    select n;
                if (nodes.Count() > 0)
                {
                    for (int ptr = 0; ptr <= nodes.Count() - 1; ptr++)
                    {
                        nodePtr = nodes.ToArray()[ptr].NodeID;
                        SpanBranch(ref Summaries, nodePtr, ref ChapterSummNode);
                    }
                }
            }
        }

        public void ChapterSummary()
        {
            string Summaries;
            int RecordID, ChapterSummNode, nodePtr;
            RecordID = -1;
            Summaries = "";
            ChapterSummNode = -1;
            nodePtr = this.SelectedNode;
            this.SpanBranch(ref Summaries, nodePtr, ref ChapterSummNode);
            using (HowToDBEntities db = new HowToDBEntities())
            {
                if (ChapterSummNode != -1)
                {
                    Node node = db.Nodes.First(n => n.NodeID == ChapterSummNode);
                    node.Heading = "Chapter Summary";
                    node.NodeText = Summaries;
                    db.SaveChanges();
                }
                else
                {
                    // Create the new node
                    Node n = new Node
                    {
                        TreeID = 2,
                        TypeID = 5,
                        TreeLevel = (short)(this.CurrentLevel + 1),
                        ParentNodeID = this.SelectedNode,
                        Heading = "Chapter Summary",
                        NodeText = Summaries
                    };

                    db.Nodes.Add(n);
                    db.SaveChanges();
                    RecordID = n.NodeID;
                }
                // Selected Node becomes Parent
                this.ParentNode = this.SelectedNode;
                // Going down a level
                this.CurrentLevel = this.CurrentLevel + 1;
                // Get 1st child
                Node node1 = db.Nodes.First(n => n.NodeID == this.ParentNode);
                // the new selected node
                if (ChapterSummNode != -1)
                {
                    this.SelectedNode = ChapterSummNode;
                }
                else
                {
                    this.SelectedNode = RecordID;
                }
            }
        }

    }
}