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
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        private Frame parentFrame;
        public MainPage() {
            InitializeComponent();
            LoadGenres();
            LoadGroups();
        }
        public MainPage(Frame parentFrame) : this() {
            this.parentFrame = parentFrame;
            
        }
        public async void LoadGenres() {
            List<Gendre> genre = new List<Gendre>();
            genre = await MySQL.Database.GetItemsAsync2();
            foreach(Gendre item in genre) {
                GenreBox.Items.Add(item.Name);
                GenreBox2.Items.Add(item.Name);
            }
        }
        public async void LoadGroups() {
            List<Group> groups = new List<Group>();
            groups = await MySQL.Database.GetItemsAsync();

            foreach(Group item in groups) {
                GroupBox.Items.Add(item.Name);
            }
        }
        private void Send_Click(object sender, RoutedEventArgs e) {
            string selected = GenreBox.Text;
            if (selected != "Vyber") {
                parentFrame.Navigate(new GroupPage(parentFrame, selected));
            }else {
                MessageBox.Show("Vyber něco");
            }
        }

        private void Genre_create(object sender, RoutedEventArgs e) {
            Genres(GenreC.Text.ToString());
            MessageBox.Show("Žánr byl přidán");
        }

        private void SendGroup_Click(object sender, RoutedEventArgs e) {
            string selected = GroupBox.Text;
            if (selected != "Vyber") {
                parentFrame.Navigate(new GenrePage(parentFrame, selected));
            } else {
                MessageBox.Show("Vyber něco");
            }
        }
        public async void Genres(string Name) {
            await MySQL.Database.SaveItemAsync2(new Gendre { Name = Name });
        }
        public async void Groups(string Name, int Year) {
            int ID = 0;
            await MySQL.Database.SaveItemAsync(new Group { Name = Name, Year = Year });
        }

        public async void Meta() {
            await MySQL.Database.SaveItemAsync3(new Meta { GenreID = 3, GroupID = 2 });
        }


        private void Add_Click(object sender, RoutedEventArgs e) {
            if (NameBox.Text != null && YearBox.Text != null && GenreBox2.Text != "Vyber") {
                MessageBox.Show("DONE");
                Groups2(NameBox.Text, Int32.Parse(YearBox.Text.ToString()));
            }
        }

        public async void Groups2(string Name, int Year) {
            int ID = 0;
            await MySQL.Database.SaveItemAsync(new Group { Name = Name, Year = Year });

            LoadGroups2(Name);
        }
        public async void LoadGroups2(string Name) {
            int id = 0;
            List<Group> groups = new List<Group>();
            groups = await MySQL.Database.GetItemsAsync();

            foreach (Group item in groups) {
                if (item.Name == Name) {
                    id = item.Id;
                }
            }
            Meta2(id);
        }
        public async void Meta2(int ID) {
            int id = 0;
            List<Gendre> genres = new List<Gendre>();
            genres = await MySQL.Database.GetItemsAsync2();

            foreach (Gendre item in genres) {
                if (item.Name == GenreBox2.Text.ToString()) {
                    id = item.Id;
                }
            }

            await MySQL.Database.SaveItemAsync3(new Meta { GenreID = id, GroupID = ID });

        }

    }
}
