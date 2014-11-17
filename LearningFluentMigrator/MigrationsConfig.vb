Imports FluentMigrator.Runner
Imports LearningFluentMigrator.Migrations

Public Class MigrationsConfig

    Public Shared Sub Start()

        Dim connectionString As String = "server=.\SQLEXPRESS;uid=common;pwd=common;database=Learning-Fluent-Migrator"
        Dim migrator As New Migrator(connectionString, "sqlserver2008")

        '#If DEBUG Then
        '            migrator.Migrate(runner => runner.MigrateDown(0))
        '#End If
        migrator.Migrate(AddressOf MigrateUp)
    End Sub

    Private Shared Sub MigrateUp(ByVal runner As IMigrationRunner)
        runner.MigrateUp()
    End Sub

    Private Shared Sub MigrateInit(ByVal runner As IMigrationRunner)
        runner.MigrateDown(0)
    End Sub
End Class
