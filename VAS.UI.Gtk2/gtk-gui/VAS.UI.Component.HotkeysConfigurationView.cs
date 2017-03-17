
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.Component
{
	public partial class HotkeysConfigurationView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.ComboBox categoriesCombo;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label lblAction;

		private global::Gtk.Label lblShortcut;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.VBox keyConfigVBox;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.Component.HotkeysConfigurationView
			global::Stetic.BinContainer.Attach (this);
			this.WidthRequest = 450;
			this.HeightRequest = 600;
			this.Name = "VAS.UI.Component.HotkeysConfigurationView";
			// Container child VAS.UI.Component.HotkeysConfigurationView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 10;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0F, 0.5F, 0F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.categoriesCombo = global::Gtk.ComboBox.NewText ();
			this.categoriesCombo.Name = "categoriesCombo";
			this.alignment1.Add (this.categoriesCombo);
			this.vbox2.Add (this.alignment1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.lblAction = new global::Gtk.Label ();
			this.lblAction.WidthRequest = 200;
			this.lblAction.Name = "lblAction";
			this.lblAction.Xalign = 0F;
			this.lblAction.LabelProp = global::Mono.Unix.Catalog.GetString ("Action");
			this.hbox1.Add (this.lblAction);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.lblAction]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.lblShortcut = new global::Gtk.Label ();
			this.lblShortcut.WidthRequest = 120;
			this.lblShortcut.Name = "lblShortcut";
			this.lblShortcut.Xalign = 0F;
			this.lblShortcut.LabelProp = global::Mono.Unix.Catalog.GetString ("Shortcut");
			this.hbox1.Add (this.lblShortcut);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.lblShortcut]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			w5.Padding = ((uint)(15));
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w6 = new global::Gtk.Viewport ();
			w6.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.keyConfigVBox = new global::Gtk.VBox ();
			this.keyConfigVBox.Name = "keyConfigVBox";
			this.keyConfigVBox.Spacing = 6;
			w6.Add (this.keyConfigVBox);
			this.GtkScrolledWindow.Add (w6);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w9.Position = 2;
			w9.Padding = ((uint)(5));
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
