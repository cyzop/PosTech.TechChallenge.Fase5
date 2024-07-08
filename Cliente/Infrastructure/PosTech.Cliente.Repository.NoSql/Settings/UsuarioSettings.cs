using Microsoft.Extensions.Configuration;

namespace PosTech.Cliente.Repository.NoSql.Settings
{
    public class UsuarioSettings : MongoSettings
    {
        const string sectionName = "UsuarioMongoSettings";

        public UsuarioSettings(IConfiguration config)
        {
            var sessao = config.GetSection(sectionName);
            sessao.Bind(this);
        }
    }
}
