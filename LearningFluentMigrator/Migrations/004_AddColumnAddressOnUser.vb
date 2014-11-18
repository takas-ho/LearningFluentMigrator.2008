Imports FluentMigrator

Namespace Migrations
    <Migration(4)> Public Class AddColumnAddressOnUser : Inherits Migration

        Public Overrides Sub Up()
            Alter.Table("User").AddColumn("Address").AsString(255).Nullable()
        End Sub

        Public Overrides Sub Down()
            Delete.Column("Address").FromTable("User")
        End Sub
    End Class
End Namespace