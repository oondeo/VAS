
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.Panel
{
	public partial class PreferencesPanel
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.TreeView treeview;

		private global::Gtk.VBox vbox2;

		private global::Gtk.VBox propsvbox;

		private global::Gtk.HButtonBox dialogButtonBox;

		private global::Gtk.Button cancelButtonDialog;

		private global::Gtk.Button okButtonDialog;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.Panel.PreferencesPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "VAS.UI.Panel.PreferencesPanel";
			// Container child VAS.UI.Panel.PreferencesPanel.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 10;
			this.hbox1.BorderWidth = ((uint)(10));
			// Container child hbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.WidthRequest = 150;
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
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.propsvbox = new global::Gtk.VBox ();
			this.propsvbox.Name = "propsvbox";
			this.propsvbox.Spacing = 6;
			this.vbox2.Add (this.propsvbox);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.propsvbox]));
			w3.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.dialogButtonBox = new global::Gtk.HButtonBox ();
			this.dialogButtonBox.Name = "dialogButtonBox";
			this.dialogButtonBox.Spacing = 10;
			this.dialogButtonBox.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialogButtonBox.Gtk.ButtonBox+ButtonBoxChild
			this.cancelButtonDialog = new global::Gtk.Button ();
			this.cancelButtonDialog.CanFocus = true;
			this.cancelButtonDialog.Name = "cancelButtonDialog";
			this.cancelButtonDialog.UseUnderline = true;
			this.cancelButtonDialog.Label = global::Mono.Unix.Catalog.GetString ("cancel");
			this.dialogButtonBox.Add (this.cancelButtonDialog);
			global::Gtk.ButtonBox.ButtonBoxChild w4 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.dialogButtonBox [this.cancelButtonDialog]));
			w4.Expand = false;
			w4.Fill = false;
			// Container child dialogButtonBox.Gtk.ButtonBox+ButtonBoxChild
			this.okButtonDialog = new global::Gtk.Button ();
			this.okButtonDialog.CanFocus = true;
			this.okButtonDialog.Name = "okButtonDialog";
			this.okButtonDialog.UseUnderline = true;
			this.okButtonDialog.Label = global::Mono.Unix.Catalog.GetString ("ok");
			this.dialogButtonBox.Add (this.okButtonDialog);
			global::Gtk.ButtonBox.ButtonBoxChild w5 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.dialogButtonBox [this.okButtonDialog]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox2.Add (this.dialogButtonBox);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.dialogButtonBox]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w7.Position = 1;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}