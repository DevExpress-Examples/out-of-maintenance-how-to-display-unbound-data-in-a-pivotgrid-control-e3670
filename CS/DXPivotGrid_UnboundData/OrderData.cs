using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("NewDataSet")]
public class OrderData : List<OrderDetails> {
    public OrderData() { }
}
public class OrderDetails {
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}


