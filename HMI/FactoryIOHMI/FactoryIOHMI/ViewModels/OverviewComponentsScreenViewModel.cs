using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryIOHMI.Models;
using FactoryIOHMI.Commands;

namespace FactoryIOHMI.ViewModels
{
    public class OverviewComponentsScreenViewModel : INotifyPropertyChanged
    {
        #region Properties

        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            private set
            {
                _pageIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PageIndex)));
            }
        }
        public int ItemsPerRow { get; private set; } = 4;
        public int PageSize { get; } = 6;

        public int TotalPages => (int)Math.Ceiling(AllMachineComponents.Count / (double)PageSize);
        public ObservableCollection<MachineComponent> AllMachineComponents { get; }
        public ObservableCollection<MachineComponent> MachineComponentPage { get; }
        public MainScreenViewModel ParentViewModel { get; private set; }
        public ICommand NextPage { get; set; }
        public ICommand PreviousPage { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public OverviewComponentsScreenViewModel()
        {
            PageIndex = 0;
            AllMachineComponents = new ObservableCollection<MachineComponent>();
            MachineComponentPage = new ObservableCollection<MachineComponent>();
            ParentViewModel = null;
            NextPage = new RelayCommand(NextPageExecute, NextPageCanExecute);
            PreviousPage = new RelayCommand(PreviousPageCommandExecute, PreviousPageCommandCanExecute);
            RefreshPage();
        }
        public OverviewComponentsScreenViewModel(MainScreenViewModel parentViewModel)
        {
            PageIndex = 0;
            AllMachineComponents = new ObservableCollection<MachineComponent>();
            MachineComponentPage = new ObservableCollection<MachineComponent>();
            ParentViewModel = parentViewModel;
            NextPage = new RelayCommand(NextPageExecute, NextPageCanExecute);
            PreviousPage = new RelayCommand(PreviousPageCommandExecute, PreviousPageCommandCanExecute);
            Commissing();
            RefreshPage();
        }
        #endregion

        #region Command-Methods
        public void NextPageExecute(object par)
        {
            PageIndex++;
            RefreshPage();
        }
        public bool NextPageCanExecute(object par)
        {
            return PageIndex < TotalPages - 1;
        }
        public void PreviousPageCommandExecute(object par)
        {
            PageIndex--;
            RefreshPage();
        }
        public bool PreviousPageCommandCanExecute(object par)
        {
            return PageIndex > 0;
        }
        #endregion

        #region Methods
        private void RefreshPage()
        {
            MachineComponentPage.Clear();

            foreach (var item in AllMachineComponents.Skip(PageIndex * PageSize).Take(PageSize))
                MachineComponentPage.Add(item);
        }
        private void Commissing()
        {
            for (int i = 1; i <= 25; i++)
                AllMachineComponents.Add(new MachineComponent { Name = $"Item {i}" });
        }
        #endregion
    }
}
