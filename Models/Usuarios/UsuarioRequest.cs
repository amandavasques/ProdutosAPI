﻿namespace ProdutosAPI.Models.Usuarios
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Funcao { get; set; }
    }
}
