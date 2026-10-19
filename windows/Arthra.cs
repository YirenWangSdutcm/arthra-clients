using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
class Arthra : Form {
 const string Origin="https://arthra-clinical.robust-bison-1426.chatgpt.site";
 WebView2 web=new WebView2(); Label status=new Label();
 [STAThread] static void Main(){Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);Application.Run(new Arthra());}
 Arthra(){Text="ARTHRA · 骨关节影像评估";Width=1440;Height=960;MinimumSize=new Size(800,600);BackColor=Color.FromArgb(8,15,25);try{Icon=new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"arthra.ico"));}catch{}
 var bar=new FlowLayoutPanel{Dock=DockStyle.Top,Height=40,BackColor=Color.FromArgb(16,27,41),Padding=new Padding(8,4,8,4)};
 foreach(string label in new[]{"首页","刷新","在浏览器打开"}){var b=new Button{Text=label,AutoSize=true,ForeColor=Color.White,FlatStyle=FlatStyle.Flat};b.Click+=(o,e)=>{if(label=="首页")web.Source=new Uri(Origin);else if(label=="刷新")web.Reload();else OpenExternal(Origin);};bar.Controls.Add(b);}
 status.Dock=DockStyle.Bottom;status.Height=26;status.ForeColor=Color.LightGray;status.Text="ARTHRA / CONNECTED CLINICAL IMAGING";web.Dock=DockStyle.Fill;Controls.Add(web);Controls.Add(bar);Controls.Add(status);Shown+=async(o,e)=>{
 try{var path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"ARTHRA","BrowserData");var env=await CoreWebView2Environment.CreateAsync(null,path);await web.EnsureCoreWebView2Async(env);
 web.CoreWebView2.Settings.AreHostObjectsAllowed=false;web.CoreWebView2.Settings.IsWebMessageEnabled=false;web.CoreWebView2.Settings.AreDevToolsEnabled=false;web.CoreWebView2.PermissionRequested+=(s,a)=>{a.State=CoreWebView2PermissionState.Deny;};
 web.CoreWebView2.NewWindowRequested+=(s,a)=>{a.Handled=true;OpenExternal(a.Uri);};
 web.CoreWebView2.NavigationStarting+=(s,a)=>{Uri u;if(!Uri.TryCreate(a.Uri,UriKind.Absolute,out u)||u.GetLeftPart(UriPartial.Authority)!=Origin){a.Cancel=true;OpenExternal(a.Uri);}};
 web.CoreWebView2.NavigationCompleted+=(s,a)=>status.Text=a.IsSuccess?"ARTHRA / ONLINE":"连接未完成，请检查网络后点击刷新。";
 web.Source=new Uri(Origin);
 }catch(Exception){status.Text="需要 Microsoft Edge WebView2 Runtime。";if(MessageBox.Show("请先安装微软官方 WebView2 Runtime，然后重新打开 ARTHRA。是否打开官方下载页面？","ARTHRA",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)OpenExternal("https://developer.microsoft.com/microsoft-edge/webview2/");}};
 }
 static void OpenExternal(string value){Uri uri;if(Uri.TryCreate(value,UriKind.Absolute,out uri)&&(uri.Scheme=="https"||uri.Scheme=="mailto")){try{Process.Start(new ProcessStartInfo(value){UseShellExecute=true});}catch{}}}
}
