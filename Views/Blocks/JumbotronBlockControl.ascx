<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="JumbotronBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.JumbotronBlockControl" %>

<div class="row">
    <div class="span4 hidden-tablet hidden-phone">
        <EPiServer:Property PropertyName="JumbotronImage" runat="server" />
    </div>

    <div class="span8">
        <EPiServer:Property PropertyName="JumbotronHeading" CustomTagName="h1" CssClass="jumbotron" DisplayMissingMessage="True" runat="server" />
        <EPiServer:Property PropertyName="JumbotronSubHeading" CustomTagName="p" CssClass="subHeader" DisplayMissingMessage="True" runat="server" />
        <a class="btn-blue right" href="<%# CurrentBlock.JumbotronButtonLink %>" id="jumboLink" runat="server"><%= CurrentBlock.JumbotronButtonText %></a>
    </div>
</div>