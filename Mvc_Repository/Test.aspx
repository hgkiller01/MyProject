<%@ Page Language="C#" AutoEventWireup="true" Inherits="Test" Codebehind="Test.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/js/jquery-1.10.2.min.js"></script>
    <script src="/js/ckeditor/ckeditor.js"></script>

    <link rel="stylesheet" href="/css/colorbox.css" />    
    <script src="/js/jquery.colorbox.js"></script>
    <script src="/js/jquery.colorbox_type.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="editor1" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
        <script>
            CKEDITOR.replace('<%=editor1.ClientID%>', {
                filebrowserImageUploadUrl: 'ckeditor_fileupload.aspx',
                filebrowserImageBrowseUrl: 'ckeditor_ImageList.aspx',
                toolbar:
                [
                    { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
                    { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
                    { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
                    '/',
                    { name: 'styles', items: ['Styles', 'Format', '-', 'FontSize', '-', 'TextColor', 'BGColor'] },
                    { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
                    { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
                    { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
                    { name: 'tools', items: ['Maximize', '-', 'About'] }

                ]
            });

        </script>
    </div>

        <a class="iframe cboxElement" href="/Login.aspx" style="text-decoration: none;color:#000;font-size:12px;">登入或註冊</a>
        <a href="javascript:alert(CKEDITOR.instances.editor1.getData())">Test</a>
        TESTTTTTTTTTTTTTTTTTT<asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:GridView ID="Grid2" runat="server"></asp:GridView>
    </form>
</body>
</html>
