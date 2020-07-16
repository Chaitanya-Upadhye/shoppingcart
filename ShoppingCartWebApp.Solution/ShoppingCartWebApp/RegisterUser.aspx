<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="ShoppingCartWebApp.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="center">
        <tr>
            <td><asp:Label ID="lblUserName" runat="server" Text="User name"></asp:Label> </td>
            <td>  <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static"></asp:TextBox>  </td>
                         <td> <asp:RequiredFieldValidator runat="server" id="lblRequireUserName" controltovalidate="txtUserName" errormessage="Enter a valid user name" /></td>

            
        </tr>
          <tr>
             <td><asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label> </td>
            <td>  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>  </td>
            <td> <asp:RequiredFieldValidator runat="server" id="lblRequiredPassword" controltovalidate="txtPassword" errormessage=" password is required" /></td>

        </tr>
          <tr>
             <td><asp:Label ID="lblConfimedPassword" runat="server" Text="Confirmed Password" ></asp:Label> </td>
            <td>  <asp:TextBox ID="txtConfirmedPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>  </td>
             <td> <asp:RequiredFieldValidator runat="server" id="lblRequiredPasswordConfirmation" controltovalidate="txtConfirmedPassword" errormessage="Confirmed Password is required" /></td>

        </tr>
          <tr>
             <td><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label> </td>
            <td>  <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static"></asp:TextBox>  </td>
        </tr>



        <tr>
             <td><asp:Label ID="lblhobbies" runat="server" Text="Select a Hobby"></asp:Label> </td>

            <td>  <asp:DropDownList ID="ddlHobbiesList" runat="server" AppendDataBoundItems="True" ClientIDMode="Static">
                <asp:ListItem Value=" ">--Select Hobby--</asp:ListItem>
                </asp:DropDownList>  </td>

        </tr>

         <tr>
            <td><asp:Label ID="lblStates" runat="server" Text="Select your State"></asp:Label> </td>

            
            <td>  <asp:DropDownList ID="ddlStatesList" runat="server" ClientIDMode="Static">
                <asp:ListItem Value=" ">--Select State--</asp:ListItem>
                </asp:DropDownList> <br /> </td>

        </tr>

          <tr>
             <td><asp:Label ID="lblFirstName" runat="server" Text="First Name" ></asp:Label> </td>
            <td>  <asp:TextBox ID="txtFirstName" runat="server" ClientIDMode="Static"></asp:TextBox>  </td>

        </tr>
          <tr>
             <td><asp:Label ID="lblLastName" runat="server" Text="Last Name" ></asp:Label> </td>
            <td>  <asp:TextBox ID="txtLastName" runat="server" ClientIDMode="Static"></asp:TextBox>  </td>

        </tr>

         <tr>
             <td><asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label> </td>
            <td>  <asp:TextBox ID="txtDateOfBirth" runat="server" ClientIDMode="Static"></asp:TextBox><br />  </td>
        </tr>

                        
       


           <tr>
               
             <td><asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" ClientIDMode="Static" /> </td>
                        <td><asp:Button ID="btnLogin" CausesValidation="false" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" /> </td>
             <td><asp:Label ID="lblRollBack" runat="server" Text="COULDNT COMMIT DATA>SOME ERROR OCCURED!" visible="false" BackColor="Red"></asp:Label></td>  
        </tr>
        


        <asp:Label ID="lblSucessMessage" runat="server" Text="User Registered Sucessfully" Visible="false"></asp:Label>


    </table>



    <table>
   

    

    </table>





 <script>
     $(function () {
         $("#txtDateOfBirth").datepicker({ dateFormat: 'dd-mm-yy' });
   });
  </script>

    <script type="text/javascript">
        $(function () {
            $("#btnRegister").click(function (e) {
                var password = $("#txtPassword").val();
                var confirmPassword = $("#txtConfirmedPassword").val();
                if (password != confirmPassword) {
                    alert("Passwords do not match.");
                    e.preventDefault();
                    return false;
                }
                return true;
            });
        });
</script>




</asp:Content>
