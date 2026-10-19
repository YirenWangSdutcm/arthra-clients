$ErrorActionPreference='Stop'
$clientRoot=Split-Path $PSScriptRoot -Parent
$sdk=Join-Path $clientRoot 'build/webview2'
$out=Join-Path $clientRoot 'build/windows-x64'
New-Item -ItemType Directory -Force $out | Out-Null
$compiler=Join-Path $env:WINDIR 'Microsoft.NET/Framework64/v4.0.30319/csc.exe'
Push-Location $PSScriptRoot
& $compiler /nologo /target:winexe /platform:x64 /optimize+ /out:../build/windows-x64/ARTHRA.exe /win32icon:arthra.ico /reference:System.Windows.Forms.dll /reference:System.Drawing.dll /reference:../build/webview2/lib/net462/Microsoft.Web.WebView2.Core.dll /reference:../build/webview2/lib/net462/Microsoft.Web.WebView2.WinForms.dll Arthra.cs
if($LASTEXITCODE -ne 0){throw 'Client compilation failed'}
Copy-Item -LiteralPath "$sdk/lib/net462/Microsoft.Web.WebView2.Core.dll","$sdk/lib/net462/Microsoft.Web.WebView2.WinForms.dll","$sdk/runtimes/win-x64/native/WebView2Loader.dll","$PSScriptRoot/arthra.ico" -Destination $out
Copy-Item -LiteralPath "$sdk/LICENSE.txt" -Destination "$out/WEBVIEW2-LICENSE.txt"
Compress-Archive -Path "$out/*" -DestinationPath "$clientRoot/build/windows-payload.zip" -Force
& $compiler /nologo /target:winexe /platform:x64 /optimize+ /out:../build/ARTHRA-Setup-0.5.0-win-x64.exe /win32icon:arthra.ico /reference:System.Windows.Forms.dll /reference:System.Drawing.dll /reference:System.IO.Compression.dll /reference:System.IO.Compression.FileSystem.dll /reference:Microsoft.CSharp.dll /resource:../build/windows-payload.zip,payload.zip Installer.cs
if($LASTEXITCODE -ne 0){throw 'Installer compilation failed'}
Get-FileHash "$clientRoot/build/ARTHRA-Setup-0.5.0-win-x64.exe" -Algorithm SHA256
Pop-Location
