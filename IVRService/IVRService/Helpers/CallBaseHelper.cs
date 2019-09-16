using System.Collections.Generic;
using IVRService.Enums;

namespace IVRService.Helpers
{
  public static class CallBaseHelper
  {

    #region Dictionaries
    public static Dictionary<long, LeasingCompany> LLCType = new Dictionary<long, LeasingCompany>()
    {
      {8885215111, LeasingCompany.KornerstoneCredit },
      {8332222112, LeasingCompany.KornerstoneCredit },
      {8882456111, LeasingCompany.KornerstoneCredit },
      {8552827378, LeasingCompany.KornerstoneCredit },
      {8555527378, LeasingCompany.CrestFinancial },
      {8016699504, LeasingCompany.AcceptanceRental }
    };

    public static Dictionary<long, Department> Department = new Dictionary<long, Department>()
    {
      {8885215111, Enums.Department.CustomerSupport },
      {8332222112, Enums.Department.RetailerSupport },
      {8882456111, Enums.Department.Collections },
      {8552827378, Enums.Department.RetailerSupport },
      {8555527378, Enums.Department.CustomerSupport },
      {8016699504, Enums.Department.CustomerSupport }
    };

    public static Dictionary<string, string> Authentication = new Dictionary<string, string>()
    {
      {"authUrl", "https://auth.SomeCompany.com/connect/token" },
      {"client_id", "ivr" },
      {"scope", "fillIn fillin fillin" },
      {"grant_type", "client_credentials" },
      {"secret", "secretofProduction" }
    };

    public static Dictionary<string, string> DevAuthentication = new Dictionary<string, string>()
    {
      {"authUrl", "https://authdev.SomeCompany.com/connect/token" },
      {"client_id", "ivr" },
      {"scope", "Fillindev FillIndev FillIndev" },
      {"grant_type", "client_credentials" },
      {"secret", "secretofDev" }
    };

    public static Dictionary<string, string> ApiUrl = new Dictionary<string, string>()
    {
      {"FetchRetailerByPhone", "https://retailerapi.someCompany.com/Retailer/GetByPhone/" },
      {"FetchCustomerByPhone", "https://customerapi.someCompany.com/Customer/getByPhoneNumber/" },
      {"FetchCustomerByPII", "https://customerapi.someCompany.com/getByDobAndLastFourSsn/" },
      {"FetchLeaseInfo", "https://customerapi.someCompany.com/Lease/GetByCustomerId/" },
      {"FetchContracts", "https://billingapi.someCompany.com/api/Contracts/List/" },
      {"FetchContract", "https://billingapi.someCompany.com/api/Contract/Get/" }
    };

    public static Dictionary<string, string> DevApiUrl = new Dictionary<string, string>()
    {
      {"FetchRetailerByPhone", "https://retailerapidev.someCompany.com/Retailer/GetByPhone/" },
      {"FetchCustomerByPhone", "https://customerapidev.someCompany.com/Customer/getByPhoneNumber/" },
      {"FetchCustomerByPII", "https://customerapidev.someCompany.com/getByDobAndLastFourSsn/" },
      {"FetchLeaseInfo", "https://customerapidev.someCompany.com/Lease/GetByCustomerId/" },
      {"FetchContracts", "https://billingapidev.someCompany.com/api/Contracts/List/" },
      {"FetchContract", "https://billingapidev.someCompany.com/api/Contract/Get/" },
    };
    #endregion

  }
}
