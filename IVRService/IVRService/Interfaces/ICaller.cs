using IVRService.Enums;
using IVRService.Objects;
using System;

namespace IVRService
{
  public interface ICaller
  {
    string Language { get; set; }
    string Environment { get; set; }
    long Ani { get; set; }
    long Dnis { get; set; }
    Department OriginalDepartment { get; set; }
    Department FinalDepartment { get; set; }

    int HoursOfOperation { get; set; }
    LeasingCompany LeasingCompany { get; set; }
    int SkillId { get; set; }
    string SkillName { get; set; }
    int voicemail { get; set; }
    string ScreenPop { get; set; }
    long MasterId { get; set; }

    Consumer Consumer { get; set; }
    string AuthToken { get; set; }
    Caller CallHandler(Inbound inboundCaller);
    Caller VerifyCallHandler(long ani, long dnis, string environment, string authToken, int lastFourDtmf, DateTime dobDmtf, long masterId);
  }
}
