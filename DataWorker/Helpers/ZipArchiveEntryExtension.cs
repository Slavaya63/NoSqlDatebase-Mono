using System;
using System.IO.Compression;
using System.IO;
using System.Xml.Linq;

namespace DataWorker
{
	public static class ZipArchiveEntryExtension
	{
		/// <summary>
		/// Записывает серилизованную сущность в XML файл 
		/// </summary>
		/// <param name="entry">Entry.</param>
		/// <param name="obj">Object.</param>
		/// <param name="isEpty">Пустая ли зип запись</param>
		/// <description>Записывает серилизованную в JSON строку в XML файл. В случае если файл<description>
		/// <description>был только создан до вызова этого метода, в аргумент передается true</description>
		public static void AddSerializeEntry(this ZipArchiveEntry entry, string obj,Guid guid , bool isEpty)
		{
			using (StreamReader streamReader = new StreamReader( entry.Open()))
			{
				const string strObj = "object";
				string strType = obj.GetType().ToString();
				if (isEpty)
				{
					XDocument document = new XDocument(new XElement(new XAttribute("guid", guid), strObj, obj)); 
					streamReader.ReadLine(document.ToString());
				}
				else
				{
					XDocument document = XDocument.Parse(streamReader.ReadToEnd());
					XElement element = document.Element(strType);
				}
			}
		}
	}
}

