using System;
using System.IO;

namespace SpotifyRecorder.Forms.UI {
    public static class Util {
        public static string GetDefaultOutputPath() {
            if (string.IsNullOrEmpty(Settings.Default.OutputPath)) {
                Settings.Default.OutputPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "SpotifyRecorder");
                if (!Directory.Exists(Settings.Default.OutputPath))
                    Directory.CreateDirectory(Settings.Default.OutputPath);
                Settings.Default.Save();
            }

            return Settings.Default.OutputPath;
        }
        public static void SetDefaultOutputPath(string outputPath) {
            Settings.Default.OutputPath = outputPath;
            Settings.Default.Save();
        }
        public static string GetDefaultDevice() {
            return Settings.Default.DefaultDevice;
        }
        public static void SetDefaultNamingPattern(string namingPattern) {
            Settings.Default.NamingPattern = namingPattern;
            Settings.Default.Save();
        }
        public static string GetDefaultNamingPattern() {
            return Settings.Default.NamingPattern;
        }
        public static void SetDefaultDevice(string device) {
            Settings.Default.DefaultDevice = device;
            Settings.Default.Save();
        }
        public static int GetDefaultBitrate() {
            return Settings.Default.Bitrate;
        }
        public static void SetDefaultThreshold(int threshold) {
            Settings.Default.DeleteThreshold = threshold;
            Settings.Default.Save();
        }
        public static int GetDefaultThreshold() {
            return Settings.Default.DeleteThreshold;
        }
        public static void SetDefaultThresholdEnabled(bool threshold) {
            Settings.Default.DeleteThresholdEnabled = threshold;
            Settings.Default.Save();
        }
        public static bool GetDefaultThresholdEnabled() {
            return Settings.Default.DeleteThresholdEnabled;
        }
        public static void SetDefaultBitrate(int bitrate) {
            Settings.Default.Bitrate = bitrate;
            Settings.Default.Save();
        }
        public static Mp3Tag ExtractMp3Tag(string song) {
            string[] split = song.Split(new[] { " – ", " - " }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length == 0)
                return null;

            return new Mp3Tag(
                split.Length > 1 ? split[1] : string.Empty,
                split[0]
            );
        }
    }
}