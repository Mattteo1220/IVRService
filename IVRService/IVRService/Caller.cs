using IVRService.Enums;
using IVRService.Helpers;
using IVRService.Objects;
using System;
using IVRAPI;

namespace IVRService
{
  public class Caller : ICaller
  {
    public Caller CallHandler(Inbound inboundCaller)
    {
      Ani = inboundCaller.Ani;
      Dnis = dnis;
      Language = dtmf == 8 ? "Spanish" : "English";
      Environment = environment;
      LeasingCompany = CallBaseHelper.LLCType[dnis];
      OriginalDepartment = CallBaseHelper.Department[dnis];
      FinalDepartment = OriginalDepartment;
      MasterId = MasterId;
      AuthToken = Authenticate();
      if (!string.IsNullOrEmpty(AuthToken))
        Consumer = new Consumer().DetermineConsumer(this);
      HoursOfOperation = (int)FinalDepartment; //Hours of operation
      return this;
    }

    public Caller VerifyCallHandler(long ani, long dnis, string environment, string authToken, int lastFourDtmf, DateTime dobDmtf, long masterId)
    {
      Ani = ani;
      Dnis = dnis;
      Environment = environment;
      LeasingCompany = CallBaseHelper.LLCType[dnis];
      OriginalDepartment = CallBaseHelper.Department[dnis];
      FinalDepartment = OriginalDepartment;
      MasterId = MasterId;
      AuthToken = authToken;
      if (string.IsNullOrEmpty(AuthToken))
        AuthToken = Authenticate();
      Consumer = new Consumer().VerifyCustomer(this, lastFourDtmf, dobDmtf);
      HoursOfOperation = (int)FinalDepartment; //Hours of operation
      return this;
    }

    #region Attributes
    public string Language { get; set; }
    public string Environment { get; set; }
    public long Ani { get; set; }
    public long Dnis { get; set; }
    public Department OriginalDepartment { get; set; }
    public Department FinalDepartment { get; set; }
    public int HoursOfOperation { get; set; }
    public LeasingCompany LeasingCompany { get; set; }
    public Consumer Consumer { get; set; }
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public int voicemail { get; set; }
    public string ScreenPop { get; set; }
    public string AuthToken { get; set; }
    public long MasterId { get; set; }
    #endregion

    #region HelperMethods

    public string Authenticate()
    {
      var apiHelper = new APIHelper(Environment);
      return AuthToken = apiHelper.FetchAuthToken();
    }
    #endregion
  }
}
