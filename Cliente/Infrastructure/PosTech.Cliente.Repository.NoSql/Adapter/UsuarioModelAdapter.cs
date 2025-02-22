﻿using PosTech.Cliente.Entities;

namespace PosTech.Cliente.Repository.NoSql.Adapter
{
    public static class UsuarioModelAdapter
    {
        public static UsuarioEntity ToEntity(Model.UsuarioModel usuarioModel)
        {
            return new UsuarioEntity(usuarioModel.Id,
               usuarioModel.Nome,
               usuarioModel.Email);
        }

        public static Model.UsuarioModel FromEntity(UsuarioEntity entity)
        {
            return new Model.UsuarioModel(entity.Id, entity.Nome, entity.Email);
        }
    }
}
