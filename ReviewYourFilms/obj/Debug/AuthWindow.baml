   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ReviewYourFilmsReviewYourFilms  5   	        ReviewYourFilms.AuthWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:ma1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   )localclr-namespace:ReviewYourFilms  5   	   
������   � AllowsTransparency  .  � Title$ LoginWindow��5	   	   $	��700��6   $	��600��6*    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�6   .��5      ��  �� CornerRadius$ 12��6   ��5   
   �� 5       �� ImageSource$" \Images\login_background.png��6   ._�5   
   �  � RowDefinitions 5      �� 5      $��35 �6    �� 5      $
��387* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5           	styleless#��[  5      $��0q�5      
������ .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6"   $��30��68   $��30��6C   ���#303134	 � Cursor$
	 Hand��5   7   5      �� 5      -   5        #��[  5      $��0q�5      
������ .��5        $ CloseCircle=�6"   $��30��65   $��30��6@   ���#AA0101$
	 Hand��5   7   $��4 0 4 0q�6E   5      5       �� 5!      $��1��6   $��Center=�6"   $��Center=�6=   $	��400��5"      $	��500��6!   $��	0 -35 0 0q�6.   
���   �
 J� Opacity$	
 0.5Q�5#   (   $ 12��66   5$       � 5%      -   5          �Name$ 	frameAuth��5%      $��1��6'   $	��400��64   $	��500��6@   $��	0 -35 0 0q�5&        � NavigationUIVisibility$ Hidden=�6'   5'      5(      5)      