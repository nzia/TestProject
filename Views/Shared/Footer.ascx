<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Footer.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Shared.Footer" %>

<div class="row">
    <div class="span12 footer">
        <hr />
        <div class="row">
            <EPiServer:PageList PageLink="<%# PageReference.StartPage %>" OnFilter="FilterProductPages" ID="Products" runat="server">
                
                <HeaderTemplate>
                <div class="span3">
                    <h3><EPiServer:Translate Text="/footer/products" runat="server"/></h3>
                    <ul>                    
                </HeaderTemplate>
                
                <ItemTemplate>
                    <li><EPiServer:Property PropertyName="PageLink" runat="server"/></li>
                </ItemTemplate>
                
                <FooterTemplate>
                    </ul>
                </div>                    
                </FooterTemplate>

            </EPiServer:PageList>

            <EPiServer:PageList PageLink="<%# StartPage.CompanyInformationPageLink %>" EnableVisibleInMenu="True" ID="Company" runat="server">
                
                <HeaderTemplate>
                <div class="span3">
                    <h3><EPiServer:Translate Text="/footer/company" runat="server" /></h3>
                    <ul>
                        <li><EPiServer:Property PropertyName="PageLink" PageLink="<%# StartPage.CompanyInformationPageLink %>" runat="server"/></li>                    
                </HeaderTemplate>
                
                <ItemTemplate>
                    <li><EPiServer:Property PropertyName="PageLink" runat="server"/></li>
                </ItemTemplate>
                
                <FooterTemplate>
                    </ul>
                </div>                    
                </FooterTemplate>

            </EPiServer:PageList>

            <EPiServer:PageList PageLink="<%# StartPage.NewsPageLink %>" ID="News" runat="server">
                
                <HeaderTemplate>
                <div class="span3">
                    <h3><EPiServer:Translate Text="/footer/news" runat="server" /></h3>
                    <ul>
                </HeaderTemplate>
                
                <ItemTemplate>
                    <li><EPiServer:Property PropertyName="PageLink" runat="server"/></li>
                </ItemTemplate>
                
                <FooterTemplate>
                    </ul>
                </div>                    
                </FooterTemplate>

            </EPiServer:PageList>

            <EPiServer:PageList PageLink="<%# StartPage.CustomerZonePageLink %>" ID="CustomerZone" runat="server">
                
                <HeaderTemplate>
                <div class="span3">
                    <h3><EPiServer:Translate Text="/footer/customerzone" runat="server" /></h3>
                    <ul>
                </HeaderTemplate>
                
                <ItemTemplate>
                    <li><EPiServer:Property PropertyName="PageLink" runat="server"/></li>
                </ItemTemplate>
                
                <FooterTemplate>
                        <asp:LoginView runat="server">
                            <AnonymousTemplate>
                                <a href="<%# FormsAuthentication.LoginUrl %>?ReturnUrl=<%= CurrentPage.LinkURL %>"><%# Translate("/footer/login") %></a>
                            </AnonymousTemplate>
                            <LoggedInTemplate>
                                <asp:LinkButton Text='<%# Translate("/footer/logout") %>' OnClick="Logout" runat="server" />
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </ul>
                </div>                    
                </FooterTemplate>

            </EPiServer:PageList>
        </div>                                    
    </div>
</div>