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

using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Synthesizer.Controls
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuItemAbrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Áudio|*.wav;*.mp3;*.midi|Todos os Arquivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string caminhoDoArquivo = openFileDialog.FileName;
                // Implement the logic to load the file
                try
                {
                    using (var waveReader = new WaveFileReader(caminhoDoArquivo))
                    {
                        // Here you can handle the logic for processing the audio file
                        MessageBox.Show($"Arquivo de áudio aberto: {caminhoDoArquivo}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o arquivo: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MenuItemSalvar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos WAV|*.wav|Arquivos MP3|*.mp3|Arquivos MIDI|*.midi|Todos os Arquivos|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string caminhoDoArquivo = saveFileDialog.FileName;
                // Implement logic to save the file
                try
                {
                    using (var waveWriter = new WaveFileWriter(caminhoDoArquivo, new WaveFormat()))
                    {
                        // Here you can handle the logic for saving the audio file
                        MessageBox.Show($"Arquivo de áudio salvo em: {caminhoDoArquivo}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
