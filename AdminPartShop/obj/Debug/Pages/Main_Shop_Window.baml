   M S B A M L   `   `   `  ����H  DAdminPartShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AdminPartShopAdminPartShop  5      *    $AdminPartShop.Pages.Main_Shop_Window   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AdminPartShop     5        N� Title$  Главное меню��5	      $	��900��6   $
��1550��6)   .��5
      � .+�5   
   �� $��Center=�6   $
��1550��61   $	��900��6>   $��Center=�6K   ���	#FFF1F1F1 �� RadiusX$ 40��6w    �� RadiusY$ 40��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#      Opacity$ 15Q�63      	Direction$	 360Q�6@   6R   5      �� 5   
   $)��#Добавление товаров��6   $
��Left=�6-   $��	90,55,0,0q�6H   $	��Top=�6[   
���   �$��54(�6�   $��Medium"�6�   $��Bahnschrift Light)�6�   �� 5   
   -   5         ��Name$ list_view_products��5      $��90,255,295,25q�6/   $��Disabled=�5      $��Hidden=�5      $��Center=�5      ��67   Z� ��6M   Z� ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    $��Center=�69   5      5      �� 5   
   $��Bottom=�6   $
��Left=�6/   $��36(�6J   $��1182,0,0,781q�6X   
���   �$��Bahnschrift Light)�6�   �� 5      -   5        	 �� TextDecorations$
	 None{�5   8   
���   �.�6b   .�5       �� $!�Личный кабинет��6   5!      6   �� 5#   
   -   5        
 ��Name$
 btn_add_product��5$         style_for_btn_buy#��[  5#      $��Добавить��6<   
���   �$��24(�5%   !   $��Medium"�6/   
�������
���   � � Cursor$
 Hand��5'      $��1280,815,23,25q�6   63   �� 5)   
   -   5         ��Name$ categoryComboBox��5)      $
��Left=�6-   $��
81,175,0,0q�6H   $��10, 16, 0, 0q�6\   $	��Top=�5*      $	��275��6#   $��55��6/   $��Bahnschrift Light)�6p   $��24(�6�   .@�5+      �� $��Все��6   
 � Tag$ 0��6)   �� 5,      $��Ввод��6   $ 1��6*   �� 5-      $��
Вывод��6   $ 2��6+   5.      �� 50   
   -   5        $ priceFilterComboBox��50      $
��Left=�60   $��1060,175,0,0q�6K   $��10, 16, 0, 0q�6a   $	��Top=�51      $	��275��6#   $��55��6/   $��Bahnschrift Light)�6s   $��24(�6�   .@�52      �� $��Все��6   $ 0��6)   �� 53      $!��По возрастанию��6   $ 1��64   �� 54      $��По убыванию��6   $ 2��61   �� 55      $"��Рейтинг от 1 до 5��6   $ 3��67   �� 56      $"��Рейтинг от 5 до 1��6   $ 4��67   57      �� 59   
   -   5         ��Name$ searchTextBox��59      $��55��6)     tb_style#��[ 65   $��380,175,515,0q�5:   
   $	��Top=�6!   $��5, 13, 0, 0q�69    �� TextWrapping$ NoWrap=�6O   $��Bahnschrift Light)�5;   2   $��24(�6Q   �� 5=   
   -   5         ��Name$ tovar_ne_naiden��5=      $(��"Товаров не найдено��6)   $
��Left=�6F   $��462,536,0,0q�6a   $	��Top=�5>      $��58��6(   $	��420��64   $��Bahnschrift Light)�6@   $��44(�5?      
���iii�$y�Hidden=�63   5@      5A      