/*using FluentValidation;
using Healthify1.Models;

namespace Healthify1.CustomerValidation
{
    public class EventDateValidation : AbstractValidator<EventModel>
    {
        public EventDateValidation()
        {
            RuleFor(e => e.EventDate)
           .NotEmpty()
           .WithMessage("Customer Name is Required");
        }
    }
}


using FluentValidation;
using Healthify1.Models;
using System;

namespace Healthify1.CustomerValidation
{
    public class EventDateValidation : AbstractValidator<EventModel>
    {
        public EventDateValidation()
        {
            RuleFor(e => e.EventDate)
                .NotEmpty().WithMessage("EventDate is required")
                .Must(BeAValidFutureDate).WithMessage("EventDate must be a future date")
                .Must(BeWithinNext30Days).WithMessage("EventDate must be within the next 30 days")
                .Must(NotBeOnWeekend).WithMessage("EventDate must not be on Saturday or Sunday")
                .Must(BeWithinNextMonth).WithMessage("EventDate must be within the next month");
        }

        private bool BeAValidFutureDate(DateTime eventDate)
        {
            return eventDate > DateTime.Now;
        }

        private bool BeWithinNext30Days(DateTime eventDate)
        {
            return eventDate <= DateTime.Now.AddDays(30);
        }

        private bool NotBeOnWeekend(DateTime eventDate)
        {
            return eventDate.DayOfWeek != DayOfWeek.Saturday && eventDate.DayOfWeek != DayOfWeek.Sunday;
        }

        private bool BeWithinNextMonth(DateTime eventDate)
        {
            DateTime nextMonth = DateTime.Now.AddMonths(1);
            return eventDate < nextMonth && eventDate >= DateTime.Now;
        }
    }
}
*/

using FluentValidation;
using Healthify1.Models;

namespace Healthify1.CustomerValidation
{
    public class EventDateValidation : AbstractValidator<EventModel>
    {
        public EventDateValidation()
        {
            RuleFor(e => e.EventDate)
           .GreaterThan(DateTime.Now)
           .WithMessage("EvenDate must be future date");

            RuleFor(e => e.EventDate)
           .LessThan(DateTime.Now.AddDays(30))
           .WithMessage("EventDate only within the next 30 days");

            RuleFor(e => e.EventDate)
           .Must(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
           .WithMessage("EventDate must not be on saturday & sunday");

            RuleFor(e => e.EventDate)
           .InclusiveBetween(DateTime.Now, DateTime.Now.AddMonths(1))
           .WithMessage("EventDate Must be within the next month");
        }
    }
}