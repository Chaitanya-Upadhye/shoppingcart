<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ShoppingCartWebApp.Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DropDownList ID="ddlSelectQuantity" runat="server"></asp:DropDownList>
    



    
    
    <asp:GridView ID="gvwProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False"  PageSize="5" OnPageIndexChanging="gvwProducts_PageIndexChanging" DataKeyNames="ProductId">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product" />
            <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" />
            <asp:BoundField DataField="CategoryName" HeaderText="Product Category" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="ProductId" Visible="False" />
            <asp:CommandField ButtonType="Button" HeaderText="ADD TO CART" SelectText="ADD TO CART" ShowSelectButton="True" />
        </Columns>

    </asp:GridView>


</asp:Content>
