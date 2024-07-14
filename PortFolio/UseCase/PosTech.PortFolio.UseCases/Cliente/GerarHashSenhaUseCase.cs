using PosTech.PortFolio.Entities;
using System.Text;

namespace PosTech.PortFolio.UseCases
{
    public class GerarHashSenhaUseCase
    {
        private readonly ClienteEntity _usuario;
        public GerarHashSenhaUseCase(ClienteEntity novoUsuario)
        {
            _usuario = novoUsuario;
        }

        public ClienteEntity Formatar()
        {
            if (_usuario != null)
            {
                var senhaHash = "";

                using (var sha512 = new System.Security.Cryptography.SHA512Managed())
                {
                    senhaHash = BitConverter.ToString(sha512.ComputeHash(Encoding.UTF8.GetBytes(_usuario.Senha))).Replace("-", "");
                }
                _usuario.Senha = senhaHash;
                return _usuario;
            }
            else
                return _usuario;
        }
    }
}
