<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="BlockPreview.aspx.cs" MasterPageFile="~/Views/MasterPages/Site.master" Inherits="EPiServer.Templates.Alloy.Views.Blocks.BlockPreview" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    
    <Alloy:TemplateHint ID="FullWidthPreviewPropertyHint" runat="server">This preview shows the block '<%= CurrentData != null ? CurrentData.Name : string.Empty %>' when rendered in full width</Alloy:TemplateHint>
    <EPiServer:Property CssClass="row preview" ID="FullWidthPreviewProperty" runat="server">
        <RenderSettings Tag="span12" EnableEditFeaturesForChildren="true" />
    </EPiServer:Property>
    
    <Alloy:TemplateHint ID="TwoThirdsWidthPreviewPropertyHint" runat="server"><%= TwoThirdsWidthPreviewProperty.Controls[0].Controls.Count > 0 ? string.Format("This preview shows the block '{0}' when rendered in two thirds width", CurrentData.Name) : string.Format("The block '{0}' can only be displayed in full width content areas", CurrentData.Name)%></Alloy:TemplateHint>
    <EPiServer:Property CssClass="row preview" ID="TwoThirdsWidthPreviewProperty" runat="server">
        <RenderSettings Tag="span8" EnableEditFeaturesForChildren="true" />
    </EPiServer:Property>
    
    <Alloy:TemplateHint Visible="<%# TwoThirdsWidthPreviewProperty.Controls[0].Controls.Count > 0 %>" ID="HalfWidthPreviewPropertyHint" runat="server"><%= HalfWidthPreviewProperty.Controls[0].Controls.Count > 0 ? string.Format("This preview shows the block '{0}' when rendered in half width", CurrentData.Name) : string.Format("The block '{0}' requires at least a two thirds wide content area", CurrentData.Name)%></Alloy:TemplateHint>
    <EPiServer:Property CssClass="row preview" ID="HalfWidthPreviewProperty" runat="server">
        <RenderSettings Tag="span6" EnableEditFeaturesForChildren="true" />
    </EPiServer:Property>
    
    <Alloy:TemplateHint Visible="<%# HalfWidthPreviewProperty.Controls[0].Controls.Count > 0 %>" ID="OneThirdWidthPreviewPropertyHint" runat="server"><%= OneThirdWidthPreviewProperty.Controls[0].Controls.Count > 0 ? string.Format("This preview shows the block '{0}' when rendered in one third width", CurrentData.Name) : string.Format("The block '{0}' requires at least a half width content area", CurrentData.Name)%></Alloy:TemplateHint>
    <EPiServer:Property CssClass="row preview" ID="OneThirdWidthPreviewProperty" runat="server">
        <RenderSettings Tag="span4" EnableEditFeaturesForChildren="true" />
    </EPiServer:Property>

</asp:Content>