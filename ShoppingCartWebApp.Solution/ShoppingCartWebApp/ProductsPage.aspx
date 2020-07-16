<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsPage.aspx.cs" Inherits="ShoppingCartWebApp.ProductsPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/themes/ShoppingCartCSS.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.min.js"></script>
    
        <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>



     <script type="text/javascript">  
        $(document).ready(function() {  
            SearchText();  
        });  
        function SearchText() {  
            $("#txtProductName").autocomplete({  
                source: function(request, response) {  
                    $.ajax({  
                        type: "POST",  
                        contentType: "application/json; charset=utf-8",  
                        url: "ProductsPage.aspx/GetProductName",  
                        data: "{'productName':'" + document.getElementById('txtProductName').value + "'}",  
                        dataType: "json",  
                        success: function(data) {  
                            response(data.d);  
                        },  
                        error: function(result) {  
                            alert("No Match");  
                        }  
                    });  
                }  
            });  
        }  
    </script>  

</head>  
<body>

 
 


    <form id="form1" runat="server">
    <div>
           <nav class="navbar navbar-light bg-light">
  <span class="navbar-brand mb-0 h1">Products</span>
<asp:Button ID="btnShowCart" CssClass="btn btn-primary" runat="server" Text="" Visible="false" Enabled="false" />  
<asp:Button ID="btnShowCartContent" CssClass="btn btn-primary" runat="server" Text=""  OnClick="btnShowCartContent_Click" />  

</nav>
      
        <asp:ScriptManager ID="ScriptManager1" runat="server">  
</asp:ScriptManager>  

<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnShowCart"  
    CancelControlID="btnClose" BackgroundCssClass="Background">  
</cc1:ModalPopupExtender>  


<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">  
    <iframe style=" width: 350px; height: 300px;" id="irm1" src="ViewProducts.aspx" runat="server"></iframe>  
   <br/>  
    <asp:Button ID="btnClose" runat="server" Text="Close" />  
</asp:Panel>  



        <table>
            <tr>
                <td>
                <asp:Label ID="lblProductName" runat="server" Text="Product Name: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
                
            </tr>
                 <tr>
                <td>
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price: "></asp:Label></td>
               <td> <asp:DropDownList ID="ddlProductPriceRange" runat="server" AppendDataBoundItems="True">
                   <asp:ListItem Value="0">--SELECT PRICE RANGE--</asp:ListItem>
                   </asp:DropDownList> <asp:Label ID="lblSpecifyRange" runat="server" Text=" And Above "></asp:Label></td>
                     
                
            </tr>
                 <tr>
                <td>
                <asp:Label ID="lblProductRating" runat="server" Text="Product Rating: "></asp:Label></td>
               <td> <asp:DropDownList ID="ddlProductRating" runat="server" AppendDataBoundItems="True">
                   <asp:ListItem Value=" 0">--SELECT RATING--</asp:ListItem>
                   </asp:DropDownList> </td>
                
            </tr>
                 <tr>
               
                <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                
            </tr>



        </table>









    <asp:GridView ID="grdProducts" runat="server" CssClass="table table-borderles table-striped" AllowPaging="True" AutoGenerateColumns="False"  PageSize="5" OnPageIndexChanging="gvwProducts_PageIndexChanging" OnSelectedIndexChanging="gvwProducts_SelectedIndexChanging" DataKeyNames="ProductId">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Product" />
            <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" />
            <asp:BoundField DataField="CategoryName" HeaderText="Product Category" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="ProductId" Visible="False" />
            <asp:CommandField  ButtonType="Link" HeaderText="View Product" SelectText="ADD TO CART" ShowSelectButton="True" />
            <asp:BoundField DataField="ProductRating" HeaderText="Product Rating" />
        </Columns>

    </asp:GridView>

    </div>
    </form>
</body>
</html>
