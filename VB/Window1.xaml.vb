Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Grid

Namespace DXGridTest

    Public Partial Class Window1
        Inherits Window

        Private scrollInfo As IScrollInfo

        Public Sub New()
            Me.InitializeComponent()
            Dim list As List(Of TestData) = New List(Of TestData)()
            For i As Integer = 0 To 1000 - 1
                list.Add(New TestData() With {.Text = "Row" & i, .Number = i, .Group = i Mod 5})
            Next

            Me.grid.ItemsSource = list
            AddHandler Me.grid.Loaded, New RoutedEventHandler(AddressOf grid_Loaded)
        End Sub

        Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            scrollInfo = GetScrollInfo()
        End Sub

        Private Function GetScrollInfo() As IScrollInfo
            Dim enumerator As VisualTreeEnumerator = New VisualTreeEnumerator(Me.grid)
            While enumerator.MoveNext()
                If TypeOf enumerator.Current Is DataPresenter Then Return TryCast(enumerator.Current, IScrollInfo)
            End While

            Return Nothing
        End Function

        Private offset As Double

        Private Sub grid_StartSorting(ByVal sender As Object, ByVal e As RoutedEventArgs)
            offset = scrollInfo.VerticalOffset
        End Sub

        Private Sub grid_EndSorting(ByVal sender As Object, ByVal e As RoutedEventArgs)
            scrollInfo.SetVerticalOffset(offset)
        End Sub
    End Class

    Public Class TestData

        Public Property Text As String

        Public Property Number As Integer

        Public Property Group As Integer
    End Class
End Namespace
