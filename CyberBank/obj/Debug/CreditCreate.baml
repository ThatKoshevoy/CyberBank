   M S B A M L   `   `   `  ����D  @CyberBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CyberBank	CyberBank  5          CyberBank.CreditCreate   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:CyberBank     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ��5
      �� 5   
     �� EndPoint$  0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFA8A8A8��6    � Offset$
 0.12Q�6-   � 5      $ White��6   $ 1Q�6)   5      .��5      � .+�5   
   �� $4��.Оформить кредитную карту��6   $
��Left=�63   $��591,171,0,0q�6N   $	��Top=�6c   $��22(�6{   $
��Bold"�6�   $��Whitney)�6�   �� 5   
    �� CornerRadius$ 10��6   
���   �$��1q�67   $
��Left=�6K   $	��103��6f   $��552,249,0,0q�6s   $	��Top=�6�   $	��400��6�   
�������._�5      �� -   5         ��Name$ description_creditcreate��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Описание��6:    �� TextWrapping$
 Wrap=�6d   $��7,4,6,0q�6x   $��14(�6�   ���	#FF7474746�   5      �� 5   
   $.��(Опишите зачем вам она.��6   $��261,246,744,0q�61   $	��Top=�6H   $��22(�6`   $
��Bold"�6n   $��Whitney)�6�   �� 5   
   $1��+Введите желаемую сумму.��6   $��238,365,741,0q�62   $	��Top=�6I   $��22(�6a   $
��Bold"�6o   $��Whitney)�6�   �� 5   
   $ 10��6   
���   �$��1q�67   $
��Left=�6K   $��30��6f   $��552,368,0,0q�6r   $	��Top=�6�   $	��400��6�   
�������._�5      �� -   5        $ value_creditcreate��5      $ 
Сумма��63   $
 Wrap=�6Z   $�� ��6n   $��7,-1,6,0q�6v   $��14(�6�   ���	#FF9E9999 �� SelectionBrush 6�   Z� 	 �� 
CaretBrush	 6�   Z� ��6�   Z� ��6�   Z� 5      �� 5   
   $ 10��6   
���   �$��1q�67   $
��Left=�6K   $��30��6f   $��552,437,0,0q�6r   $	��Top=�6�   $	��400��6�   
�������._�5      �� -   5        $ email_creditcreate��5      $ email��63   $
 Wrap=�6Z   $�� ��6n   $��7,-1,6,0q�6v   $��14(�6�   ���	#FF9E9999 6�   Z� 	 6�   Z� ��6�   Z� ��6�   Z� 5      �� 5   
   $��Введите e-mail.��6   $��360,434,745,0q�6*   $	��Top=�6A   $��22(�6Y   $
��Bold"�6g   $��Whitney)�6y   �� 5   
   -   5        
 ��Name$
 create_credit_button��5      $��Оформить��6/   $
��Left=�6C   $��580,519,0,0q�6^   $	��Top=�6s   $	��344��6�   $��46��6�   $��Arial)�6�   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   ���	#FFFF8000��6   Z� 6  �� 5    
   -   5         ��Name$ success��5       $�� ��6!   $
��Left=�6,   $��445,122,0,0q�6G   $	��Top=�6\   $��24(�6t   $
��Bold"�6�   5"      5#      