using PostTech.Cliente.Entities;
using System.Globalization;

namespace PosTech.Cliente.UseCases
{
    public  class FormatarNomeUseCase
    {
        private readonly UsuarioEntity _usuario;
        public FormatarNomeUseCase(UsuarioEntity novoUsuario)
        {
            _usuario = novoUsuario;
        }

        public UsuarioEntity Formatar()
        {
            if (_usuario != null)
            {
                TextInfo nomeInfo = CultureInfo.CurrentCulture.TextInfo;
                var nomeFormatado = nomeInfo.ToTitleCase(_usuario.Nome);

                return new UsuarioEntity(_usuario.Id,
                    nomeFormatado,
                    _usuario.Email,
                    _usuario.Senha);
            }
            else
                return _usuario;
        }
    }
}
