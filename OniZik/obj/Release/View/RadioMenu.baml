   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  =#clr-namespace:WpfApplication1.ModelWpfApplication1.Model  $    WpfApplication1.View.RadioMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     5model#clr-namespace:WpfApplication1.Model     $
��auto��$
��auto��$��Center=�  K� ZIndex$  1�� � 	Resources  �� MergedDictionaries �� Source��  �� $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/ControlMenuStyle.xaml?�%    .��� -    �Name$ radiosDisplay��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$��25,40,25,70q�.+��� -    ��Name$ TitleRadios��$��Center=�$��0,0,0,0q�$
��Wrap=�$��Radios��$	��Top=�$��25(�
���������  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��
50,50,50,5q�.+��� -    ��Name$ 	radioFlow��   placeHolder#��[  
 � Tag$ Flux de la radio��$��10q�$��30��$	��200������ *	RadioFlow+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� -   $ 	radioName��#��[  $ Nom de la radio��$��30��$	��200������ *	RadioName+$	 TwoWay=�$
 PropertyChanged=��� -    ��Name$ 
radioImage��$��30��$	��150��$��15(�$	��Top=�$��Center=�
����������#31A6D1$��10q�#��[" ����� *
AddImage+.��Image�� -   $ radioCreate��$��30��$	��150��$��15(�#��[" �
����������#31A6D1���� *CreateRadio+.��Ajouter une radio� -   $��mainGrid��$
��auto��$
��auto��$��Stretch=�$��180,100,180,5q�.+��� .+��� $��
MES RADIOS��
�������$��20(��� �� $	��Top=�$
��0,75q�$��0��$��0��$
��auto��$
��auto��$��Stretch=�$��Disabled=�$
��auto=�.���� ���� *
RadiosList+����  �� DataType%   WpfApplication1.Model.RadioItem"  .R�� $	��400��$	��210��$��0��$��0�� � ColumnDefinitions �� $	��200 ��� $	��200 ��� $	��200 � � RowDefinitions �� $	��200 ��� $��80 ��� $��40 �.+��� $��0��$��0�� �� CornerRadius$	 0.5��
�������$��0q�._��� $
��Fill=����� *Image+�� $��1��$��0�����#464646._��� 
�������$��15(�$��Center=�$��Center=����� *Name+�� $ 	playRadio��$��64��$��64��$��0��$��0��  FadeOutButton#��[  J� Opacity$ 0Q����� *Id+���� *	PlayRadio+���� .R��� $��64��$��64������  �� 
TargetType" ��.���  �� Property � �� �� Value$W Qpack://application:,,,/WpfApplication1;component/Resources/Radios/RadioStream.png���� $��1��$��0��$��25��$��0,5,5,0q�$��Right=�$	��Top=����� *Id+���� *DeleteRadio+���� .R��� $��20��$��20������ " ��.���  � ��$S Mpack://application:,,,/WpfApplication1;component/Resources/Library/delete.png��