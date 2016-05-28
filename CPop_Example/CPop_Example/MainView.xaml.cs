using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CPop_Example
{
    public partial class MainView : ContentPage
    {   

        public String Text { get; set; }

        public ContentView Dialog { get; set; }
        public Boolean ShowDialog { get; set; }
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }

        public MainView()
        {
            InitializeComponent();

            btnShow.Clicked += BtnShow_Clicked;

            Text = "This is the main view";

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
    }
}
