   M S B A M L   `   `   `  ����E  ALibraryWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryWPF.ViewLibraryWPF.View  5   	        LibraryWPF.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:LibraryWPF.View     5   	     � Title$  Библиотека��5   	   $	��350��6   $	��813��6)    � 	Resources 5         FadeUIMessage �� 
TargetName �� TargetProperty W� From	 W� To g� Duration��%�   &	        �� 5   
   .��5      W� $ 	UIMessage��5	      $ (TextBlock.Opacity)�5
      $ 1X�5      $ 0X�6   $ 0:0:6D�6!   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   .+�5   
   �� $
��Left=�6   .@�5      �� $��Выбор таблицы��6   $��10(�6-   .��5      �� 
������ $��12(�6S   $
��Bold"�6a   ��.  ��6   �� *Views+	 � BindingGroup	 5      &   System.Windows.Data.BindingGroup  5      ��5      �� 5      .R�5       �� 
 �� Orientation$
 
Horizontal=�6)   6D   5!      ��5#      �� 5$      .R�5&      �� $��0q�5'   )   $��32��6=   $	��100��6I   ��5&   %   �� *
Navigate+.��5)   "   ��  �� TextAlignment$ Center=�5*   ,   ��5)   ,   �� *ViewDisplay+5*   ,   5-      5.      50      51      �� 52      $"��Редактирование��6   $��10(�6/   .��53      �� 
������ $��11(�6V   $
��Bold"�6d   ��.  ��6   �� *
Commands+��56      �� 57      .R�58      �� $
 
Horizontal=�6)   59      ��5;      �� 5<      .R�5>      �� $��1q�5?   )   $��0q�5@   )   $��0q�64   $��60��6@   $��30��6K   ��5>   %   �� *Send+.��5B   "   �� ��6,   �� *CommandDisplay+5C      5E      5G      5H      5I      �� 5J   
   -   5         ��Name$ 	UIMessage��5J      $�� ��6'   $��Right=�6/   $	��Top=�6K   $��0,0,8,0q�6c    � 5K   
   -   5          �Name$ 	EditFrame��5K      $��1��6#     � NavigationUIVisibility$ Hidden=�61   5L      5M      