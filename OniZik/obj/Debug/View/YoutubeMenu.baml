   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model  5      &     WpfApplication1.View.YoutubeMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApplication1     5      5model#clr-namespace:WpfApplication1.Model     5      $
��auto��5	      $
��auto��6   $��Center=�6)     � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/ControlMenuStyle.xaml?�6%   %    5      .��5      � -   5         �Name$ radiosDisplay��5      $��Stretch=�6"   $��Stretch=�6@   $
��auto��6\   $
��auto��6j   $��25,40,25,70q�6w   .+�5   
   �� -   5         ��Name$ TitleRadios��5      $��Center=�6)   $��0,0,0,0q�6F   $
��Wrap=�6W   $��Vidéos Youtube��6k   $	��Top=�6�   $��25(�6�   
�������6�   �� 5   
   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��
50,30,50,5q�6h   .+�5      �� -   5         ��Name$ 	radioFlow��5         placeHolder#��[  6-   
 � Tag$ Url de la vidéo��6R   $��10q�6h   $��30��6t   $	��200��6�   ��6�   �� *
YoutubeURL+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      -   5        
 ��Name$
 
radioImage��5      $��30��6-   $	��150��69   $��15(�6b   $	��Top=�6p   $��Center=�6�   
����������#31A6D1$��10q�6�   #��[" �6�   ��6E   �� *
runVideo+.��6  Lire la vidéo6#  5      �� 5      $��Center=�6   
�������$��15(�6H   Rechercher sur Youtube :6q   �� 5      $ 
Horizontal=�6   $��Center=�63   $	��Top=�6P   $��0,10,0,0q�6h   .+�5      �� $��30��6   $	��200��6'   $��0,5,0,0q�6�   $��Center=�6�   ��63   �� *
MyResearch+$ TwoWay=�$	 PropertyChanged=�6�   �� 5      -   5        $
 searchVideo��5      #��[" �6.   $��0,5,0,0q�6�   $��32��6�   $��15(�6�   $��50��6�   
����������#31A6D1��6i   �� *startSearch+.��6�   Ok6�   5       5!      �� 5"   
   $��60��61   $��30��6<   $��X��6f   $��-450,-580, 0,0q�6r   y�6   �� *
DelVisib+��6H   �� *	HideVideo+6r   �� 5#   
   -   5        $��browser��5#      $��Center=�6D   y�6$   �� *
DelVisib+.+�5$      (  "System.Windows.Controls.WebBrowser  -   5          Name$ webBrowser1��5$      $��Stretch=�6.   $
��auto��5%      $	��500��6   $��Stretch=�6)   $
��auto��6E   $	��880��6R   $	��400q�6a    J� OpacityMask
 �   �6n   5&      � 5)   
   -   5        $��
VideoPanel��5)      $
��auto��6!   $
��auto��6/   $��Stretch=�6<   $��180,100,180,5q�6Z   .+�5*      �� $	��Top=�6   $
��0,75q�63   $��0��6A   $��0��6Q   $
��auto��6^   $
��auto��6l   $��Stretch=�6y   $��Disabled=�6�   $
��auto=�6�   .��5+      �� ��6   �� *YoutubeList+��5,      �� 5-       �� DataType'   !WpfApplication1.Model.YoutubeItem"  6'   .R�5.      � $	��400��6#   $	��210��6/   $��0��6<   $��0��6L    � ColumnDefinitions 5/   "   �� 50   &   $	��200 �67   6E   �� 51   &   $	��200 �67   6E   �� 52   &   $	��200 �67   6E    � RowDefinitions 54   "   �� 55   &   $	��200 �64   6C   �� 56   &   $��80 �64   6B   �� 57   &   $��40 �64   6B   .+�59   "   �� $��0��6)   $��0��69    �� CornerRadius$	 0.5��6F   
�������$��0q�6l   ._�5:   &   �� $
��Fill=�6,   ��6;   �� *	Thumbnail+6[   5;   #   �� 5<   "   $��1��6)   $��0��69   ���#464646._�5=   &   �� 
�������$��15(�6C   $��Center=�6Q   $	��170��6l   $��Center=�6{   ��6�   �� *Name+5>   #   �� 5@   "   $
 	playRadio��6)   $��64��6<   $��64��6G   $��0��6S   $��0��6c     FadeOutButton#��[ 6p    J� Opacity$ 0Q�6�   ��6�   �� *Id+��6�   �� *PlaySearchedVideo+��5A   &   �� 5B   *   .R�5C   .   �� $��64��64   $��64��6@   ��5D   2   �� 5E   6    �� 
TargetType" ��6<   .�5F   :   ��  �� Property � �� �� Value$W Qpack://application:,,,/WpfApplication1;component/Resources/Radios/RadioStream.png��6S   5G   7   5I   /   5J   +   5L   #   5M      5N      5P      5Q      5R      5S      5T      