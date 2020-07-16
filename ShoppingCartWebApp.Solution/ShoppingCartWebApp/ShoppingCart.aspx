<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoppingCartWebApp.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="align-content-center">
        
                        <asp:Label ID="lblYourCart" runat="server" Text="Your Cart" CssClass="h2"></asp:Label>
            <asp:Label ID="lblEmptyCartPrompt" runat="server" Text="Your Cart is currently empty...." CssClass="h2" Visible="false"></asp:Label>
            <asp:GridView ID="grdCart" runat="server" AutoGenerateColumns="False" CssClass="table" OnSelectedIndexChanged="grdCart_SelectedIndexChanged">
               
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product">
                    <HeaderStyle BorderStyle="None" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="totalprice" DataFormatString="{0:C}" HeaderText="Total Price" />
               <asp:TemplateField  HeaderText="Alter Quantity">
                   <ItemTemplate>
                       <asp:TextBox ID="txtAlterQuantity" runat="server"></asp:TextBox>
                       <asp:Button ID="btnAlterQuantity" runat="server" Text="Alter Quantity" OnClick="grdCart_SelectedIndexChanged" />

                   </ItemTemplate>


               </asp:TemplateField>

               
                </Columns>
            </asp:GridView>
            
        
            <asp:Label ID="lblTotalCartAmount" runat="server" Text="TOTAL AMOUNT: " CssClass="h4"></asp:Label>
                        <asp:Label ID="lblSetTotalCartAmount" runat="server" Text="" CssClass="h4 text-danger"></asp:Label>

            <asp:Button ID="btConfirm" runat="server" Text="Confirm Order" CssClass="btn btn-primary" OnClick="btConfirm_Click" />
            <asp:Button ID="btnProductsPage" runat="server" Text="ContinueShopping" CssClass="btn btn-primary" OnClick="btnProductsPage_Click"  />
        
            </div>
    </form>
</body>
</html>
