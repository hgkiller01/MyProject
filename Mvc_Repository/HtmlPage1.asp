<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
現在日期：<%=date%><br><hr>
現在時刻：<%=now%><br><hr>
現在時刻：<%response.write now%><br><hr>

<% for i = 1 to 5%>
<font size=<% =i%> color=#0000FF>快速掌握 Internet 技術</font><br>
<% next %>
<hr>

<%Response.write "Welcome! 歡迎光臨"%>
<hr>
<!--% Response.redirect "www.ecaa.ntu.edu.tw" %-->
</body>
</html>
