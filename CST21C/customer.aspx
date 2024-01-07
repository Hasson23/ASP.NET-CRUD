<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="CST21C.customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-header">
                <h4>Customer Information</h4>

            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-6">
                        First Name:
                        <asp:TextBox ID="TextFirstName" placeholder=" First Name" CssClass="form-control" runat="server"></asp:TextBox>


                    </div>
                     <div class="col-md-6">
                        Last Name:
                        <asp:TextBox ID="TextLastName" placeholder=" Last Name" CssClass="form-control" runat="server"></asp:TextBox>


                    </div>
                     <div class="col-md-6">
                        Email:
                        <asp:TextBox ID="TextEmail" placeholder=" Email" CssClass="form-control" runat="server"></asp:TextBox>


                    </div>
                     <div class="col-md-6">
                        Password:
                        <asp:TextBox ID="TextPassword" placeholder="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mt-2" style="margin-left:140px; margin-top:40px; margin-bottom:30px">
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-success w-100" OnClick="BtnSave_Click1"/>
                    </div>
                     <div class="col-md-3 mt-2" style="margin-top:40px; margin-bottom:30px">
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-primary w-100" OnClick="BtnUpdate_Click"/>
                    </div>
                     <div class="col-md-3 mt-2" style=" margin-top:40px; margin-bottom:30px">
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger w-100" OnClick="BtnDelete_Click"/>
                    </div>



                </div>
              <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="DgvCustomer" GridLines="None" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DgvCustomer_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                            <asp:ButtonField CommandName="Select" HeaderText="Edit" ControlStyle-cssClass="btn btn-danger btn-sm" ShowHeader="True" Text="Edit" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connect %>" SelectCommand="SELECT * FROM [customers]"></asp:SqlDataSource>
                </div>
            </div>
            </div>

            

        </div>

    </div>
</asp:Content>

