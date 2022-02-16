using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM
{
  public class Home_VM : BaseViewModel<Home_Page>
  {
    public ICommand CM_OpenSettings { get => _CM_OpenSettings ?? (_CM_OpenSettings = new Command(OnOpenSettings)); }
    private Command _CM_OpenSettings;
    public ICommand CM_Add { get => _CM_Add ?? (_CM_Add = new Command(OnAdd)); }
    private Command _CM_Add;
    public ICommand CM_Edit { get => _CM_Edit ?? (_CM_Edit = new Command(OnEdit)); }
    private Command _CM_Edit;
    public ICommand CM_Del { get => _CM_Del ?? (_CM_Del = new Command(OnDel)); }
    private Command _CM_Del;

    public int Id { get => _Id; set => SP(ref _Id, value); }
    private int _Id = -1;
    public string Content { get => _Content; set => SP(ref _Content, value); }
    private string _Content;

    public DataList<string> SimpleList { get => _SimpleList; set => SP(ref _SimpleList, value); }
    private DataList<string> _SimpleList = new DataList<string>()
    {
      "First Element"
    };
    public DataList<Home_DM> ComplexList { get => _ComplexList; set => SP(ref _ComplexList, value); }
    private DataList<Home_DM> _ComplexList = new DataList<Home_DM>()
    {
      new Home_DM { Name = "Element", Vorname = "First" }
    };

    public override void OnAppearing(bool isGoingBack)
    {
      Title = "Home";
    }

    private async void OnOpenSettings(object obj)
    {
      bool modal = Boolean.Parse(obj.ToString());
      await new Settings_VM(modal).ShowAsync(modal);
    }
    private void OnAdd(object obj)
    {
      bool.TryParse(obj.ToString(), out bool useComplex);
      if (useComplex)
      {
        ComplexList.Add(new Home_DM { Vorname = Content, Name = "CElement" });
      }
      else
      {
        SimpleList.Add(Content);
      }
      Content = string.Empty;
    }
    private void OnEdit(object obj)
    {
      bool.TryParse(obj.ToString(), out bool useComplex);
      if (useComplex)
      {
        ComplexList[Id].Vorname = Content;
      }
      else
      {
        SimpleList[Id] = Content;
      }
      Content = string.Empty;
      Id = -1;
    }
    private void OnDel(object obj)
    {
      bool.TryParse(obj.ToString(), out bool useComplex);
      if (useComplex)
      {
        ComplexList.RemoveAt(Id);
      }
      else
      {
        SimpleList.RemoveAt(Id);
      }
      Id = -1;
    }
  }
}
