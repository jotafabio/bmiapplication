using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMIApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SwtGender_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                lblGenderValue.Text = "Female";
            }
            else
            {
                lblGenderValue.Text = "Male";
            }
        }

        private void stpWeight_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int h = (int)stpHeight.Value;
            int w = (int)e.NewValue;

            if (h == 0)
            {
                h = 1;
            }

            if (w == 0)
            { 
                h = 1; 
            }

            CalculateBMI(h, w);
        }

        private void stpHeight_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int h = (int)e.NewValue;
            int w = (int)stpWeight.Value;

            if (h == 0)
            {
                h = 1;
            }

            if (w == 0)
            {
                h = 1;
            }

            CalculateBMI(h, w);
        }

        private void CalculateBMI(int h, int w)
        {
            double _bmi;
            double _h = (double)h/100;
            _bmi = w / (_h * _h);
            lblBMIValue.Text = _bmi.ToString();
            lblBMIValueInterpreted.Text = InterpretBMI(_bmi);
        }

        private string InterpretBMI(double bmi)
        {
            double _bmi = bmi;
            string _interpreted_bmi = "Healthy";
            if (_bmi < 18)
            {
                _interpreted_bmi = "Underweight";
            };

            if (_bmi >= 18 && _bmi <= 25)
            {
                _interpreted_bmi = "Healthy";
            };

            if (_bmi > 25 && _bmi < 30)
            {
                _interpreted_bmi = "Overweight";
            };

            if (_bmi >= 30 && _bmi < 39)
            {
                _interpreted_bmi = "Obese";
            }
            if (_bmi >= 39)
            {
                _interpreted_bmi = "Extremely Obese";
            }

            return _interpreted_bmi;
        }

        private void cmdAbout_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("About BMI Calculator", "Created by: Jose Fabio Ribeiro Bezerra, Date: 27/03/2020. Stay healthy!", "OK");
        }
    }
}
