using System;
using System.Collections.Generic;

namespace IVRService.Objects.CustomerObjects
{
  public class Agreement
  {
    public int id { get; set; }
    public string kind { get; set; }
    public string label { get; set; }
    public double balance { get; set; }
    public double paymentAmount { get; set; }
    public double nonCashCreditAmount { get; set; }
    public string recurringFrequency { get; set; }
    public object recurringFrequencyDays { get; set; }
    public double amount { get; set; }
    public double taxRate { get; set; }
    public DateTime startDate { get; set; }
    public DateTime firstPaymentDate { get; set; }
    public DateTime lastPaymentDate { get; set; }
    public DateTime nextPaymentDate { get; set; }
    public int numberOfPayments { get; set; }
    public double agreementPaymentAmount { get; set; }
    public double feeAmount { get; set; }
    public double unpaidFeeAmount { get; set; }
    public double pastDueAmount { get; set; }
    public double invoiceAmount { get; set; }
    public object deactivated { get; set; }
    public bool isActive { get; set; }
    public List<Statement> statement { get; set; }
    public DateTime firstPastDueDate { get; set; }
    public DateTime pastDueDate { get; set; }
    public string state { get; set; }
    public DateTime created { get; set; }
    public string createdBy { get; set; }
    public bool isFirstPaymentDefault { get; set; }
  }
}
