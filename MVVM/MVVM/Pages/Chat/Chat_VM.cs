using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class Chat_DM : BaseDataModel
  {
    public string Author { get => _Author; set => SP(ref _Author, value); }
    private string _Author;
    public string Target { get => _Target; set => SP(ref _Target, value); }
    private string _Target;
    public string Message { get => _Message; set => SP(ref _Message, value); }
    private string _Message;

    public override string ToString()
    {
      return $"{Author} >> {Target} # {Message}";
    }
  }

  public class Chat_VM : BaseViewModel<Chat_Page>
  {
    public BigDataList<Chat_DM> ChatListe { get => _ChatListe; set => SP(ref _ChatListe, value); }
    private BigDataList<Chat_DM> _ChatListe = new BigDataList<Chat_DM>();
    public string Message { get => _Message; set => SP(ref _Message, value); }
    private string _Message;
    public ICommand CM_Send { get => _CM_Send ?? (_CM_Send = new Command(OnSend)); }
    private Command _CM_Send;
    public string Author { get => _Author; set => SP(ref _Author, value); }
    private string _Author;

    TcpClient client = null;
    NetworkStream stream = null;

    public Chat_VM(string author, string target)
    {
      this.Title = target;
      this.Author = author;
      client = new TcpClient("192.168.137.2", 9999);
      stream = client.GetStream();
      byte[] cmd = Encoding.UTF8.GetBytes($"Task - Connect # {Author} >> {Title}");
      stream.Write(cmd, 0, cmd.Length);

      byte[] result = new byte[1024];
      stream.Read(result, 0, result.Length);
      string json = Encoding.UTF8.GetString(result).Trim('\0');
      List<string> list = JsonConvert.DeserializeObject<List<string>>(json);
      foreach (string item in list)
      {
        //$"{Author} >> {Target} # {Message}"
        string a = item.Split(">>".ToCharArray())[0].Trim();
        string t1 = item.Split(">>".ToCharArray())[2];
        string b = item.Split(">>".ToCharArray())[2].Split("#".ToCharArray())[0].Trim();
        string c = item.Split("#".ToCharArray())[1].Trim();
        ChatListe.Add(new Chat_DM { Author = a, Target = b, Message = c });
      }
    }

    public void OnSend(object obj)
    {
      Chat_DM chat = new Chat_DM() { Author = Author, Target = Title, Message = Message};
      ChatListe.Add(chat);
      byte[] buffer = Encoding.UTF8.GetBytes(chat.ToString());
      stream.Write(buffer, 0, buffer.Length);
      Message = string.Empty;
    }

    public override void OnDisappearing(bool isGoingBack)
    {
      byte[] cmd = Encoding.UTF8.GetBytes("Task - Disconnect");
      stream.Write(cmd, 0, cmd.Length);
      stream.Close();
      client.Close();
      base.OnDisappearing(isGoingBack);
    }
  }
}
