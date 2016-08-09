using System;
using System.IO;
using System.IO.Compression;

namespace ZipPacker
{
	public interface IFileAdd
	{
		/// <summary>
		/// Adds the entry.
		/// </summary>
		/// <param name="file">File.</param>
		ZipArchiveEntry AddEntry(string file);
		/// <summary>
		/// Adds the entry.
		/// </summary>
		/// <param name="stream">Stream.</param>
		/// <param name = "name"></param>
		ZipArchiveEntry AddEntry(Stream stream, string name);
	}
}

