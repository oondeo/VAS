
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.Panel
{
	public partial class PreferencesPanel
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.TreeView treeview;

		private global::Gtk.VBox propsvbox;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.Panel.PreferencesPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "VAS.UI.Panel.PreferencesPanel";
			// Container child VAS.UI.Panel.PreferencesPanel.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			this.treeview = new global::Gtk.TreeView ();
			this.treeview.CanFocus = true;
			this.treeview.Name = "treeview";
			this.scrolledwindow1.Add (this.treeview);
			this.hbox1.Add (this.scrolledwindow1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.scrolledwindow1]));
			w2.Position = 0;
			w2.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.propsvbox = new global::Gtk.VBox ();
			this.propsvbox.Name = "propsvbox";
			this.propsvbox.Spacing = 6;
			this.hbox1.Add (this.propsvbox);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.propsvbox]));
			w3.Position = 1;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
