   M S B A M L   `   `   `  ����C  ?Stolovai, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Stolovai.WindowsStolovai.Windows  5   	   "    Stolovai.Windows.OknoSchools   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Stolovai.Windows     5   	     � Title$  
Школы��5   	   $	��300��6   $	��500��6$   $	��300��60   $	��500��6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ ListSchools��5      ��5      �� 5      .R�5      �� .+�5      �� $��17(�6:   ��6$   �� *Name+6J   �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��SetBtn��68   -   5        $��Изменить��5   (   $��15(�6F   
����  �$
��10,0q�6   6�   �� 5      $��DelBtn��67   -   5        $��Удалить��5   (   $��15(�6E   
���  ��6   5      5      5      5      �� 5   
   $��1��6   $��Center=�6%   $��Center=�6B   $	��200��6]   .+�5      �� $!��Название школы��6   $��17(�6.   6>   �� 5      $��17(�6,   ��6   �� *Name+6<   �� 5      $��Пароль��6   $��17(�6&   66   �� 5      $��17(�60   ��6   �� *
Password+6@   �� 5       -   5        $��SetText��5    h   $��*новая школа��6   $��13(�6,   
�������$��Right=�6L   6y   �� 5!      -   5         ��Name$ SaveBtn��5!      $��Сохранить��6&   $��17(�6P   
�������6s   5"      5#      5$      