   M S B A M L   `   `   `  ����  HotelClient    HotelClient.GuestWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  GuestWindow��5   	   $	��300��6   $	��300��6*   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��Right=�6   $��0, 5, 20, 10q�5      $��Center=�6!   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ buttonCreateGuest��5      $��Create Guest��5      ��5      �� *
AddStudent+5      �� 5      -   5        $ buttonDeleteGuest��5      $��	10,0,10,0q�64   $��Delete Guest��5      ��5      �� *
AddStudent+5      �� 5      -   5        $ buttonUpdateGuest��5      $��Create Guest��5      ��5      �� *
AddStudent+5      5      5      �� 5   
   $��2��6   
�������$��Stretch=�5      ��5      ��  �� Path$ Students� �� View 5       �� 5!      .P�5"      �� $��Id��6%    �� DisplayMemberBinding 5#   %   �� $
 Name��� 5$      $��	GuestName��6%    5%   %   �� $
 Name��� 5&      $��GuestAge��6%    5'   %   �� $ Score�5)      5+      5,      5-      