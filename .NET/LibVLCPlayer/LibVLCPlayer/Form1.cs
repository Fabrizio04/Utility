using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace LibVLCPlayer
{
    public partial class Form1 : Form
    {
        public LibVLC _libVLC;
        public MediaPlayer _mp;
        public Media media;

        public bool isFullscreen = false;
        public bool isMaxWindow = false;
        public bool goFS = false;
        public bool goPlay = false;
        public string onLoadPlay = @"";
        public string customIcon = @"";

        public bool isPlaying = false;
        public Size oldVideoSize;
        public Size oldFormSize;
        public Point oldVideoLocation;

        public Form1(string[] args)
        {
            InitializeComponent();
            Core.Initialize();

            if(args != null && args.Length > 0)
            {
                foreach (string param in args)
                {
                    if (param.Contains("/title="))
                        this.Text = param.Split("/title=")[1];

                    if (param.Contains("/ico="))
                    {
                        customIcon = @param.Split("/ico=")[1];
                        this.Icon = new Icon(@param.Split("/ico=")[1]);
                    }
                        
                    if (param.Contains("/file="))
                    {
                        goPlay = true;
                        onLoadPlay = param.Split("/file=")[1];
                    }

                    if (param.Contains("/maximized"))
                        this.WindowState = FormWindowState.Maximized;

                    if (param.Contains("/fullscreen"))
                        goFS = true;

                    if (param.Contains("/center"))
                        this.CenterToScreen();

                }
            }
            

            //Inizializzazione Shortcut
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ShortcutEvent);

            //Salvo posizioni di partenza
            oldVideoSize = videoView1.Size;
            oldFormSize = this.Size;
            oldVideoLocation = videoView1.Location;

            //VLC stuff
            _libVLC = new LibVLC();
            _mp = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mp;
        }

        private void schermoInternoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            menuStrip1.Visible = false; // goodbye menu strip
            videoView1.Size = this.Size; // make video the same size as the form
            videoView1.Location = new Point(0, 0); // remove the offset
            
            TopMost = true;
            
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                isMaxWindow = true;
            } else
            {
                isMaxWindow = false;
            }
                

            this.FormBorderStyle = FormBorderStyle.None; // cheange form style
            this.WindowState = FormWindowState.Maximized;
            isFullscreen = true;
        }

        public void goFullScreenLoad()
        {
            menuStrip1.Visible = false; // goodbye menu strip
            videoView1.Size = this.Size; // make video the same size as the form
            videoView1.Location = new Point(0, 0); // remove the offset
            TopMost = true;

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                isMaxWindow = true;
            }
            else
            {
                isMaxWindow = false;
            }

            this.FormBorderStyle = FormBorderStyle.None; // cheange form style
            this.WindowState = FormWindowState.Maximized;
            isFullscreen = true;
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                PlayFile(ofd.FileName);
        }

        private void uRLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new Form2(customIcon);
            m.StartPosition = FormStartPosition.CenterParent;
            m.ShowDialog();
        }
    

        private void eSCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ShortcutEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullscreen) // from fullscreen to window
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; // change form style
                this.WindowState = FormWindowState.Normal; // back to normal size

                this.Size = oldFormSize;
                menuStrip1.Visible = true; // the return of the menu strip 
                videoView1.Size = oldVideoSize; // make video the same size as the form
                videoView1.Location = oldVideoLocation; // remove the offset

                TopMost = false;
                isFullscreen = false;
                if(isMaxWindow)
                    this.WindowState = FormWindowState.Maximized; // back to normal size
            }

            if (isPlaying) // while the video is playing
            {
                if (e.KeyCode == Keys.Space) // Pause and Play
                {
                    if (_mp.State == VLCState.Playing)
                    {
                        _mp.Pause();
                    }
                    else
                    {
                        _mp.Play();
                    }
                }

                if (e.KeyCode == Keys.J) // skip 1% backwards
                {
                    _mp.Position -= 0.01f;
                }
                if (e.KeyCode == Keys.L) // skip 1% forwards
                {
                    _mp.Position += 0.01f;
                }
            }
        }

        public void PlayFile(string file)
        {
            try
            {
                _mp.Play(new Media(_libVLC, file));
                isPlaying = true;
            }
            catch (Exception ex)
            {

            }
                
        }
        public void PlayURLFile(string file)
        {
            if (file != "")
            {
                try
                {
                    _mp.Play(new Media(_libVLC, new Uri(file)));
                    isPlaying = true;
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (goFS)
                goFullScreenLoad();

            if (goPlay)
            {
                if (File.Exists(onLoadPlay))
                    PlayFile(onLoadPlay);
                else
                    PlayURLFile(onLoadPlay);
            }
        }
    }
}
