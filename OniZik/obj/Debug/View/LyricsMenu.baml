   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      %    WpfApplication1.View.LyricsMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WpfApplication1     5      $	��680��5   H   ���#464646  K� ZIndex$  2��6j   ��6   �� *	MenuWidth+ �� Mode$ TwoWay=�.��5      �� .+�5	   
   �� -   5        $��menuExpanded��5	      y�6)   �� *ExpandedVisibility+$ TwoWay=�.+�5
      ��  �� Orientation$ 
Horizontal=�6   $	��200��62   .+�5      �� $��20��6   $��20��6%   $
��Left=�60   $��
0, 0, 0, 0q�6K   ��6_   �� *SwitchPanelSizeRelay+��5      �� 5      .R�5      �� $��20��6$   $��20��60   ��5   "   �� 5   &    �� 
TargetType" ��6,   .�5   *   ��  �� Property � �� �� Value$X Rpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRight.png��6C    �� Triggers 5   *   P� 5   .    P� Property �@J�IsMouseOver P� Value . . �5   2   ��  � ��$` Zpack://application:,,,/WpfApplication1;component/Resources/Playlist/arrowRightSelected.png��6K   5   /   5   '   5      5      5      �� 5      $	��180��6   $��Paroles��6(   $��20(�67   
�������	 �� TextAlignment$	 Center=�6X   
 �� Padding$
 0, 0, 20, 0q�6o   5      �� 5      6   �� 5       $��Stretch=�6   $	��650��68   $
��auto��6E   $��Disabled=�6R   $
��auto=�6{   .��5!      �� $	��180��6   $
��Wrap=�6(   
�������$��
10,0,10,10q�6g   ��6O   �� *Lyrics+6}   5"      5#      �� 5$   
   -   5        $��menuCollapsed��5$      $��30��6b   y�6*   �� *CollapsedVisibility+$ TwoWay=�.+�5%      �� $��20��6   $��20��6!   $
��Left=�6,   $��
0, 0, 0, 0q�6G   ��6[   �� *SwitchPanelSizeRelay+��5&      �� 5'      .R�5(      �� $��20��6    $��20��6,   ��5)      �� 5*   "   " ��6(   .�5+   &   ��  � ��$U Opack://application:,,,/WpfApplication1;component/Resources/Lyrics/arrowLeft.png��6?    5,   &   P� 5-   *    �@J�IsMouseOver . . �5.   .   ��  � ��$] Wpack://application:,,,/WpfApplication1;component/Resources/Lyrics/arrowLeftSelected.png��6G   5/   +   51   #   53      54      56      57      58      59      