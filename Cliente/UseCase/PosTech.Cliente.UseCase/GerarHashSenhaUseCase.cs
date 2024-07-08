using PostTech.Cliente.Entities;
using System.Text;

namespace PosTech.Cliente.UseCases
{
    public class GerarHashSenhaUseCase
    {
        private readonly UsuarioEntity _usuario;
        public GerarHashSenhaUseCase(UsuarioEntity novoUsuario)
        {
            _usuario = novoUsuario;
        }

        public UsuarioEntity Formatar()
        {
            if (_usuario != null)
            {
                var senhaHash = "";

                using (var sha512 = new System.Security.Cryptography.SHA512Managed())
                {
                    senhaHash = BitConverter.ToString(sha512.ComputeHash(Encoding.UTF8.GetBytes(_usuario.Senha))).Replace("-", "");
                }

                return new UsuarioEntity(_usuario.Id,
                    _usuario.Nome,
                    _usuario.Email,
                    senhaHash);
            }
            else
                return _usuario;
        }
    }
}
