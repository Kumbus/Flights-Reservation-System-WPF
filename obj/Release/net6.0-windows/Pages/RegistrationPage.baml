   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.RegistrationPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Projekt       N� Title$  RegistrationPage�� � DataContext '   !Projekt.RegistrationPageViewModel  .����    WordOrangeBrush#��[   �� CornerRadius$ 10��$��10q�._�� .+��� $
��Auto=�$
��Auto=�.���� $��Center=� �� TextAlignment$ Center=�$��40q�.+���   ForegroundLightBrush#��[ $ 10�� �� Padding$ 15 50 15 15q�$
��Auto��$	��330��$	��600��$��0q�._��  � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��2��$��Rejestracja��  FontSizeLarge#��[   LatoRegular#��[   WordBlueBrush#��[ �� $��0��$��1��
 � Tag$ Imię��  LoginAndRegister#��[ ���� *Name+�� $��1��$��1��$ Nazwisko��#��[ ���� *	Surname+�� $��0��$��2��$��2��$ Email��#��[ ���� *Email+�� $��0��$��3��$ Hasło��#��[ ���� *
Password+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��3��$ Powtórz hasło��#��[ ���� *PasswordCheck+$ PropertyChanged=��� -   	 ��Name$	 
DateButton��$��0��$��4��  PopupButton#��[ $��
10,15,5,15q����� *CalendarDateString+
 �� StringFormat$
 {0:dd/MM/yyyy}�� � Triggers :�  :� RoutedEvent$ Button.Click��[��� .���� .����  �� 
TargetName$ CalendarPopup�� �� TargetProperty$ IsOpen�.p�s�  �� KeyTime$ 0:0:0�� �� Value$
 True��� -    �Name$ CalendarPopup�� � 	StaysOpen$ False�� � AllowsTransparency$
 True�� � PlacementTarget ��  �� ElementName$ 
DateButton��.����   CalendarsPopup#��[ �� $��1��$��4��$ Numer telefonu��#��[ ���� *PhoneNumber+�� $��0��$��5��$��2��  	WrongText#��[ ���� *	WrongData+�� $��0��$��6��$��2��$��Zarejestruj się��$��Center=� 	 LoginButton#��[	 ���� *RegisterCommand+�� #��[	 $��Powrót do rezerwacji ��$��Center=�
������ $��0q����� *BackToMainPageCommand+