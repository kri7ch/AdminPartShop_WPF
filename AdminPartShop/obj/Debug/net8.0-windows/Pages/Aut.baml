   M S B A M L   `   `   `  ����H  DAdminPartShop, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AdminPartShopAdminPartShop  5          AdminPartShop.Pages.Aut   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AdminPartShop     5        N� Title$	  Aut��5	      $	��700��6   $	��650��6   .��5      � .+�5   
   �� $��Center=�6   $	��650��61   $��Center=�6>   $	��700��6Y   ���	#FFF1F1F1 �� RadiusX$ 60��6v    �� RadiusY$ 60��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#      Opacity$ 15Q�63      	Direction$	 360Q�6@   6R   5      �� 5   
   $	��Top=�6   $
��Left=�6,   $��20(�6G   $��197,565,0,0q�6U   �� 5      -   5         �� TextDecorations$
 None{�5   0   ���	#FF696969.�6^   .�5      �� $C�=Нет аккаунта? Зарегистрироваться��6   5      5      �� 5   
   $��StarSet��6   $��Center=�6"   $��0,78,0,0q�6?   $	��Top=�6Q   
���   �$��66(�6|   $��Medium"�6�   $��Bahnschrift Light)�6�   �� 5   
   $��
Почта��6   $
��Left=�6    $��151,202,0,0q�6;   $	��Top=�6P   ���	#FF696969$��18(�6   $��Bahnschrift Light)�6�   �� 5   
   -   5         ��Name$ textbox_email��5   4      tb_style#��[  6   	 �� 	MaxLength$	 30��6K   $��Center=�6Z   $��	0,234,0,0q�6w   $��2, 10, 0, 0q�5      
 �� TextWrapping$
 NoWrap=�6(   $�� ��6>   $	��Top=�6F   $	��400��6^   
���   �
���   �$��22(�5   &   $��46��64    �� SelectionBrush �	#FFA5A5A5$��Bahnschrift Light)�6[   ��5   j   Z� 5   �   �� 5   
   $��Пароль��6   $
��Left=�6!   $��151,298,0,0q�6<   $	��Top=�6Q   ���	#FF696969$��18(�6�   $��Bahnschrift Light)�6�   G� 5!   
   -   5         G�Name$ textbox_password��5!        pb_style#��[ 60    G� 	MaxLength$ 30��6R   $��Center=�6a   $��	0,330,0,0q�6~   $	��Top=�6�   $	��398��5"      $��46��6"   
���   �
������ $��22(�5#   /   $��2,8,0,0q�6=   
���   � G� SelectionBrush �	#FFA5A5A5$��0q�6}   $��Bahnschrift Light)�6�   6�   �� 5%   
   -   5         ��Name$ 	btn_enter��5%   E     	btn_style#��[ 6   $��
Войти��65   $��Center=�6X   $��	0,484,0,0q�6u    � Cursor$
 Hand��6�   $	��Top=�5&      $��76��6)   $	��256��65   
���   �
�������$��24(�6h   $��Medium"�6v   $��Bahnschrift Light)�6�   �� 5)   
   -   5         ��Name$ checkbox_password��5)      $#��Показать пароль��6.   $
��Left=�6H   $��406,383,0,0q�6c   $	��Top=�6x   ���	#FF696969$��Bahnschrift Light)�5*   v   $��16(�6�   �� 5,   
   -   5        $ textbox_show_password��5-   >   #��[  5,      $��0,4,3,3q�64   $��Center=�5-      $	 25��6/   $��2,2,2,2q�6]   $��46��6w   $

 Wrap=�5.      $�� ��6&   $	��Top=�6.   $	��398��6F   $��22(�6R   $��	0,330,0,0q�6`    �	#FFA5A5A5
���   �
���   �$y�Hidden=�5/   j   ��6@   Z� 6j   �� 51   
   $��Bottom=�6   $
��Left=�6/   $��16(�6J   $��438,0,0,225q�6X   
���iii�$��Bahnschrift Light)�6�   �� 52      -   5         ��Name$ passwordRecovery��52   /   $
 None{�6   ���	#FF696969.�6   .�53      �� $�Забыли пароль��6   54      55      �� 57   
   -   5         ��Name$ lb_quantity��57      $�� ��6%   $
��Left=�60   $��241,445,0,0q�6K   $	��Top=�6`   $	��230��6x   
���iii�$��Bahnschrift Light)�6�   $��20(�6�   $y�Hidden=�6�   ��6�   Z� 6�   58      59      