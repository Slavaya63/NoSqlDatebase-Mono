using System;
using System.Collections.Generic;

namespace DataWorker
{
	public class Collumn
	{
		private List<object> _list = new List<object>();

		/// <summary>
		/// Записывает Гуид сущности 
		/// </summary>
		/// <param name="guid">Guid.</param>
		public void Add(object guid)
		{
			_list.Add(guid);
		}

		public long Count() => _list.Count;

	}
}

