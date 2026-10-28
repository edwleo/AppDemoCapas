using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace DAL
{
    public interface IClientesDal
    {
        Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default);
        Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default);
        Task<Cliente?> CrearAsync(Cliente cliente, CancellationToken ct = default);
        Task ActualizarAsync(Cliente cliente, CancellationToken ct = default);
        Task EliminarAsync(int id, CancellationToken ct = default);
    }
}
