using Superpowers.Application.Common.Interfaces;
using System;

namespace Superpowers.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
