using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Text;

namespace PluginDemo
{
	/// <summary>
	/// Demonstration of plugin capabilities
	/// </summary>
	public class PluginDemoForm : System.Windows.Forms.Form
	{
		private rapid.Plugins.PluginManager pluginManager = new rapid.Plugins.PluginManager();

		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem fileMenuItem;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.Windows.Forms.MenuItem pluginsMenuItem;
		private System.Windows.Forms.MenuItem reloadMenuItem;
		private System.Windows.Forms.TextBox pluginTextBox;
		private System.Windows.Forms.MenuItem compileErrorsMenuItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PluginDemoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Closing += new CancelEventHandler(PluginDemoForm_Closing);
			pluginManager.PluginsReloaded += new EventHandler(pluginManager_PluginsReloaded);
			pluginManager.Start();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.fileMenuItem = new System.Windows.Forms.MenuItem();
			this.exitMenuItem = new System.Windows.Forms.MenuItem();
			this.pluginsMenuItem = new System.Windows.Forms.MenuItem();
			this.reloadMenuItem = new System.Windows.Forms.MenuItem();
			this.pluginTextBox = new System.Windows.Forms.TextBox();
			this.compileErrorsMenuItem = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.fileMenuItem,
																					 this.pluginsMenuItem});
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.Index = 0;
			this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.exitMenuItem});
			this.fileMenuItem.Text = "&File";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Index = 0;
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// pluginsMenuItem
			// 
			this.pluginsMenuItem.Index = 1;
			this.pluginsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.reloadMenuItem,
																							this.compileErrorsMenuItem});
			this.pluginsMenuItem.Text = "&Plugins";
			// 
			// reloadMenuItem
			// 
			this.reloadMenuItem.Index = 0;
			this.reloadMenuItem.Text = "&Reload";
			this.reloadMenuItem.Click += new System.EventHandler(this.reloadMenuItem_Click);
			// 
			// pluginTextBox
			// 
			this.pluginTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pluginTextBox.Location = new System.Drawing.Point(0, 0);
			this.pluginTextBox.Multiline = true;
			this.pluginTextBox.Name = "pluginTextBox";
			this.pluginTextBox.Size = new System.Drawing.Size(552, 449);
			this.pluginTextBox.TabIndex = 0;
			this.pluginTextBox.Text = "";
			// 
			// compileErrorsMenuItem
			// 
			this.compileErrorsMenuItem.Index = 1;
			this.compileErrorsMenuItem.Text = "&Compile Errors";
			this.compileErrorsMenuItem.Click += new System.EventHandler(this.compileErrorsMenuItem_Click);
			// 
			// PluginDemoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 449);
			this.Controls.Add(this.pluginTextBox);
			this.Menu = this.mainMenu;
			this.Name = "PluginDemoForm";
			this.Text = "Plugin Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PluginDemoForm());
		}

        private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void reloadMenuItem_Click(object sender, System.EventArgs e)
		{
			pluginManager.ReloadPlugins();
		}

		private void pluginManager_PluginsReloaded(object sender, EventArgs e)
		{
			pluginTextBox.Text = "";
			foreach (string pluginObjectName in
				pluginManager.GetSubclasses(typeof(MarshalByRefObject).FullName))
			{
				MarshalByRefObject pluginObject = pluginManager.CreateInstance(
					pluginObjectName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance,
					new object[] {});
				pluginTextBox.Text += "Plugin object evaluates to: \"" + pluginObject.ToString() + "\"\r\n";
			}
		}

		private void PluginDemoForm_Closing(object sender, CancelEventArgs e)
		{
			pluginManager.Stop();
		}

		private void compileErrorsMenuItem_Click(object sender, System.EventArgs e)
		{
			StringBuilder aggregateErrorText = new StringBuilder();
			foreach (string error in pluginManager.CompilerErrors)
			{
				aggregateErrorText.Append(error + "\r\n");
			}
			MessageBox.Show(this, aggregateErrorText.ToString(), "Compiler Errors");
		}
	}
}
