
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.Component
{
	public partial class RenderingStateBarView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Statusbar statusbar3;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button statebutton;

		private global::Gtk.ProgressBar progressbar;

		private global::Gtk.Button cancelbutton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.Component.RenderingStateBarView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "VAS.UI.Component.RenderingStateBarView";
			// Container child VAS.UI.Component.RenderingStateBarView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.statusbar3 = new global::Gtk.Statusbar ();
			this.statusbar3.Name = "statusbar3";
			this.statusbar3.Spacing = 6;
			this.statusbar3.HasResizeGrip = false;
			// Container child statusbar3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.statebutton = new global::Gtk.Button ();
			this.statebutton.CanFocus = true;
			this.statebutton.Name = "statebutton";
			this.statebutton.UseUnderline = true;
			this.hbox1.Add (this.statebutton);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.statebutton]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.progressbar = new global::Gtk.ProgressBar ();
			this.progressbar.Name = "progressbar";
			this.hbox1.Add (this.progressbar);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.progressbar]));
			w2.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.cancelbutton = new global::Gtk.Button ();
			this.cancelbutton.CanFocus = true;
			this.cancelbutton.Name = "cancelbutton";
			this.cancelbutton.UseUnderline = true;
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.cancelbutton.Image = w3;
			this.hbox1.Add (this.cancelbutton);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cancelbutton]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.statusbar3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.statusbar3 [this.hbox1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox2.Add (this.statusbar3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.statusbar3]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.cancelbutton.Hide ();
			this.Hide ();
		}
	}
}
