   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  %    WpfApplication1.View.LyricsMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     $	��680�����#464646  K� ZIndex$  2������ *	MenuWidth+ �� Mode$ TwoWay=�.���� .+��� -   $��menuExpanded��y��� *ExpandedVisibility+$ TwoWay=�.+���  �� Orientation$ 
Horizontal=�$	��200��.+��� $��20��$��20��$
��Left=�$��
0, 0, 0, 0q����� *SwitchPanelSizeRelay+���� .R��� $��20��$��20������  �� 
TargetType" ��.���  �� Property � �� �� Value$X Rpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRight.png�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��$` Zpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRightSelected.png���� $	��180��$��Paroles��$��20(�
�������	 �� TextAlignment$	 Center=�
 �� Padding$
 0, 0, 20, 0q��� �� $��Stretch=�$	��650��$
��auto��$��Disabled=�$
��auto=�.���� $	��180��$
��Wrap=�
�������$��
10,0,10,10q����� *Lyrics+�� -   $��menuCollapsed��$��30��y��� *CollapsedVisibility+$ TwoWay=�.+��� $��20��$��20��$
��Left=�$��
0, 0, 0, 0q����� *SwitchPanelSizeRelay+���� .R��� $��20��$��20������ " ��.���  � ��$U Opack://application:,,,/WpfApplication1;component/Resources/Lyrics/arrowLeft.png�� P�  �@J�IsMouseOver . . ���  � ��$] Wpack://application:,,,/WpfApplication1;component/Resources/Lyrics/arrowLeftSelected.png��