using PosTech.PortFolio.Entities;
using System.Globalization;

namespace PosTech.PortFolio.UseCases
{
    public  class FormatarNomeUseCase
    {
        private readonly ClienteEntity _usuario;
        public FormatarNomeUseCase(ClienteEntity novoUsuario)
        {
            _usuario = novoUsuario;
        }

        public ClienteEntity Formatar()
        {
            if (_usuario != null)
            {
                TextInfo nomeInfo = CultureInfo.CurrentCulture.TextInfo;
                var nomeFormatado = nomeInfo.ToTitleCase(_usuario.Nome);
                _usuario.Nome = nomeFormatado;
                return _usuario;
            }
            else
                return _usuario;
        }
    }
}
