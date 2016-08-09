using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;

namespace ZipPacker
{
	public class ZipArchiveProvider : IZipPacker,IFileStream, IFileAdd , IDisposable
	{
		#region Property

		public ZipArchive CurrentArchive{ get; private set;}
		public string FullName{get;set;}
		public string ArchiveName
		{
			get
			{
				return Path.GetFileName(FullName);
			}
		}

		#endregion

		#region constr

		public ZipArchiveProvider()
		{	}

		public ZipArchiveProvider(string path)
		{
			OpenZip(path);
		}

		#endregion

		#region IZipPacker implementation

		public ZipArchive OpenZip(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				throw new ArgumentException(string.Format("Path {0} is invalid!",path));
			}

			FullName = (string) path.Clone();
			FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
			CurrentArchive = new ZipArchive(stream, ZipArchiveMode.Update);
			return CurrentArchive;
		}

		#endregion

		#region IFileStream implementation

		public byte[] GetBytes(string path, FileMode mode)
		{
			throw new NotImplementedException();
		}

		public byte[] GetBytes(Stream streamFile)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IZipWatcher implementation

		public ZipArchiveEntry GetEntry(long id)
		{
			return this[id];
		}

		public ZipArchiveEntry GetEntry(string fileName)
		{
			return this[fileName];
		}

		public StreamReader EntryDataStream(ZipArchiveEntry entry)
		{
			StreamReader reader = new StreamReader(entry.Open());
			return reader;
		}

		public IEnumerable<ZipArchiveEntry> Entres
		{
			get
			{
				return CurrentArchive.Entries;
			}
		}

		public ZipArchiveEntry this[string fileName]
		{
			get
			{
				foreach (var item in CurrentArchive.Entries)
				{
					if (item.FullName == fileName)
					{
						return item;
					}
				}

				return null;
			}
		}

		public ZipArchiveEntry this[long id]
		{
			get
			{
				for (int i = 0; i < CurrentArchive.Entries.Count; i++)
				{
					if (i == id) 
						return CurrentArchive.Entries[i];		
				}
				return null;
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose()
		{
			CurrentArchive.Dispose();
		}

		#endregion

		#region IFileAdd implementation

		public ZipArchiveEntry AddEntry(string file)
		{
			return CurrentArchive.CreateEntry(file);
		}

		public ZipArchiveEntry AddEntry(Stream stream, string name)
		{
			ZipArchiveEntry entry = CurrentArchive.CreateEntry(name);

			using (StreamWriter writter = new StreamWriter(entry.Open()))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					writter.WriteLine(reader.ReadToEnd());
				}
			}
			return entry;
		}

		public void AddEntry(string path, string name = null)
		{
			if (name == null)
			{
				name = Path.GetFileName(path);
			}

			using (var stream = new FileStream(path, FileMode.OpenOrCreate))
			{
				this.AddEntry(stream, name);
			}
		}

		#endregion

		#region methods

		/// <summary>
		/// Read entry data
		/// </summary>
		/// <returns>The entry.</returns>
		/// <param name="entry">Entry.</param>
		public static string ReadEntry(ZipArchiveEntry entry)
		{
			StringBuilder sb = new StringBuilder();
			using (StreamReader data = new StreamReader(entry.Open()))
			{
				sb.Append(data.ReadLine());
			}
			return sb.ToString();
		}
		#endregion
	}
}

