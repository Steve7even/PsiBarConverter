using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PsiBarConverter.Views;
using PsiBarConverter.ViewModels;
using PsiBarConverter.Util;

namespace PsiBarConverter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {

        private const double CONVERTVALUE = 14.504;

        enum CalcMode { PSI_TO_BAR, BAR_TO_PSI };

        private CalcMode curCalcMode = CalcMode.PSI_TO_BAR;

        public ItemsPage()
        {
            InitializeComponent();
            Title = "Converter";
            btnChangeCalcMode.Text = "<-->";
            curCalcMode = CalcMode.PSI_TO_BAR;
            BindingContext = new ConverterModel();
        }

        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            txtSourceValue.CursorPosition = 0;
            txtSourceValue.SelectionLength = txtSourceValue.Text.Length;
            await Task.Delay(600);
            txtSourceValue.Unfocus();
            txtSourceValue.Focus();
        }

       
    }
}