   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ReviewYourFilmsReviewYourFilms  5      +    %ReviewYourFilms.Authentication.SignIn   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:ma1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:ReviewYourFilms  5      $	��500��5	      $	��400��6     N� Title$  LogIn��5
      .��5      � -   5         �Name$ gridMain��5       � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��50 �6   �� 5      $��1* �6   �� 5      $��60 �6   .+�5   
   �� $��Review Your Films��6   $��38(�6,   $��Center=�6:   $
��Bold"�5      $��Showcard Gothic)�6"   $��0,7,0,0q�6?   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5      �  � Color$	 Red��6#    � Offset$ 0Q�6/   � 5      $ Black��6#   $ 6Q�61   5      5      �� 5   
   
�������$��Sign In��6#   $��1��65   $
��Bold"�5      $��25(�6"   $��25,0,0,0q�60   �� 5   
   $��2��6   $��2��6"   .+�5      �� $	��350��6   $��50��6!   $��5 3 5 5q�6-    �� CornerRadius$ 12��6>   ���#2B2B38._�5!      �� -   5         ��Name$ txtEmail��5!      $��7 0 7 0q�5"      $��0q�6+   $��Center=�6?   $��23(�5#      
�������
������ 	 �� TextAlignment$
	 Left=�5$      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
User Email��6/   5%      �� 5&      $	��350��6   $��50��6!   $��5 7 5 5q�6-   $ 12��6>   ���#2B2B38._�5(      G� -   5         G�Name$ txtPass��5(      $��7 0 7 0q�5)      $��0q�6*   $��Center=�6>   $��23(�5*      
�������
������ $
 Password��5+      5,      �� 5-      $��26q�6   ���#E50914$ 7��66   $��45��5.      ._�5/      �� -   5        
������ $��0q�5/   2   $��Sign In��50      $
��Bold"�51      $��18(�6+   52      54      �� 55   
   $��3��6    �� Orientation$ 
Horizontal=�6"   .+�56      ��    labelDF#��[  6   $��You don't have account?��65   $
��auto��57      �� 58      -   5        $��Sign Up Now��58      $��17(�6)   
�������  textboxNonCarret#��[ 59      $��2 5 0 0q�6@   5:      5;      5<      5=      