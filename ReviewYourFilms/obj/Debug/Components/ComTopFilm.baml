   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      J FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ReviewYourFilms.ComponentsReviewYourFilms.Components 5      +   %ReviewYourFilms.Components.ComTopFilm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      :local(clr-namespace:ReviewYourFilms.Components     5      -   5        $	��120��5	      $	��800��6   .��5
      �� $��0 0.3 0.3 0.3q�6   ���#B2B3B5._�5   
   �   � ColumnDefinitions  5      �� 5      $��80 �6#   �� 5      $��1* �6#   �� 5      $��60 �6#   .+�5      �� -   5           	styleless#��[  5      $��0q�68   
������ 5   *   �� 5      -   5         ��Name$ 	imgPoster��5   <   $$��\Images\poster_placeholder.png��6   6<   �� 5      $��1��6   $��15 8 0 0q�6)   .+�5      �� -   5         ��Name$ txtTitle��5   %     textboxNonCarret#��[ 5      $��i. Title��5      $
��Bold"�6&   $��0 15 0 0q�68   $��30(�5       �� TextWrapping$ NoWrap=�67   5      �� 5      -   5         ��Name$ sPanel2��5   %    �� Orientation$ 
Horizontal=�5      $��0 5 0 0q�66   .+�5      �� -   5        $ txtDir��5   *     textboxUnderline#��[ 5      $��Director��5      6*   �� 5      $��Stretch=�6    $	��1.5��6<   $��5 2 5 2q�5   (   
�������69   �� 5       -   5        $ txtTime��5!   &   #��[ 5       $
��time��5!      6&   �� 5"      $��Stretch=�6    $	��1.5��6<   $��5 2 5 2q�5#      
�������6-   �� 5$      -   5        $ txtGenre��5%   '   #��[ 5$      $��Genre��5%      6'   �� 5&      $��Stretch=�6    $	��1.5��6<   $��5 2 5 2q�5'      
�������6-   �� 5(      -	   5        $ txtYear��5)   &   #��[ 5(      $
��year��5)      6&   �� 5*      $��Stretch=�6    $	��1.5��6<   $��5 2 5 2q�5+      
�������6-   �� 5,      -
   5        $ txtCate��5-   *   #��[ 5,      $��category��5-      6*   5.      5/      � 50      $��2��6   $��60��6#   $��60��6.   .+�51      A� 
���   �$��55��6'   $��55��62      LiveCharts.Wpf.PieChart  52      &    LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     StartingRotationAngle$ 0Q�61   $��	-10 0 0 0q�53   '      InnerRadius$ 21Q�6:   	   Series	 55         LiveCharts.Wpf.PieSeries  -   5        $��pieHas��55   (      LiveCharts.Wpf.Series
   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$
 80 66      Fill �#21D07A   StrokeThickness$ 0Q�56   ?     57      -   5        $��pieNo��57   (   $
 20 65    �#204529$ 0Q�58   ?   5:      �� 5;      -   5         ��Name$ 
txtPercent��5;   3   $��55��6   $��55��6(   
������ $
��Left=�5=      $��Center=�5>       �� Padding$ 
3.5 10 0 0q�5?      $
��Bold"�5@      $��00��5A       �� TextAlignment$ Center=�6'   
�������$��25(�5B   0   5C      5D      5E      5G      