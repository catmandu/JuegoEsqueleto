   M S B A M L   `   `   `  ����   RealidadAumentada"    RealidadAumentada.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013     � Title$  
MainWindow��$	��365��$	��500�� � WindowStyle$
 None=� � WindowState$ 	Maximized=�.��� .+�4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   $��kinectRegion��.��� .+�� -   $��gridPrincipal�� � ColumnDefinitions �� $	��.5* ��� $	��.5* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��lblMenu��$��0��$��Center=�.��MENU8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   $��btnJugar��$��1��
������ 
������ .���� $��img/jugar.png��$
��Fill=�  -   $��btnOpciones��$��2��
������ 
������ .���� $��img/opciones.png��$
��Fill=�  -   $��btnCreditos��$��3��
������ 
������ .���� $��img/creditos.png��$
��Fill=�  -   $��btnSalir��$��4��
������ 
������ .���� $��img/salir.png��$
��Fill=��� $��1��$��5��$��img/esqueleto.gif��� -   $��gridPreguntas��$y�Hidden=� �� $
��.25* ��� $
��.25* ��� $	��.5* � �� $
��.18* ��� $
��.18* ��� $
��.18* ��� $
��.18* �.+��� $��3��$��4��$��img/libro.jpg��$
��Fill=��� -	   $��contador��$��0��$��2��$��25(�$��0��$��Tiempo restante: 30��$��Center=�$��Bottom=��� -
   $��txtPregunta��$��0��$��2��$��2��$��1��$
��Wrap=�$��25(� �� Padding$	 120q�$
��Left=�$	��Top=�  -   $
��btn1��$��Right=�$��0��$��2��
������ 
������ .���� -   $
��img1��$
��Fill=�  -   $
��btn2��$��Right=�$��1��$��2��
������ 
������ .���� -   $
��img2��$
��Fill=�  -   $
��btn3��$��0��$��Center=�$��2��$��3��
������ 
������ .���� -   $
��img3��$
��Fill=�� -   $��gridEvaluacion��$y�Hidden=�.+��� -   $��imgEvaluacion��$
��Fill=��� -   $��lblCorrectas��$��25(��� -   $��lblIncorrectas��$��25(�  -   $��btnSiguiente��$��Bottom=�$��	0,0,50,50q�$��Right=�
������ 
������ .���� $��img/siguiente.png��$
��Fill=�4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  -   $��sensorChooserUi��$��Center=�$	��Top=�8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��Top=�$��Center=�$	��100��   KinectRegion ��  �� ElementName$ kinectRegion��