   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.MainPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Projekt       N� Title$  MainPage��.����    WordOrangeBrush#��[  $��10q� �� CornerRadius$ 10�� �� Padding$ 10q�._�� #��[  .+��� $
��Auto=�$
��Auto=�.���  � ColumnDefinitions �� $��5* ��� $��* ��� $��5* ��� $��3.60* ��� $��5* � � RowDefinitions �� $
��Auto ��� $��80 �.+��� $��0��
 � Tag$ Skąd������ *
SkadText+�� $��1��  ArrowsButton#��[ ���� *ChangePlacesCommand+�� $��2��$ Dokąd������ *	DokadText+�� -    ��Name$ 
DateButton��$��3��  PopupButton#��[ ���� *CalendarDateString+ �� StringFormat$ {0:dd/MM/yyyy}�� � Triggers :� 	 :� RoutedEvent$	 Button.Click��[��� .���� .���� 
 �� 
TargetName$
 CalendarPopup�� �� TargetProperty$ IsOpen�.p�s�  �� KeyTime$ 0:0:0�� �� Value$
 True��� -    �Name$ CalendarPopup�� � 	StaysOpen$ False�� � AllowsTransparency$
 True�� � PlacementTarget ��  �� ElementName$ 
DateButton��.����   CalendarsPopup#��[ �� -   $ PassengersButton��$��4��#��[ ���� *
Passengers+ :� $	 Button.Click��[��� .���� .���� $
 PassengersPopup��$ IsOpen�.p�s� $ 0:0:0��$
 True��� -   $ PassengersPopup��$ False��$
 True�� �� $ PassengersButton��.����   PassengersPopup#��[ �� $��4��$��1��  SearchButton#��[ $��Szukaj������ *SearchFlightsCommand+