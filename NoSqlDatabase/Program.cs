using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Packer;
using System.Text;
using ICSharpCode.SharpZipLib.Core;
using System.IO.Compression;

namespace NoSqlDatabase
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			string path = "/home/tsj/Документы/some.txt";
//			string pathTo = "/home/tsj/Документы/myzip.zip";
//
//			using (FileStream stream = new FileStream(pathTo, FileMode.OpenOrCreate))
//			{
//				using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Update))
//				{
//					ZipArchiveEntry entry = archive.CreateEntry("some/wow.txt");
//					using (StreamWriter writer = new StreamWriter(entry.Open()))
//					{
//						writer.WriteLine("Information about this package.");
//						writer.WriteLine("o========================3");
//					}
//
//					foreach (ZipArchiveEntry s in archive.Entries)
//					{
//						Console.WriteLine(s.Name);
//						StreamReader reader = new StreamReader( s.Open());
//						Console.WriteLine(reader.ReadToEnd());
//					}
//				}
//			}

			using (ZipArchiveProvider provider = new ZipArchiveProvider())
			{
				provider.OpenZip("/home/tsj/Документы/myzip.zip");
				foreach (var item in provider.Entres)
				{
					Console.WriteLine(item.FullName);
				}

				using (var stream = new FileStream("/home/tsj/Документы/some.txt", FileMode.OpenOrCreate))
				{
					provider.AddEntry( stream, "123.txt");
				}

			}
		}
	}
}
