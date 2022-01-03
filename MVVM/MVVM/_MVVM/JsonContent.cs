using System.Net.Http;
using System.Text;

namespace Orderdent
{
  public class JsonContent : StringContent
  {
    public JsonContent(string content) : base(content, Encoding.UTF8, "application/json") { }
    //
    // Zusammenfassung:
    //     Creates a new instance of the System.Net.Http.StringContent class.
    //
    // Parameter:
    //   content:
    //     The content used to initialize the System.Net.Http.StringContent.
    //
    //   encoding:
    //     The encoding to use for the content.
    public JsonContent(string content, Encoding encoding) : base(content, encoding, "application/json") { }
  }
}
