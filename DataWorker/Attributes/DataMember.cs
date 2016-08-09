using System;

namespace DataWorker
{
	[AttributeUsage(System.AttributeTargets.Class)]
	public class DataMemberAttribute : Attribute
	{	
		public Guid Guid { get; private set;} = Guid.NewGuid();
	}
}

