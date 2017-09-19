
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI.Dialog
{
	public partial class DrawingTool
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.VBox leftbox;

		private global::Gtk.Label toolslabel;

		private global::Gtk.Table toolstable;

		private global::Gtk.RadioButton anglebutton;

		private global::VAS.UI.Helpers.ImageView anglebuttonimage;

		private global::Gtk.RadioButton crossbutton;

		private global::VAS.UI.Helpers.ImageView crossbuttonimage;

		private global::Gtk.RadioButton ellipsebutton;

		private global::VAS.UI.Helpers.ImageView ellipsebuttonimage;

		private global::Gtk.RadioButton ellipsefilledbutton;

		private global::VAS.UI.Helpers.ImageView ellipsefilledbuttonimage;

		private global::Gtk.RadioButton eraserbutton;

		private global::VAS.UI.Helpers.ImageView eraserbuttonimage;

		private global::Gtk.RadioButton linebutton;

		private global::VAS.UI.Helpers.ImageView linebuttonimage;

		private global::Gtk.RadioButton numberbutton;

		private global::VAS.UI.Helpers.ImageView numberbuttonimage;

		private global::Gtk.RadioButton penbutton;

		private global::VAS.UI.Helpers.ImageView penbuttonimage;

		private global::Gtk.RadioButton playerbutton;

		private global::VAS.UI.Helpers.ImageView playerbuttonimage;

		private global::Gtk.RadioButton rectanglebutton;

		private global::VAS.UI.Helpers.ImageView rectanglebuttonimage;

		private global::Gtk.RadioButton rectanglefilledbutton;

		private global::VAS.UI.Helpers.ImageView rectanglefilledbuttonimage;

		private global::Gtk.RadioButton selectbutton;

		private global::VAS.UI.Helpers.ImageView selectbuttonimage;

		private global::Gtk.RadioButton textbutton;

		private global::VAS.UI.Helpers.ImageView textbuttonimage;

		private global::Gtk.RadioButton zoombutton;

		private global::VAS.UI.Helpers.ImageView zoombuttonimage;

		private global::Gtk.HBox zoombox;

		private global::Gtk.Label zoomlabel;

		private global::Gtk.HBox zoomscalebox;

		private global::VAS.UI.Helpers.ImageView zoomoutimage;

		private global::Gtk.HScale zoomscale;

		private global::VAS.UI.Helpers.ImageView zoominimage;

		private global::Gtk.Frame linesframe;

		private global::Gtk.Alignment GtkAlignment4;

		private global::Gtk.Table table1;

		private global::Gtk.ColorButton colorbutton;

		private global::Gtk.Label colorslabel;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.SpinButton linesizespinbutton;

		private global::Gtk.ComboBox stylecombobox;

		private global::Gtk.ComboBox typecombobox;

		private global::Gtk.Label GtkLabel4;

		private global::Gtk.Frame textframe;

		private global::Gtk.Alignment GtkAlignment13;

		private global::Gtk.Table table4;

		private global::Gtk.ColorButton backgroundcolorbutton;

		private global::Gtk.Label backgroundcolorslabel2;

		private global::Gtk.Label backgroundcolorslabel3;

		private global::Gtk.ColorButton textcolorbutton;

		private global::Gtk.Label textcolorslabel2;

		private global::Gtk.SpinButton textspinbutton;

		private global::Gtk.Label GtkLabel5;

		private global::Gtk.Button clearbutton;

		private global::Gtk.Button savetoprojectbutton;

		private global::Gtk.Button savebutton;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.DrawingArea drawingarea;

		private global::Gtk.HScrollbar wscrollbar;

		private global::Gtk.VBox vbox5;

		private global::Gtk.VScrollbar hscrollbar;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.Button buttonclose;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VAS.UI.Dialog.DrawingTool
			this.Name = "VAS.UI.Dialog.DrawingTool";
			this.Title = global::VAS.Core.Catalog.GetString ("Drawing Tool");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.DefaultWidth = 800;
			this.DefaultHeight = 1;
			this.Gravity = ((global::Gdk.Gravity)(5));
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			// Internal child VAS.UI.Dialog.DrawingTool.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.leftbox = new global::Gtk.VBox ();
			this.leftbox.Name = "leftbox";
			this.leftbox.Spacing = 6;
			// Container child leftbox.Gtk.Box+BoxChild
			this.toolslabel = new global::Gtk.Label ();
			this.toolslabel.Name = "toolslabel";
			this.toolslabel.Xalign = 0F;
			this.toolslabel.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Tools</b>");
			this.toolslabel.UseMarkup = true;
			this.leftbox.Add (this.toolslabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.toolslabel]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child leftbox.Gtk.Box+BoxChild
			this.toolstable = new global::Gtk.Table (((uint)(7)), ((uint)(2)), true);
			this.toolstable.Name = "toolstable";
			this.toolstable.RowSpacing = ((uint)(6));
			this.toolstable.ColumnSpacing = ((uint)(6));
			// Container child toolstable.Gtk.Table+TableChild
			this.anglebutton = new global::Gtk.RadioButton ("");
			global::Gtk.Tooltips w3 = new Gtk.Tooltips ();
			w3.SetTip (this.anglebutton, "Angle tool", "Angle tool");
			this.anglebutton.CanFocus = true;
			this.anglebutton.Name = "anglebutton";
			this.anglebutton.Active = true;
			this.anglebutton.DrawIndicator = false;
			this.anglebutton.UseUnderline = true;
			this.anglebutton.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.anglebutton.Remove (this.anglebutton.Child);
			// Container child anglebutton.Gtk.Container+ContainerChild
			this.anglebuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.anglebuttonimage.Name = "anglebuttonimage";
			this.anglebutton.Add (this.anglebuttonimage);
			this.toolstable.Add (this.anglebutton);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.toolstable [this.anglebutton]));
			w5.TopAttach = ((uint)(6));
			w5.BottomAttach = ((uint)(7));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.crossbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.crossbutton, "Cross tool", "Cross tool");
			this.crossbutton.CanFocus = true;
			this.crossbutton.Name = "crossbutton";
			this.crossbutton.DrawIndicator = false;
			this.crossbutton.UseUnderline = true;
			this.crossbutton.Group = this.anglebutton.Group;
			this.crossbutton.Remove (this.crossbutton.Child);
			// Container child crossbutton.Gtk.Container+ContainerChild
			this.crossbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.crossbuttonimage.Name = "crossbuttonimage";
			this.crossbutton.Add (this.crossbuttonimage);
			this.toolstable.Add (this.crossbutton);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.toolstable [this.crossbutton]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.ellipsebutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.ellipsebutton, "Ellipse tool", "Ellipse tool");
			this.ellipsebutton.CanFocus = true;
			this.ellipsebutton.Name = "ellipsebutton";
			this.ellipsebutton.DrawIndicator = false;
			this.ellipsebutton.UseUnderline = true;
			this.ellipsebutton.Group = this.anglebutton.Group;
			this.ellipsebutton.Remove (this.ellipsebutton.Child);
			// Container child ellipsebutton.Gtk.Container+ContainerChild
			this.ellipsebuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.ellipsebuttonimage.Name = "ellipsebuttonimage";
			this.ellipsebutton.Add (this.ellipsebuttonimage);
			this.toolstable.Add (this.ellipsebutton);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.toolstable [this.ellipsebutton]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.ellipsefilledbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.ellipsefilledbutton, "Filled ellipse", "Filled ellipse");
			this.ellipsefilledbutton.CanFocus = true;
			this.ellipsefilledbutton.Name = "ellipsefilledbutton";
			this.ellipsefilledbutton.DrawIndicator = false;
			this.ellipsefilledbutton.UseUnderline = true;
			this.ellipsefilledbutton.Group = this.anglebutton.Group;
			this.ellipsefilledbutton.Remove (this.ellipsefilledbutton.Child);
			// Container child ellipsefilledbutton.Gtk.Container+ContainerChild
			this.ellipsefilledbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.ellipsefilledbuttonimage.Name = "ellipsefilledbuttonimage";
			this.ellipsefilledbutton.Add (this.ellipsefilledbuttonimage);
			this.toolstable.Add (this.ellipsefilledbutton);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.toolstable [this.ellipsefilledbutton]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.eraserbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.eraserbutton, "Rubber tool", "Rubber tool");
			this.eraserbutton.CanFocus = true;
			this.eraserbutton.Name = "eraserbutton";
			this.eraserbutton.DrawIndicator = false;
			this.eraserbutton.UseUnderline = true;
			this.eraserbutton.Group = this.anglebutton.Group;
			this.eraserbutton.Remove (this.eraserbutton.Child);
			// Container child eraserbutton.Gtk.Container+ContainerChild
			this.eraserbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.eraserbuttonimage.Name = "eraserbuttonimage";
			this.eraserbutton.Add (this.eraserbuttonimage);
			this.toolstable.Add (this.eraserbutton);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.toolstable [this.eraserbutton]));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.linebutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.linebutton, "Line tool", "Line tool");
			this.linebutton.CanFocus = true;
			this.linebutton.Name = "linebutton";
			this.linebutton.DrawIndicator = false;
			this.linebutton.UseUnderline = true;
			this.linebutton.Group = this.anglebutton.Group;
			this.linebutton.Remove (this.linebutton.Child);
			// Container child linebutton.Gtk.Container+ContainerChild
			this.linebuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.linebuttonimage.Name = "linebuttonimage";
			this.linebutton.Add (this.linebuttonimage);
			this.toolstable.Add (this.linebutton);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.toolstable [this.linebutton]));
			w15.TopAttach = ((uint)(2));
			w15.BottomAttach = ((uint)(3));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.numberbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.numberbutton, "Index tool", "Index tool");
			this.numberbutton.CanFocus = true;
			this.numberbutton.Name = "numberbutton";
			this.numberbutton.DrawIndicator = false;
			this.numberbutton.UseUnderline = true;
			this.numberbutton.Group = this.anglebutton.Group;
			this.numberbutton.Remove (this.numberbutton.Child);
			// Container child numberbutton.Gtk.Container+ContainerChild
			this.numberbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.numberbuttonimage.Name = "numberbuttonimage";
			this.numberbutton.Add (this.numberbuttonimage);
			this.toolstable.Add (this.numberbutton);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.toolstable [this.numberbutton]));
			w17.TopAttach = ((uint)(5));
			w17.BottomAttach = ((uint)(6));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.penbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.penbutton, "Pencil tool", "Pencil tool");
			this.penbutton.CanFocus = true;
			this.penbutton.Name = "penbutton";
			this.penbutton.DrawIndicator = false;
			this.penbutton.UseUnderline = true;
			this.penbutton.Group = this.anglebutton.Group;
			this.penbutton.Remove (this.penbutton.Child);
			// Container child penbutton.Gtk.Container+ContainerChild
			this.penbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.penbuttonimage.Name = "penbuttonimage";
			this.penbutton.Add (this.penbuttonimage);
			this.toolstable.Add (this.penbutton);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.toolstable [this.penbutton]));
			w19.TopAttach = ((uint)(1));
			w19.BottomAttach = ((uint)(2));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.playerbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.playerbutton, "Player tool", "Player tool");
			this.playerbutton.CanFocus = true;
			this.playerbutton.Name = "playerbutton";
			this.playerbutton.DrawIndicator = false;
			this.playerbutton.UseUnderline = true;
			this.playerbutton.Group = this.anglebutton.Group;
			this.playerbutton.Remove (this.playerbutton.Child);
			// Container child playerbutton.Gtk.Container+ContainerChild
			this.playerbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.playerbuttonimage.Name = "playerbuttonimage";
			this.playerbutton.Add (this.playerbuttonimage);
			this.toolstable.Add (this.playerbutton);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.toolstable [this.playerbutton]));
			w21.TopAttach = ((uint)(5));
			w21.BottomAttach = ((uint)(6));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.rectanglebutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.rectanglebutton, "Rectangle tool", "Rectangle tool");
			this.rectanglebutton.CanFocus = true;
			this.rectanglebutton.Name = "rectanglebutton";
			this.rectanglebutton.DrawIndicator = false;
			this.rectanglebutton.UseUnderline = true;
			this.rectanglebutton.Group = this.anglebutton.Group;
			this.rectanglebutton.Remove (this.rectanglebutton.Child);
			// Container child rectanglebutton.Gtk.Container+ContainerChild
			this.rectanglebuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.rectanglebuttonimage.Name = "rectanglebuttonimage";
			this.rectanglebutton.Add (this.rectanglebuttonimage);
			this.toolstable.Add (this.rectanglebutton);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.toolstable [this.rectanglebutton]));
			w23.TopAttach = ((uint)(3));
			w23.BottomAttach = ((uint)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.rectanglefilledbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.rectanglefilledbutton, "Filled rectangle tool", "Filled rectangle tool");
			this.rectanglefilledbutton.CanFocus = true;
			this.rectanglefilledbutton.Name = "rectanglefilledbutton";
			this.rectanglefilledbutton.DrawIndicator = false;
			this.rectanglefilledbutton.UseUnderline = true;
			this.rectanglefilledbutton.Group = this.anglebutton.Group;
			this.rectanglefilledbutton.Remove (this.rectanglefilledbutton.Child);
			// Container child rectanglefilledbutton.Gtk.Container+ContainerChild
			this.rectanglefilledbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.rectanglefilledbuttonimage.Name = "rectanglefilledbuttonimage";
			this.rectanglefilledbutton.Add (this.rectanglefilledbuttonimage);
			this.toolstable.Add (this.rectanglefilledbutton);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.toolstable [this.rectanglefilledbutton]));
			w25.TopAttach = ((uint)(4));
			w25.BottomAttach = ((uint)(5));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.selectbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.selectbutton, "Selection tool", "Selection tool");
			this.selectbutton.CanFocus = true;
			this.selectbutton.Name = "selectbutton";
			this.selectbutton.DrawIndicator = false;
			this.selectbutton.UseUnderline = true;
			this.selectbutton.Group = this.anglebutton.Group;
			this.selectbutton.Remove (this.selectbutton.Child);
			// Container child selectbutton.Gtk.Container+ContainerChild
			this.selectbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.selectbuttonimage.Name = "selectbuttonimage";
			this.selectbutton.Add (this.selectbuttonimage);
			this.toolstable.Add (this.selectbutton);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.toolstable [this.selectbutton]));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.textbutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.textbutton, "Text tool", "Text tool");
			this.textbutton.CanFocus = true;
			this.textbutton.Name = "textbutton";
			this.textbutton.DrawIndicator = false;
			this.textbutton.UseUnderline = true;
			this.textbutton.Group = this.anglebutton.Group;
			this.textbutton.Remove (this.textbutton.Child);
			// Container child textbutton.Gtk.Container+ContainerChild
			this.textbuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.textbuttonimage.Name = "textbuttonimage";
			this.textbutton.Add (this.textbuttonimage);
			this.toolstable.Add (this.textbutton);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.toolstable [this.textbutton]));
			w29.TopAttach = ((uint)(1));
			w29.BottomAttach = ((uint)(2));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(2));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child toolstable.Gtk.Table+TableChild
			this.zoombutton = new global::Gtk.RadioButton ("");
			w3.SetTip (this.zoombutton, "Index tool", "Index tool");
			this.zoombutton.CanFocus = true;
			this.zoombutton.Name = "zoombutton";
			this.zoombutton.DrawIndicator = false;
			this.zoombutton.UseUnderline = true;
			this.zoombutton.Group = this.anglebutton.Group;
			this.zoombutton.Remove (this.zoombutton.Child);
			// Container child zoombutton.Gtk.Container+ContainerChild
			this.zoombuttonimage = new global::VAS.UI.Helpers.ImageView ();
			this.zoombuttonimage.Name = "zoombuttonimage";
			this.zoombutton.Add (this.zoombuttonimage);
			this.toolstable.Add (this.zoombutton);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.toolstable [this.zoombutton]));
			w31.TopAttach = ((uint)(6));
			w31.BottomAttach = ((uint)(7));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			this.leftbox.Add (this.toolstable);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.toolstable]));
			w32.Position = 1;
			w32.Expand = false;
			// Container child leftbox.Gtk.Box+BoxChild
			this.zoombox = new global::Gtk.HBox ();
			this.zoombox.Name = "zoombox";
			this.zoombox.Spacing = 6;
			// Container child zoombox.Gtk.Box+BoxChild
			this.zoomlabel = new global::Gtk.Label ();
			this.zoomlabel.Name = "zoomlabel";
			this.zoomlabel.LabelProp = "100%";
			this.zoombox.Add (this.zoomlabel);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.zoombox [this.zoomlabel]));
			w33.Position = 0;
			w33.Expand = false;
			w33.Fill = false;
			// Container child zoombox.Gtk.Box+BoxChild
			this.zoomscalebox = new global::Gtk.HBox ();
			this.zoomscalebox.Name = "zoomscalebox";
			this.zoomscalebox.Spacing = 6;
			// Container child zoomscalebox.Gtk.Box+BoxChild
			this.zoomoutimage = new global::VAS.UI.Helpers.ImageView ();
			this.zoomoutimage.WidthRequest = 14;
			this.zoomoutimage.HeightRequest = 8;
			this.zoomoutimage.Name = "zoomoutimage";
			this.zoomscalebox.Add (this.zoomoutimage);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.zoomscalebox [this.zoomoutimage]));
			w34.Position = 0;
			w34.Expand = false;
			w34.Fill = false;
			// Container child zoomscalebox.Gtk.Box+BoxChild
			this.zoomscale = new global::Gtk.HScale (null);
			this.zoomscale.Name = "zoomscale";
			this.zoomscale.Adjustment.Upper = 100;
			this.zoomscale.Adjustment.PageIncrement = 10;
			this.zoomscale.Adjustment.StepIncrement = 1;
			this.zoomscale.Adjustment.Value = 12;
			this.zoomscale.DrawValue = false;
			this.zoomscale.Digits = 0;
			this.zoomscale.ValuePos = ((global::Gtk.PositionType)(2));
			this.zoomscalebox.Add (this.zoomscale);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.zoomscalebox [this.zoomscale]));
			w35.Position = 1;
			// Container child zoomscalebox.Gtk.Box+BoxChild
			this.zoominimage = new global::VAS.UI.Helpers.ImageView ();
			this.zoominimage.WidthRequest = 14;
			this.zoominimage.HeightRequest = 8;
			this.zoominimage.Name = "zoominimage";
			this.zoomscalebox.Add (this.zoominimage);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.zoomscalebox [this.zoominimage]));
			w36.Position = 2;
			w36.Expand = false;
			w36.Fill = false;
			this.zoombox.Add (this.zoomscalebox);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.zoombox [this.zoomscalebox]));
			w37.Position = 1;
			this.leftbox.Add (this.zoombox);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.zoombox]));
			w38.Position = 2;
			w38.Expand = false;
			w38.Fill = false;
			// Container child leftbox.Gtk.Box+BoxChild
			this.linesframe = new global::Gtk.Frame ();
			this.linesframe.Name = "linesframe";
			this.linesframe.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child linesframe.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(4)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.colorbutton = new global::Gtk.ColorButton ();
			this.colorbutton.Events = ((global::Gdk.EventMask)(784));
			this.colorbutton.Name = "colorbutton";
			this.table1.Add (this.colorbutton);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.table1 [this.colorbutton]));
			w39.LeftAttach = ((uint)(1));
			w39.RightAttach = ((uint)(2));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.colorslabel = new global::Gtk.Label ();
			this.colorslabel.Name = "colorslabel";
			this.colorslabel.Xalign = 0F;
			this.colorslabel.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Color</b>");
			this.colorslabel.UseMarkup = true;
			this.table1.Add (this.colorslabel);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.table1 [this.colorslabel]));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Size</b>");
			this.label3.UseMarkup = true;
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w41.TopAttach = ((uint)(1));
			w41.BottomAttach = ((uint)(2));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Style</b>");
			this.label4.UseMarkup = true;
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w42.TopAttach = ((uint)(2));
			w42.BottomAttach = ((uint)(3));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Type</b>");
			this.label5.UseMarkup = true;
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w43.TopAttach = ((uint)(3));
			w43.BottomAttach = ((uint)(4));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.linesizespinbutton = new global::Gtk.SpinButton (2, 20, 1);
			this.linesizespinbutton.Name = "linesizespinbutton";
			this.linesizespinbutton.Adjustment.PageIncrement = 10;
			this.linesizespinbutton.ClimbRate = 1;
			this.linesizespinbutton.Numeric = true;
			this.linesizespinbutton.Value = 4;
			this.table1.Add (this.linesizespinbutton);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.table1 [this.linesizespinbutton]));
			w44.TopAttach = ((uint)(1));
			w44.BottomAttach = ((uint)(2));
			w44.LeftAttach = ((uint)(1));
			w44.RightAttach = ((uint)(2));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.stylecombobox = global::Gtk.ComboBox.NewText ();
			w3.SetTip (this.stylecombobox, "Change the line style", "Change the line style");
			this.stylecombobox.Name = "stylecombobox";
			this.table1.Add (this.stylecombobox);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.table1 [this.stylecombobox]));
			w45.TopAttach = ((uint)(2));
			w45.BottomAttach = ((uint)(3));
			w45.LeftAttach = ((uint)(1));
			w45.RightAttach = ((uint)(2));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.typecombobox = global::Gtk.ComboBox.NewText ();
			w3.SetTip (this.typecombobox, "Change the line style", "Change the line style");
			this.typecombobox.Name = "typecombobox";
			this.table1.Add (this.typecombobox);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.table1 [this.typecombobox]));
			w46.TopAttach = ((uint)(3));
			w46.BottomAttach = ((uint)(4));
			w46.LeftAttach = ((uint)(1));
			w46.RightAttach = ((uint)(2));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment4.Add (this.table1);
			this.linesframe.Add (this.GtkAlignment4);
			this.GtkLabel4 = new global::Gtk.Label ();
			this.GtkLabel4.Name = "GtkLabel4";
			this.GtkLabel4.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Lines</b>");
			this.GtkLabel4.UseMarkup = true;
			this.linesframe.LabelWidget = this.GtkLabel4;
			this.leftbox.Add (this.linesframe);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.linesframe]));
			w49.Position = 3;
			w49.Expand = false;
			w49.Fill = false;
			// Container child leftbox.Gtk.Box+BoxChild
			this.textframe = new global::Gtk.Frame ();
			this.textframe.Name = "textframe";
			this.textframe.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child textframe.Gtk.Container+ContainerChild
			this.GtkAlignment13 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment13.Name = "GtkAlignment13";
			this.GtkAlignment13.LeftPadding = ((uint)(12));
			// Container child GtkAlignment13.Gtk.Container+ContainerChild
			this.table4 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table4.Name = "table4";
			this.table4.RowSpacing = ((uint)(6));
			this.table4.ColumnSpacing = ((uint)(6));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorbutton = new global::Gtk.ColorButton ();
			this.backgroundcolorbutton.Events = ((global::Gdk.EventMask)(784));
			this.backgroundcolorbutton.Name = "backgroundcolorbutton";
			this.table4.Add (this.backgroundcolorbutton);
			global::Gtk.Table.TableChild w50 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorbutton]));
			w50.TopAttach = ((uint)(1));
			w50.BottomAttach = ((uint)(2));
			w50.LeftAttach = ((uint)(1));
			w50.RightAttach = ((uint)(2));
			w50.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorslabel2 = new global::Gtk.Label ();
			this.backgroundcolorslabel2.Name = "backgroundcolorslabel2";
			this.backgroundcolorslabel2.Xalign = 0F;
			this.backgroundcolorslabel2.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Background</b>");
			this.backgroundcolorslabel2.UseMarkup = true;
			this.table4.Add (this.backgroundcolorslabel2);
			global::Gtk.Table.TableChild w51 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorslabel2]));
			w51.TopAttach = ((uint)(1));
			w51.BottomAttach = ((uint)(2));
			w51.XOptions = ((global::Gtk.AttachOptions)(4));
			w51.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.backgroundcolorslabel3 = new global::Gtk.Label ();
			this.backgroundcolorslabel3.Name = "backgroundcolorslabel3";
			this.backgroundcolorslabel3.Xalign = 0F;
			this.backgroundcolorslabel3.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Size</b>");
			this.backgroundcolorslabel3.UseMarkup = true;
			this.table4.Add (this.backgroundcolorslabel3);
			global::Gtk.Table.TableChild w52 = ((global::Gtk.Table.TableChild)(this.table4 [this.backgroundcolorslabel3]));
			w52.TopAttach = ((uint)(2));
			w52.BottomAttach = ((uint)(3));
			w52.XOptions = ((global::Gtk.AttachOptions)(4));
			w52.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textcolorbutton = new global::Gtk.ColorButton ();
			this.textcolorbutton.Events = ((global::Gdk.EventMask)(784));
			this.textcolorbutton.Name = "textcolorbutton";
			this.table4.Add (this.textcolorbutton);
			global::Gtk.Table.TableChild w53 = ((global::Gtk.Table.TableChild)(this.table4 [this.textcolorbutton]));
			w53.LeftAttach = ((uint)(1));
			w53.RightAttach = ((uint)(2));
			w53.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textcolorslabel2 = new global::Gtk.Label ();
			this.textcolorslabel2.Name = "textcolorslabel2";
			this.textcolorslabel2.Xalign = 0F;
			this.textcolorslabel2.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Color</b>");
			this.textcolorslabel2.UseMarkup = true;
			this.table4.Add (this.textcolorslabel2);
			global::Gtk.Table.TableChild w54 = ((global::Gtk.Table.TableChild)(this.table4 [this.textcolorslabel2]));
			w54.XOptions = ((global::Gtk.AttachOptions)(4));
			w54.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.textspinbutton = new global::Gtk.SpinButton (6, 100, 1);
			this.textspinbutton.Name = "textspinbutton";
			this.textspinbutton.Adjustment.PageIncrement = 10;
			this.textspinbutton.ClimbRate = 1;
			this.textspinbutton.Numeric = true;
			this.textspinbutton.Value = 12;
			this.table4.Add (this.textspinbutton);
			global::Gtk.Table.TableChild w55 = ((global::Gtk.Table.TableChild)(this.table4 [this.textspinbutton]));
			w55.TopAttach = ((uint)(2));
			w55.BottomAttach = ((uint)(3));
			w55.LeftAttach = ((uint)(1));
			w55.RightAttach = ((uint)(2));
			w55.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment13.Add (this.table4);
			this.textframe.Add (this.GtkAlignment13);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::VAS.Core.Catalog.GetString ("<b>Text</b>");
			this.GtkLabel5.UseMarkup = true;
			this.textframe.LabelWidget = this.GtkLabel5;
			this.leftbox.Add (this.textframe);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.textframe]));
			w58.Position = 4;
			w58.Expand = false;
			w58.Fill = false;
			// Container child leftbox.Gtk.Box+BoxChild
			this.clearbutton = new global::Gtk.Button ();
			w3.SetTip (this.clearbutton, "Clear all drawings", "Clear all drawings");
			this.clearbutton.CanFocus = true;
			this.clearbutton.Name = "clearbutton";
			this.clearbutton.UseUnderline = true;
			global::Gtk.Image w59 = new global::Gtk.Image ();
			w59.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.LargeToolbar);
			this.clearbutton.Image = w59;
			this.leftbox.Add (this.clearbutton);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.leftbox [this.clearbutton]));
			w60.PackType = ((global::Gtk.PackType)(1));
			w60.Position = 5;
			w60.Expand = false;
			w60.Fill = false;
			this.vbox2.Add (this.leftbox);
			global::Gtk.Box.BoxChild w61 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.leftbox]));
			w61.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savetoprojectbutton = new global::Gtk.Button ();
			this.savetoprojectbutton.CanFocus = true;
			this.savetoprojectbutton.Name = "savetoprojectbutton";
			this.savetoprojectbutton.UseUnderline = true;
			this.savetoprojectbutton.Label = global::VAS.Core.Catalog.GetString ("Save to Project");
			global::Gtk.Image w62 = new global::Gtk.Image ();
			w62.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.savetoprojectbutton.Image = w62;
			this.vbox2.Add (this.savetoprojectbutton);
			global::Gtk.Box.BoxChild w63 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savetoprojectbutton]));
			w63.PackType = ((global::Gtk.PackType)(1));
			w63.Position = 1;
			w63.Expand = false;
			w63.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savebutton = new global::Gtk.Button ();
			this.savebutton.CanFocus = true;
			this.savebutton.Name = "savebutton";
			this.savebutton.UseUnderline = true;
			this.savebutton.Label = global::VAS.Core.Catalog.GetString ("Save to File");
			global::Gtk.Image w64 = new global::Gtk.Image ();
			w64.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.savebutton.Image = w64;
			this.vbox2.Add (this.savebutton);
			global::Gtk.Box.BoxChild w65 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savebutton]));
			w65.PackType = ((global::Gtk.PackType)(1));
			w65.Position = 2;
			w65.Expand = false;
			w65.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w66 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w66.Position = 0;
			w66.Expand = false;
			w66.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.drawingarea = new global::Gtk.DrawingArea ();
			this.drawingarea.Name = "drawingarea";
			this.vbox4.Add (this.drawingarea);
			global::Gtk.Box.BoxChild w67 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.drawingarea]));
			w67.Position = 0;
			// Container child vbox4.Gtk.Box+BoxChild
			this.wscrollbar = new global::Gtk.HScrollbar (null);
			this.wscrollbar.Name = "wscrollbar";
			this.wscrollbar.Adjustment.Upper = 100;
			this.wscrollbar.Adjustment.PageIncrement = 10;
			this.wscrollbar.Adjustment.PageSize = 10;
			this.wscrollbar.Adjustment.StepIncrement = 1;
			this.vbox4.Add (this.wscrollbar);
			global::Gtk.Box.BoxChild w68 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.wscrollbar]));
			w68.Position = 1;
			w68.Expand = false;
			w68.Fill = false;
			this.hbox3.Add (this.vbox4);
			global::Gtk.Box.BoxChild w69 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox4]));
			w69.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hscrollbar = new global::Gtk.VScrollbar (null);
			this.hscrollbar.Name = "hscrollbar";
			this.hscrollbar.Adjustment.Upper = 100;
			this.hscrollbar.Adjustment.PageIncrement = 10;
			this.hscrollbar.Adjustment.PageSize = 10;
			this.hscrollbar.Adjustment.StepIncrement = 1;
			this.vbox5.Add (this.hscrollbar);
			global::Gtk.Box.BoxChild w70 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hscrollbar]));
			w70.Position = 0;
			// Container child vbox5.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.vbox5.Add (this.alignment1);
			global::Gtk.Box.BoxChild w71 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.alignment1]));
			w71.Position = 1;
			w71.Expand = false;
			w71.Fill = false;
			this.hbox3.Add (this.vbox5);
			global::Gtk.Box.BoxChild w72 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.vbox5]));
			w72.Position = 1;
			w72.Expand = false;
			w72.Fill = false;
			this.hbox1.Add (this.hbox3);
			global::Gtk.Box.BoxChild w73 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.hbox3]));
			w73.Position = 1;
			w1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w74 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox1]));
			w74.Position = 0;
			// Internal child VAS.UI.Dialog.DrawingTool.ActionArea
			global::Gtk.HButtonBox w75 = this.ActionArea;
			w75.Name = "dialog1_ActionArea";
			w75.Spacing = 6;
			w75.BorderWidth = ((uint)(5));
			w75.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonclose = new global::Gtk.Button ();
			this.buttonclose.CanDefault = true;
			this.buttonclose.CanFocus = true;
			this.buttonclose.Name = "buttonclose";
			this.buttonclose.UseStock = true;
			this.buttonclose.UseUnderline = true;
			this.buttonclose.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonclose, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w76 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w75 [this.buttonclose]));
			w76.Expand = false;
			w76.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.anglebutton.Hide ();
			this.savetoprojectbutton.Hide ();
			this.buttonclose.Hide ();
			this.Show ();
		}
	}
}
