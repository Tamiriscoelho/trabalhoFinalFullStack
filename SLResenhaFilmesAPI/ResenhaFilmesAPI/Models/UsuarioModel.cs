﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ResenhaFilmesAPI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string  Login { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;
    }
}
