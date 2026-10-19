package org.arthra.clinical;
import android.app.Activity;
import android.os.Bundle;
import android.content.Intent;
import android.net.Uri;
import android.view.View;
import android.view.WindowInsets;
import android.webkit.*;
import android.widget.*;
import java.util.ArrayList;
public class MainActivity extends Activity {
 private static final String HOME="https://arthra-clinical.robust-bison-1426.chatgpt.site";
 private WebView web; private ValueCallback<Uri[]> chooser;
 @Override public void onCreate(Bundle state){super.onCreate(state);
  LinearLayout root=new LinearLayout(this);root.setOrientation(LinearLayout.VERTICAL);root.setBackgroundColor(0xff101b29);
  root.setOnApplyWindowInsetsListener((v,i)->{v.setPadding(i.getSystemWindowInsetLeft(),i.getSystemWindowInsetTop(),i.getSystemWindowInsetRight(),i.getSystemWindowInsetBottom());return i;});
  LinearLayout bar=new LinearLayout(this);for(String title:new String[]{"首页","刷新","浏览器"}){Button b=new Button(this);b.setText(title);b.setOnClickListener(v->{if(title.equals("首页"))web.loadUrl(HOME);else if(title.equals("刷新"))web.reload();else external(Uri.parse(HOME));});bar.addView(b,new LinearLayout.LayoutParams(0,48,1));}root.addView(bar);
  web=new WebView(this);root.addView(web,new LinearLayout.LayoutParams(-1,0,1));setContentView(root);
  WebSettings settings=web.getSettings();settings.setJavaScriptEnabled(true);settings.setDomStorageEnabled(true);settings.setAllowFileAccess(false);settings.setAllowContentAccess(true);settings.setMixedContentMode(WebSettings.MIXED_CONTENT_NEVER_ALLOW);settings.setSafeBrowsingEnabled(true);settings.setSupportMultipleWindows(false);
  CookieManager.getInstance().setAcceptThirdPartyCookies(web,false);
  web.setWebViewClient(new WebViewClient(){@Override public boolean shouldOverrideUrlLoading(WebView v,WebResourceRequest r){Uri u=r.getUrl();if("https".equals(u.getScheme())&&Uri.parse(HOME).getHost().equals(u.getHost()))return false;external(u);return true;}});
  web.setWebChromeClient(new WebChromeClient(){@Override public boolean onShowFileChooser(WebView view,ValueCallback<Uri[]> callback,FileChooserParams params){if(chooser!=null)chooser.onReceiveValue(null);chooser=callback;Intent intent=new Intent(Intent.ACTION_OPEN_DOCUMENT);intent.addCategory(Intent.CATEGORY_OPENABLE);intent.setType("*/*");intent.putExtra(Intent.EXTRA_ALLOW_MULTIPLE,true);startActivityForResult(intent,10);return true;}});
  web.setDownloadListener((url,userAgent,disposition,mime,length)->external(Uri.parse(url)));
  web.loadUrl(HOME);
 }
 private void external(Uri uri){if(!"https".equals(uri.getScheme())&&!"mailto".equals(uri.getScheme()))return;try{startActivity(new Intent(Intent.ACTION_VIEW,uri));}catch(Exception e){Toast.makeText(this,"没有可打开此链接的应用",Toast.LENGTH_LONG).show();}}
 @Override protected void onActivityResult(int request,int result,Intent data){super.onActivityResult(request,result,data);if(request!=10||chooser==null)return;ArrayList<Uri> files=new ArrayList<>();if(result==RESULT_OK&&data!=null){if(data.getClipData()!=null){if(data.getClipData().getItemCount()>10){Toast.makeText(this,"每批最多10个文件",Toast.LENGTH_LONG).show();chooser.onReceiveValue(null);chooser=null;return;}for(int i=0;i<data.getClipData().getItemCount();i++)files.add(data.getClipData().getItemAt(i).getUri());}else if(data.getData()!=null)files.add(data.getData());}chooser.onReceiveValue(files.isEmpty()?null:files.toArray(new Uri[0]));chooser=null;}
 @Override public void onBackPressed(){if(web.canGoBack())web.goBack();else super.onBackPressed();}
 @Override protected void onDestroy(){if(chooser!=null)chooser.onReceiveValue(null);web.destroy();super.onDestroy();}
}
