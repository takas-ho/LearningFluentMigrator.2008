Imports LearningFluentMigrator.Migrations
Imports FluentMigrator.Runner

Public Class Form1

    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        MigrationsConfig.Start()
    End Sub

End Class
