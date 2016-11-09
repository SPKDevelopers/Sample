using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleUWA.ClassLibrary;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleUWA.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Objects
        /// <summary>
        /// Master list
        /// </summary>
        private ObservableCollection<Master> masterList;

        /// <summary>
        /// DetailList
        /// </summary>
        private ObservableCollection<Detail> detailList;
        public ObservableCollection<Detail> DetailList
        {
            get
            {
                return detailList;
            }
            set
            {
                Set(ref detailList, value);
            }
        }
        #endregion
        
        public MainViewModel()
        {
            masterList = new ObservableCollection<Master>();
            DetailList = new ObservableCollection<Detail>();

            if (IsInDesignMode)
            {
                DetailList = new ObservableCollection<Detail>()
                {
                    new Detail()
                    {
                        Name = "EXAMPLE DETAIL"
                    }
                };
            }
            else
            {
                fill();
            }
        }

        private void fill()
        {
            for (int i = 1; i < 5; i++)
            {
                Master newMaster = new Master()
                {
                    Name = "MASTER " + i.ToString()
                };

                newMaster.Details = new ObservableCollection<Detail>();

                for (int x = 0; x < 50; x++)
                {
                    newMaster.Details.Add(new Detail()
                    {
                        Name = newMaster.Name + " - DETAIL " + x.ToString()
                    });
                }

                masterList.Add(newMaster);
            }
        }

        private RelayCommand<string> _selectMasterCommand;
        public RelayCommand<string> SelectMasterCommand
        {
            get
            {
                return _selectMasterCommand
                       ?? (_selectMasterCommand = new RelayCommand<string>(
                           (name) =>
                           {
                               DetailList = new ObservableCollection<Detail>(masterList.First(m => m.Name == name).Details);
                           }));
            }
        }
    }
}