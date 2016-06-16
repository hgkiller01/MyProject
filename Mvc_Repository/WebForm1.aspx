<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Mvc_Repository.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Label runat="server" ID="label1"><span><%:abc%></span> </asp:Label>
        <asp:LinkButton runat="server" ID="ppp"><span style="color:red" ><%:abc%></span></asp:LinkButton>
    </div>
    </form>
</body>
</html>
