   M S B A M L   `   `   `  ����A  =Fiszka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FiszkaFiszka  5   	       Fiszka.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &localclr-namespace:Fiszka     5   	     � Title$  Fiszka��5   	   $��540.111��6   $��845.222��6)    � 	Resources 5         	BoolToVis&    Fiszka.NullToVisibilityConverter  	NullToVis'   !Fiszka.DictionaryToResponseNumber  
DictToResp)   #Fiszka.DictionaryToSuccesssesNumber  DictToSuccResp��%t   &	        &	      &	 &     &	 9     �� 5   
   6'     5	   
   6>     5
   
   6@     5   
   6F   5       � DataContext 5          Fiszka.MainWindowViewModel  5   
   .��5      ]� ��. .+�5   
   � $��Right=�6   $��10                q�6&   .+�5      ��  �� Orientation$ Vertical=�6   $	��400��60   y�6?   ��  �� Path$ SelectedDictionary� �� 	Converter# [ .+�5      �� $ 
Horizontal=�6   .+�5      �� $��16(�6I   ���	#FF681B5A��6   �� *SelectedDictionary.Title+6W   �� 5      $��20,0,0,0q�6@   ��6   �� *AddWordCommand+.��6R   Add new word6`   �� 5      $��20,0,0,0q�6F   ��6   �� *StartLearningCommand+.��6X   Start Learning6h   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Words: ��6   �� 5      ��6   �� * SelectedDictionary.Words.Count+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��All responses: ��6   �� 5      ��6   �� *SelectedDictionary.Words+# [ 5       �� 5!      $ 
Horizontal=�6   .+�5"      �� $��Success responses: ��6   �� 5#      ��6   �� *SelectedDictionary.Words+# [ 5$      �� 5%      -   5        $��listBox_words��5%      $��0,10,0,0q�6�   $	��330��6�   ��6/   �� *SelectedDictionary.Words+ �� SelectedItem 6`   �� *SelectedWord+
 � Tag 6�   �� ��5'      �� 5(      .R�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� $	��100��6H   ��6,   �� *
OriginWord+6Y   �� 5,   "   $
��Wrap=�6I   $	��190��6]   $��0,0,5,0q�6i   ��6,   �� *Translation+6i   �� 5.   "   $
��Wrap=�6G   $��25��6[   ���	#FF066330��6,   �� *	Successes+6f   �� 5/   "   $
��Wrap=�6D   $��25��6X   
���  ����6,   �� *Losses+6c   51      52      54      �� 55      $��	50,0,50,0q�6?   ��6   �� *DeleteWordCommand+y�6R   �� $ SelectedWord�# [ .��6�   Delete word6�   57      58      �� 59   
   $	��Top=�6   $ 
Horizontal=�6*   .+�5<      ��  �� DisplayMemberPath$
 Name��6g   	 �� SelectedValuePath$
	 Name��6�   $	��150��6�   ��6   �� *Users+ 65   �� *SelectedUser+
 �� Mode$
 TwoWay=�5>      �� 5?      ��6   �� *AddUserCommand+.��68   
Add user5A      5B      �� 5C   
   $	��Top=�6   $ 
Horizontal=�6*   $��0,10,0,0q�6C   .+�5D      �� .��6   Dictionaries:6$   5E      �� 5F   
   $��Bottom=�6   $ 
Horizontal=�6-   .+�5G      �� $��0,0,20,0q�6?   ��6   �� *EditDictionaryCommand+y�6Q   �� $ SelectedDictionary�# [ .��6�   	Edit name6�   �� 5H      $��0,0,20,0q�6A   ��6   �� *DeleteDictionaryCommand+y�6S   �� $ SelectedDictionary�# [ .��6�   Delete dict6�   �� 5I      .��6   New dictionary:6%   �� 5J      $	��100��6F    � ToolTip$&  Wpisz nazwę dla nowego slownika��6U   ��6   �� *NewDictionaryValue+$
 TwoWay=�6�   �� 5K      ��6   �� *AddDictionaryCommand+.��6>   Add6C   5M      �� 5N   
   -   5        $��listBox��5N       6!   �� *SelectedDictionary+$
 TwoWay=���6Z   �� *SelectedUser.Dictionaries+��5P      �� 5Q      .R�5R      �� $ 
Horizontal=�6!   .+�5S      �� $��30��6A   ��6    �� *DictionaryId+6Q   �� 5T      ��6    �� *Title+6<   5U      5V      5X      5Y      5Z      