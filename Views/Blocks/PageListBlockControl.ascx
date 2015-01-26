<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PageListBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.PageListBlockControl" %>
<%@ Register src="../Shared/PageList.ascx" tagPrefix="UC" tagName="PageList" %>

<EPiServer:Property PropertyName="PageListHeading" CustomTagName="h2" runat="server" />        
<hr />

<UC:PageList ID="PageList" runat="server" />