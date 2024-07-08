using MongoDB.Bson.Serialization.Attributes;

namespace PosTech.Cliente.Repository.NoSql.Model
{
    public class UsuarioModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id
        {
            get;
            private set;
        }

        public string Nome
        {
            get;
            private set;
        }
        
        public string Email
        {
            get;
            private set;
        }

        public string Senha
        {
            get;
            private set;
        }

        public UsuarioModel(string id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
