using System;

namespace PluginTest
{
	public class NotDerivedFromMarshalByRefObject
	{
		public NotDerivedFromMarshalByRefObject()
		{
		}

		public override string ToString()
		{
			return "I am not derived from MarshalByRefObject and should not show up on the list.";
		}
	}
}
