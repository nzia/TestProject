<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.Master" AutoEventWireup="false" CodeBehind="StartPageTemplate.aspx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.StartPageTemplate" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <EPiServer:Property PropertyName="MainContentArea" CssClass="row equal-height" runat="server">
        <RenderSettings Tag="span12" />
    </EPiServer:Property>

</asp:Content>
