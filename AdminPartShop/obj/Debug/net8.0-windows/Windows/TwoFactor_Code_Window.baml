   M S B A M L   `   `   `  ����H  DAdminPartShop, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AdminPartShopAdminPartShop  5   	   1    +AdminPartShop.Windows.TwoFactor_Code_Window   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AdminPartShop     5   	     � Title$=  7Двухфакторная аутентификация��5   	   $	��450��6.   $	��400��6;    � WindowStartupLocation$ CenterScreen=�6G    � 
ResizeMode$ NoResize=�6l   .��5	      � .+�5
   
   �� $��Center=�6   $	��450��61   $��Center=�6>   $	��400��6Y   ���	#FFF1F1F16e   �� 5   
   $=��7Двухфакторная аутентификация��6   $��Center=�68    �� TextAlignment$ Center=�6U   $
��Wrap=�6l   $��0,46,0,0q�6�   $	��Top=�6�   
���   �$��28(�5       $��Bahnschrift Light)�6.   $
��Bold"�6M   $	��240��6_   $��78��6k   �� 5   
   -   5         ��Name$ textbox_code��5   4      tb_style#��[  6   $��Center=�6J   $��	0,169,0,0q�6g   $��
2, 5, 0, 0q�5       �� TextWrapping$ NoWrap=�6"   $�� ��68   $	��Top=�6@   $	��260��6X    �� 	MaxLength$ 5��6z   
���   �
���   �$��22(�5   !   $��40��6/    �� SelectionBrush �	#FFA5A5A5$��Bahnschrift Light)�6V   ��5   d   Z� 5   u   �� 5   
   -   5         ��Name$ 	btn_enter��5   M     style_for_btn_buy#��[ 6   $��
Войти��6=   $��Center=�6`   $��	0,289,0,0q�6}   	 � Cursor$
	 Hand��6�   $	��Top=�5      $��45��6%   $	��180��61   
���   ����	#FFF1F1F1$��24(�6h   $��Medium"�6v   $��Bahnschrift Light)�6�   6�   �� 5   
   $��Введите код��6   $
��Left=�6&   $��
61,142,0,0q�6A   $	��Top=�6U   ���	#FF696969$��16(�6�   $��Bahnschrift Light)�6�   $��30��6�   �� 5   
   $	��Top=�6   $��Center=�6,   $��16(�6I   $��	0,350,0,0q�6W   
���iii�$��Bahnschrift Light)�6   �� 5      -   5        
 �� TextDecorations$

 None{�5      ���	#FF696969.�6Y   .�5      �� $#�Вернуться назад��6   5      5      5      5      