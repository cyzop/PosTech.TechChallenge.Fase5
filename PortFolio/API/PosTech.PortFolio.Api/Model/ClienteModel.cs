﻿using System.ComponentModel.DataAnnotations;

namespace PosTech.PortFolio.Api.Model
{
    public class ClienteModel
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
