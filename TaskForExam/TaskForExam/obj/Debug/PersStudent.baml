   M S B A M L   `   `   `  ����F  BTaskForExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskForExamTaskForExam  5          TaskForExam.PersStudent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:TaskForExam     5        N� Title$)  #Контакты студентов��5	       N� FontSize$ 15(�6#    N� 
FontFamily$ Times New Roman)�61   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tablePersStudent��5      $
��Left=�6-   $	��510��6H   $��	24,27,0,0q�6U   $	��Top=�6h   $	��722��6�   $��15(�6�   $��Times New Roman)�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6i      CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 surname�
   ClipboardContentBinding
 6F   Z� 6�     5      $ Имя��6f    .  $	 100 6�    6%   �� $
	 name�
 6C   Z� 6�     5      $ Отчество��6m    .  $	 130 6�    6%   �� $	 middle_name�
 6J   Z� 6�     5      $! Серия паспорта��6h    .  $	 110 6�    6%   �� $	 series�
 6E   Z� 6�     5      $! Номер паспорта��6h    .  $	 120 6�    6%   �� $	 number�
 6E   Z� 6�     5      $ Пол��6e    .  $ 80 6�    6%   �� $		 sex�
 6B   Z� 6�     5      $ 
Город��6f    .  $	 100 6�    6%   �� $
	 city�
 6C   Z� 6�     5      $ 
Улица��6h    .  $	 100 6�    6%   �� $	 street�
 6E   Z� 6�     5      $ Дом��6i    .  $ 60 6�    6%   �� $	 numberH�
 6F   Z� 6�     5      $ Кварира��6f    .  $ 70 6�    6%   �� $
	 flat�
 6C   Z� 6�     5      $! Номер телефона��6n    .  $	 115 6�    6%   �� $	 phone_number�
 6K   Z� 6�   5      o� 5   
   $
��Left=�6   $��22��6*   $	��Top=�66   $��Times New Roman)�6N   $	��774��6k   .@�5      m� $��Файл��6   $��22��6%   .@�5      m� -   5        $/��)Сохранить таблицу в Exel��5      6V   5      m� 5      -   5        $��Показать все��5      $��22��6-   69   5       �� 5!   
   $1��+Показать список группы:��6   $
��Left=�62   $��
751,27,0,0q�6M   $	��Top=�6a   �� 5"   
   $��Номер:��6   $
��Left=�6!   $��
756,55,0,0q�6<   $	��Top=�6P    J� RenderTransformOrigin$ 0.286,-0.728&�6h   �� 5#   
   -   5        $��Показать��5#      
������ 
������$
��Left=�6W   $	��Top=�6r   $��75��6�   $��
800,95,0,0q�6�   6�   �� 5$   
   -   5         ��Name$ group��5$      $
��Left=�6"   $��
817,59,0,0q�6=   $	��Top=�6Q   $��83��6i   6t   �� 5%   
   -   5         ��Name$ a1��5%      $��!��6   $y�Hidden=�6(   $��25(�6<   
���**��$
��Left=�6]   $��
900,50,0,0q�6x   $	��Top=�6�   �� 5&   
   -   5        $ p��5&      $y�Hidden=�6   $)��#*заполните все поля��60   
���**��$
��Left=�6a   $��770,108,0,0q�6|   $	��Top=�6�   5'      5(      