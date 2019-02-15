using System;

namespace PluginTest
{
	public class TestPlugin : MarshalByRefObject
	{
		public TestPlugin()
		{
		}

		public override string ToString()
		{
			return "This is a test plugin object.";
		}
	}
}
