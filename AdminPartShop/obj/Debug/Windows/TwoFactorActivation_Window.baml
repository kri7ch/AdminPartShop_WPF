   M S B A M L   `   `   `  ����H  DAdminPartShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AdminPartShopAdminPartShop  5   	   6    0AdminPartShop.Windows.TwoFactorActivation_Window   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AdminPartShop     5   	     � Title$P  JАктивация двухфакторной аутентификация��5   	   $	��500��68   $	��500��6E    � WindowStartupLocation$ CenterScreen=�6Q    � 
ResizeMode$ NoResize=�6v   .��5	      � ���	#FFF1F1F1.+�5   
   �� -   5         ��Name$ textbox_code��5   4      tb_style#��[  6   $��Center=�6J   $��2, 12, 0, 0q�5       �� TextWrapping$ NoWrap=�6'   $�� ��6=   $	��Top=�6E   $	��330��6]    �� 	MaxLength$ 4��6   
���   �
���   �$��22(�5   %   $��56��63    �� SelectionBrush �	#FFA5A5A5$��Bahnschrift Light)�6Z   $��	0,175,0,0q�6�   ��5   i   Z� 5   �   �� 5   
   -   5         ��Name$ 	btn_enter��5   P     style_for_btn_buy#��[ 6   $��Добавить��6=   $��Center=�6c   $��	0,355,0,0q�6�    � Cursor$
 Hand��6�   $	��Top=�5      $��55��6(   $	��230��64   
���   ����	#FFF1F1F1$��24(�6k   $��Medium"�5      $��Bahnschrift Light)�6$   6C   �� 5   
   $��Введите код��6   $
��Left=�6&   $��
85,150,0,0q�6A   $	��Top=�6U   ���	#FF696969$��16(�5   '   $��Bahnschrift Light)�65   $��30��6T   �� 5   
   $��Код с почты��6   $��Center=�6&   $��0,55,0,0q�6C   $	��Top=�6U   
���   �$��36(�5      $��Bahnschrift Light)�6*   $	��220��6I   �� 5   
   $	��Top=�6   $��Center=�6,   $��16(�6I   $��	0,415,0,0q�6W   
���iii�$��Bahnschrift Light)�6   �� 5      -   5        	 ��Name$	 changedMyMind��5   /   
 �� TextDecorations$

 None{�6   ���	#FF696969.�6y   .�5      �� $K�EНе хочу двухфакторную аутентификация��6   5      5      5      5       