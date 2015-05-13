<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfCliente.aspx.cs" Inherits="WebUI.wfCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 682px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="lbID" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="btIDCliente" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lbApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="tbApellido" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lbDireccion" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="tbDireccion" runat="server"></asp:TextBox>
        <p>
        <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbTelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="tbTelefono" runat="server"></asp:TextBox>
        </p>
        <p><asp:Label ID="lbGenero" runat="server" Text="Genero"></asp:Label>
            <asp:DropDownList ID="ddGenero" runat="server">
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Femenino</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p><asp:Label ID="lbCedula" runat="server" Text="Cedula"></asp:Label>
            <asp:TextBox ID="tbCedula" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbCelular" runat="server" Text="Celular"></asp:Label>
            <asp:TextBox ID="tbCelular" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbFechaNac" runat="server" Text="Fecha Nacimiento"></asp:Label>
        </p>
        <asp:Calendar ID="caFechaNac" runat="server"></asp:Calendar>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
    </form>
</body>
</html>
