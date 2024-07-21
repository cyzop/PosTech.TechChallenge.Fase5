namespace PosTech.PortFolio.Messages.Cliente
{
    public static class ValidationMessages
    {
        public static string MensagemEmailDuplicado = "Já existe um usuário/cliente cadastrado com este email!";
        public static string MensagemUsuarioNaoEncontrado = "Usuário não localizado!";
        public static string MensagemSenhaVazia = "A senha não pode estar vazia!";
        public static string MensagemNomeVazio = "O nome do usuário não pode estar vazio!";
        public static string MensagemEmailVazio = "O email do usuário não pode estar vazio!";
        public static string MensagemDataCriacaoInvalida = "A data de criação do usuário não pode ser maior que a data atual!";
    }
}
