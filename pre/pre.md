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
* マルチプラットフォームで動作し、それぞれのプラットフォーム毎のソースは最小限にしたい
* C#は使わなくてはならない
<div style="text-align:center;font-size:55px;">
  ↓
</div>
<div style="text-align:center;font-size:35px;color:red">
  Xamarinを使ってACSU自動ログインアプリを作る
 </div>
 
----

# Xamarinって？
* microsoftによって買収された企業及び開発しているフレームワーク
* クロスプラットフォーム対応(IOS,Android,UWP)
* Visual Studioが公式サポートをしており、面倒なモバイルアプリの開発環境を容易に作り出すことができる

----

# Layout
![center 70%](drowchart.png)