using System;

namespace DataWorker
{
	[AttributeUsage(AttributeTargets.Property)]
	public class DataAttribute : Attribute
	{
		public bool PrimaryKey {get;set;}
		public bool AutoIncriment{get;set;}
	}
}

