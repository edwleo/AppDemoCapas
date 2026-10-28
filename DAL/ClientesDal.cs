using Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace DAL
{
    /// <summary>
    /// Acceso a datos de Clientes. En esta arquitectura la "base de datos" es el API REST,
    /// por eso la DAL usa HttpClient en lugar de SQL.
    /// </summary>
    public class ClientesDal : IClientesDal
    {
        private const string Ruta = "api/clientes";
        private readonly HttpClient _http;

        public ClientesDal(HttpClient http) => _http = http;

        public async Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default)
        {
            var url = string.IsNullOrWhiteSpace(buscar)
                ? Ruta
                : $"{Ruta}?buscar={Uri.EscapeDataString(buscar)}";

            using var resp = await _http.GetAsync(url, ct);
            await AsegurarExitoAsync(resp, ct);
            return await resp.Content.ReadFromJsonAsync<List<Cliente>>(ct) ?? new();
        }

        public async Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default)
        {
            using var resp = await _http.GetAsync($"{Ruta}/{id}", ct);
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            await AsegurarExitoAsync(resp, ct);
            return await resp.Content.ReadFromJsonAsync<Cliente>(ct);
        }

        public async Task<Cliente?> CrearAsync(Cliente cliente, CancellationToken ct = default)
        {
            using var resp = await _http.PostAsJsonAsync(Ruta, cliente, ct);
            await AsegurarExitoAsync(resp, ct);
            return await resp.Content.ReadFromJsonAsync<Cliente>(ct);
        }

        public async Task ActualizarAsync(Cliente cliente, CancellationToken ct = default)
        {
            using var resp = await _http.PutAsJsonAsync($"{Ruta}/{cliente.Id}", cliente, ct);
            await AsegurarExitoAsync(resp, ct);
        }

        public async Task EliminarAsync(int id, CancellationToken ct = default)
        {
            using var resp = await _http.DeleteAsync($"{Ruta}/{id}", ct);
            await AsegurarExitoAsync(resp, ct);
        }

        private static async Task AsegurarExitoAsync(HttpResponseMessage resp, CancellationToken ct)
        {
            if (resp.IsSuccessStatusCode) return;

            var cuerpo = await resp.Content.ReadAsStringAsync(ct);
            var detalle = string.IsNullOrWhiteSpace(cuerpo) ? resp.ReasonPhrase : cuerpo;
            throw new ApiException($"El servidor respondió {(int)resp.StatusCode}: {detalle}");
        }
    }
}
