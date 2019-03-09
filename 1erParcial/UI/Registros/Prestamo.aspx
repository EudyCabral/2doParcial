<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prestamo.aspx.cs" Inherits="_1erParcial.UI.Registros.Prestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">
        <div style="text-align: center;">

            <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Prestamo" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
        </div>
    </div>


    <div class="container">

        <div class="form-group">
           <div class="row" style="align-items:center;">
                <asp:Label ID="Label1" class="col-md-1.5 control-label" runat="server" Text="Deposito Id:"></asp:Label>
            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                <asp:TextBox class="form-control " ID="DepositoIdTextBox" placeholder="0" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" />
                </div>

                 <div class="col-md-2.5 col-sm-2.5 col-xl-2.5 col-2.5">
                      <asp:TextBox class="form-control " ID="FechaTextBox" runat="server" TextMode="Date"></asp:TextBox>
             
                </div>
            </div>
        </div>

         <div class="form-group">
           <div class="row" style="align-items:center;">
                <asp:Label ID="Label2" class="col-md-1.5 control-label" runat="server" Text="Cuenta:"></asp:Label>
            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
               
                <asp:DropDownList ID="CuentasDropDownList" class="form-control " runat="server"></asp:DropDownList>
                </div>
               
            </div>
        </div>

        
         <div class="form-group">
           <div class="row" style="align-items:center;">
                <asp:Label ID="Label3" class="col-md-1.5 control-label" runat="server" Text="Capital:"></asp:Label>
            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                <asp:TextBox ID="CapitalTextBox" class="form-control " runat="server"></asp:TextBox>
                  </div>
               
            </div>
        </div>

        
         <div class="form-group">
           <div class="row" style="align-items:center;">
                <asp:Label ID="Label4" class="col-md-1.5 control-label" runat="server" Text="Interes:"></asp:Label>
            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                <asp:TextBox ID="InteresTextBox" class="form-control " runat="server"></asp:TextBox>
                  </div>
               
            </div>
        </div>

        
         <div class="form-group">
           <div class="row" style="align-items:center;">
                <asp:Label ID="Label5" class="col-md-1.5 control-label" runat="server" Text="Tiempo/Meses:"></asp:Label>
            <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                <asp:TextBox ID="TiempoTextBox" class="form-control " runat="server"></asp:TextBox>
                  </div>
                  <div class="col-md-3 col-sm-3 col-xl-3 col-3">
                    <asp:Button ID="CalcularButton" runat="server" Text="Calcular" class="btn btn-success" />
                </div>
            </div>
        </div>

         <div class="row">
                        <asp:GridView ID="DetalleGridView" CssClass=" col-md-offset-4 col-sm-offset-4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  AutoGenerateColumns="true">
                            <AlternatingRowStyle BackColor="White" />

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
             </div>
       <div class="row" style="justify-content: center;">
            <div class="form-group">

                <asp:Button ID="LimpiarButton" class="btn btn-info" runat="server" Text="Limpiar"  />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar" />
            </div>
        </div>

     </div>

     


</asp:Content>
