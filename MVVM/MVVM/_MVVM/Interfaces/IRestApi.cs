using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVVM
{
  public interface IRestApi
  {
    int Retrys { get; set; }
    TimeSpan Timeout { get; set; }
    HttpClient Client { get; }
    ContentType ResultContentType { get; set; }
    AuthenticationHeaderValue AuthenticationHeaderValue { get; set; }

    AuthenticationHeaderValue CreateAuthenticationHeaderValue(string scheme, string parameter);
    Task<T> SendAsync<T>(HttpRequestMethod method, string requestUri, HttpContent body = null, ContentType type = ContentType.Default);
    Task<T> SendAsync<T>(HttpRequestMethod method, Uri uri, HttpContent body = null, ContentType type = ContentType.Default);
  }
}
