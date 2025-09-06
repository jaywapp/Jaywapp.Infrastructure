using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace Jaywapp.Infrastructure.Helpers
{
/// <summary>
/// 유틸리티 메서드를 제공합니다.
/// </summary>
    public static class FileHelper
    {
/// <summary>
/// 동작을 수행합니다.
/// </summary>
/// <param name="path">매개 변수</param>
/// <returns>결과를 반환합니다.</returns>
        public static IEnumerable<string> ReadLines(this string path)
        {
            using (var reader = new StreamReader(path))
            {
                var line = "";

                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }

/// <summary>
/// 동작을 수행합니다.
/// </summary>
/// <param name="zipPath">매개 변수</param>
/// <param name="dirPath">매개 변수</param>
        public static void Decompress(this string zipPath, string dirPath)
        {
            ZipFile.ExtractToDirectory(zipPath, dirPath);
        }

/// <summary>
/// 동작을 수행합니다.
/// </summary>
/// <param name="path">매개 변수</param>
        public static void ClearDirectory(this string path)
        {
            if (!Directory.Exists(path))
                return;

            Directory.Delete(path, true);
            Directory.CreateDirectory(path);
        }

/// <summary>
/// Files를(을) 가져옵니다.
/// </summary>
/// <param name="dirPath">매개 변수</param>
/// <returns>결과를 반환합니다.</returns>
        public static List<string> GetFiles(string dirPath)
        {
            var result = new List<string>();
            var members = Directory.GetFileSystemEntries(dirPath);

            foreach (var member in members)
            {
                var isFile = File.Exists(member);

                // File
                if (isFile)
                    result.Add(member);
                // Folder
                else
                    result.AddRange(GetFiles(member));
            }

            return result;
        }

/// <summary>
/// Extension인지 여부를 확인합니다.
/// </summary>
/// <param name="path">매개 변수</param>
/// <param name="extension">매개 변수</param>
/// <returns>조건을 만족하면 true를 반환합니다.</returns>
        public static bool IsExtension(string path, string extension)
        {
            if (!File.Exists(path))
                return false;

            var ext = Path.GetExtension(path);
            return !string.IsNullOrEmpty(ext)
                && string.Equals(extension, ext, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// <paramref name="filePath"/>를 <paramref name="dir"/>에 복사합니다.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dir"></param>
        public static void Copy(string filePath, string dir)
        {
            File.Copy(filePath, $@"{dir}\{Path.GetFileName(filePath)}");
        }

        /// <summary>
        /// <paramref name="filePath"/>를 <paramref name="directory"/>에 복사합니다.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="directory"></param>
        public static void Copy(string filePath, DirectoryInfo directory)
        {
            Copy(filePath, directory.FullName);
        }

        /// <summary>
        /// <paramref name="zipPath"/>이름으로 <paramref name="filePaths"/>을 모두 포함하여 압축합니다.
        /// </summary>
        /// <param name="zipPath"></param>
        /// <param name="filePaths"></param>
        public static void Compress(string zipPath, params string[] filePaths)
        {
            // 파일 이름 수집
            var fileName = Path.GetFileNameWithoutExtension(zipPath);
            // zip 파일이 위치한 폴더 경로 수집
            var dirPath = Path.GetDirectoryName(zipPath);
            // 임시 폴더 생성 (파일 이름과 동일)
            var dir = Directory.CreateDirectory($@"{dirPath}\{fileName}");

            // 입력된 파일들을 모두 임시 폴더로 복사
            foreach (var sourcePath in filePaths)
                Copy(sourcePath, dir);

            // 임시 폴더를 기반으로 압축파일 생성
            ZipFile.CreateFromDirectory(dir.FullName, zipPath);

            // 임시 폴더 제거
            Directory.Delete(dir.FullName, true);
        }

        /// <summary>
        /// <paramref name="fileName"/>이름의 파일을 TEMP 폴더에 생성합니다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetTempFile(string fileName)
        {
            var dir = Path.GetTempPath();
            var path = $@"{dir}{fileName}";

            if (File.Exists(path))
                File.Delete(path);

            return path;
        }
    }
}
