<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="ShoppingCartWebApp.ViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-group">
    
        
        <table>
            <tr>
                <td><asp:Label ID="lblDisplayProductName" runat="server" Text="Product Name:  "></asp:Label> </td>
               <td><asp:Label ID="lblSetProductName" runat="server" Text=""></asp:Label></td>
                

            </tr>

             <tr>
                <td><asp:Label ID="lblDisplayProductPrice" runat="server" Text="Product Price:  "></asp:Label></td>
              <td><asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label></td>

            </tr>
             <tr>
                <td><asp:Label ID="lblDisplayUnitsInStock" runat="server" Text="units In Stock:  "></asp:Label></td>
                 <td><asp:Label ID="lblUnitsInStock" runat="server" Text=""></asp:Label></td>

            </tr>

                <tr>
                    <td> <asp:DropDownList ID="ddlSelectQuantity" runat="server"></asp:DropDownList>  </td>
               
                 <td><asp:Button ID="btnBuy" runat="server" Text="Add" CssClass="btn btn-primary" ClientIDMode="Static" OnClick="btnBuy_Click"  /></td>
                                     <td><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click"/></td>

                    <asp:Label ID="lblCartItems" runat="server" Text=""></asp:Label>
            </tr>
</table>

    </div>
    </form>
   
    
</body>


    


</html>
