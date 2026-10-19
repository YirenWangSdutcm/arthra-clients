import SwiftUI
import WebKit
private let home = URL(string: "https://arthra-clinical.robust-bison-1426.chatgpt.site")!
@main struct ArthraApp: App {
 var body: some Scene { WindowGroup { ClinicalBrowser().frame(minWidth: 320, minHeight: 400) } }
}
final class Navigation: NSObject, WKNavigationDelegate, WKUIDelegate {
 func external(_ url: URL) {
  guard ["https", "mailto"].contains(url.scheme ?? "") else { return }
  #if os(macOS)
  NSWorkspace.shared.open(url)
  #else
  UIApplication.shared.open(url)
  #endif
 }
 func webView(_ webView: WKWebView, decidePolicyFor action: WKNavigationAction, decisionHandler: @escaping (WKNavigationActionPolicy) -> Void) {
  guard let url = action.request.url else { decisionHandler(.cancel); return }
  if url.scheme == "https" && url.host == home.host && action.targetFrame != nil { decisionHandler(.allow) }
  else { external(url); decisionHandler(.cancel) }
 }
 func webView(_ webView: WKWebView, decidePolicyFor response: WKNavigationResponse, decisionHandler: @escaping (WKNavigationResponsePolicy) -> Void) {
  if let url=response.response.url, !response.canShowMIMEType || url.path == "/api/export" { external(url); decisionHandler(.cancel) } else { decisionHandler(.allow) }
 }
 #if os(macOS)
 func webView(_ webView: WKWebView, runOpenPanelWith parameters: WKOpenPanelParameters, initiatedByFrame frame: WKFrameInfo, completionHandler: @escaping ([URL]?) -> Void) {
  let panel=NSOpenPanel();panel.allowsMultipleSelection=parameters.allowsMultipleSelection;panel.canChooseDirectories=false
  panel.begin { result in completionHandler(result == .OK && panel.urls.count <= 10 ? panel.urls : nil) }
 }
 #endif
}
func makeWeb(_ delegate: Navigation) -> WKWebView { let web=WKWebView();web.navigationDelegate=delegate;web.uiDelegate=delegate;web.allowsBackForwardNavigationGestures=true;web.load(URLRequest(url: home));return web }
#if os(macOS)
struct ClinicalBrowser: NSViewRepresentable {
 func makeCoordinator() -> Navigation { Navigation() }
 func makeNSView(context: Context) -> WKWebView { makeWeb(context.coordinator) }
 func updateNSView(_ view: WKWebView, context: Context) {}
}
#else
struct ClinicalBrowser: UIViewRepresentable {
 func makeCoordinator() -> Navigation { Navigation() }
 func makeUIView(context: Context) -> WKWebView { makeWeb(context.coordinator) }
 func updateUIView(_ view: WKWebView, context: Context) {}
}
#endif
