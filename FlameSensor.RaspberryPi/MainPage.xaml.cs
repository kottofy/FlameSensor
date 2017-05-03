using FlameSensor.RaspberryPi.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;
using System;
using Windows.UI.Xaml;
using Windows.UI.Core;

namespace FlameSensor.RaspberryPi
{
    public sealed partial class MainPage : Page
    {
        Timer _timer;

        private MainPageViewModel ViewModel
        {
            get { return DataContext as MainPageViewModel; }
            set { DataContext = value; }
        }

        public MainPage()
        {
            this.ViewModel = new MainPageViewModel();

            this.ViewModel.DeviceId = Windows.Networking.Connectivity.NetworkInformation.GetConnectionProfiles().First().NetworkAdapter.NetworkAdapterId.ToString();

            this.InitializeComponent();

            StartScenario();
        }


        // Use GPIO pin 5 to set values
        private const int AO_PIN = 5; //AO
        private GpioPin aoPin;

        // Use GPIO pin 6 to listen for value changes
        private const int DO_PIN = 6; //DO
        private GpioPin doPin;

        private GpioPinValue currentValue = GpioPinValue.High;
        private DispatcherTimer timer;


        void StartScenario()
        {
            // Initialize the GPIO objects.
            var gpio = GpioController.GetDefault();

            // Set up our GPIO pin for setting values.
            // If this next line crashes with a NullReferenceException,
            // then the problem is that there is no GPIO controller on the device.
            aoPin = gpio.OpenPin(AO_PIN);
            doPin = gpio.OpenPin(DO_PIN);

            // Set up our GPIO pin for listening for value changes.
            aoPin.SetDriveMode(GpioPinDriveMode.Input);
            //aoPin.ValueChanged += aoPin_ValueChanged;




            // Configure pin for input and add ValueChanged listener.
            doPin.SetDriveMode(GpioPinDriveMode.Input);
            //doPin.ValueChanged += Pin_ValueChanged;

            // Start toggling the pin value every 500ms.
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += Timer_Tick;
            timer.Start();

           
        }

        //private void Pin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        //{
        //    // Report the change in pin value.
        //    var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //    {
        //        string CurrentPinValue = doPin.Read().ToString();
        //        Debug.WriteLine(CurrentPinValue);
        //    });
        //}

        private void aoPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            // Report the change in pin value.
            
        }

        private void Timer_Tick(object sender, object e)
        {
            // Toggle the existing pin value.
            //currentValue = (currentValue == GpioPinValue.High) ? GpioPinValue.Low : GpioPinValue.High;

            Debug.WriteLine("Checking for flame");

            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                string CurrentPinValue = aoPin.Read().ToString();
                Debug.WriteLine("ao: " + CurrentPinValue);

                if (aoPin.Read().Equals(GpioPinValue.High))
                {
                    Debug.WriteLine("Flame detected");

                    SendSensorValue("FlameSensor", 1, this.ViewModel.DeviceId);

                    //    if (viewModel.IsSending)
                    //        viewModel.SendSensorValue("FlameSensor", 1);

                    //_timer = new Timer(new TimerCallback((x) =>
                    //{
                    //    MainPageViewModel viewModel = ((MainPageViewModel)x);

                    //    if (viewModel.IsSending)
                    //        viewModel.SendSensorValue("FlameSensor", 1);

                    //}), this.ViewModel, 1000, 3000);

                //TODO: add in notification to UI
                //TODO: instead of checking every 5 seconds, check all the time but only send request every 5 seconds


                }

            });
        }

        internal void SendSensorValue(string sensorName, double sensorValue, string deviceId)
        {
            // change this URL to match your own App Service's root URL
            Uri baseUri = new Uri("http://flamesensorappservice.azurewebsites.net");
            FlameSensorAppService appServiceClient = new FlameSensorAppService(baseUri);

            appServiceClient.Sensor.Post(new Models.SensorReading
            {
                DeviceId = deviceId,
                SensorName = sensorName,
                Value = sensorValue
            });
        }
    }
}