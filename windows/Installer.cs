using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
class Installer : Form {
 const string Key="Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\ARTHRA";
 string target=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Programs","ARTHRA");
 [STAThread] static void Main(string[] args){Application.EnableVisualStyles();Application.SetCompatibleTextRenderingDefault(false);Application.Run(new Installer(args.Length>0&&args[0]=="/uninstall"));}
 Installer(bool uninstall){Text=uninstall?"卸载 ARTHRA":"安装 ARTHRA";Width=560;Height=300;FormBorderStyle=FormBorderStyle.FixedDialog;MaximizeBox=false;StartPosition=FormStartPosition.CenterScreen;BackColor=Color.FromArgb(16,27,41);ForeColor=Color.White;
 var text=new Label{Left=30,Top=28,Width=490,Height=140,Text=uninstall?"卸载 ARTHRA 客户端。浏览器偏好数据将保留。":"ARTHRA\n骨关节影像智能评估平台\n\nWindows x64 · 联网客户端\n安装到当前工作账号，无需管理员权限。\n此内部验收版本尚无发行者代码签名。"};Controls.Add(text);
 var b=new Button{Text=uninstall?"卸载":"安装",Left=380,Top=190,Width=120,Height=38,FlatStyle=FlatStyle.Flat};Controls.Add(b);
 b.Click+=(o,e)=>{b.Enabled=false;try{if(uninstall){foreach(string name in new[]{"ARTHRA.exe","Microsoft.Web.WebView2.Core.dll","Microsoft.Web.WebView2.WinForms.dll","WebView2Loader.dll","arthra.ico","WEBVIEW2-LICENSE.txt"}){string p=Path.Combine(target,name);if(File.Exists(p))File.Delete(p);}foreach(string folder in new[]{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),Environment.GetFolderPath(Environment.SpecialFolder.Programs)}){string p=Path.Combine(folder,"ARTHRA.lnk");if(File.Exists(p))File.Delete(p);}Registry.CurrentUser.DeleteSubKeyTree(Key,false);MessageBox.Show("客户端已卸载。","ARTHRA");Close();return;}
 Directory.CreateDirectory(target);using(var stream=Assembly.GetExecutingAssembly().GetManifestResourceStream("payload.zip"))using(var zip=new ZipArchive(stream,ZipArchiveMode.Read)){foreach(var entry in zip.Entries){if(entry.Name!=entry.FullName||string.IsNullOrEmpty(entry.Name))throw new InvalidDataException();entry.ExtractToFile(Path.Combine(target,entry.Name),true);}}
 string installer=Path.Combine(target,"ARTHRA-Setup.exe");if(!string.Equals(Assembly.GetExecutingAssembly().Location,installer,StringComparison.OrdinalIgnoreCase))File.Copy(Assembly.GetExecutingAssembly().Location,installer,true);
 dynamic shell=Activator.CreateInstance(Type.GetTypeFromProgID("WScript.Shell"));foreach(string folder in new[]{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),Environment.GetFolderPath(Environment.SpecialFolder.Programs)}){dynamic shortcut=shell.CreateShortcut(Path.Combine(folder,"ARTHRA.lnk"));shortcut.TargetPath=Path.Combine(target,"ARTHRA.exe");shortcut.WorkingDirectory=target;shortcut.IconLocation=Path.Combine(target,"arthra.ico");shortcut.Save();}
 using(var k=Registry.CurrentUser.CreateSubKey(Key)){k.SetValue("DisplayName","ARTHRA Clinical Imaging");k.SetValue("DisplayVersion","0.5.0");k.SetValue("InstallLocation",target);k.SetValue("UninstallString","\""+installer+"\" /uninstall");k.SetValue("NoModify",1);k.SetValue("NoRepair",1);}
 MessageBox.Show("安装完成。可从桌面或开始菜单打开 ARTHRA。","ARTHRA");Close();}catch(Exception ex){MessageBox.Show("操作未完成："+ex.Message,"ARTHRA");b.Enabled=true;}};
 }
}
