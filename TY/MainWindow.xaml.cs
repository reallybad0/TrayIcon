using System;
using System.Collections.Generic;
using System.IO;
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

namespace TY
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player = new MediaPlayer();
        public MainWindow()
        { 
            InitializeComponent();
            
        }
        public void CreateIcon()
        {
            System.Windows.Forms.NotifyIcon NotifyIcon = new System.Windows.Forms.NotifyIcon();
            NotifyIcon.Icon = new System.Drawing.Icon("dino.ico");
            NotifyIcon.Visible = true;
            NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(NotifyClicked);

            // NotifyIcon.ShowBalloonTip(100, "Varování", "Byl jste varován", System.Windows.Forms.ToolTipIcon.Info);

            System.Windows.Forms.ContextMenu NotifyIconContextMenu = new System.Windows.Forms.ContextMenu();
            NotifyIconContextMenu.MenuItems.Add("Maximalizovat", new EventHandler(Open));
            NotifyIconContextMenu.MenuItems.Add("Vypnout appku", new EventHandler(Close));
            NotifyIconContextMenu.MenuItems.Add("||", new EventHandler(Pause));
            NotifyIconContextMenu.MenuItems.Add("►", new EventHandler(Play));
            NotifyIconContextMenu.MenuItems.Add("Stop", new EventHandler(Stop));
            NotifyIcon.ContextMenu = NotifyIconContextMenu;
        }

        //APP
        private void Open(object sender,EventArgs e) {
            this.Show();
        //    this.WindowState = WindowState.Normal;
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();

        }
        //MUSIC
        private void Pause(object sender, EventArgs e)
        {
            player.Pause();
        }
        private void Play(object sender, EventArgs e)
        {
            player.Play();
        }
        private void Stop(object sender, EventArgs e)
        {
            player.Stop();
        }


        //Clicked On Button
        private void NotifyClicked(object sender,System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Uri uri = new Uri(GetSoundFilePath("win.wav"));

                player.Open(uri);
                player.Play();

                MessageBox.Show("Vítejte");
                this.Show();

               // this.WindowState = WindowState.Normal;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateIcon();
            this.Hide();
        }
        public string GetSoundFilePath(string fileName)
        {
            string dirpath = @Directory.GetCurrentDirectory();
            //var gparent = Directory.GetParent(Directory.GetParent(dirpath).ToString());
            string imgfolder = System.IO.Path.Combine(dirpath.ToString(), fileName);
            return imgfolder;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(GetSoundFilePath("G" + ".wav"));

            //var player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }
    }
}
