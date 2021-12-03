<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="AplicacionWeb.Index" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administrador</title>
    <script type="text/javascript">
        var onKeyUp = function (field) {
            var v = this.processValue(this.getRawValue()),
                field;
            
            if (this.startDateField) {
                field = Ext.getCmp(this.startDateField);
                field.setMaxValue();
                this.dateRangeMax = null;
            } else if (this.endDateField) {
                field = Ext.getCmp(this.endDateField);
                field.setMinValue();
                this.dateRangeMin = null;
            }

            field.validate();
        };
    </script>
</head>
<body runat="server">
    <form runat="server" id="idform">
        <ext:ResourceManager runat="server" />
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:GroupTabPanel ID="GroupTabPanel1" runat="server" Region="Center" TabWidth="130" ActiveGroupIndex="0">
                    <Groups>

                        <%-- Pestaña Usuarios --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Usuarios" Icon="TagBlue" TabTip="Usuarios" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelUsuarios" runat="server" Title="Panel Usuarios" Padding="5" MonitorValid="true">
                                            <Items>
                                                <ext:TextField 
                                                    runat="server" 
                                                    ID="idUsuarios" 
                                                    IsRemoteValidation="true" 
                                                    FieldLabel="ID" 
                                                    DataIndex="id" 
                                                    Hidden="false" 
                                                    Disabled="true" 
                                                    AllowBlank="false" 
                                                    Text="" 
                                                    AnchorHorizontal="50%" />
                                                <ext:TextField 
                                                    runat="server" 
                                                    ID="contrasenias"
                                                    IsRemoteValidation="true" 
                                                    MinLength="10" 
                                                    MaxLength="10" 
                                                    FieldLabel="Contraseña" 
                                                    DataIndex="contraseña" 
                                                    AllowBlank="false" 
                                                    AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                </ext:TextField>
                                                <ext:TextField 
                                                    runat="server" 
                                                    ID="nombresCuentas" 
                                                    IsRemoteValidation="true" 
                                                    FieldLabel="Nombre Cuenta" 
                                                    DataIndex="nombrePersona" 
                                                    AllowBlank="false" 
                                                    AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                </ext:TextField>
                                                <ext:TextField 
                                                    runat="server" 
                                                    ID="nombrePersonas" 
                                                    IsRemoteValidation="true" 
                                                    MinLength="0" 
                                                    MaxLength="25" 
                                                    FieldLabel="Nombre Persona" 
                                                    DataIndex="nombreCuenta" 
                                                    AllowBlank="false" 
                                                    AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                </ext:TextField>
                                                <ext:ComboBox runat="server" ID="tipoUsuario" FieldLabel="Tipo Usuario" DataIndex="tipoUsuario" AllowBlank="false" AnchorHorizontal="50%" Editable="false"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Items>
                                                        <ext:ListItem Text="Administrador" Value="Administrador" />
                                                        <ext:ListItem Text="Profesor" Value="Profesor" />
                                                        <ext:ListItem Text="Estudiante" Value="Estudiante" />
                                                    </Items>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>
                                                <ext:Button runat="server" ID="botonGuardarUser" Text="Guardar" Icon="Disk">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarUser" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" >
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarUsuario" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Eliminar" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="EliminarUsuario" />
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" Text="Limpiar los Campos" Icon="Erase">
                                                    <DirectEvents>
                                                        <Click OnEvent="LimpiarCampos" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:FormPanel>

                                    </Items>

                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelUsuarios" Height="500" StripeRows="true" Title="Lista Usuarios" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store runat="server" ID="store_Usuarios">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="id" />
                                                                <ext:RecordField Name="nombreCuenta" />
                                                                <ext:RecordField Name="contraseña" />
                                                                <ext:RecordField Name="tipoUsuario" />
                                                                <ext:RecordField Name="nombrePersona" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="id" Header="ID" Width="80" DataIndex="id" />
                                                    <ext:Column ColumnID="contasenia" Header="Contraseña" Width="150" DataIndex="contraseña" />
                                                    <ext:Column ColumnID="nombreCuenta" Header="Nombre Cuenta" Width="150" DataIndex="nombreCuenta" />
                                                    <ext:Column ColumnID="tipoUsuario" Header="Tipo Usuario" Width="150" DataIndex="tipoUsuario" />
                                                    <ext:Column ColumnID="NombrePersona" Header="Nombre Persona" Width="150" DataIndex="nombrePersona" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelUsuarios}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Usuarios" Icon="TagBlue" TabTip="Recursos Humanos" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevos usuarios." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>



                        <%-- Pestaña Estudiantes --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Alumnos" Icon="TagBlue" TabTip="Alumnos" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelEstudiantes" runat="server" Title="Panel Estudiantes" Padding="5" MonitorValid="true">
                                            <Items>
                                                <ext:TextField runat="server" ID="idEstudiante" FieldLabel="ID" DataIndex="est_id_estudiante" Hidden="true" Disabled="true" AllowBlank="false" Text="" AnchorHorizontal="50%" />
                                                <ext:TextField runat="server" ID="cedulaEstudiante" IsRemoteValidation="true" MinLength="10" MaxLength="10" FieldLabel="Cédula" DataIndex="est_cedula" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="nombresEstudiante" IsRemoteValidation="true" FieldLabel="Nombres" DataIndex="est_nombres" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="apellidosEstudiante" IsRemoteValidation="true" FieldLabel="Apellidos" DataIndex="est_apellidos" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="telefonoEstudiante" IsRemoteValidation="true" MinLength="10" MaxLength="10" FieldLabel="Teléfono" DataIndex="est_telefono" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:Button runat="server" ID="botonGuardarEstudiante" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarEstudiante" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarEstudiante" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldEstudiante" />
                                                    </DirectEvents>
                                                </ext:Button>

                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarEstudiante}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>

                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelAlumnos" Height="500" StripeRows="true" Title="Lista Alumnos" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store runat="server" ID="store_alumnos">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="est_id_estudiante" />
                                                                <ext:RecordField Name="est_cedula" />
                                                                <ext:RecordField Name="est_nombres" />
                                                                <ext:RecordField Name="est_apellidos" />
                                                                <ext:RecordField Name="est_telefono" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idEstudiante" Header="ID Estudiante" Width="80" DataIndex="est_id_estudiante" />
                                                    <ext:Column ColumnID="cedulaEstudiante" Header="Cédula del Estudiante" Width="150" DataIndex="est_cedula" />
                                                    <ext:Column ColumnID="nombresEstudiante" Header="Nombres del Estudiante" Width="150" DataIndex="est_nombres" />
                                                    <ext:Column ColumnID="apellidosEstudiante" Header="Apellidos del Estudiante" Width="150" DataIndex="est_apellidos" />
                                                    <ext:Column ColumnID="telefonoEstudiante" Header="Teléfono del Estudiante" Width="150" DataIndex="est_telefono" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaEstudiantes" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelEstudiantes}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Alumnos" Icon="TagBlue" TabTip="Recursos Alumnos" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevas alumnos." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>

                        </ext:GroupTab>
                        <%-- Pestaña Docentes --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Docentes" Icon="TagBlue" TabTip="Docentes" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelDocentes" MonitorValid="true" runat="server" Title="Panel Docentes" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idDocente" FieldLabel="ID" DataIndex="doc_id_docente" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />
                                                <ext:TextField runat="server" ID="cedulaDocente" IsRemoteValidation="true" MinLength="10" MaxLength="10" FieldLabel="Cédula" DataIndex="doc_cedula" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="nombresDocente" IsRemoteValidation="true" FieldLabel="Nombres" DataIndex="doc_nombres" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="apellidosDocente" IsRemoteValidation="true" FieldLabel="Apellidos" DataIndex="doc_apellidos" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="telefonoDocente" IsRemoteValidation="true" MinLength="10" MaxLength="10" FieldLabel="Teléfono" DataIndex="doc_telefono" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:Button runat="server" ID="botonGuardarDocente" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarDocente" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarDocente" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldDocente" />
                                                    </DirectEvents>
                                                </ext:Button>

                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarDocente}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>
                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelDocentes" Height="500" StripeRows="true" Title="Lista Docentes" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_docentes" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="doc_id_docente" />
                                                                <ext:RecordField Name="doc_cedula" />
                                                                <ext:RecordField Name="doc_nombres" />
                                                                <ext:RecordField Name="doc_apellidos" />
                                                                <ext:RecordField Name="doc_telefono" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idDocente" Header="ID Docente" Width="80" DataIndex="doc_id_docente" />
                                                    <ext:Column ColumnID="cedulaDocente" Header="Cédula del Docente" Width="150" DataIndex="doc_cedula" />
                                                    <ext:Column ColumnID="nombresDocente" Header="Nombres del Docente" Width="150" DataIndex="doc_nombres" />
                                                    <ext:Column ColumnID="apellidosDocente" Header="Apellidos del Docente" Width="150" DataIndex="doc_apellidos" />
                                                    <ext:Column ColumnID="telefonoDocente" Header="Teléfono del Docente" Width="150" DataIndex="doc_telefono" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaDocentes" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelDocentes}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Docentes" Icon="TagBlue" TabTip="Recursos Docentes" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevos docentes." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Materias --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Materias" Icon="TagBlue" TabTip="Materias" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelMaterias" MonitorValid="true" runat="server" Title="Panel Materias" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idMateria" FieldLabel="ID" DataIndex="mat_id_materia" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />
                                                <ext:TextField runat="server" ID="codigoMateria" IsRemoteValidation="true" FieldLabel="Código Materia" DataIndex="mat_cod_materia" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="nombreMateria" IsRemoteValidation="true" FieldLabel="Nombre Materia" DataIndex="mat_nombre_materia" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:Button runat="server" ID="botonGuardarMateria" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarMateria" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarMateria" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldMateria" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarMateria}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>
                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelMaterias" Height="500" StripeRows="true" Title="Lista Materias" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_materias" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="mat_id_materia" />
                                                                <ext:RecordField Name="mat_cod_materia" />
                                                                <ext:RecordField Name="mat_nombre_materia" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idMateria" Header="Id Materia" Width="80" DataIndex="mat_id_materia" />
                                                    <ext:Column ColumnID="codigoMateria" Header="Código Materia" Width="150" DataIndex="mat_cod_materia" />
                                                    <ext:Column ColumnID="nombreMateria" Header="Nombre Materia" Width="150" DataIndex="mat_nombre_materia" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaMaterias" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelMaterias}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Materias" Icon="TagBlue" TabTip="Recursos Materias" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevas materias." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Notas --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Notas" Icon="TagBlue" TabTip="Notas" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelNotas" MonitorValid="true" runat="server" Title="Panel Notas" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idNota" FieldLabel="ID" DataIndex="not_id_nota" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_alumnos"
                                                    DisplayField="est_nombres"
                                                    ValueField="est_id_estudiante"
                                                    ID="idNotaEstudiante"
                                                    EmptyText="ID Estudiante"
                                                    DataIndex="est_id_estudiante"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-estudiante"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-estudiante">
							                                         <h3>{est_apellidos} {est_nombres}</h3>
                                                                        {est_cedula}
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>
                                                <ext:TextField runat="server" ID="idNotaQuimestre" FieldLabel="ID Quimestre" DataIndex="qui_id_quimestre" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:TextField runat="server" ID="idNotaClase" FieldLabel="ID Clase" DataIndex="cla_id_clase" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="idNota1" IsRemoteValidation="true" FieldLabel="Nota 1" EmptyText="Ejemplo: 9,00" DataIndex="not_nota1" AllowBlank="false" AnchorHorizontal="50%">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:TextField runat="server" ID="idNota2" IsRemoteValidation="true" FieldLabel="Nota 2" EmptyText="Ejemplo: 9,00" DataIndex="not_nota2" AllowBlank="false" AnchorHorizontal="50%">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:TextField runat="server" ID="idNota3" FieldLabel="Nota 3" EmptyText="Ejemplo: 9,00" DataIndex="not_nota3" AllowBlank="false" AnchorHorizontal="50%">
                                                </ext:TextField>

                                                <ext:TextField runat="server" ID="idNota4" FieldLabel="Nota 4" EmptyText="Ejemplo: 9,00" DataIndex="not_nota4" AllowBlank="false" AnchorHorizontal="50%">
                                                </ext:TextField>

                                                <ext:Button runat="server" Text="Guardar" ID="botonGuardarNota" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarNotas" />
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarNotas" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldNota" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarNota}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelNotas" Height="500" StripeRows="true" Title="Lista Notas" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_notas" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="not_id_nota" />
                                                                <ext:RecordField Name="est_id_estudiante" />
                                                                <ext:RecordField Name="qui_id_quimestre" />
                                                                <ext:RecordField Name="cla_id_clase" />
                                                                <ext:RecordField Name="not_nota1" />
                                                                <ext:RecordField Name="not_nota2" />
                                                                <ext:RecordField Name="not_nota3" />
                                                                <ext:RecordField Name="not_nota4" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idNota" Header="Id Nota" Width="80" DataIndex="not_id_nota" />
                                                    <ext:Column ColumnID="idEstudiante" Header="ID Estudiante" Width="150" DataIndex="est_id_estudiante" />
                                                    <ext:Column ColumnID="idQuimestre" Header="ID Quimestre" Width="150" DataIndex="qui_id_quimestre" />
                                                    <ext:Column ColumnID="idClase" Header="ID Clase" Width="80" DataIndex="cla_id_clase" />
                                                    <ext:Column ColumnID="nota1" Header="Nota 1" Width="80" DataIndex="not_nota1" />
                                                    <ext:Column ColumnID="nota2" Header="Nota 2" Width="80" DataIndex="not_nota2" />
                                                    <ext:Column ColumnID="nota3" Header="Nota 3" Width="80" DataIndex="not_nota3" />
                                                    <ext:Column ColumnID="nota4" Header="Nota 4" Width="80" DataIndex="not_nota4" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaNotas" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelNotas}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Notas" Icon="TagBlue" TabTip="Recursos Notas" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevas notas." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Quimestres --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Quimestres" Icon="TagBlue" TabTip="Quimestres" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelQuimestres" MonitorValid="true" runat="server" Title="Panel Quimestres" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idQuimestre" FieldLabel="ID" DataIndex="qui_id_quimestre" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />
                                                <ext:TextField runat="server" ID="numeroQuimestre" IsRemoteValidation="true" FieldLabel="Número Quimestre" DataIndex="qui_numero_quimestre" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>
                                                <ext:DateField runat="server" ID="fechaInicio" Format="yyyy-MM-dd HH:mm:ss" ShowToday="true" Vtype="daterange" FieldLabel="Fecha Inicio" DataIndex="qui_fecha_inicio" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    EnableKeyEvents="true">
                                                    <CustomConfig>
                                                        <ext:ConfigItem Name="endDateField" Value="#{fechaFin}" Mode="Value" />
                                                    </CustomConfig>
                                                    <Listeners>
                                                        <KeyUp Fn="onKeyUp" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:DateField runat="server" ID="fechaFin" Format="yyyy-MM-dd HH:mm:ss" Vtype="daterange" FieldLabel="Fecha Fin" DataIndex="qui_fecha_fin" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    EnableKeyEvents="true">
                                                    <CustomConfig>
                                                        <ext:ConfigItem Name="startDateField" Value="#{fechaInicio}" Mode="Value" />
                                                    </CustomConfig>
                                                    <Listeners>
                                                        <KeyUp Fn="onKeyUp" />
                                                    </Listeners>
                                                </ext:DateField>

                                                <ext:Button runat="server" ID="botonGuardarQuimestre" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarQuimestre" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="UpdateQuimestre" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldQuimestre" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarQuimestre}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelQuimestres" Height="500" StripeRows="true" Title="Lista Quimestre" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_quimestre" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="qui_id_quimestre" />
                                                                <ext:RecordField Name="qui_fecha_inicio" Type="Date"/>
                                                                <ext:RecordField Name="qui_fecha_fin" Type="Date"/>
                                                                <ext:RecordField Name="qui_numero_quimestre" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idQuimestre" Header="Id Quimestre" Width="80" DataIndex="qui_id_quimestre"  />
                                                    <ext:Column ColumnID="fechaInicio" Header="Fecha de Inicio" Width="150" DataIndex="qui_fecha_inicio" />
                                                    <ext:Column ColumnID="fechaFin" Header="Fecha de Fin" Width="150" DataIndex="qui_fecha_fin" />
                                                    <ext:Column ColumnID="numeroQuimestre" Header="Número Quimestre" Width="80" DataIndex="qui_numero_quimestre" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaQuimestres" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelQuimestres}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Quimestres" Icon="TagBlue" TabTip="Recursos Quimestres" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevos quimestres." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Asistencia --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Asistencias" Icon="TagBlue" TabTip="Asistencias" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelAsistencias" MonitorValid="true" runat="server" Title="Panel Asistencias" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idAsistencia" FieldLabel="ID" DataIndex="asi_id_asistencia" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_alumnos"
                                                    DisplayField="est_nombres"
                                                    ValueField="est_id_estudiante"
                                                    DataIndex="est_id_estudiante"
                                                    ID="idAsistenciaEstudiante"
                                                    EmptyText="ID Estudiante"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-estudiante"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-estudiante">
							                                         <h3>{est_apellidos} {est_nombres}</h3>
                                                                        {est_cedula}
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>
                                                <ext:TextField runat="server" ID="idAsistenciaClase" FieldLabel="ID Clase" DataIndex="cla_id_clase" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:DateField runat="server" ID="fechaAsistencia" Format="yyyy-MM-dd HH:mm:ss" Vtype="daterange" FieldLabel="Fecha Asistencia" DataIndex="asi_fecha_asistencia" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side" />
                                                <ext:ComboBox runat="server" ID="tomarAsistencia" FieldLabel="Tomar Asistencia" DataIndex="asi_tomar_asistencia" AllowBlank="false" AnchorHorizontal="50%" Editable="false"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Items>
                                                        <ext:ListItem Text="Si" Value="true" />
                                                        <ext:ListItem Text="No" Value="false" />
                                                    </Items>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:Button runat="server" ID="botonGuardarAsistencia" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarAsistencia" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualziar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarAsistencia" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldAsistencia" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarAsistencia}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelAsistencia" Height="500" StripeRows="true" Title="Lista Asistencias" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_asistencia" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="asi_id_asistencia" />
                                                                <ext:RecordField Name="est_id_estudiante" />
                                                                <ext:RecordField Name="cla_id_clase" />
                                                                <ext:RecordField Name="asi_fecha_asistencia" />
                                                                <ext:RecordField Name="asi_tomar_asistencia" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idAsistencia" Header="Id Asistencia" Width="80" DataIndex="asi_id_asistencia" />
                                                    <ext:Column ColumnID="idEstudiante" Header="ID Estudiante" Width="150" DataIndex="est_id_estudiante" />
                                                    <ext:Column ColumnID="idClase" Header="ID Clase" Width="150" DataIndex="cla_id_clase" />
                                                    <ext:Column ColumnID="fechaAsistencia" Header="Fecha Asistencia" Width="150" DataIndex="asi_fecha_asistencia" />
                                                    <ext:Column ColumnID="tomarAsistencia" Header="Asistio?" Width="80" DataIndex="asi_tomar_asistencia" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaAsistencias" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelAsistencias}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Asistencias" Icon="TagBlue" TabTip="Recursos Asistencias" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras registrar las asistencias de estudiantes." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Aula --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Aulas" Icon="TagBlue" TabTip="Aulas" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelAulas" MonitorValid="true" runat="server" Title="Panel Aulas" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idAula" FieldLabel="ID" DataIndex="au_id_aula" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />
                                                <ext:TextField runat="server" ID="nombreAula" FieldLabel="Nombre Aula" DataIndex="au_nombre_aula" AllowBlank="false" AnchorHorizontal="50%"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <RemoteValidation OnValidation="CheckField" />
                                                </ext:TextField>

                                                <ext:Button runat="server" ID="botonGuardarAula" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarAula" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarAula" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldAula" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarAula}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelAula" Height="500" StripeRows="true" Title="Lista Aulas" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_aula" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="au_id_aula" />
                                                                <ext:RecordField Name="au_nombre_aula" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idAula" Header="Id Aula" Width="80" DataIndex="au_id_aula" />
                                                    <ext:Column ColumnID="nombreAula" Header="Nombre del Aula" Width="150" DataIndex="au_nombre_aula" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaAulas" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelAulas}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Aula" Icon="TagBlue" TabTip="Recursos Aulas" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevas aulas." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        <%-- Pestaña Clase --%>
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="Clases" Icon="TagBlue" TabTip="Clases" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelClases" MonitorValid="true" runat="server" Title="Panel Clases" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idClase" FieldLabel="ID" DataIndex="cla_id_clase" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_materias"
                                                    DisplayField="mat_nombre_materia"
                                                    ValueField="mat_id_materia"
                                                    ID="idClaseMateria"
                                                    EmptyText="ID Materia"
                                                    DataIndex="mat_id_materia"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-materia"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-materia">
							                                         <h3>{mat_nombre_materia}</h3>
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_docentes"
                                                    DisplayField="doc_nombres"
                                                    ValueField="doc_id_docente"
                                                    ID="idClaseDocente"
                                                    EmptyText="ID Docente"
                                                    DataIndex="doc_id_docente"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-docente"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-docente">
							                                         <h3>{doc_apellidos} {doc_nombres}</h3>
                                                                        {doc_cedula}
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_aula"
                                                    DisplayField="au_nombre_aula"
                                                    ValueField="au_id_aula"
                                                    ID="idClaseAula"
                                                    DataIndex="au_id_aula"
                                                    EmptyText="ID Aula"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-aula"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-aula">
							                                         <h3>{au_nombre_aula}</h3>
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:Button runat="server" ID="botonGuardarClase" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarClase" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarClase" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldClase" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarClase}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>

                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelClase" Height="500" StripeRows="true" Title="Lista Clases" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_clases" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="cla_id_clase" />
                                                                <ext:RecordField Name="mat_id_materia" />
                                                                <ext:RecordField Name="doc_id_docente" />
                                                                <ext:RecordField Name="au_id_aula" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idClase" Header="ID Clase" Width="80" DataIndex="cla_id_clase" />
                                                    <ext:Column ColumnID="idMateria" Header="ID Materia" Width="80" DataIndex="mat_id_materia" />
                                                    <ext:Column ColumnID="idDocente" Header="ID Docente" Width="80" DataIndex="doc_id_docente" />
                                                    <ext:Column ColumnID="idAula" Header="ID Aula" Width="80" DataIndex="au_id_aula" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaClases" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelClases}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Clase" Icon="TagBlue" TabTip="Recursos Clases" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras ingresar nuevas clases." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>

                        <%-- Pestaña VISTA Clase 
                        
                        <ext:GroupTab runat="server" MainItem="1">
                            <Items>
                                <ext:Panel runat="server" TrackMouseOver="true" Title="VISTA Clases" Icon="TagBlue" TabTip="Vista Clases" Padding="10">
                                    <Items>
                                        <ext:FormPanel ID="formPanelVistaClases" MonitorValid="true" runat="server" Title="Panel Clases" Padding="5">
                                            <Items>
                                                <ext:TextField runat="server" ID="idClaseVista" FieldLabel="ID" DataIndex="cla_id_clase" Hidden="true" Disabled="true" AllowBlank="false" AnchorHorizontal="50%" />
                                                
                                                <ext:ComboBox runat="server"
                                                    StoreID="store_materias"
                                                    DisplayField="mat_nombre_materia"
                                                    ValueField="mat_id_materia"
                                                    ID="idClaseVistaMateria"
                                                    EmptyText="ID Materia"
                                                    DataIndex="mat_id_materia"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-materia"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-materia">
							                                         <h3>{mat_nombre_materia}</h3>
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_docentes"
                                                    DisplayField="doc_nombres"
                                                    ValueField="doc_id_docente"
                                                    ID="idClaseVistaDocente"
                                                    EmptyText="ID Docente"
                                                    DataIndex="doc_id_docente"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-docente"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-docente">
							                                         <h3>{doc_apellidos} {doc_nombres}</h3>
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:ComboBox runat="server"
                                                    StoreID="store_aula"
                                                    DisplayField="au_nombre_aula"
                                                    ValueField="au_id_aula"
                                                    ID="idClaseVistaAula"
                                                    DataIndex="au_id_aula"
                                                    EmptyText="ID Aula"
                                                    Editable="false"
                                                    TypeAhead="true"
                                                    Mode="Local"
                                                    ForceSelection="true"
                                                    TriggerAction="All"
                                                    ItemSelector="div.list-item-aula"
                                                    SelectOnFocus="true"
                                                    IndicatorIcon="Add"
                                                    IndicatorText="Añadir"
                                                    MsgTarget="Side"
                                                    IsRemoteValidation="true">
                                                    <Template runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item-aula">
							                                         <h3>{au_nombre_aula}</h3>
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <RemoteValidation OnValidation="CheckCombo" ValidationEvent="select" EventOwner="Field"></RemoteValidation>
                                                </ext:ComboBox>

                                                <ext:Button runat="server" ID="botonGuardarVistaClase" Text="Guardar" Icon="Disk" Scale="Large" IconAlign="Bottom">
                                                    <DirectEvents>
                                                        <Click OnEvent="InsertarVistaClase" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Actualizar" Icon="Reload" Scale="Large" IconAlign="Bottom">
                                                    <ToolTips>
                                                        <ext:ToolTip runat="server" Title="Para actualizar, primero seleccione una fila!" />
                                                    </ToolTips>
                                                    <DirectEvents>
                                                        <Click OnEvent="ActualizarClaseVista" />
                                                    </DirectEvents>
                                                </ext:Button>

                                                <ext:Button runat="server" Text="Limpiar Campos" Icon="Decline">
                                                    <DirectEvents>
                                                        <Click OnEvent="CleanTextFieldVistaClase" />
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                            <Listeners>
                                                <ClientValidation Handler="#{botonGuardarVistaClase}.setDisabled(!valid);" />
                                            </Listeners>
                                        </ext:FormPanel>
                                    </Items>
                                    <Items>
                                        <ext:GridPanel runat="server" ID="gridPanelVistaClase" Height="500" StripeRows="true" Title="Lista Clases" TrackMouseOver="true">
                                            <Store>
                                                <ext:Store ID="store_vistaClases" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="cla_id_clase" />
                                                                <ext:RecordField Name="doc_id_docente" />
                                                                <ext:RecordField Name="doc_nombres" />
                                                                <ext:RecordField Name="doc_apellidos" />
                                                                <ext:RecordField Name="mat_id_materia" />
                                                                <ext:RecordField Name="mat_nombre_materia" />
                                                                <ext:RecordField Name="au_id_aula" />
                                                                <ext:RecordField Name="au_nombre_aula" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <LoadMask ShowMask="true" />
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn />
                                                    <ext:Column ColumnID="idClase" Header="ID Clase" Width="80" DataIndex="cla_id_clase" />
                                                    <ext:Column ColumnID="idDocente" Hidden="true" Header="ID Docente" Width="80" DataIndex="doc_id_docente" />
                                                    <ext:Column ColumnID="nombresDocente" Header="Nombres del Docente" Width="150" DataIndex="doc_nombres" />
                                                    <ext:Column ColumnID="apellidosDocente" Header="Apellidos del Docente" Width="150" DataIndex="doc_apellidos" />
                                                    <ext:Column ColumnID="idMateria" Hidden="true" Header="ID Materia" Width="80" DataIndex="mat_id_materia" />
                                                    <ext:Column ColumnID="nombreMateria" Header="Nombre Materia" Width="150" DataIndex="mat_nombre_materia" />
                                                    <ext:Column ColumnID="idAula" Hidden="true" Header="ID Aula" Width="80" DataIndex="au_id_aula" />
                                                    <ext:Column ColumnID="nombreAula" Header="Nombre del Aula" Width="150" DataIndex="au_nombre_aula" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="seleccionFilaVistaClases" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{formPanelVistaClases}.getForm().loadRecord(record);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="VISTA Clases" Icon="TagBlue" TabTip="Recursos VISTA Clases" Padding="10">
                                    <Items>
                                        <ext:Label runat="server" Text="Aquí podras visualizar VISTA clases." Region="Center"></ext:Label>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:GroupTab>
                        --%>
                    </Groups>
                </ext:GroupTabPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
