   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.SummaryPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Projekt       N� Title$  SummaryPage�� � DataContext "   Projekt.SummaryPageViewModel  .���� .���� $��10q�   WordOrangeBrush#��[   �� CornerRadius$ 10��._��  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $
��0.1* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��0.1* �.+��� $��Powrót��  GoBackButton#��[ $	��Top=�$��20q�$
��Left=����� *GoBackCommand+�� $��Podsumowanie��  	BrandText#��[ $��0��$��4��$��Center=�$	��Top=�$��80(��� $��1��$��1��$��2�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Lot z: ��  
NormalText#��[ $��40(��� #��[ $��40(�$��SemiBold"����� *MyFlight.DeparturePlace+�� $�� do: ��#��[ $��40(��� #��[ $��40(�$��SemiBold"����� *MyFlight.DestinationPlace+�� $��0��$��2��$��4��$ 
Horizontal=�$��Center=�.+��� $��Data: ��#��[ $��40(��� #��[ $��40(�$��SemiBold"����� *MyFlight.Date+�� $��
 Godziny: ��#��[ $��40(��� #��[ $��40(�$��SemiBold"����� *MyFlight.DepartureTime+�� $	�� - ��#��[ $��40(�$��SemiBold"��� #��[ $��40(�$��SemiBold"����� *MyFlight.DestinationTime+�� $��Miejsca:��#��[ $��40(�$��0��$��3��$��4��$��Center=��� $��0��$��4��$��4��$��Center=�$	��Top=����� *Seats+���� .R��� $��Center=����� .R��  �� $
��2.2* ��� $
��1.1* �.+��� $ 
Horizontal=�.+��� $��Klasa podróży: ��#��[ $��30(��� #��[ $��30(�$��SemiBold"����� *Class+�� $ 
Horizontal=�$��1��.+��� $��  Numer fotela: ��#��[ $��30(��� #��[ $��30(�$��SemiBold"����� *Number+�� $��0��$��5��$��4��$��Center=�$��20q�$ 
Horizontal=�.+��� $��Cena:��#��[ $��40(��� #��[ $��40(�$��SemiBold"����� *StringPrice+�� $��Przejdź do płatności��  SearchButton#��[ $��1��$��6��$��2������ *GoToPaymentPageCommand+