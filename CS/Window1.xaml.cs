using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Grid;

namespace DXGridTest {

    public partial class Window1 : Window {
        IScrollInfo scrollInfo;
        public Window1() {
            InitializeComponent();

            List<TestData> list = new List<TestData>();
            for(int i = 0; i < 1000; i++)
                list.Add(new TestData() { 
                    Text = "Row" + i, Number = i, Group = i % 5 });

            grid.DataSource = list;

            grid.Loaded += new RoutedEventHandler(grid_Loaded);
        }

        void grid_Loaded(object sender, RoutedEventArgs e) {
            scrollInfo = GetScrollInfo();
        }
        IScrollInfo GetScrollInfo() {
            VisualTreeEnumerator enumerator = new VisualTreeEnumerator(grid);
            while(enumerator.MoveNext()) {
                if(enumerator.Current is DataPresenter)
                    return enumerator.Current as IScrollInfo;
            }
            return null;
        }

        double offset;
        private void grid_StartSorting(object sender, RoutedEventArgs e) {
            offset = scrollInfo.VerticalOffset;
        }

        private void grid_EndSorting(object sender, RoutedEventArgs e) {
            scrollInfo.SetVerticalOffset(offset);
        }
    }

    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
        public int Group { get; set; }
    }
}
