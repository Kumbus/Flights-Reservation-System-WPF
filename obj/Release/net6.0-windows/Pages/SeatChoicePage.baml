   M S B A M L   `   `   `  ���� B  >Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjektProjekt      Projekt.SeatChoicePage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:Projekt       N� Title$  SeatChoicePage�� � DataContext %   Projekt.SeatChoicePageViewModel  .���� .���� $��10q�   WordOrangeBrush#��[   �� CornerRadius$ 10��._��  � ColumnDefinitions �� $
��0.3* ��� $
��1.2* ��� $
��0.8* ��� $
��0.6* ��� $
��0.6* ��� $
��0.3* � � RowDefinitions �� $
��0.4* ��� $��5* ��� $��* ��� $
��0.1* �.+��� $��Powrót��  GoBackButton#��[ $	��Top=�$��20q����� *GoBackCommand+�� $N��HC:\Users\jakub\Desktop\Wszechswiat\WPF\Projekt\Images\PlaneToSeatsNB.png��$��1��$��1��$��4��$��1��$��20q���   
NormalText#��[ $��1��$��1��$	��Top=�$��	0,120,0,0q�$��Center=����� *ClassNames[0]+�� #��[ $��2��$��1��$	��Top=�$��	0,120,0,0q�$��Center=����� *ClassNames[1]+�� #��[ $��3��$��1��$	��Top=�$��	0,120,0,0q�$��Center=����� *ClassNames[2]+�� #��[ $��4��$��1��$	��Top=�$��	0,120,0,0q�$��Center=����� *ClassNames[3]+�� $��1��$��1��$��30q����� *EconomySeats+ �� Mode$ TwoWay=�����  �� 
TargetType" ��.R��� $��10q�._��� ���� .R�A�  A� Columns$ 9�� A� Rows$ 8��$��Center=����� .R���   
CheckStyle#��[ $��4q�{��� *Free+	 d� 	IsChecked	 �� *	Clicked+���� 
 �� RelativeSource
 ��  �� AncestorType" �� �� Path$* $DataContext.CheckClickedSeatsCommand����� *Number+�� $��2��$��1������ *PremiumSeats+$ TwoWay=����� " ��.R��� $��10q�._��� ���� .R�A� $ 7��$ 6��$��Center=����� .R��� #��[ $��5q�{��� *Free+	 �� *	Clicked+���� 
 �� " ��$* $DataContext.CheckClickedSeatsCommand����� *Number+�� $��3��$��1������ *BusinessSeats+$ TwoWay=����� " ��.R��� $��10q�._��� ���� .R�A� $ 5��$ 4��$��Center=����� .R��� #��[ $��10q�{��� *Free+	 �� *	Clicked+���� 
 �� " ��$* $DataContext.CheckClickedSeatsCommand����� *Number+�� $��4��$��1������ *
FirstSeats+$ TwoWay=����� " ��.R��� $��10q�._��� ���� .R�A� $ 4��$ 2��$��Center=����� .R��� #��[ $
��0,30q�{��� *Free+	 �� *	Clicked+���� 
 �� " ��$* $DataContext.CheckClickedSeatsCommand����� *Number+��   SearchButton#��[ $��2��$��1��$��3������ *
ButtonText+���� *GoToSummaryCommand+