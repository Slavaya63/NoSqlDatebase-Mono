using System;
using System.IO;
using ZipPacker;
using System.Text;
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

			using (ZipArchiveProvider provider = new ZipArchiveProvider("/home/tsj/Документы/myzip.zip"))
			{
				foreach (ZipArchiveEntry item in provider.Entres)
				{
					Console.WriteLine(item.FullName);
					Console.WriteLine(provider.ReadEntry(item));
				}

				provider.AddEntry("/home/tsj/Документы/some.txt");
			}
		}
	}
}
