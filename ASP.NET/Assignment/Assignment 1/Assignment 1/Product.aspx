<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment1.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Appliances</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .container {
            width: 500px;
            margin: 50px auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px #ccc;
            text-align: center;
        }

        h2 {
            color: darkblue;
            margin-bottom: 25px;
        }

        .dropdown {
            width: 250px;
            padding: 8px;
            font-size: 15px;
        }

        .productImage {
            border: 1px solid #ccc;
            border-radius: 8px;
            margin-top: 20px;
        }

        .btn {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #0078D7;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 15px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #005fa3;
        }

        .priceLabel {
            display: block;
            margin-top: 20px;
            font-size: 18px;
            color: green;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container">

            <h2>Home Appliances</h2>

            <!-- Dropdown -->
            <asp:DropDownList
                ID="ddlProducts"
                runat="server"
                CssClass="dropdown"
                AutoPostBack="True"
                OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">

                <asp:ListItem Text="Select Product" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Fan" Value="fan"></asp:ListItem>
                <asp:ListItem Text="Fridge" Value="fridge"></asp:ListItem>
                <asp:ListItem Text="Washing Machine" Value="washingmachine"></asp:ListItem>

            </asp:DropDownList>

            <br />

            <!-- Product Image -->
            <asp:Image
                ID="imgProduct"
                runat="server"
                Width="250px"
                Height="200px"
                CssClass="productImage" />

            <br />

            <!-- Button -->
            <asp:Button
                ID="btnPrice"
                runat="server"
                Text="Get Price"
                CssClass="btn"
                OnClick="btnPrice_Click" />

            <br />

            <!-- Price Label -->
            <asp:Label
                ID="lblPrice"
                runat="server"
                CssClass="priceLabel">
            </asp:Label>

        </div>

    </form>
</body>
</html>