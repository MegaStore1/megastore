using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos;
using MegaStore.API.Dtos.User;
using MegaStore.API.Models;
using Stripe;

namespace MegaStore.API.Services.Stripe
{
    public interface IStripeService
    {
        Task<StripeCustomer> AddStripeCustomerAsync(RequestOptions requestOptions, AddStripeCustomer customer, CancellationToken cancellationToken);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken cancellationToken);
        Task<StripeAccount> AddStripeAccountAsync(StripeAccountDto stripeUser, CancellationToken cancellationToken);
        Task<bool?> DeleteStripeAccountAsync(string stripeId);
        Task<bool?> AcceptStripeTermOfService();

        Task<UserForDetailsDto> AddStripeAccountPerson(string accountId, int stateId, StripePersonDto stripePersonDto, CancellationToken cancellationToken);
    }
}