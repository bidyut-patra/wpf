   M S B A M L   `   `   `  ����B  >Student, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:StudentStudent  5   	        Student.StudentInformation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Student     5   	   $
��Auto��5   	   $
��Auto��6   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��0.5* �6   6.   �� 5      $
��0.5* �6   6.    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��2��6"   $��5q�66   .+�5      �� $��0��6   $��0��6!   $
��Name��61   �� 5      $��1��6   $��30��6E    �� 
IsEditable .  w� TextPath$
 Name��5   =   ��5   '   �� *Items+ �� SelectedItem 5      �� *SelectedItem+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��10q�6>   ��6(   �� *Name+6>   �� 5      $
��Bold"�6>   $��10q�6P   ��6(   �� *Dept+6P   5      5      5       5!      �� 5"   
   $��1��6   $��2��6"   $��5q�66   .+�5#      �� $��1��6   $��0��6!   $��
Department��61   �� 5$      $��1��6   $��30��6K   {�.  ��6(   �� *SelectedItem.Dept+6W   5%      5&      5'      