using System;

namespace IVRService.Objects.CustomerObjects
{
  public class PaymentMethod
  {
    public int id { get; set; }
    public string type { get; set; }
    public string bin { get; set; }
    public string number { get; set; }
    public string lastFour { get; set; }
    public string provider { get; set; }
    public bool isPrePaid { get; set; }
    public int priority { get; set; }
    public DateTime? expirationDate { get; set; }
    public string primaryName { get; set; }
    public object secondaryName { get; set; }
    public bool isDebit { get; set; }
    public string authorizationType { get; set; }
    public AuthorizedTimeFrame authorizedTimeFrame { get; set; }
    public Health health { get; set; }
    public string token { get; set; }
    public bool isUseable { get; set; }
    public double priorityValue { get; set; }
    public double rank { get; set; }
    public string accountType { get; set; }
    public DateTime openDate { get; set; }
    public object deactivatedDate { get; set; }
    public object deactivatedReason { get; set; }
    public object meta { get; set; }
    public string createdBy { get; set; }
    public string modifiedBy { get; set; }
    public bool isVerified { get; set; }
  }
}
