namespace SpotifyRecorder.Forms.UI
{
    public class Mp3Tag
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Mp3Tag(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
    }
}