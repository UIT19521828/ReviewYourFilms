   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ReviewYourFilms.ComponentsReviewYourFilms.Components  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      (    "ReviewYourFilms.Components.ComFilm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:ReviewYourFilms.Components     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      $	��360��5	      $	��200��6   $��0 0 20 0q�6'   .��5
      �   � RowDefinitions  5   
   �� 5      $	��300 �6   �� 5      $��15 �6   �� 5      $��1* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 12��6    � Cursor$
 Hand��60      	borderBig#��[  5      ��5      �� 5      -   5        	imgPoster�� j� Stretch$
 Fill=�5       �� ImageSource$$ \Images\poster_placeholder.png��5      ._�5      �� -   5        
������ $��0q�5   .   $	��300��5      6"   5      � 5   
   $��1��6   .+�5      �� $��40��6   $��40��6!   $ 40��6,   
���   �$
��Left=�5      $��Center=�5      $��
12 -24 0 0q�5       ._�5!        LiveCharts.Wpf.PieChart  &   LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     StartingRotationAngle$ 0Q�61   $��Center=�5"      $��Center=�5#         InnerRadius$ 17Q�5$      $��
0 0 0 -1.5q�5%         Series 5'        LiveCharts.Wpf.PieSeries  -   5        	  Name$	 pieHas��5'   (     LiveCharts.Wpf.Series
   Values;  5LiveCharts.Wpf.Converters.NumericChartValuesConverter$
 15 68      Fill �#21D07A   StrokeThickness$ 0Q�5(   (     5)      -   5        $	 pieNo��5)   (   $
 4 67    �#204529$ 0Q�5*   (   5,      5-      �� 5.      -   5         ��Name$ 
txtPercent��55      $��40��5.      $��40��6$   
������ $
��Left=�50      $��Center=�51       �� TextAlignment$ Center=�52      $��
12 -24 0 0q�6/   $
��Bold"�53      $��0��6*    �� Padding$ 0 5 0 0q�54      
�������$��22(�56   +   57      �� 58   
   -   5         ��Name$ txtTitle��59   #   $��2��58      $��Title��6     textboxNonCarret#��[ 6,   $��2 0 0 0q�59      $��15(�65    �� TextWrapping$
 Wrap=�6C   5;      5<      