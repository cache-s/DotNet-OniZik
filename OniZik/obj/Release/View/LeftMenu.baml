   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  #    WpfApplication1.View.LeftMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     ���#464646  K� ZIndex$  2������ *	MenuWidth+ �� Mode$ TwoWay=�.���� .+��� -   $��menuExpanded�� �� Orientation$ Vertical=�y��� *ExpandedVisibility+$ TwoWay=�.+��� $ 
Horizontal=�$	��200��.+��� $��20(�
�������
������ #��[" �$��OniZik��$��Center=����� *	HomeRelay+�� $��20��$��20��$
��Left=�$��100, 0, 0, 0q����� *SwitchPanelSizeRelay+���� .R��� $��20��$��20������  �� 
TargetType" ��.���  �� Property � �� �� Value$W Qpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowLeft.png�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��$_ Ypack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowLeftSelected.png���� $	��400��$	��200��.+��� $y�Hidden=�$��
5, 5, 5, 5q�   placeHolder#���   
	 � Tag$	 
Rechercher������ *
SearchText+�� -   
 ��Name$
 btnPlaylists��$��	Playlists��  playlistsBtnStyle#���  ���� *ShowPlaylistsRelay+�� #��["��� -   $��btnRadio��$��Radio��  radioBtnStyle#���  ���� *ShowRadiosRelay+�� #��["��� -   $��	btnMedias��$��Medias��  mediasBtnStyle#���  ���� *ShowMediasRelay+�� #��["��� -   $��
btnYoutube��$��Youtube��  youtubeBtnStyle#���  ���� *ShowYoutubeRelay+�� �� -    ��Name$ 	musicInfo��$
��auto��.+��  � ColumnDefinitions �� $	��200 � � RowDefinitions �� $	��200 ��� $��30 ��� $��30 ��� $��30 �.+��� -    ��Name$ coverArt��$��0��$��0��$	��150��$	��150��$��Center=�$��10q����� *
CoverImage+�� -   $��songName��$��0��$��1��
�������$��Center=����� *
SongName+�� -	   $��
artistName��$��0��$��2��
�������$��Center=����� *
ArtistName+�� -
   $��	albumName��$��0��$��3��
�������$��Center=����� *	AlbumName+�� -   $��menuCollapsed��$��30��y��� *CollapsedVisibility+$ TwoWay=�.+��� $��20��$��20��$
��Left=�$��
0, 0, 0, 0q����� *SwitchPanelSizeRelay+���� .R��� $��20��$��20������ " ��.���  � ��$X Rpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRight.png�� P�  �@J�IsMouseOver . . ���  � ��$` Zpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRightSelected.png�� � 	Resources  �� BasedOn �� 
TargetType ��Name �� Path �� RelativeSource �� UpdateSourceTrigger �� Binding �� Source%  System.Windows.Markup.Reference �� Value  listView  listViewItem  plainBtnStyle �� Padding��%  &	        7��&	 T    &	 y    &	 �    &	 I    7  &	 �    7  &	      7  &	 [    7  �� " ��8   .���  � �� �� " ��.R�� .+��� $ 
textSource��
������ $  2������ $
 Text� �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=��� #��z	 #��z��$  1��.������ " ��.���  � ��
 ����  ��  �� $
 Text�   *
textSource+  .a���  � ��
 �����.���� " ��.���  � ��
 ���� �� " ��.���  � �� �#909090 P�  �@J�IsMouseOver . . ���  � ��
 ���� �� " ��.���  � �� �#909090 P�  �@J�IsMouseOver . . ���  � ��
 ������� 8   " ��.���  � ��$ 20(���  � ��$ 10, 0, 0, 0q���  � �� �� " ��.R��� $ 
Horizontal=�$	��200��.+��� $��Uniform=�$��20��$��20��$��
5, 0, 0, 0q����� " ��.���  � ��$V Ppack://application:,,,/WpfApplication1;component/Resources/Playlist/playlist.png���� #��z��# z��$��Center=�$	��180���� 8   " ��.���  � ��$ 20(���  � ��$ 10, 0, 0, 0q���  � �� �� " ��.R��� $ 
Horizontal=�$	��200��.+��� $��Uniform=�$��20��$��20��$��
5, 0, 0, 0q����� " ��.���  � ��$S Mpack://application:,,,/WpfApplication1;component/Resources/Playlist/radio.png���� #��z��# z��$��Center=�$	��180���� 8   " ��.���  � ��$ 20(���  � ��$ 10, 0, 0, 0q���  � �� �� " ��.R��� $ 
Horizontal=�$	��200��.+��� $��Uniform=�$��20��$��20��$��
5, 0, 0, 0q����� " ��.���  � ��$T Npack://application:,,,/WpfApplication1;component/Resources/Playlist/titres.png���� #��z��# z��$��Center=�$	��180���� 8   " ��.���  � ��$ 20(���  � ��$ 10, 0, 0, 0q���  � �� �� " ��.R��� $ 
Horizontal=�$	��200��.+��� $��Uniform=�$��20��$��20��$��
5, 0, 0, 0q����� " ��.���  � ��$Y Spack://application:,,,/WpfApplication1;component/Resources/Playlist/youtubeLogo.png���� #��z��# z��$��Center=�$	��180��