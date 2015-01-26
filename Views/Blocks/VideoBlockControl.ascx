<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="VideoBlockControl.ascx.cs" Inherits="EPiServer.Templates.Alloy.Views.Blocks.VideoBlockControl" %>

<div class="embed" id="embed" runat="server">
    <div style="position:absolute; width: 100%; height: 100%">
        <div id="container" runat="server"></div>
    </div>

    <script type="text/javascript" src="<%# ScriptUrl %>"></script>

    <script type="text/javascript">
        jwplayer('<%# container.ClientID %>').setup({
            'file': '<%# VideoUrl %>',
            'image': '<%# PreviewImageUrl %>',
            'width': '100%',
            'height': '100%',
            'modes': [
                { type: 'html5' },
                { type: 'flash', src: "<%# PlayerUrl %>" }
            ]
        });
        jwplayer('<%# container.ClientID %>').play();
        jwplayer('<%# container.ClientID %>').pause();
    </script>
</div>