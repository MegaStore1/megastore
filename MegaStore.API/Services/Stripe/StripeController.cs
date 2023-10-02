using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Services.Stripe
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public StripeController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
            [FromBody] AddStripeCustomer customer,
            CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(null,
                customer,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }

        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePayment>> AddStripePayment(
            [FromBody] AddStripePayment payment,
            CancellationToken ct)
        {
            StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(
                payment,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }

        [HttpPost("account/add")]
        public async Task<ActionResult<StripeAccount>> AddStripeAccount(StripeAccountDto stripeUserDto, CancellationToken ct)
        {
            StripeAccount createdAccount = await _stripeService.AddStripeAccountAsync(stripeUserDto, ct);
            return StatusCode(StatusCodes.Status200OK, createdAccount);
        }

        [HttpPost("account/accpetStripTermOfReference")]
        public async Task<ActionResult<StripeAccount>> AcceptStripeTermOfReference()
        {
            bool? accepted = await _stripeService.AcceptStripeTermOfService();
            return StatusCode(StatusCodes.Status200OK, accepted);
        }
    }
}