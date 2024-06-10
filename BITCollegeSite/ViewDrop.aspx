<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDrop.aspx.cs" Inherits="BITCollegeSite.ViewDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:DetailsView ID="dvRegistrationDetails" runat="server" Height="103px" OnPageIndexChanging="dvRegistrationDetails_PageIndexChanging1" Width="367px" AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowPaging="True">
            <AlternatingRowStyle ForeColor="Black" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField ApplyFormatInEditMode="True" DataField="RegistrationNumber" HeaderText="Registration" />
                <asp:BoundField DataField="Student.FullName" HeaderText="Student" ApplyFormatInEditMode="True" />
                <asp:BoundField DataField="Course.Title" HeaderText="Course" ApplyFormatInEditMode="True" />
                <asp:BoundField DataField="RegistrationDate" HeaderText="Date" ApplyFormatInEditMode="True" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="Grade" DataFormatString="{0:P2}" HeaderText="Grade" />
            </Fields>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White"/>
        </asp:DetailsView>
    </p>
    <p>
        <asp:LinkButton ID="lbtbDropCourse" runat="server" OnClick="lbtbDropCourse_Click">Drop Course</asp:LinkButton>
        <asp:LinkButton ID="lbtbReturn" runat="server" OnClick="lbtbReturn_Click1">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
