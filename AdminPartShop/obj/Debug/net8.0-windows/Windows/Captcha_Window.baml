   M S B A M L   `   `   `  ����J  FEasyCaptcha.Wpf, Version=0.9.0.3, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:EasyCaptcha.Wpf;assembly=EasyCaptcha.WpfEasyCaptcha.Wpf  5       AdminPartShop*   $AdminPartShop.Windows.Captcha_Window   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Geasy6clr-namespace:EasyCaptcha.Wpf;assembly=EasyCaptcha.Wpf     5        � Title$  
Капча��5      $	��600��6   $	��400��6     � WindowStartupLocation$ CenterScreen=�6,    � 
ResizeMode$ NoResize=�6Q   .��5	      � .+�5
   
   �� $��Center=�6   $	��600��61   $��Center=�6>   $	��400��6Y   ���	#FFF1F1F16e      EasyCaptcha.Wpf.Captcha  5   
   -   5          Name$ 	MyCaptcha��5      $	��330��6*   $	��130��67   $��22(�6D   $��Bahnschrift Light)�6R   $��35,239,35,215q�6q   �� 5   
   $��
Капча��6   $��Center=�6    $��0,46,0,0q�6=   $	��Top=�6O   
���   �$��36(�5      $��Bahnschrift Light)�6-   $
��Bold"�6L   $	��110��6^   �� 5   
   -   5         ��Name$ textbox_captcha��5   4      tb_style#��[  6   $��Center=�6M   $��	0,169,0,0q�6j   $��
2, 5, 0, 0q�5   
    �� TextWrapping$ NoWrap=�6   $�� ��65   $	��Top=�6=   $	��260��6U    �� 	MaxLength$ 5��6w   
���   �
���   �$��22(�5      $��40��6,    �� SelectionBrush �	#FFA5A5A5$��Bahnschrift Light)�6S   ��5   a   Z� 5   r   �� 5   
   -   5         ��Name$ 	btn_enter��5   M     style_for_btn_buy#��[ 6   $��
Войти��6=   $��Center=�6`   $��	0,410,0,0q�6}   	 � Cursor$
	 Hand��6�   $	��Top=�5   	   $��45��6!   $	��330��6-   
���   ����	#FFF1F1F1$��24(�6d   $��Medium"�6r   $��Bahnschrift Light)�6�   6�   �� 5   
   $��Введите капчу��6   $
��Left=�6(   $��
61,142,0,0q�6C   $	��Top=�6W   ���	#FF696969$��16(�6�   $��Bahnschrift Light)�6�   $��30��6�   �� 5   
   $��Bottom=�6   $
��Left=�6/   $��18(�6J   $��
170,0,0,84q�6X   
���iii�$��Bahnschrift Light)�6�   �� 6�   -   5        
 �� TextDecorations$

 None{�5   �   ���	#FF696969.�6�   �� $-�'Сгенерировать заново��6�   6  6(  �� 5   
   -   5         ��Name$ lb_quantity��5      $�� ��6%   $��Center=�60   $��	0,515,0,0q�6M   $	��Top=�6`   $	��230��6x   
���iii�$��Bahnschrift Light)�6�   $��20(�6�   $y�Hidden=�6�   ��6�   Z� 6�   5!      5"      