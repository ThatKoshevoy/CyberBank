   M S B A M L   `   `   `  ����D  @CyberBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CyberBank	CyberBank  5          CyberBank.MainMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      #localclr-namespace:CyberBank  5      .��5
      � -   5          �Name$  MainMenuGrid��5
      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFA8A8A8��6    � Offset$ 0.124Q�61   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ to_trans_button��5      $��Перевод��6+   $
��Left=�6>   $��369,214,0,0q�6Y   $	��Top=�6n   $	��315��6�   $��46��6�   $��Arial)�6�   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   ���	#FFFF8000��6�   Z� 6  �� 5   
   -   5        $ credit_button��5      $��Кредит��6(   $
��Left=�6:   $��369,290,0,0q�6U   $	��Top=�6j   $	��316��6�   $��46��6�   $��Arial)�6�   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   ���	#FFFF8000��6�   Z� 6  �� 5   
   -   5        $ admin_button��5      $(��"Администрирование��6'   $
��Left=�6D   $��946,214,0,0q�6_   $	��Top=�6t   $	��316��6�   $��46��6�   $��Arial)�6�   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   ���	#FFFF8000��6  Z� 6  �� 5   
    �� CornerRadius$ 30��6   $��1q�6#   $
��Left=�67   $��87��6R   $��252,622,0,0q�6^   $	��Top=�6s   $	��968��6�   ���	#FF3F3F3F._�5      �� $��
19,9,19,10q�6   .+�5      �� $
��Wrap=�6   $5��/Новости (Источник: Медуза)��60   ���	#FFB6B2AE$��16(�6i   $��25��6x   $��Whitney)�6�   �� 5      -   5         ��Name$
 news��5      $
��Wrap=�6*   $�� ��6>   $��16(�6F   $��45��6T   $��Whitney)�6`   ���	#FFB6B2AE6u   5      5       � 5   
   -   5          �Name$ 	frontcard��5      $
��Left=�6#   $	��278��6>   $��732,336,0,0q�6K   $	��Top=�6`   $	��530��6x   ��5       �� 5!      	 �� ImageSource$	 cardwithout.png��6   5#      �� 5$   
   -   5        
 ��Name$
 cardnumber_on_card��5$      $��8141 4992 0474 8232��6,   $
��Left=�6J   $��772,495,0,0q�6e   $	��Top=�6z   $��68��6�   $	��481��6�   $��48(�6�   $��Gadugi)�6�   $��ExtraCondensed&�6�   &   System.Windows.Media.TextOptions   TextHintingMode$ Fixed=�6�   
���������6�   Z�  J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         Color$ 	#FF424242��6#      ShadowDepth$ 10Q�65      
BlurRadius$ 4Q�6F   5(      �� 5)   
   -   5        $
 cardholder_name_on_card��5)      $��VLADISLAV STOLNIKOV��61   $
��Left=�6O   $��775,556,0,0q�6j   $	��Top=�6   $��36(�6�   $��Candara)�6�   $
��Bold"�6�   
�������$	��475��6�    5*        5+      $ 	#FF424242��6#   $ 10Q�65   $ 4Q�6F      RenderingBias$ Quality=�6U   5-       � 5.   
   -	   5        $ backcard��5.      $
��Left=�6"   $y�Hidden=�6=   $	��Top=�6Q   $	��278��6i   $��732,336,0,0q�6v   $	��530��6�   ��5/      �� 50      $	 backcard.png��6   52      �� 53   
   -
   5        $ reverse��53      $
��Left=�6#   $��631,462,0,0q�6>   $	��Top=�6S   $��95��6k   $��36��6�   ��6v   Z� ��6�   Z� .��55      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Eye=�6&   $��29��61   $��50��6=   ���	#FF8787876H   56      �� 57   
   $��Show CVV��6   $
��Left=�6#   $��645,438,0,0q�6>   $	��Top=�6S   $
��Bold"�6k   $��Whitney)�6}   ���	#FF8787876�   �� 58   
   -   5        $
 cvv_on_card��58      $y�Hidden=�6%   $	��888��69   $
��Left=�6G   $��1064,437,0,0q�6b   $	��Top=�6x   $��Italic$�6�   $	��109��6�   $��18(�6�   ���	#DD4B4B4B��6�   Z� 6�   5:      5;      