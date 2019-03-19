<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SampleCuentas.aspx.cs" Inherits="_1erParcial.UI.Samples.SampleCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        
        <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Cuentas" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
         <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row" >
                   <asp:Label for="CuentaidTextBox" class="control-label col-md-1" ID="Label6" runat="server" Text="Id: " ></asp:Label>

               
                <div class="col-sm-1 col-md-4 col-xs-5" style="align-items: center;">
                  
                            <asp:TextBox ID="CuentaidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Cuenta ID" ></asp:TextBox>
                                 </div>
               
                  <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="CuentaidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>
 
                <div class="col-sm-1 col-md-2 col-xs6" style="align-items: center;">
                      <asp:Button ValidationGroup="ValidacionBE" ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary"  />
                   </div>
                <label class="control-label col-sm-1" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-3" style="align-items: center;"  >
               
                            <asp:TextBox ID="FechaTextBox" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
                 
                       </div>
                      <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorfecha" ControlToValidate="FechaTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

            </div>

        
            <div class="form-group row" style="align-items: center;">
                <label class="control-label col-sm-1" for="NombreTextBox">Nombre:</label>
                <div class="col-sm-1 col-md-4">
                  <asp:TextBox ID="NombreTextBox" runat="server" class="form-control" placeholder="Nombre" ></asp:TextBox>
                      </div>
                      <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorNombre" ControlToValidate="NombreTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

            </div>

            <div class="form-group row" style="align-items: center;">
                <label class="control-label col-sm-1" for="BalanceTextBox">Balance:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                   
                            <asp:TextBox ID="BalanceTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Balance" ReadOnly="True">0</asp:TextBox>
                    </div>
                 <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorBalance" ControlToValidate="BalanceTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                         <asp:Button ID="LimpiarButton" class="btn btn-info" runat="server" Text="Limpiar"  />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar"  />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar"  />

       </div>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
