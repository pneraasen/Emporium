<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Store</title>
	<link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		    <div class="container">
			    <h1>My Store</h1>
                <asp:panel runat="server" id="CategoryDropdowns" class="DropdownSection">
                <asp:DropDownList Class="SelectionDropdown" ID="Category" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Category_SelectedIndexChanged" />
                <asp:DropDownList Class="SelectionDropdown" ID="Subcategory" runat="server" AutoPostBack ="true" visible="false" OnSelectedIndexChanged="Subcategory_SelectedIndexChanged" />
                <asp:DropDownList Class="SelectionDropdown" ID="CartProduct" runat="server" AutoPostBack="true" visible="false" OnSelectedIndexChanged="CartProduct_SelectedIndexChanged" />    
			    <asp:panel id="EmailSection" runat="server" visible="false" Class="EmailPanel">
			        <div class="products">
				        <div>Database Item Placeholder - <asp:LinkButton runat="server" ID="btnAddShirt" OnClick="btnAddProduct_Click">Add To Cart</asp:LinkButton></div>
				        <%--<div>Shirt - <asp:LinkButton runat="server" ID="btnAddShorts" OnClick="btnAddShirt_Click">Add To Cart</asp:LinkButton></div>
				        <div>Pants - <asp:LinkButton runat="server" ID="btnAddShoes" OnClick="btnAddPants_Click">Add To Cart</asp:LinkButton></div>--%>
			        </div>
                </asp:panel>
			    <a href="ViewCart.aspx">View Cart</a>
                    </asp:panel>
		    </div>
        <asp:Label ID="errorLabel" runat="server" Text=""  Visible="False" Class="EmailItem" />
    </form>
</body>
</html>
