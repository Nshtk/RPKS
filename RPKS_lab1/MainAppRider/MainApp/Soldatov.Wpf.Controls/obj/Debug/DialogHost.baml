   M S B A M L   `   `   `  ����P  LSoldatov.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Soldatov.Wpf.ControlsSoldatov.Wpf.Controls  5      L HSoldatov.Wpf.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:Soldatov.Wpf.MVVM;assembly=Soldatov.Wpf.MVVMSoldatov.Wpf.MVVM 5      &     Soldatov.Wpf.Controls.DialogHost   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8controls#clr-namespace:Soldatov.Wpf.Controls     5      Kmvvm:clr-namespace:Soldatov.Wpf.MVVM;assembly=Soldatov.Wpf.MVVM     5        � 	Resources  5
      &   Soldatov.Wpf.MVVM.RoundConverter  5   
      KeyRoundConverter  6   .��5      � y�6   �� *DialogVisibility+ � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5      .+�5   
   �� 
���   �$��3��6�   $��3��6�    J� Opacity 6"   �� *Transparency+ �� RelativeSource ��  �� AncestorType$ controls:DialogHostL� J� InputBindings 5      d� 5       d� MouseAction$ 	LeftClicke�6    �� Command 67   �� *CmdBackground+5      �� 5   
   $��1��6   $��1��6!   $��1q�6.   
���   �
�������	 �� CornerRadius	 6B   �� *
Rounding+ �� $ controls:DialogHostL�  RoundConverter
 �� 	Converter#
 [  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 50Q�6#      Opacity$	 0.2Q�63   ._�5"      �� ��6   �� *HostContent+5#      5$      5&      