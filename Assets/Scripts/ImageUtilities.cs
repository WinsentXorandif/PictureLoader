using Cysharp.Threading.Tasks;
using System.IO;
using UnityEngine;

public static class ImageUtilties
{
    public static class FileFormat
    {
        public const string JPG = "JPG";
        public const string PNG = "PNG";
    }

    public static class DirectoryUtils
    {
        public static void CheckDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
    public static class FileUtils
    {

        public const int BUFFER_SIZE = 0x4096;

        public static async UniTask<byte[]> ReadImageBytes(string filePath)
        {
            using (FileStream readStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, BUFFER_SIZE, true))
            {
                byte[] data = new byte[readStream.Length];
                await readStream.ReadAsync(data, 0, (int)data.Length);
                return data;
            }
        }

        public static Texture2D GetTextureFromByteArray(byte[] data)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(data);
            texture.Apply();
            return texture;
        }

        public static async UniTask<string> SaveImage(Texture2D image, string filePath, string format)
        {
            byte[] imageData = null;
            switch (format)
            {
                case FileFormat.JPG:
                    imageData = image.EncodeToJPG();
                    break;

                case FileFormat.PNG:
                    imageData = image.EncodeToPNG();
                    break;
            }
            await WriteByteArray(imageData, filePath);
            return filePath;
        }

        public static async UniTask WriteByteArray(byte[] data, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, BUFFER_SIZE, true))
            {
                await fileStream.WriteAsync(data, 0, data.Length);
            }
        }
    }



}
