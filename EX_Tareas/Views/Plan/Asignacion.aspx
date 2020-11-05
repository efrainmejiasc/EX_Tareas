<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Views/MasterPage/Site.Master" CodeBehind="Asignacion.aspx.vb" Inherits="EX_Tareas.Asignacion" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="gdvAsignacion" runat="server" Width="100%" 
         AutoGenerateColumns="true"
         nHeaderFilterFillItems="gdvAsignacion_HeaderFilterFillItems" 
         ClientInstanceName="gdvAsignacion">

          <SettingsBehavior  AllowSelectByRowClick = "true" />

         
    </dx:ASPxGridView>

</asp:Content>
