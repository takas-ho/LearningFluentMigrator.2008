Imports FluentMigrator.Runner.Announcers
Imports FluentMigrator
Imports FluentMigrator.Runner
Imports FluentMigrator.Runner.Processors
Imports System.Reflection
Imports FluentMigrator.Runner.Initialization

Namespace Migrations
    Public Class Migrator

        Private ReadOnly _connectionString As String
        Private ReadOnly _dbType As String

        Private Class MigrationOptions : Implements IMigrationProcessorOptions

            Private _previewOnly As Boolean
            Private _timeout As Integer
            Private _providerSwitches As String
            Public ReadOnly Property PreviewOnly() As Boolean Implements IMigrationProcessorOptions.PreviewOnly
                Get
                    Return _previewOnly
                End Get
            End Property

            Public ReadOnly Property Timeout() As Integer Implements IMigrationProcessorOptions.Timeout
                Get
                    Return _timeout
                End Get
            End Property

            Public ReadOnly Property ProviderSwitches() As String Implements IMigrationProcessorOptions.ProviderSwitches
                Get
                    Return _providerSwitches
                End Get
            End Property
        End Class

        Public Sub New(ByVal connectionString As String, ByVal dbType As String)
            Me._connectionString = connectionString
            Me._dbType = dbType
        End Sub

        Private Shared Sub WriteText(ByVal s As String)
            System.Diagnostics.Debug.WriteLine(s)
        End Sub

        Public Sub Migrate(ByVal runnerAction As Action(Of IMigrationRunner))
            Dim options As New MigrationOptions
            Dim provider As New FluentMigrator.Runner.Processors.MigrationProcessorFactoryProvider
            Dim factory As IMigrationProcessorFactory = provider.GetFactory(_dbType)
            Dim assembly As Assembly = assembly.GetExecutingAssembly()
            Dim announcer As New TextWriterAnnouncer(AddressOf WriteText)
            Dim migrationContext As New RunnerContext(announcer)
            Dim processor As IMigrationProcessor = factory.Create(_connectionString, announcer, options)
            Dim runner As MigrationRunner = New MigrationRunner(assembly, migrationContext, processor)
            runnerAction(runner)
        End Sub

    End Class
End Namespace