   M S B A M L   `   `   `  ����F  BTaskForExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskForExamTaskForExam  5          TaskForExam.Student   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:TaskForExam     5        N� Title$  Студенты��5	       N� 
FontFamily$ Times New Roman)�6    N� FontSize$ 15(�65   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tableStudent��5      $
��Left=�6)   $	��510��6D   $��	24,27,0,0q�6Q   $	��Top=�6d   $��15(�6|   $��Times New Roman)�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6i      CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 surname�
   ClipboardContentBinding
 6F   Z� 6�     5      $ Имя��6f    .  $	 100 6�    6%   �� $
	 name�
 6C   Z� 6�     5      $ Отчество��6m    .  $	 130 6�    6%   �� $	 middle_name�
 6J   Z� 6�     5      $ Группа��6g    .  $ 60 6�    6%   �� $	 group�
 6D   Z� 6�     5      $# Год поступления��6f    .  $	 120 6�    6%   �� $
	 year�
 6C   Z� 6�   5      o� 5   
   $
��Left=�6   $��22��6*   $	��Top=�66   $��Times New Roman)�6N   $	��774��6k   .@�5      m� $��Файл��6   .@�5      m� -   5        $/��)Сохранить таблицу в Exel��5      6V   5      m� 5      -   5        $2��,Показать всех студентов��5      $��22��68   6D   m� 5      -   5        $'��!Добавить студента��5      $��22��62   6>   5      �� 5   
   $1��+Показать список группы:��6   $
��Left=�62   $��
628,27,0,0q�6M   $	��Top=�6a   �� 5   
   $��Номер:��6   $
��Left=�6!   $��
608,59,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $��Показать��5      
������ 
������$
��Left=�6W   $	��Top=�6r   $��84��6�   $��685,104,0,0q�6�   $��26��6�   �� 5   
   -   5         ��Name$ group��5      $
��Left=�6"   $��
685,63,0,0q�6=   $	��Top=�6Q   $	��120��6i   6u   �� 5    
   -   5         ��Name$ a1��5       $��!��6   $y�Hidden=�6(   $��25(�6<   
���**��$
��Left=�6]   $��
805,54,0,0q�6x   $	��Top=�6�   �� 5!   
   -   5        $ p��5!      $y�Hidden=�6   $)��#*заполните все поля��6/   
���**��$
��Left=�6`   $��764,104,0,0q�6{   $	��Top=�6�   5"      5#      