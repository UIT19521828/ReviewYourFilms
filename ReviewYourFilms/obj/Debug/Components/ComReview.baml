   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ReviewYourFilms.ComponentsReviewYourFilms.Components  5      *    $ReviewYourFilms.Components.ComReview   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      4local(clr-namespace:ReviewYourFilms.Components  5      $	��400��5	   #   $��0 5 5 5q�63   $	��800��5
      .��5      �� -   5          ��Name$  borderComment��5       �� CornerRadius$ 12��6$   $	��0.5q�66   ���#A3A6AA._�5   
   �  � ColumnDefinitions 5      �� 5      -   5         ��Name$ column1��5   .   $��80 �6#   6.   �� 5      $��1* �6#   .+�5      A� -   5        $��0��5      $��64��6&   $��64��61   $	��Top=�5      $��Right=�5       � Cursor$
 Hand��6.   $��0 10 0 0q�5      ��5      �� 5      -   5        imgReviewer�� �� ImageSource$ \Images\user.png��5   6   5      � 5      $��1��6   $��10 0 0 0q�6#    � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��1* �6$   �� 5      $��40 �6$   .+�5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"      �� -   5         ��Name$ txtTitle��5#      $��Title��5"      $��20(�6+   $
��Bold"�69   	 �� 
IsReadOnly	 . $	��430��5#   0      textBoxNoCnH#��[  6?   
�������$��Center=�5$   1   $��	3.5 0 0 0q�5%      �� 5&      $��10 0 0 0q�6   $��30��6/   $ 10��6;   ���#242424._�5(      �� $ 
Horizontal=�6%   .+�5)      "  FontAwesome.WPF.ImageAwesome  
   Icon$

 Star=�6.   $��22��6:   $��22��6E      
Foreground �#F5C518$��15 0 5 0q�5*   ?   �� 5+      -   5         ��Name$ txtScore��5-   5   $��0��5+   $   $��16(�60   $��SemiBold"�6>   
�������$��Center=�5,   7   $��0 0 5 0q�5-   $   65   5.      5/      50      �� 51      -   5         ��Name$ 
rtbContent��51   9   $��1��6   $
��Auto��6+   " �� VerticalScrollBarVisibility$ Hidden=�52        rtbNoCaretH#��[ 53      	 . 6C   �� 54      $ 
Horizontal=�6   $��Right=�66   $��2��55      $��0 0 10 0q�6*   .+�56      �� -   5        $ txtFilmTitle��59   5     textboxNonCarret#��[ 56      $��15(�57      $��Title��6,   ���#B2B3B5$��Center=�58      $��
0 1.5 10 0q�69   $y�	Collapsed=�59      5:      �� 5;      -	   5         ��Name$ btnLike��5;   -   $��0��6     FontAwesome.WPF.Awesome   Content$ ThumbsUp=�5<      $
 Hand��5=        defaultButton#��[ 5>      $��0q�5?      $��28(�5@      $
��Left=�5A      $��Center=�5B      $��10,0,5,5q�64   $��32��6F   $��28��6R   �� 5D      -
   5        $ txtLike��5F      #��[  5D      $��Center=�5E      $��0 0 15 0q�5G      $��0��60   $��14(�5H      
�������6,   �� 5J      -   5        $ btnDis��5L   '   $��0��5J      $ 
ThumbsDown=�5K      $
 Hand��5L      #��[ 5M      $��0q�5N      $��28(�5O      $
��Left=�5P      $��Center=�5Q      $��10,0,5,0q�64   $��32��6F   $��28��6R   �� 5S      -   5        $ txtDis��5U      #��[  5S      $��Center=�5T      $��0 0 15 0q�5V      $��0��60   $��14(�5W      
�������6,   �� 5Y      $��written by:��6   
�������$��Center=�5Z      $��0 -1 0 0q�67   �� 5[      -   5        $ txtReviewer��5\      #��[ 5[      $��Reviewer��5]      $��Center=�6.   $	��150��6I   $��SemiBold"�5^      $��14(�64   5_      5`      5a      5b      5d      