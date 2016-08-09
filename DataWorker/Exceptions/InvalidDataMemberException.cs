using System;

namespace DataWorker
{
	public class InvalidDataMemberException : Exception
	{	
		public InvalidDataMemberException(string data)
			: base(data)
		{	}
	}
}

