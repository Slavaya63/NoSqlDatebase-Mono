using System;
using ZipPacker;
using System.IO.Compression;
using System.Reflection;
using Newtonsoft.Json;

namespace DataWorker
{
	public class DatabaseProvider : IDisposable
	{
		#region var 
		private ZipArchiveProvider _zipProvider;
		#endregion

		#region prop
		public string DBName { get; set;}
		#endregion

		#region constr
		public DatabaseProvider(string database)
		{
			DBName = database;
		}
		#endregion

		#region methods
		public void	Insert(object obj)
		{
			using (_zipProvider = new ZipArchiveProvider(DBName))
			{
				Type objType = obj.GetType();
				ZipArchiveEntry collumn = _zipProvider.GetEntry(objType.ToString()+"_col");

				if (collumn == null)
				{
					collumn = _zipProvider.AddEntry(objType.ToString() + "_col");
				}

				DataMemberAttribute dataMemberAtt = objType.GetCustomAttribute<DataMemberAttribute>();
				if (dataMemberAtt == null)
				{
					throw new InvalidDataMemberException(string.Format("The object ({0}) has no special attributes!", obj));
				}

				InsertGuidIntoCollumn(collumn, dataMemberAtt);

				WriteIntoCommonFile(obj);
			}
		}

		/// <summary>
		/// Записывает сущность дублируя гуид сущности в таблицу
		/// </summary>
		/// <param name="collumn">Collumn.</param>
		/// <param name="obj">Object.</param>
		void InsertGuidIntoCollumn(ZipArchiveEntry collumn, DataMemberAttribute obj)
		{
			Collumn coll = (Collumn) JsonConvert.DeserializeObject(ZipArchiveProvider.ReadEntry(collumn));
			coll.Add(obj.Guid);
		}

		/// <summary>
		/// Запись сущности в общий файл
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="guid">Entity guid</param>
		void WriteIntoCommonFile(object obj, Guid guid)
		{
			ZipArchiveEntry commonFileName = _zipProvider.GetEntry(obj.GetType().ToString());
			string toSave = JsonConvert.SerializeObject(obj);

			if (commonFileName == null)
			{
				commonFileName = _zipProvider.AddEntry(obj.GetType().ToString());

				commonFileName.AddSerializeEntry(toSave, guid, true);
			}
			else
			{
				commonFileName.AddSerializeEntry(toSave, guid, false);
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose()
		{
			//TODO make
		}

		#endregion
	}
}

