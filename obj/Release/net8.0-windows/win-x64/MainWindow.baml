   M S B A M L   `   `   `  ����   EPCopilot_Deepseek    CopilotChatWPF.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  E&P Copilot��$	��675��$	��900�� � WindowStartupLocation$ CenterScreen=����#F0F0F0 � 	Resources  �� 
TargetType �� Property �� Value��%z  '��       '�� 8     '�� �     '�� �    �� " ��.���  � ��$ 14(���  � ��$ 5q��� " ��.���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 5q���  � �� �#018DD2��  � ��
 �������  � ��$ 0q���  �@�Cursor$
 Hand���� " ��.���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 5q���  � ��
 �������  � ��
 �   ���  � ��$ 1q���  � �� �#CCCCCC�� " ��.���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 5q���  � ��
 �������  � ��
 �   ���  � ��$ 1q���  � �� �#CCCCCC.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��0��$��0��$��2��$��10q�.+��� $H��BC:/Users/friedemann.schuetz/EP_Copilot/EPCopilot_Deepseek/logo.png��$	��150��$	��150��$��0,0,10,0q��� $ Vertical=�.+��� $!��Willkommen zum E&P Copilot!��$��18(�$
��Bold"��� $F��@Dieser hilft dir bei der Bearbeitung deiner täglichen Aufgaben.��$
��Wrap=��� $6��0Der E&P Copilot hat aktuell folgende Funktionen:��$
��Wrap=��� $%��- Längere Texte zusammenfassen��$
��Wrap=��� $"��- Kundenfeedback analysieren��$
��Wrap=��� $4��.- Blogartikel und Social Media Posts schreiben��$
��Wrap=��� $��- Mails beantworten��$
��Wrap=��� $q��kWähle unten die entsprechende Funktion aus. Darunter kannst du dann deine entsprechende Aufgabe eintragen.��$
��Wrap=��� $��Viel Spaß!��$��Italic$�$
��Wrap=��� -   	 ��Name$	 txtChat��
 �� 
IsReadOnly$

 True��" �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�$	��880��$	��555��$��1��$��0��$��2��$��10q�� $��2��$��0��$��2��$��10q� �� $
��Auto ��� $��* �.+��� -    ��Name$ cmbFunctions��$��0��$��Center=� �� SelectedIndex$ -1��.@��� $��Funktion auswählen�� �� 
IsSelected$
 True��${�False���� $ ��Zusammenfassung von Texten���� $#��Auswertung von Kundenfeedback���� $#��Erstellung von Blogbeiträgen���� $'��!Erstellung von Social Media Posts���� $��Beantwortung von Mails���� -   $	 txtInput�� �� AcceptsReturn$
 True��$
 Auto=�$
 Wrap=�$	��880��$��1��$��Stretch=�$��0,10,0,0q��� -    ��Name$ btnSend��$��Senden��$��3��$��0��$��2��$��Center=�$��10q�