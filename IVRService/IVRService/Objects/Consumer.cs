using IVRService.Enums;
using System;

namespace IVRService.Objects
{
  public class Consumer
  {
    public ConsumerType ConsumerType { get; set; } = new ConsumerType();

    public Consumer DetermineConsumer(Caller caller)
    {
      if (caller.OriginalDepartment == Department.RetailerSupport)
      {
        new Retailer(out Retailer retailer, caller);
        if (retailer != null)
          ConsumerType.Retailer = retailer;
        else
        {
          new Customer(out Customer customer, caller);
          if (customer != null)
            ConsumerType.Customer = customer;
        }
      }
      else
      {
        new Customer(out Customer customer, caller);
        if (customer != null)
          ConsumerType.Customer = customer;
        else
        {
          new Retailer(out Retailer retailer, caller);
          if (retailer != null)
            ConsumerType.Retailer = retailer;
        }
      }
      return this;
    }

    public Consumer VerifyCustomer(Caller caller, int lastFour, DateTime dateOfBirth)
    {
      new Customer(out Customer customer, caller, lastFour, dateOfBirth);
      if (customer != null)
        ConsumerType.Customer = customer;
      return this;
    }
  }
}
