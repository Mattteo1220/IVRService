using System;

namespace IVRService.Objects.CustomerObjects
{
  public class Detail
  {
    public int id { get; set; }
    public double amount { get; set; }
    public double taxAmount { get; set; }
    public double total { get; set; }
    public string createdBy { get; set; }
    public string reason { get; set; }
    public DateTime transactionTimeStamp { get; set; }
    public DateTime? settlementDate { get; set; }
    public DateTime transactionDate { get; set; }
    public string typeName { get; set; }
    public int antecedentId { get; set; }
    public double balance { get; set; }
    public int paymentMethodId { get; set; }
    public DateTime createdDate { get; set; }
  }
}
