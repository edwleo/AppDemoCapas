using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BOL
{
    /// <summary>Se lanza cuando los datos no cumplen una regla de negocio.</summary>
    public class ReglaNegocioException : Exception
    {
        /// <summary>Nombre de la propiedad con problema (ej. "Dni"), para que la UI enfoque el campo.</summary>
        public string? Campo { get; }

        public ReglaNegocioException(string mensaje, string? campo = null) : base(mensaje) => Campo = campo;
    }
}
