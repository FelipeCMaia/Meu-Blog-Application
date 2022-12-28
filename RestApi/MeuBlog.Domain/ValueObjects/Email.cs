using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuBlog.Domain.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }

    public class EmailValidation: AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(e => e.Address)
                .NotEmpty()
                .WithMessage("Email não informado");

            RuleFor(e => e.Address)
                .EmailAddress()
                .WithMessage("Email Inválido");
        }
    }
}
