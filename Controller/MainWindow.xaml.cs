using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Gaming.Input;
using System.Timers;
using System.Threading;

namespace Controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window window;
        Gamepad gamepad;
        GamepadVibration vibration;

        double rightMotor = 0;
        double leftMotor = 0;
        double rightTrigger = 0;
        double leftTrigger = 0;

        public MainWindow()
        {
            InitializeComponent();
            window = this;

            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;


            Thread thread = new Thread(Loop);
            thread.Start();
        }

        private void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
        }

        private void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
        }

        public void Loop()
        {
            Thread.Sleep(1000);
            while (true)
            {
                gamepad = Gamepad.Gamepads.First();

                vibration.LeftMotor = leftMotor;
                vibration.LeftTrigger = leftTrigger;
                vibration.RightMotor = rightMotor;
                vibration.RightTrigger = rightTrigger;
                gamepad.Vibration = vibration;

                Thread.Sleep(1000);
            }
        }

        private void LeftMotorChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            leftMotor = sliderLeftMotor.Value;
        }

        private void LeftTriggerChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            leftTrigger = sliderLeftTrigger.Value;
        }

        private void RightMotorChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rightMotor = sliderRightMotor.Value;
        }

        private void RightTriggerChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rightTrigger = sliderRightTrigger.Value;
        }
    }
}