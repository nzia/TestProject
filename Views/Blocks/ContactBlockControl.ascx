<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.ContactBlockControl" %>

<div class="contact">
    <EPiServer:Property PropertyName="ContactBlockImage" runat="server" />
    <EPiServer:Property PropertyName="ContactBlockHeading" CustomTagName="h3" runat="server" />
    <EPiServer:Property PropertyName="ContactPageLink" runat="server">
        <RenderSettings Tag="ContactBlock"></RenderSettings>
    </EPiServer:Property>
    <asp:PlaceHolder ID="ContactBlockLink" runat="server">
        <a class="btn-blue" href="<%# CurrentBlock.ContactBlockLinkUrl %>" id="Link" runat="server" ><%= CurrentBlock.ContactBlockLinkText %></a>
    </asp:PlaceHolder>
</div>