using MongoDB.Bson;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFclinica.Handler;
using WPFclinica.Model;

namespace WPFclinica.Views
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : UserControl
    {
        ExpedienteHandler _expediente = new ExpedienteHandler();
        public Perfil()
        {
            InitializeComponent();
        }

        private void BtnObs_Click(object sender, RoutedEventArgs e)
        {
            obstetrico ventana1 = new obstetrico();
            ventana1.Show();
            ventana1.IdExpediente = IdUsuario;
            ventana1.btnDelete.IsEnabled = false;
            ventana1.btnDelete.Visibility = Visibility.Collapsed;
            ventana1.btnUpdate.IsEnabled = false;
            ventana1.btnUpdate.Visibility = Visibility.Collapsed;
            //FramePerfil.Content = ventana1;
        }

        private void Avanzar(object sender, RoutedEventArgs e)
        {
            ginecologico ventana2 = new ginecologico();
            ventana2.Show();
            ventana2.IdExpediente = IdUsuario;
            ventana2.btnDelete.IsEnabled = false;
            ventana2.btnDelete.Visibility = Visibility.Collapsed;
            ventana2.btnUpdate.IsEnabled = false;
            ventana2.btnUpdate.Visibility = Visibility.Collapsed;
           // FramePerfil.Content = ventana2;
        }

        public void Consultar()
        {
            exp = _expediente.GetById(IdUsuario);
            if (exp != null)
            {
                nombre_paciente.Text = exp.Nombre;
                télefono_paciente.Text = String.Join("  ", exp.Telefonos);
                direccion_paciente.Text = exp.Procedencia;
                if (exp.Image != null)
                {
                    ImageSourceConverter imgs = new ImageSourceConverter();
                    foto.SetValue(Image.SourceProperty, imgs.ConvertFrom(exp.Image));
                }
                
                if (exp.Historial != null)
                {
                    lista = exp.Historial.ConverToViewHistorial(exp.Historial);
                    historias.ItemsSource = lista;
                }
            }
        }

        public void Ver(object sender, RoutedEventArgs e)
        {
            string uuid = ((Button)sender).CommandParameter.ToString();
            if (!string.IsNullOrEmpty(uuid))
            {
                var historialItem = lista.Find(x => x.MyUUID == uuid);

                if (historialItem.Tipo == "Obstetrico")
                {
                    var h = exp.Historial.HObstetricos.First(x => x.MyUUID == historialItem.MyUUID);
                    ViewObste(h);
                }
                else if (historialItem.Tipo == "Ginecologico")
                {
                    var h = exp.Historial.HGinecologicos.First(x => x.MyUUID == historialItem.MyUUID);
                    ViewGine(h);
                }
            }
            
            //MessageBox.Show("UUID: " + historialItem.MyUUID + ' ' + uuid);
        }

        public void updateObstet(object sender, RoutedEventArgs e)
        {

        }

        public void deleteObstet(object sender, RoutedEventArgs e)
        {

        }

        private void ViewObste(HObstetrico h)
        {
            obstetrico ventana1 = new obstetrico();
            ventana1.Show();    
            ventana1.IdExpediente = IdUsuario;
            ventana1.MyUUID = h.MyUUID;
            ventana1.BtnSave.IsEnabled = false;
            ventana1.BtnSave.Visibility = Visibility.Collapsed;
            ventana1.SetHistorial(ventana1.IdExpediente, ventana1.MyUUID);
            // FramePerfil.Content = ventana1;
            Consultar();
        }

        private void ViewGine(HGinecologico h)
        {
            ginecologico ventana2 = new ginecologico();
            ventana2.Show();    
            ventana2.IdExpediente = IdUsuario;
            ventana2.MyUUID = h.MyUUID;
            ventana2.BtnIng.IsEnabled = false;
            ventana2.BtnIng.Visibility = Visibility.Collapsed;
            ventana2.SetHistorial(IdUsuario, h.MyUUID);
            //FramePerfil.Content = ventana2;
            Consultar();
        }

        public string IdUsuario = string.Empty;
        private List<ViewHistorial> lista;
        private Expediente exp;


        byte[] data;
        String base64Text;
        private System.Drawing.Image image; 
        private void Subir(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog(); 
            if (ofd.ShowDialog() == true)
            {
                System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                data = System.IO.File.ReadAllBytes(ofd.FileName);
                base64Text = Convert.ToBase64String(data);
                Console.WriteLine(base64Text);
                //fs.Read(data, 0,System.Convert.ToInt32(fs.Length));
                //fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                image = new System.Drawing.Bitmap(ofd.FileName.ToString());
                foto.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }

            if (foto.Source != null)
            {
                var converter = new System.Drawing.ImageConverter();
                data = (byte[])converter.ConvertTo(image, typeof(byte[]));
                _expediente.NewProfilePhoto(data, exp);
            }

            /*Microsoft.Win32.SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog1.Filter = "Imagenes PNG (*.png)|*.png|Imagenes JPEG (*.jpg)|*.jpg";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog()==true)
            {
                string filename = saveFileDialog1.FileName;
                byte[] data = Convert.FromBase64String(base64Text);
                File.WriteAllBytes(filename, Convert.FromBase64String(base64Text));
                //save file using stream.
            }*/
        }

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            Lista_Examen p = new Lista_Examen();
            p.expeId = IdUsuario;
            p.ShowFiles();
            p.Show();
        }

        private void Ficha(object sender, RoutedEventArgs e)
        {
            Page1 ventana3 = new Page1();
            ventana3.Show();
            ventana3.btnInsertarPaciente.Visibility = Visibility.Hidden;
            ventana3.btnInsertarPaciente.IsEnabled = false;
            ventana3.LlenarCampos(IdUsuario);
            //FramePerfil.Content = ventana;
        }
    }
}
