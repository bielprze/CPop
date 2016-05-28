# CPop
A popup solution for Xamarin Forms

###Feel free to use, mentioning to the author: Federico Calvagna.

To use CPop extension, install CPop Nuget on your project
  
> PM Install-Package Calvagna.CPop

On the page that you want to have a popup, add the component

```
<calvagna:CPop Dialog="{Binding Dialog}"
               ShowDialog="{Binding ShowDialog}"
               BackgroundColor="{Binding BackColor}"
               BorderColor="{Binding BorderColor}" />
```

And add the namespace

```
xmlns:calvagna="clr-namespace:Calvagna.CPop;assembly=Calvagna.CPop"
```

Then you define a ContentView that will be your popup, for example

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentView xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="CPop_Example.PopupView">

  <StackLayout>

    <Label Text="This is the popup view" VerticalOptions="Center" HorizontalOptions="Center" />

    <Button x:Name="btnClose" Text="Close modal" />

  </StackLayout>
  
</ContentView>
```

In the codebehind define some result for the popup, for example:

```
public partial class PopupView : ContentView
{

    public event EventHandler<PopupEventArgs> Complete;
    public PopupView()
    {
        InitializeComponent();

        btnClose.Clicked += BtnClose_Clicked;
    }

    private void BtnClose_Clicked(object sender, EventArgs e)
    {
        Complete?.Invoke(this, new PopupEventArgs { Result = "Hello" });
    }

    public class PopupEventArgs : EventArgs
    {
        public String Result { get; internal set; }
    }
}
```

And on the main page, initialize properties and call the popup

````
public ContentView Dialog { get; set; }
public Boolean ShowDialog { get; set; }
public Color BackColor { get; set; }
public Color BorderColor { get; set; }

public MainView()
{
    InitializeComponent();

    btnShow.Clicked += BtnShow_Clicked;
    
    var popup = new PopupView();
    popup.Complete += Popup_Complete;

    Dialog = popup;
    BackColor = Color.Green;
    BorderColor = Color.Red;

    BindingContext = this;
}

private void Popup_Complete(object sender, PopupView.PopupEventArgs e)
{
    Text = $"Popup result: {e.Result}";
    ShowDialog = false;

    OnPropertyChanged("ShowDialog");
    OnPropertyChanged("Text");
}

private void BtnShow_Clicked(object sender, EventArgs e)
{
    ShowDialog = true;
    OnPropertyChanged("ShowDialog");
}
```

And that's all.

It's working on Android, iOS and Windows.
