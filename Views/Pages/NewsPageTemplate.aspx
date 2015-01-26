<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/LeftNavigation.master" AutoEventWireup="false" CodeBehind="NewsPageTemplate.aspx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.NewsPageTemplate" %>
<%@ Import Namespace="EPiServer.Security" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <EPiServer:Property PropertyName="PageName" CustomTagName="h1" runat="server" />
    
    <EPiServer:Property CustomTagName="p" CssClass="introduction" PropertyName="MetaDescription" runat="server" />

    <div class="row">
        <EPiServer:Property PropertyName="MainBody" CustomTagName="div" CssClass="span8 clearfix" runat="server" />
    </div>
    
    <EPiServer:Property PropertyName="NewsList" runat="server" />
    <Alloy:TemplateHint Visible="<%# PageReference.IsNullOrEmpty(CurrentPage.NewsList.PageListRoot) && CurrentPage.QueryDistinctAccess(AccessLevel.Edit) %>" ID="NoListRootMessage" runat="server">
        <EPiServer:Translate Text="/newspagetemplate/listrootempty" runat="server" />
    </Alloy:TemplateHint>
    
    <EPiServer:Property PropertyName="MainContentArea" CssClass="row equal-height" runat="server">
        <RenderSettings Tag="span8"></RenderSettings>
    </EPiServer:Property>
        
</asp:Content>