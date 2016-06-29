using System;
using System.IO;

namespace ZipPacker
{
	public interface IZipPacker 
	{
		/// <summary>
		/// Get zip archive
		/// </summary>
		/// <returns>The zip.</returns>
		/// <param name="path">Path.</param>
		System.IO.Compression.ZipArchive OpenZip (string path); 
		/// <summary>
		/// Closes the zip stream.
		/// </summary>
		/// <returns><c>true</c>, if zip stream was closed, <c>false</c> otherwise.</returns>
		/// <param name="stream">Stream.</param>
	}
}

