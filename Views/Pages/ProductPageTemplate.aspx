<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/TwoPlusOne.Master" AutoEventWireup="false" CodeBehind="ProductPageTemplate.aspx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.ProductPageTemplate" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <EPiServer:Property CustomTagName="h1" PropertyName="PageName" runat="server" />
    
    <EPiServer:Property CustomTagName="p" CssClass="introduction" PropertyName="MetaDescription" runat="server" />
    
    <div class="row">
        <EPiServer:Property PropertyName="MainBody" CustomTagName="div" CssClass="span8 clearfix" runat="server" />
    </div>
    
    <EPiServer:Property PropertyName="MainContentArea" CssClass="row equal-height" runat="server">
        <RenderSettings Tag="span8" />
    </EPiServer:Property>

</asp:Content>

<asp:Content ContentPlaceHolderID="RelatedContent" runat="server">
                
    <div>
        <EPiServer:Property PropertyName="PageImage" runat="server" />
    </div>

    <div class='block colorBox' id="UniqueSellingPointsContainer" runat="server">
        <EPiServer:Property PropertyName="PageName" Runat="server" CustomTagName="h2" />
        <EPiServer:Property PropertyName="UniqueSellingPoints" runat="server" CustomTagName="div" />
    </div>

    <EPiServer:Property PropertyName="RelatedContentArea" CssClass="row" runat="server">
        <RenderSettings Tag="span4" />
    </EPiServer:Property>

</asp:Content>