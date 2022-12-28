using FluentValidation;

namespace MeuBlog.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class NameValidation : AbstractValidator<Name>
    {
        public NameValidation()
        {
            RuleFor(n => n.FirstName)
                .MinimumLength(3)
                .WithMessage("O nome deve conter no minimo 3 caracteres");

            RuleFor(n => n.FirstName)
                .MinimumLength(3)
                .WithMessage("O sobrenome deve conter no minimo 3 caracteres");
        }
    }
}
