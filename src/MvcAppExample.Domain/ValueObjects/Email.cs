using System.Text.RegularExpressions;

namespace MvcAppExample.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; set; }

        public bool Validar()
        {
            return Regex.IsMatch(
                Endereco,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
        }
    }
}
