using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp {
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            myFrame.Navigate(new MainPage(myFrame));
        }
        public async void Genres(string Name) {
            await MySQL.Database.SaveItemAsync2(new Gendre { Name = Name});
        }
        public async void Groups(string Name, int Year) {
            int ID = 0;
            await MySQL.Database.SaveItemAsync(new Group { Name = Name, Year = Year });

            LoadGroups(Name);
        }
        public async void LoadGroups(string Name) {
            int id = 0;
            List<Group> groups = new List<Group>();
            groups = await MySQL.Database.GetItemsAsync();

            foreach(Group item in groups) {
                if (item.Name == Name) {
                    id = item.Id;
                }
            }
        }
        public async void Meta() {
            await MySQL.Database.SaveItemAsync3(new Meta { GenreID = 3, GroupID = 2 });
        }
        public void Clear() {
            MySQL.Database.Clear();
        }
    }
}
