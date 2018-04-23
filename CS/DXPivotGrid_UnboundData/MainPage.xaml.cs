using System;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_UnboundData {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_UnboundData.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }
        private void pivotGridControl1_CustomUnboundFieldData(object sender, 
            PivotCustomFieldDataEventArgs e) {
            if (ReferenceEquals(e.Field, fieldTotalSum)) {
                decimal unitPrice = Convert.ToDecimal(e.GetListSourceColumnValue("UnitPrice"));
                int qty = Convert.ToInt32(e.GetListSourceColumnValue("Quantity"));
                decimal discount = Convert.ToDecimal(e.GetListSourceColumnValue("Discount"));
                e.Value = unitPrice * qty * (1 - discount);
            }
        }
    }
}