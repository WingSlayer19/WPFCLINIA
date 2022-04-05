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
        public Lista_Examen()
        {
            InitializeComponent();
        }
        
        private void Cargar(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                data = System.IO.File.ReadAllBytes(ofd.FileName);
                base64Text = Convert.ToBase64String(data);
                Console.WriteLine(base64Text);
                ofd.Multiselect = true;
                //if (ofd.ShowDialog() == true)
                //{
                //    foreach (string filename in ofd.FileNames)
                //        Lista.Items.Add(System.IO.Path.GetFileName(filename));
                //}


                foreach (string filename in ofd.FileNames)
                {
                    listaArchivos.Add(new Archivo(System.IO.Path.GetFileName(filename), expeId));
                    Lista.Items.Add(System.IO.Path.GetFileName(filename));
                }

                //fs.Read(data, 0,System.Convert.ToInt32(fs.Length));
                //fs.Close();
                // ImageSourceConverter imgs = new ImageSourceConverter();
                //  foto.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }

         
        }
        //where is the click event

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            Lista_Examen p = new Lista_Examen();
            p.ShowFiles();
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

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            _handler.SaveFiles(listaArchivos);
            ShowFiles();
            listaArchivos.Clear();
        }

        public void ShowFiles()
        {
            Lista.Items.Clear();
            var archivos = _handler.GetAllExpeAndFiles(expeId);
            foreach (var item in archivos)
            {
                Lista.Items.Add(item.Id.ToString() + " " + item.Nombre);
            }
        }
    }
 
}


    

