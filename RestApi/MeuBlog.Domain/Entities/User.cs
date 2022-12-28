using FluentValidation.Results;
using MeuBlog.Domain.ValueObjects;
using MeuBlog.Shared.Entities;

namespace MeuBlog.Domain.Entities
{
    public class User : Entity
    {        
        public Name Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }        

        public List<Post> Posts { get; set; } = new List<Post>();

        public ValidationResult ValidationResult { get; set; }

        public User(Name name, Email email, string password)
        {
            Name = name;
            Email = email;
            Password = password;            
            Active = true;
        }

        public bool EhValido()
        {
            var emailErrors = new List<ValidationFailure>();

            emailErrors.AddRange(new EmailValidation().Validate(Email).Errors);
            ValidationResult = new ValidationResult(emailErrors);

            return ValidationResult.IsValid;
        }
    }
}
