using System.Windows.Forms;

namespace PhotographyAutomation.App.UserControls.PreFactor
{
    // ReSharper disable once InconsistentNaming
    public partial class ucPhotoOrderProperties : UserControl
    {
        #region Singletone

        private static ucPhotoOrderProperties _instanceOrderProperties;
        public static ucPhotoOrderProperties InstanceOrderProperties
        {
            get
            {
                if(_instanceOrderProperties==null)
                    _instanceOrderProperties=new ucPhotoOrderProperties();
                return _instanceOrderProperties;
            }
        }

        #endregion


        public ucPhotoOrderProperties()
        {
            InitializeComponent();
        }
    }
}
