Imports FluentMigrator

Namespace Migrations
    <Migration(1)> Public Class CreateUserTable : Inherits Migration

        Public Overrides Sub Up()
            Create.Table("User") _
                .WithColumn("Pwa").AsAnsiString(20).NotNullable().PrimaryKey() _
                .WithColumn("Name").AsString(255).NotNullable().WithDefaultValue("Anonymous")
        End Sub

        Public Overrides Sub Down()
            Delete.Table("User")
        End Sub
    End Class
End Namespace