# UnityInspectorVariableSearch
UnityInspectorVariableSearchは、選択したGameObjectのInspector内の変数を検索・編集できるUnityエディター拡張機能です。
このツールを使用することで、多くのコンポーネントや変数を持つ複雑なGameObjectで特定の変数を見つけて修正するプロセスを効率化することができます。

# デモ動画
[デモ動画](https://miya123123.github.io/UnityInspectorVariableSearch)

# 特徴
- 選択したGameObjectにアタッチされているユーザースクリプトのInspectorに表示される変数を検索します。
- 検索にヒットした変数の値を変更できます。
- 複数のユーザースクリプトを持つGameObjectの検索にも対応しています。
- プリミティブ、Unityタイプ、配列、リストなど、さまざまなフィールドタイプをサポートします。
- 軽量で高速に動作します。

# 動作確認済みUnityEditorバージョン
- 6000.0.23f1(macOS ARM64)
- 2022.3.5f1(macOS ARM64)

# インストール方法
1. [Unityパッケージ](https://github.com/miya123123/UnityInspectorVariableSearch/releases/download/ver.1.0.0/UnityInspectorVariableSearch.unitypackage)をダウンロードします。
2. Unityプロジェクトにインポートします。

# 使い方
1. UnityのHierarchyでGameObjectを選択します。
2. Unityメニューの`Tools > Inspector Variable Search`を選択して、InspectorVariableSearchウィンドウを開きます。
3. "Search Text"フィールドに検索語を入力し、"Search"ボタンをクリックします。
4. 検索にヒットした変数が本ウィンドウで表示されます。
5. 必要に応じて表示された変数を変更します。

# サポートされるフィールドタイプ
InspectorVariableSearchは以下のフィールドタイプをサポートしています：

- プリミティブ：int、float、string、bool
- Unityタイプ：Vector2、Vector3、Vector4、Quaternion、Color、LayerMask、AnimationCurve、Gradient
- Unityコンポーネント：GameObject、Transform、Rigidbody、Collider、Collider2D、Camera、Light、Material、MeshRenderer、ParticleSystem、Rigidbody2D、Animation、Animator
- 列挙型
- ScriptableObject
- サポートされている型の配列とリスト

# 制限事項
- 上記のサポートされるフィールドタイプの変数のみ検索できます。
- ユーザースクリプト内の変数のみ検索できます。
- 選択したGameObjectのコンポーネント内の変数のみを検索します。子のGameObjectやシーン全体は検索しません。

# バグ
InspectorVariableSearchウィンドウ上で検索にヒットした配列もしくはリストのサイズを変更すると、エラーが発生する場合があります。

# ライセンス
このプロジェクトは[MITライセンス](LICENSE.md)の下でライセンスされています。

# 使用LLM
「Claude 3.7 Sonnet」をコードと各種ドキュメント生成に使用しました。

# 貢献
IssueやPull Requestを歓迎します。
コントリビューションガイドラインは特に設けていません。

# 作者
miya_gamedev (@miya123123)