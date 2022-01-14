﻿using UpworkAssignment.Application.Common.Interfaces;

namespace UpworkAssignment.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
