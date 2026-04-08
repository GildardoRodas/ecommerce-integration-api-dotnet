using Ecommerce.Integration.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Application.Payments
{
    public interface IPaymentRepository
    {

        Task AddAsync(Payment payment);
        Task<Payment?> GetByIdAsync(Guid id);
        Task UpdateAsync(Payment payment);

    }
}
