   M S B A M L   `   `   `  ���� a  ]GongSolutions.Wpf.DragDrop, Version=0.1.4.3, Culture=neutral, PublicKeyToken=d19974ea350ccea1kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop  J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model '   !WpfApplication1.View.PlaylistMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     adragDropLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     5model#clr-namespace:WpfApplication1.Model     $
��auto��$
��auto��$��Center=�  K� ZIndex$  1�� � 	Resources  �� MergedDictionaries �� Source��  �� $c ]pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/PlayListMenuStyle.xaml?�%    .��� -    �Name$ playlistDisplay��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$��25,40,25,70q�.+��� -    ��Name$ TitlePlaylist��$��Center=�$��0,0,0,0q�$
��Wrap=�$��Gérer mes playlists��$	��Top=�$��25(�
��������� -    ��Name$ playlistName��$��30��$	��200��$	��Top=�   placeHolder#��[  
 � Tag$ Nom playlist��$��
0,50,240,0q����� *PlaylistName+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� -   
 ��Name$
 createPlaylist��$��30��$	��250��$��15(�$	��Top=�$��Center=�$��
240,50,0,0q�#��[" �
����������#31A6D1���� *CreatePlaylistRelay+.��Créer playlist� -   $��mainGrid��$
��auto��$
��auto��$��Stretch=�$��180,100,180,5q�.+��� .+��� $��MES PLAYLISTS��
�������$��20(��� � -   $��mainListGrid��$��
0,38,0,-38q�$
��auto�� � ColumnDefinitions �� -    �Name$ 
myPlaylist��$��2* ��� -   $ myList��$��5* � � RowDefinitions �� -	   $ myButtonsHere��$
��0.4* ��� -
   $ listHere��$	��10* �.+�� $��2��$��2��$
��auto��$��Stretch=�)   #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget .    DropHandler �� .+��� $��0��$��0��$
��Left=�$��	0,20,5,30q� �� Orientation$ 
Horizontal=�.+��� $
��auto��$��Disabled=�$
��auto=�.���� $��0,0,0,0q����� *PlaylistList+����  �� DataType(  "WpfApplication1.Model.PlaylistItem"  .R��� 
������ $
��auto��$��Stretch=�$ 
Horizontal=�.+��� $��25��$��5,0,5,0q����� *Id+���� *
DelCommand+���� .R��� $��20��$��20������  �� 
TargetType" ��.���  �� Property � �� �� Value$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png���� $
 button�����#262626#��[" �$��0q�$��20��$	��100��$��5,0,5,0q�
����������� *Name+���� *Id+���� *	Command+�� $��0��$��0��  VerticalSeparatorStyle#���  y��� *AddVisibility+� $��1��$��1��$
��auto��$��Stretch=�$��
180,0,20,0q�.+��� $��1��$��1��$
��Left=�$ 
Horizontal=�.+��� $	��150��$��30��$��
0,10,25,10q�$	��Top=�$
��Left=�#��[" �
����������#31A6D1y��� *AddVisibility+���� *AddMediaRelay+.��+ Ajouter média�� $	��150��$��30��$��
0,10,25,10q�$	��Top=�$
��Left=�#��[" �
����������#31A6D1y��� *AddVisibility+���� *ReadPlayListRelay+.��Lire playlist�� $	��150��$��30��$��
0,10,25,10q�$	��Top=�$
��Left=�#��[  $ 
Rechercher��y��� *AddVisibility+���� *
SearchText+$ TwoWay=�$	 PropertyChanged=�� $��1��$��1��$
��auto��$��Stretch=�$��	0,40,0,60q� �� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* � �� .+��� $��1��$��0��$��TITRE��$	��Top=�$
��Left=�  NoBorderBlueHover#��[ $��15(�y��� *AddVisibility+���� *SortTitleRelay+�� $��2��$��0��$��ARTISTE��$	��Top=�$
��Left=�#��[ $��15(�y��� *AddVisibility+���� *SortArtistRelay+�� $��3��$��0��$��ALBUM��$	��Top=�$
��Left=�#��[ $��15(�y��� *AddVisibility+���� *SortAlbumRelay+�� $��4��$��0��$��DURÉE��$	��Top=�$
��Left=�
�������$��15(�y��� *AddVisibility+�� $
��0,75q�$��1��$��1��$��Stretch=�$
��auto��$
��auto��$��Disabled=�$
��auto=�.���� ���� *LibraryList+���� '  !WpfApplication1.Model.LibraryItem"  .R�� $��1��$��1��$
��auto��$��Stretch=�$��0,0,0,0q� �� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* � �� .+��� $��0��$��0��$��25��$��0,0,5,0q�$
��Left=����� *Id+���� *
DelCommand+���� .R��� $��20��$��20������ " ��.���  � ��$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png���� $��0��$��0�����#262626
�������$��0q�$��20��$��20��$
��Left=�$��25,0,0,0q����� *Name+���� *	LibItem+���� *	Command+���� .R��� $��20��$��20������ " �� �� Triggers ��  �� Binding �� *	Playing+ �� Value True.a���  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/stopButton2.png����  �� *	Playing+	 False.a���  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/playButton2.png���� $��Title��$��1��$��0��$
��Left=�$	��300��
�����������  �� Path$ Title��� $��Artist��$��2��$��0��$
��Left=�$	��200��
����������� $ Artist��� $��Album��$��3��$��0��$
��Left=�$	��200��
����������� $ Album��� $
��Time��$��4��$��0��$
��Left=�$	��100��
����������� $
 Time�