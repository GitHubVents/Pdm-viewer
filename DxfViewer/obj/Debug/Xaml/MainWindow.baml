   M S B A M L   `   `   `  ����J  FDxfAndPDFViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DxfViewer	DxfViewer  5   	       DxfViewer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DxfViewer     5   	   -   5        $��MainWin��5        � Title$  VENTS Viewer��6	   $	��800��6-   $
��1000��6:    � WindowState$ 	Maximized=�6G    � 	Resources 5	         MyImage��%:   &	        �� 5
   
   $��..\Resource\images.png��6    5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��300��6   $	��300 �6.   �� 5      .+�5   
   �� -   5        $��TxtBoxSearch��5      $��32(�6&   $
��Bold"�65   $��0��6G   $��0��6W   $��Stretch=�6d   �� 5   
   -   5        $��	BtnSearch��5      #��[  6"   $��Right=�6E   $��50��6a   $��0��6�   $��0��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DgFiles��5   0   $��1��6   $��0��6       AutoGenerateColumns .  $��Visible=�6[      CanUserReorderColumns .     
IsReadOnly .    CanUserAddRows .  $��Stretch=�5   .   	   SelectionMode$	 Single=�5   C   $��25(�6Z   
   HorizontalGridLinesBrush
 �	#FF0B4EA2   VerticalGridLinesBrush �	#FF0B4EA2   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 35 6)      
IsReadOnly .    CellTemplate 5      �� 5       .R�5!      �� $��25��6E   ��6$   ��  �� Path$ ImageSrc�6E   5"      5$      0  *System.Windows.Controls.DataGridTextColumn  5%         Header$ Файл��6%   $ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
FileName+5(      � 5)   
   -   5        $��HostControl��5)      $��2��6"   $��1��63   �� 5*   
   -   5         ��Name$ gridSplitter��5*      $��5��6-   $��0��67   $��0��6D   $��2��6T   5+      5,      