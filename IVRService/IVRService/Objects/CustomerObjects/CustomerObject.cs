using System;
using System.Collections.Generic;

namespace IVRService.Objects.CustomerObjects
{
  public class CustomerObject
  {
    public List<PaymentMethod> paymentMethods { get; set; }
    public bool isCurrent { get; set; }
    public int id { get; set; }
    public int investorId { get; set; }
    public string status { get; set; }
    public string statusReason { get; set; }
    public DateTime statusDate { get; set; }
    public string externalRefId { get; set; }
    public int externalGroupId { get; set; }
    public double balance { get; set; }
    public double balanceWithoutFees { get; set; }
    public DateTime nextPaymentDate { get; set; }
    public DateTime firstPaymentDate { get; set; }
    public int termInMonths { get; set; }
    public int buyoutPeriod { get; set; }
    public double buyoutAmount { get; set; }
    public DateTime buyoutDate { get; set; }
    public double payoffPercent { get; set; }
    public int buyoutPeriodRemainingDays { get; set; }
    public int daysPastDue { get; set; }
    public bool isFirstPaymentDefault { get; set; }
    public double taxRate { get; set; }
    public double value { get; set; }
    public DateTime startDate { get; set; }
    public double productValue { get; set; }
    public DateTime firstPastDueDate { get; set; }
    public DateTime pastDueDate { get; set; }
    public double pastDueAmount { get; set; }
    public double downPaymentAmount { get; set; }
    public double paymentAmount { get; set; }
    public List<Agreement> agreements { get; set; }
    public int activeAgreementId { get; set; }
    public string createdBy { get; set; }
    public string modifiedBy { get; set; }
    public bool isFrozen { get; set; }
    public int portfolioId { get; set; }
    public int antecedentId { get; set; }
  }
}
