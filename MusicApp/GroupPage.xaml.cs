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
    /// Interakční logika pro GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page {
        private Frame parentFrame;
        private string GenreName;
        public GroupPage() {
            InitializeComponent();
            
        }
        
        public GroupPage(Frame parentFrame, string GenreName) : this() {
            this.parentFrame = parentFrame;
            this.GenreName = GenreName;

            LoadGenreID();
        }
        public async void LoadGenreID() {
            int id = 0;
            List<Gendre> genres = new List<Gendre>();
            genres = await MySQL.Database.GetItemsAsync2();

            foreach(Gendre item in genres) {
                if (item.Name == GenreName) {
                    id = item.Id;
                }
            }
            LoadMeta(id);
        }

        public async void LoadMeta(int ID) {
            List<Meta> meta = new List<Meta>();
            List<int> groupids = new List<int>();
            meta = await MySQL.Database.GetItemsAsync3();

            foreach(Meta item in meta) {
                if (item.GenreID == ID) {
                    groupids.Add(item.GroupID);
                }
            }
            LoadGroupAsync(groupids);
        }
        public async void LoadGroupAsync(List<int> ids) {
            List<Group> groups = new List<Group>();
            groups = await MySQL.Database.GetItemsAsync();

            foreach(Group item in groups) {
                foreach(int item2 in ids) {
                    if (item.Id == item2) {
                        StackPanel stack = new StackPanel();
                        stack.Orientation = Orientation.Horizontal;
                        Label label = new Label();
                        label.Content = item.Name;
                        label.Foreground = Brushes.White;
                        label.FontSize = 20;
                        Label label2 = new Label();
                        label2.Content = item.Year;
                        label2.FontSize = 20;
                        stack.Children.Add(label);
                        stack.Children.Add(label2);
                        GroupPanel.Children.Add(stack);
                    }
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            parentFrame.Navigate(new MainPage(parentFrame));
        }
    }
}
