<!-- page_number: true -->

# C# デモプログラム発表会
## 15t5801g 宇野 貴士

----

# Problem

<div style="text-align:left;font-size:45px;">
大学のネットワークに接続するたびに<br />
ACSUにログインするのがめんどくさい<br />（#^ω^）
</div>
<div style="text-align:right">
・・・特にスマホから
 </div>


----

<div style="text-align:center;font-size:50px;">
 出来るだけ楽にログインしたい！！！
</div>

----


<div style="text-align:center;font-size:40px;">
IOSでもAndroidでもWindowsでも使いたい
</div>

----


<div style="text-align:center;font-size:40px;">
正直沢山プログラムは書きたくない＼(^o^)／
</div>

----

# Goal
* ワンクリックでACSUにログインするためのアプリケーションの開発
* 出来ればバックグラウンドで勝手にログインしていてほしい
	* Android 8から廃止されていた・・・
* マルチプラットフォームで動作させたい
* C#は使わなくてはならない
<div style="text-align:center;font-size:55px;">
  ↓
</div>
<div style="text-align:center;font-size:33px;color:red">
  Xamarinを使ってACSU自動ログインアプリを作ればいい
 </div>
 
----
![bg center 25%](logo.png)

# Xamarinって？ 
* Microsoftによって買収された企業及び開発しているフレームワーク
* クロスプラットフォーム対応(IOS,Android,UWP)
* Xamarin.Formsというプラットフォーム間で共通のコードを作れる
* Visual Studioが公式サポートをしており、モバイルアプリの開発環境を容易に作り出すことができる
* MacなしでIPhoneのデバッグができる(xamarin live player)

----

# Layout
![center 70%](drowchart.png)