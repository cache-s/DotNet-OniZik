   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  "    WpfApplication1.View.TopMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:WpfApplication1     $	��252��$
��auto�����#464646$��Stretch=�  K� ZIndex$  3��.��� ���#464646$	��461��$
��Left=� � RowDefinitions �� $��0* ���  � 	Resources  �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   '��       'm� )     'o� R     �� " ��.���  � �� �#464646�� " m�.���  � �� �#464646�� " o�.���  � �� �#464646 P�  �@J�IsMouseOver . . ���  � �� �#FF0000.+�o� -   	 o�Name$	 Fichier��$
��Left=�$��21��$	��Top=�$��46�����#464646
�������$��2��$��3.066,0,0,0q���Z� .@�m� $��_Fichier�����#464646.@�m� $��1q�$��Ouvrir un fichier��
 m� Command
 �� *
fileOpener+m� $��1q�$��Ouvrir un dossier��
 �� *folderOpener+m� $��1q�$��Ouvrir un flux réseau...��
 �� *
fluxOpener+m� $��1q�$��Quitter��
 �� *
closeapp+o� -   $	 Audio��$
��Left=�$��21��$	��Top=�$��46�����#464646
�������$��2��$��53.599,0,0,0q���Z� .@�m� $��_Audio��.@�m� $��Couper le volume��
 �� *	muteVol+m� $��Reactiver le volume��
 �� *	unmuteVol+o� -   $	 Video��$��21��$	��Top=�$��103.132,0,0,0q����#464646
�������$��2��$
��Left=�$��46����Z� .@�m� $��_Video��.@�m� $��Plein écran��
 �� *setFullScreen+m� $��Capture d'écran��
 �� *takeScreenShot+o� -   $	 Playlist��$
��Left=�$��21��$	��Top=�$��51��$��152.176,0,0,0q����#464646
�������$��2����Z� .@�m� $��Playlist��.@�m� $��Importer une Playlist��
 �� *importPlayList+o� -   $	 Media��$��21��$	��Top=�$��208.753,-0.022,208.247,0q����#464646
�������$��2����Z� .@�m� $��_Media��.@�m� $��Suivant��
 �� *goNext+m� $��Précédent��
 �� *goPrev+m� $
��Lire��
 �� *	playMedia+m� $��Pause��
 �� *
pauseMedia+m� $��Arreter��
 �� *	stopMedia+o� $
��Left=�$��21��$	��Top=�$��46��$��257.138,0.332,0,0q����#464646
�������$��2����Z� .@�m� $��_Aide��.@�m� $��A propos...��
 �� *aboutOpener+� -    �Name$ 
aboutPopUp��$��2��$��	0,0,0,252q�$��2������ *aboutIsOpen+.��� ���	#FFE5E5E5$��163.558��$��397.385��.+��� -    ��Name$ 	AboutText��$��19.5,18,10.385,9.058q�$
��Wrap=����� *	aboutText+�� -    ��Name$ 
closeAbout��$��X��$��Right=�$
��19.5��$��0,5,5,0q�$	��Top=�$��18������ *aboutCloser+� -	   $ 	fluxPopUp��$��2��$��	0,0,0,252q�$��2������ *
fluxIsOpen+.��� ���#464646$��163.558��$��397.385��.+���  �� Orientation$ 
Horizontal=�.+��� -
    ��Name$
 flux��$��30��$	��180��$��10,0,0,0q� �� TextWrapping$
 Wrap=����� *
fluxPath+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ createPlaylist��$��30��$	��180��$��15,0,0,0q�$��15(�#��[" �
����������#31A6D1���� *ReadFluxBtn+.��Lire le flux�� -   $ 	closeFlux��$��X��$��Right=�$
��19.5��$��0,5,5,0q�$	��Top=�$��18������ *
fluxCloser+� -   $ browsePopUp��$��2��$��	0,0,0,252q�$��2������ *browseIsOpen+.��� ���	#FFE5E5E5$��163.558��$��397.385��.+��� -   $ browseFolderButton��$��Selectionner le dossier��$��Right=�$��0,36,8.885,0q�$	��135��$��24��$	��Top=����� *folderBrowser+�� $��1q�
���   �._��� -   $ 
browseText��$
��19.5��$��6,39,148.385,0q�$
��Wrap=�$	��Top=����� *
browsePath+$ PropertyChanged=��� -    ��Name$ recurseCheckBox��$F��@Recherche Recursive (/!\Restreindre à de petites arborescences)��$��12,63,0,81.058q�$
��Left=�$��360.5�� d� 	IsChecked �� *
recurCheck+$ PropertyChanged=��� -   $ audioCheckBox��$��Fichier Audios��$��12,0,0,61.558q�$
��Left=�$��142.5��$
��19.5��$��Bottom=� �� *
audioCheck+$ PropertyChanged=��� -   $ videoCheckBox��$��Fichier Vidéos��$��12,0,0,41.558q�$
��Left=�$��142.5��$
��19.5��$��Bottom=� �� *
videoCheck+$ PropertyChanged=��� -   $ imageCheckBox��$��Images��$��12,0,0,21.558q�$
��Left=�$��142.5��$
��19.5��$��Bottom=� �� *
imageCheck+$ PropertyChanged=��� -   $ generatePlayList��$��	Générer��$��0,0,11.885,16q�$��Right=�$	��108��$
��28.5��$��Bottom=����� *playlistGenerator+�� -   $ closeFolderBrowse��$��X��$��Right=�$
��19.5��$��0,5,5,0q�$	��Top=�$��18������ *closeBrowseFolder+