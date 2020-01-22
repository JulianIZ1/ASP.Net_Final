<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeBehind="Dashboard.aspx.cs" Inherits="ASP_Final.Dashboard" %>
<asp:Content ID="ContentPlaceHolder1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <link href="main.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="DashboardCSS.css" />
    <div class="navbar verticalCenter" align="right" style="background-color:black">
            <img src="Images/logo2.png" class="logo"/>
            <a href="" class="active">Dashboard</a>
            <a href="ViewPrescriptions.aspx">Prescriptions</a>
            <a href="ViewPhysicians.aspx">Doctors</a>
            <a href="ViewPatients.aspx">Patients</a>
            <a href="Home.html">Logout</a>

        </div>
      <br />
    <br />
    <br />
    <br />
    <br />
    <div class="mainBack">
        <div class="welcomeDiv roundBorders">
            <div class="clockDiv">
                <iframe src="http://free.timeanddate.com/clock/i6lx9lsv/n4561/fn6/fs16/fcfff/tct/pct/ftb/pa8/tt0/tw1/th1/ta1/tb4" frameborder="0" width="100%" height="100%" allowTransparency="true"></iframe>
            </div>
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" CssClass="welcomeMsg"></asp:Label>
            <div id="cont_4218ecce3bb6b06f69973c0f8000b7e5" class="weatherDiv">
                <script type="text/javascript" async src="https://www.theweather.com/wid_loader/4218ecce3bb6b06f69973c0f8000b7e5"></script>
            </div>
        </div>
        <div class="titleDiv">
            XYZ Health | Dashboard
        </div>        
        <div class="customerInfoDiv roundBorders">
            <div class="infoHeader">
                Personal Information
            </div>
            <table class="customerInfoTable">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grdStudents" AutoGenerateColumns="False" CssClass="GridView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="10">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top"  />
                        <Columns>
                            <asp:BoundField DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
                            <asp:BoundField DataField="MIDINIT" HeaderText="Middle Initial" SortExpression="MIDINIT" />
                            <asp:BoundField DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
                            <asp:BoundField HeaderText="GENDER" DataField="Gender" SortExpression="GENDER" />                                                         
                        </Columns>   
                        <EmptyDataTemplate>
                            No Records Found Matching Your Search!
                        </EmptyDataTemplate>
                    </asp:GridView>                
                </td>
            </tr>
        </table>
        </div>
        <div class="contactDiv roundBorders">
            <a id="foxyform_embed_link_942456" href=""></a>
            <script type="text/javascript">
                (function(d, t){
                    var g = d.createElement(t),
                    s = d.getElementsByTagName(t)[0];
                    g.src = "http://www.foxyform.com/js.php?id=942456&sec_hash=864e9a6dc65&width=350px";
                    s.parentNode.insertBefore(g, s);
                }(document, "script"));
            </script>
        </div>
        <div class="calendarDiv roundBorders">
            <iframe src="https://calendar.google.com/calendar/embed?height=600&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=pmh6tsa8snfv8mc2783nuvml10%40group.calendar.google.com&amp;color=%23B1440E&amp;ctz=America%2FNew_York" style="border-width:0" width="100%" height="100%" margin-top:"7%" frameborder="0" scrolling="yes"></iframe>
        </div>
        <div class="presInfoDiv roundBorders">
            <div class="infoHeader">
                Physicians
            </div>
            <table class="presInfoTable">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grdPhysicians" AutoGenerateColumns="False" CssClass="GridView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" PageSize="10">
                        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top"  />
                        <Columns>
                            <asp:BoundField DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
                            <asp:BoundField DataField="MIDINIT" HeaderText="Middle Initial" SortExpression="MIDINIT" />
                            <asp:BoundField DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
                            <asp:BoundField HeaderText="Position" DataField="Position" SortExpression="Position" />
                            <asp:BoundField HeaderText="Specialty" DataField="Specialty" SortExpression="Specialty" />                          
                        </Columns>   
                        <EmptyDataTemplate>
                            No Records Found Matching Your Search!
                        </EmptyDataTemplate>
                    </asp:GridView>                
                </td>
            </tr>
        </table>
        </div>
        <div class="callDiv roundBorders">

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>
