<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Views/MasterPage/Site.Master" CodeBehind="Tareas.aspx.vb" Inherits="EX_Tareas.Tareas" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="/Scripts/Tarea/nuevaTarea.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-3.3.1.min.js"></script>
    <link href="/Content/nuevaTarea.css" rel="stylesheet" type="text/css">

         <div id="nuevaTarea" class="awindow" >
            <div class="awindow-content">

            <span class="close" onclick="OcultarNuevaTareaPopUp()">&times;</span>

             <asp:HiddenField ID="id_Tarea" runat="server" />
             <label id="lblIdTarea"></label><br />

            <label>Plantilla</label>
            <input type="text" id="id_Plantilla" name="idPlantilla" runat="server" class="itype" disabled/><br />

            <label>Tarea</label>
            <input type="text" id="tarea" name="tarea" runat="server" class="itype"/><br />

            <label>Tipo tarea</label>
            <asp:DropDownList ID="tipoTarea" runat="server" class="itype"></asp:DropDownList><br />

            <label>Estado Tarea</label>
            <asp:DropDownList ID="estadoTarea" runat="server" class="itype"></asp:DropDownList><br />

            <label>Tipo Servicio</label>
            <asp:DropDownList ID="tipoServicio" runat="server" class="itype"></asp:DropDownList><br />

             <label>Tarea Valor</label>
            <asp:DropDownList ID="tareaValor" runat="server" class="itype"></asp:DropDownList><br />

            <label>Fecha Inicio</label>
            <input type="date" id="fechaInicio" name="fechaInicio"  runat="server" class="itype"/><br />

            <label>Fecha Final</label>
            <input type="date" id="fechaFinal" name="fechaFinal"  runat="server" class="itype"/><br />
               
            <label>Descripcion</label>
            <textarea id="descripcion" name="descripcion" rows="2" cols="50"  resize="none" runat="server" ></textarea><br />

            <label>Tiempo Estimado</label>
            <input type="number" id="tiempoEstimado" name="tiempoEstimado"  runat="server" min="1" max="100000" step="1" class="itype"/> <br />   

            <label id="lblOrden">Orden</label>
            <input type="number" id="orden" name="orden"  runat="server" min="1" max="100" step="1" class="itype"/> <br /> <br /> 
                
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" style ="background-color:forestgreen;width:150px;border:0px;color:white;" />

        </div>
    </div>

    <div id="encabezadoPlantillaStr" style="padding:10px;">
        <span >Id Plantilla</span>
        <input type = "text" id="idPlantillaStr" name="idPlantillaStr" runat="server" class="itype" disabled />
        <span >Nombre Plantilla</span>
        <input type ="text" id="nombrePlantillaStr" name="nombrePlantillaStr" runat="server"  class="itype" disabled />
    </div>
    

     <div  style="width:auto;background-color:whitesmoke;height:50%;">
           <div>
               <input type="button" id="nuevo" name="nuevo" value="Nueva" onclick="MostrarNuevaTareaPopUp('')" style ="background-color:forestgreen;width:150px;border:0px;color:white;"/>
               <asp:Button ID="rPlantilla" runat="server" Text="Plantillas" style ="background-color:dimgray;width:150px;border:0px;color:white;" />

          </div>
        
        <dx:aspxgridview ID="gdvTareas" runat="server" KeyFieldName="IdTarea" Width="100%" 
         AutoGenerateColumns="false"
         nHeaderFilterFillItems="gdvTareas_HeaderFilterFillItems" 
         EnableRowsCache="true" 
         ClientInstanceName="gdvTareas">

               <SettingsBehavior  AllowSelectByRowClick = "true" />
            
            <Columns>
               <dx:GridViewCommandColumn  Caption="Eliminar" ShowDeleteButton="true"  VisibleIndex="1" >
              <CellStyle ForeColor="Navy"> </CellStyle> </dx:GridViewCommandColumn>

             <dx:GridViewDataColumn FieldName="IdTarea" Caption="Editar" Visible="true" VisibleIndex="0" CellStyle-ForeColor="#666666"> 
                  <DataItemTemplate>
                    <a href="javascript:EditRow('<%# Eval("IdTarea") %>')" style="color:navy;text-decoration: underline navy" >Editar</a>
                  </DataItemTemplate>
              </dx:GridViewDataColumn>

                  <dx:GridViewDataColumn FieldName="IdPlantilla" Caption="Id Plantilla" Visible="true" VisibleIndex="2" > 
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>
    
              <dx:GridViewDataColumn FieldName="IdTarea" Caption="Id Tarea" Visible="true" VisibleIndex="3" > 
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="Tarea" Caption="Tarea"  VisibleIndex="4" >
                 <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                 </DataItemTemplate>
              </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="Descripcion" Caption="Descripcion"  VisibleIndex="5" >
                   <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                  </DataItemTemplate>
               </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="IdTipoTarea" Caption="Id Tipo Tarea" Visible="false"  VisibleIndex="6" >
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="TipoTarea" Caption="Tipo Tarea"  VisibleIndex="7" >
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="IdEstadoTarea" Caption="Id Estado Tarea" Visible="false"  VisibleIndex="8">
                <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="EstadoTarea" Caption="Estado Tarea"  VisibleIndex="9">
                <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="IdTipoServicio" Caption="Id Tipo Servicio" Visible="false"   VisibleIndex="10">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="TipoServicio" Caption="Tipo Servicio"    VisibleIndex="11">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="IdTareaValor" Caption="Id Tarea Valor" Visible="false"  VisibleIndex="12">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="TareaValor" Caption="Tarea Valor"  VisibleIndex="13">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaInicio" Caption="Fecha Inicio"  VisibleIndex="14">
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaFin" Caption="Fecha Fin"  VisibleIndex="15">
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
            
               <dx:GridViewDataColumn FieldName="TiempoEstimado" Caption="Tiempo Estimado"  VisibleIndex="16">
                 <DataItemTemplate>
                     <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="Orden" Caption="Orden"  VisibleIndex="17">
                 <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

          </Columns>
   
         <SettingsDataSecurity  AllowDelete="true"/>
        
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

        </dx:aspxgridview>
    </div>
</asp:Content>
