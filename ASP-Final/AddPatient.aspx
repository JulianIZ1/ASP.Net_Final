﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="ASP_Final.AddPatient" %>

<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript">
        function Validate() {          
            var isValid = false;
            isValid = Page_ClientValidate('firstGroup');        
            if (isValid) {
                isValid = Page_ClientValidate('secondGroup');   
                if (isValid) {
                } else {
                    alert("Something is wrong with your data. Please check your inputs and try again.");
                }              
            } else {
                alert("Something is wrong with your data. Please check your inputs and try again.");
            }                   
            return isValid;
        }
    </script>
    <link href="main.css" rel="stylesheet" />
    <link href="StyleSheet.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true"></asp:ScriptManager>
    <div class="navbar verticalCenter" align="right" style="background-color:black" >
            <img src="Images/logo2.png" class="logo"/>
            <a href="Dashboard.aspx">Dashboard</a>
            <a href="ViewPrescriptions.aspx">Prescriptions</a>
            <a href="ViewPhysicians.aspx">Doctors</a>
            <a href="" class="active">Patients</a>
            <a href="Home.html">Logout</a>

        </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <table class="auto-style1" style="color:white; background-color:black">
        <tr>
            <td class="auto-style2">* Patient ID:</td>
            <td>
                <asp:TextBox ID="txtPatID" style="width:90%;" runat="server" ValidationGroup="a"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="firstValidator" runat="server" ErrorMessage="Must be 5 characters and begin with 'P'." Text="Must be 5 characters and begin with 'P'." ValidationExpression = "^[\s\S]{0,5}$" ControlToValidate="txtPatID" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>           
            </td>
        </tr>
        <tr>
            <td class="auto-style2">* First Name:</td>
            <td>
                <asp:TextBox ID="txtFName" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="A first name is required." Text="A first name is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtFName" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Middle Initial:</td>
            <td>
                <asp:TextBox ID="txtMidInit" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">* Last Name:</td>
            <td>
                <asp:TextBox ID="txtLName" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="A last name is required." Text="A last name is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtLName" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">* Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" style="width:90%;" runat="server">
                    <asp:ListItem>MALE</asp:ListItem>
                    <asp:ListItem>FEMALE</asp:ListItem>
                    <asp:ListItem>OTHER</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">* Date of Birth</td>
            <td>               
                <asp:TextBox ID="txtDOB" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please specify a DOB." Text="Please specify a DOB." ValidationExpression = "^[\s\S]{0,5}$" ControlToValidate="txtDOB" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
                <asp:CompareValidator
                    id="dateValidator" runat="server" 
                    Type="Date"
                    Operator="DataTypeCheck"
                    ControlToValidate="txtDOB" 
                    ErrorMessage="Please enter a valid date." ValidationGroup="secondGroup"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Street:</td>
            <td>
                <asp:TextBox ID="txtStreet" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">City:</td>
            <td>
                <asp:TextBox ID="txtCity" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">State:</td>
            <td>
                <asp:DropDownList ID="ddlState" style="width:90%;" runat="server"></asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Zip:</td>
            <td>
                <asp:TextBox ID="txtZIP" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
            
        </tr>
        <tr>
            <td class="auto-style2">Home Phone:</td>
            <td>
                <asp:TextBox ID="txtHomePhone" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Cell Phone</td>
            <td>
                <asp:TextBox ID="txtCellPhone" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailI" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailII" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailIII" style="width:90%;" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>               
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Verify Data" ValidationGroup="firstGroup" AutoPostBack="false" OnClientClick="return Validate()"/>
                <asp:Button ID="btnHidden" runat="server" Text="Update Record"/>
                <asp:Button ID="btnClose" runat="server" Text="Close"/>
                <asp:Label ID="lblDisplay" runat="server"></asp:Label>
            </td>
        </tr>
        
    </table>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 39%;
            height: 90%;
        }
        .auto-style2 {
            width: 120px;
            text-align: right;
        }
    </style>
</asp:Content>
