<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Views/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="EX_Tareas._Default" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <script type="text/javascript" src="/Scripts/NuevaTarea/nuevaTarea.js"></script>
   <script type="text/javascript" src="/Scripts/jquery-3.3.1.min.js"></script>
   <link href="/Content/nuevaTareaPopUp.css" rel="stylesheet" type="text/css">
 

    <div  style="width:auto;background-color:whitesmoke;height:50%;">
           <div>
               <input type="button" id="nuevo" name="nuevo" value="Nueva" onclick="MostrarNuevaTareaPopUp()" style  ="background-color:forestgreen;width:150px;border:0px;color:white;"/>
          </div>
        
        <dx:ASPxGridView ID="gdvTareas" runat="server" KeyFieldName="IdTarea" Width="100%" 
         AutoGenerateColumns="false"
         nHeaderFilterFillItems="gdvTareas_HeaderFilterFillItems" 
         EnableRowsCache="true" 
         ClientInstanceName="gdvTareas" >

               <SettingsBehavior  AllowSelectByRowClick = "true" />
            
            <Columns>
               <dx:GridViewCommandColumn  ShowEditButton="true"  ShowDeleteButton="true" VisibleIndex="0"  />
               
              <dx:GridViewDataColumn FieldName="IdTarea" Caption="Id Tarea" Visible="true" VisibleIndex="1" > 
                  <DataItemTemplate>
                  <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>
              <dx:GridViewDataColumn FieldName="Tarea" Caption="Tarea" Visible="True" VisibleIndex="2" >
                   <DataItemTemplate>
                   <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="IdTipoTarea" Caption="Id Tipo Tarea" Visible="true"  VisibleIndex="3" >
                  <DataItemTemplate>
               <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                  </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="IdEstadoTarea" Caption="Id Estado Tarea" Visible="false"  VisibleIndex="4">
                  <DataItemTemplate>
                   <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                  </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="IdTipoServicio" Caption="Id Tipo Servicio" Visible="false"  VisibleIndex="5">
                  <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="IdEstadoTarea" Caption="Id Estado Tarea"  VisibleIndex="5">
                  <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="TiempoEstimado" Caption="Tiempo Estimado"  VisibleIndex="6">
                  <DataItemTemplate>
                   <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
             <dx:GridViewDataColumn FieldName="Orden" Caption="Orden"  VisibleIndex="7">
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
          </Columns>
   
         <SettingsDataSecurity AllowEdit="true" AllowDelete="true"/>
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>

        <SettingsSearchPanel Visible="True" ShowApplyButton="True" ShowClearButton="True" />
        <Settings ShowFooter="true" ShowHeaderFilterButton="true" />
        <SettingsPopup>
          <HeaderFilter Height="200">
             <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
          </HeaderFilter>
        </SettingsPopup>


        </dx:ASPxGridView>
        
    </div>
    <br />


      <div id="nuevaTarea" class="awindow">
            <div class="awindow-content">

            <span class="close" onclick="OcultarNuevaTareaPopUp()">&times;</span>

            <label>Tarea</label><br />
            <input type="text" id="tarea" name="tarea" runat="server"/><br />

            <label>Tipo tarea</label><br />
            <asp:DropDownList ID="tipoTarea" runat="server"></asp:DropDownList><br />

            <label>Prioridad</label><br />
            <asp:DropDownList ID="prioridad" runat="server"></asp:DropDownList><br />

            <label>Fecha Inicio</label><br />
            <input type="date" id="fechaInicio" name="fechaInicio"  runat="server"/><br />

            <label>Fecha Final</label><br />
            <input type="date" id="fechaFinal" name="fechaFinal"  runat="server"/><br />

            <label>Usuarios</label><br />
             <asp:ListBox ID="usuarios" runat="server" SelectionMode="Multiple"></asp:ListBox> <br />
               
            <label>Descripcion</label><br />
            <textarea id="descripcion" name="descripcion" rows="3" cols="10"  runat="server"></textarea><br />

            <label>Proceso</label><br />
            <input type="text" id="proceso" name="proceso"  runat="server"/> <br />   

            <label>Resultado</label><br />
            <asp:DropDownList ID="resultado" runat="server"></asp:DropDownList><br />

            <label>Tiempo Estimado</label><br />
            <input type="number" id="tiempoEstimado" name="tiempoEstimado"  runat="server" min="0.5" max="10000" step="0.5"/> <br />   
                
         <asp:Button ID="Button1" runat="server" Text="Enviar" />

        </div>
    </div>

    <script>
         var now = new Date();
         var day = ("0" + now.getDate()).slice(-2);
         var month = ("0" + (now.getMonth() + 1)).slice(-2);
         var today = now.getFullYear()+"-"+(month)+"-"+(day) ;
         $('#MainContent_fechaInicio').val(today);
         $('#MainContent_fechaFinal').val(today);

    </script>
        
</asp:Content>
