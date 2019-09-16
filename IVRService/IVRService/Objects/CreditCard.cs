using System;

namespace IVRService.Objects
{
  public class CreditCard
  {
    public int CreditCardLastFour { get; set; }
    public int ZipCode { get; set; }
    public DateTime ExpirationDate { get; set; }

    public CreditCard AddCreditCard(int creditCardNumber, DateTime expirationDate, int zipcode)
    {
      CreditCardLastFour = creditCardNumber;
      ZipCode = zipcode;
      ExpirationDate = expirationDate;
      return this;
    }
  }
}
