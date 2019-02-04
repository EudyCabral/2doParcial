<%@ Page Title="Registro de Cuentas Bancarias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RCuentasBancarias.aspx.cs" Inherits="_1erParcial.UI.Registros.RCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <form>
        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Cuentas" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="columns" style="width: 350px;">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                                    <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="CuentaidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE" ></asp:RequiredFieldValidator>
                                
                            <div style="width: 75px;">
                                     <asp:Label for="CuentaidTextBox" ID="Label6" runat="server" Text="Cuenta Id:"></asp:Label>
                            
                            </div>
                         
                            <asp:TextBox ID="CuentaidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Numero ID" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorNombre" ControlToValidate="NombreTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar" >*</asp:RequiredFieldValidator>
                               
                            <div style="width: 75px;">
                                <asp:Label for="NombreTextBox" ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                            </div>
                                    
                            <asp:TextBox ID="NombreTextBox" runat="server" class="form-control" placeholder="Nombre" Width="250px"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorBalance" ControlToValidate="BalanceTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar" >*</asp:RequiredFieldValidator>
                             
                            <div style="width: 75px;">
                                
                                <asp:Label for="BalanceTextBox" ID="Label5" runat="server" Text="Balance:"></asp:Label>
                            </div>
                               
                            <asp:TextBox ID="BalanceTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Balance" Width="250px"></asp:TextBox>
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

                <div class="columns" >
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <div style="width:50px">
                            <asp:Label for="FechaTextBox" ID="Label2" runat="server" Text="Fecha:"></asp:Label>
                            </div>
                                    <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorfecha" ControlToValidate="FechaTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar" >*</asp:RequiredFieldValidator>
                               
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
