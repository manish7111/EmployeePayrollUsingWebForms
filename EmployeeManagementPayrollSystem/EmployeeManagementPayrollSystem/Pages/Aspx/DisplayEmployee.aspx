<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayEmployee.aspx.cs" Inherits="EmployeeManagementPayrollSystem.Pages.Aspx.DisplayEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

    <html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Employee payroll form</title>
        <link rel="stylesheet" href="../css/home.css">
        <link
            href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,600;1,500&display=swap"
            rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;600&display=swap" rel="stylesheet">
    </head>

    <body>
        
        <div class="flex-column content">
            <div class="emp-detail">
                <div class="detail-text">
                    Employee Details 
                </div>
                <a href="RegisterEmployee.aspx" class="add-button flex-row-center">
                    <img src="../assets/icons/add-24px.svg" alt="">
                    Add User</a>

            </div>
            <div runat="server">
                <div class="table-main">
                    <asp:GridView ID="GridView" class="gridView" runat="server" Width="99%"
                        DataKeyNames="EmpId"
                        AutoGenerateColumns="false" ForeColor="#333333"
                        GridLines="None" OnRowCommand="GridView_RowCommand">
                        <HeaderStyle BackColor="lightgrey" />
                        <RowStyle BackColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Image ID="Profile" runat="server"
                                        src='<%# Eval("ProfileImage").ToString()=="../Assets/Ellipse -8"?"../Assets/Ellipse -8.png":
                                            Eval("ProfileImage").ToString()=="../Assets/Ellipse -7"?"../Assets/Ellipse -7.png":
                                            Eval("ProfileImage").ToString()=="../Assets/Ellipse -3"?"../Assets/Ellipse -3.png":
                                            Eval("ProfileImage").ToString()=="../Assets/Ellipse -1"?"../Assets/Ellipse -1.png":null%>'></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="Name" runat="server"
                                        Text='<%# Eval("EName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="Gender" runat="server"
                                        Text='<%# Eval("Gender") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="DeptName" runat="server"
                                        Text='<%# Eval("DeptName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                     <asp:Label ID="Label1" runat="server"
                                        Text='₹'></asp:Label>
                                    <asp:Label ID="Salary" runat="server"
                                        Text='<%# Eval("EmpSal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StartDate" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="StartDate" runat="server"
                                        Text='<%# Eval("HireDay") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblEdit" runat="server" CommandName="EditButton"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                         <img src="../Assets/create-black-18dp.svg" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lblDelete" runat="server" OnClientClick="return confirm('Are you sure to delete?')"
                                        OnClick="DeleteEmployee">
                                    <img src="../Assets/delete-black-18dp.svg">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </body>
    </html>

</asp:Content>
