   M S B A M L   `   `   `  ����J  FReviewYourFilms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ReviewYourFilmsReviewYourFilms  5   	        ReviewYourFilms.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   )localclr-namespace:ReviewYourFilms  5   	   -   5        
������   � AllowsTransparency  .  � Title$ 
MainWindow��5   	   $	��600��6   $
��1350��6)    � WindowStyle$
 None=�66    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyleRed	 �� 
TargetType
 �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%>  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   "	 ��6'   .�5       ��  �@�FocusVisualStyle8   61   �� 5!       � ��8  6+   �� 5"       � ��8  6,   �� 5#       � ��# � ��6+   �� 5$       � ��$ 1q�60   �� 5%       � ��$ Center=�6;   �� 5&       � ��$ Center=�69   �� 5'       � ��$ 1q�6(   �� 5(       � �� 5)      �� 5*      "
 ��6&   .R�5+      �� $ border��6!   #��z��61   #��z��6[   #��z��6�    . ._�5,      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5-       5.      P� 5/       �@��IsDefaulted . . �50   "   �� $ border��6@   # � ��6T    � ��51      P� 52       �@J�IsMouseOver . . �53   "   �� $ border��6?    � ��
 �  ��6S   �� 54   "   $ border��6@   8   � ��6T   55      P� 56       � �� . . �57   "   �� $ border��6?   8   � ��6S   �� 58   "   $ border��6@   8   � ��6T   59      P� 5:       � {� .  . �5;   "   �� $ border��6?   8   � ��6S   �� 5<   "   $ border��6@   8   � ��6T   �� 5=   "   $ contentPresenter��6K   8   � ��6i   5>      5@      5B      5C      5D      .��5E      �� -   5        $ 
mainBorder��5E      $	��0.5q�6!   ���#A3A6AA �� CornerRadius$ 10��5F      ���#202020._�5G   
   �  � RowDefinitions 5H      �� 5I      $��30 �6    �� 5J      $��45 �6    �� 5K      $��1* �6    .+�5M      �� -   5        $��0��5M      ._�5N      � $��33��6   $	��Top=�5O       � ColumnDefinitions 5P      �� 5Q      $��1* �6+   �� 5R      $��30 �6+   �� 5S      $��30 �6+   �� 5T      $��30 �6+   .+�5V      �� $��REVIEW YOUR FILMS��6   $��	10,10,0,0q�5W      ���#A3A6AA$��Normal"�5Y      $	��Top=�5Z      $��Showcard Gothic)�65   �� 5[      -   5        $��1��5[        FontAwesome.WPF.Awesome   Content$ Minus=�5\        defaultButton#��[ 5]      $��0q�5^      $��14(�5_      5a      �� 5b      -   5        $��2��5b      $ SquareOutline=�5c      #��[ 5d      $��0q�5e      $��14(�5f      5h      �� 5i      -   5        #��� 
 5i      $��3��6F   $��X��5j      
������ ���#B2B3B5$
��Bold"�5m      $��0q�5n      $��16(�5o      5q      5r      5s      � 5t      $��1��6   $��	10,0,10,0q�6     5u      �� 5v      $	��150 �6'   �� 5w      �� 5x      $	��250 �6'   �� 5y      $��40 �6'   .+�5{      �� -   5        $��0��5{      $
 Bars=�5|       � Cursor$
 Hand��5}      #��[ 5~      $��0q�5      $��30(�5�      $
��Left=�5�      $��Center=�5�      $��10,0,0,0q�64   $��32��6F   $��28��6R   5�      �� 5�      $��1��6    �� Orientation$ 
Horizontal=�6-   .+�5�      �� $��35��6   $��35��6'   $��Images/loupe.png��63   �� 5�      $	��300��6   $��30��6)   $��5 3 5 5q�65   $ 10��6F   ���#2B2B38._�5�      �� $��6 0 4 0q�5�      $��0q�6/   $��17(�5�      
�������
������  �� TextAlignment$
 Left=�5�      5�      5�      �� 5�      $��2��6   $ 
Horizontal=�6-   $��Right=�6F   .+�5�      A� $��Center=�5�      $��40��65   $��40��6@   ��5�      �� 5�       �� ImageSource$ Images\user.png��6)   -   5        	imgClient��5�   G   5�      �� 5�      -	   5         ��Name$ txtUserN��5�      $��Client��60   ���#E7E9EA  textBoxNoCnH#��[ 5�      $��Center=�6D   $��DemiBold"�5�      $��25(�64   $��5 0 10 0q�6B   5�      � 5�      $��3��6   .+�5�      A� $��40��6   ���#2A2C2E6*   �� 5�      -
   5         ��Name$ 
btnSetting��5�   1   $
 Hand��5�      $ 	CaretDown=�5�      #��[ 5�      $��0q�5�      $��25(�5�      $��3 3 5 0q�6+   $��Center=�5�      $��Center=�5�      $��35��6:   $��35��6F   5�      5�      5�      � 5�      -   5         �Name$ popupBorder��5�   2   $��2��6   $��10 0 0 0q�6    .+�5�      � -   5         �Name$ 	popUpMenu��5�       � 	StaysOpen .  $��RelativePoint=�6=   $
��Left=�5�      $��10 0 0 0q�63    � AllowsTransparency .  � PlacementTarget 5�   2   ��   �� ElementName$  popupBorder��.��5�      �� $��0��6   ���#202020$ 10��6B   $	��160��5�      $	��320��6)   $	��Top=�5�      $	��0.6q�65   $
��Left=�5�        borderRainbow#��[ 5�      ._�5�      �� .+�5�      	� -   5        ! 	�Name$! btnHomeP��5�   *     
menuButton#��[ 5�   *   .��5�   "   �� $ 
Horizontal=�6-   $��45��6F   .+�5�   &   !  FontAwesome.WPF.FontAwesome  "   Icon$
" Home=�65     menuButtonIcon#��[ 5�   5   �� 5�   &   $
��Home��60     menuButtonText#��[ 5�   1   5�   #   5�      	� 5�      -   5        #��[ 5�   *   .��5�   "   �� $ 
Horizontal=�6-   $��45��6F   .+�5�   &     $
" Film=�65   #��[ 5�   5   �� 5�   &   $��
Watch List��60   #��[ 5�   0   5�   #   5�      	� 5�      -   5        #��[ 5�   *   .��5�   "   �� $ 
Horizontal=�6-   $��45��6F   .+�5�   &     $
" Star=�65   #��[ 5�   5   �� 5�   &   $��Top 100��60   #��[ 5�   0   $��Yu Gothic UI)�6X   5�   #   5�      	� 5�      -   5        #��[ 5�   *   .��5�   "   �� $ 
Horizontal=�6-   $��45��6F   .+�5�   &     $" Search=�65   #��[ 5�   9   �� 5�   &   $��
Adv.Search��60   #��[ 5�   4   5�   #   5�      	� 5�      -   5        #��[ 5�   *   .��5�   "   �� $ 
Horizontal=�6-   $��45��6F   .+�5�   &     $" Group=�65   #��[ 5�   9   �� 5�   &   $��Followed��60   #��[ 5�   4   5�   #   5�      5�      5�      5�      5�      �� 5�      -   5        $ secondBorder��5�      ���#181818$��2��5�      $ 	0 0 10 10��6"   ._�5�      �  5�      �� 5�      $��1* �6+   .+�5�      ]� $��0��6    .+�5�       � -   5        #  �Name$# NavHost��5�       $  � NavigationUIVisibility$$ Hidden=�61   $��Stretch=�5�       $��Stretch=�6>   5�      ]� 5�      $	��600��6    $	��400��6,   $��Right=�69   $��	0 0 10 50q�5�       �� 5�      -   5        $��0q�5�      
������ $��0q�6B   $��80��5�      $��80��6(   $
 Hand��64   $��Bottom=�5�      $��Right=�68   $��	0 0 15 15q�5�      .��5�      �� $��\Images\chatbot.png��6    $��6q�6=   ��5�      �� 5�   "   "	 ��6(   % �� Triggers% 5�   &   P� 5�   *    �@J�IsMouseOver . . �5�   .   ��  � ��$ 0q�6G   5�   +   5�   #   5�      5�      �� 5     -   5        $ settingBoard��5     $��Right=�5     $��0 3 10 0q�69   $	��200��5  3   $	��0.3q�5     
�������$ 12��6H   $	��Top=�5     ���#202020._�5     �� .+�5     �� -   5        $ btnUserInfor��5  %   $��40��5  %   $��	10 3 10 5q�61   $
 Hand��6D   ._�5  "   �� $ 
Horizontal=�6-   .+�5	  &   "  FontAwesome.WPF.ImageAwesome  &   Icon$
& Gear=�66   $��30��6B   $��30��6M   '   
Foreground' �#E7E9EA$��	15 0 15 0q�5
  K   �� 5  &   $��User Profile��60   $��18(�6D   ���#E7E9EA$��Center=�5  0   $��DemiBold"�6K   5  #   5     �� 5     -   5        $ 
btnSignOut��5  %   $��40��5  %   $��	10 0 10 0q�61   $
 Hand��6D   ._�5  "   �� $ 
Horizontal=�6-   .+�5  &     $& SignOut=�66   $��30��6E   $��30��6P   ' �#E7E9EA$��	15 0 15 0q�5  K   �� 5  &   $��Sign Out��60   $��18(�6@   ���#E7E9EA$��Center=�5  0   $��DemiBold"�6K   5  #   5     5     5     5     5     5     5     5      