using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Interaction;
using Microsoft.Kinect.Toolkit.Controls;

namespace RealidadAumentada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public KinectSensorChooser sensorChooser;
        Preguntas[] pregunta=new Preguntas[15];
        int indice = new Random().Next(0, 15);
        int correctas = 0;
        int incorrectas = 0;
        int tiempo = 30;
        Timer reloj = new Timer();

        public enum KinectStatus
        {
            Undefined,
            Disconnected,
            Connected,
            Initializing,
            Error,
            NotPowered,
            NotReady,
            DeviceNotGenuine,
            DeviceNotSupported,
            InsufficientBandwidth,
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            reloj.Tick += new EventHandler(reloj_Tick);
            reloj.Enabled = true;
            reloj.Interval = 1000;
            reloj.Stop();

            pregunta[0] = new Preguntas("Selecciona el hueso que conforma el brazo", "img/preguntas/1/1.png", "img/preguntas/1/2.png", "img/preguntas/1/3.png", "");

            pregunta[1] = new Preguntas("¿Cuál es el hueso más largo del esqueleto humano?", "img/preguntas/2/1.png", "img/preguntas/2/2.png", "img/preguntas/2/3.png", "");

            pregunta[2] = new Preguntas("¿Cuál es el hueso más pequeño del esqueleto humano?", "img/preguntas/3/1.png", "img/preguntas/3/2.png", "img/preguntas/3/3.png", "");

            pregunta[3] = new Preguntas("¿Cuál de los siguientes no es un hueso del cráneo?", "img/preguntas/4/1.png", "img/preguntas/4/2.png", "img/preguntas/4/3.png", "");

            pregunta[4] = new Preguntas("¿Dónde se encuentran los huesos del brazo?", "img/preguntas/5/1.png", "img/preguntas/5/2.png", "img/preguntas/5/3.png", "");

            pregunta[5] = new Preguntas("¿Cómo se denomina la ciencia que se encarga de estudiar los huesos?", "img/preguntas/6/1.png", "img/preguntas/6/2.png", "img/preguntas/6/3.png", "");

            pregunta[6] = new Preguntas("Las principales funciones de los huesos son:", "img/preguntas/7/1.png", "img/preguntas/7/2.png", "img/preguntas/7/3.png", "");

            pregunta[7] = new Preguntas("¿Cuantos huesos forman el cráneo?", "img/preguntas/8/1.png", "img/preguntas/8/2.png", "img/preguntas/8/3.png", "");

            pregunta[8] = new Preguntas("¿Cuál es la función del esqueleto?", "img/preguntas/9/1.png", "img/preguntas/9/2.png", "img/preguntas/9/3.png", "");

            pregunta[9] = new Preguntas("¿Cual es el principal componente del cuerpo humano?", "img/preguntas/10/1.png", "img/preguntas/10/2.png", "img/preguntas/10/3.png", "");

            pregunta[10] = new Preguntas("¿Como se clasifican los huesos del cuerpo?", "img/preguntas/11/1.png", "img/preguntas/11/2.png", "img/preguntas/11/3.png", "");

            pregunta[11] = new Preguntas("¿Que parte del esqueleto humano protege a los pulmones?", "img/preguntas/12/1.png", "img/preguntas/12/2.png", "img/preguntas/12/3.png", "");

            pregunta[12] = new Preguntas("¿Como se le denomina al eje del esqueleto humano?", "img/preguntas/13/1.png", "img/preguntas/13/2.png", "img/preguntas/13/3.png", "");

            pregunta[13] = new Preguntas("¿Como se le denomina a la parte del esqueleto humano que comúnmente llamamos caderas?", "img/preguntas/14/1.png", "img/preguntas/14/2.png", "img/preguntas/14/3.png", "");

            pregunta[14] = new Preguntas("¿Como se llaman a los huesos de la cara que se utilizan  en la masticación?", "img/preguntas/15/1.png", "img/preguntas/15/2.png", "img/preguntas/15/3.png", "");
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += new EventHandler<KinectChangedEventArgs>(sensorChooser_KinectChanged);
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            var regionSensorBinding = new System.Windows.Data.Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            var altura = this.Height / 5;
            var anchura = altura*2;

            btnJugar.Height = btnOpciones.Height = btnCreditos.Height = btnSalir.Height = altura;
            btnJugar.Width = btnOpciones.Width = btnCreditos.Width = btnSalir.Width = anchura;

            altura = this.Height / 7;
            anchura = altura * 2;

            btn1.Height=btn2.Height=btn3.Height= altura;
            btn1.Width = btn2.Width = btn3.Width = anchura;
        }

        public void sensorChooser_KinectChanged(object sender, KinectChangedEventArgs args)
        {
            bool error = false;
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                    error = true;
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                        error = true;
                    }
                }
                catch (InvalidOperationException)
                {
                    error = true;
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (!error)
                kinectRegion.KinectSensor = args.NewSensor;
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            contador.Content = "Tiempo restante: " + tiempo;
            if (tiempo == 0)
            {
                tiempo = 30;
                contador.Content = "Tiempo restante: " + tiempo;
                reloj.Stop();
                tiempoAgotado();
            }
            tiempo -= 1;
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
           this.sensorChooser.Stop();
           App.Current.Shutdown();
        }

        private void Jugar(object sender, RoutedEventArgs e)
        {
            btnSiguiente.Click -= menuPrincipal;
            btnSiguiente.Click += siguiente;
            seleccionarPregunta();
            gridPrincipal.Visibility = Visibility.Hidden;
            gridPreguntas.Visibility = Visibility.Visible;
        }

        private void seleccionarPregunta()
        {
            reloj.Start();

          regreso:
            if (!pregunta[indice].contestada)
            {
                txtPregunta.Text = pregunta[indice].pregunta;
                BitmapImage bi1 = new BitmapImage(new Uri(pregunta[indice].resA, UriKind.Relative));
                BitmapImage bi2 = new BitmapImage(new Uri(pregunta[indice].resB, UriKind.Relative));
                BitmapImage bi3 = new BitmapImage(new Uri(pregunta[indice].resC, UriKind.Relative));

                img1.Source = bi1;
                img2.Source = bi2;
                img3.Source = bi3;

                img1.Width = btn1.Width;
                img2.Width = btn2.Width;
                img3.Width = btn3.Width;

                pregunta[indice].contestada = true;
            }
            else
            {
                if ((correctas+incorrectas)<15)
                {
                    indice = new Random().Next(0, 15);
                    goto regreso;
                }
            }
        }
   
        private void evaluacion(object sender, RoutedEventArgs e)
        {
            KinectTileButton comodin = (KinectTileButton)sender;

            reloj.Stop();
            tiempo = 30;
            contador.Content = "Tiempo restante: " + tiempo;

            switch (indice)
            {
                case 0:
                    if (comodin.Name == "btn2") resCorrecta();
                    else resIncorrecta();
                    break;
                case 1:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 2:
                    if (comodin.Name == "btn2") resCorrecta();
                    else resIncorrecta();
                    break;
                case 3:
                    if (comodin.Name == "btn3") resCorrecta();
                    else resIncorrecta();
                    break;
                case 4:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 5:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 6:
                    if (comodin.Name == "btn3") resCorrecta();
                    else resIncorrecta();
                    break;
                case 7:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 8:
                    if (comodin.Name == "btn2") resCorrecta();
                    else resIncorrecta();
                    break;
                case 9:
                    if (comodin.Name == "btn3") resCorrecta();
                    else resIncorrecta();
                    break;
                case 10:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 11:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 12:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 13:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
                case 14:
                    if (comodin.Name == "btn1") resCorrecta();
                    else resIncorrecta();
                    break;
            }
        }

        private void siguiente(object sender, RoutedEventArgs e)
        {
            if ((correctas + incorrectas) < 15)
            {
                seleccionarPregunta();
                gridEvaluacion.Visibility = Visibility.Hidden;
                gridPreguntas.Visibility = Visibility.Visible;
            }
            else
            {
                resultados();
            }
           
        }

        private void menuPrincipal(object sender, RoutedEventArgs e)
        {
            correctas =incorrectas= 0;
            for (int i = 0; i < 15; i++)
            {
                pregunta[i].contestada = false;
            }
            tiempo = 30;
                gridEvaluacion.Visibility = Visibility.Hidden;
                lblCorrectas.Visibility = lblIncorrectas.Visibility = Visibility.Hidden;
                gridPrincipal.Visibility = Visibility.Visible;
        }

        private void resCorrecta()
        {
            gridPreguntas.Visibility = Visibility.Hidden;
            gridEvaluacion.Visibility = Visibility.Visible;

           BitmapImage fondo = new BitmapImage(new Uri("img/evaluacion/correcto.jpg", UriKind.Relative));
            imgEvaluacion.Source = fondo;
            correctas++;
        }

        private void resIncorrecta()
        {
            gridPreguntas.Visibility = Visibility.Hidden;
            gridEvaluacion.Visibility = Visibility.Visible;

            BitmapImage fondo = new BitmapImage(new Uri("img/evaluacion/incorrecto.jpg", UriKind.Relative));
            imgEvaluacion.Source = fondo;
            incorrectas++;
        }

        private void tiempoAgotado()
        {
            gridPreguntas.Visibility = Visibility.Hidden;
            gridEvaluacion.Visibility = Visibility.Visible;

            BitmapImage fondo = new BitmapImage(new Uri("img/evaluacion/tiempo.jpg", UriKind.Relative));
            imgEvaluacion.Source = fondo;
        }

        private void resultados()
        {
            btnSiguiente.Click -= siguiente;
            btnSiguiente.Click += menuPrincipal;
            BitmapImage fondo = new BitmapImage(new Uri("img/evaluacion/final.jpg", UriKind.Relative));
            lblCorrectas.Content = "Preguntas contestadas correctamente: "+correctas.ToString();
            lblIncorrectas.Content = "Preguntas contestadas incorrectamente: " + incorrectas.ToString();
            lblCorrectas.Visibility=lblIncorrectas.Visibility = Visibility.Visible;

            lblCorrectas.Padding = new Thickness(this.Width / 10, this.Height / 3, 0, 0);
            lblIncorrectas.Padding = new Thickness(this.Width / 10, (this.Height / 3)+50, 0, 0);
            imgEvaluacion.Source = fondo;           
        }
    }
}
