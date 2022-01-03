# MVVM
 Simple MVVM Framework for Xamarin Projects

## Voraussetzungen
Zielframework: .NET Standard 2.0
Beim Anlegen des Projektes keine AppShell verwenden ansonsten die Datei AppShell löschen
Jede Page benötigt ein ViewModel

## Implementierung
1. Ordner _MVVM in das Hauptprojekt kopieren
2. Services kopieren
	a. Entweder den kompletten Ordner samt Inhalt oder
	b. Nur die Klassen die mit _SV enden
		- Und in der eigenen Services.cs File die beiden Service hinterlegen
3. Denn gesamten UI Ordner aus MVVM.Android in das Android Projekt kopieren
4. In der Android MainActivity.cs folgende Zeile hinzufügen in die OnCreate Methode `StatusColor.Init(this);`
5. Im Hauptprojekt zu jeder Page ein ViewModel anlegen welches vom BaseViewModel erbt und als Generic Parameter die Page bekommt. 
   Beispiel: `public class Main_VM : BaseViewModel<Main_Page>`
6. In der App.xaml.cs die MainPage zuweisung gegen das Main_VM ersetzten und die Methode MainPage aufrufen. Beispiel: `MainPage = new Main_VM().MainPage();`

### Navigieren innerhalb der App
- `await new Home_VM().ShowAsync();`

## Versionsverlauf
Version 1.0:
	- Basis Framework
