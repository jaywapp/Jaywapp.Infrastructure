using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestFileHelper
    {
        [TestCase(3)]
        [TestCase(0)]
        public void ReadLines_CountMatches(int count)
        {
            var dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            try
            {
                var file = Path.Combine(dir.FullName, "sample.txt");
                var content = Enumerable.Range(1, count).Select(i => $"l{i}").ToArray();
                File.WriteAllLines(file, content);
                var lines = file.ReadLines().ToArray();
                Assert.That(lines.Length, Is.EqualTo(count));
            }
            finally
            {
                Directory.Delete(dir.FullName, true);
            }
        }

        [Test]
        public void ClearDirectory_DeletesAndRecreates()
        {
            var dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            var sub = Path.Combine(dir.FullName, "sub");
            Directory.CreateDirectory(sub);
            File.WriteAllText(Path.Combine(sub, "f.txt"), "x");

            dir.FullName.ClearDirectory();

            Assert.That(Directory.Exists(dir.FullName), Is.True);
            Assert.That(Directory.GetFiles(dir.FullName, "*", SearchOption.AllDirectories).Length, Is.EqualTo(0));
            Directory.Delete(dir.FullName, true);
        }

        [Test]
        public void GetFiles_ReturnsRecursiveFiles()
        {
            var dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            try
            {
                var a = Path.Combine(dir.FullName, "a.txt");
                var d = Directory.CreateDirectory(Path.Combine(dir.FullName, "d"));
                var b = Path.Combine(d.FullName, "b.txt");
                File.WriteAllText(a, "x");
                File.WriteAllText(b, "y");
                var files = FileHelper.GetFiles(dir.FullName);
                Assert.That(files.Count, Is.EqualTo(2));
                Assert.That(files.Any(p => p.EndsWith("a.txt")), Is.True);
                Assert.That(files.Any(p => p.EndsWith("b.txt")), Is.True);
            }
            finally
            {
                Directory.Delete(dir.FullName, true);
            }
        }

        [TestCase(".txt", true)]
        [TestCase(".bin", false)]
        public void IsExtension_Cases(string ext, bool expected)
        {
            var dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            try
            {
                var a = Path.Combine(dir.FullName, "a.txt");
                File.WriteAllText(a, "x");
                Assert.That(FileHelper.IsExtension(a, ext), Is.EqualTo(expected));
            }
            finally
            {
                Directory.Delete(dir.FullName, true);
            }
        }

        [Test]
        public void Copy_CopiesFileToDirectory()
        {
            var dir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            var dst = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            try
            {
                var a = Path.Combine(dir.FullName, "a.txt");
                File.WriteAllText(a, "x");
                FileHelper.Copy(a, dst.FullName);
                Assert.That(File.Exists(Path.Combine(dst.FullName, "a.txt")), Is.True);
            }
            finally
            {
                Directory.Delete(dir.FullName, true);
                Directory.Delete(dst.FullName, true);
            }
        }

        [Test]
        public void Decompress_ExtractsZip()
        {
            var root = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            var zip = Path.Combine(root.FullName, "t.zip");
            var zipSrcDir = Directory.CreateDirectory(Path.Combine(root.FullName, "src"));
            var zipOutDir = Path.Combine(root.FullName, "out");
            try
            {
                File.WriteAllText(Path.Combine(zipSrcDir.FullName, "f.txt"), "hello");
                if (File.Exists(zip)) File.Delete(zip);
                ZipFile.CreateFromDirectory(zipSrcDir.FullName, zip);
                zip.Decompress(zipOutDir);
                Assert.That(File.Exists(Path.Combine(zipOutDir, "f.txt")), Is.True);
            }
            finally
            {
                Directory.Delete(root.FullName, true);
            }
        }
    }
}
