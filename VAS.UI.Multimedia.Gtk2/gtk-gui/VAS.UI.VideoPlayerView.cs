
// This file has been generated by the GUI designer. Do not modify.
namespace VAS.UI
{
	public partial class VideoPlayerView
	{
		private global::Gtk.EventBox maineventbox;

		private global::Gtk.VBox totalbox;

		private global::Gtk.HBox mainbox;

		private global::Gtk.HPaned videohpaned;

		private global::Gtk.HBox videobox;

		private global::VAS.UI.VideoWindow mainviewport;

		private global::Gtk.DrawingArea blackboarddrawingarea;

		private global::Gtk.VBox subviewportsbox;

		private global::VAS.UI.SubViewport subviewport1;

		private global::VAS.UI.SubViewport subviewport2;

		private global::VAS.UI.SubViewport subviewport3;

		private global::Gtk.EventBox lightbackgroundeventbox;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.DrawingArea timerulearea;

		private global::Gtk.HBox controlsbox;

		private global::Gtk.Alignment leftBlockAlignment;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button closebutton;

		private global::VAS.UI.Helpers.ImageView closebuttonimage;

		private global::Gtk.Button drawbutton;

		private global::VAS.UI.Helpers.ImageView drawbuttonimage;

		private global::Gtk.Label eventNameLabel;

		private global::Gtk.VSeparator vseparator2;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label timeLabel;

		private global::Gtk.Label timelabel;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.Alignment centerBlockAlignment;

		private global::Gtk.HBox buttonsbox;

		private global::Gtk.Button prevbutton;

		private global::VAS.UI.Helpers.ImageView prevbuttonimage;

		private global::Gtk.Button playbutton;

		private global::Gtk.Image playbuttonimage;

		private global::Gtk.Button pausebutton;

		private global::Gtk.Image pausebuttonimage;

		private global::Gtk.Button nextbutton;

		private global::Gtk.Image nextbuttonimage;

		private global::Gtk.Alignment rightBlockAlignment;

		private global::Gtk.HBox hbox3;

		private global::Gtk.HBox jumpsbox;

		private global::Gtk.VSeparator vseparator3;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Button jumpsButton;

		private global::Gtk.Image jumpsButtonImage;

		private global::Gtk.Label jumpsLabel;

		private global::Gtk.VSeparator vseparator4;

		private global::Gtk.VBox zoomBox;

		private global::Gtk.Button zoomLevelButton;

		private global::Gtk.Image zoomLevelImage;

		private global::Gtk.Label zoomLabel;

		private global::Gtk.VSeparator vseparator5;

		private global::Gtk.VBox rateBox;

		private global::Gtk.Button rateLevelButton;

		private global::Gtk.Image rateLevelButtonImage;

		private global::Gtk.Label rateLabel;

		private global::Gtk.VBox durationBox;

		private global::Gtk.ToggleButton DurationButton;

		private global::Gtk.Image DurationButtonImage;

		private global::Gtk.Label durationLabel;

		private global::Gtk.VSeparator vseparator6;

		private global::Gtk.ToggleButton viewportsSwitchButton;

		private global::Gtk.Image viewportsSwitchImage;

		private global::Gtk.VSeparator vseparator7;

		private global::Gtk.HBox center_playhead_box;

		private global::Gtk.Button centerplayheadbutton;

		private global::Gtk.Image centerplayheadbuttonimage;

		private global::Gtk.VSeparator vseparator8;

		private global::Gtk.Button detachbutton;

		private global::VAS.UI.Helpers.ImageView detachbuttonimage;

		private global::Gtk.Button volumebutton;

		private global::Gtk.Image volumebuttonimage;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget VAS.UI.VideoPlayerView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "VAS.UI.VideoPlayerView";
			// Container child VAS.UI.VideoPlayerView.Gtk.Container+ContainerChild
			this.maineventbox = new global::Gtk.EventBox();
			this.maineventbox.Name = "maineventbox";
			// Container child maineventbox.Gtk.Container+ContainerChild
			this.totalbox = new global::Gtk.VBox();
			this.totalbox.Name = "totalbox";
			// Container child totalbox.Gtk.Box+BoxChild
			this.mainbox = new global::Gtk.HBox();
			this.mainbox.Name = "mainbox";
			// Container child mainbox.Gtk.Box+BoxChild
			this.videohpaned = new global::Gtk.HPaned();
			this.videohpaned.CanFocus = true;
			this.videohpaned.Name = "videohpaned";
			this.videohpaned.Position = 883;
			// Container child videohpaned.Gtk.Paned+PanedChild
			this.videobox = new global::Gtk.HBox();
			this.videobox.WidthRequest = 200;
			this.videobox.Name = "videobox";
			// Container child videobox.Gtk.Box+BoxChild
			this.mainviewport = new global::VAS.UI.VideoWindow();
			this.mainviewport.Events = ((global::Gdk.EventMask)(256));
			this.mainviewport.Name = "mainviewport";
			this.mainviewport.Ratio = 1F;
			this.videobox.Add(this.mainviewport);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.videobox[this.mainviewport]));
			w1.Position = 0;
			// Container child videobox.Gtk.Box+BoxChild
			this.blackboarddrawingarea = new global::Gtk.DrawingArea();
			this.blackboarddrawingarea.Name = "blackboarddrawingarea";
			this.videobox.Add(this.blackboarddrawingarea);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.videobox[this.blackboarddrawingarea]));
			w2.Position = 1;
			this.videohpaned.Add(this.videobox);
			global::Gtk.Paned.PanedChild w3 = ((global::Gtk.Paned.PanedChild)(this.videohpaned[this.videobox]));
			w3.Resize = false;
			w3.Shrink = false;
			// Container child videohpaned.Gtk.Paned+PanedChild
			this.subviewportsbox = new global::Gtk.VBox();
			this.subviewportsbox.WidthRequest = 150;
			this.subviewportsbox.Name = "subviewportsbox";
			// Container child subviewportsbox.Gtk.Box+BoxChild
			this.subviewport1 = new global::VAS.UI.SubViewport();
			this.subviewport1.Events = ((global::Gdk.EventMask)(256));
			this.subviewport1.Name = "subviewport1";
			this.subviewport1.Index = 0;
			this.subviewportsbox.Add(this.subviewport1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.subviewportsbox[this.subviewport1]));
			w4.Position = 0;
			// Container child subviewportsbox.Gtk.Box+BoxChild
			this.subviewport2 = new global::VAS.UI.SubViewport();
			this.subviewport2.Events = ((global::Gdk.EventMask)(256));
			this.subviewport2.Name = "subviewport2";
			this.subviewport2.Index = 0;
			this.subviewportsbox.Add(this.subviewport2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.subviewportsbox[this.subviewport2]));
			w5.Position = 1;
			// Container child subviewportsbox.Gtk.Box+BoxChild
			this.subviewport3 = new global::VAS.UI.SubViewport();
			this.subviewport3.Events = ((global::Gdk.EventMask)(256));
			this.subviewport3.Name = "subviewport3";
			this.subviewport3.Index = 0;
			this.subviewportsbox.Add(this.subviewport3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.subviewportsbox[this.subviewport3]));
			w6.Position = 2;
			this.videohpaned.Add(this.subviewportsbox);
			global::Gtk.Paned.PanedChild w7 = ((global::Gtk.Paned.PanedChild)(this.videohpaned[this.subviewportsbox]));
			w7.Resize = false;
			w7.Shrink = false;
			this.mainbox.Add(this.videohpaned);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.mainbox[this.videohpaned]));
			w8.Position = 0;
			this.totalbox.Add(this.mainbox);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.totalbox[this.mainbox]));
			w9.Position = 0;
			// Container child totalbox.Gtk.Box+BoxChild
			this.lightbackgroundeventbox = new global::Gtk.EventBox();
			this.lightbackgroundeventbox.Name = "lightbackgroundeventbox";
			// Container child lightbackgroundeventbox.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.timerulearea = new global::Gtk.DrawingArea();
			this.timerulearea.Name = "timerulearea";
			this.vbox1.Add(this.timerulearea);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.timerulearea]));
			w10.Position = 0;
			w10.Expand = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.controlsbox = new global::Gtk.HBox();
			this.controlsbox.Name = "controlsbox";
			this.controlsbox.Spacing = 6;
			// Container child controlsbox.Gtk.Box+BoxChild
			this.leftBlockAlignment = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.leftBlockAlignment.Name = "leftBlockAlignment";
			// Container child leftBlockAlignment.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.closebutton = new global::Gtk.Button();
			this.closebutton.TooltipMarkup = "Close loaded event";
			this.closebutton.Name = "closebutton";
			this.closebutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child closebutton.Gtk.Container+ContainerChild
			this.closebuttonimage = new global::Gtk.Image();
			this.closebuttonimage.Name = "closebuttonimage";
			this.closebutton.Add(this.closebuttonimage);
			this.hbox2.Add(this.closebutton);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.closebutton]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.drawbutton = new global::Gtk.Button();
			this.drawbutton.TooltipMarkup = "Draw frame";
			this.drawbutton.Name = "drawbutton";
			this.drawbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child drawbutton.Gtk.Container+ContainerChild
			this.drawbuttonimage = new global::Gtk.Image();
			this.drawbuttonimage.Name = "drawbuttonimage";
			this.drawbutton.Add(this.drawbuttonimage);
			this.hbox2.Add(this.drawbutton);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.drawbutton]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.eventNameLabel = new global::Gtk.Label();
			this.eventNameLabel.Name = "eventNameLabel";
			this.hbox2.Add(this.eventNameLabel);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.eventNameLabel]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator();
			this.vseparator2.Name = "vseparator2";
			this.hbox2.Add(this.vseparator2);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vseparator2]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.timeLabel = new global::Gtk.Label();
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Time");
			this.vbox2.Add(this.timeLabel);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.timeLabel]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.timelabel = new global::Gtk.Label();
			this.timelabel.Name = "timelabel";
			this.vbox2.Add(this.timelabel);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.timelabel]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.hbox2.Add(this.vbox2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
			w19.PackType = ((global::Gtk.PackType)(1));
			w19.Position = 4;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hbox2.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vseparator1]));
			w20.PackType = ((global::Gtk.PackType)(1));
			w20.Position = 5;
			w20.Expand = false;
			w20.Fill = false;
			this.leftBlockAlignment.Add(this.hbox2);
			this.controlsbox.Add(this.leftBlockAlignment);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.leftBlockAlignment]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child controlsbox.Gtk.Box+BoxChild
			this.centerBlockAlignment = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.centerBlockAlignment.Name = "centerBlockAlignment";
			// Container child centerBlockAlignment.Gtk.Container+ContainerChild
			this.buttonsbox = new global::Gtk.HBox();
			this.buttonsbox.Name = "buttonsbox";
			this.buttonsbox.Homogeneous = true;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.prevbutton = new global::Gtk.Button();
			this.prevbutton.TooltipMarkup = "Previous";
			this.prevbutton.Name = "prevbutton";
			this.prevbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child prevbutton.Gtk.Container+ContainerChild
			this.prevbuttonimage = new global::Gtk.Image();
			this.prevbuttonimage.Name = "prevbuttonimage";
			this.prevbutton.Add(this.prevbuttonimage);
			this.buttonsbox.Add(this.prevbutton);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.prevbutton]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.playbutton = new global::Gtk.Button();
			this.playbutton.TooltipMarkup = "Play";
			this.playbutton.Name = "playbutton";
			this.playbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child playbutton.Gtk.Container+ContainerChild
			this.playbuttonimage = new global::Gtk.Image();
			this.playbuttonimage.Name = "playbuttonimage";
			this.playbutton.Add(this.playbuttonimage);
			this.buttonsbox.Add(this.playbutton);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.playbutton]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.pausebutton = new global::Gtk.Button();
			this.pausebutton.TooltipMarkup = "Pause";
			this.pausebutton.Name = "pausebutton";
			this.pausebutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child pausebutton.Gtk.Container+ContainerChild
			this.pausebuttonimage = new global::Gtk.Image();
			this.pausebuttonimage.Name = "pausebuttonimage";
			this.pausebutton.Add(this.pausebuttonimage);
			this.buttonsbox.Add(this.pausebutton);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.pausebutton]));
			w28.Position = 2;
			w28.Expand = false;
			w28.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.nextbutton = new global::Gtk.Button();
			this.nextbutton.TooltipMarkup = "Next";
			this.nextbutton.Sensitive = false;
			this.nextbutton.Name = "nextbutton";
			this.nextbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child nextbutton.Gtk.Container+ContainerChild
			this.nextbuttonimage = new global::Gtk.Image();
			this.nextbuttonimage.Name = "nextbuttonimage";
			this.nextbutton.Add(this.nextbuttonimage);
			this.buttonsbox.Add(this.nextbutton);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.nextbutton]));
			w30.Position = 3;
			w30.Expand = false;
			w30.Fill = false;
			this.centerBlockAlignment.Add(this.buttonsbox);
			this.controlsbox.Add(this.centerBlockAlignment);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.centerBlockAlignment]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			// Container child controlsbox.Gtk.Box+BoxChild
			this.rightBlockAlignment = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.rightBlockAlignment.Name = "rightBlockAlignment";
			// Container child rightBlockAlignment.Gtk.Container+ContainerChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.jumpsbox = new global::Gtk.HBox();
			this.jumpsbox.Name = "jumpsbox";
			this.jumpsbox.Spacing = 6;
			// Container child jumpsbox.Gtk.Box+BoxChild
			this.vseparator3 = new global::Gtk.VSeparator();
			this.vseparator3.Name = "vseparator3";
			this.jumpsbox.Add(this.vseparator3);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.vseparator3]));
			w33.Position = 0;
			w33.Expand = false;
			w33.Fill = false;
			// Container child jumpsbox.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.jumpsButton = new global::Gtk.Button();
			this.jumpsButton.CanFocus = true;
			this.jumpsButton.Name = "jumpsButton";
			this.jumpsButton.FocusOnClick = false;
			this.jumpsButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child jumpsButton.Gtk.Container+ContainerChild
			this.jumpsButtonImage = new global::Gtk.Image();
			this.jumpsButtonImage.Name = "jumpsButtonImage";
			this.jumpsButton.Add(this.jumpsButtonImage);
			this.vbox3.Add(this.jumpsButton);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.jumpsButton]));
			w35.Position = 0;
			w35.Expand = false;
			w35.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.jumpsLabel = new global::Gtk.Label();
			this.jumpsLabel.Name = "jumpsLabel";
			this.vbox3.Add(this.jumpsLabel);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.jumpsLabel]));
			w36.Position = 1;
			w36.Expand = false;
			w36.Fill = false;
			this.jumpsbox.Add(this.vbox3);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.vbox3]));
			w37.Position = 1;
			w37.Expand = false;
			w37.Fill = false;
			// Container child jumpsbox.Gtk.Box+BoxChild
			this.vseparator4 = new global::Gtk.VSeparator();
			this.vseparator4.Name = "vseparator4";
			this.jumpsbox.Add(this.vseparator4);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.vseparator4]));
			w38.Position = 2;
			w38.Expand = false;
			w38.Fill = false;
			this.hbox3.Add(this.jumpsbox);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.jumpsbox]));
			w39.Position = 0;
			w39.Expand = false;
			w39.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.zoomBox = new global::Gtk.VBox();
			this.zoomBox.Name = "zoomBox";
			this.zoomBox.Spacing = 6;
			// Container child zoomBox.Gtk.Box+BoxChild
			this.zoomLevelButton = new global::Gtk.Button();
			this.zoomLevelButton.CanFocus = true;
			this.zoomLevelButton.Name = "zoomLevelButton";
			this.zoomLevelButton.FocusOnClick = false;
			this.zoomLevelButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child zoomLevelButton.Gtk.Container+ContainerChild
			this.zoomLevelImage = new global::Gtk.Image();
			this.zoomLevelImage.Name = "zoomLevelImage";
			this.zoomLevelButton.Add(this.zoomLevelImage);
			this.zoomBox.Add(this.zoomLevelButton);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.zoomBox[this.zoomLevelButton]));
			w41.Position = 0;
			w41.Expand = false;
			w41.Fill = false;
			// Container child zoomBox.Gtk.Box+BoxChild
			this.zoomLabel = new global::Gtk.Label();
			this.zoomLabel.Name = "zoomLabel";
			this.zoomBox.Add(this.zoomLabel);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.zoomBox[this.zoomLabel]));
			w42.Position = 1;
			w42.Expand = false;
			w42.Fill = false;
			this.hbox3.Add(this.zoomBox);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.zoomBox]));
			w43.Position = 1;
			w43.Expand = false;
			w43.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator5 = new global::Gtk.VSeparator();
			this.vseparator5.Name = "vseparator5";
			this.hbox3.Add(this.vseparator5);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator5]));
			w44.Position = 2;
			w44.Expand = false;
			w44.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.rateBox = new global::Gtk.VBox();
			this.rateBox.Name = "rateBox";
			this.rateBox.Spacing = 6;
			// Container child rateBox.Gtk.Box+BoxChild
			this.rateLevelButton = new global::Gtk.Button();
			this.rateLevelButton.Sensitive = false;
			this.rateLevelButton.CanFocus = true;
			this.rateLevelButton.Name = "rateLevelButton";
			this.rateLevelButton.FocusOnClick = false;
			this.rateLevelButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child rateLevelButton.Gtk.Container+ContainerChild
			this.rateLevelButtonImage = new global::Gtk.Image();
			this.rateLevelButtonImage.Name = "rateLevelButtonImage";
			this.rateLevelButton.Add(this.rateLevelButtonImage);
			this.rateBox.Add(this.rateLevelButton);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.rateBox[this.rateLevelButton]));
			w46.Position = 0;
			w46.Expand = false;
			w46.Fill = false;
			// Container child rateBox.Gtk.Box+BoxChild
			this.rateLabel = new global::Gtk.Label();
			this.rateLabel.Name = "rateLabel";
			this.rateBox.Add(this.rateLabel);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.rateBox[this.rateLabel]));
			w47.Position = 1;
			w47.Expand = false;
			w47.Fill = false;
			this.hbox3.Add(this.rateBox);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.rateBox]));
			w48.Position = 3;
			w48.Expand = false;
			w48.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.durationBox = new global::Gtk.VBox();
			this.durationBox.Name = "durationBox";
			this.durationBox.Spacing = 6;
			// Container child durationBox.Gtk.Box+BoxChild
			this.DurationButton = new global::Gtk.ToggleButton();
			this.DurationButton.Name = "DurationButton";
			this.DurationButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child DurationButton.Gtk.Container+ContainerChild
			this.DurationButtonImage = new global::Gtk.Image();
			this.DurationButtonImage.Name = "DurationButtonImage";
			this.DurationButton.Add(this.DurationButtonImage);
			this.durationBox.Add(this.DurationButton);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.durationBox[this.DurationButton]));
			w50.Position = 0;
			w50.Expand = false;
			w50.Fill = false;
			// Container child durationBox.Gtk.Box+BoxChild
			this.durationLabel = new global::Gtk.Label();
			this.durationLabel.Name = "durationLabel";
			this.durationBox.Add(this.durationLabel);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.durationBox[this.durationLabel]));
			w51.Position = 1;
			w51.Expand = false;
			w51.Fill = false;
			this.hbox3.Add(this.durationBox);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.durationBox]));
			w52.Position = 4;
			w52.Expand = false;
			w52.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator6 = new global::Gtk.VSeparator();
			this.vseparator6.Name = "vseparator6";
			this.hbox3.Add(this.vseparator6);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator6]));
			w53.Position = 5;
			w53.Expand = false;
			w53.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.viewportsSwitchButton = new global::Gtk.ToggleButton();
			this.viewportsSwitchButton.Name = "viewportsSwitchButton";
			this.viewportsSwitchButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child viewportsSwitchButton.Gtk.Container+ContainerChild
			this.viewportsSwitchImage = new global::Gtk.Image();
			this.viewportsSwitchImage.Name = "viewportsSwitchImage";
			this.viewportsSwitchButton.Add(this.viewportsSwitchImage);
			this.hbox3.Add(this.viewportsSwitchButton);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.viewportsSwitchButton]));
			w55.Position = 6;
			w55.Expand = false;
			w55.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator7 = new global::Gtk.VSeparator();
			this.vseparator7.Name = "vseparator7";
			this.hbox3.Add(this.vseparator7);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator7]));
			w56.Position = 7;
			w56.Expand = false;
			w56.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.center_playhead_box = new global::Gtk.HBox();
			this.center_playhead_box.Name = "center_playhead_box";
			// Container child center_playhead_box.Gtk.Box+BoxChild
			this.centerplayheadbutton = new global::Gtk.Button();
			this.centerplayheadbutton.TooltipMarkup = "Next";
			this.centerplayheadbutton.Name = "centerplayheadbutton";
			this.centerplayheadbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child centerplayheadbutton.Gtk.Container+ContainerChild
			this.centerplayheadbuttonimage = new global::Gtk.Image();
			this.centerplayheadbuttonimage.Name = "centerplayheadbuttonimage";
			this.centerplayheadbutton.Add(this.centerplayheadbuttonimage);
			this.center_playhead_box.Add(this.centerplayheadbutton);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.center_playhead_box[this.centerplayheadbutton]));
			w58.Position = 0;
			w58.Expand = false;
			w58.Fill = false;
			this.hbox3.Add(this.center_playhead_box);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.center_playhead_box]));
			w59.Position = 8;
			w59.Expand = false;
			w59.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator8 = new global::Gtk.VSeparator();
			this.vseparator8.Name = "vseparator8";
			this.hbox3.Add(this.vseparator8);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator8]));
			w60.Position = 9;
			w60.Expand = false;
			w60.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.detachbutton = new global::Gtk.Button();
			this.detachbutton.TooltipMarkup = "Detach window";
			this.detachbutton.Name = "detachbutton";
			this.detachbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child detachbutton.Gtk.Container+ContainerChild
			this.detachbuttonimage = new global::Gtk.Image();
			this.detachbuttonimage.Name = "detachbuttonimage";
			this.detachbutton.Add(this.detachbuttonimage);
			this.hbox3.Add(this.detachbutton);
			global::Gtk.Box.BoxChild w62 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.detachbutton]));
			w62.PackType = ((global::Gtk.PackType)(1));
			w62.Position = 10;
			w62.Expand = false;
			w62.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.volumebutton = new global::Gtk.Button();
			this.volumebutton.TooltipMarkup = "Volume";
			this.volumebutton.Name = "volumebutton";
			this.volumebutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child volumebutton.Gtk.Container+ContainerChild
			this.volumebuttonimage = new global::Gtk.Image();
			this.volumebuttonimage.Name = "volumebuttonimage";
			this.volumebutton.Add(this.volumebuttonimage);
			this.hbox3.Add(this.volumebutton);
			global::Gtk.Box.BoxChild w64 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.volumebutton]));
			w64.PackType = ((global::Gtk.PackType)(1));
			w64.Position = 11;
			w64.Expand = false;
			w64.Fill = false;
			this.rightBlockAlignment.Add(this.hbox3);
			this.controlsbox.Add(this.rightBlockAlignment);
			global::Gtk.Box.BoxChild w66 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.rightBlockAlignment]));
			w66.Position = 2;
			w66.Expand = false;
			w66.Fill = false;
			this.vbox1.Add(this.controlsbox);
			global::Gtk.Box.BoxChild w67 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.controlsbox]));
			w67.Position = 1;
			w67.Expand = false;
			w67.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.lightbackgroundeventbox.Add(this.alignment1);
			this.totalbox.Add(this.lightbackgroundeventbox);
			global::Gtk.Box.BoxChild w70 = ((global::Gtk.Box.BoxChild)(this.totalbox[this.lightbackgroundeventbox]));
			w70.Position = 1;
			w70.Expand = false;
			this.maineventbox.Add(this.totalbox);
			this.Add(this.maineventbox);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.blackboarddrawingarea.Hide();
			this.closebutton.Hide();
			this.prevbutton.Hide();
			this.pausebutton.Hide();
			this.nextbutton.Hide();
			this.controlsbox.Hide();
			this.Show();
		}
	}
}
