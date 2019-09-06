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
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtSourceValue.Focus();
        }

        private void Entry_PsiTextChanged(object sender, TextChangedEventArgs e)
        {


            String newVal = e.NewTextValue;
            Calc(newVal);
        }

        private void Calc(string newVal)
        {
            if (newVal != null && newVal.Length != 0)
            {
                switch (curCalcMode)
                {
                    case CalcMode.PSI_TO_BAR:
                        {
                            LblResult.Text = (Double.Parse(newVal) / CONVERTVALUE).ToString();
                            break;
                        }
                    case CalcMode.BAR_TO_PSI:
                        {
                            LblResult.Text = (Double.Parse(newVal) * CONVERTVALUE).ToString();
                            break;
                        }

                }
            }
            else
            {
                LblResult.Text = "";
            }
        }

        private void OnConverterChanged(object sender, EventArgs e)
        {
            switch(curCalcMode)
            {
                case CalcMode.BAR_TO_PSI:
                    {
                        btnChangeCalcMode.Text = "<-->";
                        LblSourceUnit.Text = "Psi";
                        LblResultUnit.Text = "Bar";
                        curCalcMode = CalcMode.PSI_TO_BAR;
                        SwitchSourceAndResultValues();
                        break;
                    }
                case CalcMode.PSI_TO_BAR:
                    {
                        btnChangeCalcMode.Text = "<-->";

                        LblSourceUnit.Text = "Bar";
                        LblResultUnit.Text = "Psi";

                        curCalcMode = CalcMode.BAR_TO_PSI;
                        SwitchSourceAndResultValues();
                        break;
                    }
            }
        }

        private void SwitchSourceAndResultValues()
        {
            string sourceVal = txtSourceValue.Text;
            string resultVal = LblResult.Text;
            txtSourceValue.Text = resultVal;
            LblResult.Text = sourceVal;
        }
    }
}