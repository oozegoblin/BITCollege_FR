<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="BITCollegeSite.CourseRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblStudentName" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector:"></asp:Label>
        <asp:DropDownList ID="ddlCourse" runat="server" >
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblRegistrationNotes" runat="server" Text="Registration Notes:"></asp:Label>
        <asp:TextBox ID="tbNotes" runat="server" ></asp:TextBox>
    </p>
    <p>
        <asp:LinkButton ID="lbtbRegister" runat="server" OnClick="lbtbRegister_Click">Register</asp:LinkButton>
        <asp:LinkButton ID="lbtbReturn" runat="server" OnClick="lbtbReturn_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
    </p>
    <p>
    </p>
</asp:Content>
