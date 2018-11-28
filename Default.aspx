<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>R 'n R Books Dataset Viewer</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,700" rel="stylesheet">
</head>
<body>
    <section id="main_section">
        <h2>RNR Book Viewer</h2>
        <form id="form1" runat="server">
            <div>
                <asp:GridView ID="BooksGridView" runat="server" AllowPaging="True">
                </asp:GridView>
            </div>
        </form>
    </section>
</body>
</html>
