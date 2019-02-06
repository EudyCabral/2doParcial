<%@ Page Title="Registro Depositos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RDepositos.aspx.cs" Inherits="_1erParcial.UI.Registros.RDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form>
        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Depositos" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="columns" style="width: 350px;">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="DepositosidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>

                            <div style="width: 90px;">
                                <asp:Label for="DepositosidTextBox" ID="Label6" runat="server" Text="Deposito Id:"></asp:Label>
                            </div>
                            <asp:TextBox ID="DepositosidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Deposito ID" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorcid" ControlToValidate="CuentaidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>

                            <div style="width: 90px;">
                                <asp:Label for="CuentaidTextBox" ID="Label1" runat="server" Text="Cuenta Id:"></asp:Label>
                            </div>
                            <asp:TextBox ID="CuentaidTextBox" runat="server" class="form-control" placeholder="CuentaId" Width="250px" TextMode="Number"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorconcepto" ControlToValidate="ConceptoTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>

                            <div style="width: 90px;">
                                <asp:Label for="ConceptoTextBox" ID="Label5" runat="server" Text="Concepto:"></asp:Label>
                            </div>
                            <asp:TextBox ID="ConceptoTextBox" runat="server" class="form-control" TextMode="MultiLine" placeholder="Concepto" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorMonto" ControlToValidate="MontoTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>
                            <div style="width: 90px;">
                                <asp:Label for="MontoTextBox" ID="Label3" runat="server" Text="Monto:"></asp:Label>
                            </div>
                            <asp:TextBox ID="MontoTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Monto" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="columns" style="width: 400px;">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:Button ValidationGroup="ValidacionBE" ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click" />
                        </div>
                    </div>
                </div>

                <div class="columns">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorfecha" ControlToValidate="FechaTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>
                            <div style="width: 50px">
                                <asp:Label for="FechaTextBox" ID="Label2" runat="server" Text="Fecha:"></asp:Label>
                            </div>
                            <asp:TextBox ID="FechaTextBox" runat="server" class="form-control" TextMode="Date" Width="180"></asp:TextBox>

                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div class="row" style="justify-content: center;">
            <div class="form-group">

                <asp:Button ID="LimpiarButton" class="btn btn-info" runat="server" Text="Limpiar" OnClick="LimpiarButton_Click" />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="ElminarButton_Click" />
            </div>
        </div>

    </form>

</asp:Content>
