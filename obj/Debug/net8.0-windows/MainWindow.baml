   M S B A M L   `   `   `  ����  EPCopilot_Deepseek    CopilotChatWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  E&P Copilot��5   	   $	��675��6!   $	��900��6.    � WindowStartupLocation$ CenterScreen=�5   	   ���#F0F0F0 � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� k     '�� �    '�� �    �� 5   
   " ��6   .�5	      ��  � ��$ 14(�6)   �� 5
       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � �� �#018DD26+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ 1q�60   �� 5       � �� �#CCCCCC6,   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5        � ��$
 10,5q�6(   �� 5!       � ��$ 5q�6'   �� 5"       � ��
 �����6+   �� 5#       � ��
 �   �6+   �� 5$       � ��$ 1q�60   �� 5%       � �� �#CCCCCC6,   5&      5'      .��5(      �  � RowDefinitions 5)   
   �� 5*      $
��Auto �6   �� 5+      $��* �6   �� 5,      $
��Auto �6   �� 5-      $
��Auto �6    � ColumnDefinitions 5/   
   �� 50      $��* �6   �� 51      $
��Auto �6   .+�55   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0��6;   $��2��6K   $��10q�6_   .+�56      �� $H��BC:/Users/friedemann.schuetz/EP_Copilot/EPCopilot_Deepseek/logo.png��6   $	��150��6`   $	��150��6l   $��0,0,10,0q�6y   �� 57      $ Vertical=�6   .+�58      �� $!��Willkommen zum E&P Copilot!��6   $��18(�6C   $
��Bold"�6Q   �� 59      $F��@Dieser hilft dir bei der Bearbeitung deiner täglichen Aufgaben.��6   $
��Wrap=�6c   �� 5:      $6��0Der E&P Copilot hat aktuell folgende Funktionen:��6   $
��Wrap=�6X   �� 5;      $%��- Längere Texte zusammenfassen��6   $
��Wrap=�6B   �� 5<      $"��- Kundenfeedback analysieren��6   $
��Wrap=�6@   �� 5=      $4��.- Blogartikel und Social Media Posts schreiben��6   $
��Wrap=�6R   �� 5>      $��- Mails beantworten��6   $
��Wrap=�67   �� 5?      $q��kWähle unten die entsprechende Funktion aus. Darunter kannst du dann deine entsprechende Aufgabe eintragen.��6   $
��Wrap=�6�   �� 5@      $��Viel Spaß!��6   $��Italic$�6.   $
��Wrap=�6A   5A      5B      �� 5E   
   -   5        	 ��Name$	 txtChat��5E      
 �� 
IsReadOnly$

 True��6#   " �� VerticalScrollBarVisibility$
 Auto=�65   $ �� HorizontalScrollBarVisibility$
 Auto=�6X    �� TextWrapping$
 Wrap=�6}   $	��880��6�   $	��555��6�   $��1��6�   $��0��6�   $��2��6�   $��10q�6�   � 5H   
   $��2��6   $��0��6   $��2��6,   $��10q�6@    5I      �� 5J      $
��Auto �6    �� 5K      $��* �6    .+�5M      �� -   5         ��Name$ cmbFunctions��5M      $��0��6-   $��Center=�6:    �� SelectedIndex$ -1��6U   .@�5N      �� $��Funktion auswählen��6    �� 
IsSelected$
 True��6<   ${�False��6N   �� 5O      $ ��Zusammenfassung von Texten��6   �� 5P      $#��Auswertung von Kundenfeedback��6   �� 5Q      $#��Erstellung von Blogbeiträgen��6   �� 5R      $'��!Erstellung von Social Media Posts��6   �� 5S      $��Beantwortung von Mails��6   5T      �� 5U      -   5        $	 txtInput��5U       �� AcceptsReturn$
 True��6(   $
 Auto=�6=   $
 Wrap=�6`   $	��880��6t   $��1��6�   $��Stretch=�6�   $��0,10,0,0q�6�   5V      �� 5Y   
   -   5         ��Name$ btnSend��5Y      $��Senden��6"   $��3��6I   $��0��6V   $��2��6f   $��Center=�6z   $��10q�6�   5Z      5[      