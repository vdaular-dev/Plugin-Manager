using System;

namespace PluginTest
{
	/// <summary>
	/// Summary description for YetAnotherTestPlugin.
	/// </summary>
	public class YetAnotherTestPlugin : MarshalByRefObject
	{
		public YetAnotherTestPlugin()
		{
		}

		public override string ToString()
		{
			return "I am an object of Type: " + this.GetType().FullName;
		}
	}
}
