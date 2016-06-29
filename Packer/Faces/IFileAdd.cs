using System;
using System.IO;

namespace Packer
{
	public interface IFileAdd
	{
		/// <summary>
		/// Adds the entry.
		/// </summary>
		/// <param name="file">File.</param>
		void AddEntry(string file);
		/// <summary>
		/// Adds the entry.
		/// </summary>
		/// <param name="stream">Stream.</param>
		/// <param name = "name"></param>
		void AddEntry(Stream stream, string name);
	}
}

