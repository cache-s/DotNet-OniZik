   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  ;"clr-namespace:WpfApplication1.ViewWpfApplication1.View  %    WpfApplication1.View.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication1     3view"clr-namespace:WpfApplication1.View       � Title$  MyWindowsMediaPlayerV2�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=����#262626.��� .+�"   WpfApplication1.View.TopMenu  -     Name$ topMenu��$��30��$��Stretch=�$	��Top=�&    WpfApplication1.View.ControlMenu  -     Name$ controlMenu��$��50��$��Stretch=�$��Bottom=�&    WpfApplication1.View.MainDisplay  -     Name$ mainDisplay��$
��auto��$
��auto��$��Center=�$��Center=�&    WpfApplication1.View.LibraryMenu  -     Name$ libraryMenu��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$y�	Collapsed=�%   WpfApplication1.View.LyricsMenu  -     Name$ 
lyricsMenu��$	��200��$
��Auto��$��Right=�$��0,31,-0.4,50.4q�#   WpfApplication1.View.LeftMenu  -     Name$ leftMenu��$	��200��$
��Auto��$
��Left=�$��0,31,0,50.5q�'   !WpfApplication1.View.PlaylistMenu  -   	  Name$	 playlistMenu��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$y�	Collapsed=�$   WpfApplication1.View.RadioMenu  -   
  Name$
 	radioMenu��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$y�	Collapsed=�&	    WpfApplication1.View.YoutubeMenu	  -	    	 Name$ youtubeMenu��$��Stretch=�$��Stretch=�$
��auto��$
��auto��$y�	Collapsed=�