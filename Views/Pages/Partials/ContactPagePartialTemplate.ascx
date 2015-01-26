<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactPagePartialTemplate.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Pages.Partials.ContactPagePartialTemplate" %>

<div class="border">
    
    <%-- Wide layout --%>
    <asp:PlaceHolder runat="server" Visible="<%# Width > Global.ContentAreaWidths.HalfWidth %>">
        <div class="media">
            <div class="mediaImg">
                <EPiServer:Property PropertyName="PageImage" runat="server" />
            </div>
            <div class="mediaText">
                <EPiServer:Property PropertyName="PageName" CustomTagName="h2" runat="server" />
                <EPiServer:Property PropertyName="TeaserText" CustomTagName="p" runat="server" />
                <p>
                    <%= Translate("/contact/email") %>: <a href="mailto:<%= CurrentData.Email %>"><%= CurrentData.Email %></a><br />
                    <%= Translate("/contact/phone") %>: <%= CurrentData.Phone %>
                </p>
            </div>
        </div>
    </asp:PlaceHolder>
    
    <%-- Standard layout --%>
    <asp:PlaceHolder runat="server" Visible="<%# Width <= Global.ContentAreaWidths.HalfWidth %>">
        <EPiServer:Property PropertyName="PageImage" runat="server" />
        <EPiServer:Property PropertyName="PageName" CustomTagName="h2" runat="server" />
        <EPiServer:Property PropertyName="TeaserText" CustomTagName="p" runat="server" />
        <p>
            <%= Translate("/contact/email") %>: <a href="mailto:<%= CurrentData.Email %>"><%= CurrentData.Email %></a><br />
            <%= Translate("/contact/phone") %>: <%= CurrentData.Phone %>
        </p>
    </asp:PlaceHolder>

</div>