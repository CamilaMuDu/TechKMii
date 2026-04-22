using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json;
using TechKMii.Layers.BLL;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using TechKMii.Layers.UI.Mantenimientos.Filtros;
using UTN.Winform.Electronics.Extensions;
using UTNLeccion8B.Layer.Entities.PersonaHacienda;
using System.Net.Mail;

namespace TechKMii.Layers.UI.Mantenimientos
{
    public partial class frmClienteMantenimiento : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        IClienteBLL clienteBll = new ClienteBLL();
        IProvinciaBLL provinciaBLL = new BLLProvincia();
        Provincia provincia = new Provincia();
        private byte[] fotoBytes = null;
        private int clienteIdActual = 0;

        public frmClienteMantenimiento()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClienteMantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                List<Provincia> listaP = provinciaBLL.GetProvinciaFromInternet();

                cmbProvincia.DataSource = listaP;
                cmbProvincia.DisplayMember = "Descripcion";
                cmbProvincia.ValueMember = "Descripcion";
                cmbProvincia.SelectedIndex = -1;

                cmbTipoIdentificacion.DataSource = Enum.GetValues(typeof(TipoIdentificacion));
                cmbTipoIdentificacion.SelectedIndex = -1;

                cmbEstado.DataSource = Enum.GetValues(typeof(EstadoCatalogos));
                cmbEstado.SelectedIndex = -1;

                lblValidacionCorreo.Visible = false;

                CargarClientes();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarClientes()
        {
            try
            {
                var lista = clienteBll.GetAllSync().ToList();

                dgvDatosCliente.AutoGenerateColumns = true;
                dgvDatosCliente.DataSource = lista;

                ConfigurarColumnasGrid(dgvDatosCliente);
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Error al cargar los clientes: " + er.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoIdentificacion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de identificación.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoIdentificacion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show("Debe ingresar la identificación.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentificacion.Focus();
                    return;
                }

                if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
                {
                    string identificacion = txtIdentificacion.Text.Trim().ToUpper();

                    if (!System.Text.RegularExpressions.Regex.IsMatch(identificacion, @"^[A-Z]{1}[0-9]{6}$"))
                    {
                        MessageBox.Show("La identificación extranjera debe tener 1 letra y 6 dígitos. Ejemplo: A123456",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdentificacion.Focus();
                        return;
                    }
                }

                if (txtIdentificacion.Text.Trim().Length > 20)
                {
                    MessageBox.Show("La identificación no puede tener más de 20 caracteres.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentificacion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Debe ingresar los apellidos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellidos.Focus();
                    return;
                }

                if (!rdbFemenino.Checked && !rdbMasculino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el sexo.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProvincia.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar la provincia.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProvincia.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el estado.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                Cliente oCliente = new Cliente();
                oCliente.ClienteID = 0;
                oCliente.Identificacion = txtIdentificacion.Text.Trim();
                oCliente.Nombre = txtNombre.Text.Trim();
                oCliente.Apellidos = txtApellidos.Text.Trim();
                oCliente.Telefono = mskTelefono.Text.Trim();
                oCliente.Correo = txtCorreo.Text.Trim();
                oCliente.Direccion = txtDireccion.Text.Trim();
                oCliente.Provincia = cmbProvincia.SelectedValue.ToString();
                oCliente.Fotografia = fotoBytes;
                oCliente.TipoIdentificacion = (TipoIdentificacion)cmbTipoIdentificacion.SelectedItem;
                oCliente.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    try
                    {
                        MailAddress mail = new MailAddress(txtCorreo.Text.Trim());

                        if (mail.Address != txtCorreo.Text.Trim())
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("Debe ingresar un correo válido.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCorreo.Focus();
                        return;
                    }
                }

                if (clienteIdActual == 0)
                {
                    oCliente.ClienteID = 0;
                    Cliente clienteGuardado = await clienteBll.Save(oCliente);

                    MessageBox.Show("Cliente agregado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oCliente.ClienteID = clienteIdActual;
                    Cliente clienteActualizado = await clienteBll.Update(oCliente);

                    MessageBox.Show("Cliente actualizado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                CargarClientes();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarFormulario()
        {
            clienteIdActual = 0;
            fotoBytes = null;

            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            mskTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            cmbProvincia.SelectedIndex = -1;
            cmbTipoIdentificacion.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            rdbFemenino.Checked = false;
            rdbMasculino.Checked = false;

            pcbFotografia.Image = null;
            txtIdentificacion.Enabled = true;

            lblValidacionCorreo.Visible = false;
            lblValidacionCorreo.Text = "";
        }

        private async void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteIdActual <= 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente de la lista para editar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTipoIdentificacion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de identificación.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoIdentificacion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show("Debe ingresar la identificación.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentificacion.Focus();
                    return;
                }

                if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
                {
                    string identificacion = txtIdentificacion.Text.Trim().ToUpper();

                    if (!System.Text.RegularExpressions.Regex.IsMatch(identificacion, @"^[A-Z]{1}[0-9]{6}$"))
                    {
                        MessageBox.Show("La identificación extranjera debe tener 1 letra y 6 dígitos. Ejemplo: A123456",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdentificacion.Focus();
                        return;
                    }
                }

                if (txtIdentificacion.Text.Trim().Length > 20)
                {
                    MessageBox.Show("La identificación no puede tener más de 20 caracteres.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentificacion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Debe ingresar los apellidos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellidos.Focus();
                    return;
                }

                if (!rdbFemenino.Checked && !rdbMasculino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el sexo.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProvincia.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar la provincia.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProvincia.Focus();
                    return;
                }

                if (cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el estado.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbEstado.Focus();
                    return;
                }

                Cliente oCliente = new Cliente();
                oCliente.ClienteID = clienteIdActual;
                oCliente.Identificacion = txtIdentificacion.Text.Trim();
                oCliente.Nombre = txtNombre.Text.Trim();
                oCliente.Apellidos = txtApellidos.Text.Trim();
                oCliente.Telefono = mskTelefono.Text.Trim();
                oCliente.Correo = txtCorreo.Text.Trim();
                oCliente.Direccion = txtDireccion.Text.Trim();
                oCliente.Provincia = cmbProvincia.SelectedValue.ToString();
                oCliente.Fotografia = fotoBytes;
                oCliente.TipoIdentificacion = (TipoIdentificacion)cmbTipoIdentificacion.SelectedItem;
                oCliente.Estado = (EstadoCatalogos)cmbEstado.SelectedItem;

                if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    try
                    {
                        MailAddress mail = new MailAddress(txtCorreo.Text.Trim());

                        if (mail.Address != txtCorreo.Text.Trim())
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("Debe ingresar un correo válido.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCorreo.Focus();
                        return;
                    }
                }

                if (rdbFemenino.Checked)
                    oCliente.Sexo = Sexo.Femenino;
                else
                    oCliente.Sexo = Sexo.Masculino;

                Cliente clienteActualizado = await clienteBll.Update(oCliente);

                MessageBox.Show("Cliente actualizado correctamente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbTipoIdentificacion.SelectedIndex == -1)
                return;

            if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
            {
                string textoActual = txtIdentificacion.Text;

                if (char.IsControl(e.KeyChar))
                    return;

                if (txtIdentificacion.SelectionStart == 0)
                {
                    if (!char.IsLetter(e.KeyChar))
                        e.Handled = true;
                }
                else
                {
                    if (!char.IsDigit(e.KeyChar))
                        e.Handled = true;
                }

                if (textoActual.Length >= 7 && txtIdentificacion.SelectionLength == 0)
                    e.Handled = true;
            }
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            if (cmbTipoIdentificacion.SelectedIndex == -1)
                return;

            if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
            {
                int posicion = txtIdentificacion.SelectionStart;
                txtIdentificacion.Text = txtIdentificacion.Text.ToUpper();
                txtIdentificacion.SelectionStart = posicion;
            }
        }
        private void cmbTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdentificacion.Clear();

            if (cmbTipoIdentificacion.SelectedIndex == -1)
                return;

            if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
            {
                txtIdentificacion.MaxLength = 7;
            }
            else
            {
                txtIdentificacion.MaxLength = 20;
            }
        }

        //Metodo que consulta el servicio de Hacienda
        //para obtener el nombre completo a partir de la identificación
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show("No existe una identificación para buscar", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdentificacion.Focus();
                    return;
                }

                if (cmbTipoIdentificacion.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de identificación.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoIdentificacion.Focus();
                    return;
                }

                if ((TipoIdentificacion)cmbTipoIdentificacion.SelectedItem == TipoIdentificacion.Extranjero)
                {
                    MessageBox.Show("Para identificación extranjera no se permite consultar el API de Hacienda. Debe ingresar los datos manualmente.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                PersonaHaciendaDatos datosDatos = null;

                string identificacion = txtIdentificacion.Text.Trim();

                datosDatos = Task.Run(() =>
                {
                    string url = "https://api.hacienda.go.cr/fe/ae?identificacion=" + identificacion;

                    HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    myWebRequest.UserAgent = "Mozilla/5.0";
                    myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                    myWebRequest.Proxy = null;
                    myWebRequest.Timeout = 5000;

                    using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse())
                    using (Stream myStream = myHttpWebResponse.GetResponseStream())
                    using (StreamReader myStreamReader = new StreamReader(myStream))
                    {
                        string datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());

                        return JsonConvert.DeserializeObject<PersonaHaciendaDatos>(datos);
                    }

                }).GetAwaiter().GetResult();

                this.Cursor = Cursors.Default;

                if (datosDatos == null || string.IsNullOrWhiteSpace(datosDatos.nombre))
                {
                    MessageBox.Show("No se encontraron datos en Hacienda.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LlenarNombreYApellidos(datosDatos.nombre);
            }
            catch (WebException)
            {
                this.Cursor = Cursors.Default;

                DialogResult result = MessageBox.Show(
                    "El servicio de Hacienda no está disponible en este momento.\n\n¿Desea ingresar los datos manualmente?",
                    "Hacienda no disponible",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    txtNombre.Focus();
                }
            }
            catch (Exception er)
            {
                this.Cursor = Cursors.Default;

                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Llena el nombre y los dos apellidos por separado
        private void LlenarNombreYApellidos(string nombreCompleto)
        {
            txtNombre.Clear();
            txtApellidos.Clear();

            if (string.IsNullOrWhiteSpace(nombreCompleto))
                return;

            string[] partes = nombreCompleto
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (partes.Length)
            {
                case 1:
                    txtNombre.Text = partes[0];
                    break;

                case 2:
                    txtNombre.Text = partes[0];
                    txtApellidos.Text = partes[1];
                    break;

                case 3:

                    txtNombre.Text = partes[0];
                    txtApellidos.Text = $"{partes[1]} {partes[2]}";
                    break;

                default:
                    txtNombre.Text = string.Join(" ", partes.Take(partes.Length - 2));
                    txtApellidos.Text = string.Join(" ", partes.Skip(partes.Length - 2));
                    break;
            }
        }

        private void CargarClienteEnFormulario(Cliente oCliente)
        {
            try
            {
                if (oCliente == null)
                    return;

                clienteIdActual = oCliente.ClienteID;

                txtIdentificacion.Text = oCliente.Identificacion;
                txtNombre.Text = oCliente.Nombre;
                txtApellidos.Text = oCliente.Apellidos;
                mskTelefono.Text = oCliente.Telefono;
                txtCorreo.Text = oCliente.Correo;
                txtDireccion.Text = oCliente.Direccion;

                cmbProvincia.SelectedValue = oCliente.Provincia;
                cmbTipoIdentificacion.SelectedItem = oCliente.TipoIdentificacion;
                cmbEstado.SelectedItem = oCliente.Estado;

                if (oCliente.Sexo == Sexo.Femenino)
                    rdbFemenino.Checked = true;
                else
                    rdbMasculino.Checked = true;

                fotoBytes = oCliente.Fotografia;

                if (oCliente.Fotografia != null)
                {
                    using (MemoryStream ms = new MemoryStream(oCliente.Fotografia))
                    {
                        pcbFotografia.Image = Image.FromStream(ms);
                        pcbFotografia.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    pcbFotografia.Image = null;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al cargar el cliente en el formulario: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        //Metodo para agregar una foto al cliente
        private void btnAnnadirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Seleccionar fotografía";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaImagen = openFileDialog.FileName;

                    using (FileStream fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                    {
                        fotoBytes = new byte[fs.Length];
                        fs.Read(fotoBytes, 0, fotoBytes.Length);
                    }

                    using (MemoryStream ms = new MemoryStream(fotoBytes))
                    {
                        pcbFotografia.Image = Image.FromStream(ms);
                        pcbFotografia.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvDatosCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                Cliente oCliente = dgvDatosCliente.Rows[e.RowIndex].DataBoundItem as Cliente;

                if (oCliente != null)
                {
                    CargarClienteEnFormulario(oCliente);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatosCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void tsbBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteIdActual <= 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente para borrarlo.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente clienteSeleccionado = dgvDatosCliente.CurrentRow?.DataBoundItem as Cliente;

                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("No se pudo obtener la información del cliente seleccionado.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (clienteSeleccionado.Estado == EstadoCatalogos.Inactivo)
                {
                    MessageBox.Show("El cliente ya se encuentra.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de borrar el cliente seleccionado?",
                    "Confirmar borrado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                clienteSeleccionado.Estado = EstadoCatalogos.Inactivo;

                Cliente clienteActualizado = await clienteBll.Update(clienteSeleccionado);

                if (clienteActualizado != null)
                {
                    MessageBox.Show("Cliente borrado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo borrar el cliente.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}",
                    msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));

                MessageBox.Show("Se ha producido el siguiente error: " + er.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tspBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmClienteFiltro frm = new frmClienteFiltro())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Cliente clienteSeleccionado = frm.oCliente;

                        if (clienteSeleccionado != null)
                        {
                            CargarClienteEnFormulario(clienteSeleccionado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el filtro: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                lblValidacionCorreo.Visible = false;
                return;
            }

            lblValidacionCorreo.Visible = true;

            try
            {
                MailAddress mail = new MailAddress(correo);

                if (mail.Address == correo)
                {
                    lblValidacionCorreo.Text = "Valido";
                    lblValidacionCorreo.ForeColor = Color.Green;
                }
                else
                {
                    lblValidacionCorreo.Text = "No valido";
                    lblValidacionCorreo.ForeColor = Color.Red;
                }
            }
            catch
            {
                lblValidacionCorreo.Text = "No valido";
                lblValidacionCorreo.ForeColor = Color.Red;
            }
        }

        private void tlpPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ConfigurarColumnasGrid(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            string[] columnasVisibles =
            {
            "Identificacion",
            "Nombre",
            "Apellidos",
            "Sexo",
            "Telefono",
            "Correo",
            "Provincia",
            "Estado"
            };

            foreach (string nombreColumna in columnasVisibles)
            {
                if (dgv.Columns[nombreColumna] != null)
                    dgv.Columns[nombreColumna].Visible = true;
            }

            if (dgv.Columns["Identificacion"] != null)
                dgv.Columns["Identificacion"].HeaderText = "Identificación";

            if (dgv.Columns["Telefono"] != null)
                dgv.Columns["Telefono"].HeaderText = "Teléfono";
        }
    }
}

