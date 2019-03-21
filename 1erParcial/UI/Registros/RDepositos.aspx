<%@ Page Title="Registro Depositos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RDepositos.aspx.cs" Inherits="_1erParcial.UI.Registros.RDepositos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Depositos" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <hr>
                   <div class="form-horizontal col-md-12" role="form">
              
                    <div class="form-group row" style="align-items: center;">
                        
                           
                                <asp:Label for="DepositosidTextBox" class="col-md-1" ID="Label6" runat="server" Text="Deposito Id:"></asp:Label>
                     <div class="col-sm-1 col-md-3 col-xs-5">
                            <asp:TextBox ID="DepositosidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Deposito ID" Width="250px"></asp:TextBox>
                       </div>
                         <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="DepositosidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>
                        
                         <div class="col-sm-1 col-md-2 col-xs-4" >
                            <asp:Button ValidationGroup="ValidacionBE" ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="BuscarButton_Click" />
                       </div>
                          
                        <asp:Label for="FechaTextBox" ID="Label2" class="col-md-1" runat="server" Text="Fecha:"></asp:Label>
                       <div class="col-sm-1 col-md-3 col-xs-5">
                            <asp:TextBox ID="FechaTextBox" runat="server" class="form-control" TextMode="Date" Width="180"></asp:TextBox>
                        </div>
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorfecha" ControlToValidate="FechaTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>
                               </div>
                       
                    
                      
                    
                    <div class="form-group row" style="align-items: center;">
                   
                        
                      
                                <asp:Label for="CuentaidTextBox" class="col-md-1" ID="Label1" runat="server" Text="Cuenta Id:"></asp:Label>
                        <div class="col-sm-1 col-md-3 col-xs-5">
                            <asp:TextBox ID="CuentaidTextBox" runat="server" class="form-control" placeholder="CuentaId" Width="250px" TextMode="Number"></asp:TextBox>
                          </div>
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorcid" ControlToValidate="CuentaidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>

                        </div>

                 

                    <div class="form-group row" style="align-items: center;">
                       
                          
                                <asp:Label for="ConceptoTextBox" ID="Label5" class="col-md-1" runat="server" Text="Concepto:"></asp:Label>
                     <div class="col-sm-1 col-md-3 col-xs-5">
                            <asp:TextBox ID="ConceptoTextBox" runat="server" class="form-control" TextMode="MultiLine" placeholder="Concepto" Width="250px"></asp:TextBox>
                      </div>
                         <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorconcepto" ControlToValidate="ConceptoTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>

                               
                    </div>
               
                    <div class="form-group row" style="align-items: center;">
                     
                                <asp:Label for="MontoTextBox" ID="Label3" class="col-md-1" runat="server" Text="Monto:"></asp:Label>
                            <div class="col-sm-1 col-md-3 col-xs-5">
                            <asp:TextBox ID="MontoTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Monto" Width="250px"></asp:TextBox>
                         </div>
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorMonto" ControlToValidate="MontoTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar"></asp:RequiredFieldValidator>
                         
                    </div>
                    


            
                   
           

           

          

       <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                <asp:Button ID="LimpiarButton" class="btn btn-info" runat="server" Text="Limpiar" OnClick="LimpiarButton_Click" />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="ElminarButton_Click" />
           </div>

                </div>
        </div>
      </div>
       
    </div>
    
</asp:Content>
