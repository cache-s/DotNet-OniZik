   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   ;"clr-namespace:WpfApplication1.ViewWpfApplication1.View  5   	   %    WpfApplication1.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   3view"clr-namespace:WpfApplication1.View     5   	     � Title$  MyWindowsMediaPlayerV2��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.   ���#262626.��5      � .+�5   
   "   WpfApplication1.View.TopMenu  -   5          Name$ topMenu��5      $��30��6(   $��Stretch=�64   $	��Top=�6R   &    WpfApplication1.View.ControlMenu  5   
   -   5          Name$ controlMenu��5      $��50��61   $��Stretch=�6=   $��Bottom=�6[   &    WpfApplication1.View.MainDisplay  5   
   -   5          Name$ mainDisplay��5      $
��auto��60   $
��auto��6=   $��Center=�6K   $��Center=�6h   &    WpfApplication1.View.LibraryMenu  5   
   -   5          Name$ libraryMenu��5      $��Stretch=�60   $��Stretch=�6N   $
��auto��6j   $
��auto��6x   $y�	Collapsed=�6�   %   WpfApplication1.View.LyricsMenu  5   
   -   5          Name$ 
lyricsMenu��5      $	��200��6.   $
��Auto��6:   $��Right=�6H   $��0,31,-0.4,50.4q�6d   #   WpfApplication1.View.LeftMenu  5   
   -   5          Name$ leftMenu��5      $	��200��6*   $
��Auto��66   $
��Left=�6D   $��0,31,0,50.5q�6_   '   !WpfApplication1.View.PlaylistMenu  5   
   -   5        	  Name$	 playlistMenu��5      $��Stretch=�62   $��Stretch=�6P   $
��auto��6l   $
��auto��6z   $y�	Collapsed=�6�   $   WpfApplication1.View.RadioMenu  5   
   -   5        
  Name$
 	radioMenu��5      $��Stretch=�6,   $��Stretch=�6J   $
��auto��6f   $
��auto��6t   $y�	Collapsed=�6�   &	    WpfApplication1.View.YoutubeMenu	  5   
   -	   5         	 Name$ youtubeMenu��5      $��Stretch=�60   $��Stretch=�6N   $
��auto��6j   $
��auto��6x   $y�	Collapsed=�6�   5      5      