   M S B A M L   `   `   `  ����a  ]GongSolutions.Wpf.DragDrop, Version=0.1.4.3, Culture=neutral, PublicKeyToken=d19974ea350ccea1kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop  5      J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5      =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model 5      '   !WpfApplication1.View.PlaylistMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      adragDropLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApplication1     5      5model#clr-namespace:WpfApplication1.Model     5      $
��auto��5	      $
��auto��6-   $��Center=�6:     K� ZIndex$  1��5
   8    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $c ]pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/PlayListMenuStyle.xaml?�6%   %    5      .��5      � -   5         �Name$ playlistDisplay��5      $��Stretch=�6$   $��Stretch=�6B   $
��auto��6^   $
��auto��6l   $��25,40,25,70q�6y   .+�5   
   �� -   5         ��Name$ TitlePlaylist��5      $��Center=�6+   $��0,0,0,0q�6H   $
��Wrap=�6Y   $��Gérer mes playlists��6m   $	��Top=�6�   $��25(�6�   
�������6�   �� 5   
   -   5         ��Name$ playlistName��5      $��30��6(   $	��200��64   $	��Top=�6@      placeHolder#��[  6X   
 � Tag$ Nom playlist��6}   $��
0,50,240,0q�6�   ��6�   �� *PlaylistName+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5   
   -   5        
 ��Name$
 createPlaylist��5      $��30��6)   $	��250��65   $��15(�6j   $	��Top=�6x   $��Center=�6�   $��
240,50,0,0q�6�   #��[" �6�   
����������#31A6D1��6B   �� *CreatePlaylistRelay+.��6$  Créer playlist64  � 5   
   -   5        $��mainGrid��5      $
��auto��6   $
��auto��6-   $��Stretch=�6:   $��180,100,180,5q�6X   .+�5      �� .+�5      �� $��MES PLAYLISTS��6   
�������$��20(�6B   �� 5      6   5      � 5      -   5        $��mainListGrid��5      $��
0,38,0,-38q�6'   $
��auto��6;    � ColumnDefinitions 5      �� 5       -   5         �Name$ 
myPlaylist��5    '   $��2* �69   6G   �� 5!      -   5        $ myList��5!   '   $��5* �65   6C    � RowDefinitions 5#      �� 5$      -	   5        $ myButtonsHere��5$   $   $
��0.4* �69   6I   �� 5%      -
   5        $ listHere��5%   $   $	��10* �64   6C   .+�5'      � $��2��6   $��2��6+   $
��auto��6<   $��Stretch=�6I   )   #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget .    DropHandler 5)   '   �� .+�5*      �� $��0��6   $��0��6-   $
��Left=�6:   $��	0,20,5,30q�6U    �� Orientation$ 
Horizontal=�6h   .+�5+      �� $
��auto��6'   $��Disabled=�65   $
��auto=�6^   .��5,      �� $��0,0,0,0q�6+   ��6<   �� *PlaylistList+��5-   "   �� 5.   &    �� DataType(  "WpfApplication1.Model.PlaylistItem"  63   .R�5/   *   �� 
������ $
��auto��6N   $��Stretch=�6[   $ 
Horizontal=�6w   .+�50   .   �� $��25��65   $��5,0,5,0q�6C   ��6T   �� *Id+��6t   �� *
DelCommand+��51   2   �� 52   6   .R�53   :   �� $��20��6@   $��20��6L   ��54   >   �� 55   B    �� 
TargetType" ��6H   .�56   F   ��  �� Property � �� �� Value$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png��6_   57   C   59   ;   5:   7   5<   /   �� 5=   .   $
 button��6�   ���#262626#��[" �6J   $��0q�6�   $��20��6�   $	��100��6�   $��5,0,5,0q�6�   
���������6�   �� *Name+��6�   �� *Id+��6  �� *	Command+6=  5>   +   5?   '   5A      5B      �� 5C      $��0��6I   $��0��6Y     VerticalSeparatorStyle#���  6g   y�6$   �� *AddVisibility+6g   5D      � 5F      $��1��6   $��1��6'   $
��auto��64   $��Stretch=�6A   $��
180,0,20,0q�6_   .+�5G      �� $��1��6!   $��1��61   $
��Left=�6>   $ 
Horizontal=�6Y   .+�5H      �� $	��150��6!   $��30��6-   $��
0,10,25,10q�69   $	��Top=�6M   $
��Left=�6e   #��[" �6�   
����������#31A6D1y�6�   �� *AddVisibility+��6�   �� *AddMediaRelay+.��6*  + Ajouter média6;  �� 5I      $	��150��6%   $��30��61   $��
0,10,25,10q�6=   $	��Top=�6Q   $
��Left=�6i   #��[" �6�   
����������#31A6D1y�6�   �� *AddVisibility+��6�   �� *ReadPlayListRelay+.��62  Lire playlist6A  �� 5J      $	��150��6&   $��30��62   $��
0,10,25,10q�6>   $	��Top=�6R   $
��Left=�6j   #��[  6�   $ 
Rechercher��6�   y�6�   �� *AddVisibility+��6�   �� *
SearchText+$ TwoWay=�$	 PropertyChanged=�5K      � 5L      $��1��6   $��1��6/   $
��auto��6<   $��Stretch=�6I   $��	0,40,0,60q�6g    5M      �� 5N   "   $��1* �63   6A   �� 5O   "   $��2* �63   6A   �� 5P   "   $��1* �63   6A   �� 5Q   "   $��1* �63   6A   �� 5R   "   $��1* �63   6A    5T      �� 5U   "   63   .+�5W      �� $��1��6%   $��0��65   $��TITRE��6B   $	��Top=�6R   $
��Left=�6j     NoBorderBlueHover#��[ 6�   $��15(�6�   y�6�   �� *AddVisibility+��6�   �� *SortTitleRelay+�� 5X      $��2��6%   $��0��65   $��ARTISTE��6B   $	��Top=�6T   $
��Left=�6l   #��[ 6�   $��15(�6�   y�6�   �� *AddVisibility+��6�   �� *SortArtistRelay+�� 5Y      $��3��6%   $��0��65   $��ALBUM��6B   $	��Top=�6S   $
��Left=�6k   #��[ 6�   $��15(�6�   y�6�   �� *AddVisibility+��6�   �� *SortAlbumRelay+�� 5Z      $��4��6$   $��0��64   $��DURÉE��6A   $	��Top=�6Q   $
��Left=�6i   
�������$��15(�6�   y�6�   �� *AddVisibility+5[      �� 5\      $
��0,75q�6(   $��1��66   $��1��6F   $��Stretch=�6T   $
��auto��6p   $
��auto��6~   $��Disabled=�6�   $
��auto=�6�   .��5]      �� ��6+   �� *LibraryList+��5^   "   �� 5_   &   '  !WpfApplication1.Model.LibraryItem"  63   .R�5`   *   � $��1��60   $��1��6@   $
��auto��6M   $��Stretch=�6Z   $��0,0,0,0q�6w    5a   .   �� 5b   2   $��1* �6C   6P   �� 5c   2   $��2* �6C   6Q   �� 5d   2   $��1* �6C   6Q   �� 5e   2   $��1* �6C   6Q   �� 5f   2   $��1* �6C   6Q    5h   .   �� 5i   2   6C   .+�5k   .   �� $��0��65   $��0��6E   $��25��6R   $��0,0,5,0q�6`   $
��Left=�6q   ��6�   �� *Id+��6�   �� *
DelCommand+��5l   2   �� 5m   6   .R�5n   :   �� $��20��6@   $��20��6L   ��5o   >   �� 5p   B   " ��6H   .�5q   F   ��  � ��$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png��6_   5r   C   5t   ;   5u   7   5w   /   �� 5x   .   $��0��65   $��0��6E   ���#262626
�������$��0q�6z   $��20��6�   $��20��6�   $
��Left=�6�   $��25,0,0,0q�6�   ��6�   �� *Name+��6�   �� *	LibItem+��6  �� *	Command+��5y   2   �� 5z   6   .R�5{   :   �� $��20��6@   $��20��6L   ��5|   >   �� 5}   B   " ��6H    �� Triggers 5~   F   �� 5   J    �� Binding 6V   �� *	Playing+ �� Value True6r   .a�5�   N   ��  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/stopButton2.png��6g   5�   K   �� 5�   J    6V   �� *	Playing+	 False6r   .a�5�   N   ��  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/playButton2.png��6g   5�   K   5�   C   5�   ;   5�   7   5�   /   �� 5�   .   $��Title��6Q   $��1��64   $��0��6D   $
��Left=�6^   $	��300��6y   
���������6�   ��  �� Path$ Title�6�   �� 5�   .   $��Artist��6Q   $��2��64   $��0��6D   $
��Left=�6_   $	��200��6z   
���������6�   �� $ Artist�6�   �� 5�   .   $��Album��6Q   $��3��64   $��0��6D   $
��Left=�6^   $	��200��6y   
���������6�   �� $ Album�6�   �� 5�   .   $
��Time��6Q   $��4��64   $��0��6D   $
��Left=�6]   $	��100��6x   
���������6�   �� $
 Time�6�   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      