Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_LocateColumnAndRowHeaders
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		' Handles the CustomFieldValueCells event to remove columns with
		' zero summary values.
        Private Sub pivotGridControl1_CustomFieldValueCells(ByVal sender As Object, _
                ByVal e As PivotCustomFieldValueCellsEventArgs)
            If pivotGridControl1.DataSource Is Nothing Then
                Return
            End If
            If rbDefault.IsChecked = True Then
                Return
            End If

            ' Obtains the first encountered column header whose column
            ' matches the specified condition, represented by a predicate.
            ' Defines the predicate returning true for columns
            ' that contain only zero summary values.
            Dim cell As FieldValueCell = _
                e.FindCell(True, New Predicate(Of Object()) _
                           (Function(dataCellValues) IsColumnZero(dataCellValues)))

            ' If any column header matches the condition, this column is removed.
            If cell IsNot Nothing Then
                e.Remove(cell)
            End If
        End Sub
        Private Function IsColumnZero(ByVal dataCellValues() As Object) As Boolean
            For Each value As Object In dataCellValues
                If (Not Object.Equals(CDec(0), value)) Then
                    Return False
                End If
            Next value
            Return True
        End Function
		Private Sub rbDefault_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If pivotGridControl1 Is Nothing Then
				Return
			End If
			pivotGridControl1.LayoutChanged()
		End Sub
		Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			PivotHelper.FillPivot(pivotGridControl1)
			pivotGridControl1.DataSource = PivotHelper.GetData()
			pivotGridControl1.BestFit()
		End Sub
        Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, _
                                                            ByVal e As PivotFieldDisplayTextEventArgs)
            If e.Value Is Nothing Then
                Return
            End If
            If Object.ReferenceEquals(e.Field, pivotGridControl1.Fields(PivotHelper.Month)) Then
                e.DisplayText = _
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
            End If
        End Sub
	End Class
End Namespace
