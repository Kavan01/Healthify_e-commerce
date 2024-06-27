using FluentValidation;
using FluentValidation.AspNetCore;
using Healthify1.Models;

namespace Healthify1.CustomerValidation
{
    public class CustomerValidation : AbstractValidator<CustomerModel>
    {
        public CustomerValidation()
        {
            RuleFor(customermodel => customermodel.CustomerName).NotEmpty().WithMessage("Customer Name is Required");
            RuleFor(customermodel => customermodel.Email).NotEmpty().EmailAddress().WithMessage("Email format is wrong");
            RuleFor(customermodel => customermodel.CustomerName).NotEmpty().WithMessage("Customer Name is Required");
        }
        public int? CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}