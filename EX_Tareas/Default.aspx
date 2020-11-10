<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Views/MasterPage/Site.Master" CodeBehind="Default.aspx.vb" Inherits="EX_Tareas._Default1" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <script type="text/javascript" src="/Scripts/Plantilla/nuevaPlantilla.js"></script>
       <script type="text/javascript" src="/Scripts/jquery-3.3.1.min.js"></script>
      <link href="/Content/nuevaTarea.css" rel="stylesheet" type="text/css">


        <div id="nuevaTarea" class="awindow" >
            <div class="awindow-content">

            <span class="close" onclick="OcultarNuevaTareaPopUp()">&times;</span>

             <asp:HiddenField ID="idPlantilla" runat="server" />
             <label id="lblIdPlantilla"></label><br />

            <label> Nombre de la plantilla </label><br />
            <input type="text" id="nombrePlantilla" name="nombrePlantilla" runat="server" class="itype"/><br />

            <div style="text-align:center;">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" style ="background-color:forestgreen;width:150px;border:0px;color:white;" />
            </div> 

        </div>
    </div>



       <div  style="width:auto;background-color:whitesmoke;height:50%;">
           <div>
               <input type="button" id="nuevo" name="nuevo" value="Nueva" onclick="MostrarNuevaTareaPopUp('')" style ="background-color:forestgreen;width:150px;border:0px;color:white;float:left;"/>
                 <asp:Button ID="Asignacion" runat="server" Text="Asignacion" style ="background-color:dimgray;width:150px;border:0px;color:white;float:right;" />
          </div>
        
        <dx:ASPxGridView ID="gdvPlantillas" runat="server" KeyFieldName="IdPlantilla" Width="100%" 
         AutoGenerateColumns="false"
         nHeaderFilterFillItems="gdvPlantillas_HeaderFilterFillItems" 
         EnableRowsCache="true" 
         ClientInstanceName="gdvPlantillas"
    >

               <SettingsBehavior  AllowSelectByRowClick = "true" />
            
            <Columns>
               <dx:GridViewCommandColumn  Caption="" ShowDeleteButton="true"  ShowEditButton="true"  VisibleIndex="0" >
              <CellStyle ForeColor="Navy"> </CellStyle> </dx:GridViewCommandColumn>     

              <dx:GridViewDataColumn FieldName="IdPlantilla" Caption="Id Plantilla" Visible="true" VisibleIndex="1" > 
                  <DataItemTemplate>
                <a href ="Views/Actividad/Tareas.aspx?idPlantilla=<%# Eval("IdPlantilla") %>"> <%# Container.Text %> </a>
                   </DataItemTemplate>
              </dx:GridViewDataColumn>

              <dx:GridViewDataColumn FieldName="Nombre" Caption="Plantilla"  VisibleIndex="2" >
                 <DataItemTemplate>
                    <a href ="Views/Actividad/Tareas.aspx?idPlantilla=<%# Eval("IdPlantilla") %>"> <%# Container.Text %> </a>
                 </DataItemTemplate>
              </dx:GridViewDataColumn>

                 <dx:GridViewDataColumn FieldName="FechaCreacion" Caption="Fecha"  VisibleIndex="3" >
                 <DataItemTemplate>
                    <a href ="Views/Actividad/Tareas.aspx?idPlantilla=<%# Eval("IdPlantilla") %>"> <%# Container.Text %> </a>
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

        </dx:ASPxGridView>
    </div>


</asp:Content>
