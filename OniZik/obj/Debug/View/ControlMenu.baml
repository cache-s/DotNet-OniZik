   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5      &     WpfApplication1.View.ControlMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      )localclr-namespace:WpfApplication1  5      ���#464646$
��auto��5	   7     K� ZIndex$  3��6D    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/ControlMenuStyle.xaml?�6%   %    5      .��5      � $��Center=�6   .+�5   
   �� -   5         ��Name$ 
playButton��5      $
��Left=�6%   $��
27,-2,0,-2q�6@   $	��Top=�6T   $��66��6l   #��[" �6w   $��54��6�   ��6�   �� *playButton_Click+��5      �� 5      .R�5      �� $��48��6   $��48��6(   ��5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value$a [pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/playButton.png��6;    �� Triggers 5   "   P� 5   &   	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5   *   ��  � ��$i cpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/playButtonSelected.png��6C   5   '   5       5"      5#      5%      �� 5&   
   -   5        $ pauseButton��5&      $
��Left=�6&   $��
27,-2,0,-2q�6A   $	��Top=�6U   $��66��6m   #��[" �6x   $��54��6�   $y�Hidden=�6�   ��6�   �� *pauseButton_Click+��5'      �� 5(      .R�5)      �� $��48��6   $��48��6(   ��5*      �� 5+      " ��6$   .�5,   "   ��  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/buttonPaused.png��6;    5-   "   P� 5.   &   	 �@J�IsMouseOver
 . . �5/   *   ��  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/buttonPausedSelected.png��6C   50   '   52      54      55      57      �� 58   
   -   5        $ previousButton��58      $
��Left=�6J   $��2,6,0,0q�6e   $	��Top=�6v   $��35��6�   #��[" �6�   $��35��6�   ��6)   �� *prevBtnClick+��59      �� 5:      .R�5;      �� $��25��6   $��25��6(   ��5<      �� 5=      " ��6$   .�5>   "   ��  � ��$e _pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/previousButton.png��6;    5?   "   P� 5@   &   	 �@J�IsMouseOver
 . . �5A   *   ��  � ��$m gpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/previousButtonSelected.png��6C   5B   '   5D      5F      5G      5I      �� 5J   
   -   5        $ 
nextButton��5J      #��[" �6F   $
��Left=�6�   $��	89,11,0,0q�6�   $	��Top=�6�   $��25��6�   $��25��6�   ��6%   �� *nextBtnClick+��5K      �� 5L      .R�5M      �� $��25��6   $��25��6(   ��5N      �� 5O      " ��6$   .�5P   "   ��  � ��$a [pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/nextButton.png��6;    5Q   "   P� 5R   &   	 �@J�IsMouseOver
 . . �5S   *   ��  � ��$i cpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/nextButtonSelected.png��6C   5T   '   5V      5X      5Y      5[      �� 5\   
   -   5        $ fullscreenButton��5\      $��Button��6+   $
��Left=�6<   $��1075,11,0,0q�6W   $	��Top=�6l   $��23��6�   #��[" �6�   ��6�   �� *fullscreenButton_Click+��5]      �� 5^      .R�5_      �� $��25��6   $��25��6(   ��5`      �� 5a      " ��6$   .�5b   "   ��  � ��$g apack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/fullscreenButton.png��6;    5c   "   P� 5d   &   	 �@J�IsMouseOver
 . . �5e   *   ��  � ��$o ipack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/fullscreenButtonSelected.png��6C   5f   '   5h      5j      5k      5m      �� 5n   
   -   5        $ downScreenButton��5n      $��Button��6+   $
��Left=�6<   $��1075,11,0,0q�6W   $	��Top=�6l   $��23��6�   #��[" �6�   $y�Hidden=�6�   ��6�   �� *downScreenButton_Click+��5o      �� 5p      .R�5q      �� $��25��6   $��25��6(   ��5r      �� 5s      " ��6$   .�5t   "   ��  � ��$g apack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/downScreenButton.png��6;    5u   "   P� 5v   &   	 �@J�IsMouseOver
 . . �5w   *   ��  � ��$o ipack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/downScreenButtonSelected.png��6C   5x   '   5z      5|      5}      5      �� 5�   
   -   5        $ volumeButton��5�      $��Button��6'   $
��Left=�68   $��
941,12,0,0q�6S   $	��Top=�6g   $��25��6    J� RenderTransformOrigin$ -0.52,0.364&�6�   #��[" �5�      ��6L   �� *volumeButton_Click+��5�      �� 5�      .R�5�      �� $��volumeImage��6   $��25��6/   $��25��6;   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$^ Xpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volume3.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$f `pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volume3Selected.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -   5        $ volumeButtonOff��5�      $��Button��6*   $
��Left=�6;   $��
941,12,0,0q�6V   $	��Top=�6j   $��25��6�   $ -0.52,0.364&�6�   #��[" �5�      $y�Hidden=�6v   ��6L   �� *volumeButtonOff_Click+��5�      �� 5�      .R�5�      �� $��volumeImage��6   $��25��6/   $��25��6;   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$` Zpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volumeOff.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$h bpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volumeOffSelected.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -	   5        $ shuffleButton��5�      $��Button��6(   $
��Left=�69   $��
839,12,0,0q�6T   $	��Top=�6h   $��25��6�   #��[" �6�   ��6�   �� *shuffleButton_Click+��5�      �� 5�      .R�5�      �� $��25��6   $��25��6(   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$d ^pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButton.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$l fpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButtonSelected.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -
   5        $ shuffleButtonSelected��5�      $��Button��60   $
��Left=�6A   $��
839,12,0,0q�6\   $	��Top=�6p   $��25��6�   #��[" �6�   $y�Hidden=�6�   ��6�   �� *shuffleButtonSelected_Click+��5�      �� 5�      .R�5�      �� $��25��6   $��25��6(   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$l fpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButtonSelected.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$d ^pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButton.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -   5        $ repeatButton��5�      $��Button��6'   $
��Left=�68   $��
867,12,0,0q�6S   $	��Top=�6g   $��25��6   #��[" �6�   ��6�   �� *repeatButton_Click+��5�      �� 5�      .R�5�      �� $��25��6   $��25��6(   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButton.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButtonSelected.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -   5        $ repeatButtonSelected��5�      $��Button��6/   $
��Left=�6@   $��
867,12,0,0q�6[   $	��Top=�6o   $��25��6�   #��[" �6�   $y�Hidden=�6�   ��6�   �� *repeatButtonSelected_Click+��5�      �� 5�      .R�5�      �� $��25��6   $��25��6(   ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButtonSelected.png��6;    5�   "   P� 5�   &   	 �@J�IsMouseOver
 . . �5�   *   ��  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButton.png��6C   5�   '   5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ 	timeVideo��5�      $
��Left=�6'   $��
118,17,0,0q�6B   $
��Wrap=�6V   $��00:00:00��6j   $	��Top=�6z   � 5�   
   -   5         �Name$ progressBar��5�      $
��Left=�6+   $��10��6F   $��
172,20,0,0q�6R   $	��Top=�6f   $	��602��6~   ���	#FF393738���	#FF31A6D1 � Value$ 0Q�5�      6    �� 5�   
   -   5        $ endTimeVideo��5�      $
��Left=�6*   $��
781,17,0,0q�6E   $
��Wrap=�6Y   $��00:00:00��6m   $	��Top=�6}   � 5�   
   -   5        $ 	volumeBar��5�      $
��Left=�6)   $��10��6D   $��
969,20,0,0q�6P   $	��Top=�6d   $��85��6|   ���	#FF393738���	#FF31A6D1$ 50Q�5�   -   68   �� 5�   
   -   5        $ button��5�      $
��Left=�6\   $��	897,6,0,0q�6w   $	��Top=�6�      NoBorderBlueHover#��[  6�   $
��auto��6�   $��20(�6�   ��6!   �� *Speed+��6;   �� *SpeedClicked+6�   5�      5�      