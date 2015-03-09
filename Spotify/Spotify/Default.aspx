<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Spotify.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Busqueda</h1>
        <asp:TextBox ID="txtConsulta" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <hr />
        <h2>Seleccionar un Artista</h2>
        <asp:DropDownList ID="ddlArtista" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArtista_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:GridView ID="gvInformacion" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
