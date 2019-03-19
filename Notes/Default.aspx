<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="Default.aspx.cs" Inherits="Notes.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Note</title>
    <link rel="stylesheet" type="text/css" href="css/default.css"/>
    <script src="scripts/jquery-2.0.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ImgBtn").hover(handleMouseEnter, handleMouseLeave);
            function handleMouseEnter(e) {
                $(this).css("border", "medium solid teal");
            };
            function handleMouseLeave(e) {
                $(this).css("border", "");
            }
        });
    </script> 
</head>
<body id="body">
    <form id="Notes" runat="server">
        <div id="header">
        <!-- Note/Info Selection -->   
            <asp:RadioButton Style="position: absolute; top: 8px; left: 288px; " ID="rdoNotes" runat ="server" ForeColor="White" Font-Size="Medium" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" Text="Notes" GroupName="NotesInfo" Enabled="True" Checked="True" OnCheckedChanged="rdoNotes_CheckedChanged">
            </asp:RadioButton>
            <asp:RadioButton Style="position: absolute; top: 27px; left: 288px; " ID="rdoInfo" runat ="server" ForeColor="White" Font-Size="Medium" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" Text="Info" GroupName="NotesInfo" Enabled="True" OnCheckedChanged="rdoInfo_CheckedChanged">
            </asp:RadioButton>
             <asp:DropDownList Style="position: absolute; top: 48px; left: 288px; right: 1173px;" ID="drpFilterOn" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px" >
                 <asp:ListItem Value="Clear">Clear</asp:ListItem>
                 <asp:ListItem Value="Heading">Heading</asp:ListItem>
             </asp:DropDownList>
             <asp:TextBox Style="position: absolute; top: 72px; left: 288px; right: 1165px;" ID="txtFilterText" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px" Height="20px" BorderColor="White">
             </asp:TextBox>

        <!-- Key Search -->           
             <asp:Label Style="position: absolute; top: 8px; left: 568px; height: 23px;" ID="lblSearch" runat="server" ForeColor="White" Font-Size="Medium" Font-Names="Baskerville" Font-Bold="True" BackColor="Transparent">Search</asp:Label>
             <asp:Label Style="position: absolute; top: 32px; left: 568px" ID="lblSearchOn" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" BackColor="Transparent">Filter</asp:Label>
             <asp:DropDownList Style="z-index: 3; position: absolute; top: 48px; left: 568px" ID="drpSearchOn" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px">
                 <asp:ListItem Value="Clear">Clear</asp:ListItem>
                 <asp:ListItem Value="Key">Key</asp:ListItem>
                 <asp:ListItem Value="Key Like">Key Like</asp:ListItem>
             </asp:DropDownList>
             <asp:TextBox Style="position: absolute; top: 72px; left: 568px" ID="txtSearchFilter" runat="server" ForeColor="White" BackColor="#5280A0" Width="72px" Height="20px">
             </asp:TextBox>

        <!-- Note/Info Tools -->
             <asp:Label Style="position: absolute; top: 115px; left: 288px" ID="lblNoteTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent">Note Tools</asp:Label>
             <asp:Label Style="position: absolute; top: 115px; left: 288px" ID="lblInfoTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Enabled="False" Visible="False">Info Tools</asp:Label>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 370px; width: 16px;" ID="btnRefresh" runat="server" ToolTip="Refresh" ImageUrl="~/images/icons/Refresh.png" CssClass="ImgBtn" OnClick="btnRefresh_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 370px; width: 16px;" ID="btnRefreshInfo" runat="server" ToolTip="Refresh" ImageUrl="~/images/icons/Refresh.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnRefreshInfo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 390px; right: 1153px;" ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/icons/edit.png" CssClass="ImgBtn" OnClick="btnEdit_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 390px; right: 1153px;" ID="btnEditInfo" runat="server" ToolTip="Edit" ImageUrl="~/images/icons/edit.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnEditInfo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 410px; height: 16px;" ID="btnNew" runat="server" ToolTip="New" ImageUrl="~/images/icons/New.png" CssClass="ImgBtn" OnClick="btnNew_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 410px; height: 16px;" ID="btnNewInfo" runat="server" ToolTip="New" ImageUrl="~/images/icons/New.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnNewInfo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 430px;" ID="btnNewChild" runat="server" ToolTip="New Child" ImageUrl="~/images/icons/NewChild.png" CssClass="ImgBtn" OnClick="btnNewChild_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 430px;" ID="btnInfoNode" runat="server" ToolTip="Source Note" ImageUrl="~/images/icons/Back.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnInfoNode_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 140px; left: 530px;" ID="btnRestoreInfo" runat="server" ToolTip="Back To Info" ImageUrl="~/images/icons/Back.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnRestoreInfo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 450px; right: 1015px;" ID="btnGo" runat="server" ToolTip="Perform Text Operation" ImageUrl="~/images/icons/Go_Disabled.png" CssClass="ImgBtn" Enabled="False" OnClick="btnGo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 470px" ID="btnBackOut" runat="server" ToolTip="Backout Text Operation" ImageUrl="~/images/icons/No_Disabled.png" CssClass="ImgBtn" Enabled="False" OnClick="btnBackOut_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 490px; width: 16px;" ID="btnSave" runat="server" ToolTip="Save" ImageUrl="~/images/icons/Save_Disabled.png" CssClass="ImgBtn" OnClick="btnSave_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 490px" ID="btnSaveInfo" runat="server" ToolTip="Save" ImageUrl="~/images/icons/Save_Disabled.png" Enabled="False" Visible="False" CssClass="ImgBtn" OnClick="btnSaveInfo_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 510px; height: 16px;" ID="btnDown" runat="server" ToolTip="Children" ImageUrl="~/images/icons/Down.png" CssClass="ImgBtn" OnClick="btnDown_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 530px; height: 16px; width: 16px;" ID="btnUp" runat="server" ToolTip="Parent" ImageUrl="~/images/icons/Up.png" CssClass="ImgBtn" OnClick="btnUp_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 135px; left: 530px" ID="btnSummary" runat="server" ToolTip="Chapter Summary" ImageUrl="~/images/icons/Summary.png" CssClass="ImgBtn" Enabled="False" Visible="False" OnClick="btnSummary_Click">
             </asp:ImageButton>

             <asp:DropDownList Style="position: absolute; top: 136px; left: 748px;" ID="drpPage" runat="server" ForeColor="White" BackColor="#C97C7E" Width="85px" AutoPostBack="True">
                 <asp:ListItem Value="0">Stay Here</asp:ListItem>
                 <asp:ListItem Value="1">Code</asp:ListItem>
                 <asp:ListItem Value="2">Problems</asp:ListItem>
                 <asp:ListItem Value="3">How To</asp:ListItem>
                 <asp:ListItem Value="4">Tasks</asp:ListItem>
                 <asp:ListItem Value="5">Messages</asp:ListItem>
             </asp:DropDownList>  

             <asp:DropDownList Style="position: absolute; top: 136px; left: 288px;" ID="drpTxtOpr" runat="server" ForeColor="White" BackColor="#C97C7E" Width="72px" AutoPostBack="True" OnSelectedIndexChanged="drpTxtOpr_SelectedIndexChanged">
                 <asp:ListItem Value="Words">Words</asp:ListItem>
                 <asp:ListItem Value="Sentences">Sentences</asp:ListItem>
                 <asp:ListItem Value="Format Text">Format Text</asp:ListItem>
                 <asp:ListItem Value="Debugging Text">Debugging Text</asp:ListItem>
                 <asp:ListItem Value="Sort">Sort</asp:ListItem>
                 <asp:ListItem Value="Remove Column">Remove Column</asp:ListItem>
             </asp:DropDownList>  
                   
             <asp:TextBox Style="position: absolute; top: 136px; left: 366px;" ID="txtTxtSpecs" runat="server" ForeColor="White" BackColor="#C97C7E" Width="105px" Enabled="False">
             </asp:TextBox>

             <asp:DropDownList Style="position: absolute; top: 136px; left: 480px;" ID="drpInfoTypes" runat="server" ForeColor="White" BackColor="#C97C7E" Width="70px" Enabled="False" Visible="False" AutoPostBack="True" DataValueField="TypeID" DataTextField="Label" OnSelectedIndexChanged="drpInfoTypes_SelectedIndexChanged">
             </asp:DropDownList>

        <!-- Search Tools -->
             <asp:Label Style="position: absolute; top: 115px; left: 568px" ID="lblSearchTools" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Width="104px">Search Tools</asp:Label>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 665px; height: 16px;" ID="btnSearchRefresh" runat="server" ToolTip="Refresh" ImageUrl="~/images/icons/Refresh.png" CssClass="ImgBtn" OnClick="btnSearchRefresh_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 686px; height: 16px;" ID="btnSearch" runat="server" ToolTip="Search For Key" ImageUrl="~/images/icons/Search.png" CssClass="ImgBtn" OnClick="btnSearch_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 706px; height: 16px;" ID="btnSrchBack" runat="server" ToolTip="Restore after Search" ImageUrl="~/images/icons/Back_Disabled.png" Enabled="False" CssClass="ImgBtn" OnClick="btnSrchBack_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 115px; left: 728px" ID="btnAddKeyWord" runat="server" ToolTip="Add New Key" ImageUrl="~/images/icons/Keyword.png" Enabled="False" CssClass="ImgBtn" OnClick="btnAddKeyWord_Click">
             </asp:ImageButton>
             <asp:TextBox Style="position: absolute; top: 113px; left: 748px" ID="txtKeyWord" runat="server" ForeColor="White" BackColor="Transparent" Width="80px" Height="18px" ToolTip="Add Key Text" Enabled="False">
             </asp:TextBox>
 
        <!-- Summary Tools -->   
             <asp:Label Style="position: absolute; top: 170px; left: 5px" ID="lblSummary" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True">Summary: Size</asp:Label>
             <asp:RadioButton Style="position: absolute; top: 170px; left: 88px" ID="rdoSmallSumm" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False" OnCheckedChanged="rdoSmallSumm_CheckedChanged">
             </asp:RadioButton>
             <asp:RadioButton Style="position: absolute; top: 170px; left: 108px" ID="rdoLargeSumm" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False" OnCheckedChanged="rdoLargeSumm_CheckedChanged">
             </asp:RadioButton>
             <asp:RadioButton Style="position: absolute; top: 170px; left: 128px" ID="rdoLargestSumm" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" AutoPostBack="True" GroupName="Summary" Enabled="False" OnCheckedChanged="rdoLargestSumm_CheckedChanged">
             </asp:RadioButton>
             <asp:ImageButton Style="position: absolute; top: 170px; left: 150px; height: 16px;" ID="btnNewSummary" runat="server" ToolTip="New" ImageUrl="~/images/icons/New.png" CssClass="ImgBtn" OnClick="btnNewSummary_Click">
             </asp:ImageButton>
             <asp:DropDownList Style="position: absolute; top: 170px; left: 168px;" ID="drpSummaries" runat="server" AutoPostBack="True" ForeColor="White" BackColor="#C97C7E" Enabled="False" Height="18px" Width="90px">
                <asp:ListItem Value="Summary">Summary</asp:ListItem>
                <asp:ListItem Value="Comment">Comment</asp:ListItem>
                <asp:ListItem Value="Additional Info">Additional Info</asp:ListItem>
                <asp:ListItem Value="Text Refers To">Text Refers To</asp:ListItem>
                <asp:ListItem Value="Refresher On">Refresher On</asp:ListItem>
            </asp:DropDownList>
             <asp:ImageButton Style="position: absolute; top: 170px; left: 260px; height: 16px;" ID="btnSaveSummary" runat="server" ToolTip="Save Summary" ImageUrl="images/icons/Save_Disabled.png" CssClass="ImgBtn" OnClick="btnSaveSummary_Click">
             </asp:ImageButton>

        <!-- Picture Tools -->
             <asp:Label Style="position: absolute; top: 170px; left: 280px" ID="lblPictures" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent" Text="Pictures: "></asp:Label>
             <asp:ImageButton Style="position: absolute; top: 170px; left: 340px" ID="btnPrevPicture" runat="server" ToolTip="Previous Picture" ImageUrl="~/images/Icons/Back_Disabled.png" Enabled="False" CssClass="ImgBtn" OnClick="btnPrevPicture_Click">
             </asp:ImageButton>
             <asp:ImageButton Style="position: absolute; top: 170px; left: 363px" ID="btnNextPicture" runat="server" ToolTip="Next Picture" ImageUrl="~/images/Icons/Forward_Disabled.png" Enabled="False" CssClass="ImgBtn" OnClick="btnNextPicture_Click">
             </asp:ImageButton>
             <asp:Label Style="position: absolute; top: 170px; left: 390px" ID="lblAddPicture" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Garamond" Font-Bold="True" BackColor="Transparent">Add Picture</asp:Label>
             <asp:TextBox Style="position: absolute; top: 169px; left: 602px; width: 136px; height: 17px; right: 790px;" ID="txtPictureTitle" runat="server" ForeColor="White" Font-Size="Small" Font-Names="Georgia" BackColor="#C97C7E" Enabled="False">
             </asp:TextBox>
             <asp:ImageButton Style="position: absolute; top: 170px; left: 820px; " ID="btnSavePicture" runat="server" ToolTip="Save New Picture" ImageUrl="~/images/icons/Save_Disabled.png" Enabled="False" CssClass="ImgBtn" OnClick="btnSavePicture_Click">
             </asp:ImageButton>

        <!-- File Upload for Picture Tools -->
             <asp:FileUpload Style="position: absolute; width: 130px; height: 20px; top: 169px; left: 463px; " ID="filUpload" runat="server" Enabled="False" />

        <!-- Drop Down List for Keys Search -->
             <asp:DropDownList Style="position: absolute; top: 139px; left: 568px" ID="drpKeys" runat="server" ForeColor="White" BackColor="#C97C7E" Width="90px" AutoPostBack="True" >
             </asp:DropDownList>

        <!-- Picture Upload Type -->
             <asp:DropDownList Style="position: absolute; top: 168px; left: 745px;" ID="drpPictureType" runat="server" ForeColor="White" BackColor="#C97C7E" Width="70px" Enabled="False" DataValueField="TypeID" DataTextField="Label">
             </asp:DropDownList>

        <!-- Notes -->
             <asp:ListBox Style="position: absolute; top: 8px; left: 367px; " ID="lbxNodes" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" DataTextField="Heading" DataValueField="NodeID" OnSelectedIndexChanged="lbxNodes_SelectedIndexChanged">
             </asp:ListBox>

        <!-- Keys -->
            <asp:ListBox Style="position: absolute; top: 8px; left: 648px" ID="lbxKeys" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" DataTextField="KeyText" OnSelectedIndexChanged="lbxKeys_SelectedIndexChanged">
            </asp:ListBox>

        <!-- Info -->
             <asp:ListBox Style="position: absolute; top: 8px; left: 367px; " ID="lbxInfo" runat="server" ForeColor="White" BackColor="#5280A0" Width="176px" Height="90px" AutoPostBack="True" Enabled="False" Visible="False" DataTextField="Heading" DataValueField="InfoID" OnSelectedIndexChanged="lbxInfo_SelectedIndexChanged">
             </asp:ListBox>

        <!-- Note Heading -->
             <asp:TextBox Style="position: absolute; top: 115px; left: 8px" ID="txtHeading" runat="server" ForeColor="White" Font-Size="Large" Font-Names="Georgia" BackColor="#6B9396" Width="256px" TextMode="MultiLine" Height="46px" BorderColor="White">
             </asp:TextBox>

        <!-- Note Summary Text -->
             <asp:TextBox Style="position: absolute; top: 8px; left: 860px;" ID="txtSummText" runat="server" ForeColor="White" BackColor="#8EA5B6" Width="465px" Height="85" TextMode="MultiLine" Visible="False" Font-Names="Verdana" Font-Size="Small">
             </asp:TextBox>
        </div>
        <div id="content" style="overflow: scroll">
            <div id="Tree">
            </div>
            <!-- Note Text -->
            <asp:TextBox Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; height:95%; width: 54.7%; vertical-align: top;" ID="txtNodeText" runat="server" ForeColor="White" BackColor="#8EA5B6" TextMode="MultiLine" ReadOnly="True" Font-Names="Verdana" Font-Size="Medium" CssClass="NodeText">
            </asp:TextBox>

            <!-- Note Picture -->
            <asp:Image Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; vertical-align: top;" ID="Picture" runat="server" CssClass="NodePicture">
            </asp:Image>

            <!-- Summarize -->
            <asp:GridView Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; height:95%; width: 54.7%; vertical-align: top; " ID="gvSummarize" runat="server" ForeColor="White" BackColor="#8EA5B6" Font-Names="Verdana" Font-Size="Medium" CssClass="GridView" AutoGenerateColumns="False" Enabled="False" Visible="False" DataKeyNames="SentenceNo" onrowediting="gvSummarize_RowEditing" onpageindexchanging="gvSummarize_PageIndexChanging" onrowcancelingedit="gvSummarize_RowCancelingEdit" onrowupdating="gvSummarize_RowUpdating">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                    <asp:TemplateField HeaderText="Inc">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Include") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Include") %>' Enabled="False" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Paragraph" HeaderText="Pgph" ReadOnly="True"/>
                    <asp:BoundField DataField="SentenceNo" HeaderText="#" ReadOnly="True"/>
                    <asp:BoundField DataField="Sentence" HeaderText="Sentence" ReadOnly="True"/>
                </Columns>
            </asp:GridView>

            <asp:Label Style="border: 3px solid #ccc; border-bottom-color: #eee;  border-left-color: #ddd; border-top-color: #bbb; width: 54.3%; text-align: center " ID="lblPercentReduction" runat="server" ForeColor="White" BackColor="#8EA5B6" Font-Names="Verdana" Font-Size="Medium" Visible="False" Width="54.3%" Font-Bold="True"></asp:Label>
        </div>
    </form>
</body>
</html>
