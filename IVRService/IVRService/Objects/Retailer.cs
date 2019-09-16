using IVRService.Enums;
using IVRService.Helpers;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace IVRService.Objects
{
  public class Retailer
  {

    public Retailer(out Retailer retailer, Caller caller)
    {
      _environment = caller.Environment;
      _ani = caller.Ani;
      _dnis = caller.Dnis;
      _authToken = caller.AuthToken;
      retailer = QueryRetailer();
      if (retailer.Name == null)
        retailer = null;
      if (caller.OriginalDepartment != Department.RetailerSupport)
        caller.OriginalDepartment = Department.RetailerSupport;
    }

    #region Attributes
    public string Name { get; set; }
    public int RetailerId { get; set; }
    public bool IsVip { get; set; }
    public int IsVerified { get; set; } = 0;
    private string _environment;
    private long _ani;
    private long _dnis;
    private string _authToken;
    private RestClient _client;
    private RestRequest _postRequest;
    private RestRequest _getRequest;
    private IRestResponse _restResponse;
    private JsonDeserializer _jsonDeserializer;
    private JsonSerializer _jsonSerializer;
    #endregion

    #region HelperMethods
    public Retailer QueryRetailer()
    {
      return FetchRetailerInfo(_ani, _authToken);
    }

    private Retailer FetchRetailerInfo(long ani, string token)
    {
      var url = _environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevApiUrl["FetchRetailerByPhone"] : CallBaseHelper.ApiUrl["FetchRetailerByPhone"];
      _client = new RestClient(new Uri(url + _ani));
      _getRequest = new RestRequest(Method.GET);
      _getRequest.AddHeader(APIHelper.AUTHORIZATION, $"Bearer {_authToken}");
      var result = _client.Execute(_getRequest);
      if (result.Content != String.Empty)
      {
        _jsonDeserializer = new JsonDeserializer();
        var values = _jsonDeserializer.Deserialize<Dictionary<string, string>>(result);
        Name = values["name"];
        RetailerId = Convert.ToInt32(values["id"]);
        IsVip = values["vip"] == "true" ? true : false;
        IsVerified = 0;
      }
      return this;
    }


    #endregion
  }
}
