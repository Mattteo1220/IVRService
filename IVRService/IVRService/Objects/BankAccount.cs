namespace IVRService.Objects
{
  public class BankAccount
  {
    public int AccountLastFour { get; set; }
    public long RoutingNumber { get; set; }
    public string Institution { get; set; }

    public BankAccount AddBankAccount(int accountNumber, long routingNumber, string institution)
    {
      AccountLastFour = accountNumber;
      RoutingNumber = routingNumber;
      Institution = institution;
      return this;
    }
  }
}
