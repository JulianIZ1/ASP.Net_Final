<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePhysician.aspx.cs" Inherits="ASP_Final.UpdatePhysician" %>
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
    <div class="navbar verticalCenter" align="right" style="background-color:black">
            <img src="Images/logo2.png" class="logo"/>
            <a href="Dashboard.aspx">Dashboard</a>
            <a href="ViewPrescriptions.aspx">Prescriptions</a>
            <a href="" class="active">Doctors</a>
            <a href="ViewPatients.aspx">Patients</a>
            <a href="Home.html">Logout</a>

        </div>
      <br />
    <br />
    <br />
    <br />
    <br />
    <table class="auto-style1" style="color:white; background-color:black">
        <tr>
            <td class="auto-style2">Physician ID:</td>
            <td>
                <asp:Label ID="lblPhysicianID" runat="server" Text="Patient's ID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">First Name:</td>
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
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name:</td>
            <td>
                <asp:TextBox ID="txtLName" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="A last name is required." Text="A last name is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtLName" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" style="width:90%;" runat="server">
                    <asp:ListItem>MALE</asp:ListItem>
                    <asp:ListItem>FEMALE</asp:ListItem>
                    <asp:ListItem>OTHER</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Birth</td>
            <td>
                <asp:TextBox ID="txtDOB" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please specify a DOB." Text="Please specify a DOB." ValidationExpression = "^[\s\S]{0,5}$" ControlToValidate="txtDOB" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
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
            </td>
        </tr>
        <tr>
            <td class="auto-style2">City:</td>
            <td>
                <asp:TextBox ID="txtCity" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">State:</td>
            <td>
                <asp:DropDownList ID="ddlState" style="width:90%;" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Zip:</td>
            <td>
                <asp:TextBox ID="txtZIP" style="width:90%;" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="auto-style2">Office Phone:</td>
            <td>
                <asp:TextBox ID="txtOfficePhone" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Personal Phone</td>
            <td>
                <asp:TextBox ID="txtPersonalPhone" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailI" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Email:</td>
            <td>
                <asp:TextBox ID="txtEmailII" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Work Email:</td>
            <td>
                <asp:TextBox ID="txtWorkEmail" style="width:90%;" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Position:</td>
            <td>
                <asp:TextBox ID="txtPosition" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="A position is required." Text="A position is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtPosition" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Specialty:</td>
            <td>
                <asp:TextBox ID="txtSpecialty" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="A specialty is required." Text="A specialty is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtSpecialty" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Salary:</td>
            <td>
                <asp:TextBox ID="txtSalary" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="A salary is required." Text="A salary is required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtSalary" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>               
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Verify Data" ValidationGroup="firstGroup" AutoPostBack="false" OnClientClick="return Validate()"/>
                <asp:Button ID="btnHidden" runat="server" Text="Update Record"/>
                <asp:Button ID="btnClose" runat="server" Text="Close"/>
                <asp:Label ID="lblDisplay" runat="server" />
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
