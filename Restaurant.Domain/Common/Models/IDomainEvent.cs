﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Common.Models
{
    public interface IDomainEvent: INotification
    {
    }
}
