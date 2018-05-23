using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.PivotGrid;
using System;

namespace DXPivotGrid_LocateColumnAndRowHeaders {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        // Handles the CustomFieldValueCells event to remove columns with
        // zero summary values.
        void pivotGridControl1_CustomFieldValueCells(object sender, 
            PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGridControl1.DataSource == null) return;
            if (rbDefault.IsChecked == true) return;

            // Obtains the first encountered column header whose column
            // matches the specified condition, represented by a predicate.
            FieldValueCell cell = e.FindCell(true, new Predicate<object[]>(

                // Defines the predicate returning true for columns
                // that contain only zero summary values.
                delegate(object[] dataCellValues) {
                    foreach (object value in dataCellValues) {
                        if (!object.Equals((decimal)0, value))
                            return false;
                    }
                    return true;
                }));

            // If any column header matches the condition, this column is removed.
            if (cell != null) e.Remove(cell);
        }
        private void rbDefault_Checked(object sender, RoutedEventArgs e) {
            if (pivotGridControl1 == null) return;
            pivotGridControl1.LayoutChanged();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetData();
            pivotGridControl1.BestFit();
        }
        private void pivotGridControl1_FieldValueDisplayText(object sender,
            PivotFieldDisplayTextEventArgs e) {
            if (e.Value == null) return;
            if (e.Field == pivotGridControl1.Fields[PivotHelper.Month]) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
    }
}
