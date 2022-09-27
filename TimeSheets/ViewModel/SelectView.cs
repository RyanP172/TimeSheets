using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimeSheets.Command;
using TimeSheets.View;

namespace TimeSheets.ViewModel
{
    public class SelectView : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public SelectView(AdminViewModel adminView, EmployeesViewModel employeesView)
        {
            AdminViewModel = adminView;
            EmployeesViewModel = employeesView;
            SelectedViewModel = EmployeesViewModel;
            SelectViewModelCommand = new AppCommands(SelectViewModel);



        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                NotifyPropertyChanged(nameof(SelectedViewModel));
            }

        }
        public AdminViewModel AdminViewModel { get; }
        public EmployeesViewModel EmployeesViewModel { get; }

        public AppCommands SelectViewModelCommand { get; }

        private void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;

        }

    }
}
