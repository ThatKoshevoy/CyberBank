   M S B A M L   `   `   `  ���� D  @CyberBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CyberBank	CyberBank      CyberBank.MainMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  #localclr-namespace:CyberBank  .��� -     �Name$  MainMenuGrid������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFA8A8A8�� � Offset$ 0.124Q�� $ White��$ 1Q�.+��� -    ��Name$ to_trans_button��$��Перевод��$
��Left=�$��369,214,0,0q�$	��Top=�$	��315��$��46��$��Arial)�$
��Bold"�$��Italic$�$��16(����	#FFFF8000��Z� �� -   $ credit_button��$��Кредит��$
��Left=�$��369,290,0,0q�$	��Top=�$	��316��$��46��$��Arial)�$
��Bold"�$��Italic$�$��16(����	#FFFF8000��Z� �� -   $ admin_button��$(��"Администрирование��$
��Left=�$��946,214,0,0q�$	��Top=�$	��316��$��46��$��Arial)�$
��Bold"�$��Italic$�$��16(����	#FFFF8000��Z� ��  �� CornerRadius$ 30��$��1q�$
��Left=�$��87��$��252,622,0,0q�$	��Top=�$	��968�����	#FF3F3F3F._��� $��
19,9,19,10q�.+��� $
��Wrap=�$5��/Новости (Источник: Медуза)�����	#FFB6B2AE$��16(�$��25��$��Whitney)��� -    ��Name$
 news��$
��Wrap=�$�� ��$��16(�$��45��$��Whitney)����	#FFB6B2AE � -     �Name$ 	frontcard��$
��Left=�$	��278��$��732,336,0,0q�$	��Top=�$	��530������ 	 �� ImageSource$	 cardwithout.png���� -   
 ��Name$
 cardnumber_on_card��$��8141 4992 0474 8232��$
��Left=�$��772,495,0,0q�$	��Top=�$��68��$	��481��$��48(�$��Gadugi)�$��ExtraCondensed&�&   System.Windows.Media.TextOptions   TextHintingMode$ Fixed=�
���������Z�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF424242��   ShadowDepth$ 10Q�   
BlurRadius$ 4Q��� -   $
 cardholder_name_on_card��$��VLADISLAV STOLNIKOV��$
��Left=�$��775,556,0,0q�$	��Top=�$��36(�$��Candara)�$
��Bold"�
�������$	��475��   $ 	#FF424242��$ 10Q�$ 4Q�   RenderingBias$ Quality=� � -	   $ backcard��$
��Left=�$y�Hidden=�$	��Top=�$	��278��$��732,336,0,0q�$	��530������ $	 backcard.png���� -
   $ reverse��$
��Left=�$��631,462,0,0q�$	��Top=�$��95��$��36����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Eye=�$��29��$��50�����	#FF878787�� $��Show CVV��$
��Left=�$��645,438,0,0q�$	��Top=�$
��Bold"�$��Whitney)����	#FF878787�� -   $
 cvv_on_card��$y�Hidden=�$	��888��$
��Left=�$��1064,437,0,0q�$	��Top=�$��Italic$�$	��109��$��18(����	#DD4B4B4B��Z� 