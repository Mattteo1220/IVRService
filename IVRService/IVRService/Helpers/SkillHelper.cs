using IVRService.Enums;
using IVRService.Extensions;
using IVRService.Objects;
using System;
using System.Linq;

namespace IVRService.Helpers
{
  public static class SkillHelper
  {
    private static Skill _skills;
    public static void GetSkills(out Skill skill, Caller caller)
    {
      _skills = new Skill();
      {
        switch (caller.OriginalDepartment)
        {
          case Department.RetailerSupport:
            if (caller.Environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
              IdentifyRetailerDevSkills(caller);
            else
              IdentifyRetailerSkills(caller);
            break;

          case Department.CustomerSupport:
            if (caller.Environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
              IdentifyCustomerDevSkills(caller);
            else
              IdentifyCustomerSkills(caller);
            break;

          case Department.Collections:
            if (caller.Environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
              IdentifyCollectionsDevSkills(caller);
            else
              IdentifyCollectionsSkills(caller);
            break;

          case Department.AcceptanceRental:
            if (caller.Environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
              IdentifyArcDevSkills(caller);
            else
              IdentifyArcSkills(caller);
            break;

          default:
            if (caller.Environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase))
              IdentifyCustomerDevSkills(caller);
            else
              IdentifyCustomerSkills(caller);
            break;
        }
      }
      skill = _skills;
    }

    private static void IdentifyRetailerDevSkills(Caller caller)
    {
      if (caller.Consumer.ConsumerType.Retailer.IsVip)
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.VIPRetailerEnglishDev : (int)SkillSet.VIPRetailerSpanishDev;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.VIPRetailerEnglishDev) : EnumExtensions.GetDescription(SkillSet.VIPRetailerSpanishDev);
        _skills.VoicemailId = (int)SkillSet.KornerstoneRetailerSupportVoicemailDev;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneRetailerSupportVoicemailDev);
        _skills.ScreenPop = $@"https://devapp.KornerstoneCredit.com/Dealers/Details/{caller.Consumer.ConsumerType.Retailer.RetailerId}?verified={caller.Consumer.ConsumerType.Retailer.IsVerified}&code={caller.MasterId}";
      }
      else
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.RetailerSupportEnglishDev : (int)SkillSet.RetailerSupportSpanishDev;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.RetailerSupportEnglishDev) : EnumExtensions.GetDescription(SkillSet.RetailerSupportSpanishDev);
        _skills.VoicemailId = (int)SkillSet.KornerstoneRetailerSupportVoicemailDev;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneRetailerSupportVoicemailDev);
        _skills.ScreenPop = $@"https://devapp.KornerstoneCredit.com/Dealers/Details/{caller.Consumer.ConsumerType.Retailer.RetailerId}?verified={caller.Consumer.ConsumerType.Retailer.IsVerified}&code={caller.MasterId}";
      }
    }

    private static void IdentifyRetailerSkills(Caller caller)
    {
      if (caller.Consumer.ConsumerType.Retailer.IsVip)
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.VIPRetailerEnglish : (int)SkillSet.VIPRetailerSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.VIPRetailerEnglish) : EnumExtensions.GetDescription(SkillSet.VIPRetailerSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneRetailerVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneRetailerVoicemail);
        _skills.ScreenPop = $@"https://app.KornerstoneCredit.com/Dealers/Details/{caller.Consumer.ConsumerType.Retailer.RetailerId}?verified={caller.Consumer.ConsumerType.Retailer.IsVerified}&code={caller.MasterId}";
      }
      else
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.RetailerSupportEnglish : (int)SkillSet.RetailerSupportSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.RetailerSupportEnglish) : EnumExtensions.GetDescription(SkillSet.RetailerSupportSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneRetailerVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneRetailerVoicemail);
        _skills.ScreenPop = $@"https://app.KornerstoneCredit.com/Dealers/Details/{caller.Consumer.ConsumerType.Retailer.RetailerId}?verified={caller.Consumer.ConsumerType.Retailer.IsVerified}&code={caller.MasterId}";
      }
    }

    private static void IdentifyCollectionsDevSkills(Caller caller)
    {
      if (caller.Consumer.ConsumerType.Customer.Leases.First().DaysPastDue >= 1 && caller.Consumer.ConsumerType.Customer.Leases.First().DaysPastDue <= 30)
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet. : (int)SkillSet.AcceptanceRentalsDevSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevEnglish) : EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneCustomerSupportVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneCustomerSupportVoicemail);
        _skills.ScreenPop = $@"https://devapp.kornerstonecredit.com/Applicants/Details/{caller.Consumer.ConsumerType.Customer.Leases[0].ApplicantId}?verified={caller.Consumer.ConsumerType.Customer.IsVerified}&code={caller.MasterId}";
      }
    }

    private static void IdentifyCollectionsSkills(Caller caller)
    {

    }

    private static void IdentifyCustomerDevSkills(Caller caller)
    {

    }

    private static void IdentifyCustomerSkills(Caller caller)
    {

    }

    private static void IdentifyArcDevSkills(Caller caller)
    {
      if (caller.Consumer.ConsumerType.Customer.Leases.First().DaysPastDue >= 1)
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.ARCCollectionsEnglishDEV : (int)SkillSet.ARCCollectionsEnglishDEV;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.ARCCollectionsEnglishDEV) : EnumExtensions.GetDescription(SkillSet.ARCCollectionsSpanishDEV);
        _skills.VoicemailId = (int)SkillSet.KornerstoneCustomerSupportVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneCustomerSupportVoicemail);
        _skills.ScreenPop = $@"https://devapp.kornerstonecredit.com/Applicants/Details/{caller.Consumer.ConsumerType.Customer.Leases[0].ApplicantId}?verified={caller.Consumer.ConsumerType.Customer.IsVerified}&code={caller.MasterId}";
      }
      else
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.AcceptanceRentalsDevEnglish : (int)SkillSet.AcceptanceRentalsDevSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevEnglish) : EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneCustomerSupportVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneCustomerSupportVoicemail);
        _skills.ScreenPop = $@"https://devapp.kornerstonecredit.com/Applicants/Details/{caller.Consumer.ConsumerType.Customer.Leases[0].ApplicantId}?verified={caller.Consumer.ConsumerType.Customer.IsVerified}&code={caller.MasterId}";
      }
    }

    private static void IdentifyArcSkills(Caller caller)
    {
      if (caller.Consumer.ConsumerType.Customer.Leases.First().DaysPastDue >= 1)
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.AcceptanceRentalsDevEnglish : (int)SkillSet.AcceptanceRentalsDevSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevEnglish) : EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsDevSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneCustomerSupportVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneCustomerSupportVoicemail);
        _skills.ScreenPop = $@"https://app.kornerstonecredit.com/Applicants/Details/{caller.Consumer.ConsumerType.Customer.Leases[0].ApplicantId}?verified={caller.Consumer.ConsumerType.Customer.IsVerified}&code={caller.MasterId}";
      }
      else
      {
        _skills.SkillId = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.AcceptanceRentalsCollectionsEnglish : (int)SkillSet.AcceptanceRentalsCollectionSpanish;
        _skills.SkillName = caller.Language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsCollectionsEnglish) : EnumExtensions.GetDescription(SkillSet.AcceptanceRentalsCollectionSpanish);
        _skills.VoicemailId = (int)SkillSet.KornerstoneCustomerSupportVoicemail;
        _skills.VoicemailName = EnumExtensions.GetDescription(SkillSet.KornerstoneCustomerSupportVoicemail);
        _skills.ScreenPop = $@"https://app.kornerstonecredit.com/Applicants/Details/{caller.Consumer.ConsumerType.Customer.Leases[0].ApplicantId}?verified={caller.Consumer.ConsumerType.Customer.IsVerified}&code={caller.MasterId}";
      }
    }
  }
}
