using System.Windows.Forms;

namespace PhotographyAutomation.App.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class ucSmallPhotoViewer : UserControl
    {
        //Singleton Pattern
        private static ucSmallPhotoViewer _instance;
        public static ucSmallPhotoViewer Instance => _instance ?? (_instance = new ucSmallPhotoViewer());

        //private static ucSmallPhotoViewer _instance;
        //public static ucSmallPhotoViewer Instance
        //{
        //    get
        //    {
        //        if(_instance==null)
        //            _instance=new ucSmallPhotoViewer();
        //        return _instance;
        //    }
        //}

        public ucSmallPhotoViewer()
        {
            InitializeComponent();
        }

        private void btnNextPhoto_Click(object sender, System.EventArgs e)
        {

        }

        private void btnPreviousPhoto_Click(object sender, System.EventArgs e)
        {

        }

        private void btnMagnifyPhoto_Click(object sender, System.EventArgs e)
        {

        }
    }
}
