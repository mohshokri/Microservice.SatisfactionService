﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfaction.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
