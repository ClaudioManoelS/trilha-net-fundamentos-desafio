using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models;

/// <summary>
/// Objeto para padronizar e validar as placas
/// </summary>
public class Placa
{
    public string valor { get; private set; }

    public Placa(string valor)
    {
        this.valor = CodigoTratado(valor);
    }

    private string CodigoTratado(string valor)
    {
        // O objetivo deste método é padronizar o valor que será guardado 
        // para que seja sempre maiúsculo e adicione o traço caso não tenha

        string retorno = "";

        retorno = valor.ToUpper();

        if (retorno.Length == 7)
        {
            retorno = $"{retorno.Substring(0, 3)}-{retorno.Substring(3)}";
        }

        return retorno;
    }

    /// <summary>
    /// Método para verificar se a placa é inválida
    /// </summary>
    /// <returns>Retorna TRUE se a placa for inválida ou FALSE se a placa for válida</returns>
    public bool Invalida()
    {
        return !Regex.IsMatch(valor, "^[A-Z]{3}-[0-9][A-Z0-9][0-9]{2}$");
    }
}
