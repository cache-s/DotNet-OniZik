   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model  &     WpfApplication1.View.YoutubeMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     5model#clr-namespace:WpfApplication1.Model     $
��auto��$
��auto��$��Center=�  � 	Resources   �� MergedDictionaries �� Source��  �� $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/ControlMenuStyle.xaml?�%    .��� -    �Name$ radiosDisplay��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$��25,40,25,70q�.+��� -    ��Name$ TitleRadios��$��Center=�$��0,0,0,0q�$
��Wrap=�$��Vidéos Youtube��$	��Top=�$��25(�
��������� .+���  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��
50,30,50,5q�.+��� -    ��Name$ 	radioFlow��   placeHolder#��[  
 � Tag$ Url de la vidéo��$��10q�$��30��$	��200������ *
YoutubeURL+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� -   
 ��Name$
 
radioImage��$��30��$	��150��$��15(�$	��Top=�$��Center=�
����������#31A6D1$��10q�#��[" ����� *
runVideo+.��Lire la vidéo�� $��Center=�
�������$��15(�Rechercher sur Youtube :�� $ 
Horizontal=�$��Center=�$	��Top=�$��0,10,0,0q�.+��� $��30��$	��200��$��0,5,0,0q�$��Center=����� *
MyResearch+$ TwoWay=�$	 PropertyChanged=��� -   $
 searchVideo��#��[" �$��0,5,0,0q�$��32��$��15(�$��50��
����������#31A6D1���� *startSearch+.��Ok�� $��60��$��30��$��Fermer��$��-450,-580,0,0q�#��[" �
����������#31A6D1y��� *
DelVisib+���� *	HideVideo+�� -   $��browser��$��Center=�y��� *
DelVisib+.+�(  "System.Windows.Controls.WebBrowser  -     Name$ webBrowser1��$��Stretch=�$
��auto��$	��500��$��Stretch=�$
��auto��$	��880��$	��400q� J� OpacityMask
 �   �� -   $��
VideoPanel��$
��auto��$
��auto��$��Stretch=�$��180,100,180,5q�.+��� $	��Top=�$
��0,75q�$��0��$��0��$
��auto��$
��auto��$��Stretch=�$��Disabled=�$
��auto=�.���� ���� *YoutubeList+����  �� DataType'   !WpfApplication1.Model.YoutubeItem"  .R�� $	��400��$	��210��$��0��$��0�� � ColumnDefinitions �� $	��200 ��� $	��200 ��� $	��200 � � RowDefinitions �� $	��200 ��� $��80 ��� $��40 �.+��� $��0��$��0�� �� CornerRadius$	 0.5��
�������$��0q�._��� $
��Fill=����� *	Thumbnail+�� $��1��$��0�����#464646._��� 
�������$��15(�$��Center=�$	��170��$��Center=����� *Name+�� $
 	playRadio��$��64��$��64��$��0��$��0��  FadeOutButton#��[  J� Opacity$ 0Q����� *Id+���� *PlaySearchedVideo+���� .R��� $��64��$��64������  �� 
TargetType" ��.���  �� Property � �� �� Value$W Qpack://application:,,,/WpfApplication1;component/Resources/Radios/RadioStream.png��