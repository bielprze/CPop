using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CPop_Example
{
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
}
