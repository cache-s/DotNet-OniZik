   M S B A M L   `   `   `  ����a  ]GongSolutions.Wpf.DragDrop, Version=0.1.4.3, Culture=neutral, PublicKeyToken=d19974ea350ccea1kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop  5      J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 5      =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model 5      &    WpfApplication1.View.LibraryMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      adragDropLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApplication1     5      5model#clr-namespace:WpfApplication1.Model     5      $
��auto��5	      $
��auto��6-   $��Center=�6:     K� ZIndex$  1��5
   8    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/LibraryMenuStyle.xaml?�6%   %    5      .��5      � -   5         �Name$ libraryDisplay��5      $��Stretch=�6#   $��Stretch=�6A   $
��auto��6]   $��	0,40,25,0q�6j   .+�5   
   �� -   5         ��Name$ TitleLibrary��5      $��Center=�6*   $��0,0,0,0q�6G   $
��Wrap=�6X   $��Bibliothèque de médias��6l   $	��Top=�6�   $��25(�6�   
�������6�   � 5   
    � Orientation$ 
Horizontal=�6   $
��auto��6-   $
��auto��6:   $��Center=�6H   $��92,39,-92.6,-39q�6e   .+�5      �� -   5         ��Name$ 	addButton��5      $��30��6(   $	��240��64   $��15(�6_   $	��Top=�6m   $��Center=�6�   $��0,0,10,0q�6�   #��[" �6�   
����������#31A6D1$��+ Ajouter médias��6  ��6A   �� *
AddMedia+6  �� 5      $	��240��6   $��30��6#      placeHolder#��[  6/   
 � Tag$ Rechercher un média��6T   $��Center=�6n   $	��Top=�6�   $��0,0,10,0q�6�   ��6�   �� *
SearchText+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 5      -   5        $ 	delButton��5      $��30��6(   $	��240��64   $��15(�6_   $	��Top=�6m   $��Center=�6�   $��0,0,0,0q�6�   #��[" �6�   
����������#31A6D1$��- Vider la liste��6  ��6A   �� *
EmptyLib+6  5      �� 5   
   $
��auto��6   $��Stretch=�6"   $��180,100,180,0q�6@   )   #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget .    DropHandler 5      �� .+�5      �  � ColumnDefinitions 5      �� 5       $��1* �6'   65   �� 5!      $��2* �6'   65   �� 5"      $��1* �6'   65   �� 5#      $��1* �6'   65   �� 5$      $��1* �6'   65    � RowDefinitions 5&      �� 5'      6'   .+�5)      �� $��0��6   $��0��6)   $	��150��66   $��30��6B   $
��Left=�6N   #��[" �6�   
����������#31A6D1��6i   �� *ReadLibraryRelay+.��6�   Lire les medias6  �� 5*      -   5        $��TopTitle��5*   6   $��1��6   $��0��6)   $	��150��6F   $��TITRE��6R     NoBorderBlueHover#��[ 6c   $��20(�6�   $
��Left=�6�   $��Title��6�   $��
54,0,-24,0q�6�   ��6�   �� *SortTitleRelay+6�   �� 5+      -   5        $��	TopArtist��5+   6   $��2��6   $��0��6)   $	��150��6G   $��ARTISTE��6S   #��[ 6e   $��20(�6�   $
��Left=�6�   $��Artist��6�   ��6�   �� *SortArtistRelay+�� 5,      -   5        $��TopAlbum��5,   6   $��3��6   $��0��6)   $	��150��6F   $��ALBUM��6R   #��[ 6b   $��20(�6�   $
��Left=�6�   $��Album��6�   ��6�   �� *SortAlbumRelay+�� 5-      -   5        $��TopDuration��5-   6   $��4��6   $��0��6)   $	��150��6I   $��DURÉE��6U   $
��Left=�6e   
�������$��20(�6�   5.      �� 5/      �� 50      $	��550��6   $��Disabled=�6(   $
��auto=�6Q   .��51      �� ��6   �� *LibraryList+��53      �� 54       �� DataType'  !WpfApplication1.Model.LibraryItem"  6'   .R�55      � $��60,0,0,0q�6#    56   "   �� 57   &   $��1* �67   6E   �� 58   &   $��2* �67   6E   �� 59   &   $��1* �67   6E   �� 5:   &   $��1* �67   6E   �� 5;   &   $��1* �67   6E    5=   "   �� 5>   &   67   .+�5@   "   �� $��0��6)   $��0��69   $��25��6F   $��20,0,5,0q�6T   $
��Left=�6�   ��6f   �� *Id+��6�   �� *
DelCommand+��5A   &   �� 5B   *   .R�5C   .   �� $��20��64   $��20��6@   ��5D   2   �� 5E   6    �� 
TargetType" ��6<   .�5F   :   ��  �� Property � �� �� Value$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png��6S   5G   7   5I   /   5J   +   5L   #   �� 5M   "   $��0��6)   $��0��69   $��0q�6F   $��20��6Z   $
��auto��6f   $
��Left=�6s   $��	50,0,20,0q�6�   $
��Play��6�   ��6�   �� *	LibItem+��6�   �� *	Command+��5N   &   �� 5O   *   .R�5P   .   �� $��20��64   $��20��6@   ��5Q   2   �� 5R   6   " ��6<    �� Triggers 5S   :   �� 5T   >    �� Binding 6J   �� *	Playing+ �� Value True6f   .a�5U   B   ��  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/stopButton2.png��6[   5V   ?   �� 5W   >    6J   �� *	Playing+	 False6f   .a�5X   B   ��  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/playButton2.png��6[   5Y   ?   5[   7   5]   /   5^   +   5`   #   �� 5a   "   $��Title��6E   $��1��6(   $��0��68   $
��Left=�6R   $	��300��6m   
���������6}   ��  �� Path$ Title�6�   �� 5b   "   $��Artist��6E   $��2��6(   $��0��68   $
��Left=�6S   $	��200��6n   
���������6}   �� $ Artist�6�   �� 5c   "   $��Album��6E   $��3��6(   $��0��68   $
��Left=�6R   $	��200��6m   
���������6|   �� $ Album�6�   �� 5d   "   $
��Time��6E   $��4��6(   $��0��68   $
��Left=�6Q   $	��100��6l   
���������6{   �� $
 Time�6�   5e      5f      5h      5i      5j      5k      5l      