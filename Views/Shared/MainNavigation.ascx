<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="MainNavigation.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Shared.MainNavigation" %>

<%-- We avoid the HeaderTemplate and FooterTemplate in this case since we want that markup to
     appear regardless of whether the menu contains any items. Also, we want all server controls
     to be part of the control tree to avoid having to use FindControl on the different templates --%>

<div class="alloyMenu">
    <div class="navbar">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>            
                <div class="nav-collapse">
                    <ul class="nav">
                        <li class="<%= CurrentPage.PageLink.CompareToIgnoreWorkID(PageReference.StartPage) ? "active" : string.Empty %>"><EPiServer:Property PropertyName="PageLink" PageLink="<%# PageReference.StartPage %>" ID="HomePageLink" ClientIDMode="Static" runat="server" /></li>

                        <EPiServer:MenuList PageLink="<%# PageReference.StartPage %>" ID="MainMenu" runat="server">
     
                            <ItemTemplate>
                                <li><EPiServer:Property CssClass="<%# GetThemeCssClass(Container.CurrentContent) %>" PropertyName="PageLink" runat="server" /></li>
                            </ItemTemplate>
    
                            <SelectedTemplate>
                                <li class="active"><EPiServer:Property CssClass="<%# GetThemeCssClass(Container.CurrentContent) %>" PropertyName="PageLink" runat="server" /></li>
                            </SelectedTemplate>

                        </EPiServer:MenuList>

                    </ul>
                    <div class="navbar-search pull-right">
                        <asp:Panel DefaultButton="SearchButton" runat="server">
                            <asp:TextBox CssClass="search-query" placeholder='<%# Translate("/mainnavigation/search") %>' ID="SearchKeywords" ClientIDMode="Static" runat="server" />
                            <asp:Button CssClass="searchButton" OnClick="PerformSearch" ID="SearchButton" ClientIDMode="Static" runat="server" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>