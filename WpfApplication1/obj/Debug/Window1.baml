   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  Window1��5   	   $	��150��6   $	��300��6&    � 	Resources 5	          LinearGradientBlueBackground �� EndPoint �� 
StartPoint � Color � Offset  MyBtnBorderColor �� Color  MyBtnHoverBackgroundColor  MyWpfButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%T  &	        &	 �     &	 �     &	 �     7   7  7  �� 5   
   $ 0.5,1&�6C   $ 0.5,0&�6T   .��5      � $ 	LightBlue��6   $ 0Q�6-   � 5      $ 	#FF074CC0��6   $ 1Q�6-   5      �� 5   
   $ 	#FF2D78F4��63   6G   �� 5   
   $ 	#FF317EF3��6<   6P   �� 5   
   " ��6$   .�5      ��  � ��8	   6c   �� 5       � ��
	 �����6;   �� 5       � ��8	  6X   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . $ 3,3,3,3��5   <   ._�5      �� $ contentPresenter��6/   |�.  #��z��5   /   #��z��5   /   ��. # z 5!   /   #��z��5"   /   5#       5$      P� 5%       �@J�IsMouseOver . . �5&   "   �� $ border��6?   8	   � ��6S   5'      5)      5+      5,      5-      .��5.      �  +� FocusedElement 6   ��  �� ElementName$ Passwd_TextBox����5/   
   �� 50      $ 0.5, 0&�6"   $ 0.5, 1&�66   .��51      � $ White��6   $	 0.0Q�6-   � 52      $ LightSkyBlue��6   $ 1Q�64   53       � ColumnDefinitions 55   
   �� 56      $��* �6   �� 57      $��* �6   �� 58      $��* �6   .+�5:   
   G� -   5         G�Name$ Passwd_TextBox��5:      $��0��6O   $��2��6_   $	��150��6s   $��Center=�6   $��Center=�6�   �� 5;   
   -   5         ��Name$ Passwd_Button��5;      $��确认��6(   $��2��6Q   $��50��6a   $��20��6l   #��[ 6x   5<      5=      