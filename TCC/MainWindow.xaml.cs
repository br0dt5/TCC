using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Synthesizer.Controls;
using Synthesizer.Models;
using Synthesizer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Synthesizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainViewModel mainViewModel;
        
        public MainWindow()
        {
            InitializeComponent();          
                        
            mainViewModel = new MainViewModel();            
            this.DataContext = mainViewModel;    
            
            ComboBoxOctave.SelectedIndex = 0;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
  
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var keyIndex = KeyboardViewModel.keyboardNotes.FindIndex(obj => obj.keyNote == e.Key);

            if(keyIndex != -1)
            {
                string keyNote = (string)KeyboardViewModel.keyboardNotes[keyIndex].ButtonName;
                Button button = (Button)this.keyboard.FindName($"{keyNote}");
                
                button.Background = Brushes.DeepSkyBlue;
            }

            SignalGeneratorType WaveShape = OscillatorViewModel.SelectWaveShape(Oscillator1.WaveShapeComboBox.SelectedIndex);
            mainViewModel.CurrentOscillator1.SelectedWaveShape = WaveShape;

            mainViewModel.PlayWaveProvider(keyIndex);
           
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            var keyIndex = KeyboardViewModel.keyboardNotes.FindIndex(obj => obj.keyNote == e.Key);

            if (keyIndex != -1)
            {
                string keyNote = (string)KeyboardViewModel.keyboardNotes[keyIndex].ButtonName;
                Button button = (Button)this.keyboard.FindName($"{keyNote}");

                string TypeNote = KeyboardViewModel.keyboardNotes[keyIndex].TypeNote;

                if(TypeNote == "sharp")
                {
                    button.Background = Brushes.Black;
                }
                else
                {
                    button.Background = Brushes.White;
                }
            }

            mainViewModel.StopWaveProvider();
        }

        private void ComboBoxOctave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainViewModel.Octave = mainViewModel.OctaveCollection[ComboBoxOctave.SelectedIndex].Octave;
            mainViewModel.GenerateKeyboardNotes();
        }
    }
}
