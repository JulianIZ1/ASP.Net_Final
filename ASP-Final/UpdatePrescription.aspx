<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePrescription.aspx.cs" Inherits="ASP_Final.UpdatePrescription" %>
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
        <div class="navbar verticalCenter" align="right" style="background-color:black">
            <img src="Images/logo2.png" class="logo"/>
            <a href="Dashboard.aspx">Dashboard</a>
            <a href="" class="active">Prescriptions</a>
            <a href="ViewPhysicians.aspx">Doctors</a>
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
            <td>*******All fields are required*******</td>
            <td class="auto-style2">Physician ID:</td>
            <td>
                <asp:Label ID="lblPrescriptionID" runat="server" Text="Prescription ID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Medication Name:</td>
            <td>
                <asp:TextBox ID="txtMedicationName" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required." Text="Required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtMedicationName" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Refill Amount:</td>
            <td>
                <asp:TextBox ID="txtRefillAmt" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required." Text="Required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtRefillAmt" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Refill Date:</td>
            <td>
                <asp:Label ID="lblRefillDate" style="width:90%;" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Dosage:</td>
            <td>
                <asp:TextBox ID="txtDosage" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required." Text="Required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtDosage" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Intake Method:</td>
            <td>
                <asp:TextBox ID="txtIntakeMethod" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required." Text="Required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtIntakeMethod" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Frequency:</td>
            <td>
                <asp:TextBox ID="txtFrequency" style="width:90%;" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required." Text="Required." ValidationExpression = "^[\s\S]{1,}$" ControlToValidate="txtFrequency" EnableClientScript="false" ValidationGroup="firstGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
       <tr>
            <td class="auto-style2">*Patient ID:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" style="width:80%;" runat="server"></asp:DropDownList>
                <br />               
                <asp:Label ID="lblPatID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">*Physician ID:</td>
            <td>
                <asp:DropDownList ID="DropDownList2" style="width:80%;" runat="server"></asp:DropDownList>
                <br />
                <asp:Label ID="lblPhyID" runat="server" Text=""></asp:Label>                
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
