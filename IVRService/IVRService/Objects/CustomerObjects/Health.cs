using System;

namespace IVRService.Objects.CustomerObjects
{
  public class Health
  {
    public int attempts { get; set; }
    public int successfulAttempts { get; set; }
    public int returns { get; set; }
    public DateTime? lastSuccessfulAttempt { get; set; }
    public double returnRate { get; set; }
    public double paymentAmount { get; set; }
    public int consecutiveReturns { get; set; }
    public int consecutiveSuccesses { get; set; }
    public double successRate { get; set; }
    public double health { get; set; }
  }
}
