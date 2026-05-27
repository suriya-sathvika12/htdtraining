<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="OrderStats.aspx.cs"
Inherits="FoodOrderManagement.OrderStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Order Statistics</h2>

<asp:Label ID="lblVisitors" runat="server"></asp:Label>

<br /><br />

<asp:Label ID="lblUsers" runat="server"></asp:Label>

<br /><br />

<h3>Category Wise Food Summary</h3>

<asp:GridView ID="gvStats" runat="server"></asp:GridView>

</asp:Content>