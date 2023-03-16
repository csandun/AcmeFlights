using System;
using System.Data.Common;

namespace API.Application.ViewModels;

public class OrderViewModel
{
    public Guid Id { get; private set; }
    public string Status { get; private set; }

    public OrderViewModel(Guid id, string status)
    {
        Id = id;
        Status = status;
    }
}