<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoppingCartWebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        
        
    <div class="form-control">

         <table class="center">
        <tr>
            <td><asp:Label ID="lblUserName" runat="server" Text="UserName" CssClass="form-text"></asp:Label></td>
            
             <td><asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox></td>
             <td> <asp:RequiredFieldValidator runat="server" id="lblReqName" controltovalidate="txtUserName" errormessage="Enter a valid user name" /></td>
           
        </tr>

        
         <tr>
                <td><asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-text"></asp:Label></td>
            
             <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td> 
               <td> <asp:RequiredFieldValidator runat="server" id="lblReqPassword" controltovalidate="txtPassword" errormessage="Please enter a valid password" /></td>


         </tr>

       
         <tr>
               <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" /></td>
                             <td><asp:Label ID="lblLoginFailed" runat="server" Text="LoginFailed" Visible="false"></asp:Label></td>

        </tr>

    </table>

    </div>


                
        

    


</asp:Content>


