# How to retain the current scroll position after changing the sort order of grid rows


<p>The following example demonstrates how to prevent changing the current scroll position when sorting group rows.</p>


<h3>Description</h3>

<p>In the future, we are planning to add an option to internally support this behavior. If you want to be notified of its progress, please track the corresponding suggestion: <a data-ticket="Q217241">Scrolling - Add an option to retain the current scroll position after changing the sort order of grid rows</a>.</p><p>For now, as a workaround, you can handle a grid&#39;s StartSorting and EndSorting events and manually set the current vertical offset.</p>

<br/>


