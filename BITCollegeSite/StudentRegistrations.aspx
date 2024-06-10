<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistrations.aspx.cs" Inherits="BITCollegeSite.StudentRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
    <asp:Label ID="lblStudentName" runat="server"></asp:Label>
</p>
<p>
    <asp:GridView ID="gvCourses" runat="server" AutoGenerateSelectButton="True" Width="477px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCourses_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Course.CourseNumber" HeaderText="Course" ApplyFormatInEditMode="True" />
            <asp:BoundField DataField="Course.Title" HeaderText="Title" />
            <asp:BoundField HeaderText="Course Type" DataField="Course.CourseType" />
            <asp:BoundField DataField="Course.TuitionAmount" HeaderText="Tuition" DataFormatString="{0:c}" />
            <asp:BoundField DataField="Grade" HeaderText="Grade" DataFormatString="{0:P2}" />
        </Columns>
    </asp:GridView>
</p>
<p>
    <asp:Label ID="lblViewDrop" runat="server" Text="Click the Select Link Beside a registration (above) to View of Drop the course"></asp:Label>
</p>
<p>
    <asp:LinkButton ID="lbtbRegister" runat="server" OnClick="lbtbRegister_Click1">Click Here to Register for a Course</asp:LinkButton>
</p>
<p>
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
</p>
</asp:Content>
