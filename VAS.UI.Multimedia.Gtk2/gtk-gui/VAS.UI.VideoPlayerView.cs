
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

		private global::Gtk.DrawingArea editeventtimeruledrawingarea;

		private global::Gtk.DrawingArea timerulearea;

		private global::Gtk.HBox controlsbox;

		private global::Gtk.Alignment leftBlockAlignment;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button closebutton;

		private global::VAS.UI.Helpers.ImageView closebuttonimage;

		private global::Gtk.Label eventNameLabel;

		private global::Gtk.Button drawbutton;

		private global::VAS.UI.Helpers.ImageView drawbuttonimage;

		private global::Gtk.HBox timeHBox;

		private global::Gtk.VSeparator timeLeftSeparator;

		private global::Gtk.VBox timeVBox;

		private global::Gtk.DrawingArea currentTimeArea;

		private global::Gtk.DrawingArea totalTimeArea;

		private global::Gtk.VSeparator timeRightSeparator;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Alignment centerBlockAlignment;

		private global::Gtk.HBox buttonsbox;

		private global::Gtk.Button prevbutton;

		private global::VAS.UI.Helpers.ImageView prevbuttonimage;

		private global::Gtk.Button playbutton;

		private global::VAS.UI.Helpers.ImageView playbuttonimage;

		private global::Gtk.Button pausebutton;

		private global::VAS.UI.Helpers.ImageView pausebuttonimage;

		private global::Gtk.Button nextbutton;

		private global::VAS.UI.Helpers.ImageView nextbuttonimage;

		private global::Gtk.Alignment rightBlockAlignment;

		private global::Gtk.HBox hbox3;

		private global::Gtk.HBox jumpsbox;

		private global::Gtk.VSeparator jumpsLeftSeparator;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Button jumpsButton;

		private global::VAS.UI.Helpers.ImageView jumpsButtonImage;

		private global::Gtk.Label jumpsLabel;

		private global::Gtk.VSeparator jumpsRightSeparator;

		private global::Gtk.HBox zoomBox;

		private global::Gtk.VBox zoomBoxV;

		private global::Gtk.Button zoomLevelButton;

		private global::VAS.UI.Helpers.ImageView zoomLevelImage;

		private global::Gtk.Label zoomLabel;

		private global::Gtk.VSeparator zoomSeparator;

		private global::Gtk.HBox rateBox;

		private global::Gtk.VBox rateBoxV;

		private global::Gtk.Button rateLevelButton;

		private global::VAS.UI.Helpers.ImageView rateLevelButtonImage;

		private global::Gtk.Label rateLabel;

		private global::Gtk.VSeparator rateSeparator;

		private global::Gtk.HBox durationBox;

		private global::Gtk.VBox durationBoxV;

		private global::Gtk.ToggleButton DurationButton;

		private global::VAS.UI.Helpers.ImageView DurationButtonImage;

		private global::Gtk.Label durationLabel;

		private global::Gtk.VSeparator durationSeparator;

		private global::Gtk.HBox editDurationBox;

		private global::Gtk.ToggleButton editDurationButton;

		private global::Gtk.VSeparator viewportsSeparator1;

		private global::Gtk.HBox viewportsBox;

		private global::Gtk.ToggleButton viewportsSwitchButton;

		private global::VAS.UI.Helpers.ImageView viewportsSwitchImage;

		private global::Gtk.VSeparator viewportsSeparator;

		private global::Gtk.HBox center_playhead_box;

		private global::Gtk.Button centerplayheadbutton;

		private global::VAS.UI.Helpers.ImageView centerplayheadbuttonimage;

		private global::Gtk.VSeparator centerPlayHeadSeparator;

		private global::Gtk.Button detachbutton;

		private global::VAS.UI.Helpers.ImageView detachbuttonimage;

		private global::Gtk.Button volumebutton;

		private global::VAS.UI.Helpers.ImageView volumebuttonimage;

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
			this.videohpaned.Position = 719;
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
			this.editeventtimeruledrawingarea = new global::Gtk.DrawingArea();
			this.editeventtimeruledrawingarea.Name = "editeventtimeruledrawingarea";
			this.vbox1.Add(this.editeventtimeruledrawingarea);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.editeventtimeruledrawingarea]));
			w10.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.timerulearea = new global::Gtk.DrawingArea();
			this.timerulearea.Name = "timerulearea";
			this.vbox1.Add(this.timerulearea);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.timerulearea]));
			w11.Position = 1;
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
			this.closebuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.closebuttonimage.Name = "closebuttonimage";
			this.closebutton.Add(this.closebuttonimage);
			this.hbox2.Add(this.closebutton);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.closebutton]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.eventNameLabel = new global::Gtk.Label();
			this.eventNameLabel.WidthRequest = 110;
			this.eventNameLabel.Name = "eventNameLabel";
			this.hbox2.Add(this.eventNameLabel);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.eventNameLabel]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.drawbutton = new global::Gtk.Button();
			this.drawbutton.TooltipMarkup = "Draw frame";
			this.drawbutton.Name = "drawbutton";
			this.drawbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child drawbutton.Gtk.Container+ContainerChild
			this.drawbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.drawbuttonimage.Name = "drawbuttonimage";
			this.drawbutton.Add(this.drawbuttonimage);
			this.hbox2.Add(this.drawbutton);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.drawbutton]));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.timeHBox = new global::Gtk.HBox();
			this.timeHBox.Name = "timeHBox";
			this.timeHBox.Spacing = 6;
			// Container child timeHBox.Gtk.Box+BoxChild
			this.timeLeftSeparator = new global::Gtk.VSeparator();
			this.timeLeftSeparator.Name = "timeLeftSeparator";
			this.timeHBox.Add(this.timeLeftSeparator);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.timeHBox[this.timeLeftSeparator]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child timeHBox.Gtk.Box+BoxChild
			this.timeVBox = new global::Gtk.VBox();
			this.timeVBox.Name = "timeVBox";
			// Container child timeVBox.Gtk.Box+BoxChild
			this.currentTimeArea = new global::Gtk.DrawingArea();
			this.currentTimeArea.Name = "currentTimeArea";
			this.timeVBox.Add(this.currentTimeArea);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.timeVBox[this.currentTimeArea]));
			w18.Position = 0;
			// Container child timeVBox.Gtk.Box+BoxChild
			this.totalTimeArea = new global::Gtk.DrawingArea();
			this.totalTimeArea.Name = "totalTimeArea";
			this.timeVBox.Add(this.totalTimeArea);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.timeVBox[this.totalTimeArea]));
			w19.Position = 1;
			this.timeHBox.Add(this.timeVBox);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.timeHBox[this.timeVBox]));
			w20.Position = 1;
			// Container child timeHBox.Gtk.Box+BoxChild
			this.timeRightSeparator = new global::Gtk.VSeparator();
			this.timeRightSeparator.Name = "timeRightSeparator";
			this.timeHBox.Add(this.timeRightSeparator);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.timeHBox[this.timeRightSeparator]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			this.hbox2.Add(this.timeHBox);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.timeHBox]));
			w22.Position = 3;
			w22.Expand = false;
			this.leftBlockAlignment.Add(this.hbox2);
			this.controlsbox.Add(this.leftBlockAlignment);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.leftBlockAlignment]));
			w24.Position = 0;
			// Container child controlsbox.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.HeightRequest = 0;
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.centerBlockAlignment = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.centerBlockAlignment.Name = "centerBlockAlignment";
			// Container child centerBlockAlignment.Gtk.Container+ContainerChild
			this.buttonsbox = new global::Gtk.HBox();
			this.buttonsbox.Name = "buttonsbox";
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.prevbutton = new global::Gtk.Button();
			this.prevbutton.TooltipMarkup = "Previous";
			this.prevbutton.Name = "prevbutton";
			this.prevbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child prevbutton.Gtk.Container+ContainerChild
			this.prevbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.prevbuttonimage.Name = "prevbuttonimage";
			this.prevbutton.Add(this.prevbuttonimage);
			this.buttonsbox.Add(this.prevbutton);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.prevbutton]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.playbutton = new global::Gtk.Button();
			this.playbutton.TooltipMarkup = "Play";
			this.playbutton.Name = "playbutton";
			this.playbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child playbutton.Gtk.Container+ContainerChild
			this.playbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.playbuttonimage.Name = "playbuttonimage";
			this.playbutton.Add(this.playbuttonimage);
			this.buttonsbox.Add(this.playbutton);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.playbutton]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.pausebutton = new global::Gtk.Button();
			this.pausebutton.TooltipMarkup = "Pause";
			this.pausebutton.Name = "pausebutton";
			this.pausebutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child pausebutton.Gtk.Container+ContainerChild
			this.pausebuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.pausebuttonimage.Name = "pausebuttonimage";
			this.pausebutton.Add(this.pausebuttonimage);
			this.buttonsbox.Add(this.pausebutton);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.pausebutton]));
			w30.Position = 2;
			w30.Expand = false;
			w30.Fill = false;
			// Container child buttonsbox.Gtk.Box+BoxChild
			this.nextbutton = new global::Gtk.Button();
			this.nextbutton.TooltipMarkup = "Next";
			this.nextbutton.Sensitive = false;
			this.nextbutton.Name = "nextbutton";
			this.nextbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child nextbutton.Gtk.Container+ContainerChild
			this.nextbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.nextbuttonimage.Name = "nextbuttonimage";
			this.nextbutton.Add(this.nextbuttonimage);
			this.buttonsbox.Add(this.nextbutton);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.buttonsbox[this.nextbutton]));
			w32.Position = 3;
			w32.Expand = false;
			w32.Fill = false;
			this.centerBlockAlignment.Add(this.buttonsbox);
			this.hbox4.Add(this.centerBlockAlignment);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.centerBlockAlignment]));
			w34.Position = 0;
			w34.Fill = false;
			this.controlsbox.Add(this.hbox4);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.hbox4]));
			w35.Position = 1;
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
			this.jumpsLeftSeparator = new global::Gtk.VSeparator();
			this.jumpsLeftSeparator.Name = "jumpsLeftSeparator";
			this.jumpsbox.Add(this.jumpsLeftSeparator);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.jumpsLeftSeparator]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			// Container child jumpsbox.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			// Container child vbox3.Gtk.Box+BoxChild
			this.jumpsButton = new global::Gtk.Button();
			this.jumpsButton.WidthRequest = 21;
			this.jumpsButton.HeightRequest = 21;
			this.jumpsButton.CanFocus = true;
			this.jumpsButton.Name = "jumpsButton";
			this.jumpsButton.FocusOnClick = false;
			this.jumpsButton.Relief = ((global::Gtk.ReliefStyle)(2));
			this.jumpsButton.Xalign = 0F;
			this.jumpsButton.Yalign = 0F;
			// Container child jumpsButton.Gtk.Container+ContainerChild
			this.jumpsButtonImage = new global::VAS.UI.Helpers.ImageView();
			this.jumpsButtonImage.Name = "jumpsButtonImage";
			this.jumpsButton.Add(this.jumpsButtonImage);
			this.vbox3.Add(this.jumpsButton);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.jumpsButton]));
			w38.Position = 0;
			w38.Expand = false;
			w38.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.jumpsLabel = new global::Gtk.Label();
			this.jumpsLabel.Name = "jumpsLabel";
			this.vbox3.Add(this.jumpsLabel);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.jumpsLabel]));
			w39.Position = 1;
			w39.Expand = false;
			w39.Fill = false;
			this.jumpsbox.Add(this.vbox3);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.vbox3]));
			w40.Position = 1;
			w40.Expand = false;
			w40.Fill = false;
			// Container child jumpsbox.Gtk.Box+BoxChild
			this.jumpsRightSeparator = new global::Gtk.VSeparator();
			this.jumpsRightSeparator.Name = "jumpsRightSeparator";
			this.jumpsbox.Add(this.jumpsRightSeparator);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.jumpsbox[this.jumpsRightSeparator]));
			w41.Position = 2;
			w41.Expand = false;
			w41.Fill = false;
			this.hbox3.Add(this.jumpsbox);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.jumpsbox]));
			w42.Position = 0;
			w42.Expand = false;
			w42.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.zoomBox = new global::Gtk.HBox();
			this.zoomBox.Name = "zoomBox";
			this.zoomBox.Spacing = 6;
			// Container child zoomBox.Gtk.Box+BoxChild
			this.zoomBoxV = new global::Gtk.VBox();
			this.zoomBoxV.Name = "zoomBoxV";
			// Container child zoomBoxV.Gtk.Box+BoxChild
			this.zoomLevelButton = new global::Gtk.Button();
			this.zoomLevelButton.WidthRequest = 21;
			this.zoomLevelButton.HeightRequest = 21;
			this.zoomLevelButton.CanFocus = true;
			this.zoomLevelButton.Name = "zoomLevelButton";
			this.zoomLevelButton.FocusOnClick = false;
			this.zoomLevelButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child zoomLevelButton.Gtk.Container+ContainerChild
			this.zoomLevelImage = new global::VAS.UI.Helpers.ImageView();
			this.zoomLevelImage.Name = "zoomLevelImage";
			this.zoomLevelButton.Add(this.zoomLevelImage);
			this.zoomBoxV.Add(this.zoomLevelButton);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.zoomBoxV[this.zoomLevelButton]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			// Container child zoomBoxV.Gtk.Box+BoxChild
			this.zoomLabel = new global::Gtk.Label();
			this.zoomLabel.Name = "zoomLabel";
			this.zoomBoxV.Add(this.zoomLabel);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.zoomBoxV[this.zoomLabel]));
			w45.Position = 1;
			w45.Expand = false;
			w45.Fill = false;
			this.zoomBox.Add(this.zoomBoxV);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.zoomBox[this.zoomBoxV]));
			w46.Position = 0;
			w46.Expand = false;
			w46.Fill = false;
			// Container child zoomBox.Gtk.Box+BoxChild
			this.zoomSeparator = new global::Gtk.VSeparator();
			this.zoomSeparator.Name = "zoomSeparator";
			this.zoomBox.Add(this.zoomSeparator);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.zoomBox[this.zoomSeparator]));
			w47.Position = 1;
			w47.Expand = false;
			w47.Fill = false;
			this.hbox3.Add(this.zoomBox);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.zoomBox]));
			w48.Position = 1;
			w48.Expand = false;
			w48.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.rateBox = new global::Gtk.HBox();
			this.rateBox.Name = "rateBox";
			this.rateBox.Spacing = 6;
			// Container child rateBox.Gtk.Box+BoxChild
			this.rateBoxV = new global::Gtk.VBox();
			this.rateBoxV.Name = "rateBoxV";
			// Container child rateBoxV.Gtk.Box+BoxChild
			this.rateLevelButton = new global::Gtk.Button();
			this.rateLevelButton.WidthRequest = 21;
			this.rateLevelButton.HeightRequest = 21;
			this.rateLevelButton.Sensitive = false;
			this.rateLevelButton.CanFocus = true;
			this.rateLevelButton.Name = "rateLevelButton";
			this.rateLevelButton.FocusOnClick = false;
			this.rateLevelButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child rateLevelButton.Gtk.Container+ContainerChild
			this.rateLevelButtonImage = new global::VAS.UI.Helpers.ImageView();
			this.rateLevelButtonImage.Name = "rateLevelButtonImage";
			this.rateLevelButton.Add(this.rateLevelButtonImage);
			this.rateBoxV.Add(this.rateLevelButton);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.rateBoxV[this.rateLevelButton]));
			w50.Position = 0;
			w50.Expand = false;
			w50.Fill = false;
			// Container child rateBoxV.Gtk.Box+BoxChild
			this.rateLabel = new global::Gtk.Label();
			this.rateLabel.Name = "rateLabel";
			this.rateBoxV.Add(this.rateLabel);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.rateBoxV[this.rateLabel]));
			w51.Position = 1;
			w51.Expand = false;
			w51.Fill = false;
			this.rateBox.Add(this.rateBoxV);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.rateBox[this.rateBoxV]));
			w52.Position = 0;
			w52.Expand = false;
			w52.Fill = false;
			// Container child rateBox.Gtk.Box+BoxChild
			this.rateSeparator = new global::Gtk.VSeparator();
			this.rateSeparator.Name = "rateSeparator";
			this.rateBox.Add(this.rateSeparator);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.rateBox[this.rateSeparator]));
			w53.Position = 1;
			w53.Expand = false;
			w53.Fill = false;
			this.hbox3.Add(this.rateBox);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.rateBox]));
			w54.Position = 2;
			w54.Expand = false;
			w54.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.durationBox = new global::Gtk.HBox();
			this.durationBox.Name = "durationBox";
			this.durationBox.Spacing = 6;
			// Container child durationBox.Gtk.Box+BoxChild
			this.durationBoxV = new global::Gtk.VBox();
			this.durationBoxV.Name = "durationBoxV";
			// Container child durationBoxV.Gtk.Box+BoxChild
			this.DurationButton = new global::Gtk.ToggleButton();
			this.DurationButton.WidthRequest = 21;
			this.DurationButton.HeightRequest = 21;
			this.DurationButton.Name = "DurationButton";
			this.DurationButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child DurationButton.Gtk.Container+ContainerChild
			this.DurationButtonImage = new global::VAS.UI.Helpers.ImageView();
			this.DurationButtonImage.Name = "DurationButtonImage";
			this.DurationButton.Add(this.DurationButtonImage);
			this.durationBoxV.Add(this.DurationButton);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.durationBoxV[this.DurationButton]));
			w56.Position = 0;
			w56.Expand = false;
			w56.Fill = false;
			// Container child durationBoxV.Gtk.Box+BoxChild
			this.durationLabel = new global::Gtk.Label();
			this.durationLabel.Name = "durationLabel";
			this.durationBoxV.Add(this.durationLabel);
			global::Gtk.Box.BoxChild w57 = ((global::Gtk.Box.BoxChild)(this.durationBoxV[this.durationLabel]));
			w57.Position = 1;
			w57.Expand = false;
			w57.Fill = false;
			this.durationBox.Add(this.durationBoxV);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.durationBox[this.durationBoxV]));
			w58.Position = 0;
			w58.Expand = false;
			w58.Fill = false;
			// Container child durationBox.Gtk.Box+BoxChild
			this.durationSeparator = new global::Gtk.VSeparator();
			this.durationSeparator.Name = "durationSeparator";
			this.durationBox.Add(this.durationSeparator);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.durationBox[this.durationSeparator]));
			w59.PackType = ((global::Gtk.PackType)(1));
			w59.Position = 1;
			w59.Expand = false;
			w59.Fill = false;
			this.hbox3.Add(this.durationBox);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.durationBox]));
			w60.Position = 3;
			w60.Expand = false;
			w60.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.editDurationBox = new global::Gtk.HBox();
			this.editDurationBox.Name = "editDurationBox";
			this.editDurationBox.Spacing = 6;
			// Container child editDurationBox.Gtk.Box+BoxChild
			this.editDurationButton = new global::Gtk.ToggleButton();
			this.editDurationButton.Sensitive = false;
			this.editDurationButton.CanFocus = true;
			this.editDurationButton.Name = "editDurationButton";
			this.editDurationButton.Relief = ((global::Gtk.ReliefStyle)(2));
			this.editDurationBox.Add(this.editDurationButton);
			global::Gtk.Box.BoxChild w61 = ((global::Gtk.Box.BoxChild)(this.editDurationBox[this.editDurationButton]));
			w61.Position = 0;
			// Container child editDurationBox.Gtk.Box+BoxChild
			this.viewportsSeparator1 = new global::Gtk.VSeparator();
			this.viewportsSeparator1.Name = "viewportsSeparator1";
			this.editDurationBox.Add(this.viewportsSeparator1);
			global::Gtk.Box.BoxChild w62 = ((global::Gtk.Box.BoxChild)(this.editDurationBox[this.viewportsSeparator1]));
			w62.Position = 1;
			w62.Expand = false;
			w62.Fill = false;
			this.hbox3.Add(this.editDurationBox);
			global::Gtk.Box.BoxChild w63 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.editDurationBox]));
			w63.Position = 4;
			// Container child hbox3.Gtk.Box+BoxChild
			this.viewportsBox = new global::Gtk.HBox();
			this.viewportsBox.Name = "viewportsBox";
			this.viewportsBox.Spacing = 6;
			// Container child viewportsBox.Gtk.Box+BoxChild
			this.viewportsSwitchButton = new global::Gtk.ToggleButton();
			this.viewportsSwitchButton.Name = "viewportsSwitchButton";
			this.viewportsSwitchButton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child viewportsSwitchButton.Gtk.Container+ContainerChild
			this.viewportsSwitchImage = new global::VAS.UI.Helpers.ImageView();
			this.viewportsSwitchImage.Name = "viewportsSwitchImage";
			this.viewportsSwitchButton.Add(this.viewportsSwitchImage);
			this.viewportsBox.Add(this.viewportsSwitchButton);
			global::Gtk.Box.BoxChild w65 = ((global::Gtk.Box.BoxChild)(this.viewportsBox[this.viewportsSwitchButton]));
			w65.Position = 0;
			w65.Expand = false;
			w65.Fill = false;
			// Container child viewportsBox.Gtk.Box+BoxChild
			this.viewportsSeparator = new global::Gtk.VSeparator();
			this.viewportsSeparator.Name = "viewportsSeparator";
			this.viewportsBox.Add(this.viewportsSeparator);
			global::Gtk.Box.BoxChild w66 = ((global::Gtk.Box.BoxChild)(this.viewportsBox[this.viewportsSeparator]));
			w66.Position = 1;
			w66.Expand = false;
			w66.Fill = false;
			this.hbox3.Add(this.viewportsBox);
			global::Gtk.Box.BoxChild w67 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.viewportsBox]));
			w67.Position = 5;
			w67.Expand = false;
			w67.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.center_playhead_box = new global::Gtk.HBox();
			this.center_playhead_box.Name = "center_playhead_box";
			// Container child center_playhead_box.Gtk.Box+BoxChild
			this.centerplayheadbutton = new global::Gtk.Button();
			this.centerplayheadbutton.TooltipMarkup = "Next";
			this.centerplayheadbutton.Name = "centerplayheadbutton";
			this.centerplayheadbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child centerplayheadbutton.Gtk.Container+ContainerChild
			this.centerplayheadbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.centerplayheadbuttonimage.Name = "centerplayheadbuttonimage";
			this.centerplayheadbutton.Add(this.centerplayheadbuttonimage);
			this.center_playhead_box.Add(this.centerplayheadbutton);
			global::Gtk.Box.BoxChild w69 = ((global::Gtk.Box.BoxChild)(this.center_playhead_box[this.centerplayheadbutton]));
			w69.Position = 0;
			w69.Expand = false;
			w69.Fill = false;
			// Container child center_playhead_box.Gtk.Box+BoxChild
			this.centerPlayHeadSeparator = new global::Gtk.VSeparator();
			this.centerPlayHeadSeparator.Name = "centerPlayHeadSeparator";
			this.center_playhead_box.Add(this.centerPlayHeadSeparator);
			global::Gtk.Box.BoxChild w70 = ((global::Gtk.Box.BoxChild)(this.center_playhead_box[this.centerPlayHeadSeparator]));
			w70.PackType = ((global::Gtk.PackType)(1));
			w70.Position = 1;
			w70.Expand = false;
			w70.Fill = false;
			this.hbox3.Add(this.center_playhead_box);
			global::Gtk.Box.BoxChild w71 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.center_playhead_box]));
			w71.Position = 6;
			w71.Expand = false;
			w71.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.detachbutton = new global::Gtk.Button();
			this.detachbutton.TooltipMarkup = "Detach window";
			this.detachbutton.Name = "detachbutton";
			this.detachbutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child detachbutton.Gtk.Container+ContainerChild
			this.detachbuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.detachbuttonimage.Name = "detachbuttonimage";
			this.detachbutton.Add(this.detachbuttonimage);
			this.hbox3.Add(this.detachbutton);
			global::Gtk.Box.BoxChild w73 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.detachbutton]));
			w73.PackType = ((global::Gtk.PackType)(1));
			w73.Position = 7;
			w73.Expand = false;
			w73.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.volumebutton = new global::Gtk.Button();
			this.volumebutton.TooltipMarkup = "Volume";
			this.volumebutton.Name = "volumebutton";
			this.volumebutton.Relief = ((global::Gtk.ReliefStyle)(2));
			// Container child volumebutton.Gtk.Container+ContainerChild
			this.volumebuttonimage = new global::VAS.UI.Helpers.ImageView();
			this.volumebuttonimage.Name = "volumebuttonimage";
			this.volumebutton.Add(this.volumebuttonimage);
			this.hbox3.Add(this.volumebutton);
			global::Gtk.Box.BoxChild w75 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.volumebutton]));
			w75.PackType = ((global::Gtk.PackType)(1));
			w75.Position = 8;
			w75.Expand = false;
			w75.Fill = false;
			this.rightBlockAlignment.Add(this.hbox3);
			this.controlsbox.Add(this.rightBlockAlignment);
			global::Gtk.Box.BoxChild w77 = ((global::Gtk.Box.BoxChild)(this.controlsbox[this.rightBlockAlignment]));
			w77.PackType = ((global::Gtk.PackType)(1));
			w77.Position = 2;
			this.vbox1.Add(this.controlsbox);
			global::Gtk.Box.BoxChild w78 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.controlsbox]));
			w78.Position = 2;
			w78.Expand = false;
			w78.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.lightbackgroundeventbox.Add(this.alignment1);
			this.totalbox.Add(this.lightbackgroundeventbox);
			global::Gtk.Box.BoxChild w81 = ((global::Gtk.Box.BoxChild)(this.totalbox[this.lightbackgroundeventbox]));
			w81.Position = 1;
			w81.Expand = false;
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
			this.DurationButton.Hide();
			this.durationBoxV.Hide();
			this.durationBox.Hide();
			this.controlsbox.Hide();
			this.Show();
		}
	}
}
