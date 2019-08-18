using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Admin
{
    public partial class FrmAddEditPrintSizeAndServices_Refactored : Form
    {
        #region Variables

        private bool _newSizeFlag;
        private bool _editSizeFlag;
        private bool _deleteSizeFlag;

        private int _selectedPrintSizeId;
        private int _selectedPrintServiceId;
        private int _selectedPrintSizeServiceId;

        private readonly BackgroundWorker _bgWorkerUpdatePrintSizeService = new BackgroundWorker();
        private readonly BackgroundWorker _bgWorkerSaveNewPrintSizeService = new BackgroundWorker();

        #endregion Variables


        public FrmAddEditPrintSizeAndServices_Refactored()
        {
            InitializeComponent();
        }
    }
}