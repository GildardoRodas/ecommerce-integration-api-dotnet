using Ecommerce.Integration.Application.Payments;
using Ecommerce.Integration.Domain.Payments;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Infrastructure.Persistence
{
    public class InMemoryPaymentRepository : IPaymentRepository
    {

        private readonly ConcurrentDictionary<Guid, Payment> _payments = new();

        public Task AddAsync(Payment payment)
        {
            _payments[payment.Id] = payment;
            return Task.CompletedTask;
        }

        public Task<Payment?> GetByIdAsync(Guid id)
        {
            _payments.TryGetValue(id, out var payment);
            return Task.FromResult(payment);
        }

        public Task UpdateAsync(Payment payment)
        {
            _payments[payment.Id] = payment;
            return Task.CompletedTask;
        }

    }
}
