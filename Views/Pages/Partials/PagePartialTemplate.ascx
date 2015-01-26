<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PagePartialTemplate.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.Partials.PagePartialTemplate" %>

<div class="border">
     
    <%-- We don't link the block if the underlying page is a container page --%>
    <asp:PlaceHolder Visible="<%# CurrentData.HasTemplate() %>" runat="server">
        <a href="<%= CurrentData.LinkURL %>" title="<%= HttpUtility.HtmlAttributeEncode(CurrentData.PageName) %>">
    </asp:PlaceHolder>
        
    <%-- Wide layout --%>
    <asp:PlaceHolder runat="server" Visible="<%# Width > Global.ContentAreaWidths.HalfWidth %>">
        <div class="media">
            <div class="mediaImg">
                <EPiServer:Property PropertyName="PageImage" runat="server" />
            </div>
            <EPiServer:Property PropertyName="PageName" CustomTagName="h2" runat="server" />
            <p id="TeaserTextWide" runat="server"><%= CurrentData.TeaserText %></p><%-- Access page property directly to make use of custom property getter --%>
        </div>
    </asp:PlaceHolder>
    
    <%-- Standard layout --%>
    <asp:PlaceHolder runat="server" Visible="<%# Width <= Global.ContentAreaWidths.HalfWidth %>">
        <EPiServer:Property PropertyName="PageName" CustomTagName="h2" runat="server" />
        <p id="TeaserTextStandard" runat="server"><%= CurrentData.TeaserText %></p>
        <EPiServer:Property PropertyName="PageImage" runat="server" />
    </asp:PlaceHolder>
    
    <asp:PlaceHolder Visible="<%# CurrentData.HasTemplate() %>" runat="server">
        </a>
    </asp:PlaceHolder>

</div>