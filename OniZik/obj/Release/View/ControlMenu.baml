   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  &     WpfApplication1.View.ControlMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  )localclr-namespace:WpfApplication1  ���#464646$
��auto��  K� ZIndex$  3�� � 	Resources  �� MergedDictionaries �� Source��  �� $b \pack://application:,,,/WpfApplication1;component/Resources/Dictionnary/ControlMenuStyle.xaml?�%    .��� $��Center=�.+��� -    ��Name$ 
playButton��$
��Left=�$��
27,-2,0,-2q�$	��Top=�$��66��#��[" �$��54������ *playButton_Click+���� .R��� $��48��$��48������  �� 
TargetType" ��.���  �� Property � �� �� Value$a [pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/playButton.png�� �� Triggers P� 	 P� Property	 �@J�IsMouseOver
 P� Value
 . . ���  � ��$i cpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/playButtonSelected.png���� -   $ pauseButton��$
��Left=�$��
27,-2,0,-2q�$	��Top=�$��66��#��[" �$��54��$y�Hidden=����� *pauseButton_Click+���� .R��� $��48��$��48������ " ��.���  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/buttonPaused.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/buttonPausedSelected.png���� -   $ previousButton��$
��Left=�$��2,6,0,0q�$	��Top=�$��35��#��[" �$��35������ *prevBtnClick+���� .R��� $��25��$��25������ " ��.���  � ��$e _pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/previousButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$m gpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/previousButtonSelected.png���� -   $ 
nextButton��#��[" �$
��Left=�$��	89,11,0,0q�$	��Top=�$��25��$��25������ *nextBtnClick+���� .R��� $��25��$��25������ " ��.���  � ��$a [pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/nextButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$i cpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/nextButtonSelected.png���� -   $ fullscreenButton��$��Button��$
��Left=�$��1075,11,0,0q�$	��Top=�$��23��#��[" ����� *fullscreenButton_Click+���� .R��� $��25��$��25������ " ��.���  � ��$g apack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/fullscreenButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$o ipack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/fullscreenButtonSelected.png���� -   $ downScreenButton��$��Button��$
��Left=�$��1075,11,0,0q�$	��Top=�$��23��#��[" �$y�Hidden=����� *downScreenButton_Click+���� .R��� $��25��$��25������ " ��.���  � ��$g apack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/downScreenButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$o ipack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/downScreenButtonSelected.png���� -   $ volumeButton��$��Button��$
��Left=�$��
941,12,0,0q�$	��Top=�$��25�� J� RenderTransformOrigin$ -0.52,0.364&�#��[" ����� *volumeButton_Click+���� .R��� $��volumeImage��$��25��$��25������ " ��.���  � ��$^ Xpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volume3.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$f `pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volume3Selected.png���� -   $ volumeButtonOff��$��Button��$
��Left=�$��
941,12,0,0q�$	��Top=�$��25��$ -0.52,0.364&�#��[" �$y�Hidden=����� *volumeButtonOff_Click+���� .R��� $��volumeImage��$��25��$��25������ " ��.���  � ��$` Zpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volumeOff.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$h bpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/volumeOffSelected.png���� -	   $ shuffleButton��$��Button��$
��Left=�$��
839,12,0,0q�$	��Top=�$��25��#��[" ����� *shuffleButton_Click+���� .R��� $��25��$��25������ " ��.���  � ��$d ^pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$l fpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButtonSelected.png���� -
   $ shuffleButtonSelected��$��Button��$
��Left=�$��
839,12,0,0q�$	��Top=�$��25��#��[" �$y�Hidden=����� *shuffleButtonSelected_Click+���� .R��� $��25��$��25������ " ��.���  � ��$l fpack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButtonSelected.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$d ^pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/shuffleButton.png���� -   $ repeatButton��$��Button��$
��Left=�$��
867,12,0,0q�$	��Top=�$��25��#��[" ����� *repeatButton_Click+���� .R��� $��25��$��25������ " ��.���  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButton.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButtonSelected.png���� -   $ repeatButtonSelected��$��Button��$
��Left=�$��
867,12,0,0q�$	��Top=�$��25��#��[" �$y�Hidden=����� *repeatButtonSelected_Click+���� .R��� $��25��$��25������ " ��.���  � ��$k epack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButtonSelected.png�� P� 	 �@J�IsMouseOver
 . . ���  � ��$c ]pack://application:,,,/WpfApplication1;component/Resources/controlMenuImages/repeatButton.png���� -    ��Name$ 	timeVideo��$
��Left=�$��
118,17,0,0q�$
��Wrap=�$��00:00:00��$	��Top=�� -    �Name$ progressBar��$
��Left=�$��10��$��
172,20,0,0q�$	��Top=�$	��602�����	#FF393738���	#FF31A6D1 � Value$ 0Q��� -   $ endTimeVideo��$
��Left=�$��
781,17,0,0q�$
��Wrap=�$��00:00:00��$	��Top=�� -   $ 	volumeBar��$
��Left=�$��10��$��
969,20,0,0q�$	��Top=�$��85�����	#FF393738���	#FF31A6D1$ 50Q��� -   $ button��$
��Left=�$��	897,6,0,0q�$	��Top=�   NoBorderBlueHover#��[  $
��auto��$��20(����� *Speed+���� *SpeedClicked+