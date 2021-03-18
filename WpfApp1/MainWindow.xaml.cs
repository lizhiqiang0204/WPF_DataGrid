using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RegisterInformation> registerInformation = new ObservableCollection<RegisterInformation>();
        ColorDialog colorDialog = new ColorDialog();
        public MainWindow()
        {
            InitializeComponent();
            myDataGrid.ItemsSource = registerInformation;//绑定源信息
        }
        //删除选中的行
        private void DeleteDataGrid_Click(object sender, RoutedEventArgs e)
        {
            while (myDataGrid.SelectedIndex != -1)
                registerInformation.RemoveAt(myDataGrid.SelectedIndex);
        }
        //插入行
        private void InsertDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedIndex == -1)
                return;
            registerInformation.Insert(myDataGrid.SelectedIndex, new RegisterInformation { });
            myDataGrid.SelectedIndex = -1;//不选中任何行            
        }
        //添加行
        private void AddDataGrid_Click(object sender, RoutedEventArgs e)
        {
            registerInformation.Add(new RegisterInformation());
        }

        private void SaveDataGrid_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }
        #region 保存文档
        private void SaveDocument()
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "",
                DefaultExt = ".csv",
                Filter = "CSV Files|*.csv|TSV Files|*.tsv|Text Files|*.txt|All Files|*.*"
            };
            var result = dlg.ShowDialog();
            if (result == true)
            {
                var filename = dlg.FileName;
                FileStream savefs = new FileStream(dlg.FileName, FileMode.Create);
                StreamWriter savesw = new StreamWriter(savefs);
                for (int _rowIndex = 0; _rowIndex < registerInformation.Count; _rowIndex++)
                {
                    savesw.Write(registerInformation[_rowIndex].Name + ",");
                    savesw.Write(registerInformation[_rowIndex].Gender + ",");
                    savesw.Write(registerInformation[_rowIndex].Age + ",");
                    savesw.Write(registerInformation[_rowIndex].RowBackgroud + ",");
                    savesw.Write("\r\n");
                }
                savesw.Flush();
                savesw.Close();
                savefs.Close();
                Title = filename;//显示全路径
            }
        }
        #endregion

        private void LoadDataGrid_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }

        #region 打开文档

        private SolidColorBrush myConvertFromString(string color)
        {
            SolidColorBrush solidColorBrush;
            if (color != "")
                solidColorBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color));
            else
                solidColorBrush = Brushes.White;
            return solidColorBrush;

        }
        private void OpenDocument()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "",
                DefaultExt = ".csv",
                Filter = "CSV Files|*.csv|TSV Files|*.tsv|Text Files|*.txt|All Files|*.*"
            };
            var result = dlg.ShowDialog();
            if (result == true)
            {
                var filename = dlg.FileName;
                FileStream openfs = new FileStream(dlg.FileName, FileMode.Open);
                StreamReader opensw = new StreamReader(openfs);
                String line;
                while ((line = opensw.ReadLine()) != null)
                {
                    string[] strArray = line.Split(',');
                    registerInformation.Add(new RegisterInformation
                    {
                        Name = strArray[0],
                        Gender = strArray[1],
                        Age = strArray[2],
                        RowBackgroud = myConvertFromString(strArray[3])
                    });
                }
                openfs.Close();
            }
        }
        #endregion


        public int rowIndex;
        public int columnIndex;

        private bool GetCellXY(System.Windows.Controls.DataGrid dg, ref int rowIndex, ref int columnIndex)
        {
            var _cells = dg.SelectedCells;
            if (_cells.Any())
            {
                rowIndex = dg.Items.IndexOf(_cells.First().Item);
                columnIndex = _cells.First().Column.DisplayIndex;
                return true;
            }
            return false;
        }

        //更改背景色
        private void BackColorDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//调用颜色选择器对话框
            {
                //提取选中的颜色
                SolidBrush sb = new SolidBrush(colorDialog.Color);
                SolidColorBrush solidColorBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(sb.Color.A, sb.Color.R, sb.Color.G, sb.Color.B));

                foreach (var item in myDataGrid.SelectedItems)
                {
                    var selected_item = item as RegisterInformation;
                    selected_item.RowBackgroud = solidColorBrush;
                }
                GetCellXY(myDataGrid, ref rowIndex, ref columnIndex);

            }
        }
    }

    //登记信息
    public class RegisterInformation : INotifyPropertyChanged
    {
        public string Name { get; set; }//姓名
        public string Gender { get; set; }//性别
        public string Age { get; set; }//年龄

        private SolidColorBrush _backgroud;
        public SolidColorBrush RowBackgroud
        {
            get { return _backgroud; }
            set { _backgroud = value; NotifyPropertyChanged(); }
        }//背景色

        private SolidColorBrush _cellgroud;
        public SolidColorBrush CellBackgroud
        {
            get { return _cellgroud; }
            set { _cellgroud = value; NotifyPropertyChanged(); }
        }//单元格背景色


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
