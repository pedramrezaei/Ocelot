using Microsoft.AspNetCore.Http;
using Ocelot.Configuration;
using Ocelot.Infrastructure.Claims.Parser;
using Ocelot.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Ocelot.Claims
{
    public class AddClaimsToRequest : IAddClaimsToRequest
    {
        private readonly IClaimsParser _claimsParser;

        public AddClaimsToRequest(IClaimsParser claimsParser)
        {
            _claimsParser = claimsParser;
        }

        public Response SetClaimsOnContext(List<ClaimToThing> claimsToThings, HttpContext context)
        {
            foreach (var config in claimsToThings)
            {
                var value = _claimsParser.GetValue(context.User.Claims, config.NewKey, config.Delimiter, config.Index);

                if (value.IsError)
                {
                    return new ErrorResponse(value.Errors);
                }

                if (context.User.Identity is ClaimsIdentity identity)
                {
                    var exists = context.User.Claims.FirstOrDefault(x => string.Equals(x.Type, config.ExistingKey, StringComparison.Ordinal));

                    if (exists != null)
                    {
                        identity.RemoveClaim(exists);
                    }

                    identity.AddClaim(new Claim(config.ExistingKey, value.Data));
                }
            }

            return new OkResponse();
        }
    }
}
