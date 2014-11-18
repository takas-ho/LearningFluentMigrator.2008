Imports FluentMigrator

Namespace Migrations
    <Migration(2)> Public Class AddColumnPhoneOnUser : Inherits Migration

        Public Overrides Sub Up()
            Alter.Table("User").AddColumn("Phone").AsAnsiString(13).Nullable()
        End Sub

        Public Overrides Sub Down()
            Delete.Column("Phone").FromTable("User")
        End Sub
    End Class
End Namespace