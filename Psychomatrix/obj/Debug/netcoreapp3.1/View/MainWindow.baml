   M S B A M L   `   `   `  ����G  CPsychomatrix, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PsychomatrixPsychomatrix  5   	   U QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 62   3    -Psychomatrix.Controller.UI.Windows.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.0.48.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Psychomatrix     5   	   <sys,clr-namespace:System;assembly=System.Runtime     62   -   5          � Title$  Pythagoras Psychomatrix��5   	   $	��480��6)   $	��852��66   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   .+�5   
   o� $��0��6   $��0��6   .@�5      m� $
��File��6   .@�5      m� -   5        $��OpenMenuItem��5      $
��Open��60   6>   m� 5      -   5        $��SaveMenuItem��5      $
��Save��6/   6=   5      m� 5      $
��Edit��6   .@�5      m� -   5        $��UnblockMenuItem��5      $��Unblock��62   6d   m� 5      -   5        $��BlockMenuItem��5      $��Block��60   6^   m� 5      -   5        $��ClearMenuItem��5      $��Clear��60   6^   5      m� 5      $��Tools��6   .@�5      m� -   5        $��RestartMenuItem��5      $��Restart��62   6d   m� 5      -   5        $��ExitMenuItem��5      $
��Exit��6/   6[   5      m� 5      $
��Info��6   .@�5       m� -	   5        $��DateMenuItem��5       $
��Date��6/   6@   m� 5!      -
   5        $��TimeMenuItem��5!      $
��Time��6/   6@   m� 5"      -   5        $��StopwatchMenuItem��5"      $��	Stopwatch��64   6J   m� 5#      -   5        $��
OSMenuItem��5#      $��OS��6-   6<   m� 5$      -   5        $��LocationMenuItem��5$      $��Location��63   6H   m� 5%      -   5        $��LANIPMenuItem��5%      $��LAN IP��60   6C   m� 5&      -   5        $��WANIPMenuItem��5&      $��WAN IP��60   6C   5'      m� 5(      $
��Help��6   .@�5)      m� -   5        $��AboutMenuItem��5)      $��About��60   6^   m� 5*      -   5        $��AuthorMenuItem��5*      $��Author��61   6a   5+      5,      �� 5-   
   $��0��6   $��1��6%   .@�5.      �� ��5/      �� 50      $
��Bold"�6   .�6-   	One Day66   .��52      �  53      �� 54      $
��auto �6(   68   �� 55      6*    57      �� 58      6-   .+�5:      �� $��0��6   $��0��6/   ��5;      �� 5<      $
��Bold"�6#   .�65   Input6<   .��5>      �  5?      �� 5@   "   $
��auto �60   6@   �� 5A   "   62   �� 5B   "   62    5D      �� 5E   "   65   �� 5F   "   65   .+�5H      �� $��Select Date of Birthday��6$   $
��Bold"�6F   $
��Auto��6X   $
��Auto��6e   $��Center=�6s   $��Center=�6�   $��0��6�   $��2��6�   $��0��6�   (  "System.Windows.Controls.DatePicker  5I      -   5        $��DateDatePicker��5I   )   $
��Auto��6?   $
��Auto��6L   $��Center=�6Z   $��Center=�6w   $��0��6�   $��2��6�   $��1��6�      SelectedDateFormat$ Short=�6�   �� 5J      -   5        $��	Calculate��5J   %   $
��Auto��69   $
��Auto��6F   $��Center=�6T   $��Center=�6q   $��0��6�   $��2��6�   $��2��6�   6�   5K      5L      �� 5M      $��0��6   $��1��6/   ��5N      �� 5O      $
��Bold"�6#   .�65   Output6=   .��5Q      �  5R      �� 5S   "   $
��auto �60   6@   �� 5T   "   62    5V      �� 5W   "   65   �� 5X   "   65   �� 5Y   "   65   .+�5[      �� $��Calculation��6$   $
��Bold"�6:   $
��Auto��6L   $
��Auto��6Y   $��Center=�6g   $��Center=�6�   $��0��6�   $��1��6�   $��0��6�   �� 5\      -   5        $��
LogTextBox��5\   &   $�� ��68   $��1��6@   $��0��6M   $��1��6]    �� 
IsReadOnly$
 True��6q    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��6�   $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5]      $��Matrix��6$   $
��Bold"�65   $
��Auto��6G   $
��Auto��6T   $��Center=�6b   $��Center=�6   $��1��6�   $��1��6�   $��0��6�   �� 5^      $��Description��6$   $
��Bold"�6:   $
��Auto��6L   $
��Auto��6Y   $��Center=�6g   $��Center=�6�   $��2��6�   $��2��6�   $��0��6�   �� 5_      -   5        $��DescTextBox��5_   &   $�� ��69   $��1��6A   $��2��6N   $��1��6^   $
 True��6r   $
 Wrap=�6�   $
 True��6�   $ Disabled=�6�   $
 Auto=�6�   � 5`      $��1��6#   $��1��63    5a   "   �� 5b   &   66   �� 5c   &   66   �� 5d   &   66   �� 5e   &   66   �� 5f   &   66   �� 5g   &   66    5i   "   �� 5j   &   69   �� 5k   &   69   �� 5l   &   69   �� 5m   &   69   .+�5o   "   �� -   5        $��TextBox0��5o   *   $��Center=�6:   $�� ��6\   $��0��6d   $��0��6q   $��4��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   	 �� TextAlignment$	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5p   "   -   5        $��TextBox1��5p   *   $��Center=�6:   $�� ��6\   $��1��6d   $��0��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5q   "   -   5        $��TextBox2��5q   *   $��Center=�6:   $�� ��6\   $��1��6d   $��1��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5r   "   -   5        $��TextBox3��5r   *   $��Center=�6:   $�� ��6\   $��1��6d   $��2��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5s   "   -   5        $��TextBox4��5s   *   $��Center=�6:   $�� ��6\   $��2��6d   $��0��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5t   "   -   5        $��TextBox5��5t   *   $��Center=�6:   $�� ��6\   $��2��6d   $��1��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5u   "   -   5        $��TextBox6��5u   *   $��Center=�6:   $�� ��6\   $��2��6d   $��2��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5v   "   -   5        $��TextBox7��5v   *   $��Center=�6:   $�� ��6\   $��3��6d   $��0��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5w   "   -   5        $��TextBox8��5w   *   $��Center=�6:   $�� ��6\   $��3��6d   $��1��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5x   "   -   5        $��TextBox9��5x   *   $��Center=�6:   $�� ��6\   $��3��6d   $��2��6q   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5y   "   -    5        $��	TextBox10��5y   *   $��Center=�6;   $�� ��6]   $��4��6e   $��0��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5z   "   -!   5        $��	TextBox11��5z   *   $��Center=�6;   $�� ��6]   $��4��6e   $��1��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5{   "   -"   5        $��	TextBox12��5{   *   $��Center=�6;   $�� ��6]   $��4��6e   $��2��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5|   "   -#   5        $��	TextBox0S��5|   *   $��Center=�6;   $�� ��6]   $��1��6e   $��3��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5}   "   -$   5        $��	TextBox1S��5}   *   $��Center=�6;   $�� ��6]   $��2��6e   $��3��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5~   "   -%   5        $��	TextBox2S��5~   *   $��Center=�6;   $�� ��6]   $��3��6e   $��3��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5   "   -&   5        $��	TextBox3S��5   *   $��Center=�6;   $�� ��6]   $��4��6e   $��3��6r   $��1��6�   $
 True��6�   $
 Wrap=�6�   $
 True��6�   $	 Center=�6�   $ Disabled=�6�   $ Disabled=�6  �� 5�   "   $
��Auto��6(   $
��Auto��65   $��Center=�6C   $��Center=�6`   $��0��6{   $��4��6�   $��5��6�   .��5�   &   �� $8��2Green - Normal | Yellow - Not Normal | Red - Empty��60   $
��Wrap=�6j   5�   #   5�      5�      5�      5�      5�      �� 5�      ��5�      �� 5�      $
��Bold"�6   .�6-   Month64   .��5�      �  5�      �� 5�      $
��auto �6(   68   �� 5�      6*    5�      �� 5�      6-   .+�5�      �� $��0��6   $��0��6/   ��5�      �� 5�      $
��Bold"�6#   .�65   Input6<   .��5�      �  5�      �� 5�   "   $
��auto �60   6@   �� 5�   "   62   �� 5�   "   62    5�      �� 5�   "   65   �� 5�   "   65   .+�5�      �� $��Select any day in Month��6$   $
��Bold"�6F   $
��Auto��6X   $
��Auto��6e   $��Center=�6s   $��Center=�6�   $��0��6�   $��2��6�   $��0��6�     5�      -'   5        $��MonthDatePicker��5�   )   $
��Auto��6@   $
��Auto��6M   $��Center=�6[   $��Center=�6x   $��0��6�   $��2��6�   $��1��6�   $ Short=�6�   �� 5�      -(   5        $��	Calculate��5�   %   $
��Auto��69   $
��Auto��6F   $��Center=�6T   $��Center=�6q   $��0��6�   $��2��6�   $��2��6�   6�   5�      5�      �� 5�      $��0��6   $��1��6/   ��5�      �� 5�      $
��Bold"�6#   .�65   Output6=   .��5�      �  5�      �� 5�   "   $
��auto �60   6@   �� 5�   "   62    5�      �� 5�   "   65   �� 5�   "   65   .+�5�      �� $��Table��6$   $
��Bold"�64   $
��Auto��6F   $
��Auto��6S   $��Center=�6a   $��Center=�6~   $��0��6�   $��0��6�   �� 5�      $��Chart��6$   $
��Bold"�64   $
��Auto��6F   $
��Auto��6S   $��Center=�6a   $��Center=�6~   $��1��6�   $��0��6�   &   System.Windows.Controls.DataGrid  5�      -)   5        $��MonthDataGrid��5�   '   $��0��6u   $��1��6�   ��6<   �� 6�   � 5�      $��1��6#   $��1��63    5�   "   �� 5�   &   $
��auto �64   6D   �� 5�   &   66    5�   "   �� 5�   &   69   �� 5�   &   69   �� 5�   &   69   .+�5�   "   �� $��Select parametr��6(   $
��Auto��6B   $
��Auto��6O   $��Center=�6]   $��Center=�6z   $��0��6�   $��0��6�   �� 5�   "   -*   5        $��ParamComboBox��5�   +   $
��Auto��6@   $
��Auto��6M   $��Center=�6[   $��Center=�6x   $��1��6�   $��0��6�   �� 5�   "   -+   5        $��Change��5�   )   $
��Auto��6:   $
��Auto��6G   $��Center=�6U   $��Center=�6r   $��2��6�   $��0��6�   6�     ScottPlot.WpfPlot  5�   "   -,   5        $��WpfPlot��5�   *   $��0��69   $��3��6I   $��1��6]   5�      5�      5�      5�      5�      5�      5�      5�      