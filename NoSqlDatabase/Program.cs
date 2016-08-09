using System;
using System.IO;
using ZipPacker;
using System.Text;
using System.IO.Compression;
using DataWorker;

namespace NoSqlDatabase
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (DatabaseProvider db = new DatabaseProvider("/home/tsj/Документы/custom.db"))
			{
				db.Insert(5);
			}
		}
	}
}
