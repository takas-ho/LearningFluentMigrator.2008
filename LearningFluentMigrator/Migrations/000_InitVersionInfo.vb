Imports FluentMigrator

Namespace Migrations
    <Migration(1)> Public Class InitVersionInfo : Inherits Migration

        Public Overrides Sub Up()
        End Sub

        Public Overrides Sub Down()
            Delete.FromTable("VersionInfo").AllRows()
        End Sub
    End Class
End Namespace
