   M S B A M L   `   `   `  ����B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt  5          Projekt.MainPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Projekt     5        N� Title$  MainPage��5	      .��5      ��    WordOrangeBrush#��[  6   $��10q�6;    �� CornerRadius$ 10��6G    �� Padding$ 10q�6Y   ._�5   
   � #��[  6   .+�5      �� $
��Auto=�6   $
��Auto=�6?   .��5      �  � ColumnDefinitions 5      �� 5      $��5* �6+   �� 5      $��* �6+   �� 5      $��5* �6+   �� 5      $��3.60* �6+   �� 5      $��5* �6+    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��80 �6(   .+�5      �� $��0��6   
 � Tag$ Skąd��6.   ��69   �� *
SkadText+�� 5       $��1��6     ArrowsButton#��[ 6-   ��6S   �� *ChangePlacesCommand+�� 5!      $��2��6   $ Dokąd��6.   ��6:   �� *	DokadText+�� 5#      -   5         ��Name$ 
DateButton��5#      $��3��61     PopupButton#��[ 6A   ��6f   �� *CalendarDateString+ �� StringFormat$ {0:dd/MM/yyyy}�� � Triggers 5$      :� 5%      	 :� RoutedEvent$	 Button.Click��6+   [�5&   "   �� 5'   &   .��5(   *   �� .��5)   .   �� 
 �� 
TargetName$
 CalendarPopup��5*   )    �� TargetProperty$ IsOpen�5+   )   .p�5,   2   s�  �� KeyTime$ 0:0:0��6J    �� Value$
 True��6Z   5-   /   5.   +   5/   '   51      53      � 55      -   5         �Name$ CalendarPopup��55       � 	StaysOpen$ False��6f    � AllowsTransparency$
 True��6x    � PlacementTarget 63   ��  �� ElementName$ 
DateButton��.��56      ��   CalendarsPopup#��[ 6)   58      59      �� 5<      -   5        $ PassengersButton��5<      $��4��67   #��[ 6G   ��6l   �� *
Passengers+ 5=      :� 5>      $	 Button.Click��6+   [�5?   "   �� 5@   &   .��5A   *   �� .��5B   .   �� $
 PassengersPopup��5C   )   $ IsOpen�5D   )   .p�5E   2   s� $ 0:0:0��6J   $
 True��6Z   5F   /   5G   +   5H   '   5J      5L      � 5N      -   5        $ PassengersPopup��5N      $ False��6n   $
 True��6�    65   �� $ PassengersButton��.��5O      ��   PassengersPopup#��[ 6)   5Q      5R      �� 5T      $��4��6   $��1��6-     SearchButton#��[ 6:   $��Szukaj��6`   ��6q   �� *SearchFlightsCommand+5V      5W      5X      5Y      5Z      