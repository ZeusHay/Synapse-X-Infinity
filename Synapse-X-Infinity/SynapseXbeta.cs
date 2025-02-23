﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using sxlib;
using sxlib.Specialized;
using sxlib.Static;
using System.Threading;
using System.Text.RegularExpressions;

namespace Synapse_X_Infinity
{
    public partial class SynapseXbeta : Form
    {
        public static string sxDirectory = Directory.GetCurrentDirectory();

        public SynapseXbeta()
        {
            APIWrapper.IncrementCount();
            InitializeComponent();
            BunifuPages1.SetPage("dashboardPage");
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuPanel1);
#if Interface
            SynxF.Lib.AttachEvent += sxAttachEvent;
#endif
            LoadScriptsLoop.Enabled = true;
            setupMessage.Enabled = true;
            refreshImages();
        }

        public void setDefaultImages(string item)
        {
            if (item == "logo")
            {
                logoPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo.png");
                pictureBox1.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo.png");
            }

            if (item == "dashboard")
            {
                if (File.Exists(sxDirectory + "\\lib\\Resources\\dashboard.png2"))
                {
                    File.Delete(sxDirectory + "\\lib\\Resources\\dashboard.png2");
                }
                dashboardPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard.png");
                pictureBox4.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard.png");
            }

            if (item == "lua")
            {
                luaexecPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua.png");
                pictureBox6.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua.png");
            }

            if (item == "hub")
            {
                hubPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub.png");
                pictureBox7.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub.png");
            }

            if (item == "settings")
            {
                configPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings.png");
                pictureBox8.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings.png");
            }

            if (item == "minimize")
            {
                minimizePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize.png");
                pictureBox3.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize.png");
            }

            if (item == "cancel")
            {
                closePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel.png");
                pictureBox2.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel.png");
            }
        }

        public void refreshImages()
        {
            if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
            {
                if (File.Exists(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo2.png"))
                {
                    logoPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo2.png");
                    pictureBox1.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo2.png");
                }
                else
                {
                    logoPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo.png");
                    pictureBox1.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\InfinityLogoSolo.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\dashboard2.png"))
                {
                    dashboardPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard2.png");
                    pictureBox4.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard2.png");
                }
                else
                {
                    dashboardPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard.png");
                    pictureBox4.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\dashboard.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\lua2.png"))
                {
                    luaexecPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua2.png");
                    pictureBox6.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua2.png");
                }
                else
                {
                    luaexecPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua.png");
                    pictureBox6.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\lua.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\hub2.png"))
                {
                    hubPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub2.png");
                    pictureBox7.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub2.png");
                }
                else
                {
                    hubPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub.png");
                    pictureBox7.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\hub.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\settings2.png"))
                {
                    configPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings2.png");
                    pictureBox8.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings2.png");
                }
                else
                {
                    configPicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings.png");
                    pictureBox8.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\settings.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\minimize2.png"))
                {
                    minimizePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize2.png");
                    pictureBox3.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize2.png");
                }
                else
                {
                    minimizePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize.png");
                    pictureBox3.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\minimize.png");
                }

                if (File.Exists(sxDirectory + "\\lib\\Resources\\cancel2.png"))
                {
                    closePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel2.png");
                    pictureBox2.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel2.png");
                }
                else
                {
                    closePicture.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel.png");
                    pictureBox2.Image = Image.FromFile(sxDirectory + "\\lib\\Resources\\cancel.png");
                }
            }
        }

        public enum launcherConfig
        {
            UnlockFPS,
            AutoAttach,
            AutoLaunch,
            InternalUI,
            TopMost
        }

        private void Settings(launcherConfig item, bool value)
        {
            if (item == launcherConfig.UnlockFPS)
            {
                Data.Options unlockFpsOp = new Data.Options
                {
                    UnlockFPS = value
                };
                SynxF.Lib.SetOptions(unlockFpsOp);
            }

            if (item == launcherConfig.AutoAttach)
            {
                Data.Options autoAttachOp = new Data.Options
                {
                    AutoAttach = value
                };
                SynxF.Lib.SetOptions(autoAttachOp);
            }

            if (item == launcherConfig.AutoLaunch)
            {
                Data.Options autoLaunchOp = new Data.Options
                {
                    AutoLaunch = value
                };
                SynxF.Lib.SetOptions(autoLaunchOp);
            }

            if (item == launcherConfig.InternalUI)
            {
                var options = new sxlib.Static.Data.Options();
                options.InternalUI = value;
                SynxF.Lib.SetOptions(options);
            }

            if (item == launcherConfig.TopMost)
            {
                this.TopMost = value;
            }
        }

        private void LoadScripts(string path)
        {
            try
            {
                listBox1.Items.Clear();

                DirectoryInfo dinfo = new DirectoryInfo(Application.StartupPath + path);
                FileInfo[] Files = dinfo.GetFiles("*.txt");
                FileInfo[] Files1 = dinfo.GetFiles("*.lua");

                foreach (FileInfo file in Files)
                {
                    listBox1.Items.Add(file.Name);
                }

                foreach (FileInfo file in Files1)
                {
                    listBox1.Items.Add(file.Name);
                }
            }
            catch 
            {
                if (!Directory.Exists(Application.StartupPath + path))
                {
                    Directory.CreateDirectory(Application.StartupPath + path);
                }
            }
        }

        public void SetAceText(string Text)
        {
            webBrowser1.Document.InvokeScript("SetText", new object[] { Text });
        }

        public string GetAceText()
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object obj = document.InvokeScript(scriptName, new string[0]);
            string Text = obj.ToString();
            return Text;
        }
        
        public bool getProcess(string ProcessName)
        {
            Process[] pname = Process.GetProcessesByName(ProcessName);
            if (pname.Length == 0)
                return true;
            else
                return false;
        }

        private void killProcess(string ProcessName)
        {
            foreach (var process in Process.GetProcessesByName(ProcessName))
            {
                process.Kill();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            APIWrapper.ReduceCount();
            Environment.Exit(0);
            Application.Exit();
        }

        public bool setupSound = true;

        private void sxAttachEvent(SxLibBase.SynAttachEvents Event, object whatever)
        {
            switch (Event)
            {
                case SxLibBase.SynAttachEvents.CHECKING:
                    this.statusProgress.Value = 20;
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 128, 0);
                    break;

                case SxLibBase.SynAttachEvents.INJECTING:
                    this.statusProgress.ProgressColor = Color.FromArgb(195, 255, 0);
                    this.statusProgress.Value = 40;
                    break;

                case SxLibBase.SynAttachEvents.CHECKING_WHITELIST:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 208, 0);
                    this.statusProgress.Value = 60;
                    break;

                case SxLibBase.SynAttachEvents.SCANNING:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 251, 0);
                    this.statusProgress.Value = 80;
                    break;
                
                case SxLibBase.SynAttachEvents.READY:
                    SynxF.startSetup(setupSound);
                    this.statusProgress.ProgressColor = Color.FromArgb(86, 252, 3);
                    this.statusProgress.Value = 100;
                    return;

                case SxLibBase.SynAttachEvents.FAILED_TO_FIND:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 128, 0);
                    this.statusProgress.Value = 100;
                    break;

                case SxLibBase.SynAttachEvents.NOT_RUNNING_LATEST_VER_UPDATING:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 128, 0);
                    this.statusProgress.Value = 100;
                    break;

                case SxLibBase.SynAttachEvents.NOT_INJECTED:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 128, 0);
                    this.statusProgress.Value = 100;
                    break;

                case SxLibBase.SynAttachEvents.ALREADY_INJECTED:
                    this.statusProgress.ProgressColor = Color.FromArgb(255, 128, 0);
                    this.statusProgress.Value = 100;
                    break;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            BunifuPages1.SetPage("configurationPage");
            bunifuVScrollBar1.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            BunifuPages1.SetPage("hubPage");
            bunifuVScrollBar1.Visible = false;
        }

        public async void showScriptInfo(object sender, EventArgs e)
        {
            // Aqui vai ficar as coisas na hora que clicar no panel do Script
            string ID = Regex.Match(((System.Windows.Forms.Control)sender).Name, @"\d+").Value;
            APITypes.Posts post = await APIWrapper.GetPostByID(ID);

            Bunifu.UI.WinForms.BunifuPanel pnScriptInfo = new Bunifu.UI.WinForms.BunifuPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynapseXbeta));
            pnScriptInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pnScriptInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnScriptInfo.BackgroundImage")));
            pnScriptInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pnScriptInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            pnScriptInfo.BorderRadius = 3;
            pnScriptInfo.BorderThickness = 1;
            pnScriptInfo.Location = new System.Drawing.Point(3, 3);
            pnScriptInfo.Name = "pnScriptInfo";
            pnScriptInfo.ShowBorders = false;
            pnScriptInfo.Size = new System.Drawing.Size(801, 413);
            pnScriptInfo.TabIndex = 20;
            scriptsPage.Controls.Add(pnScriptInfo);

            Bunifu.UI.WinForms.BunifuPictureBox pbIconScriptInfo = new Bunifu.UI.WinForms.BunifuPictureBox();

            pbIconScriptInfo.AllowFocused = false;
            pbIconScriptInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            pbIconScriptInfo.AutoSizeHeight = false;
            pbIconScriptInfo.BorderRadius = 0;
            pbIconScriptInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbIconScriptInfo.Image")));
            pbIconScriptInfo.IsCircle = true;
            pbIconScriptInfo.Location = new System.Drawing.Point(8, 11);
            pbIconScriptInfo.Name = "pbIconScriptInfo";
            pbIconScriptInfo.Size = new System.Drawing.Size(160, 135);
            pbIconScriptInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbIconScriptInfo.TabIndex = 1;
            pbIconScriptInfo.TabStop = false;
            pbIconScriptInfo.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            pbIconScriptInfo.ImageLocation = post.image;
            pnScriptInfo.Controls.Add(pbIconScriptInfo);

            Bunifu.UI.WinForms.BunifuLabel lbDescriptionInfoScript = new Bunifu.UI.WinForms.BunifuLabel();

            lbDescriptionInfoScript.AllowParentOverrides = false;
            lbDescriptionInfoScript.AutoEllipsis = false;
            lbDescriptionInfoScript.AutoSize = false;
            lbDescriptionInfoScript.CursorType = System.Windows.Forms.Cursors.Default;
            lbDescriptionInfoScript.Font = new System.Drawing.Font("Segoe UI", 14F);
            lbDescriptionInfoScript.ForeColor = System.Drawing.Color.White;
            lbDescriptionInfoScript.Location = new System.Drawing.Point(198, 63);
            lbDescriptionInfoScript.Name = "lbDescriptionInfoScript";
            lbDescriptionInfoScript.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lbDescriptionInfoScript.Size = new System.Drawing.Size(578, 339);
            lbDescriptionInfoScript.TabIndex = 2;
            lbDescriptionInfoScript.Text = post.content;
            lbDescriptionInfoScript.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            lbDescriptionInfoScript.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            pnScriptInfo.Controls.Add(lbDescriptionInfoScript);

            Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLoadInfoScript = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();

            btnLoadInfoScript.AllowAnimations = true;
            btnLoadInfoScript.AllowMouseEffects = true;
            btnLoadInfoScript.AllowToggling = false;
            btnLoadInfoScript.AnimationSpeed = 200;
            btnLoadInfoScript.AutoGenerateColors = false;
            btnLoadInfoScript.AutoRoundBorders = true;
            btnLoadInfoScript.AutoSizeLeftIcon = true;
            btnLoadInfoScript.AutoSizeRightIcon = true;
            btnLoadInfoScript.BackColor = System.Drawing.Color.Transparent;
            btnLoadInfoScript.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            btnLoadInfoScript.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadInfoScript.BackgroundImage")));
            btnLoadInfoScript.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            btnLoadInfoScript.ButtonText = "Load this Script";
            btnLoadInfoScript.ButtonTextMarginLeft = 0;
            btnLoadInfoScript.ColorContrastOnClick = 45;
            btnLoadInfoScript.ColorContrastOnHover = 45;
            btnLoadInfoScript.Cursor = System.Windows.Forms.Cursors.Default;
            btnLoadInfoScript.DialogResult = System.Windows.Forms.DialogResult.None;
            btnLoadInfoScript.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            btnLoadInfoScript.DisabledFillColor = System.Drawing.Color.Empty;
            btnLoadInfoScript.DisabledForecolor = System.Drawing.Color.Empty;
            btnLoadInfoScript.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            btnLoadInfoScript.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnLoadInfoScript.ForeColor = System.Drawing.Color.White;
            btnLoadInfoScript.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLoadInfoScript.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            btnLoadInfoScript.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            btnLoadInfoScript.IconMarginLeft = 11;
            btnLoadInfoScript.IconPadding = 10;
            btnLoadInfoScript.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnLoadInfoScript.IconRightCursor = System.Windows.Forms.Cursors.Default;
            btnLoadInfoScript.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            btnLoadInfoScript.IconSize = 25;
            btnLoadInfoScript.IdleBorderColor = System.Drawing.Color.Empty;
            btnLoadInfoScript.IdleBorderRadius = 0;
            btnLoadInfoScript.IdleBorderThickness = 0;
            btnLoadInfoScript.IdleFillColor = System.Drawing.Color.Empty;
            btnLoadInfoScript.IdleIconLeftImage = null;
            btnLoadInfoScript.IdleIconRightImage = null;
            btnLoadInfoScript.IndicateFocus = false;
            btnLoadInfoScript.Location = new System.Drawing.Point(21, 200);
            btnLoadInfoScript.Name = "btnLoadInfoScript";
            btnLoadInfoScript.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            btnLoadInfoScript.OnDisabledState.BorderRadius = 1;
            btnLoadInfoScript.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            btnLoadInfoScript.OnDisabledState.BorderThickness = 1;
            btnLoadInfoScript.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            btnLoadInfoScript.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            btnLoadInfoScript.OnDisabledState.IconLeftImage = null;
            btnLoadInfoScript.OnDisabledState.IconRightImage = null;
            btnLoadInfoScript.OnHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            btnLoadInfoScript.OnHoverState.BorderRadius = 1;
            btnLoadInfoScript.OnHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            btnLoadInfoScript.OnHoverState.BorderThickness = 1;
            btnLoadInfoScript.OnHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            btnLoadInfoScript.OnHoverState.ForeColor = System.Drawing.Color.White;
            btnLoadInfoScript.OnHoverState.IconLeftImage = null;
            btnLoadInfoScript.OnHoverState.IconRightImage = null;
            btnLoadInfoScript.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            btnLoadInfoScript.OnIdleState.BorderRadius = 1;
            btnLoadInfoScript.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            btnLoadInfoScript.OnIdleState.BorderThickness = 1;
            btnLoadInfoScript.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            btnLoadInfoScript.OnIdleState.ForeColor = System.Drawing.Color.White;
            btnLoadInfoScript.OnIdleState.IconLeftImage = null;
            btnLoadInfoScript.OnIdleState.IconRightImage = null;
            btnLoadInfoScript.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            btnLoadInfoScript.OnPressedState.BorderRadius = 1;
            btnLoadInfoScript.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            btnLoadInfoScript.OnPressedState.BorderThickness = 1;
            btnLoadInfoScript.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            btnLoadInfoScript.OnPressedState.ForeColor = System.Drawing.Color.White;
            btnLoadInfoScript.OnPressedState.IconLeftImage = null;
            btnLoadInfoScript.OnPressedState.IconRightImage = null;
            btnLoadInfoScript.Size = new System.Drawing.Size(136, 36);
            btnLoadInfoScript.TabIndex = 3;
            btnLoadInfoScript.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnLoadInfoScript.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            btnLoadInfoScript.TextMarginLeft = 0;
            btnLoadInfoScript.TextPadding = new System.Windows.Forms.Padding(0);
            btnLoadInfoScript.UseDefaultRadiusAndThickness = true;
            pnScriptInfo.Controls.Add(btnLoadInfoScript);

            Bunifu.UI.WinForms.BunifuLabel lbTitleInfoScript = new Bunifu.UI.WinForms.BunifuLabel();

            lbTitleInfoScript.AllowParentOverrides = false;
            lbTitleInfoScript.AutoEllipsis = false;
            lbTitleInfoScript.AutoSize = false;
            lbTitleInfoScript.AutoSizeHeightOnly = true;
            lbTitleInfoScript.CursorType = null;
            lbTitleInfoScript.Font = new System.Drawing.Font("Segoe UI", 16F);
            lbTitleInfoScript.ForeColor = System.Drawing.Color.White;
            lbTitleInfoScript.Location = new System.Drawing.Point(217, 11);
            lbTitleInfoScript.Name = "lbTitleInfoScript";
            lbTitleInfoScript.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lbTitleInfoScript.Size = new System.Drawing.Size(490, 30);
            lbTitleInfoScript.TabIndex = 0;
            lbTitleInfoScript.Text = post.title;
            lbTitleInfoScript.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            lbTitleInfoScript.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            pnScriptInfo.Controls.Add(lbTitleInfoScript);

            Bunifu.UI.WinForms.BunifuLabel lbBackInfoScript = new Bunifu.UI.WinForms.BunifuLabel();

            lbBackInfoScript.AllowParentOverrides = false;
            lbBackInfoScript.AutoEllipsis = false;
            lbBackInfoScript.Cursor = System.Windows.Forms.Cursors.Default;
            lbBackInfoScript.CursorType = System.Windows.Forms.Cursors.Default;
            lbBackInfoScript.Font = new System.Drawing.Font("Segoe UI", 18F);
            lbBackInfoScript.ForeColor = System.Drawing.Color.White;
            lbBackInfoScript.Location = new System.Drawing.Point(17, 6);
            lbBackInfoScript.Name = "lbBackInfoScript";
            lbBackInfoScript.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lbBackInfoScript.Size = new System.Drawing.Size(49, 32);
            lbBackInfoScript.TabIndex = 0;
            lbBackInfoScript.Text = "Back";
            lbBackInfoScript.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            lbBackInfoScript.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            lbBackInfoScript.Click += new System.EventHandler(closePnScriptInfo);
            pnScriptInfo.Controls.Add(lbBackInfoScript);

            script = post.script;

            btnLoadInfoScript.Click += new System.EventHandler(loadPostScript);

            lbBackInfoScript.BringToFront();
            pnScriptInfo.BringToFront();
        }

        public static string script;

        private void loadPostScript(object sender, EventArgs e)
        {
            SetAceText(script);
            BunifuPages1.SetPage("executorPage");
        }

        private void closePnScriptInfo(object sender, EventArgs e)
        {
           scriptsPage.Controls["pnScriptInfo"].Visible = false;
        }

        private async void createPostPanels()
        {
            List<APITypes.Posts> posts = await APIWrapper.GetPost();
            //Fetch da API dos Dados
            if (posts.Count <= 0) { return; }

            int NewPos = 12;

            foreach ( APITypes.Posts post in posts) 
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynapseXbeta));
                Bunifu.UI.WinForms.BunifuGradientPanel tempPanel = new Bunifu.UI.WinForms.BunifuGradientPanel();
                tempPanel.BackColor = System.Drawing.Color.Transparent;
                tempPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
                tempPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                tempPanel.BorderRadius = 10;
                tempPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
                tempPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
                tempPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
                tempPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
                tempPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                tempPanel.Location = new System.Drawing.Point(12, NewPos);
                tempPanel.Name = "panelTest" + post.id.ToString();
                tempPanel.Quality = 10;
                tempPanel.Size = new System.Drawing.Size(783, 138);
                tempPanel.TabIndex = 15;
                tempPanel.Click += new System.EventHandler(showScriptInfo);

                Bunifu.UI.WinForms.BunifuLabel tempTitle = new Bunifu.UI.WinForms.BunifuLabel();
                Bunifu.UI.WinForms.BunifuLabel tempDescription = new Bunifu.UI.WinForms.BunifuLabel();
                Bunifu.UI.WinForms.BunifuPictureBox tempPicImage = new Bunifu.UI.WinForms.BunifuPictureBox();

                tempTitle.AllowParentOverrides = false;
                tempTitle.AutoEllipsis = false;
                tempTitle.AutoSize = false;
                tempTitle.CursorType = System.Windows.Forms.Cursors.Default;
                tempTitle.Font = new System.Drawing.Font("Segoe UI", 15.16F);
                tempTitle.Location = new System.Drawing.Point(154, 3);
                tempTitle.Name = "lbTitle" + post.id.ToString();
                tempTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
                tempTitle.Size = new System.Drawing.Size(626, 30);
                tempTitle.TabIndex = 0;
                tempTitle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                tempTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
                tempTitle.Text = post.title;
                tempTitle.ForeColor = Color.White;
                tempTitle.Click += new System.EventHandler(showScriptInfo);

                tempDescription.AllowParentOverrides = false;
                tempDescription.AutoEllipsis = false;
                tempDescription.AutoSize = false;
                tempDescription.CursorType = null;
                tempDescription.Font = new System.Drawing.Font("Segoe UI", 15.12F);
                tempDescription.Location = new System.Drawing.Point(154, 39);
                tempDescription.Name = "lbDescription" + post.id.ToString();
                tempDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
                tempDescription.Size = new System.Drawing.Size(626, 96);
                tempDescription.TabIndex = 1;
                tempDescription.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                tempDescription.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
                tempDescription.Text = post.content;
                tempDescription.ForeColor = Color.White;
                tempDescription.Click += new System.EventHandler(showScriptInfo);

                tempPicImage.AllowFocused = false;
                tempPicImage.Anchor = System.Windows.Forms.AnchorStyles.None;
                tempPicImage.AutoSizeHeight = true;
                tempPicImage.BorderRadius = 0;
                tempPicImage.IsCircle = true;
                tempPicImage.Location = new System.Drawing.Point(0, 1);
                tempPicImage.Name = "picImage" + post.id.ToString();
                tempPicImage.Size = new System.Drawing.Size(137, 137);
                tempPicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                tempPicImage.TabIndex = 2;
                tempPicImage.TabStop = false;
                tempPicImage.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
                tempPicImage.ImageLocation = post.image;
                tempPicImage.Click += new System.EventHandler(showScriptInfo);

                tempPanel.Controls.Add(tempPicImage);
                tempPanel.Controls.Add(tempTitle);
                tempPanel.Controls.Add(tempDescription);

                scriptsPage.Controls.Add(tempPanel);
                NewPos = tempPanel.Location.Y + 143;
            }
            bunifuCircleProgress1.Visible = false;
            scriptsPage.Height = NewPos + 30;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BunifuPages1.SetPage("dashboardPage");
            bunifuVScrollBar1.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            BunifuPages1.SetPage("executorPage");
            bunifuVScrollBar1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            SynxF.Lib.Attach();
            SynxF.Lib.AttachEvent += sxAttachEvent;
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            SynxF.Lib.Execute(GetAceText());
        }

        private void bunifuButton8_Click(object sender, EventArgs e) { SetAceText(""); }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string MainText = File.ReadAllText(SynxF.OpenFile.FileName);
                    SetAceText(MainText);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Synapse X - Error Report");
                }
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string MainText = File.ReadAllText(SynxF.OpenFile.FileName);
                    SynxF.Lib.Execute(MainText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Synapse X - Error Report");
                }
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (SynxF.SaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(SynxF.SaveFile.OpenFile());
                    writer.WriteLine(GetAceText());
                    writer.Dispose();
                    writer.Close();
                }
                catch (Exception ex) { MessageBox.Show("[Error]: " + ex.Message, "Synapse X - Error Report"); };
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void LoadScriptsLoop_Tick(object sender, EventArgs e)
        {
            LoadScripts(@"\scripts\");
        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void SynapseXbeta_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(string.Format("file:///{0}ace/AceEditor.html", AppDomain.CurrentDomain.BaseDirectory));
            Configurations.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists("scripts"))
            {
                Directory.CreateDirectory("scripts");
            }

            object item = listBox1.SelectedItem;

            if (item != null)
            {
                string path = @"\scripts\";
                string script = File.ReadAllText(Application.StartupPath + @"\scripts\" + item.ToString());

                SetAceText(script);
                LoadScripts(path);
            }
        }

        private void Configurations_Tick(object sender, EventArgs e)
        {
            bunifuElipse1.ElipseRadius = borderRadiusSlider.Value;
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            killProcess("RobloxPlayerBeta");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void computerStats_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Scripts.DexV4();
        }

        private void bunifuGradientPanel10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void topMostToggle_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (topMostToggle.Checked == true)
            {
                Settings(launcherConfig.TopMost, true);
            }
            else
            {
                Settings(launcherConfig.TopMost, false);
            }
        }

        private void autoInjectToggle_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (autoInjectToggle.Checked == true)
            {
                Settings(launcherConfig.AutoAttach, true);
            }
            else
            {
                Settings(launcherConfig.AutoAttach, false);
            }
        }

        private void autoLaunchToggle_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (autoLaunchToggle.Checked == true)
            {
                Settings(launcherConfig.AutoLaunch, true);
            }
            else
            {
                Settings(launcherConfig.AutoLaunch, false);
            }
        }

        private void unlockFpsToggle_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (unlockFpsToggle.Checked == true)
            {
                Settings(launcherConfig.UnlockFPS, true);
            }
            else
            {
                Settings(launcherConfig.UnlockFPS, false);
            }
        }

        private void internalUiToggle_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (internalUiToggle.Checked == true)
            {
                Settings(launcherConfig.InternalUI, true);
            }
            else
            {
                Settings(launcherConfig.InternalUI, false);
            }
        }

        private void setLogoText_TextChange(object sender, EventArgs e)
        {
            logoText.Text = setLogoText.Text;
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Roblox";
            if (Directory.Exists(path) == true)
            {
                Directory.Delete(path, true);
                using (WebClient Client = new WebClient())
                {
                    FileInfo file = new FileInfo("RobloxPlayerLauncher.exe");
                    Client.DownloadFile("https://setup.rbxcdn.com/version-4aa145f1367e450d-Roblox.exe", file.FullName);

                    Process.Start(file.FullName);
                }
            }
            else
            {
                using (WebClient Client = new WebClient())
                {
                    FileInfo file = new FileInfo("RobloxPlayerLauncher.exe");
                    Client.DownloadFile("https://setup.rbxcdn.com/version-4aa145f1367e450d-Roblox.exe", file.FullName);

                    Process.Start(file.FullName);
                }
            }
        }

        private void dashboardReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Delete(sxDirectory + "\\lib\\Resources\\dashboard2.png");
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\dashboard2.png", true);
                        }
                        catch {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for dashboard2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void luaexecReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\lua2.png", true);
                            refreshImages();
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for lua2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void logoReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\InfinityLogoSolo2.png", true);
                            refreshImages();
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for InfinityLogoSolo2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void hubReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\hub2.png", true);
                            refreshImages();
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for hub2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void configReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\settings2.png", true);
                            refreshImages();
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for settings2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void minimizeReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            refreshImages();
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\minimize2.png", true);
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for minimize2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void closeReplace_Click(object sender, EventArgs e)
        {
            if (SynxF.OpenImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(sxDirectory + "\\lib\\Resources"))
                    {
                        try
                        {
                            File.Copy(SynxF.OpenImageFile.FileName, sxDirectory + "\\lib\\Resources\\cancel2.png", true);
                            refreshImages();
                        }
                        catch
                        {
                            MessageBox.Show("Ya, i already know, i see a error, i'll fix this on the next update, maybe, please, change the icon manually, rename de png image for cancel2 and put on resources lib.");
                            Process.Start("explorer.exe", sxDirectory + "\\lib\\Resources");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We dont found the Resources folder in your lib.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Infinity - Error Report");
                }
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_2(object sender, EventArgs e)
        {
            setDefaultImages("dashboard");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Scripts.Hydroxide();
        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void dashboardPage_Click(object sender, EventArgs e)
        {

        }

        private void scriptsMenuItem_Click(object sender, EventArgs e)
        {
            BunifuPages1.SetPage("scriptsPage");
            createPostPanels();
            bunifuVScrollBar1.Visible = true;
        }

        private async void dashboardPage_Enter(object sender, EventArgs e)
        {
            List<APITypes.Count> data = await APIWrapper.GetAnalytics();
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            OnFormClosing(null);
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        { 
        }
    }
}
