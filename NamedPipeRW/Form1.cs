using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public Form1()
        {
            InitializeComponent();
        }

        Mem m = new Mem();
        NamedPipeClientStream pipeStream;
        StreamWriter sw;

        public static void ScrollToBottom(RichTextBox MyRichTextBox)
        {
            SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }

        public void CreateThread(string pid)
        {
            if (!m.OpenProcess(Convert.ToInt32(pid)))
            {
                AppendOutputText("ERROR: Process open failed!", Color.Red);
                return;
            } 
            else
            {
                AppendOutputText("SUCCESS: Process open!", Color.Green);
            }

            if (!File.Exists(DLLFilePath.Text))
            {
                AppendOutputText("ERROR: DLL Doesn't exist!", Color.Red);
                return;
            }

            m.InjectDll(DLLFilePath.Text);
            string pipename = "cemonodc_pid" + pid;
            pipeStream = new NamedPipeClientStream(pipename);
            Debug.WriteLine("Creating named pipe: " + pipename);
            sw = new StreamWriter(pipeStream);
            if (!pipeStream.IsConnected)
            {
                pipeStream.Connect();
                AppendOutputText("Created named pipe.", Color.Green);
            } else
            {
                AppendOutputText("Named pipe already connected.", Color.Green);
            }

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        void AppendOutputText(string text, Color color = default(Color))
        {
            try
            {
                PipeOutputTextBox.Invoke(new MethodInvoker(delegate
                {
                    if (PipeOutputTextBox.Lines.Count() > 500)
                        PipeOutputTextBox.Clear();
                    PipeOutputTextBox.SelectionStart = PipeOutputTextBox.TextLength;
                    PipeOutputTextBox.SelectionLength = 0;
                    PipeOutputTextBox.SelectionColor = color;
                    PipeOutputTextBox.AppendText(DateTime.Now + " " + text + Environment.NewLine);
                    ScrollToBottom(PipeOutputTextBox);
                }));
            }
            catch
            {
                Debug.WriteLine("[ERROR] AppendOutputText crashed!");
            }
        }


        public void WriteMsg(string func)
        {
            Thread ClientThread = new Thread(() => SendMsg(func));
            ClientThread.Start();
        }

        public void SendMsg(string func)
        {
            if (pipeStream == null)
                return;

            if (sw.AutoFlush == false)
                sw.AutoFlush = true;
            sw.WriteLine(func);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DLLFilePath.Text = Properties.Settings.Default.DLLPath;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (ProcIDTxtBox.Text.Length <= 0)
                return;
            CreateThread(ProcIDTxtBox.Text);
        }

        private void WriteMsg_Click(object sender, EventArgs e)
        {
            WriteMsg(WriteMsgTxtBox.Text);
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DLLFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DLLPath = DLLFilePath.Text;
            Properties.Settings.Default.Save();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            AppendOutputText("BG Worker started, reading pipe...");
            using (StreamReader sr = new StreamReader(pipeStream))
            {
                // Display the read text to the console
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    AppendOutputText(temp);
                }
            }
        }
    }
}
