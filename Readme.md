<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134574299/11.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3880)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_LocateColumnAndRowHeaders/MainPage.xaml) (VB: [MainPage.xaml](./VB/DXPivotGrid_LocateColumnAndRowHeaders/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DXPivotGrid_LocateColumnAndRowHeaders/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_LocateColumnAndRowHeaders/MainPage.xaml.vb))
<!-- default file list end -->
# How to locate field value cells matching a particular condition


<p>The following example demonstrates how to handle the CustomFieldValueCells event to locate a specific column/row header identified by its column's/row's summary values.<br />
In this example, a predicate is used to locate a column that contains only zero summary values. The column header is obtained by the event parameter's FindCell method, and then removed via the Remove method.</p><br />


<br/>


