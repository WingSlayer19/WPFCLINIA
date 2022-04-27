using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using WPFclinica.Handler;
using WPFclinica.Model;

namespace WPFclinica.Views
{
    /// <summary>
    /// Lógica de interacción para Lista_Examen.xaml
    /// </summary>
    public partial class Lista_Examen : Window
    {
        byte[] data;
        String base64Text;
        public string expeId;
        private ExpedienteHandler _handler = new ExpedienteHandler();
        private List<Archivo> listaArchivos = new List<Archivo>();
        private List<Archivo> listaArchivosCargados = new List<Archivo>();
        private List<string> namesStrings = new List<string>();
        public Lista_Examen()
        {
            InitializeComponent();
        }
        
        private void Cargar(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                data = File.ReadAllBytes(ofd.FileName);
                base64Text = Convert.ToBase64String(data);
                Console.WriteLine(base64Text);
                ofd.Multiselect = true;

                foreach (string filename in ofd.FileNames)
                {
                    listaArchivos.Add(new Archivo(System.IO.Path.GetFileName(filename), expeId));
                    namesStrings.Add(filename);
                    Lista.Items.Add(System.IO.Path.GetFileName(filename));
                }

                fs.Close();
            }
        }
        //where is the click event

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            Lista_Examen p = new Lista_Examen();
            p.ShowFiles();
        }

        private void ShowDefaultViewer(object sender, RoutedEventArgs e)
        {
            if (listaArchivosCargados.Count < 1)
            {
                MessageBox.Show("La lista no contiene tal elemento");
                return;
            }

            if (Lista.SelectedIndex > listaArchivosCargados.Count -1)
            {
                MessageBox.Show("Elemento Inesperado. Asegurese de Guardar el archivo para visualizar");
                return;
            }

            var indexTemp = Lista.SelectedIndex;
            var itemTemp = listaArchivosCargados[indexTemp];
            System.Diagnostics.Process.Start(@""+itemTemp.Path);
        }

        private void Download(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog1.Filter = "Imagenes PNG (*.png)|*.png|Imagenes JPEG (*.jpg)|*.jpg|Archivos PDF (*.pdf)|*.pdf|Archivos Word (*.docx)|*.docx";
            saveFileDialog1.DefaultExt = ".pdf";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == true)
            {
                string filename = saveFileDialog1.FileName;
                byte[] data = Convert.FromBase64String(base64Text);
                File.WriteAllBytes(filename, Convert.FromBase64String(base64Text));
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var indexTemp = Lista.SelectedIndex;
            var itemTemp = listaArchivosCargados[indexTemp];
            _handler.DeleteFile(itemTemp);
            MessageBox.Show("Archivo Eliminado de la lista");
            System.IO.File.Delete(itemTemp.Path);
            ShowFiles();
        }   

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            _handler.SaveFiles(listaArchivos);
            Directories();
            for (int i = 0; i < listaArchivos.Count; i++)
                File.Move(@""+namesStrings[i], @""+listaArchivos[i].Path);
                
            
            ShowFiles();
            listaArchivos.Clear();
            namesStrings.Clear();
        }

        private void Directories()
        {
            foreach (var item in listaArchivos)
            {
                string path = item.Path;
                path = path.Substring(0, path.LastIndexOf("\\"));
                if (!File.Exists(path))
                    Directory.CreateDirectory(path);
            }
        }

        public void ShowFiles()
        {
            Lista.Items.Clear();
            listaArchivosCargados.Clear();
            listaArchivosCargados = _handler.GetAllExpeAndFiles(expeId);
            foreach (var item in listaArchivosCargados)
            {
                Lista.Items.Add(item.Id.ToString() + " " + item.Nombre);
            }
        }
    }
 
}


    

