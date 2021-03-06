﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Views/MasterPage/Site.Master" CodeBehind="Asignacion.aspx.vb" Inherits="EX_Tareas.Asignacion" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <script type="text/javascript" src="/Scripts/Plan/asignacion.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-3.3.1.min.js"></script>
    <link href="/Content/nuevaTarea.css" rel="stylesheet" type="text/css">

 <div style="padding:10px;">
     <span >Id Empresa</span>
     <input type="text" id="idEmpresa" name="idEmpresa" runat="server" disabled />
     <span >Empresa</span>
      <input type="text" id="empresa" name="empresa" runat="server" disabled />
      <span >Contrato</span>
      <input type="text" id="idContrato" name="idContrato" runat="server" disabled />
      <span >Proyecto</span>
      <input type="text" id="idProyecto" name="idProyecto" runat="server" disabled />
     <asp:Button ID="GuardarDB" runat="server" Text="Guardar" style ="background-color:forestgreen;width:150px;border:0px;color:white;" />

</div>


    <dx:ASPxGridView ID="gdvAsignacion" runat="server"  KeyFieldName="IdTarea" Width="100%" 
         AutoGenerateColumns="true"
         nHeaderFilterFillItems="gdvAsignacion_HeaderFilterFillItems" 
         ClientInstanceName="gdvAsignacion">

         <SettingsBehavior  AllowSelectByRowClick = "true" />
         <SettingsDataSecurity  AllowDelete="true"/>

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

                <dx:GridViewDataColumn FieldName="Nombre" Caption="Plantilla" Visible="true" VisibleIndex="3" > 
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>
    
              <dx:GridViewDataColumn FieldName="IdTarea" Caption="Id Tarea" Visible="true" VisibleIndex="4" > 
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="Tarea" Caption="Tarea"  VisibleIndex="5" >
                 <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                 </DataItemTemplate>
              </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="Descripcion" Caption="Descripcion"  VisibleIndex="6" >
                   <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                  </DataItemTemplate>
               </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="IdTipoTarea" Caption="Id Tipo Tarea" Visible="false"  VisibleIndex="7" >
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="TipoTarea" Caption="Tipo Tarea"  VisibleIndex="8" >
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="IdEstadoTarea" Caption="Id Estado Tarea" Visible="false"  VisibleIndex="9">
                <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="EstadoTarea" Caption="Estado Tarea"  VisibleIndex="10">
                <DataItemTemplate>
                    <a> <%# Container.Text %> </a>
                </DataItemTemplate>
               </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="IdTipoServicio" Caption="Id Tipo Servicio" Visible="false"   VisibleIndex="11">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="TipoServicio" Caption="Tipo Servicio"    VisibleIndex="12">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="IdTareaValor" Caption="Id Tarea Valor" Visible="false"  VisibleIndex="13">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                <dx:GridViewDataColumn FieldName="TareaValor" Caption="Tarea Valor"  VisibleIndex="14">
                  <DataItemTemplate>
                 <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaInicio" Caption="Fecha Inicio"  VisibleIndex="15">
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaFin" Caption="Fecha Fin"  VisibleIndex="16">
                  <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
                 </dx:GridViewDataColumn>
            
               <dx:GridViewDataColumn FieldName="TiempoEstimado" Caption="Tiempo Estimado"  VisibleIndex="17">
                 <DataItemTemplate>
                     <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="Orden" Caption="Orden"  VisibleIndex="18">
                 <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

               <dx:GridViewDataColumn FieldName="HoraInicio" Caption="Hora Inicio"  VisibleIndex="19">
                 <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="HoraFin" Caption="Hora Fin"  VisibleIndex="20">
                 <DataItemTemplate>
                      <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="FechaTerminado" Caption="Fecha Terminado"  VisibleIndex="21">
               <DataItemTemplate>
                <a> <%# Container.Text %> </a>
                </DataItemTemplate>
              </dx:GridViewDataColumn>

          </Columns>

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


            <div id="asignacionFmr" class="awindow" >
            <div class="awindow-content">
            <span class="close" onclick="OcultarAsignacionPopUp()">&times;</span>

            <span>Id Plantilla</span>
            <input type="text" id="idPlantilla" name="idPlantilla" runat="server" class="itype" disabled/><br />

            <span>Plantilla</span>
            <input type="text" id="nombrePlantilla" name="nombrePlantilla" runat="server" class="itype" disabled/><br />

             <span>Id Tarea</span>
            <input type="text" id="idTarea" name="IdTarea" runat="server" class="itype" disabled/><br />
            <input type="hidden" id="id_Tarea" name="id_Tarea" runat="server" />

            <span>Tarea</span>
            <input type="text" id="tarea" name="tarea" runat="server" class="itype"/><br />

            <span>Tipo tarea</span>
            <asp:DropDownList ID="tipoTarea" runat="server" class="itype"></asp:DropDownList><br />

            <span>Estado Tarea</span>
            <asp:DropDownList ID="estadoTarea" runat="server" class="itype"></asp:DropDownList><br />

            <span>Tipo Servicio</span>
            <asp:DropDownList ID="tipoServicio" runat="server" class="itype"></asp:DropDownList><br />

             <span>Tarea Valor</span>
            <asp:DropDownList ID="tareaValor" runat="server" class="itype"></asp:DropDownList><br />

            <span>Fecha Inicio</span>
            <input type="date" id="fechaInicio" name="fechaInicio"  runat="server" class="itype"/><br />

            <span>Fecha Final</span>
            <input type="date" id="fechaFinal" name="fechaFinal"  runat="server" class="itype"/><br />

            <span>Hora Inicio</span>
            <input type="time" id="horaInicio" name="horaInicio"  runat="server" class="itype"/><br />

            <span>Hora Fin</span>
            <input type="time" id="horaFin" name="horaFin"  runat="server" class="itype"/><br />

            <span>Fecha Finalizado</span>
            <input type="date" id="fechaTerminado" name="fechaTerminado"  runat="server" class="itype"/><br />
                
            <span>Descripcion</span>
            <textarea id="descripcion" name="descripcion" rows="2" cols="50"  resize="none" runat="server" ></textarea><br />

            <span>Tiempo Estimado</span>
            <input type="number" id="tiempoEstimado" name="tiempoEstimado"  runat="server" min="1" max="100000" step="1" class="itype"/> <br />   

            <span id="lblOrden">Orden</span>
            <input type="number" id="orden" name="orden"  runat="server" min="1" max="100" step="1" class="itype"/> <br /> <br /> 
                
           <asp:Button ID="BtnGuardar" runat="server" Text="Actualizar" style ="background-color:forestgreen;width:150px;border:0px;color:white;" />
        </div>
    </div>
   
</asp:Content>
