using System;
using System.IO;

namespace ZipPacker
{
	/// <summary>
	/// I file stream.
	/// </summary>
	public interface IFileStream
	{
		/// <summary>
		/// Get all byte from path to file.
		/// </summary>
		/// <returns>The bytes.</returns>
		/// <param name="path">Path.</param>
		/// <param name="mode">Mode.</param>
		byte[] GetBytes(string path, FileMode mode);

		/// <summary>
		/// Gets the bytes from stream.
		/// </summary>
		/// <returns>The bytes.</returns>
		/// <param name="streamFile">Stream file.</param>
		byte[] GetBytes (Stream streamFile);
	}
}

