   M S B A M L   `   `   `  ���� a  ]GongSolutions.Wpf.DragDrop, Version=0.1.4.3, Culture=neutral, PublicKeyToken=d19974ea350ccea1kLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDropGongSolutions.Wpf.DragDrop  J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1 =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model &    WpfApplication1.View.LibraryMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     adragDropLclr-namespace:GongSolutions.Wpf.DragDrop;assembly=GongSolutions.Wpf.DragDrop     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     5model#clr-namespace:WpfApplication1.Model     $
��auto��$
��auto��$��Center=�  K� ZIndex$  1�� � 	Resources  �� MergedDictionaries �� Source��  �� $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/LibraryMenuStyle.xaml?�%    .��� -    �Name$ libraryDisplay��$��Stretch=�$��Stretch=�$
��auto��$��	0,40,25,0q�.+��� -    ��Name$ TitleLibrary��$��Center=�$��0,0,0,0q�$
��Wrap=�$��Bibliothèque de médias��$	��Top=�$��25(�
��������  � Orientation$ 
Horizontal=�$
��auto��$
��auto��$��Center=�$��92,39,-92.6,-39q�.+��� -    ��Name$ 	addButton��$��30��$	��240��$��15(�$	��Top=�$��Center=�$��0,0,10,0q�#��[" �
����������#31A6D1$��+ Ajouter médias������ *
AddMedia+�� $	��240��$��30��   placeHolder#��[  
 � Tag$ Rechercher un média��$��Center=�$	��Top=�$��0,0,10,0q����� *
SearchText+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� -   $ 	delButton��$��30��$	��240��$��15(�$	��Top=�$��Center=�$��0,0,0,0q�#��[" �
����������#31A6D1$��- Vider la liste������ *
EmptyLib+�� $
��auto��$��Stretch=�$��180,100,180,0q�)   #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget .    DropHandler �� .+��  � ColumnDefinitions �� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* � � RowDefinitions �� .+��� $��0��$��0��$	��150��$��30��$
��Left=�#��[" �
����������#31A6D1���� *ReadLibraryRelay+.��Lire les medias�� -   $��TopTitle��$��1��$��0��$	��150��$��TITRE��  NoBorderBlueHover#��[ $��20(�$
��Left=�$��Title��$��
54,0,-24,0q����� *SortTitleRelay+�� -   $��	TopArtist��$��2��$��0��$	��150��$��ARTISTE��#��[ $��20(�$
��Left=�$��Artist������ *SortArtistRelay+�� -   $��TopAlbum��$��3��$��0��$	��150��$��ALBUM��#��[ $��20(�$
��Left=�$��Album������ *SortAlbumRelay+�� -   $��TopDuration��$��4��$��0��$	��150��$��DURÉE��$
��Left=�
�������$��20(��� �� $	��550��$��Disabled=�$
��auto=�.���� ���� *LibraryList+����  �� DataType'  !WpfApplication1.Model.LibraryItem"  .R�� $��60,0,0,0q� �� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* � �� .+��� $��0��$��0��$��25��$��20,0,5,0q�$
��Left=����� *Id+���� *
DelCommand+���� .R��� $��20��$��20������  �� 
TargetType" ��.���  �� Property � �� �� Value$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png���� $��0��$��0��$��0q�$��20��$
��auto��$
��Left=�$��	50,0,20,0q�$
��Play������ *	LibItem+���� *	Command+���� .R��� $��20��$��20������ " �� �� Triggers ��  �� Binding �� *	Playing+ �� Value True.a���  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/stopButton2.png����  �� *	Playing+	 False.a���  � ��$P Jpack://application:,,,/WpfApplication1;component/Resources/playButton2.png���� $��Title��$��1��$��0��$
��Left=�$	��300��
�����������  �� Path$ Title��� $��Artist��$��2��$��0��$
��Left=�$	��200��
����������� $ Artist��� $��Album��$��3��$��0��$
��Left=�$	��200��
����������� $ Album��� $
��Time��$��4��$��0��$
��Left=�$	��100��
����������� $
 Time�