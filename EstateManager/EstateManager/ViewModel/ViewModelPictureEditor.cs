using EstateAgencyManager.Wpf.Converters;
using EstateManager.Model;
using EstateManager.Tools;
using EstateManager.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EstateManager.ViewModel
{
    class ViewModelPictureEditor : BaseNotifyPropertyChanged
    {
        private ViewModelEstateEditor estateEditor;
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        private bool IsDefaultImage { get; set; }
        public ImageSource ImgSrc
        {
            get { return GetProperty<ImageSource>(); }
            set
            {
                SetProperty(value);
                IsDefaultImage = false;
            }
        }

        private PictureEditor editor;

        private string filePath { get; set; }

        public ViewModelPictureEditor(ViewModelEstateEditor estateEditor, PictureEditor editor)
        {
            IsDefaultImage = false;
            this.estateEditor = estateEditor;
            this.editor = editor;
        }

        public BaseCommand BrowseForPicture
        {
            get { return new BaseCommand(browseForPicture); }
        }
        public void browseForPicture()
        {
            OpenFileDialog pictureDialog = new OpenFileDialog();
            pictureDialog.Filter = "Image Files(*.PNG; *.JPG; *.JPEG)| *.PNG; *.JPG; *.JPEG";
            if (pictureDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = pictureDialog.FileName;
                Console.WriteLine(filePath);
                ImgSrc = new BitmapImage(new Uri(filePath));
            }
        }
        public BaseCommand CloseWindowFailure
        {
            get { return new BaseCommand(closeWindowFailure); }
        }
        public void closeWindowFailure()
        {
            editor.Close();
        }
        public BaseCommand CloseWindowSuccess
        {
            get { return new BaseCommand(closeWindowSuccess); }
        }
        public void closeWindowSuccess()
        {
            if (ImgSrc != null && !string.IsNullOrEmpty(Title)) {
                Photo p = new Photo();
                p.Title = Title;
                p.Content = BitmapImageToBase64String(new BitmapImage(new Uri(filePath)));
                estateEditor.PhotoList.Add(p);
                editor.Close();
            }
            else
            {
                if(ImgSrc == null)
                {
                    MessageBox.Show("Erreur : Il n'y a pas d'image.");
                }
                else
                {
                    MessageBox.Show("Erreur : Il n'y a pas de titre.");
                }
            }
        }

        private string BitmapImageToBase64String(BitmapImage image)
        {
            if (image == null) return "";

            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                byte[] byteArray = stream.ToArray();
                return System.Convert.ToBase64String(byteArray);
            }
        }
    }
}
