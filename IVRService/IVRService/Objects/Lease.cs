using IVRService.Enums;
using IVRService.Helpers;
using IVRService.Objects.CustomerObjects;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace IVRService.Objects
{
  public class Lease
  {
    #region Attributes
    private long _ani;
    private string _authToken;
    private string _environment;
    private Department _department;
    private int _lastFour;
    private int _daysLate;
    private int _contractId;
    private int _leaseProvider;
    private LeasingCompany _leasingCompany;
    private DateTime _dateOfBirth;
    private RestClient _client;
    private RestRequest _postRequest;
    private RestRequest _getRequest;
    private IRestResponse _restResponse;
    private JsonDeserializer _jsonDeserializer;
    private JsonSerializer _jsonSerializer;
    public string Name { get; set; }
    public int Status { get; set; }
    public int ApplicantId { get; set; }
    public int? LoanOwner { get; set; }
    public int DaysPastDue { get; set; }
    public string ContractStatus { get; set; }
    public double PastDueAmount { get; set; }
    public List<BankAccount> BankAccounts { get; set; }
    public List<CreditCard> CreditCards { get; set; }
    public string PaymentType { get; set; }


    public int LeaseProvider { get; set; }
    public int ContractID { get; set; }
    public bool HasSelfServeCapability { get; set; }
    #endregion
    public Lease(out Lease lease, IRestResponse response, string authToken, LeasingCompany leasingCompany, string environment, bool verify)
    {
      _leasingCompany = leasingCompany;
      _authToken = authToken;
      _environment = environment;
      if (verify)
        lease = ParseByPIIResultJson(response);
      else
      {
        lease = ParseGetByPhoneJson(response);
      }
      if (string.IsNullOrWhiteSpace(lease.Name))
        lease = null;
    }



    #region HelperMethods
    private Lease ParseGetByPhoneJson(IRestResponse response)
    {
      if (response.Content != String.Empty)
      {
        _jsonDeserializer = new JsonDeserializer();
        var customerDictionaries = _jsonDeserializer.Deserialize<List<Dictionary<string, string>>>(response);
        foreach (var dictionary in customerDictionaries)
        {
          ApplicantId = Convert.ToInt32(dictionary["id"]);
          Name = dictionary["firstName"] + " " + dictionary["lastName"];
          Status = Convert.ToInt32(dictionary["status"]);
          FetchLeaseInfo(ApplicantId);
          ContractID = _contractId;
          LeaseProvider = _leaseProvider;
          FetchDaysLate(ContractID);
        }
      }
      return this;
    }

    public Lease ParseByPIIResultJson(IRestResponse response)
    {
      if (response.Content != String.Empty)
      {
        var jsonDeserializer = new JsonDeserializer();
        var customerObject = jsonDeserializer.Deserialize<RootObject>(response);
        ApplicantId = customerObject.result.externalGroupId;
        //Name = customerObject.result;
        //Status = customerObject.result.status;
        FetchLeaseInfo(ApplicantId);
        ContractID = _contractId;
        LeaseProvider = _leaseProvider;
        //LoanOwner = Convert.ToInt32(dictionary["LoanOwner"]);
        FetchDaysLate(ContractID);
        //PaymentType = dictionary["PaymentType"];
        //BankAccounts = new List<BankAccount>();
        //CreditCards = new List<CreditCard>();
        HasSelfServeCapability = (LeaseProvider == 2 || LoanOwner == 14) ? false : true;
        //var accountLastFour = Convert.ToInt32(dictionary["lastFour"]);
        //var routingNumber = long.Parse(dictionary["routingNumber"]);
        //var bankInstitution = dictionary["bankInstitution"];
        //var creditCardLastFour = Convert.ToInt32(dictionary["lastFour"]);
        //var expirationDate = DateTime.Parse(dictionary["expirationDate"]);
        //var zipCode = Convert.ToInt32(dictionary["zipCode"]);
        //if (PaymentType.Equals("BankAccount", StringComparison.InvariantCultureIgnoreCase))
        //{
        //  var bankAccount = new BankAccount().AddBankAccount(accountLastFour, routingNumber, bankInstitution);
        //  BankAccounts.Add(bankAccount);
        //}
        //else
        //{
        //  var creditCard = new CreditCard().AddCreditCard(creditCardLastFour, expirationDate, zipCode);
        //  CreditCards.Add(creditCard);
        //}
      }
      return this;
    }

    private void FetchLeaseInfo(int applicantId)
    {
      var url = _environment.Equals("Dev", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevApiUrl["FetchLeaseInfo"] : CallBaseHelper.ApiUrl["FetchLeaseInfo"];
      var client = new RestClient(new Uri(url + applicantId));
      var getRequest = new RestRequest(Method.GET);
      getRequest.AddHeader("Authorization", $"Bearer {_authToken}");
      var results = client.Execute(getRequest);
      if (results.IsSuccessful)
      {
        var jsonDeserializer = new JsonDeserializer();
        var containers = jsonDeserializer.Deserialize<IEnumerable<Dictionary<string, string>>>(results);
        foreach (var container in containers)
        {
          ContractID = Convert.ToInt32(container["leaseProviderRefId"]);
          LeaseProvider = Convert.ToInt32(container["leaseProvider"]);
        }
      }
    }

    private void FetchDaysLate(int contractId)
    {
      var url = _environment.Equals("Dev", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevApiUrl["FetchContract"] : CallBaseHelper.ApiUrl["FetchContract"];

      var client = new RestClient(new Uri(url + ContractID));
      var getRequest = new RestRequest(Method.GET);
      getRequest.AddHeader("Authorization", $"Bearer {_authToken}");
      var results = client.Execute(getRequest);
      if (results.IsSuccessful)
      {
        var jsonDeserializer = new JsonDeserializer();
        var container = jsonDeserializer.Deserialize<RootObject>(results);
        DaysPastDue = container.result.daysPastDue;
        PastDueAmount = container.result.pastDueAmount;
      }
    }
    #endregion

  }
}
