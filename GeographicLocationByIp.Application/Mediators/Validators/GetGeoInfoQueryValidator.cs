using FluentValidation;
using GeographicLocationByIp.Application.Mediators.Queries;

namespace GeographicLocationByIp.Application.Mediators.Validators
{
    public class GetGeoInfoQueryValidator : AbstractValidator<GetGeoInfoQuery>
    {
        public GetGeoInfoQueryValidator()
        {
            RuleFor(v => v.IpAddress)
                .Matches(@"^(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$")
                .WithMessage("IP address not valid");
        }
    }
}