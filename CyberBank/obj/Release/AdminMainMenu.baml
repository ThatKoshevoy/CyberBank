   M S B A M L   `   `   `  ���� D  @CyberBank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CyberBank	CyberBank      CyberBank.AdminMainMenu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:CyberBank     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .��� ����   �� EndPoint$  0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFA8A8A8�� � Offset$ 0.124Q�� $ White��$ 1Q�.+��� -    ��Name$ credit��$y�Hidden=�$
��Left=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$3 -Логин кому выдать кредит��$��44��$��291,136,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��642�����	#FFCDCDCD���	#89000000$��30(�$��Arial)�$
��Bold"�$��Italic$����	#FF424242 �� TextDecorations Z� �� -    ��Name$ Users_border��$y�Visible=�	 �� CornerRadius$	 30��$��1q�$	��389��$��291,224,76,0q�$	��Top=����	#FFFF8000._�&   System.Windows.Controls.DataGrid  -   
  Name$
 DataGrid��
���   ����	#FFFF8000$��	1,0,-1,12q� J� RenderTransformOrigin$ 0.5,0.5&���Z� z�V� .~��� �� ��  �� Angle$ -0.15Q�T�    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ ID�   ClipboardContentBinding Z�   $ 
Логин�� �� $ Username� Z�   $ Имя�� �� $
 Name� Z�   $ Дата рождения�� �� $	 dob� Z�   $- 'Есть дебетовая карта?�� �� $
 card� Z�   $- 'Есть кредитная карта?�� �� $ credit� Z�   $  Сумма на карте�� �� $ value� Z�   $ Роль�� �� $
 Role� Z� �� -   $ Credit_border��$y�Hidden=�$	 30��$��1q�$	��389��$��291,224,76,0q�$	��Top=����	#FFFF8000._�  -   $
 CreditDataGrid��
���   ����	#FFFF8000$��	1,0,-1,12q�$ 0.5,0.5&���Z� z�V� .~��� �� �� $ -0.15Q�T�    $ Описание�� �� $
 Desc� Z�   $ 
Логин�� �� $ Username� Z�   $ Имя�� �� $
 Name� Z�   $ email�� �� $ email� Z�   $  Денег на счете�� �� $ value� Z�   $# Сколько требует�� �� $ 
value_need� Z� �� -    ��Name$ user_datagrid��$��Пользователи��$��290,82,808,0q�$	��Top=����	#FFFF8000$��47����Z� �� -   $ credit_datagrid��$$��Заявки на кредит��$��502,82,596,0q�$	��Top=����	#FFFF8000$��47����Z� �� -   $ credit_button��$y�Hidden=�$��929,134,206,0q�$��Выдать кредит��$	��Top=����	#FFFF8000$��47����Z� �� -	    ��Name$ success��$�� ��$
��Left=�$��330,192,0,0q�$	��Top=��� $��1q�$
��Left=�$	��325��$��258,263,0,0q�$	��Top=�$	��924������  �� Color$ 	#FC000000�� �� Opacity$ 0Q�