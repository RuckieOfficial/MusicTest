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
    /// Interakční logika pro GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page {

        private Frame parentFrame;
        private string GrroupName;
        public GenrePage() {
            InitializeComponent();
        }

        public GenrePage(Frame parentFrame, string GroupName) : this() {
            this.parentFrame = parentFrame;
            this.GrroupName = GroupName;

            this.GroupName.Content = GroupName;
            LoadGroupID();
        }
        public async void LoadGroupID() {
            int id = 0;
            List<Group> genres = new List<Group>();
            genres = await MySQL.Database.GetItemsAsync();

            foreach (Group item in genres) {
                if (item.Name == GrroupName) {
                    id = item.Id;
                }
            }
            LoadMeta(id);
        }

        public async void LoadMeta(int ID) {
            List<Meta> meta = new List<Meta>();
            List<int> genreids = new List<int>();
            meta = await MySQL.Database.GetItemsAsync3();

            foreach (Meta item in meta) {
                if (item.GroupID == ID) {
                    genreids.Add(item.GenreID);
                }
            }
            LoadGroupAsync(genreids);
        }
        public async void LoadGroupAsync(List<int> ids) {
            List<Gendre> groups = new List<Gendre>();
            groups = await MySQL.Database.GetItemsAsync2();

            foreach (Gendre item in groups) {
                foreach (int item2 in ids) {
                    if (item.Id == item2) {
                        
                        Label label = new Label();
                        label.Content = item.Name;
                        label.FontSize = 25;
                        
                        
                        
                        GenrePanel.Children.Add(label);
                    }
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            parentFrame.Navigate(new MainPage(parentFrame));
        }
    }
}
