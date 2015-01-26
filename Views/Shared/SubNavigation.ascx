<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SubNavigation.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Shared.SubNavigation" %>

<EPiServer:MenuList PageLink="<%# TopPageLink %>" NumberOfLevels="1" runat="server">
    
    <HeaderTemplate>
        <div id="alloyDrop" class="accordion">
            <div class="accordion-group">
    </HeaderTemplate>
    
    <FooterTemplate>
            </div>
        </div>
    </FooterTemplate>
    
    <ItemTemplate>
        <div class="accordion-heading">
            <a class='<%# Container.CurrentPage.PageLink.CompareToIgnoreWorkID(CurrentPage.PageLink) ? "accordion-toggle active" : "accordion-toggle" %>' href="<%# Container.CurrentPage.LinkURL %>" data-parent="#alloyDrop"><%# HttpContext.Current.Server.HtmlEncode(Container.CurrentPage.PageName) %> <i class='<%# HasChildren(Container.CurrentPage) ? "icon-chevron-down right" : "right" %>'></i></a>
        </div>
        
        <EPiServer:PageTree PageLink="<%# Container.CurrentPage.PageLink %>" runat="server">
            
                <HeaderTemplate>
                    <div id="collapse-<%# Container.CurrentPage.PageLink.ID %>" class="accordion-body collapse <%# Container.CurrentPage == CurrentPage || CurrentPage.IsDescendantOf(Container.CurrentPage)  ? "in" : "" %>">
                        <ul>
                </HeaderTemplate>
            
                <FooterTemplate>
                        </ul>
                    </div>
                </FooterTemplate>

                <ItemTemplate>
                    <li><EPiServer:Property PropertyName="PageLink" runat="server" /></li>
                </ItemTemplate>
                
                <SelectedItemTemplate>
                    <li class="active"><EPiServer:Property PropertyName="PageLink" runat="server" /></li>
                </SelectedItemTemplate>
            
                <IndentTemplate>
                    <asp:PlaceHolder Visible="<%# Container.Indent>1 %>" runat="server">
                        <div style="height: 0px;" id="subCollapse-<%# Container.CurrentPage.ParentLink.ID %>" class="accordion-body collapse">
                            <ol>
                    </asp:PlaceHolder>
                </IndentTemplate>
            
                <UnindentTemplate>
                    <asp:PlaceHolder Visible="<%# Container.Indent>1 %>" runat="server">
                            </ol>
                        </div>
                    </asp:PlaceHolder>
                </UnindentTemplate>

            </EPiServer:PageTree>

    </ItemTemplate>

</EPiServer:MenuList>
