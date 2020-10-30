<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Views/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="EX_Tareas._Default" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <script type="text/javascript" src="/Scripts/NuevaTarea/nuevaTarea.js"></script>
   <script type="text/javascript" src="/Scripts/jquery-3.3.1.min.js"></script>
   <link href="/Content/nuevaTareaPopUp.css" rel="stylesheet" type="text/css">


        <div id="nuevaTarea" class="awindow" >
            <div class="awindow-content">

            <span class="close" onclick="OcultarNuevaTareaPopUp()">&times;</span>

            <label>Tarea</label>
            <input type="text" id="tarea" name="tarea" runat="server"/><br />

            <label>Tipo tarea</label>
            <asp:DropDownList ID="tipoTarea" runat="server"></asp:DropDownList><br />

            <label>Estado Tarea</label>
            <asp:DropDownList ID="estadoTarea" runat="server"></asp:DropDownList><br />

            <label>Tipo Servicio</label>
            <asp:DropDownList ID="tipoServicio" runat="server"></asp:DropDownList><br />

             <label>Tarea Valor</label>
            <asp:DropDownList ID="tareaValor" runat="server"></asp:DropDownList><br />

            <label>Fecha Inicio</label>
            <input type="date" id="fechaInicio" name="fechaInicio"  runat="server"/><br />

            <label>Fecha Final</label>
            <input type="date" id="fechaFinal" name="fechaFinal"  runat="server"/><br />
               
            <label>Descripcion</label>
            <textarea id="descripcion" name="descripcion" rows="3" cols="10"  runat="server"></textarea><br />

            <label>Tiempo Estimado</label>
            <input type="number" id="tiempoEstimado" name="tiempoEstimado"  runat="server" min="0.5" max="100000" step="0.5"/> <br />   
                
            <asp:Button ID="Button1" runat="server" Text="Enviar" />

        </div>
    </div>




 

       <div  style="width:auto;background-color:whitesmoke;height:50%;">
           <div>
               <input type="button" id="nuevo" name="nuevo" value="Nueva" onclick="MostrarNuevaTareaPopUp()" style  ="background-color:forestgreen;width:150px;border:0px;color:white;"/>
          </div>
        
        <dx:ASPxGridView ID="gdvTareas" runat="server" KeyFieldName="IdTarea" Width="100%" 
         AutoGenerateColumns="true"
         nHeaderFilterFillItems="gdvTareas_HeaderFilterFillItems" 
         EnableRowsCache="true" 
         ClientInstanceName="gdvTareas"
         OnCommandButtonInitialize="gdvTareas_CommandButtonInitialize" >

               <SettingsBehavior  AllowSelectByRowClick = "true" />
            
            <Columns>
               <dx:GridViewCommandColumn  ShowEditButton="true"  ShowDeleteButton="true" VisibleIndex="0"  />
               
              <dx:GridViewDataColumn FieldName="IdTarea" Caption="Id Tarea" Visible="true" VisibleIndex="1" > 
                  <DataItemTemplate>
                <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="Tarea" Caption="Tarea"  VisibleIndex="2" >
                 <DataItemTemplate>
                    <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                 </DataItemTemplate>
              </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="Descripcion" Caption="Descripcion"  VisibleIndex="3" >
                   <DataItemTemplate>
                      <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                  </DataItemTemplate>
               </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="IdTipoTarea" Caption="Id Tipo Tarea" Visible="false"  VisibleIndex="4" >
                  <DataItemTemplate>
                <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="TipoTarea" Caption="Tipo Tarea"  VisibleIndex="5" >
                  <DataItemTemplate>
                <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="IdEstadoTarea" Caption="Id Estado Tarea" Visible="false"  VisibleIndex="6">
                <DataItemTemplate>
                    <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="EstadoTarea" Caption="Estado Tarea"  VisibleIndex="7">
                <DataItemTemplate>
                    <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="IdTipoServicio" Caption="Id Tipo Servicio" Visible="false"   VisibleIndex="8">
                  <DataItemTemplate>
                 <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="TipoServicio" Caption="Tipo Servicio"    VisibleIndex="9">
                  <DataItemTemplate>
                 <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="IdTareaValor" Caption="Id Tarea Valor" Visible="false"  VisibleIndex="10">
                  <DataItemTemplate>
                 <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="TareaValor" Caption="Tarea Valor"  VisibleIndex="11">
                  <DataItemTemplate>
                 <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaInicio" Caption="Fecha Inicio"  VisibleIndex="12">
                  <DataItemTemplate>
                <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaFin" Caption="Fecha Fin"  VisibleIndex="13">
                  <DataItemTemplate>
                <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
            
               <dx:GridViewDataColumn FieldName="TiempoEstimado" Caption="Tiempo Estimado"  VisibleIndex="14">
                 <DataItemTemplate>
                     <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="Orden" Caption="Orden"  VisibleIndex="15">
                 <DataItemTemplate>
                      <a href="/Views/Actividad/List?id=<%# Eval("IdTarea") %>" > <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

          </Columns>
   
         <SettingsDataSecurity AllowEdit="true" AllowDelete="true"/>
        
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>

            <SettingsSearchPanel Visible="True" ShowApplyButton="True" ShowClearButton="True" />
               <SettingsPager PageSize="10">
               </SettingsPager>
              <Settings ShowFooter="true" ShowHeaderFilterButton="true" />
              <SettingsPopup>
                  <HeaderFilter Height="200">
                     <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                 </HeaderFilter>
            </SettingsPopup>

        </dx:ASPxGridView>
    </div>
        
</asp:Content>
