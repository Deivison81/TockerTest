using FluentValidation;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;

namespace TockerTest.API.Validation
{
    public class ValidatorUser: AbstractValidator<VMUser>
    {
        public ValidatorUser()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("El campo es requerido");
               

            RuleFor(x => x.Phone).NotEmpty().WithMessage($"{nameof(ValidatorUser)}.Phone")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("El número de teléfono no es válido");
        }
    }
}
