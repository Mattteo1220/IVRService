using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace IVRService.Helpers
{
  public class APIHelper
  {
    private RestClient _client;
    private RestRequest _postRequest;
    private RestRequest _getRequest;
    private IRestResponse _restResponse;
    private JsonDeserializer _jsonDeserializer;
    private JsonSerializer _jsonSerializer;
    private string _environment;
    private long _dnis;
    private long _ani;
    private string _authToken;
    private string _department;
    public static string AUTHORIZATION = "Authorization";
    public APIHelper(string environment)
    {
      _environment = environment;
    }

    public APIHelper withEnvironment(string environment)
    {
      _environment = environment;
      return this;
    }

    public APIHelper withAni(long ani)
    {
      _ani = ani;
      return this;
    }

    public APIHelper withDnis(long dnis)
    {
      _dnis = dnis;
      return this;
    }

    public APIHelper withDepartment(string department)
    {
      _department = department;
      return this;
    }

    public APIHelper withAuthToken(string authToken)
    {
      _authToken = authToken;
      return this;
    }

    #region Auth
    public string FetchAuthToken()
    {
      _jsonDeserializer = new JsonDeserializer();
      var content = _jsonDeserializer.Deserialize<Dictionary<string, string>>(AuthRequest());
      return content["access_token"];
    }

    private IRestResponse AuthRequest()
    {
      var url = _environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevAuthentication["authUrl"] : CallBaseHelper.Authentication["authUrl"];
      var clientId = _environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevAuthentication["client_id"] : CallBaseHelper.Authentication["client_id"];
      var secret = _environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevAuthentication["secret"] : CallBaseHelper.Authentication["secret"];
      var scope = _environment.Equals("Development", StringComparison.InvariantCultureIgnoreCase) ? CallBaseHelper.DevAuthentication["scope"] : CallBaseHelper.Authentication["scope"];
      _client = new RestClient(new Uri(url));
      _postRequest = new RestRequest(Method.POST);
      _postRequest.AddParameter("grant_type", CallBaseHelper.Authentication["grant_type"], ParameterType.GetOrPost);
      _postRequest.AddParameter("client_id", clientId, ParameterType.GetOrPost);
      _postRequest.AddParameter("client_secret", secret, ParameterType.GetOrPost);
      _postRequest.AddParameter("scope", scope, ParameterType.GetOrPost);
      return _client.Execute(_postRequest);
    }
    #endregion

  }
}
