using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PsiBarConverter.Util
{
    class ConverterModel : INotifyPropertyChanged
    {
        private readonly double CONVERTVALUE = 14.504;

        double psi = 0.0;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public double Psi {
            set
            {
                if (PropertyChanged != null)
                {
                   
                    if (psi != value)
                    {
                        bar = Math.Round(value / CONVERTVALUE, 5);
                    }
                    psi = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Bar"));
                    
                }
            }
            get
            {
                return psi;
            }
        }
        
        public double bar = 0.0;

        public double Bar
        {
            set
            {
                if (PropertyChanged != null)
                {
                    
                    if (bar != value)
                    {
                        psi = Math.Round(value * CONVERTVALUE, 5);
                    }
                    bar = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Psi"));
                }
            }
            get
            {
                return bar;
            }
        }
    }
}
