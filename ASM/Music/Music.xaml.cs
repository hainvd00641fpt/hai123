using ASM.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ASM.Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Music : Page
    {
        private bool _isPlaying = false;

        private int _currentIndex = 0;
        private ObservableCollection<Song> listSong;

        internal ObservableCollection<Song> ListSong { get => listSong; set => listSong = value; }

        public Music()
        {
            this.ListSong = new ObservableCollection<Song>();
            this.ListSong.Add(new Song()
            {
                name = "Thằng điên",
                singer = "",
                thumbnail = "https://photo-zmp3.zadn.vn/thumb/94_94/cover/9/d/5/c/9d5c56a277a06a48ec7956a4fd17e4c1.jpg",
                link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui969/NhuLoiDon-BaoAnh-5700656.mp3"
            });
            this.ListSong.Add(new Song()
            {
                name = "HongKhong1",
                singer = "",
                thumbnail = "https://photo-zmp3.zadn.vn/thumb/94_94/cover/2/4/3/6/2436b0b8130f7c2199d9803c0b85d57d.jpg",
                link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui969/NhuLoiDon-BaoAnh-5700656.mp3"
            });
            this.ListSong.Add(new Song()
            {
                name = "bai hat 3",
                singer = "",
                thumbnail = "https://photo-zmp3.zadn.vn/thumb/94_94/cover/9/9/7/2/997250daaebfe5c1a8f29a5fce90248a.jpg",
                link = "https://c1-ex-swe.nixcdn.com/NhacCuaTui969/NhuLoiDon-BaoAnh-5700656.mp3"
            });
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Song song = new Song()
            {
                name = this.SongName.Text,
                thumbnail = this.SongThumbnail.Text

            };
            this.ListSong.Add(song);
            this.SongName.Text = string.Empty;
            this.SongThumbnail.Text = string.Empty;
            SongModel.ADD(song);
        }
        private void Choosed_Song(object sender, TappedRoutedEventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            Song choosed = panel.Tag as Song;
            _currentIndex = this.MyListSong.SelectedIndex;
            Uri mp3Link = new Uri(choosed.link);
            this.MyPlayer.Source = mp3Link;
            this.Song_Name.Text = this.ListSong[_currentIndex].name + " - " + this.ListSong[_currentIndex].singer;
            Play_Song();
        }

        private void Play_Song()
        {
            _isPlaying = true;
            this.Player_Status.Text = "Now Playing: ";
            this.MyPlayer.Play();
            this.Play_Button.Symbol = Symbol.Pause;
        }

        private void Pause_Song()
        {
            _isPlaying = false;
            this.Player_Status.Text = "Paused: ";
            this.MyPlayer.Pause();
            this.Play_Button.Symbol = Symbol.Play;
        }

        private void Click_Play(object sender, RoutedEventArgs e)
        {
            if (_isPlaying)
            {
                Pause_Song();
            }
            else
            {
                Play_Song();
            }
        }

        private void Do_Next(object sender, RoutedEventArgs e)
        {
            Pause_Song();
            _currentIndex += 1;
            if (_currentIndex >= this.ListSong.Count)
            {
                _currentIndex = 0;
            }
            Uri mp3Link = new Uri(this.ListSong[_currentIndex].link);
            this.MyPlayer.Source = mp3Link;
            this.Song_Name.Text = this.ListSong[_currentIndex].name + " - " + this.ListSong[_currentIndex].singer;
            this.MyListSong.SelectedIndex = _currentIndex;
            Play_Song();
        }

        private void Do_Previous(object sender, RoutedEventArgs e)
        {
            Pause_Song();
            _currentIndex -= 1;
            if (_currentIndex < 0)
            {
                _currentIndex = this.ListSong.Count - 1;
            }
            Uri mp3Link = new Uri(this.ListSong[_currentIndex].link);
            this.MyPlayer.Source = mp3Link;
            this.Song_Name.Text = this.ListSong[_currentIndex].name + " - " + this.ListSong[_currentIndex].singer;
            this.MyListSong.SelectedIndex = _currentIndex;
            Play_Song();
        }
    }

}
