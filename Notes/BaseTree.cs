using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Notes
{
    public class BaseTree
    {
        public BaseTree(
            ListBox lbxNodes,
            ListBox lbxKeys,
            DropDownList drpKeys,
            DropDownList drpFilterOn,
            TextBox txtFilterText,
            TextBox txtKeyWord,
            TextBox txtHeading,
            TextBox txtNodeText,
            TextBox txtSearchFilter,
            DropDownList drpSearchOn,
            ImageButton btnRefresh,
            ImageButton btnEdit,
            ImageButton btnNew,
            ImageButton btnNewChild,
            ImageButton btnSave,
            ImageButton btnAddKeyWord,
            ImageButton btnSearch,
            ImageButton btnSrchBack,
            ImageButton btnUp,
            ImageButton btnDown,
            ImageButton btnSummary)
        {
            treelbxNodes = lbxNodes;
            treelbxKeys = lbxKeys;
            treedrpKeys = drpKeys;
            treedrpFilterOn = drpFilterOn;
            treetxtFilterText = txtFilterText;
            treetxtKeyWord = txtKeyWord;
            treetxtHeading = txtHeading;
            treetxtNodeText = txtNodeText;
            treetxtSearchFilter = txtSearchFilter;
            treedrpSearchOn = drpSearchOn;
            treebtnRefresh = btnRefresh;
            treebtnEdit = btnEdit;
            treebtnNew = btnNew;
            treebtnNewChild = btnNewChild;
            treebtnSave = btnSave;
            treebtnAddKeyWord = btnAddKeyWord;
            treebtnSearch = btnSearch;
            treebtnSrchBack = btnSrchBack;
            treebtnUp = btnUp;
            treebtnDown = btnDown;
            treebtnSummary = btnSummary;
        }

        ListBox treelbxNodes, treelbxKeys;
        DropDownList treedrpKeys, treedrpFilterOn, treedrpSearchOn;
        TextBox treetxtFilterText, treetxtKeyWord, treetxtHeading, treetxtNodeText, treetxtSearchFilter;
        ImageButton treebtnRefresh, treebtnEdit, treebtnNew, treebtnNewChild, btnNewChild, treebtnSave, treebtnAddKeyWord, treebtnSearch, treebtnSrchBack, treebtnUp, treebtnDown, treebtnSummary;

        public int CurrentTree { get; set; }
        public int NodeType { get; set; }
        public int ParentNode { get; set; }
        public int SelectedNode { get; set; }
        public int CurrentLevel { get; set; }
        public int RestoreParentNode { get; set; }
        public int RestoreSelectedNode { get; set; }
        public int RestoreCurrentLevel { get; set; }
        public int RestorePrevParentNode { get; set; }
        public int RestorePrevSelectedNode { get; set; }
        public int RestorePrevCurrentLevel { get; set; }
        public string Operation { get; set; }
        public int Item { get; set; }
        public bool SavedYet { get; set; }
        public string SelectedKey { get; set; }
        public bool SearchDisplayed { get; set; }

        public void InitialSettings(int TreeType, int NodeType)
        {
            // Subs called :- None 
            // Properties Altered:- NodeType, CurrentTree 
            // ParentNode, SelectedNode, CurrentLevel, Item, 
            // Operation, SelectedKey 
            // 
            //The initial value of these ones vary depending on the caller 
            // 
            // There are several types of nodes: problem nodes, task nodes etc. 
            this.NodeType = NodeType;
            // Nodes are arranged into trees, i.e. a tree of problem nodes,  
            // a tree of task nodes etc this defines what sort of tree were  
            // dealing with 
            this.CurrentTree = TreeType;
            // 
            // These ones always have the same initial value independent of caller 
            // 
            // Nodes at the very top of the this. have no parents this is  
            // where we start 
            this.ParentNode = 0;
            // Start with the 1st node at the top of the tree 
            this.SelectedNode = 0;
            // Each level of the tree is numbered the top is level 1 
            this.CurrentLevel = 1;
            // Assume there are no items at this stage 
            this.Item = 0;
            // Set Operation to Browse opposed to New + Edit 
            this.Operation = "Browse";
            // Set Search Results Displayed to false 
            this.SearchDisplayed = false;
            // Start though were not in the process of Editing something 
            this.SavedYet = true;
            // Initial values for Restorse 
            this.RestoreCurrentLevel = 1;
            this.RestoreParentNode = this.ParentNode;
            this.RestoreSelectedNode = 0;
            this.RestorePrevCurrentLevel = 1;
            this.RestorePrevParentNode = this.ParentNode;
            this.RestorePrevSelectedNode = 0;
            // Dont start with a keyword search 
            this.SelectedKey = "";
        }

        public virtual void NodeChanged()
        {
            // Subs called:- InitialSettings BindNodes BindKeys InitPage  
            // DisplayNoNodeFound DisplayNode FillKeysForNode AlsoChanged 
            // Properties Altered:- Operation SelectedNode ParentNode CurrentLevel 
            string str;
            //Get Selected treelbxNodes Node 
            if (treelbxNodes.Items.Count < 1)
            {
                // if (there arent any nodes in the list box reset to initial 
                // settings and display a message saying no nodes selected 
                InitialSettings(this.CurrentTree, this.NodeType);
                DisplayNoNodeFound();
            }
            else
            {
                // if (this is a new node that's just been saved select the new  
                // node so its displayed in the nodes listbox opposed to  
                // selecting the 1st node in the list 
                // if (this is a new child just drop through to below which selects 1st item (New Child will always be 1st item) 
                if (this.Operation == "New" && this.SavedYet && this.SelectedNode > 0)
                {
                    treelbxNodes.Items.FindByValue(this.SelectedNode.ToString()).Selected = true;
                }
                if (this.Operation == "Edit" && this.SavedYet && this.SelectedNode > 0)
                {
                    treelbxNodes.Items.FindByValue(this.SelectedNode.ToString()).Selected = true;
                }
                // There are nodes in the nodes list box if (none have been selected select the 1st node 
                if (treelbxNodes.SelectedIndex < 0)
                {
                    treelbxNodes.Items[0].Selected = true;
                }
                // Given the above a node should always now be selected 
                str = treelbxNodes.SelectedValue;
                this.SelectedNode = (int)Int64.Parse(str);
                // Retrieve this node + set parent + current level 
                using (HowToDBEntities db = new HowToDBEntities())
                {
                    var nodes = from n in db.Nodes
                                where n.NodeID == this.SelectedNode
                                select n;
                    this.ParentNode = nodes.First().ParentNodeID;
                    this.CurrentLevel = nodes.First().TreeLevel;
                    // Display 1st row with this NodeID (should only be one NodeID is the Primary Key) 
                    DisplayNode(nodes.First().Heading, nodes.First().NodeText);
                    // Add keys that point to the selected node to the drop down list 
                    FillKeysForNode(this.SelectedNode);
                    // Does the Selected Node have any children? if (so enable the down Button
                    var children = from n in db.Nodes
                                where n.ParentNodeID == this.SelectedNode
                                select n;
                    if (children.Count() > 0)
                    {
                        treebtnDown.Enabled = true;
                        treebtnDown.ImageUrl = "images/Icons/Down.png";
                    }
                    else
                    {
                        treebtnDown.Enabled = false;
                        treebtnDown.ImageUrl = "images/Icons/Down_Disabled.png";
                    }
                }
                // Enable the Up button if (not at the top level 
                if (this.CurrentLevel > 1)
                {
                    treebtnUp.Enabled = true;
                    treebtnUp.ImageUrl = "images/Icons/Up.png";
                }
                else
                {
                    treebtnUp.Enabled = false;
                    treebtnUp.ImageUrl = "images/Icons/Up_Disabled.png";
                }
                // if (Displaying Search Results Disable New && NewChild Buttons 
                if (this.SearchDisplayed)
                {
                    treebtnNew.Enabled = false;
                    treebtnNewChild.Enabled = false;
                }
                else
                {
                    treebtnNew.Enabled = true;
                    treebtnNewChild.Enabled = true;
                }
                // if (at Chapter Level enable Chapter Summary Button 
                if (this.CurrentLevel == 2)
                {
                    treebtnSummary.Enabled = true;
                    treebtnSummary.Visible = true;
                }
                else
                {
                    treebtnSummary.Enabled = false;
                    treebtnSummary.Visible = false;
                }
                // Set up page in Browse Mode  
                InitPage("Browse");
            }
        }

        public void FillKeysForNode(int i)
        {
            //Subs called:- None 
            //Properties Altered:- None 
            // Add keys that point to the selected node to the drop down list 
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var keys = from k in db.Keys
                            where k.NodeID == i
                            select k;
                treedrpKeys.Items.Clear();
                if (keys.Count() < 1)
                {
                    treedrpKeys.Enabled = false;
                }
                else
                {
                    treedrpKeys.Enabled = true;
                    foreach (Key key in keys)
                    {
                        treedrpKeys.Items.Add(key.KeyText);
                    }
                }
            }
        }

        public virtual void InitPage(string TypeID)
        {
            //Subs called:- SetReadOnly 
            //Properties Altered:- Operation SavedYet 
            switch (TypeID)
            {
                case "Browse":
                    // Disable save button 
                    treebtnSave.Enabled = false;
                    treebtnSave.Visible = true;
                    treebtnSave.ImageUrl = "images/Icons/Save_Disabled.png";
                    // Enable edit button 
                    treebtnEdit.Enabled = true;
                    treebtnEdit.Visible = true;
                    // Enable Search  
                    treebtnSearch.Enabled = true;
                    treelbxKeys.Enabled = true;
                    // Enable Add Key Word 
                    treebtnAddKeyWord.Enabled = true;
                    treetxtKeyWord.Enabled = true;
                    treetxtKeyWord.Text = "";
                    // Buttons dependent on Node or Info Mode 
                    treebtnRefresh.Enabled = true;
                    treebtnRefresh.Visible = true;
                    treebtnNew.Enabled = true;
                    treebtnNew.Visible = true;
                    treebtnNewChild.Enabled = true;
                    treebtnNewChild.Visible = true;
                    treebtnUp.Visible = true;
                    treebtnDown.Visible = true;
                    treelbxNodes.Enabled = true;
                    treelbxNodes.Visible = true;
                    //Set to Browse Mode i.e. default to no updates 
                    this.Operation = "Browse";
                    SetReadOnly(true);
                    break;
                case "New":
                    // Enable Save button 
                    treebtnSave.Enabled = true;
                    treebtnSave.Visible = true;
                    treebtnSave.ImageUrl = "images/Icons/Save.png";
                    // Disable edit button 
                    treebtnEdit.Enabled = false;
                    treebtnEdit.Visible = true;
                    // Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved) 
                    treebtnSearch.Enabled = false;
                    treelbxKeys.Enabled = false;
                    // Disable Add Key Word (cant add Key Word until node is saved) 
                    treebtnAddKeyWord.Enabled = false;
                    treetxtKeyWord.Enabled = false;
                    treetxtKeyWord.Text = "";
                    //Enable Text Operations (prior to Saving) 
                    SetReadOnly(false);
                    //Not Saved Yet 
                    this.SavedYet = false;
                    break;
                case "NewChild":
                    // Enable Save button 
                    treebtnSave.Enabled = true;
                    treebtnSave.Visible = true;
                    treebtnSave.ImageUrl = "images/Icons/Save.png";
                    // Disable edit button 
                    treebtnEdit.Enabled = false;
                    // Disable Search (gets messy if SrchBack hit after Search if new node hasnt been saved) 
                    treebtnSearch.Enabled = false;
                    treelbxKeys.Enabled = false;
                    // Disable Add Key Word (cant add Key Word until node is saved) 
                    treebtnAddKeyWord.Enabled = false;
                    treetxtKeyWord.Enabled = false;
                    treetxtKeyWord.Text = "";
                    //Enable Text Operations (prior to Saving) 
                    SetReadOnly(false);
                    //Not Saved Yet 
                    this.SavedYet = false;
                    break;
                case "Edit":
                    // Enable Save button 
                    treebtnSave.Enabled = true;
                    treebtnSave.Visible = true;
                    treebtnSave.ImageUrl = "images/Icons/Save.png";
                    // Disable edit button 
                    treebtnEdit.Enabled = false;
                    treebtnEdit.Visible = true;
                    // Enable save button 
                    SetReadOnly(false);
                    //Not Saved Yet 
                    this.SavedYet = false;
                    break;
            }
        }

        public void SetReadOnly(bool RdOnly)
        {
            switch (RdOnly)
            {
                case true:
                    treetxtHeading.ReadOnly = true;
                    treetxtNodeText.ReadOnly = true;
                    break;
                case false:
                    treetxtHeading.ReadOnly = false;
                    treetxtNodeText.ReadOnly = false;
                    break;
            }
        }

        // Buttons Clicked 

        // Node Tools Buttons 

        public virtual void Refresh()
        {
            //Subs called:- BindNodes NodeChanged 
            //Properties Altered:- NodeFilter 
            switch (treedrpFilterOn.SelectedItem.Text)
            {
                case "Heading":
                    // Display only nodes with headings like that specified 
                    using (HowToDBEntities db = new HowToDBEntities())
                    {
                            var nodes =
                              from n in db.Nodes
                              where n.TreeID == 2 && n.ParentNodeID == this.ParentNode && n.Heading.Contains(treetxtFilterText.Text) == true
                              select n;
                            if (nodes.Count() > 0)
                            {
                                treelbxNodes.DataSource = nodes.ToList();
                                treelbxNodes.DataBind();
                            }
                    }
                    break;
                default:
                    // Clear the filter on nodes displayed
                    using (HowToDBEntities db = new HowToDBEntities())
                    {
                        var nodes =
                          from n in db.Nodes
                          where n.TreeID == 2 && n.ParentNodeID == this.ParentNode 
                          orderby n.Heading
                          select n;
                        if (nodes.Count() > 0)
                        {
                            treelbxNodes.DataSource = nodes.ToList();
                            treelbxNodes.DataBind();
                        }
                    }
                    break;
            }
            treetxtFilterText.Text = "";
        }


        public void Down()
        {
            //Subs called:- ResetSearch BindNodes ResetFilters NodeChanged 
            //Properties Altered:- ParentNode CurrentLevel SelectedNode 
            // Selected Node becomes Parent 
            this.ParentNode = this.SelectedNode;
            // Going down a level 
            this.CurrentLevel = this.CurrentLevel + 1;
            // Get 1st child, if (there werent any the down button would have been disabled 
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var nodes =
                  from n in db.Nodes
                  where n.TreeID == 2 && n.ParentNodeID == this.ParentNode
                  select n;
                if (nodes.Count() > 0)
                {
                    // 1st child becomes the new selected node 
                    this.SelectedNode = nodes.First().NodeID;
                    treelbxNodes.DataSource = nodes.ToList();
                    treelbxNodes.DataBind();
                }
            }
        }


        public void Up()
        {
            //Subs called:- ResetSearch BindNodes ResetFilters NodeChanged 
            //Properties Altered:- SelectedNode ParentNode CurrentLevel 
            // Parent becomes Selected Node 
            this.SelectedNode = this.ParentNode;
            // Going up a level 
            this.CurrentLevel = this.CurrentLevel - 1;
            // Get the new parent 
            using (HowToDBEntities db = new HowToDBEntities())
            {
                  Node node = db.Nodes.First(n => n.NodeID == this.SelectedNode); 
                  this.ParentNode = node.ParentNodeID;
                  if (this.CurrentLevel == 1)
                  {
                      var nodes =
                      from n in db.Nodes
                      where n.TreeID == 2 && n.ParentNodeID == this.ParentNode
                      orderby n.Heading
                      select n;
                      if (nodes.Count() > 0)
                      {
                          treelbxNodes.DataSource = nodes.ToList();
                          treelbxNodes.DataBind();
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
                          treelbxNodes.DataSource = nodes.ToList();
                          treelbxNodes.DataBind();
                      }
                  }
            }
        }

        public virtual void NewNode()
        {
            //Subs called:- InitPage DisplayNewNode 
            //Properties Altered:- None 
            DisplayNewNode();
            InitPage("New");
        }

        public virtual void NewChildNode()
        {
            //Subs called:- InitPage DisplayNewNode 
            //Properties Altered:- None 
            DisplayNewNode(); ;
            InitPage("NewChild");
        }


        public virtual void EditNode()
        {
            //Subs called:- InitPage  
            //Properties Altered:- None 
            // Note page is already displayed so dont need to call DisplayNode 
            InitPage("Edit");
        }


        public virtual void Save()
        {
            // Subs called:- CreateNewNode BindNodes NodeChanged BindKeys  
            // UpdateNode InitPage   
            // Properties Altered:- SavedYet SelectedNode ParentNode CurrentLevel 
            // NodeFilter 
            int NodeID;
            switch (this.Operation)
            {
            case "New":
                //Create the new node 
                NodeID = CreateNewNode();
                // Selected Node changes to the new child 
                this.SelectedNode = NodeID;
                // New Node hbeen Saved 
                this.SavedYet = true;
                break;
            case "NewChild":
                // the selected node becomes the new parent  
                this.ParentNode = this.SelectedNode;
                // down a level 
                this.CurrentLevel = this.CurrentLevel + 1;
                //Create the new node 
                NodeID = CreateNewNode();
                // Selected Node changes to the new child 
                this.SelectedNode = NodeID;
                // New Node hbeen Saved 
                this.SavedYet = true;
                break;
            case "Edit":
                // Retrieve + Update the Node  
                UpdateNode(this.SelectedNode);
                // Edited Node has been Saved 
                this.SavedYet = true;
                break;
            }
        }

        // Search Tools Buttons 

        public void SearchRefresh()
        {
            //Subs called:- ResetFilters InitialSettings BindNodes NodeChanged 
            //BindKeys 
            //Properties Altered:- SearchFilter
            switch (treedrpSearchOn.SelectedItem.Text)
            {
                case "Key Like":
                    // Only display keys like the string entered 
                    using (HowToDBEntities db = new HowToDBEntities())
                    {
                        var keys =
                          (from k in db.Keys
                          where k.TreeID == 2 && k.KeyText.Contains(treetxtSearchFilter.Text) == true
                          orderby k.KeyText
                          select new
                          {
                              k.KeyText
                          }).Distinct();
                        if (keys.Count() > 0)
                        {
                            treelbxKeys.DataSource = keys.ToList();
                            treelbxKeys.DataBind();
                        }
                    }
                    break;
                case "Key":
                    // Only display keys like the string entered 
                    using (HowToDBEntities db = new HowToDBEntities())
                    {
                        var keys =
                          (from k in db.Keys
                          where k.TreeID == 2 && k.KeyText == treetxtSearchFilter.Text
                          orderby k.KeyText
                          select new
                          {
                              k.KeyText
                          }).Distinct();
                        if (keys.Count() > 0)
                        {
                            treelbxKeys.DataSource = keys.ToList();
                            treelbxKeys.DataBind();
                        }
                    }
                    break;
                default:
                    // Clear the filter on nodes displayed 
                    using (HowToDBEntities db = new HowToDBEntities())
                    {
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
                            treelbxKeys.DataSource = keys.ToList();
                            treelbxKeys.DataBind();
                        }
                    }
                    break;
            }
            treetxtSearchFilter.Text = ""; 
        }

        public virtual void Search()
        {
            //Subs called:- BindNodes NodeChanged 
            //Properties Altered:- NodeSelectCmd 
            if (treebtnSrchBack.Enabled == false)
            {
                treebtnSrchBack.ImageUrl = "images/Icons/Back.png";
                treebtnSrchBack.Enabled = true;
            }
            // Only display nodes that match the keys entered 
            using (HowToDBEntities db = new HowToDBEntities())
            {
                var keys =
                    from k in db.Keys
                    where k.TreeID == 2 && k.KeyText == this.SelectedKey
                    select k;
                if (keys.Count() > 0)
                {
                    List<Node> nodes = new List<Node>();
                    foreach (var k in keys)
                    {
                        Node n = db.Nodes.Single(node => node.NodeID == k.NodeID); 
                        nodes.Add(n);                       
                    }
                    treelbxNodes.DataSource = nodes;
                    treelbxNodes.DataBind();
                }
            }

        }

        public void SrchBack()
        {
            //Subs called:- ResetSearch BindNodes ResetFilters NodeChanged 
            //Properties Altered:- ParentNode CurrentLevel SelectedNode 
            treebtnSrchBack.ImageUrl = "images/Icons/Back_Disabled.png";
            treebtnSrchBack.Enabled = false;
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
                        treelbxNodes.DataSource = nodes.ToList();
                        treelbxNodes.DataBind();
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
                        treelbxNodes.DataSource = nodes.ToList();
                        treelbxNodes.DataBind();
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
                    treelbxKeys.DataSource = keys.ToList();
                    treelbxKeys.DataBind();
                }
            }
        }

        public void AddKeyWord()
        {
            //Subs called:- CreateNewKey BindKeys 
            //Properties Altered:- None 
            // Create a new key 
            CreateNewKey(this.SelectedNode, treetxtKeyWord.Text);
        } 

        // Node Methods 

        public int CreateNewNode()
        {
            int RecordID;
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Node n = new Node
                {
                    TreeID = (short)this.CurrentTree,
                    TypeID = (short)this.NodeType,
                    TreeLevel = (short)this.CurrentLevel,
                    ParentNodeID = this.ParentNode,
                    Heading = treetxtHeading.Text,
                    NodeText = treetxtNodeText.Text
                };

                db.Nodes.Add(n);
                db.SaveChanges();
                RecordID = n.NodeID;
                if (this.CurrentLevel == 1)
                {
                    var nodes =
                        from no in db.Nodes
                        where no.TreeID == 2 && no.ParentNodeID == this.ParentNode
                        orderby no.Heading
                        select no;
                    if (nodes.Count() > 0)
                    {
                        treelbxNodes.DataSource = nodes.ToList();
                        treelbxNodes.DataBind();
                    }
                }
                else
                {
                    var nodes =
                        from no in db.Nodes
                        where no.TreeID == 2 && no.ParentNodeID == this.ParentNode
                        select no;
                    if (nodes.Count() > 0)
                    {
                        treelbxNodes.DataSource = nodes.ToList();
                        treelbxNodes.DataBind();
                    }
                }
            }
            return RecordID;
        }

        public void UpdateNode(int i)
        {
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Node node = db.Nodes.FirstOrDefault(n => n.NodeID == i);
                node.Heading = treetxtHeading.Text;
                node.NodeText = treetxtNodeText.Text;
                db.SaveChanges();
            }
        } 

        public void DisplayNoNodeFound()
        {
            treetxtHeading.Text = "No Node Satisfies Filter || Keyword Search";
            treetxtNodeText.Text = "Filter + Keyword Search Reset";
            treetxtFilterText.Text = "";
            treetxtSearchFilter.Text = "";
            treedrpFilterOn.SelectedIndex = 0;
            treedrpSearchOn.SelectedIndex = 0;
        }

        public void DisplayNode(string Heading, string NodeText)
        {
            treetxtHeading.Text = Heading;
            treetxtNodeText.Text = NodeText;
        }

        public void DisplayNewNode()
        {
            treetxtHeading.Text = "Enter Heading Here";
            treetxtNodeText.Text = "Enter Text Here";
        }

        // Key Methods 

        public int CreateNewKey(int RecordID, string Key)
        {
            using (HowToDBEntities db = new HowToDBEntities())
            {
                Key k = new Key
                {
                    TreeID = (short)this.CurrentTree,
                    NodeID = RecordID,
                    TypeID = 7,
                    KeyText = Key
                };

                db.Keys.Add(k);
                db.SaveChanges();
                RecordID = k.KeyID;
                var keys =
                    (from ke in db.Keys
                     where ke.TreeID == 2
                     orderby ke.KeyText
                     select new
                     {
                         ke.KeyText
                     }).Distinct();
                if (keys.Count() > 0)
                {
                    treelbxKeys.DataSource = keys.ToList();
                    treelbxKeys.DataBind();
                }
            }
            return RecordID;
        } 

    }
}