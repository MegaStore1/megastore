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
    public class StripeService : IStripeService
    {
        private readonly ChargeService chargeService;
        private readonly CustomerService customerService;
        private readonly TokenService tokenService;
        public StripeService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService)
        {
            this.chargeService = chargeService;
            this.customerService = customerService;
            this.tokenService = tokenService;
        }

        public async Task<bool?> AcceptStripeTermOfService()
        {
            var options = new AccountUpdateOptions
            {
                TosAcceptance = new AccountTosAcceptanceOptions
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(1609798905).UtcDateTime,
                    Ip = "8.8.8.8",
                },
            };
            var service = new AccountService();
            await service.UpdateAsync("acct_1NvmtXRASfSBOLxt", options);
            return true;
        }

        public async Task<StripeAccount> AddStripeAccountAsync(StripeAccountDto stripeUserDto, CancellationToken cancellationToken)
        {
            var options = new AccountCreateOptions
            {
                Type = stripeUserDto.type,
                Country = stripeUserDto.country,
                Email = stripeUserDto.email,
                BusinessType = stripeUserDto.businessType,
                Company = new AccountCompanyOptions
                {
                    Name = stripeUserDto.company,
                    TaxId = stripeUserDto.taxId,
                    Phone = stripeUserDto.phoneNumber,
                    RegistrationNumber = stripeUserDto.registrationNumber,
                    Address = new AddressOptions
                    {
                        Country = stripeUserDto.country,
                        Line1 = stripeUserDto.line1,
                        PostalCode = stripeUserDto.postalCode,
                        State = stripeUserDto.state,
                        City = stripeUserDto.city,
                    }
                },
                ExternalAccount = new AccountBankAccountOptions
                {
                    AccountNumber = stripeUserDto.accountNumber, // Replace with the actual bank account details
                    RoutingNumber = stripeUserDto.routingNumber, // Replace with the actual routing number
                    Currency = stripeUserDto.currency,
                    Country = stripeUserDto.country

                },
                BusinessProfile = new AccountBusinessProfileOptions
                {
                    Url = stripeUserDto.website,
                    Mcc = stripeUserDto.industry,
                },
                Capabilities = new AccountCapabilitiesOptions
                {
                    CardPayments = new AccountCapabilitiesCardPaymentsOptions
                    {
                        Requested = true,
                    },
                    Transfers = new AccountCapabilitiesTransfersOptions
                    {
                        Requested = true,
                    },
                },
            };
            var service = new AccountService();
            var createdAccount = await service.CreateAsync(options, null, cancellationToken);
            return new StripeAccount()
            {
                id = createdAccount.Id,
            };
        }

        public async Task<UserForDetailsDto> AddStripeAccountPerson(string accountId, int stateId, StripePersonDto stripePersonDto, CancellationToken cancellationToken)
        {
            var options = new PersonCreateOptions
            {
                Relationship = new PersonRelationshipOptions
                {
                    Owner = true,
                    Executive = true,
                    Director = true,
                    Representative = true,
                    Title = "Owner",
                    PercentOwnership = 100

                },
                FirstName = stripePersonDto.firstName,
                LastName = stripePersonDto.lastName,
                SsnLast4 = stripePersonDto.ssnLast4,
                Email = stripePersonDto.email,
                Phone = stripePersonDto.phoneNumber,
                Dob = new DobOptions
                {
                    Day = Convert.ToDateTime(stripePersonDto.dateOfBirth).Day,
                    Month = Convert.ToDateTime(stripePersonDto.dateOfBirth).Month,
                    Year = Convert.ToDateTime(stripePersonDto.dateOfBirth).Year
                },

                Address = new AddressOptions
                {
                    Line1 = stripePersonDto.address.line1,
                    City = stripePersonDto.address.city,
                    PostalCode = stripePersonDto.address.postalCode,
                    State = stripePersonDto.address.state,
                },
            };

            var personService = new PersonService();
            var person = await personService.CreateAsync(accountId, options);

            return new UserForDetailsDto
            {
                firstName = person.FirstName,
                lastName = person.LastName,
                email = person.Email,
                line1 = person.Address.Line1,
                line2 = person.Address.Line2,
                postalCode = person.Address.PostalCode,
                stateId = stateId
            };
        }

        public async Task<StripeCustomer> AddStripeCustomerAsync(
            RequestOptions requestOptions,
            AddStripeCustomer customer,
            CancellationToken cancellationToken)
        {
            // Set Stripe Token options based on customer data
            // TokenCreateOptions tokenOptions = new TokenCreateOptions
            // {
            //     Card = new TokenCardOptions
            //     {
            //         Name = customer.name,
            //         Number = customer.creditCard.cardNumber,
            //         ExpYear = customer.creditCard.cardNumber,
            //         ExpMonth = customer.creditCard.expirationMonth,
            //         Cvc = customer.creditCard.cvc
            //     }
            // };

            // // Create new Stripe Token
            // Token stripeToken = await this.tokenService.CreateAsync(tokenOptions, null, cancellationToken);

            // var options = new CardCreateOptions
            // {
            //     Source = "tok_visa",
            // };
            // var service = new CardService();
            // service.Create("cus_ORCfns2BVo84LF", options);
            // // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.name,
                Email = customer.email
            };

            // Create customer at Stripe
            Customer createdCustomer = await this.customerService.CreateAsync(customerOptions, requestOptions, cancellationToken);

            // // Return the created customer at stripe
            return new StripeCustomer()
            {
                email = createdCustomer.Email,
                customerId = createdCustomer.Id,
            };
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken cancellationToken)
        {
            // Set the options for the payment we would like to create at Stripe
            ChargeCreateOptions paymentOptions = new ChargeCreateOptions
            {
                Customer = payment.customerId,
                ReceiptEmail = payment.receiptEmail,
                Description = payment.description,
                Currency = payment.currency,
                Amount = payment.amount
            };

            // Create the payment
            var createdPayment = await this.chargeService.CreateAsync(paymentOptions, null, cancellationToken);

            // Return the payment to requesting method
            return new StripePayment()
            {

                customerId = createdPayment.CustomerId,
                receiptEmail = createdPayment.ReceiptEmail,
                description = createdPayment.Description,
                currency = createdPayment.Currency,
                amount = createdPayment.Amount,
                paymentId = createdPayment.Id
            };
        }

        public async Task<bool?> DeleteStripeAccountAsync(string stripeId)
        {
            var service = new AccountService();
            var result = await service.DeleteAsync(stripeId);
            return result.Deleted;
        }
    }
}