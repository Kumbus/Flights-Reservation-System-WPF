   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Projekt     -     �Name$  	AppWindow�� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � WindowStartupLocation$ CenterScreen=� � Icon$H BC:\Users\jakub\Desktop\Wszechswiat\WPF\Projekt\Images\Ikona4NB.png��$	��350��$	��300�� � Title$ 
MainWindow��$	��800��$
��1450��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 42Q�%  System.Windows.SystemParameters"   WindowResizeBorderThickness	   ResizeBorderThickness#	 Z 
 � 	Resources
    Projekt.MainWindow �� 
TargetType �� Property �� Value �� 
TargetType �� Padding ��Name   BackgroundLightBrush �� CornerRadius  ForegroundLightBrush J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions K� ZIndex � ColumnDefinitions  LatoBold  WordOrangeBrush  ForegroundVeryDarkBrush �� Orientation  WindowControlButton  WindowCloseButton  BackgroundBrandBrush  	BrandText 	 
TextButton �� 	Converter+   %Projekt.ApplicationPageValueConverter��%  '        7   7  7  7  7  7  7  7  7  7  7  7 	 7 	 �� "  .���  � �� �� " �.R��� $ 4q�._�� .+��� $ 	Container��8��  $ 10���� $ 10��8��    $ 0Q�$	 0.2Q��  !�  �� $ 	Container�� �� $��52 ��� $
��Auto ��� $��* �.+�� $��0��$ 1�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $G��AC:\Users\jakub\Desktop\Wszechswiat\WPF\Projekt\Images\IkonaNB.png��$��3,3,0,0q�(� $��0��$��3��$��3q�.���� 8�� �� $�J��8�� �� $	� & ��8�� �� $�W��8�� �� $��2��$ 
Horizontal=�.+��� -   8�� $��_���� -   8�� $	��[ ]���� -   8�� $��X���� $��1��8��	 $ 10q�._��  �� $��* ��� $
��Auto ��� $
��Auto �.+��� $��Zaplanuj podróż życia��8��
 �� $��1��8�� $��Right=����� *RegisterButtonText+���� *!ChangePageToRegistrationCommand+�� $��2��8�� ���� *LoginButtonText+���� *ChangePageToLoginCommand+�� $��2��$��0q����� *CurrentPage+   