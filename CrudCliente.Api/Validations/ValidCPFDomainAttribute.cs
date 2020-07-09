using System.ComponentModel.DataAnnotations;
namespace CrudCliente.Api.Validation
{
    public class ValidCPFDomainAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            return true;

            bool valido = Util.Util.ValidaCPF(value.ToString());
            return valido;
        }
    }
}