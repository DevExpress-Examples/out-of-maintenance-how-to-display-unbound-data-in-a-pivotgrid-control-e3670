Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Controls
Imports System.Xml.Serialization
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_UnboundData
	Partial Public Class MainPage
		Inherits UserControl
        Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
            Dim assembly As System.Reflection.Assembly = _
                System.Reflection.Assembly.GetExecutingAssembly()
            Dim stream As Stream = assembly.GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub
        Private Sub pivotGridControl1_CustomUnboundFieldData(ByVal sender As Object,
                                                             ByVal e As PivotCustomFieldDataEventArgs)
            If ReferenceEquals(e.Field, fieldTotalSum) Then
                Dim unitPrice As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"))
                Dim qty As Integer = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"))
                Dim discount As Decimal = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"))
                e.Value = unitPrice * qty * (1 - discount)
            End If
        End Sub
	End Class
End Namespace