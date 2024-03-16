using System;
using System.Windows;
using System.Windows.Media;
using System.Media;
using System.IO;


namespace Soundtrack
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer player = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private string[]files;
        public int currentTrackIndex = 0;
        public MediaPlayer mediaPlayer = new MediaPlayer();
        private void Button_play_Click(object sender, RoutedEventArgs e)
        {
            string folderPath1 = Path.Combine(Directory.GetCurrentDirectory(),"Playlist");
            files = Directory.GetFiles(folderPath1, "*.mp3");
            mediaPlayer.Open(new Uri(files[currentTrackIndex]));
            Play_Next_Track_After_Completion();
        }
        private void Play_Next_Track_After_Completion() //Воспроизведение после завершения трека 
        { 
                    mediaPlayer.MediaEnded += (s, args) =>
                    {
                        Pause_PlayLast();
                    };
                    mediaPlayer.Play();
        }
        public void Pause()
        {
                if (mediaPlayer != null)
                {
                mediaPlayer.Pause();
                }
        }
        private void Button_PlayLast_Click(object sender, RoutedEventArgs e)
        {
            Pause_PlayLast();
        }
        public void Pause_PlayLast() 
        {
            if ((++currentTrackIndex) == files.Length)
                currentTrackIndex = 0;
            mediaPlayer.Open(new Uri(files[currentTrackIndex]));
            mediaPlayer.Play();
        }

        private void Button_Pause_Checked(object sender, RoutedEventArgs e)
        {

            if (mediaPlayer != null)
            {
                mediaPlayer.Pause();
            }
        }

        private void Button_Pause_Unchecked(object sender, RoutedEventArgs e)
        {
                mediaPlayer.Play();
        }
    }
    
}
