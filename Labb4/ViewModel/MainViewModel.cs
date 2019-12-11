using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Labb4.Model;
using Xamarin.Forms;

namespace Labb4.ViewModel
{
    public class MainViewModel : SimpleViewModel
    {
        private Country selectedCountry;
        private List<Country> countries;
        int index;
        public ICommand NextCountryCommand { get;  set; }
        public ICommand PrevCountryCommand { get;  set; }

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set { SetPropertyValue(ref selectedCountry, value); }
        }

        public MainViewModel()
        {
            CountryRepository CountryRepository = new CountryRepository();
            countries = CountryRepository.GetCountries();
            SelectedCountry = countries.ElementAt(0);
            NextBtnClicked();
            PrevBtnClicked();
        }

        private void NextBtnClicked()
        {
            NextCountryCommand = new Command(() =>
            {
                index++;
                if (index >= countries.Count())
                {
                    index = 0;
                }
                SelectedCountry = countries.ElementAt(index);
            });
        }

        private void PrevBtnClicked()
        {
            PrevCountryCommand = new Command(() =>
            {
                index--;
                if (index < 0)
                {
                    index = countries.Count() - 1;
                }
                SelectedCountry = countries.ElementAt(index);
            });
        }
    }
}