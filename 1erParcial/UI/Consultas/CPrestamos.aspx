<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CPrestamos.aspx.cs" Inherits="_1erParcial.UI.Consultas.CPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="form-group container">
        <h2 class="control-label" style="text-align: center">Consulta Prestamos</h2>
    </div>
    <div class="container" ">
    <div class="form-control" style="height:120px;" >
        <div class="col-sm-10" >

    <div class="container ">
        <div class="row" >
            <div class="columns" style="width: 280px;">
                <div class="form-group">
                    <div class="row" style="align-items: center;">
                        <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
                        <div style="width: 220px">

                            <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                                <asp:ListItem>Prestamo ID</asp:ListItem>
                                <asp:ListItem>Cuenta Id</asp:ListItem>
                                <asp:ListItem>Nombre de Cuenta</asp:ListItem>
                                <asp:ListItem>Capital</asp:ListItem>
                                <asp:ListItem>Interes</asp:ListItem>       
                                <asp:ListItem>Tiempo</asp:ListItem>
                                <asp:ListItem>Balance</asp:ListItem>     
                                <asp:ListItem Selected="True">Todo</asp:ListItem>
             
                            </asp:DropDownList>

                        </div>

                    </div>
                </div>
            </div>

            <div class="columns" style="width:400px;">
                <div class="form-group">
                    <div class="row" style="align-items: center;">
                        
                        <asp:Label ID="LabelCriterio" runat="server" Text="Criterio:" Style="width: 60px"></asp:Label>
                      <div style="width:280px;">
                        <asp:TextBox class="form-control" ID="TextCriterio" runat="server" Style="width: 270px"></asp:TextBox>
                   </div> 
                   

                           <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="ButtonBuscar_Click" />
                     

                    </div>
             
                </div>
             </div>
                   
 
        </div>



       
        <div class="row" style="align-items:center;">

         

            <div class="columns" style="width: 300px;">
                <div class="form-group">
                    <div class="row" style="align-items: center;">
                        <asp:Label for="DesdeTextBox" ID="Labeldesde" runat="server" Text="Desde:"></asp:Label>
                        <asp:TextBox class="form-control" ID="DesdeTextBox" runat="server" TextMode="Date" Width="200"></asp:TextBox>

                    </div>
                </div>
            </div>


            <div class="columns" >
                <div class="form-group">
                    <div class="row" style="align-items: center;">


                        <asp:Label for="HastaTextBox" ID="Labelhasta" runat="server" Text="Hasta:"></asp:Label>
                        <asp:TextBox class="form-control" ID="HastaTextBox" runat="server" TextMode="Date" Width="200"></asp:TextBox>


                    </div>
                </div>
            </div>

        </div>
    



   </div>


    </div>

    </div>
        <div class="col-sm-10" >

         <div class="columns">
                <div class="form-group">
                    <div class="row" style="align-items: center;">

                        <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="LightSkyBlue" />
                           
                            <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

         </div>

          
        <div class="form-group">
           <div class="row" style="align-items:center;">
        <div class="col-md-3 col-sm-3 col-xl-3 col-3"> 
                    <asp:Button ID="ImprimirButton" runat="server" Text="Imprimir" class="btn btn-success" ValidationGroup="ValidacionGC" Enabled="True" EnableViewState="True" Visible="False" OnClick="ImprimirButton_Click" />
                   </div></div></div>
         </div>

</asp:Content>
