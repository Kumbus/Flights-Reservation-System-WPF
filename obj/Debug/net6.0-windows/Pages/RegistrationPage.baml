   M S B A M L   `   `   `  ����B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt  5          Projekt.RegistrationPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Projekt     5        N� Title$  RegistrationPage��5	       � DataContext 5      '   !Projekt.RegistrationPageViewModel  5   
   .��5      ��    WordOrangeBrush#��[  6    �� CornerRadius$ 10��6;   $��10q�6M   ._�5   
   � .+�5      �� $
��Auto=�6   $
��Auto=�6>   .��5      �� $��Center=�6    �� TextAlignment$ Center=�6:   $��40q�6[   .+�5      ��   ForegroundLightBrush#��[ 6   $ 10��5       �� Padding$ 15 50 15 15q�5      $
��Auto��5      $	��330��5      $	��600��5      $��0q�5      ._�5      �  � ColumnDefinitions 5      �� 5   "   $��* �63   �� 5    "   $��* �63    � RowDefinitions 5#      �� 5$   "   $
��Auto �60   �� 5%   "   $
��Auto �60   �� 5&   "   $
��Auto �60   �� 5'   "   $
��Auto �60   �� 5(   "   $
��Auto �60   �� 5)   "   $
��Auto �60   �� 5*   "   $
��Auto �60   �� 5+   "   $
��Auto �60   .+�5.      �� $��2��6(   $��Rejestracja��6<     FontSizeLarge#��[ 5/   $     LatoRegular#��[ 50   $     WordBlueBrush#��[ 51   $   �� 53      $��0��6&   $��1��66   
 � Tag$ Imię��6C     LoginAndRegister#��[ 6N   ��6x   �� *Name+�� 55      $��1��6&   $��1��66   $ Nazwisko��6C   #��[ 6S   ��6}   �� *	Surname+�� 57      $��0��6&   $��2��66   $��2��6C   $ Email��6W   #��[ 6d   ��6�   �� *Email+�� 59      $��0��6&   $��3��66   $ Hasło��6C   #��[ 6P   ��6z   �� *
Password+ �� UpdateSourceTrigger$ PropertyChanged=��� 5;      $��1��6&   $��3��66   $ Powtórz hasło��6C   #��[ 6X   ��6�   �� *PasswordCheck+$ PropertyChanged=��� 5=      -   5        	 ��Name$	 
DateButton��5=   B   $��0��6%   $��4��65     PopupButton#��[ 6V   $��
10,15,5,15q�6�   ��6{   �� *CalendarDateString+
 �� StringFormat$
 {0:dd/MM/yyyy}�� � Triggers 5>   "   :� 5?   &    :� RoutedEvent$ Button.Click��63   [�5@   *   �� 5A   .   .��5B   2   �� .��5C   6   ��  �� 
TargetName$ CalendarPopup��5D   =    �� TargetProperty$ IsOpen�5E   =   .p�5F   :   s�  �� KeyTime$ 0:0:0��6R    �� Value$
 True��6b   5G   7   5H   3   5I   /   5K   '   5M      � 5O      -   5         �Name$ CalendarPopup��5O   $    � 	StaysOpen$ False��6n    � AllowsTransparency$
 True��6�    � PlacementTarget 6;   ��  �� ElementName$ 
DateButton��.��5P   "   ��   CalendarsPopup#��[ 61   5R   #   5S      �� 5U      $��1��6&   $��4��66   $ Numer telefonu��6C   #��[ 6X   ��6�   �� *PhoneNumber+�� 5W      $��0��6$   $��5��64   $��2��6A     	WrongText#��[ 6s   ��6U   �� *	WrongData+6s   �� 5Y      $��0��6%   $��6��65   $��2��6B   $��Zarejestruj się��6V   $��Center=�6p    	 LoginButton#��[	 6�   ��6�   �� *RegisterCommand+5[      5]      �� 5_      #��[	 6   $��Powrót do rezerwacji ��6B   $��Center=�6b   
������ $��0q�6�   ��6�   �� *BackToMainPageCommand+5a      5b      5c      5d      5e      