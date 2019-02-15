using System;

namespace PluginTest
{
	public class UpdatedClass : MarshalByRefObject
	{
		public UpdatedClass()
		{
		}

		public override string ToString()
		{
			return "Comment me into/out of existance and recompile just the PluginTest project while the demo is running.  Be aware, there is a ten second delay on updates.";
		}
	}
}
