   M S B A M L   `   `   `  ����F  BTaskForExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskForExamTaskForExam  5          TaskForExam.PersTeacher   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:TaskForExam     5        N� Title$3  -Контакты преподавателей��5	       N� FontSize$ 15(�6'    N� 
FontFamily$ Times New Roman)�65   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tablePersTeacher��5      $
��Left=�6-   $	��510��6H   $��	24,27,0,0q�6U   $	��Top=�6h   $	��900��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6i      CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 surname�
   ClipboardContentBinding
 6F   Z� 6�     5      $ Имя��6f    .  $	 100 6�    6%   �� $
	 name�
 6C   Z� 6�     5      $ Отчество��6m    .  $	 100 6�    6%   �� $	 middle_name�
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
��Left=�6   $��22��6*   $	��Top=�66   $��Times New Roman)�6N   $	��774��6k   .@�5      m� $��Файл��6   .@�5      m� -   5        $/��)Сохранить таблицу в Exel��5      6V   5      m� 5      $3��-Показать преподавателей��6   $��22��68   .@�5       m� -   5        $��Всех��5       6D   m� 5!      -   5         m�Name$ t1��5!      $��Профессоры��6'   6N   m� 5"      -   5        $ t2��5"      $��Доценты��6'   6K   m� 5#      -   5        $ t3��5#      $8��2Старшие научные сотрудники��6'   6^   m� 5$      -   5        $ t4��5$      $8��2Младшие научные сотрудники��6'   6^   m� 5%      -   5        $ t5��5%      $��Ассистенты��6'   6N   5&      5'      5(      5)      