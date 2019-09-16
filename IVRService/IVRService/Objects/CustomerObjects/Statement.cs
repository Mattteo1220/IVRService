using System;
using System.Collections.Generic;

namespace IVRService.Objects.CustomerObjects
{
  public class Statement
  {
    public double absoluteTotal { get; set; }
    public int id { get; set; }
    public double total { get; set; }
    public double amount { get; set; }
    public double totalPayments { get; set; }
    public double paymentAmount { get; set; }
    public double recurringAmount { get; set; }
    public double scheduledAmount { get; set; }
    public double taxAmount { get; set; }
    public double feeAmount { get; set; }
    public double feePaymentAmount { get; set; }
    public double surchargeAmount { get; set; }
    public double balance { get; set; }
    public DateTime transactionDate { get; set; }
    public DateTime transactionTimeStamp { get; set; }
    public bool isDeclined { get; set; }
    public DateTime? settlementDate { get; set; }
    public bool isForRecurring { get; set; }
    public bool isCancelled { get; set; }
    public DateTime? cancelledDate { get; set; }
    public bool isTransacted { get; set; }
    public List<PaymentMethod> paymentMethod { get; set; }
    public List<Detail> detail { get; set; }
    public bool isCredit { get; set; }
    public string paymentStatus { get; set; }
    public string externalId { get; set; }
    public int paymentProcessorId { get; set; }
    public int gatewayResponseId { get; set; }
    public double nonCashCreditAmount { get; set; }
  }
}
