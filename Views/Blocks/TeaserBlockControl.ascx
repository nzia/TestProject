<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="TeaserBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.TeaserBlockControl" %>

<%--
    Depending on how wide the teaser block is (in Bootstrap units) we render different markup
--%>

<div class="border">
    
    <%-- Link the teaser block only if a link has been set --%>
    <asp:PlaceHolder Visible="<%# !(Page is BlockPreview) && !PageReference.IsNullOrEmpty(CurrentBlock.TeaserLink) %>" runat="server">
        <a href='<%= !PageReference.IsNullOrEmpty(CurrentBlock.TeaserLink) ? CurrentBlock.TeaserLink.GetPage().LinkURL : "#" %>' title="<%= CurrentBlock.TeaserHeading %>">
    </asp:PlaceHolder>
        
        <%-- Wide layout --%>
        <asp:PlaceHolder runat="server" Visible="<%# Width > Global.ContentAreaWidths.HalfWidth %>">
        <div class="media">
            <div class="mediaImg">
                <EPiServer:Property PropertyName="TeaserImage" runat="server"/>
            </div>
            <div class="mediaText">
                <EPiServer:Property PropertyName="TeaserHeading" CustomTagName="h2" runat="server"/>
                <EPiServer:Property PropertyName="TeaserText" CustomTagName="p" runat="server"/>
            </div>
        </div>
        </asp:PlaceHolder>  
        
        <%-- Standard layout --%>
        <asp:PlaceHolder runat="server" Visible="<%# Width <= Global.ContentAreaWidths.HalfWidth %>">
            <EPiServer:Property PropertyName="TeaserHeading" CustomTagName="h2" runat="server"/>
            <EPiServer:Property PropertyName="TeaserText" CustomTagName="p" runat="server"/>
            <EPiServer:Property PropertyName="TeaserImage" runat="server"/>
        </asp:PlaceHolder>
    
    <asp:PlaceHolder Visible="<%# !(Page is BlockPreview) && !PageReference.IsNullOrEmpty(CurrentBlock.TeaserLink) %>" runat="server">    
        </a>
    </asp:PlaceHolder>

</div>
