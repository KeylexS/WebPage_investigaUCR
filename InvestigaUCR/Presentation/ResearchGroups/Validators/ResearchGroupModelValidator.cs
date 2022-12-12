using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.ValueObjects;
using FluentValidation;
using Presentation.ResearchGroups.Models;

namespace Presentation.ResearchGroups.Validators
{
    public class ResearchGroupModelValidator : AbstractValidator<ResearchGroupModel>
    {
        public ResearchGroupModelValidator()
        {
            RuleFor(p => p)
                .Custom((model, context) =>
                {
                    var result = ResearchGroupId.TryCreate(model.Id);
                    if (!result.IsFail)
                        return;

                    var error = result.Fail();
                    var errorMessage = error switch
                    {
                        ResearchGroupId.IsNullOrWhitespace _ => "Por favor ingrese un Id valido.",
                        ResearchGroupId.TooLong tooLong => $"Escriba menos {tooLong.MaxLength} caracteres.",
                        _ => throw new ArgumentOutOfRangeException(nameof(error))
                    };

                    context.AddFailure(nameof(ResearchGroupModel.Id), errorMessage);
                });

            RuleFor(p => p)
                .Custom((model, context) =>
                {
                    var result = ResearchGroupName.TryCreate(model.Name);
                    if (!result.IsFail)
                        return;

                    var error = result.Fail();
                    var errorMessage = error switch
                    {
                        ResearchGroupName.IsNullOrWhitespace _ => "Por favor ingrese un nombre.",
                        ResearchGroupName.TooLong tooLong => $"Escriba menos {tooLong.MaxLength} caracteres.",
                        _ => throw new ArgumentOutOfRangeException(nameof(error))
                    };

                    context.AddFailure(nameof(ResearchGroupModel.Name), errorMessage);
                });

            RuleFor(p => p)
                .Custom((model, context) =>
                {
                    var result = ResearchGroupDescription.TryCreate(model.Description);
                    if (!result.IsFail)
                        return;

                    var error = result.Fail();
                    var errorMessage = error switch
                    {
                        ResearchGroupDescription.IsNullOrWhitespace _ => "Por favor ingrese una descripción.",
                        ResearchGroupDescription.TooLong tooLong => $"Escriba menos {tooLong.MaxLength} caracteres.",
                        _ => throw new ArgumentOutOfRangeException(nameof(error))
                    };

                    context.AddFailure(nameof(ResearchGroupModel.Description), errorMessage);
                });

            RuleFor(p => p)
                .Custom((model, context) =>
                {
                    if (model.Start_Date >= new DateTime(1981, 3, 11))
                        return;
                    context.AddFailure(nameof(ResearchGroupModel.Start_Date), "La fecha ingresada debe ser igual o mayor a: 11/3/1981");
                });
        }
    }
}
