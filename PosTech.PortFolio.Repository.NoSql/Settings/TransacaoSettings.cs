using Microsoft.Extensions.Configuration;

namespace PosTech.PortFolio.Repository.NoSql.Settings
{
    public class TransacaoSettings : MongoSettings
    {
        const string sectionName = "TransacaoMongoSettings";

        public TransacaoSettings(IConfiguration config)
        {
            var sessao = config.GetSection(sectionName);
            sessao.Bind(this);
        }
    }
}
