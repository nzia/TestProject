<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PageList.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Shared.PageList" %>

<EPiServer:PageList OnFilter="FilterPageList" AutoBind="False" ID="List" runat="server">

    <ItemTemplate>
        <div class="listResult <%# Container.CurrentContent is ICategorizable ? string.Join(" ", ((ICategorizable)Container.CurrentContent).GetThemeCssClassNames()) : string.Empty %>">
            <h3>
                <EPiServer:Property PropertyName="PageLink" Visible="<%# HasContentLink(Container.CurrentContent)%>" runat="server"  />
                <asp:HyperLink NavigateUrl="<%# Container.CurrentPage.LinkURL %>" Visible="<%# !HasContentLink(Container.CurrentContent) %>" Text="<%# Container.CurrentContent.Name %>" runat="server" />
            </h3>
            <p class="date" clientidmode="Static" Visible="<%# IncludePublishDate %>" runat="server"><%# Container.CurrentPage.StartPublish.ToString("d MMMM yyyy") %></p>
            <p clientidmode="Static" Visible="<%# IncludeIntroduction %>" runat="server"><%# Container.CurrentContent is SitePageData ? ((SitePageData)Container.CurrentContent).TeaserText : String.Empty %></p>
            <hr />
        </div>
    </ItemTemplate>

</EPiServer:PageList>
