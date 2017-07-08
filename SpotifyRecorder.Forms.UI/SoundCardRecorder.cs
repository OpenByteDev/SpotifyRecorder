using System;
using System.Diagnostics;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SpotifyRecorder.Forms.UI
{
    public class SoundCardRecorder:IDisposable
    {
        #region Constants

        #endregion

        #region Private Properties

        private MMDevice Device { get; set; }
        private IWaveIn _waveIn;
        private WaveFileWriter _writer;
        private Stopwatch _stopwatch = new Stopwatch();


        #endregion

        #region Public Properties

        public string FilePath { get; set; }
        public string Song { get; set; }
        public TimeSpan Duration { get { return _stopwatch.Elapsed; } }


        #endregion

        #region Constructor

        public SoundCardRecorder(MMDevice device, string filePath, string song)
        {
            Device = device;
            FilePath = filePath;
            Song = song;

            _waveIn = new WasapiCapture(Device);
            _writer = new WaveFileWriter(FilePath, _waveIn.WaveFormat);
            _waveIn.DataAvailable += OnDataAvailable;

        }

        public void Dispose()
        {
            if (_waveIn != null)
            {
                _waveIn.StopRecording();
                _waveIn.Dispose();
                _waveIn = null;
            }
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
        }

        #endregion

        #region Events

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            //            if (InvokeRequired)
            //            {
            //                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            //            }
            //            else
            //            {
            if (_writer != null)
                _writer.Write(e.Buffer, 0, e.BytesRecorded);
            //            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public void Start()
        {
            _waveIn.StartRecording();
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public void Stop()
        {
            if (_waveIn != null)
            {
                _waveIn.StopRecording();
                _waveIn.Dispose();
                _waveIn = null;
            }
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
        }

        #endregion
    }
}