Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Xml.Serialization

<XmlRoot("NewDataSet")> _
Public Class OrderData
	Inherits List(Of OrderDetails)
	Public Sub New()
	End Sub
End Class
Public Class OrderDetails
	Private privateOrderID As Integer
	Public Property OrderID() As Integer
		Get
			Return privateOrderID
		End Get
		Set(ByVal value As Integer)
			privateOrderID = value
		End Set
	End Property
	Private privateProductID As Integer
	Public Property ProductID() As Integer
		Get
			Return privateProductID
		End Get
		Set(ByVal value As Integer)
			privateProductID = value
		End Set
	End Property
	Private privateUnitPrice As Decimal
	Public Property UnitPrice() As Decimal
		Get
			Return privateUnitPrice
		End Get
		Set(ByVal value As Decimal)
			privateUnitPrice = value
		End Set
	End Property
	Private privateQuantity As Short
	Public Property Quantity() As Short
		Get
			Return privateQuantity
		End Get
		Set(ByVal value As Short)
			privateQuantity = value
		End Set
	End Property
	Private privateDiscount As Single
	Public Property Discount() As Single
		Get
			Return privateDiscount
		End Get
		Set(ByVal value As Single)
			privateDiscount = value
		End Set
	End Property
End Class


