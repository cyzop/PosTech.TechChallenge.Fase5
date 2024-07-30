using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PosTech.Cliente.Interfaces.Repositories;
using PosTech.Cliente.Repository.NoSql.Adapter;
using PosTech.Cliente.Repository.NoSql.Model;
using PosTech.Cliente.Repository.NoSql.Settings;
using PosTech.Cliente.Entities;

namespace PosTech.Cliente.Repository.NoSql
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<UsuarioModel> _usuarios;
        private readonly UsuarioSettings _settings;

        public ClienteRepository(IConfiguration configuration)
        {
            _settings = new UsuarioSettings(configuration);

            string connectionString = string.Format(_settings.ConnectionString, _settings.Secret);

            var mongoClient = new MongoClient(connectionString);
            var mongoDataBase = mongoClient.GetDatabase(_settings.Database);

            _usuarios = mongoDataBase.GetCollection<UsuarioModel>(_settings.Repository);
        }

        public ClienteRepository(IMongoDatabase database)
        {
            _usuarios = database.GetCollection<UsuarioModel>(nameof(UsuarioModel));
        }

        public void AtualizarUsuario(UsuarioEntity usuario)
        {
            var filter = Builders<UsuarioModel>.Filter.Eq(p => p.Id, usuario.Id);
            var entidadeDb = _usuarios.Find(filter).FirstOrDefault();

            var entidadeAtualizar = UsuarioModelAdapter.FromEntity(usuario);
            _usuarios.ReplaceOne(p => p.Id == entidadeDb.Id, entidadeAtualizar);
        }

        public UsuarioEntity IncluirUsuario(UsuarioEntity usuario)
        {
            var usuarioIncluir = UsuarioModelAdapter.FromEntity(usuario);
            _usuarios.InsertOne(usuarioIncluir);
            usuario.SetId(usuarioIncluir.Id);
            return usuario;
        }

        public UsuarioEntity ObterPorId(string id)
        {
            var filter = Builders<UsuarioModel>.Filter.Eq(p => p.Id, id);
            var p = _usuarios.Find(filter).FirstOrDefault();

            return p != null ? UsuarioModelAdapter.ToEntity(p) : null;
        }

        public UsuarioEntity ObterPorEmail(string email)
        {
            var filter = Builders<UsuarioModel>.Filter.Eq(p => p.Email, email);
            var p = _usuarios.Find(filter).FirstOrDefault();

            return p != null ? UsuarioModelAdapter.ToEntity(p) : null;
        }

        public IEnumerable<UsuarioEntity> ObterUsuarios()
        {
            var dbitens = _usuarios.Find(a => true).ToList();

            return dbitens.Select(e => UsuarioModelAdapter.ToEntity(e)).ToList();

        }
    }
}