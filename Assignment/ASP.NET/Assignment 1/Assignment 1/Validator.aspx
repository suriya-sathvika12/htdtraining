<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Form</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .container {
            width: 700px;
            margin: 40px auto;
            background: white;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 0 10px #ccc;
        }

        h2 {
            text-align: center;
            margin-bottom: 25px;
        }

        table {
            width: 100%;
        }

        td {
            padding: 10px;
            vertical-align: top;
        }

        .labelCell {
            width: 150px;
            font-weight: bold;
        }

        .inputCell {
            width: 220px;
        }

        .errorCell {
            width: 300px;
        }

        .error {
            color: red;
            font-size: 13px;
        }

        input[type=text] {
            width: 200px;
            padding: 5px;
        }

        .btn {
            padding: 8px 18px;
            background-color: #0078D7;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #005fa3;
        }

        .success {
            color: green;
            font-weight: bold;
        }

        .summary {
            margin-top: 15px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container">

            <h2>Insert Your Details</h2>

            <table>

                <!-- Name -->
                <tr>
                    <td class="labelCell">Name :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RequiredFieldValidator
                            ID="rfvName"
                            runat="server"
                            ControlToValidate="txtName"
                            ErrorMessage="Name required"
                            CssClass="error">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <!-- Family Name -->
                <tr>
                    <td class="labelCell">Family Name :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RequiredFieldValidator
                            ID="rfvFamily"
                            runat="server"
                            ControlToValidate="txtFamily"
                            ErrorMessage="Family name required"
                            CssClass="error">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:CompareValidator
                            ID="cvNameFamily"
                            runat="server"
                            ControlToValidate="txtFamily"
                            ControlToCompare="txtName"
                            Operator="NotEqual"
                            Type="String"
                            ErrorMessage="Family name must differ from Name"
                            CssClass="error">
                        </asp:CompareValidator>
                    </td>
                </tr>

                <!-- Address -->
                <tr>
                    <td class="labelCell">Address :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RegularExpressionValidator
                            ID="revAddress"
                            runat="server"
                            ControlToValidate="txtAddress"
                            ValidationExpression="^.{2,}$"
                            ErrorMessage="Address must contain at least 2 characters"
                            CssClass="error">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <!-- City -->
                <tr>
                    <td class="labelCell">City :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RegularExpressionValidator
                            ID="revCity"
                            runat="server"
                            ControlToValidate="txtCity"
                            ValidationExpression="^.{2,}$"
                            ErrorMessage="City must contain at least 2 characters"
                            CssClass="error">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <!-- Zip -->
                <tr>
                    <td class="labelCell">Zip Code :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RegularExpressionValidator
                            ID="revZip"
                            runat="server"
                            ControlToValidate="txtZip"
                            ValidationExpression="^\d{5}$"
                            ErrorMessage="Zip code must be 5 digits"
                            CssClass="error">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <!-- Phone -->
                <tr>
                    <td class="labelCell">Phone :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RegularExpressionValidator
                            ID="revPhone"
                            runat="server"
                            ControlToValidate="txtPhone"
                            ValidationExpression="^(\d{2}-\d{7}|\d{3}-\d{7})$"
                            ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
                            CssClass="error">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <!-- Email -->
                <tr>
                    <td class="labelCell">E-Mail :</td>

                    <td class="inputCell">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>

                    <td class="errorCell">
                        <asp:RegularExpressionValidator
                            ID="revEmail"
                            runat="server"
                            ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-\+.'']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Invalid Email"
                            CssClass="error">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <!-- Button -->
                <tr>
                    <td colspan="2">
                        <asp:Button
                            ID="btnCheck"
                            runat="server"
                            Text="Check"
                            CssClass="btn"
                            OnClick="btnCheck_Click" />
                    </td>
                </tr>

                <!-- Success Message -->
                <tr>
                    <td colspan="3">
                        <asp:Label
                            ID="lblMessage"
                            runat="server"
                            CssClass="success">
                        </asp:Label>
                    </td>
                </tr>

                <!-- Validation Summary -->
                <tr>
                    <td colspan="3" class="summary">
                        <asp:ValidationSummary
                            ID="ValidationSummary1"
                            runat="server"
                            HeaderText="Validation Errors"
                            CssClass="error" />
                    </td>
                </tr>

            </table>

        </div>

    </form>
</body>
</html>