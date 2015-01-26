<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.master" AutoEventWireup="false" CodeBehind="LandingPageTemplate.aspx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.LandingPageTemplate" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
    <div class="campaign-wrapper">
    <EPiServer:Property PropertyName="MainContentArea" CssClass="row equal-height" runat="server">
        <RenderSettings Tag="span12" />
    </EPiServer:Property>
    </div>
</asp:Content>
