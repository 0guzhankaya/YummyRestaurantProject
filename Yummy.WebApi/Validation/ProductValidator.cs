using FluentValidation;
using Yummy.WebApi.Entities;

namespace Yummy.WebApi.Validation
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Product name is required.")
				.MaximumLength(100).WithMessage("Product name must not exceed 100 characters.")
				.MinimumLength(3).WithMessage("Product name must be at least 3 characters long.");

			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Price must be greater than zero.")
				.NotEmpty().WithMessage("Price is required.");
		}
	}
}
