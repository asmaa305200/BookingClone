using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace BookingClone.Application.Features.continent.commands.AddContinent;
public class AddContinentCommmandValidator : AbstractValidator<AddContinentCommmand>
   
{
    public AddContinentCommmandValidator()
    {
        RuleFor(a => a.Name)
               .NotEmpty().WithMessage(a => "Name is empty.")
               .NotNull().WithMessage(a => "Name is required.")

               .MaximumLength(200).WithMessage(a => "name must not exceed 200 characters.");


    }


}

