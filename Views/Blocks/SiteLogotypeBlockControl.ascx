<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SiteLogotypeBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.SiteLogotypeBlockControl" %>

<a href="<%# PageReference.StartPage.GetPage().LinkURL %>" title="<%# CurrentBlock.SiteLogotypeTitle %>" id="logo" runat="server">
    <img src="<%# LogotypeUrl %>" alt="<%# CurrentBlock.SiteLogotypeTitle %>" runat="server" />
</a>
