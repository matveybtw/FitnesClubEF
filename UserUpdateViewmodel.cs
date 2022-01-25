using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFbase;

namespace FitnesClubEF
{
    public class UserUpdateViewmodel : OnPropertyChangedHandler
    {
        public MyVisitor MyVisitor { get; set; }
        UserUpdate window;
        public UserUpdateViewmodel(MyVisitor v, UserUpdate uu)
        {
            window = uu;
            MyVisitor = v;
            LastName.Item = v.LastName;
            FirstName.Item = v.FirstName;
            Birthday = v.Birthday;
            Phone.Item = v.Phone;
            Balance.Item = v.Balance.ToString();
            Birthday = DateTime.Now;
        }
        public ChangingItem<string> LastName { get; set; } = new ChangingItem<string>();
        public ChangingItem<string> FirstName { get; set; } = new ChangingItem<string>();
        public DateTime Birthday
        {
            get => bd;
            set
            {
                bd = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }
        DateTime bd;

        public ChangingItem<string> Phone { get; set; } = new ChangingItem<string>();
        public ChangingItem<string> Balance { get; set; } = new ChangingItem<string>();
        public ICommand Save => new RelayCommand(o =>
        {
            MyVisitor.LastName = LastName.Item;
            MyVisitor.FirstName = FirstName.Item;
            MyVisitor.Birthday = Birthday;
            MyVisitor.Phone = Phone.Item;
            MyVisitor.Balance = double.Parse(Balance.Item.Replace('.', ','));
            window.Close(MyVisitor);
        });
        public ICommand Cancel => new RelayCommand(o =>
        {
            window.Close(MyVisitor);
        });
    }
}
