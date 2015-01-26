<%@ Page Language="C#" MasterPageFile="~/Views/MasterPages/TwoPlusOne.master" Codebehind="SearchPageTemplate.aspx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.SearchPageTemplate" %>
<%@ Import Namespace="EPiServer.Search" %>
<%@ Register src="../Shared/PageList.ascx" tagPrefix="UC" tagName="PageList" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="span8">
            <asp:Panel DefaultButton="SearchButton" runat="server">
                <asp:TextBox TabIndex="1" ID="SearchKeywords" runat="server" />
                <asp:Button Text='<%# Translate("/searchpagetemplate/searchbutton") %>' Enabled="<%# SearchSettings.Config.Active %>" CssClass="btn" TabIndex="2" OnClick="SearchClick" ID="SearchButton" runat="server" />
            </asp:Panel>
            <asp:CustomValidator ControlToValidate="SearchKeywords" Display="Dynamic" ID="SearchKeywordsValidator" ClientIDMode="Static" runat="server" />     
        </div>
    </div>
    
    <asp:PlaceHolder Visible="False" ID="SearchResultSummaryPlaceHolder" runat="server">
        <div class="row">
            <div class="span8 grayHead">
                <h2><EPiServer:Translate Text="/searchpagetemplate/result" runat="server"/></h2>
                <p><EPiServer:Translate Text="/searchpagetemplate/searchfor" runat="server"/> <i><%: SearchKeywords.Text %></i> <EPiServer:Translate Text="/searchpagetemplate/resultedin" runat="server" />&nbsp;<asp:Literal ID="NumberOfHits" runat="server" />&nbsp;<EPiServer:Translate Text="/searchpagetemplate/hits" runat="server"/>.</p>
            </div>
        </div>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder Visible="False" ID="SearchResultPlaceHolder" runat="server">
        <div class="row">
            <div class="span8 SearchResults">
                <UC:PageList IncludeIntroduction="true" MaxCount="40" ID="SearchResult" runat="server" />
            </div>
        </div>
    </asp:PlaceHolder>
            
    <EPiServer:SearchDataSource ID="SearchDataSource" runat="server" SearchFiles="True" EnableVisibleInMenu="false">
        <SelectParameters>
            <asp:ControlParameter Name="SearchQuery" ControlID="SearchKeywords" PropertyName="Text" />
        </SelectParameters>
    </EPiServer:SearchDataSource>
    
</asp:Content>
