   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ReviewYourFilmsReviewYourFilms  5      +    %ReviewYourFilms.Authentication.SignUp   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:ma1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:ReviewYourFilms  5      $	��500��5	      $	��400��6     N� Title$  SignIn��5
      .��5      � -   5         �Name$ gridSU��5       � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��50 �6   �� 5      $��1* �6   �� 5      $��60 �6   .+�5   
   �� $��Review Your Films��6   $��38(�6,   $��Center=�6:   $
��Bold"�5      $��Showcard Gothic)�6"   $��0,7,0,0q�6?   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5      �  � Color$	 Red��6#    � Offset$ 0Q�6/   � 5      $ Black��6#   $ 6Q�61   5      5      �� 5   
   
�������$��Sign Up��6#   $��1��65   $
��Bold"�5      $��25(�6"   $��25,0,0,0q�60   �� 5   
   $��2��6   $��2��6"   .+�5      �� $	��350��6   $��50��6!   $��5 3 5 5q�6-    �� CornerRadius$ 12��6>   ���#2B2B38._�5!      �� -   5         ��Name$ txtEmail��5!      $��7 0 7 0q�5"      $��0q�6*   $��Center=�6>   $��23(�5#      
�������
������ 	 �� TextAlignment$
	 Left=�5$      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
User Email��6.   5%      �� 5&      $	��350��6   $��50��6!   $��5 3 5 5q�6-   $ 12��6>   ���#2B2B38._�5(      �� -   5        $ txtNickname��5(      $��7 0 7 0q�5)      $��0q�6+   $��Center=�6?   $��23(�5*      
�������
������ $
	 Left=�5+      $
 Nickname��6/   5,      �� 5-      $	��350��6   $��50��6!   $��5 3 5 5q�6-   $ 12��6>   ���#2B2B38._�5/      G� -   5         G�Name$ txtPass��5/      $��7 0 7 0q�50      $��0q�6*   $��Center=�6>   $��23(�51      
�������
������ $
 Password��52      53      �� 54      $	��350��6   $��50��6!   $��5 3 5 5q�6-   $ 12��6>   ���#2B2B38._�56      G� -   5        $ 	txtRePass��56      $��7 0 7 0q�57      $��0q�6*   $��Center=�6>   $��23(�58      
�������
������ $
 Repeat Password��59      5:      �� 5;      $��26 10 26 26q�6   ���#E50914$ 7��6?   $��45��5<      ._�5=      �� -   5        
������ $��0q�5=   2   $��Sign Up��5>      $
��Bold"�6+   $��18(�5?   .   5@      5B      �� 5C   
   -   5        $��3��5C         	styleless#��[  6   
������ $��40��5D   *   $��40��65   $��Right=�5E       � Cursor$
 Hand��6-   .��5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�5H      $��40��6"   $��40��6-   ���#A3A6AA69   5I      5K      5L      