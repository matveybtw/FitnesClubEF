
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFbase;

namespace FitnesClubEF
{
    public class MainWindowViewmodel : OnPropertyChangedHandler
    {
        public MainWindowViewmodel()
        {
            //Refresh.Execute(123);
        }
        public MyVisitor selectedv => MyVisitors[selected.Item];
        public ChangingItem<int> selected { get; set; } = new ChangingItem<int>();
        public ICommand Refresh => new RelayCommand(o =>
        {
            var list = FitnesClubDB.SelectMyVisitors();
            MyVisitors = new ObservableCollection<MyVisitor>(list);
            OnPropertyChanged(nameof(MyVisitors));
        });
        public ICommand Add => new RelayCommand(o =>
        {
            UserUpdate win = new UserUpdate(new MyVisitor());
            if (win.ShowDialog() != null)
            {
                if (win.MyVisitor != new MyVisitor())
                {
                    FitnesClubDB.Insert(win.MyVisitor);
                    Refresh.Execute(1);
                }
            }
        });
        public ICommand Update => new RelayCommand(o =>
        {
            UserUpdate win = new UserUpdate(selectedv);
            if (win.ShowDialog() != null)
            {
                if (win.MyVisitor != new MyVisitor())
                {
                    FitnesClubDB.Update(win.MyVisitor);
                    Refresh.Execute(1);
                }
            }
        });
        public ICommand Delete => new RelayCommand(o =>
        {
            FitnesClubDB.Delete(selectedv);
            Refresh.Execute(1);
        });
        public ObservableCollection<MyVisitor> MyVisitors { get; set; }
    }
}