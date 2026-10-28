using BOL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmClientes : Form
    {
        private readonly ClientesBol _bol;

        private int _idActual;          // 0 = cliente nuevo
        private bool _cargandoGrid;     // evita reaccionar a la selección mientras se llena la grilla

        public FrmClientes(ClientesBol bol)
        {
            InitializeComponent();
            _bol = bol;
            Load += async (_, _) => await CargarAsync();
        }

        //Métodos
        private static void SoloDigitos(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void ActualizarEstadoBotones() => btnEliminar.Enabled = _idActual != 0;

        private void LimpiarFormulario(bool enfocar)
        {
            _idActual = 0;
            txtApellidos.Clear();
            txtNombres.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            grid.ClearSelection();
            ActualizarEstadoBotones();
            if (enfocar) txtApellidos.Focus();
        }

        /// <summary>Ejecuta una operación bloqueando la pantalla y mostrando los errores.</summary>
        private async Task EjecutarAsync(Func<Task> accion)
        {
            Control? foco = null;
            try
            {
                UseWaitCursor = true;
                Enabled = false;
                await accion();
            }
            catch (ReglaNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foco = ex.Campo switch
                {
                    nameof(Cliente.Apellidos) => txtApellidos,
                    nameof(Cliente.Nombres) => txtNombres,
                    nameof(Cliente.Dni) => txtDni,
                    nameof(Cliente.Telefono) => txtTelefono,
                    nameof(Cliente.Correo) => txtCorreo,
                    _ => null
                };
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Error del servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("El servidor tardó demasiado en responder.", "Tiempo agotado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"No se pudo conectar con el servidor.\n\n{ex.Message}", "Sin conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
            foco?.Focus();
        }

        private async Task CargarListaAsync()
        {
            var lista = await _bol.ListarAsync(txtBuscar.Text);

            _cargandoGrid = true;
            grid.DataSource = lista;
            grid.ClearSelection();
            _cargandoGrid = false;

            LimpiarFormulario(false);
        }

        private Task CargarAsync() => EjecutarAsync(CargarListaAsync);

        private void MostrarSeleccionado()
        {
            if (_cargandoGrid || grid.SelectedRows.Count == 0) return;
            if (grid.SelectedRows[0].DataBoundItem is not Cliente c) return;

            _idActual = c.Id;
            txtApellidos.Text = c.Apellidos;
            txtNombres.Text = c.Nombres;
            txtDni.Text = c.Dni;
            txtTelefono.Text = c.Telefono;
            txtDireccion.Text = c.Direccion;
            txtCorreo.Text = c.Correo;
            ActualizarEstadoBotones();
        }

        private async Task GuardarAsync()
        {
            var cliente = new Cliente
            {
                Id = _idActual,
                Apellidos = txtApellidos.Text.Trim(),
                Nombres = txtNombres.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            await EjecutarAsync(async () =>
            {
                await _bol.GuardarAsync(cliente);

                await CargarListaAsync();
                MessageBox.Show("Cliente guardado correctamente.", "Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async Task EliminarAsync()
        {
            if (_idActual == 0) return;

            var r = MessageBox.Show($"¿Eliminar a {txtNombres.Text} {txtApellidos.Text}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            var id = _idActual;
            await EjecutarAsync(async () =>
            {
                await _bol.EliminarAsync(id);
                await CargarListaAsync();
            });
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await EliminarAsync();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccionado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(true);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigitos(sender, e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigitos(sender, e);
        }
    }
}