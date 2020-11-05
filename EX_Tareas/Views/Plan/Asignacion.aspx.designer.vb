'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Asignacion
    
    '''<summary>
    '''Control idEmpresa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents idEmpresa As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control empresa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents empresa As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control idContrato.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents idContrato As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control idProyecto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents idProyecto As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control GuardarDB.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GuardarDB As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control gdvAsignacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gdvAsignacion As Global.DevExpress.Web.ASPxGridView
    
    '''<summary>
    '''Control idPlantilla.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents idPlantilla As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control nombrePlantilla.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents nombrePlantilla As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control idTarea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents idTarea As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control id_Tarea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents id_Tarea As Global.System.Web.UI.HtmlControls.HtmlInputHidden
    
    '''<summary>
    '''Control tarea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tarea As Global.System.Web.UI.HtmlControls.HtmlInputText
    
    '''<summary>
    '''Control tipoTarea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tipoTarea As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control estadoTarea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents estadoTarea As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control tipoServicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tipoServicio As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control tareaValor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tareaValor As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control fechaInicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fechaInicio As Global.System.Web.UI.HtmlControls.HtmlInputGenericControl
    
    '''<summary>
    '''Control fechaFinal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fechaFinal As Global.System.Web.UI.HtmlControls.HtmlInputGenericControl
    
    '''<summary>
    '''Control descripcion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents descripcion As Global.System.Web.UI.HtmlControls.HtmlTextArea
    
    '''<summary>
    '''Control tiempoEstimado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tiempoEstimado As Global.System.Web.UI.HtmlControls.HtmlInputGenericControl
    
    '''<summary>
    '''Control orden.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents orden As Global.System.Web.UI.HtmlControls.HtmlInputGenericControl
    
    '''<summary>
    '''Control BtnGuardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents BtnGuardar As Global.System.Web.UI.WebControls.Button
End Class
