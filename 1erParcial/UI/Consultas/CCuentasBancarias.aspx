<%@ Page Title="Consulta Cuentas Bancarias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CCuentasBancarias.aspx.cs" Inherits="_1erParcial.UI.Consultas.CCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-group">
            <div style="text-align: center;">
                <asp:Label ID="Label3" runat="server" Text="Consulta Cuentas Bancarias" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>

            </div>
        </div>
        <hr>

        <div class="form-horizontal col-md-12 ">

            <div class="form-group row" style="align-items: center;">
                <label style="align-items: center;" for="TipodeFiltro" class="col-md-1">Filtro:</label>

                <div class="col-md-3">

                    <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Balance</asp:ListItem>
                        <asp:ListItem>Todos</asp:ListItem>

                    </asp:DropDownList>



                </div>

                <asp:Label ID="LabelCriterio" runat="server" Text="Criterio:" class="col-md-1"></asp:Label>

                <div class="col-sm-1 col-md-3 col-xs-5" style="align-items: center;">
                    <asp:TextBox class="form-control" ID="TextCriterio" runat="server" Style="width: 270px"></asp:TextBox>
                </div>

                <div class="col-sm-1 col-md-2 col-xs6">
                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="ButtonBuscar_Click" />
                </div>
            </div>





            <div class="form-group row" style="align-items: center;">


                <asp:Label for="DesdeTextBox" ID="Labeldesde" class="col-md-1" runat="server" Text="Desde:"></asp:Label>
                <div class="col-sm-1 col-md-3 col-xs-5">
                    <asp:TextBox class="form-control" ID="DesdeTextBox" runat="server" TextMode="Date" Width="200"></asp:TextBox>
                </div>


                <asp:Label for="HastaTextBox" ID="Labelhasta" class="col-md-1" runat="server" Text="Hasta:"></asp:Label>
                <div class="col-sm-1 col-md-3 col-xs-5">
                    <asp:TextBox class="form-control" ID="HastaTextBox" runat="server" TextMode="Date" Width="200"></asp:TextBox>
                </div>

            </div>

        </div>


        <div class="col-md-12">


            <div class="form-group row" style="align-items: center;">


                <asp:GridView ID="CuentasGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />

                    <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                </asp:GridView>

            </div>

        </div>


        <div class="form-group row" style="align-items: center;">

            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                <asp:Button ID="ImprimirButton" runat="server" Text="Imprimir" class="btn btn-success" ValidationGroup="ValidacionGC" Enabled="True" EnableViewState="True" Visible="False" OnClick="ImprimirButton_Click" />
            </div>

        </div>
    </div>

</asp:Content>
