   M S B A M L   `   `   `  ����C  ?SlapJack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SlapJackSlapJack  5   	       SlapJack.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SlapJack     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   ��5	      �� 5
   
    �� ImageSource$ image/background.jpg��6   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ btnMainButton��5      $��START��6(   $
��Left=�68   $��627,365,0,0q�6S   $	��Top=�6h   $��75��6�   $��20��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ 	CardImage��5      $
��Left=�6#   $	��238��6>   $��
308,84,0,0q�6K   $	��Top=�6_   $	��156��6w   �� 5   
   -   5         ��Name$ lblNumberOfCardsInPile��5      $�� ��60   $
��Left=�6;   $��491,264,0,0q�6V   $	��Top=�6k   
���������5      �� 5       �� Color# � ��6"    5        5      5      �� 5   
   -   5        $ lblPlayerCards��5      $�� ��6(   $
��Left=�63   $��479,367,0,0q�6N   $	��Top=�6c   
������� 5         5!      ��5#      �� 5$      # � ��6"   5&      �� 5'   
   -   5        $ lblComputerCards��5'      $�� ��6*   $
��Left=�65   $��175,359,0,0q�6P   $	��Top=�6e   
������� 5(        5)      ��5+      �� 5,      # � ��6"   5.      �� 5/   
   -   5        $ lblInstructions��5/      $>��8Hit the START button to deal cards and to start the game��6)   $
��Left=�6l   $��	45,26,0,0q�6�   $	��Top=�6�   
������� 50        51      ��53      �� 54      # � ��6"   56      �� 57   
   -   5        $ 	BackImage��57      $
��Left=�6#   $	��238��6>   $��308,327,0,-144.333q�6K   $	��Top=�6g   $	��156��6   �� 58   
   -	   5        $ lblGameOver��58      $�� ��6%   $
��Left=�60   $��249,177,0,0q�6K   $	��Top=�6`   $��35(�6x   $	��317��6�   
������� 59        5:      ��5<      �� 5=      # � ��6"   5?      �� 5@   
   -
   5        $ lblSlap��5@      $�� ��6!   $
��Left=�6,   $��249,177,0,0q�6G   $	��Top=�6\   $��35(�6t   $	��317��6�   
���������5A      �� 5B      # � ��6"    5D        5E      5G      5J      5K      