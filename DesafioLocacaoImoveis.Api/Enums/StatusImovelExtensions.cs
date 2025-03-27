namespace DesafioLocacaoImoveis.Api.Enums
{
    public class StatusImovelExtensions
    {
        public static bool EhValido(int status)
        {
            return Enum.IsDefined(typeof(StatusImovel), status);
        }
    }
}
