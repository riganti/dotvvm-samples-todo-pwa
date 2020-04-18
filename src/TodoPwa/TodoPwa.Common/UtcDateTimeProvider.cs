using Riganti.Utils.Infrastructure.Core;
using System;

namespace TodoPwa.Common
{
    public class UtcDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}