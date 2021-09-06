Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Grid

Namespace DXGridTest

	Partial Public Class Window1
		Inherits Window

		Private scrollInfo As IScrollInfo
		Public Sub New()
			InitializeComponent()

			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 999
				list.Add(New TestData() With {
					.Text = "Row" & i,
					.Number = i,
					.Group = i Mod 5
				})
			Next i

			grid.ItemsSource = list

			AddHandler grid.Loaded, AddressOf grid_Loaded
		End Sub

		Private Sub grid_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			scrollInfo = GetScrollInfo()
		End Sub
		Private Function GetScrollInfo() As IScrollInfo
			Dim enumerator As New VisualTreeEnumerator(grid)
			Do While enumerator.MoveNext()
				If TypeOf enumerator.Current Is DataPresenter Then
					Return TryCast(enumerator.Current, IScrollInfo)
				End If
			Loop
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
		Public Property Text() As String
		Public Property Number() As Integer
		Public Property Group() As Integer
	End Class
End Namespace
