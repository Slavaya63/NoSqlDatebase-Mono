using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace Packer
{
	public class ZipArchiveProvider : IZipPacker,IFileStream, IFileAdd , IDisposable
	{
		#region Property

		public ZipArchive CurrentArchive{ get; private set;}

		#endregion

		#region constr

		#endregion

		#region IZipPacker implementation

		public ZipArchive OpenZip(string path)
		{
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

		public void AddEntry(string file)
		{
			CurrentArchive.CreateEntry(file);
		}

		public void AddEntry(Stream stream, string name)
		{
			ZipArchiveEntry entry = CurrentArchive.CreateEntry(name);

			using (StreamWriter writter = new StreamWriter(entry.Open()))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					writter.WriteLine(reader.ReadToEnd());
				}
			}
		}

		#endregion

	}
}

