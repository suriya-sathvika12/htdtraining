<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="AddEditMenu.aspx.cs"
Inherits="FoodOrderManagement.AddEditMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Add / Edit Menu</h2>

<asp:ValidationSummary ID="ValidationSummary1"
runat="server" ForeColor="Red" />

Item Name:

<asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvItem"
runat="server"
ControlToValidate="txtItemName"
ErrorMessage="Item Name Required"
ForeColor="Red" />

<br /><br />

Category:

<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvCat"
runat="server"
ControlToValidate="txtCategory"
ErrorMessage="Category Required"
ForeColor="Red" />

<br /><br />

Food Type:

<asp:DropDownList ID="ddlFoodType" runat="server">
    <asp:ListItem>Veg</asp:ListItem>
    <asp:ListItem>Non-Veg</asp:ListItem>
</asp:DropDownList>

<asp:CompareValidator
ID="cvFoodType"
runat="server"
ControlToValidate="ddlFoodType"
Operator="DataTypeCheck"
Type="String"
ErrorMessage="Select Food Type"
ForeColor="Red" />

<br /><br />

Price:

<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvPrice"
runat="server"
ControlToValidate="txtPrice"
ErrorMessage="Price Required"
ForeColor="Red" />

<asp:RangeValidator
ID="rvPrice"
runat="server"
ControlToValidate="txtPrice"
MinimumValue="1"
MaximumValue="10000"
Type="Double"
ErrorMessage="Price must be between 1 and 10000"
ForeColor="Red" />

<br /><br />

Quantity:

<asp:TextBox ID="txtQty" runat="server"></asp:TextBox>

<asp:RegularExpressionValidator
ID="revQty"
runat="server"
ControlToValidate="txtQty"
ValidationExpression="^\d+$"
ErrorMessage="Only numbers allowed"
ForeColor="Red" />

<br /><br />

Available:

<asp:CheckBox ID="chkAvailable" runat="server" />

<br /><br />

<asp:Button ID="btnSave"
runat="server"
Text="Save"
OnClick="btnSave_Click" />

</asp:Content>