<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainBox
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainBox))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnLogin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCustomers = New System.Windows.Forms.ToolStripButton()
        Me.btnProducts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnReport = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutenticarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MisDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosDeLaCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresoraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BusquedaDeVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecargarListadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.CuentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoríasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlmacenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SesionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformaciónDeLaSesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.mnuCell = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CancelarVentaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.mnuCell.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 63)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(699, 340)
        Me.DataGridView1.TabIndex = 10
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLogin, Me.ToolStripSeparator3, Me.btnNew, Me.ToolStripSeparator4, Me.btnCustomers, Me.btnProducts, Me.ToolStripSeparator7, Me.btnReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(699, 39)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnLogin
        '
        Me.btnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(36, 36)
        Me.btnLogin.Text = "Sesión"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Enabled = False
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(36, 36)
        Me.btnNew.Text = "ToolStripButton1"
        Me.btnNew.ToolTipText = "Nueva nota"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'btnCustomers
        '
        Me.btnCustomers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCustomers.Enabled = False
        Me.btnCustomers.Image = CType(resources.GetObject("btnCustomers.Image"), System.Drawing.Image)
        Me.btnCustomers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Size = New System.Drawing.Size(36, 36)
        Me.btnCustomers.Text = "ToolStripButton1"
        Me.btnCustomers.ToolTipText = "Catalogo de clientes"
        '
        'btnProducts
        '
        Me.btnProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProducts.Enabled = False
        Me.btnProducts.Image = CType(resources.GetObject("btnProducts.Image"), System.Drawing.Image)
        Me.btnProducts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(36, 36)
        Me.btnProducts.Text = "ToolStripButton2"
        Me.btnProducts.ToolTipText = "Catalogo de productos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'btnReport
        '
        Me.btnReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReport.Enabled = False
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(36, 36)
        Me.btnReport.Text = "Reporte de venta"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 403)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(699, 35)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(378, 30)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "No se encontraron registros"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(306, 30)
        Me.ToolStripStatusLabel4.Text = "USUARIO: NO AUTENTIFICADO"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(117, 30)
        Me.ToolStripStatusLabel1.Text = "Total: $0.00"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.VentasToolStripMenuItem, Me.CatalogosToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(699, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutenticarToolStripMenuItem, Me.ToolStripSeparator6, Me.MisDatosToolStripMenuItem, Me.DatosDeLaCuentaToolStripMenuItem, Me.ToolStripSeparator2, Me.ConfiguraciónToolStripMenuItem, Me.ImpresoraToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'AutenticarToolStripMenuItem
        '
        Me.AutenticarToolStripMenuItem.Name = "AutenticarToolStripMenuItem"
        Me.AutenticarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AutenticarToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AutenticarToolStripMenuItem.Text = "&Iniciar sesión"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(168, 6)
        '
        'MisDatosToolStripMenuItem
        '
        Me.MisDatosToolStripMenuItem.Enabled = False
        Me.MisDatosToolStripMenuItem.Name = "MisDatosToolStripMenuItem"
        Me.MisDatosToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.MisDatosToolStripMenuItem.Text = "&Mis datos"
        '
        'DatosDeLaCuentaToolStripMenuItem
        '
        Me.DatosDeLaCuentaToolStripMenuItem.Name = "DatosDeLaCuentaToolStripMenuItem"
        Me.DatosDeLaCuentaToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DatosDeLaCuentaToolStripMenuItem.Text = "&Datos de la cuenta"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(168, 6)
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ConfiguraciónToolStripMenuItem.Text = "&Configuración"
        '
        'ImpresoraToolStripMenuItem
        '
        Me.ImpresoraToolStripMenuItem.Name = "ImpresoraToolStripMenuItem"
        Me.ImpresoraToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ImpresoraToolStripMenuItem.Text = "Im&presora..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaVentaToolStripMenuItem, Me.ImprimirVentaToolStripMenuItem, Me.CancelarVentaToolStripMenuItem, Me.ToolStripSeparator10, Me.BusquedaDeVentaToolStripMenuItem, Me.ListadoDeVentasToolStripMenuItem, Me.ToolStripSeparator5, Me.RecargarListadoToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.VentasToolStripMenuItem.Text = "&Ventas"
        '
        'NuevaVentaToolStripMenuItem
        '
        Me.NuevaVentaToolStripMenuItem.Enabled = False
        Me.NuevaVentaToolStripMenuItem.Name = "NuevaVentaToolStripMenuItem"
        Me.NuevaVentaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NuevaVentaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NuevaVentaToolStripMenuItem.Text = "&Nueva venta"
        '
        'ImprimirVentaToolStripMenuItem
        '
        Me.ImprimirVentaToolStripMenuItem.Name = "ImprimirVentaToolStripMenuItem"
        Me.ImprimirVentaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.ImprimirVentaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ImprimirVentaToolStripMenuItem.Text = "&Imprimir venta"
        '
        'CancelarVentaToolStripMenuItem
        '
        Me.CancelarVentaToolStripMenuItem.Enabled = False
        Me.CancelarVentaToolStripMenuItem.Name = "CancelarVentaToolStripMenuItem"
        Me.CancelarVentaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.CancelarVentaToolStripMenuItem.Text = "&Cancelar venta"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(190, 6)
        '
        'BusquedaDeVentaToolStripMenuItem
        '
        Me.BusquedaDeVentaToolStripMenuItem.Name = "BusquedaDeVentaToolStripMenuItem"
        Me.BusquedaDeVentaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.BusquedaDeVentaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.BusquedaDeVentaToolStripMenuItem.Text = "&Busqueda de venta"
        '
        'ListadoDeVentasToolStripMenuItem
        '
        Me.ListadoDeVentasToolStripMenuItem.Name = "ListadoDeVentasToolStripMenuItem"
        Me.ListadoDeVentasToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ListadoDeVentasToolStripMenuItem.Text = "&Listado de ventas"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(190, 6)
        '
        'RecargarListadoToolStripMenuItem
        '
        Me.RecargarListadoToolStripMenuItem.Name = "RecargarListadoToolStripMenuItem"
        Me.RecargarListadoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RecargarListadoToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.RecargarListadoToolStripMenuItem.Text = "&Recargar listado"
        '
        'CatalogosToolStripMenuItem
        '
        Me.CatalogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.ToolStripSeparator8, Me.CuentasToolStripMenuItem, Me.CategoríasToolStripMenuItem, Me.AlmacenesToolStripMenuItem, Me.ToolStripSeparator9, Me.SesionesToolStripMenuItem})
        Me.CatalogosToolStripMenuItem.Name = "CatalogosToolStripMenuItem"
        Me.CatalogosToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CatalogosToolStripMenuItem.Text = "&Catalogos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Enabled = False
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ClientesToolStripMenuItem.Text = "&Clientes"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Enabled = False
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Pr&oveedores"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Enabled = False
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ProductosToolStripMenuItem.Text = "&Productos"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(155, 6)
        '
        'CuentasToolStripMenuItem
        '
        Me.CuentasToolStripMenuItem.Enabled = False
        Me.CuentasToolStripMenuItem.Name = "CuentasToolStripMenuItem"
        Me.CuentasToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CuentasToolStripMenuItem.Text = "C&uentas"
        '
        'CategoríasToolStripMenuItem
        '
        Me.CategoríasToolStripMenuItem.Enabled = False
        Me.CategoríasToolStripMenuItem.Name = "CategoríasToolStripMenuItem"
        Me.CategoríasToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CategoríasToolStripMenuItem.Text = "C&ategorías"
        '
        'AlmacenesToolStripMenuItem
        '
        Me.AlmacenesToolStripMenuItem.Enabled = False
        Me.AlmacenesToolStripMenuItem.Name = "AlmacenesToolStripMenuItem"
        Me.AlmacenesToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.AlmacenesToolStripMenuItem.Text = "&Almacenes"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(155, 6)
        '
        'SesionesToolStripMenuItem
        '
        Me.SesionesToolStripMenuItem.Enabled = False
        Me.SesionesToolStripMenuItem.Name = "SesionesToolStripMenuItem"
        Me.SesionesToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.SesionesToolStripMenuItem.Text = "&Sesiones"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformaciónDeLaSesiónToolStripMenuItem, Me.ToolStripSeparator11, Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ay&uda"
        '
        'InformaciónDeLaSesiónToolStripMenuItem
        '
        Me.InformaciónDeLaSesiónToolStripMenuItem.Name = "InformaciónDeLaSesiónToolStripMenuItem"
        Me.InformaciónDeLaSesiónToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.InformaciónDeLaSesiónToolStripMenuItem.Text = "Información de la sesión"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(200, 6)
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AcercaDeToolStripMenuItem.Text = "&Acerca de..."
        '
        'mnuCell
        '
        Me.mnuCell.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CancelarVentaToolStripMenuItem1})
        Me.mnuCell.Name = "mnuCell"
        Me.mnuCell.Size = New System.Drawing.Size(153, 26)
        '
        'CancelarVentaToolStripMenuItem1
        '
        Me.CancelarVentaToolStripMenuItem1.Name = "CancelarVentaToolStripMenuItem1"
        Me.CancelarVentaToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.CancelarVentaToolStripMenuItem1.Text = "Cancelar venta"
        '
        'MainBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 438)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainBox"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.mnuCell.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnLogin As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnCustomers As ToolStripButton
    Friend WithEvents btnProducts As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnReport As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutenticarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents MisDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatosDeLaCuentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ConfiguraciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImpresoraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents BusquedaDeVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents RecargarListadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CatalogosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents CuentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoríasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents SesionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlmacenesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformaciónDeLaSesiónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents mnuCell As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CancelarVentaToolStripMenuItem1 As ToolStripMenuItem
End Class
