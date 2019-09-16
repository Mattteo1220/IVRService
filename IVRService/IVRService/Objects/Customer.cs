using IVRService.Enums;
using IVRService.Helpers;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IVRService.Objects
{
  public class Customer
  {

    public Customer(out Customer customer, Caller caller)
    {
      _ani = caller.Ani;
      _authToken = caller.AuthToken;
      _department = caller.OriginalDepartment;
      _environment = caller.Environment;
      _leasingCompany = caller.LeasingCompany;
      customer = GetCustomerByPhone();
      if (!customer.Leases.Any())
        customer = null;

    }

    public Customer(out Customer customer, Caller caller, int lastFour, DateTime dateOfBirth)
    {
      _department = caller.OriginalDepartment;
      _authToken = caller.AuthToken;
      _lastFour = lastFour;
      _dateOfBirth = dateOfBirth;
      _environment = caller.Environment;
      _leasingCompany = caller.LeasingCompany;
      _authToken = caller.AuthToken;
      customer = GetCustomerBySSNAndDOB();
      if (!customer.Leases.Any())
        customer = null;
    }

    #region Attributes
    private long _ani;
    private string _authToken;
    private string _environment;
    private Department _department;
    private int _lastFour;
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
    public List<Lease> Leases { get; set; }
    public int IsVerified { get; set; }
    #endregion


    #region HelperMethods
    private Customer GetCustomerByPhone()
    {
      var url = _environment.Equals("Dev", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevApiUrl["FetchCustomerByPhone"] : CallBaseHelper.ApiUrl["FetchCustomerByPhone"];
      _client = new RestClient(new Uri(url + _ani));
      _getRequest = new RestRequest(Method.GET);
      _getRequest.AddHeader(APIHelper.AUTHORIZATION, $"Bearer {_authToken}");
      var results = _client.Execute(_getRequest);
      Leases = new List<Lease>();
      new Lease(out Lease lease, results, _authToken, _leasingCompany, _environment, false);
      if (lease != null)
        Leases.Add(lease);
      IsVerified = 0;
      return this;
    }

    private Customer GetCustomerBySSNAndDOB()
    {
      var url = _environment.Equals("Dev", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevApiUrl["FetchCustomerByPII"] : CallBaseHelper.ApiUrl["FetchCustomerByPII"];
      _client = new RestClient(new Uri(url + (_dateOfBirth.ToString("yyyy-MM-dd") + "/" + _lastFour)));
      _getRequest = new RestRequest(Method.GET);
      _getRequest.AddHeader(APIHelper.AUTHORIZATION, $"Bearer {_authToken}");
      var results = _client.Execute(_getRequest);
      Leases = new List<Lease>();
      new Lease(out Lease lease, results, _authToken, _leasingCompany, _environment, true);
      if (lease != null)
        Leases.Add(lease);
      if (Leases.Any())
        IsVerified = 1;
      return this;
    }
    #endregion
  }
}
