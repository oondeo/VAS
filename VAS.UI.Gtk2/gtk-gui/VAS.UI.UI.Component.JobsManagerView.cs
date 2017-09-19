
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.UI.Component
{
	public partial class JobsManagerView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.HBox treeviewbox;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Button clearbutton;

		private global::Gtk.Button cancelbutton;

		private global::Gtk.Button retrybutton;

		private global::Gtk.HButtonBox hbuttonbox2;

		private global::Gtk.Button acceptButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.UI.Component.JobsManagerView
			global::Stetic.BinContainer.Attach (this);
			this.WidthRequest = 500;
			this.HeightRequest = 250;
			this.Name = "VAS.UI.UI.Component.JobsManagerView";
			// Container child VAS.UI.UI.Component.JobsManagerView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.WidthRequest = 0;
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.treeviewbox = new global::Gtk.HBox ();
			this.treeviewbox.Name = "treeviewbox";
			this.treeviewbox.Spacing = 6;
			this.hbox1.Add (this.treeviewbox);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.treeviewbox]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 10;
			// Container child vbox3.Gtk.Box+BoxChild
			this.clearbutton = new global::Gtk.Button ();
			this.clearbutton.CanFocus = true;
			this.clearbutton.Name = "clearbutton";
			this.clearbutton.UseUnderline = true;
			this.clearbutton.Label = global::VAS.Core.Catalog.GetString ("C_lear finished jobs");
			global::Gtk.Image w2 = new global::Gtk.Image ();
			w2.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.clearbutton.Image = w2;
			this.vbox3.Add (this.clearbutton);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.clearbutton]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.cancelbutton = new global::Gtk.Button ();
			this.cancelbutton.CanFocus = true;
			this.cancelbutton.Name = "cancelbutton";
			this.cancelbutton.UseUnderline = true;
			this.cancelbutton.Label = global::VAS.Core.Catalog.GetString ("_Cancel job");
			global::Gtk.Image w4 = new global::Gtk.Image ();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.cancelbutton.Image = w4;
			this.vbox3.Add (this.cancelbutton);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.cancelbutton]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.retrybutton = new global::Gtk.Button ();
			this.retrybutton.CanFocus = true;
			this.retrybutton.Name = "retrybutton";
			this.retrybutton.UseUnderline = true;
			this.retrybutton.Label = global::VAS.Core.Catalog.GetString ("Retry job");
			global::Gtk.Image w6 = new global::Gtk.Image ();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.retrybutton.Image = w6;
			this.vbox3.Add (this.retrybutton);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.retrybutton]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.hbox1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox3]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w9.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbuttonbox2 = new global::Gtk.HButtonBox ();
			this.hbuttonbox2.Name = "hbuttonbox2";
			this.hbuttonbox2.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
			this.acceptButton = new global::Gtk.Button ();
			this.acceptButton.CanFocus = true;
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.UseStock = true;
			this.acceptButton.UseUnderline = true;
			this.acceptButton.Label = "gtk-ok";
			this.hbuttonbox2.Add (this.acceptButton);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2 [this.acceptButton]));
			w10.Expand = false;
			w10.Fill = false;
			this.vbox2.Add (this.hbuttonbox2);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbuttonbox2]));
			w11.Position = 1;
			w11.Expand = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.cancelbutton.Hide ();
			this.retrybutton.Hide ();
			this.Hide ();
		}
	}
}
