<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="App2.form" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 517px;
            height: 234px;
        }
        .auto-style2 {
            width: 189px;
        }
        .auto-style5 {
            width: 189px;
            height: 67px;
        }
        .auto-style6 {
            height: 67px;
            width: 323px;
        }
        .auto-style7 {
            width: 323px;
        }
        .auto-style8 {
            height: 67px;
        }
        .auto-style9 {
            width: 189px;
            height: 33px;
        }
        .auto-style10 {
            width: 323px;
            height: 33px;
        }
        #form1 {
            width: 517px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <div class="Header" style="color:#006699">
                <h3>EMPLOYEE REGISTRATION</h3>
                <hr />
            </div>
            <table cellspacing="1" class="auto-style1">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="IbMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Personal Id:</td>
                    <td class="auto-style9"></td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtId" runat="server" Width="98px" Height="24px" Enabled="false"></asp:TextBox>
                        <asp:Button ID="btnId" runat="server" BackColor="#006699" Font-Bold="True" ForeColor="White" Height="31px" OnClick="btnId_Click" Text="Personal Id" Width="105px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Name:</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtName" runat="server" Width="208px" Height="24px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Surname:</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtSurname" runat="server" Width="208px" Height="24px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">E-Mail:</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtEmail" runat="server" Height="24px" Width="208px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Department:</td>
                    <td class="auto-style9"></td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="DropDownListDepartment" runat="server" Height="33px" Width="216px" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="-1">Please select a department</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>Medicine</asp:ListItem>
                            <asp:ListItem>Software</asp:ListItem>
                            <asp:ListItem>Law</asp:ListItem>
                            <asp:ListItem>Civil Engineering</asp:ListItem>
                            <asp:ListItem>Artificial Intelligence</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">City:</td>
                    <td class="auto-style9"></td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtCity" runat="server" Width="208px" Height="24px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Security Number:</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtSecurityNum" runat="server" Width="98px" Height="24px" Enabled="false"></asp:TextBox>
                        <asp:Button ID="btnSecurity" runat="server" BackColor="#006699" Font-Bold="True" ForeColor="White" Height="31px" OnClick="btnSecurity_Click" Text="Security Num" Width="105px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit/Update" Font-Bold="True" Width="105px" Height="39px" BackColor="#006699" ForeColor="White" />
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Font-Bold="True" Width="105px" Height="39px" BackColor="#006699" ForeColor="White" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="3">
                        <asp:Button ID="btnPersonalList" runat="server" Font-Bold="True" Height="50px" OnClick="btnPersonalList_Click" Text="See Personal List Here" Width="330px" BackColor="#006699" ForeColor="White" />
                        <asp:Button ID="btnExcel" runat="server" BackColor="#339933" Font-Bold="True" Height="50px" Text="Export to Excel" Width="170px" ForeColor="White" OnClick="btnExcel_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gridPersonalList" runat="server" DataSourceID="SqlDataSource" Visible="False"
            AutoGenerateColumns="False" CellPadding="3" DataKeyNames="PersonalId" Width="301px" BackColor="White" BorderColor="#CCCCCC" 
            OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" BorderStyle="None" OnRowCommand="gridPersonalList_RowCommand"
            BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="PersonalId" HeaderText="PersonalId" ReadOnly="True" SortExpression="PersonalId"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="SecurityNum" HeaderText="SecurityNum" SortExpression="SecurityNum" />
                <asp:TemplateField ShowHeader="False" HeaderText="Delete Row">
                    <ItemTemplate>
                        <asp:Button ID="deleteRow" runat="server" CausesValidation="false" CommandName="DeleteRow" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" Text="Delete"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeesConnectionString %>" SelectCommand="SELECT * FROM [PersonalList]"></asp:SqlDataSource>
    </form>
</body>
</html>
