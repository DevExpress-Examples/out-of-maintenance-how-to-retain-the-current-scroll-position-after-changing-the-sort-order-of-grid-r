Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports DevExpress.Wpf.Core.Native
Imports DevExpress.Wpf.Grid

Namespace DXGridTest

	Partial Public Class Window1
		Inherits Window
		Private scrollInfo As IScrollInfo
		Public Sub New()
			InitializeComponent()

			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 999
				list.Add(New TestData() With {.Text = "Row" & i, .Number = i, .Group = i Mod 5})
			Next i

			grid.DataSource = list

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
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateGroup As Integer
		Public Property Group() As Integer
			Get
				Return privateGroup
			End Get
			Set(ByVal value As Integer)
				privateGroup = value
			End Set
		End Property
	End Class
End Namespace
