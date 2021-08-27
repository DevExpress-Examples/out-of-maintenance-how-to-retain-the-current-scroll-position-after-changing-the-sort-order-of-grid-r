<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1829)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml.vb](./VB/Window1.xaml.vb))
<!-- default file list end -->
# How to retain the current scroll position after changing the sort order of grid rows


<p>The following example demonstrates how to prevent changing the current scroll position when sorting group rows.</p>


<h3>Description</h3>

<p>In the future, we are planning to add an option to internally support this behavior. If you want to be notified of its progress, please track the corresponding suggestion: <a data-ticket="Q217241">Scrolling - Add an option to retain the current scroll position after changing the sort order of grid rows</a>.</p><p>For now, as a workaround, you can handle a grid&#39;s StartSorting and EndSorting events and manually set the current vertical offset.</p>

<br/>


