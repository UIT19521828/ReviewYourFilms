   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      J FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ReviewYourFilms.ComponentsReviewYourFilms.Components 5      ,   &ReviewYourFilms.Components.ComListFilm   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:ma1http://materialdesigninxaml.net/winfx/xaml/themes  5      4local(clr-namespace:ReviewYourFilms.Components  5      $
��1200��5
   "   $	��225��5      $��15q�6   .��5      ��   �� CornerRadius$  12��6   $	��0.3q�6   ���#A3A6AA._�5   
   �  � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $��1* �6#   .+�5      �� $  	12 0 0 12��6   ��5      �� 5       �� ImageSource$$ \Images\poster_placeholder.png��6!   -   5        	imgPoster��5   !   ._�5      �� -   5        
������ $��0q�5   2   $	��225��5      6"   5      � 5      $��1��6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      �� 5      $��50 �6$   .+�5       � $��0��6    5!      �� 5"      $��70 �6+   �� 5#      $��1* �6+   �� 5$      $��80 �6+   .+�5&      � $��0��6   $��60��6+   $��60��66   $��10,5,0,5q�6B   .+�5'      A� 
���   �$��55��6/   $��55��6:      LiveCharts.Wpf.PieChart  5(      &    LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     StartingRotationAngle$ 0Q�69   $��	-10 0 0 0q�5)   '      InnerRadius$ 21Q�6:      Series 5+   "      LiveCharts.Wpf.PieSeries  -   5        $��pieHas��5+   0      LiveCharts.Wpf.Series   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 80 6>   	   Fill	 �#21D07A
   StrokeThickness$
 0Q�5,   ?     5-   "   -   5        $��pieNo��5-   0   $ 20 6=   	 �#204529$
 0Q�5.   ?   50      �� 51      -   5         ��Name$ 
txtPercent��57   .   $��55��51   $   $��55��60   
������ $
��Left=�53   $   $��Center=�54   $    �� Padding$ 5 9 0 0q�55   $   $
��Bold"�56   $    �� TextAlignment$ Center=�66   $��00��57   $   
�������$��25(�58   7   59      �� 5:      $��1��6!   $��7 8 0 0q�61   .+�5;      �� -   5         ��Name$ txtTitle��5<   A      textboxNonCarret#��[  5;   "   $��Title��5<   "   $
��Bold"�6/   $��25(�5=   "   60   �� 5>      -   5         ��Name$ sPanel2��5?   %    �� Orientation$ 
Horizontal=�5>   %   $��0 5 0 0q�6>   .+�5@      �� -   5        $ txtDir��5A   6     textboxUnderline#��[ 5@   &   $��Director��5A   &   66   �� 5B      $��Stretch=�6(   $	��1.5��6D   $��5 2 5 2q�5C   (   
�������69   �� 5D      -	   5        $ txtTime��5E   2   #��[ 5D   &   $
��time��5E   &   62   �� 5F      $��Stretch=�6(   $	��1.5��6D   $��5 2 5 2q�5G   (   
�������69   �� 5H      -
   5        $ txtGenre��5I   3   #��[ 5H   &   $��Genre��5I   &   63   �� 5J      $��Stretch=�6(   $	��1.5��6D   $��5 2 5 2q�5K   (   
�������69   �� 5L      -   5        $ txtYear��5M   2   #��[ 5L   &   $
��year��5M   &   62   �� 5N      $��Stretch=�6(   $	��1.5��6D   $��5 2 5 2q�5O   (   
�������69   �� 5P      -   5        $ txtCate��5Q   6   #��[ 5P   &   $��category��5Q   &   66   5R      5S      5U      �� 5V      -   5        $ txtDescript��5X       �� TextWrapping$
 Wrap=�5V        textBoxNoCnH#��[ 6.   $��
15 15 15 5q�5W      $��1��6.   $��overview��6;   $��18(�5X   /   $��Regular"�6=   �� 5Y      $��2��6   $��Center=�6*   $��15 0 0 0q�6E   $ 
Horizontal=�5Z      .+�5[      � -   5         �Name$ myRate��5[      $��30��6+   $��30��66   $y�	Collapsed=�6B   .+�5\      A� -   5         A�Name$ fillE��5\   2   ���#21D07A�� 5]      -   5        $ 	txtMyRate��5]   E   $��-1��6$   $ Center=�6.   $
��Bold"�5^   $   
�������$��19(�5_   $   $��0 -2 0 0q�62   $��Center=�5`   $   5a      '  !MaterialDesignThemes.Wpf.PackIcon  5c      -   5          Name$ tempRate��5d   7      Kind$ 
StarCircle=�5c   "   $��35��64   $��35��6?   ���#A3A6AA5d   7   �� 5e      #��[ 6   $��0 2 20 0q�5f      ���#A3A6AA$��Your rating��5g      $��DemiBold"�61   $��Center=�6G   $��17(�5h      �� 5i      -   5          	styleless#��[ 5i      
������  � Cursor$
 Hand��5j      $��0q�6+   .��5k        $ RemoveCircleOutline=�6&   $��37��6A   $��37��6L   ���#A3A6AA5l   "   5m      �� 5o      #��[ 6   $��0 2 0 0q�5p      ���#A3A6AA$��Remove��5q      $��DemiBold"�6,   $��Center=�6B   $��17(�5r      5s      5t      5v      5w      5y      