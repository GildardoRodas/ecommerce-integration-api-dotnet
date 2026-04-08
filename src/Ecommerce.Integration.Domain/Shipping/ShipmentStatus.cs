using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Integration.Domain.Shipping
{

    public enum ShipmentStatus
    {
        Created,
        InTransit,
        Delivered,
        Failed
    }

}
