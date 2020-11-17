<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="EmployeeManagementPayrollSystem.Pages.Aspx.UpdateEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../Css/payroll-form.css">
    <title>Employee payroll form</title>
    <script defer src="../js/payroll-form.js"></script>
</head>

<body>
    <div>
        <header>Employee Update Form</header>
    </div>
    <div class="form" action="#" runat="server" >
        <div class="row">
            <label class="label text" for="name">EmpId</label>
            <asp:TextBox class="input" type="text" ID="EmpId" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="row">
            <label class="label text" for="name">Name</label>
            <asp:TextBox class="input" type="text" ID="name" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label class="label text" for="profile">Profile image</label>
            <div class="profile-radio-button">
                <label>
                    <asp:RadioButton runat="server" OnCheckedChanged="SelectProfileImage" ID="profile1" GroupName="profile" value="../Assets/Ellipse -3.png " />
                    <asp:Image runat="server" class="profile" ID='image1' src="../Assets/Ellipse -3.png" />
                </label>
                <label>
                    <asp:RadioButton runat="server" OnCheckedChanged="SelectProfileImage" ID="profile2" GroupName="profile" value="../Assets/Ellipse -1.png " />
                    <asp:Image runat="server" class="profile" ID='image2' src="../Assets/Ellipse -1.png" />
                </label>
                <label>
                    <asp:RadioButton runat="server" OnCheckedChanged="SelectProfileImage" ID="profile3" GroupName="profile" value="../Assets/Ellipse -8.png " />
                    <asp:Image runat="server" class="profile" ID='image3' src="../Assets/Ellipse -8.png" />
                </label>
                <label>
                    <asp:RadioButton runat="server" OnCheckedChanged="SelectProfileImage" ID="profile4" GroupName="profile" value="../Assets/Ellipse -7.png " />
                    <asp:Image runat="server" class="profile" ID='image4' src="../Assets/Ellipse -7.png" />
                </label>
            </div>
        </div>
        <div class="row">
            <label class="label text" for="gender">Gender</label>
            <div>
                <asp:RadioButton type="radio" ID="male" name="gender" GroupName="gender" value="male" runat="server"  />
                <label class="text" for="male">Male</label>
                <asp:RadioButton type="radio" ID="female" name="gender" GroupName="gender" value="female" runat="server"  />
                <label class="text" for="female">Female</label>
            </div>
        </div>

        <div class="row">
            <label class="label text" for="department">Department</label>
            <div>
                <asp:CheckBox class="checkbox" type="checkbox" AutoPostBack="True" ID="hr" name="hr" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" />
                <label class="text" for="hr">HR</label>
                <asp:CheckBox class="checkbox" type="checkbox" AutoPostBack="True" ID="sales" name="sales" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" />
                <label class="text" for="sales">Sales</label>
                <asp:CheckBox class="checkbox" type="checkbox" AutoPostBack="True" ID="finance" name="finance" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" />
                <label class="text" for="finance">Finance</label>
                <asp:CheckBox class="checkbox" type="checkbox" AutoPostBack="True" ID="engineer" name="engineer" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" />
                <label class="text" for="engineer">Engineer</label>
                <asp:CheckBox class="checkbox" type="checkbox" AutoPostBack="True" ID="others" name="others" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" />
                <label class="text" for="others">Others</label>
            </div>
        </div>
        <div class="row">
            <label class="label text" for="salary">Salary</label>
            <asp:TextBox class="input" type="number" ID="salary" name="salary" placeholder="Salary" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label class="label text" for="startDate">Start Date</label>
            <div>
                <select id="day" name="Day" runat="server" clientidmode="Static" required>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    <option value="11">11</option>
                    <option value="12">12</option>
                    <option value="13">13</option>
                    <option value="14">14</option>
                    <option value="15">15</option>
                    <option value="16">16</option>
                    <option value="17">17</option>
                    <option value="18">18</option>
                    <option value="19">19</option>
                    <option value="20">20</option>
                    <option value="21">21</option>
                    <option value="22">22</option>
                    <option value="23">23</option>
                    <option value="24">24</option>
                    <option value="25">25</option>
                    <option value="26">26</option>
                    <option value="27">27</option>
                    <option value="28">28</option>
                    <option value="29">29</option>
                    <option value="30">30</option>
                    <option value="31">31</option>
                </select>
                <select id="month" name="Month" runat="server" clientidmode="Static" required>
                    <option value="Jan">January</option>
                    <option value="Feb">Febuary</option>
                    <option value="March">March</option>
                    <option value="April">April</option>
                    <option value="May">May</option>
                    <option value="June">June</option>
                    <option value="July">July</option>
                    <option value="Aug">August</option>
                    <option value="Sept">September</option>
                    <option value="Oct">October</option>
                    <option value="Nov">November</option>
                    <option value="Dec">December</option>
                </select>
                <select id="year" name="Year" runat="server" clientidmode="Static" required>
                    <option value="2020">2020</option>
                    <option value="2019">2019</option>
                    <option value="2018">2018</option>
                    <option value="2017">2017</option>
                    <option value="2016">2016</option>
                </select>
            </div>
        </div>
        <div class="row">
            <label class="label text" for="notes">Notes</label>
            <asp:TextBox ID="notes" class="input" name="Notes" placeholder="" Style="height: 100px" runat="server"></asp:TextBox>
        </div>
        <div class="buttonParent">
             <a href="../Aspx/DisplayEmployee.aspx" class="resetButton button cancelButton">Cancel</a>
            <div class="submit-reset">
                 <asp:Button Text="Update" runat="server" class="button submitButton" OnClick="SubmitButton"/>
            </div>
        </div>
         <div class="display-message">
            <asp:Label runat="server" ID="myLabel" class="display-message-label"/>
        </div>
    </div>
</body>
</html>

</asp:Content>
