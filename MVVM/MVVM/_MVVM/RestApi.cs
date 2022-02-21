using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVVM
{
  [Obsolete("Currently not tested, so be careful!")]
  public partial class RestApi : IRestApi
  {
    public int Retrys { get; set; } = 3;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
    public HttpClient Client { get; }
    public ContentType ResultContentType { get; set; }
    public AuthenticationHeaderValue AuthenticationHeaderValue { get => this.Client?.DefaultRequestHeaders.Authorization; set => this.Client.DefaultRequestHeaders.Authorization = value; }

    public RestApi(Uri baseUriAddress, ContentType type = ContentType.JSON)
    {
      this.Client = new HttpClient();
      this.Client.BaseAddress = baseUriAddress;
      this.Client.Timeout = Timeout;
      this.Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue;
      this.ResultContentType = type;
    }

    public RestApi(string baseAddress, ContentType type = ContentType.JSON) : this(new Uri(baseAddress), type) { }

    /// <summary>
    /// Setting AuthencationHeaderValue in Property AuthenticationHeaderValue and so in Property Client. Also returns the value for manipulation and setting it manually
    /// </summary>
    /// <param name="scheme"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public AuthenticationHeaderValue CreateAuthenticationHeaderValue(string scheme, string parameter) => this.AuthenticationHeaderValue = new AuthenticationHeaderValue(scheme, parameter);

    public async Task<T> SendAsync<T>(HttpRequestMethod method, string requestUri, HttpContent body = null, ContentType type = ContentType.Default) => await SendAsync<T>(method, new Uri(requestUri), body, type);
    public async Task<T> SendAsync<T>(HttpRequestMethod method, Uri uri, HttpContent body = null, ContentType type = ContentType.Default)
    {
      if (type == ContentType.Default) type = ResultContentType;
      HttpContent content = null;
      switch (method)
      {
        case HttpRequestMethod.GET:
          content = await SendGet(uri, body);
          break;
        case HttpRequestMethod.POST:
          content = await SendPost(uri, body);
          break;
        case HttpRequestMethod.PUT:
          content = await SendPut(uri, body);
          break;
        case HttpRequestMethod.PATCH:
          content = await SendPatch(uri, body);
          break;
        case HttpRequestMethod.DELETE:
          content = await SendDelete(uri, body);
          break;
        default: return default(T);
      }

      if (content != null)
      {
        string value = await content.ReadAsStringAsync();
        switch (type)
        {
          case ContentType.JSON: return JsonConvert.DeserializeObject<T>(value);
          /// case XML not tested currently
          case ContentType.XML: return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(value));
          default: throw new NotImplementedException($"The Deserilisation with the Content Type \"{type.ToString()}\" is not implemented.");
        }
      }
      return default(T);
    }

    private async Task<HttpContent> SendGet(Uri uri, HttpContent body, int currentTry = 0)
    {
      if (currentTry == Retrys) return null;
      HttpResponseMessage response = await Client.GetAsync(uri);
      if (!response.IsSuccessStatusCode)
      {
        return await SendGet(uri, body, ++currentTry);
      }
      return response.Content;
    }

    private async Task<HttpContent> SendPost(Uri uri, HttpContent body, int currentTry = 0)
    {
      if (currentTry == Retrys) return null;
      HttpResponseMessage response = await Client.PostAsync(uri, body);
      if (!response.IsSuccessStatusCode)
      {
        return await SendPost(uri, body, ++currentTry);
      }
      return response.Content;
    }

    private async Task<HttpContent> SendPut(Uri uri, HttpContent body, int currentTry = 0)
    {
      if (currentTry == Retrys) return null;
      HttpResponseMessage response = await Client.PutAsync(uri, body);
      if (!response.IsSuccessStatusCode)
      {
        return await SendPut(uri, body, ++currentTry);
      }
      return response.Content;
    }

    private async Task<HttpContent> SendPatch(Uri uri, HttpContent body, int currentTry = 0)
    {
      if (currentTry == Retrys) return null;
      HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
      HttpResponseMessage response = await Client.SendAsync(msg);
      if (!response.IsSuccessStatusCode)
      {
        return await SendPatch(uri, body, ++currentTry);
      }
      return response.Content;
    }

    private async Task<HttpContent> SendDelete(Uri uri, HttpContent body, int currentTry = 0)
    {
      if (currentTry == Retrys) return null;
      HttpResponseMessage response = await Client.DeleteAsync(uri);
      if (!response.IsSuccessStatusCode)
      {
        return await SendDelete(uri, body, ++currentTry);
      }
      return response.Content;
    }
  }
}
