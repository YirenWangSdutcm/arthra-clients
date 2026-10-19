# 客户端构建与分发 · Client build and distribution

原始构建说明保留如下。本仓库并不包含完整分析服务。当前交付重点为网站和本机服务，客户端工程作为后续集成基础。

The original client build notes are retained below. The full analysis backend is not included in this repository; current delivery focuses on the website and local service.

# ARTHRA connected clients

Production origin: https://arthra-clinical.robust-bison-1426.chatgpt.site

Online clients display the same public application. They do not run local imaging inference. Current public access offers three real research cases and stateless clinical calculations; private accounts and new-image inference require the future compute deployment.

- Windows x64: `windows/build.ps1` compiles a .NET Framework WinForms + WebView2 client and per-user installer. Requires WebView2 Evergreen Runtime; the runtime is not included. SDK: Microsoft.Web.WebView2 1.0.4258.31 from NuGet. Installer is currently unsigned, for internal validation only. No claim of SmartScreen reputation or clinical certification.
- Android 8+: native WebView shell, HTTPS only, no JavaScript/native bridge, document picker limited to 10 files. GitHub Actions builds an internally signed debug APK. Do not treat a debug APK as a production release. Supply a stable release signing key before long-term distribution and updates.
- macOS 13+: WKWebView. GitHub Actions produces an unsigned universal validation archive. Developer ID signing and notarization are required before general direct distribution.
- iOS 16+: WKWebView, iPhone/iPad. CI validates the simulator target. A simulator binary is not a device installer. Apple Developer membership, provisioning and App Store Connect/TestFlight distribution are needed for devices.

Upload only this directory's source files to an empty GitHub repository. Exclude `build/` and all signing material. Workflow runs on push to `main` or manually in Actions. In a private repository, check included Actions minutes before running paid workloads. Builds are not uploaded to stores or promoted to website downloads automatically.

Native shells restrict in-app navigation to the production HTTPS origin. Evidence links and downloads open in the system browser on mobile/Apple. TLS validation is never bypassed. No patient data, local account database, passwords, private reports or model weights are included.

Before distribution: build on target runners, exercise file selection/report downloads, sign packages, test on real devices, calculate SHA-256, then update the website's `clients.json` using verified artifacts. Do not fabricate release links or package availability.
