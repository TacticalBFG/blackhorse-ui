using System;
using System.Collections.Generic;
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

namespace wpf_bh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool waitingForKey = false;
        public int keyPressed = 0;


        public static string[] keynames = {
            "PageUp",
            "PageDown",
            "End",
            "Home",
            "Left",
            "Up",
            "Right",
            "Down",
            "Select",
            "Print",
            "Execute",
            "Snapshot",
            "Insert",
            "Delete",
            "Help",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",

            "unk","unk","unk","unk","unk","unk","unk",

            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",

            "LWin",
            "RWin",
            "Apps",
            "unk",

            "Sleep",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "Multiply",
            "Add",
            "Separator",
            "Subtract",
            "Decimal",
            "Divide",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F23",
            "F24",

        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void checkIfEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
                Keyboard.ClearFocus(); // sends the lost keyboard focus event to whatever the fag pressed enter on (textboxes are shit and normally enter doesnt work)
        }

        private void UpdateFOV(object sender, KeyboardFocusChangedEventArgs e)
        {
            int newfov = int.Parse(FOV.Text);

            if (newfov < 70 || newfov > 90)
            {
                MessageBox.Show("Error - invalid FOV range (please choose between 70 -> 90)", "Error", MessageBoxButton.OK);
                return;
            }
        }

        private void UpdateSensitivity(object sender, KeyboardFocusChangedEventArgs e)
        {
            float newsens = float.Parse(Sens.Text);

            if (newsens <= 0 || newsens > 1)
            {
                MessageBox.Show("Error - invalid sensitivity range (please choose between 0 -> 1)", "Error", MessageBoxButton.OK);
                return;
            }
        }

        private void openNewKeybind(object sender, RoutedEventArgs e)
        {
            NewKeybind.Visibility = Visibility.Visible;
        }

        private void openEditKeybinds(object sender, RoutedEventArgs e)
        {
            NewKeybind.Visibility = Visibility.Hidden;
        }

        private void listenForKey(object sender, RoutedEventArgs e)
        {
            waitingForKey = true;
            keyBoundTo.Content = "Press a key...";
        }

        private void RandXSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            randXLabel.Content = Math.Floor(randXSlider.Value).ToString() + "%"; // how bad can you be at programming so that MinValue literally does nothing
        }

        private void RandYSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            randYLabel.Content = Math.Floor(randYSlider.Value).ToString() + "%";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (waitingForKey)
            {
                int key = KeyInterop.VirtualKeyFromKey(e.Key);

                if (key > 32 && key <= 135) // keyCode > space & keycode <= F24
                {
                    string kn = keynames[key - 33];
                    keyBoundTo.Content = kn;
                    keyPressed = key;

                    waitingForKey = false;
                }
            }
        }

        private void saveKeybind(object sender, RoutedEventArgs e)
        {

        }
    }
}
