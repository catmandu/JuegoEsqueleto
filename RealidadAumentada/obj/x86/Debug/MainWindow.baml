   M S B A M L   `   `   `  ����  RealidadAumentada"    RealidadAumentada.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Microsoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Kinect.Toolkit.Controls, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5   	     � Title$  
MainWindow��5   	   $	��365��6   $	��500��6)    � WindowStyle$
 None=�5   	    � WindowState$ 	Maximized=�5   	   .��5      � .+�5	   
   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5        $��kinectRegion��5	      .��5
      � .+�5      � -   5        $��	principal��5       � ColumnDefinitions 5      �� 5      $	��.5* �6+   �� 5      $	��.5* �6+    � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   .+�5      �� -   5        $��lblMenu��5   B   $��0��6   $��Center=�6%   .��6Q   MENU6W   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5      -   5        $��btnJugar��5   i   $��1��6)   
������ 
������ .��5      �� $��img/jugar.png��6   $
��Fill=�64   5         5"      -   5        $��btnOpciones��5"   i   $��2��6)   
������ 
������ .��5#      �� $��img/opciones.png��6   $
��Fill=�66   5$        5&      -   5        $��btnCreditos��5&   i   $��3��6)   
������ 
������ .��5'      �� $��img/creditos.png��6   $
��Fill=�66   5(        5*      -   5        $��btnSalir��5*   j   $��4��6)   
������ 
������ .��5+      �� $��img/salir.png��6   $
��Fill=�63   5,      �� 5.      $��1��6   $��5��6,   $��img/esqueleto.gif��6=   5/      � 52      -   5        $��	preguntas��52      $y�Hidden=�6$    54      �� 55      $
��.25* �6+   �� 56      $
��.25* �6+   �� 57      $	��.5* �6+    5:      �� 5;      $
��.18* �6(   �� 5<      $
��.18* �6(   �� 5=      $
��.18* �6(   �� 5>      $
��.18* �6(   .+�5A      �� $��3��6   $��4��60   $��img/libro.jpg��6A   $
��Fill=�6X   �� 5B      -	   5        $��contador��5B   ,   $��0��6   $��primera columna��6<   $
��Left=�6V   $	��Top=�6q   �� 5C      -
   5        $��	contador2��5C   ,   $��1��6   $��segunda columna��6=   $
��Left=�6W   $	��Top=�6r     5F      $��Right=�6)   $��0��6E   $��2��6U   
������ 
������ .��5G      �� -   5        $
��btn1��5G   !   $
��Fill=�6-   5H        5J      $��Right=�6)   $��1��6E   $��2��6U   
������ 
������ .��5K      �� -   5        $
��btn2��5K       $��img/creditos.png��6,   $
��Fill=�6F   5L        5N      -   5        $��0��5N   )   $��Center=�69   $��2��6V   $��3��6j   
������ 
������ .��5O      �� -   5        $
��btn3��5O       $��img/salir.png��6,   $
��Fill=�6C   5P      5R      � 5U      -   5        $��
evaluacion��5U      5W      4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5X      -   5        $��sensorChooserUi��5X   [   $��Center=�6&   $	��Top=�6C   6[   8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  5Y      $	��Top=�6!   $��Center=�69   $	��100��6�      KinectRegion 6V   ��  �� ElementName$ kinectRegion��6�   5Z      5[      5\      5]      