using Entidades;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BOL
{
    /// <summary>Reglas de negocio de Clientes. La UI solo habla con esta clase.</summary>
    public class ClientesBol
    {
        private readonly IClientesDal _dal;
        public ClientesBol(IClientesDal dal) => _dal = dal;

        public Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default)
            => _dal.ListarAsync(buscar?.Trim(), ct);

        public Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default)
            => _dal.ObtenerAsync(id, ct);

        /// <summary>Crea el cliente si Id == 0; de lo contrario lo actualiza.</summary>
        public async Task GuardarAsync(Cliente cliente, CancellationToken ct = default)
        {
            Normalizar(cliente);
            Validar(cliente);

            if (cliente.Id == 0) await _dal.CrearAsync(cliente, ct);
            else await _dal.ActualizarAsync(cliente, ct);
        }

        public Task EliminarAsync(int id, CancellationToken ct = default)
        {
            if (id <= 0) throw new ReglaNegocioException("Seleccione un cliente para eliminar.");
            return _dal.EliminarAsync(id, ct);
        }

        private static void Normalizar(Cliente c)
        {
            c.Apellidos = c.Apellidos.Trim();
            c.Nombres = c.Nombres.Trim();
            c.Dni = c.Dni.Trim();
            c.Telefono = c.Telefono.Trim();
            c.Direccion = c.Direccion.Trim();
            c.Correo = c.Correo.Trim();
        }

        private static void Validar(Cliente c)
        {
            if (c.Apellidos.Length == 0)
                throw new ReglaNegocioException("Ingrese los apellidos.", nameof(Cliente.Apellidos));
            if (c.Nombres.Length == 0)
                throw new ReglaNegocioException("Ingrese los nombres.", nameof(Cliente.Nombres));
            if (!Regex.IsMatch(c.Dni, @"^\d{8}$"))
                throw new ReglaNegocioException("El DNI debe tener 8 dígitos.", nameof(Cliente.Dni));
            if (c.Telefono.Length > 0 && !Regex.IsMatch(c.Telefono, @"^\d{6,15}$"))
                throw new ReglaNegocioException("El teléfono debe tener entre 6 y 15 dígitos.", nameof(Cliente.Telefono));
        }
    }
}
