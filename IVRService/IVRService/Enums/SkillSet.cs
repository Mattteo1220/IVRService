using System.ComponentModel;

namespace IVRService.Enums
{
  public enum SkillSet
  {
    #region RetailerSupport
    [Description("KC_RS_DEV")]
    RetailerSupportEnglishDev = 4188689,

    [Description("KC_RS_SP_DEV")]
    RetailerSupportSpanishDev = 4188690,

    [Description("Kornerstone RS")]
    RetailerSupportEnglish = 4103801,

    [Description("Kornerstone RS SP")]
    RetailerSupportSpanish = 4103802,
    #endregion

    #region VIPRetailer
    [Description("KC_RS_VIP_DEV")]
    VIPRetailerEnglishDev = 4188691,

    [Description("KC_RS_VIP_SP_DEV")]
    VIPRetailerSpanishDev = 4188692,

    [Description("Kornerstone VIP Retailer")]
    VIPRetailerEnglish = 4103828,

    [Description("Kornerstone VIP Retailer SP")]
    VIPRetailerSpanish = 4103830,
    #endregion

    #region CustomerSupport
    [Description("KC_PreFunded_DEV")]
    PreFundedEnglishDev = 4188700,

    [Description("KC_PreFunded_SP_DEV")]
    PreFundedSpanishDev = 4188701,

    [Description("KC_Prefunded")]
    PreFundedEnglish = 4188514,

    [Description("KC_Prefunded_SP")]
    PreFundedSpanish = 4188515,

    [Description("KC_Funded_DEV")]
    FundedEnglishDev = 4188698,

    [Description("KC_Funded_SP_DEV")]
    FundedSpanishDev = 4188699,

    [Description("KC_Funded")]
    FundedEnglish = 4188516,

    [Description("KC_Funded_SP")]
    FundedSpanish = 4188517,
    #endregion

    #region Collections
    #region RegularCollections(Bankrupt, Charged Off)
    [Description("KC_Coll_DEV")]
    KornerstoneCollectionsEnglishDev = 4188712,

    [Description("KC_Coll_SP_DEV")]
    KornerstoneCollectionsSpanishDev = 4188713,

    [Description("Kornerstone Collections")]
    KornerstoneCollectionsEnglish = 4103820,

    [Description("Kornerstone Collections SP")]
    KornerstoneCollectionsSpanish = 4103821,

    [Description("CF_Coll_DEV")]
    CrestCollectionsEnglishDev = 4188724,

    [Description("CF_Coll_SP_DEV")]
    CrestCollectionsSpanishDev = 4188725,

    [Description("Crest Collections")]
    CrestCollectionsEnglish = 4103808,

    [Description("Crest Collections SP")]
    CrestCollectionsSpanish = 4103809,
    #endregion

    #region EarlyStage
    [Description("KC_ES_DEV")]
    KornerstoneEarlyStageEnglishDev = 4188704,

    [Description("KC_ES_SP_DEV")]
    KornerstoneEarlyStageSpanishDev = 4188705,

    [Description("Kornerstone Early Stage")]
    KornerstoneEarlyStageEnglish = 4103812,

    [Description("Kornerstone Early Stage SP")]
    KornerstoneEarlyStageSpanish = 4103813,

    [Description("CS_ES_DEV")]
    CrestEarlyStageEnglishDEV = 4188716,

    [Description("CS_ES_SP_DEV")]
    CrestEarlyStageSpanishDev = 4188717,

    [Description("Crest Early Stage")]
    CrestEarlyStageEnglish = 4103537,

    [Description("Crest Early Stage SP")]
    CrestEarlyStageSpanish = 4103540,
    #endregion

    #region LateStage
    [Description("KC_LS_DEV")]
    KornerstoneLateStageEnglishDev = 4188706,

    [Description("KC_LS_SP_DEV")]
    KornerstoneLateStageSpanishDev = 4188707,

    [Description("Kornerstone Late Stage")]
    KornerstoneLateStageEnglish = 4103814,

    [Description("Kornerstone Late Stage SP")]
    KornerstoneLateStageSpanish = 4103815,

    [Description("CS_LS_DEV")]
    CrestLateStageEnglishDev = 4188718,

    [Description("CS_LS_SP_DEV")]
    CrestLateStageSpanishDev = 4188719,

    [Description("Crest Late Stage")]
    CrestLateStageEnglish = 4103538,

    [Description("Crest Late Stage SP")]
    CrestLateStageSpanish = 4103541,
    #endregion

    #region LossPrevention
    [Description("KC_LP_DEV")]
    KornerstoneLossPreventionEnglishDev = 4188708,

    [Description("KC_LP_SP_DEV")]
    KornerstoneLossPreventionSpanishDev = 4188709,

    [Description("Kornerstone LP")]
    KornerstoneLossPreventionEnglish = 4103816,

    [Description("Kornerstone LP SP")]
    KornerstoneLossPreventionSpanish = 4103817,

    [Description("CF_LP_DEV")]
    CrestLossPreventionEnglishDev = 4188720,

    [Description("CF_LP_SP_DEV")]
    CrestLossPreventionSpanishDev = 4188721,

    [Description("Crest LP")]
    CrestLossPreventionEnglish = 333049,

    [Description("Crest LP SP")]
    CrestLossPreventionSpanish = 347139,
    #endregion

    #region PreChargeOff
    [Description("KC_PC_DEV")]
    KornerstonePreChargeOffEnglishDev = 4188710,

    [Description("KC_PC_SP_DEV")]
    KornerstonePreChargeOffSpanishDev = 4188711,

    [Description("Kornerstone PreCo")]
    KornerstonePreChargeOffEnglish = 4103818,

    [Description("Kornerstone PreCo SP")]
    KornerstonePreChargeOffSpanish = 4103819,

    [Description("CF_PC_DEV")]
    CrestPreChargeOffEnglishDev = 4188722,

    [Description("CF_PC_SP_DEV")]
    CrestPreChargeOffSpanishDev = 4188723,

    [Description("Crest PreCo")]
    CrestPreChargeOffEnglish = 4103539,

    [Description("Crest PreCo SP")]
    CrestPreChargeOffSpanish = 4103543,

    #endregion

    #endregion

    #region ARC
    [Description("Acceptance Rental Eng")]
    AcceptanceRentalsEnglish = 4189301,

    [Description("Acceptance Rental Span")]
    AcceptanceRentalsSpanish = 4189302,

    [Description("Acceptance Rental Coll Eng")]
    AcceptanceRentalsCollectionsEnglish = 4189305,

    [Description("Acceptance Rental Coll Span")]
    AcceptanceRentalsCollectionSpanish = 4189306,

    [Description("Acceptance Rental Dev Eng")]
    AcceptanceRentalsDevEnglish = 4238682,

    [Description("Acceptance Rental Dev Span")]
    AcceptanceRentalsDevSpanish = 4238683,

    [Description("Acceptance Rental Coll Dev Eng")]
    ARCCollectionsEnglishDEV = 4238684,

    [Description("Acceptance Rental Coll devSpan")]
    ARCCollectionsSpanishDEV = 4238685,

    #endregion

    #region Voicemail
    [Description("KC_RS_VM_DEV")]
    KornerstoneRetailerSupportVoicemailDev = 4188693,

    [Description("KC_CS_VM_DEV")]
    KornerstoneCustomerSupportVoicemailDev = 4188694,

    [Description("KC_COLL_VM_DEV")]
    KornerstoneCollectionsVoicemailDev = 4188695,

    [Description("CF_CS_VM_DEV")]
    CrestCustomerSupportVoicemailDev = 4188696,

    [Description("CF_COLL_VM_DEV")]
    CrestCollectionsVoicemailDev = 4188697,

    [Description("Crest Collections VM")]
    CrestCollectionsVoicemail = 4103831,

    [Description("Crest CS VM")]
    CrestCustomerSupportVoicemail = 4103833,

    [Description("Kornerstone Retailer VM")]
    KornerstoneRetailerVoicemail = 4103836,

    [Description("Kornerstone Collections VM")]
    KornerstoneCollectionsVoicemail = 4103832,

    [Description("Kornerstone CS VM")]
    KornerstoneCustomerSupportVoicemail = 4103834,
    #endregion

  }
}
