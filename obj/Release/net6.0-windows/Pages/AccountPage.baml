   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.AccountPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Projekt       N� Title$  AccountPage�� � DataContext "   Projekt.AccountPageViewModel  .����    WordOrangeBrush#��[   �� CornerRadius$ 10��$��10q�._�� .+��� $
��Auto=�$
��Auto=�.���� $��Center=� �� TextAlignment$ Center=�$��40q�.+���   ForegroundLightBrush#��[ $ 10�� �� Padding$ 15 50 15 15q�$
��Auto��$	��330��$
��1200��$��0q�._��  � ColumnDefinitions �� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��  	BrandText#��[ $
��Loty���� $��1������ *	Flights+���� .���  �� Property � �� �� Value$ 10q���  � ��# [  	 �� Triggers	 P� 
 P� Property
 �@J�IsMouseOver P� Value$
 True������ .R��  �� $
��0.5* ��� $��0.35* ��� $��* ��� $��0.35* ��� $��* � �� $
��0.1* ��� $
��0.1* ��� $
��0.1* ��� $
��0.1* �.+��� $��5��$��3��#��[  $ 10���� $��0��$��0��$��2��$��10q����� *	Airline+ �� 	Converter )  #Projekt.AirlineToLogoValueConverter  ��   NormalTextBlock#��[ $��30(�$��0��$��1������ *DepartureTime+�� #��[ $��30(�$��0��$��3������ *DestinationTime+�� #��[ $��1��$��1��$	��Top=����� *DeparturePlace+�� #��[ $��1��$��3��$	��Top=����� *DestinationPlace+� $��0��$��2��$
��0,20q�$��2�� �� $��0.01* ��� $��1* �.+��� $��Center=�$��17(����� *	FlyTime+�� $Q��KC:\Users\jakub\Desktop\Wszechswiat\WPF\Projekt\Images\SamolotDoCzasuNB2.png���� $��2��$��5�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Miejsca:��  
NormalText#��[ �� #��[ ���� *BookedSeatsString+�� $��Anuluj rezerwację��  DeleteAccountButton#��[ $��3��$��5������  �� RelativeSource ��  �� AncestorType" �� �� Path$* $DataContext.CancelReservationCommand����� *FlightNumber+�� $��2��#��[ $
��Dane���� $��3��.+��� $ 
Horizontal=�.+��� #��[ $��Imię: ��$��20,0,0,0q��� #��[ ���� *	User.Name+�� $ 
Horizontal=�.+��� #��[ $��
Nazwisko: ��$��20,0,0,0q��� #��[ ���� *User.Surname+�� $ 
Horizontal=�.+��� #��[ $��Email: ��$��20,0,0,0q��� #��[ ���� *
User.Email+�� $ 
Horizontal=�.+��� #��[ $��Hasło: ��$��20,0,0,0q��� #��[ ���� *User.Password+�� $ 
Horizontal=�.+��� #��[ $��Data urodzenia: ��$��20,0,0,0q��� #��[ ���� *User.Birthday+�� $ 
Horizontal=�.+��� #��[ $��Numer telefonu: ��$��20,0,0,0q��� #��[ ���� *User.PhoneNumber+�� $��Usuń konto��#��[ ���� *DeleteAccountCommand+��   LoginButton#��[ $��Powrót do rezerwacji ��$��Center=�
������ $��0q����� *BackToMainPageCommand+