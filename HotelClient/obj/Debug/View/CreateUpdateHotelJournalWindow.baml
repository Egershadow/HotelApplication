   M S B A M L   `   `   `  ����  HotelClient5    /HotelClient.View.CreateUpdateHotelJournalWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��197��5   0   $	��300��6=     � Title  6	   �� *CreateOrUpdateEntity+.��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5	      $��30 �6   �� 5
      $��42 �6    � ColumnDefinitions 5   
   �� 5      $
��122* �6   �� 5      $
��296* �6   .+�5   
   �� -   5        $��label1��5      $��Id��5      $��2��6   $��28��6.   $
��Left=�6:   $	��Top=�5      �� 5   
   -   5        $��label2��5   #   $
��Room��5      $��1��6   $��2��6,   $��28��6=   $
��Left=�5      $	��Top=�5      �� 5   
   -   5        $��label3��5      $��Guest��5      $��2��6    $��2��6-   $��28��6>   $
��Left=�5      $	��Top=�5      �� 5   
   -   5        $��	IdTextBox��5      $��1��5      $��2��6"   $��23��63   $
��Left=�6?   $��20,5,0,0q�5      $	��Top=�6+   $	��120��5      {�.  ��6   ��  �� Path$ 	Entity.Id� �� Mode$ TwoWay=�6A   �� 5   
   $��1��6   $��1��6#   $��	20,5,40,5q�60    �� SelectedItem 6C   �� $ SelectedRoom�$ TwoWay=���6{   �� $ Rooms��� 5   
   $��1��6   $��2��6#   $��	20,5,40,5q�60    6C   �� $ SelectedGuest�$ TwoWay=���6|   �� $ Guests��� 5"   
   -   5        $$��createUpdateHotelJournalButton��5#   6   $��1��5"   0   $��4��6@   $��23��6M   $
��Left=�5#      $��	20,10,0,0q�6#   $	��Top=�5$      $��75��6    ��5"      �� *
ButtonName+��5$   +   �� *CreateOrUpdateEntity+5%      5&      