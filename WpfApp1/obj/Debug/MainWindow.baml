   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid��5
         AutoGenerateColumns .     CanUserAddRows .     SelectionUnit$ CellOrRowHeader=�5         RowHeaderWidth$ 30Q�63    � ContextMenu 5      �� 5      -   5        $��myDataGridContexMenu��5       �� 	StaysOpen . 
�������.@�5      m� -   5        $��添加��5      6+   m� 5      -   5        $��删除��5      6+   m� 5      -   5        $��插入��5      6+   m� 5      -   5        $��保存��5      6+   m� 5      -   5        $��加载��5      6+   m� 5      -   5        $��	背景色��5      6,   5         RowStyle 5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5      �� 
 �� Property
 � �� �� Value 5      �� 5       �� Path$ RowBackgroud�6&    �� Mode$ TwoWay=�6:    �� UpdateSourceTrigger$ PropertyChanged=�6I   5       5!         	CellStyle 5$      �� 5%      *  $System.Windows.Controls.DataGridCell"	  6    �� Triggers 5&      P� 5'       P� Property �@ 
IsSelected P� Value . . �5(      �� 
 � ��
 ��  �6;   �� 5)      
 � ��$ 0q�6@   �� 5*      
 � ��
 �  ��6;   5+      5-         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ 姓名��60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Name+$ TwoWay=�$ PropertyChanged=�  52      $ * 6%   $ 性别��60    6A   �� *Gender+$ TwoWay=�$ PropertyChanged=�  53      $ * 6%   $ 年龄��60    6A   �� *Age+$ TwoWay=�$ PropertyChanged=�55      56      57      