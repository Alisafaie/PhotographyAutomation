﻿using DevComponents.DotNetBar.Controls;
using Ookii.Dialogs.WinForms;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Order;
using PhotographyAutomation.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmShowUploadedPhotos : Form
    {
        #region Variables
        private int _statusCode;
        #endregion

        #region Form Events
        public FrmShowUploadedPhotos()
        {
            InitializeComponent();
        }

        private void FrmShowUploadedPhotos_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        #endregion

        #region Form Control Events

        #region Button Events

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtOrderCodeDate.ResetText();
            txtOrderCodeCustomerIdBookingId.ResetText();

            rbCustomerInfo.Checked = false;
            rbOrderCode.Checked = false;
            rbOrderDate.Checked = false;
            rbOrderStatus.Checked = false;

            txtOrderCodeDate.Focus();
        }

        private void btnShowOrders_Click(object sender, EventArgs e)
        {
            if (CheckInputs() == false)
                return;

            if (rbOrderCode.Checked)
            {
                string orderCode = txtOrderCodeDate.Text + "-" + txtOrderCodeCustomerIdBookingId.Text;
                ShowOrdersByOrderCode(orderCode);
            }
            else if (rbCustomerInfo.Checked)
            {
                string customerInfo = txtCustomerInfo.Text.Trim();

                if (customerInfo == "***")
                    ShowAllOrders();
                else
                    ShowOrders(customerInfo);
            }
            else if (rbOrderDate.Checked)
            {
                var orderDate = datePickerOrderDate.Value.GetDateFromPersianDateTimePicker();
                ShowOrders(orderDate);
            }
            else if (rbOrderStatus.Checked)
            {
                if (chkEnableOrderStatusDatePicker.Checked == false)
                {
                    _statusCode = (int)cmbOrderStatus.SelectedValue;

                    ShowOrders(_statusCode);
                }
                else
                {
                    DateTime statusDate = datePickerOrderStatus.Value.GetDateFromPersianDateTimePicker();
                    ShowOrders(_statusCode, statusDate);
                }
            }
            GC.Collect();
        }



        #endregion


        #region Radio Buttons
        private void rbOrderCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderCode.Checked)
            {
                txtOrderCodeDate.Enabled = true;
                txtOrderCodeCustomerIdBookingId.Enabled = true;
                txtOrderCodeDate.Focus();
            }
            else
            {
                txtOrderCodeDate.Enabled = false;
                txtOrderCodeCustomerIdBookingId.Enabled = false;
            }
        }

        private void rbCustomerInfo_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerInfo.Enabled = rbCustomerInfo.Checked;
            if (txtCustomerInfo.Enabled)
                txtCustomerInfo.Focus();
        }

        private void rbOrderDate_CheckedChanged(object sender, EventArgs e)
        {
            datePickerOrderDate.Enabled = rbOrderDate.Checked;
        }

        private void rbOrderStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderStatus.Checked)
            {
                cmbOrderStatus.Enabled = true;
                chkEnableOrderStatusDatePicker.Enabled = true;
                datePickerOrderStatus.Enabled = chkEnableOrderStatusDatePicker.Checked;
            }
            else
            {
                cmbOrderStatus.Enabled = false;
                datePickerOrderDate.Enabled = false;
                chkEnableOrderStatusDatePicker.Checked = false;
                chkEnableOrderStatusDatePicker.Enabled = false;
            }
        }

        #endregion Radio Buttons


        #region NumberOnlyTextbox


        private void txtOrderCodeDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;

            //if (txtOrderCodeDate.TextLength == 7)
            //    txtOrderCodeCustomerId.Focus();
        }
        private void txtOrderCodeDate_KeyDown(object sender, KeyEventArgs e)
        {
            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                foreach (var t in pasteText)
                {
                    if (char.IsDigit(t))
                        strippedText += t.ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextBoxX me = (TextBoxX)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }



        private void txtOrderCodeCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        #endregion


        #region ComboBox Events
        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderStatus.Enabled)
                int.TryParse(cmbOrderStatus.SelectedValue.ToString(), out _statusCode);
        }



        #endregion


        #region chkEnableOrderStatusDatePicker Events

        private void chkEnableOrderStatusDatePicker_CheckedChanged(object sender, EventArgs e)
        {
            datePickerOrderStatus.Enabled = chkEnableOrderStatusDatePicker.Checked;
        }

        #endregion chkEnableOrderStatusDatePicker Events


        #region TextBox Events
        private void txtOrderCodeDate_TextChanged(object sender, EventArgs e)
        {
            if (txtOrderCodeDate.TextLength == 7)
            {
                txtOrderCodeCustomerIdBookingId.ReadOnly = false;
                txtOrderCodeCustomerIdBookingId.Enabled = true;
                txtOrderCodeCustomerIdBookingId.Focus();
            }
        }

        #endregion TextBox Events


        #region DatePicke Events

        private void datePickerOrderStatus_EnabledChanged(object sender, EventArgs e)
        {
            if (datePickerOrderStatus.Enabled)
            {
                var loc = datePickerOrderStatus.PointToScreen(Point.Empty);
                MouseSilulator.MoveCursorToPoint(loc.X + 100, loc.Y + 10);
                //MouseSilulator.DoMouseClick();
            }
        }

        private void datePickerOrderDate_EnabledChanged(object sender, EventArgs e)
        {
            if (datePickerOrderDate.Enabled)
            {
                var loc = datePickerOrderDate.PointToScreen(Point.Empty);
                MouseSilulator.MoveCursorToPoint(loc.X + 100, loc.Y + 10);
                //MouseSilulator.DoMouseClick();
            }
        }

        #endregion DatePicke Events


        #region DataGridView

        #region DataGridView Events
        private void dgvUploads_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridViewX)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonXColumn &&
                e.RowIndex >= 0)
            {
            RetryGetListOfPhotos:

                var pathLocator = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();

                if (pathLocator != null)
                {
                    List<PhotoViewModel> listOfFiles = GetListOfFilesOfOrder(pathLocator);
                    if (listOfFiles != null)
                    {
                        using (var frmViewUploadedPhotos = new FrmViewUploadedPhotos())
                        {
                            frmViewUploadedPhotos.ListOfPhotos = listOfFiles;
                            frmViewUploadedPhotos.OrderCode =
                                dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
                            frmViewUploadedPhotos.CustomerName = dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"]
                                .Value.ToString();
                            frmViewUploadedPhotos.PhotographyDate =
                                dgvUploads.SelectedRows[0].Cells["clmDate"].Value.ToString();
                            frmViewUploadedPhotos.TotalPhotos =
                                (int)dgvUploads.SelectedRows[0].Cells["clmTotalFiles"].Value;
                            frmViewUploadedPhotos.OrderStatus =
                                dgvUploads.SelectedRows[0].Cells["clmStatusName"].Value.ToString();

                            frmViewUploadedPhotos.ShowDialog();
                            GC.Collect();
                        }
                    }
                    else
                    {
                        var dialogResult = RtlMessageBox.Show(
                            "برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                            "لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                            "خطا در دریافت لیست عکس های سفارش",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Retry)
                        {
                            goto RetryGetListOfPhotos;
                        }
                    }
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای رزرو انتخابی هنوز عکسی در سیستم قرار داده نشده است.",
                        "عدم آپلود عکس برای رزرو انتخابی",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        #endregion DataGridView Events


        #region DataGridView Contextmenu

        private void مشاهدهعکسهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
        RetryGetListOfPhotos:

            var pathLocator = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();

            if (pathLocator != null)
            {
                List<PhotoViewModel> listOfFiles = GetListOfFilesOfOrder(pathLocator);
                if (listOfFiles != null)
                {
                    using (var frmViewUploadedPhotos = new FrmViewUploadedPhotos())
                    {
                        frmViewUploadedPhotos.ListOfPhotos = listOfFiles;
                        frmViewUploadedPhotos.OrderCode =
                            dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
                        frmViewUploadedPhotos.CustomerName = dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"]
                            .Value.ToString();
                        frmViewUploadedPhotos.PhotographyDate =
                            dgvUploads.SelectedRows[0].Cells["clmDate"].Value.ToString();
                        frmViewUploadedPhotos.TotalPhotos =
                            (int)dgvUploads.SelectedRows[0].Cells["clmTotalFiles"].Value;
                        frmViewUploadedPhotos.OrderStatus =
                            dgvUploads.SelectedRows[0].Cells["clmStatusName"].Value.ToString();

                        frmViewUploadedPhotos.ShowDialog();
                        GC.Collect();
                    }
                }
                else
                {
                    var dialogResult = RtlMessageBox.Show(
                        "برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                        "لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                        "خطا در دریافت لیست عکس های سفارش",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.Retry)
                    {
                        goto RetryGetListOfPhotos;
                    }
                }
            }
        }

        private void دریافتعکسهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var photoPath = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();
            var orderCode = dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
            if (photoPath == null)
            {
                RtlMessageBox.Show(
                    "عکسی برای این سفارش در سیستم ثبت نشده است.",
                    "خطا در دریافت عکس های سفارش",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (var folderBrowser = new VistaFolderBrowserDialog())
            {
                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowser.ShowNewFolderButton = true;
                folderBrowser.Description = @"لطفا محل ذخیره عکس های مشتری را انتخاب نمایید";
                folderBrowser.UseDescriptionForTitle = true;


                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;
                    bool resultDownload = DownloadPhotos(selectedPath, photoPath, orderCode);
                    if (resultDownload)
                    {
                        if (RtlMessageBox.Show(
                            "فایل ها با موفقیت در سیستم دریافت شد. آیا فولدر نگهداری آنها باز شود؟",
                            "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)

                        {
                            OpenFolder(selectedPath + "\\" + "Orders" + "\\" + orderCode);
                            GC.Collect();
                        }
                    }
                }
            }
        }




        private void مشاهدهاطلاعاتمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value.ToString(),
                out int customerId)) return;

            using (var frmCustomerInfo = new FrmAddEditCustomerInfo())
            {
                frmCustomerInfo.CustomerId = customerId;
                frmCustomerInfo.NewCustomer = true;
                frmCustomerInfo.IsViewOnly = true;
                frmCustomerInfo.ShowDialog();
            }
        }

        private void مشاهدهاطلاعاترزروToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clmBookingId
            if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmBookingId"].Value.ToString(),
                out int bookingId)) return;
            if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value.ToString(),
                out int customerId)) return;

            using (var frmAddEditBooking = new FrmAddEditBooking())
            {
                frmAddEditBooking.BookingId = bookingId;
                frmAddEditBooking.CustomerId = customerId;
                frmAddEditBooking.IsViewOnly = true;
                frmAddEditBooking.ShowDialog();
            }
        }

        #endregion DataGridView Contextmenu

        #endregion DataGridView


        #endregion Form Control Events

        #region Methods
        private void ShowAllOrders()
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetAllOrders();
                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "هیچ سفارشی در سیستم ثبت نشده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
        }


        private void ShowOrdersByOrderCode(string orderCode)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersOfCustomerByOrderCode(orderCode);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }



        private void ShowOrders(string customerInfo)
        {
            using (var db = new UnitOfWork())
            {
                List<CustomerOrderViewModel> ordersList = db.OrderRepository.GetOrdersOfCustomer(customerInfo);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(DateTime orderDate)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByOrderDate(orderDate);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(int orderStatusId)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByStatusCode(orderStatusId);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }

        private void ShowOrders(int orderStatusId, DateTime statusDate)
        {
            using (var db = new UnitOfWork())
            {
                var ordersList = db.OrderRepository.GetOrdersByStatusCode(orderStatusId, statusDate);

                if (ordersList.Count > 0)
                {
                    PopulateDataGridView(ordersList);
                }
                else
                {
                    RtlMessageBox.Show(
                        "برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    dgvUploads.Rows.Clear();
                }
            }
            dgvUploads.ClearSelection();
        }



        private void PopulateDataGridView(IReadOnlyList<CustomerOrderViewModel> ordersList)
        {
            dgvUploads.Rows.Clear();
            dgvUploads.RowCount = ordersList.Count;
            dgvUploads.AutoGenerateColumns = false;

            for (var i = 0; i < ordersList.Count; i++)
            {
                dgvUploads.Rows[i].Cells["clmId"].Value = ordersList[i].Id;
                dgvUploads.Rows[i].Cells["clmCustomerId"].Value = ordersList[i].CustomerId;
                dgvUploads.Rows[i].Cells["clmBookingId"].Value = ordersList[i].BookingId;

                if (ordersList[i].OrderCode != null)
                    dgvUploads.Rows[i].Cells["clmOrderCode"].Value = ordersList[i].OrderCode;

                switch (ordersList[i].CustomerGender)
                {
                    case 0:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            "خانم " + ordersList[i].CustomerFullName;
                        break;
                    case 1:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            "آقای " + ordersList[i].CustomerFullName;
                        break;
                    case 2:
                        dgvUploads.Rows[i].Cells["clmCustomerFullName"].Value =
                            ordersList[i].CustomerFullName;
                        break;
                }


                dgvUploads.Rows[i].Cells["clmDate"].Value = ordersList[i].OrderDate?.ToShamsiDate();
                dgvUploads.Rows[i].Cells["clmTime"].Value = ordersList[i].OrderTime?.Hours.ToString("##") + ":" +
                                                           ordersList[i].OrderTime?.Minutes.ToString("00");
                dgvUploads.Rows[i].Cells["clmPhotographyTypeId"].Value = ordersList[i].PhotographyTypeId;
                dgvUploads.Rows[i].Cells["clmPhotographyTypeName"].Value = ordersList[i].PhotographyTypeName;
                dgvUploads.Rows[i].Cells["clmPersonCount"].Value = ordersList[i].PersonCount;
                //dgvOrders.Rows[i].Cells["clmPaymentIsOK"].Value = ordersList[i].PaymentIsOk;
                //dgvOrders.Rows[i].Cells["clmSubmitter"].Value = ordersList[i].Submitter;
                //dgvOrders.Rows[i].Cells["clmSubmitterName"].Value = ordersList[i].SubmitterName;
                dgvUploads.Rows[i].Cells["clmStatusId"].Value = ordersList[i].OrderStatusId;
                dgvUploads.Rows[i].Cells["clmStatusName"].Value = ordersList[i].OrderStatusName;
                dgvUploads.Rows[i].Cells["clmCreatedDateTime"].Value = ordersList[i].CreatedDateTime;
                dgvUploads.Rows[i].Cells["clmModifiedDateTime"].Value = ordersList[i].ModifiedDateTime;
                dgvUploads.Rows[i].Cells["clmTotalFiles"].Value = ordersList[i].TotalFiles;
                dgvUploads.Rows[i].Cells["clmOrderStatusCode"].Value = ordersList[i].OrderStatusCode;
                dgvUploads.Rows[i].Cells["clmPhotosFolderLink"].Value = ordersList[i].OrderFolderPathLocator;
                dgvUploads.Rows[i].Cells["clmUploadDate"].Value = ordersList[i].UploadDate?.ToShamsiDate();
                //dgvUploads.Rows[i].Cells["clmViewPhotos"].Value = "مشاهده عکس ها";


                //Alignments
                dgvUploads.Rows[i].Cells["clmDate"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmTime"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmOrderCode"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmTotalFiles"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmPersonCount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUploads.Rows[i].Cells["clmUploadDate"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        private bool CheckInputs()
        {
            if (rbOrderCode.Checked)
            {
                if (string.IsNullOrEmpty(txtOrderCodeDate.Text.Trim()) ||
                    string.IsNullOrEmpty(txtOrderCodeCustomerIdBookingId.Text.Trim()))
                {
                    RtlMessageBox.Show(
                        "شناسه سفارش به درستی وارد نشده است.",
                        "خطا در ورود اطلاعات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (rbCustomerInfo.Checked)
            {
                if (string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
                {
                    RtlMessageBox.Show(
                        "اطلاعات مشتری وارد نشده است.",
                        "خطا در ورود اطلاعات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtCustomerInfo.Focus();
                    return false;
                }
            }


            return true;
        }



        private void PopulateComboBox()
        {
            using (var db = new UnitOfWork())
            {
                cmbOrderStatus.DataSource = db.OrderStatusGenericRepository.Get(x => x.Code > 10)
                    .Select(x => new OrderStatusViewModel
                    {
                        Id = x.Id,
                        StatusCode = x.Code,
                        Name = x.Name
                    }).ToList();

                cmbOrderStatus.DisplayMember = "Name";
                cmbOrderStatus.ValueMember = "Id";
            }
        }


        public List<PhotoViewModel> GetListOfFilesOfOrder(string pathLocator)
        {
            using (var db = new UnitOfWork())
            {
                return db.PhotoRepository.GetListOfFilesInFolder(pathLocator);
            }
        }

        private bool DownloadPhotos(string selectedPath, string photoPath, string orderCode)
        {
            bool result = false;
            try
            {
                using (var db = new UnitOfWork())
                {

                    List<Guid> fileStreamIdList = db.PhotoRepository.GetListOfOrderFilesReturnStreamIds(photoPath);
                    int counter = 0;
                    if (fileStreamIdList != null)
                    {
                        var totalFiles = fileStreamIdList.Count;
                        foreach (var guid in fileStreamIdList)
                        {
                            var file = db.PhotoRepository.DownloadOrderPhotos(guid);
                            if (file != null)
                            {
                                var directoryPathOrders = CreateOrderDirectory(selectedPath);

                                var directoryPathOrderCode = CreateOrderCodeDirectory(orderCode, directoryPathOrders);

                                string fileNameAndPath = directoryPathOrderCode + file.name;

                                #region Method 1

                                //using (var fileStream = new FileStream(fileNameAndPath, FileMode.Create, FileAccess.Write))
                                //{
                                //    byte[] bytes = new byte[file.fileStream.Length];
                                //    file.fileStream.Read(bytes, 0, (int)file.fileStream.Length);
                                //    fileStream.Write(bytes, 0, bytes.Length);
                                //    //ms.Close();
                                //}

                                #endregion

                                #region Method 2 
                                //.NET 4+
                                using (var fileStream = new FileStream(fileNameAndPath, FileMode.Create,
                                    FileAccess.Write))
                                {
                                    bool fileExists = File.Exists(fileNameAndPath);
                                    DialogResult dr = DialogResult.None;
                                    if (fileExists)
                                    {
                                        dr = RtlMessageBox.Show(
                                            "این فایل قبلا در سیستم ذخیره شده است. آیا می خواهید بازنویسی شود؟" +
                                            Environment.NewLine +
                                            "در صورت تایید محتوای فایل قبلی از بین می رود.",
                                            "تائید بازنویسی فایل",
                                            MessageBoxButtons.YesNo);
                                    }

                                    if (dr == DialogResult.Yes)
                                    {
                                        file.fileStream.WriteTo(fileStream);
                                        if (fileStream.Length == file.fileStream.Length)
                                        {

                                            fileStream.Flush();
                                            fileStream.Close();
                                        }
                                        else
                                        {
                                            RtlMessageBox.Show(
                                                "ذخیره فایل با نام " + file.name +
                                                " با مشکل مواجه شد. حجم فایل سرور با فایل ذخیره شده تطابق ندارد.",
                                                "خطا در ذخیره فایل در سیستم کاربر",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    counter++;
                                }
                                #endregion
                            }
                        }

                        if (totalFiles > 0 && counter > 0 && counter == totalFiles)
                            result = true;
                    }

                }
            }
            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(notSupportedException.Message);
                return false;
            }
            catch (IOException ioException)
            {
                MessageBox.Show(ioException.Message);
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }

            return result;

        }

        private static string CreateOrderCodeDirectory(string orderCode, string directoryPathOrders)
        {
            string directoryPathOrderCode = directoryPathOrders + "\\" + orderCode + "\\";
            bool folderExistsOrderCode = Directory.Exists(directoryPathOrderCode);
            if (!folderExistsOrderCode)
                Directory.CreateDirectory(directoryPathOrderCode);
            return directoryPathOrderCode;
        }

        private static string CreateOrderDirectory(string selectedPath)
        {
            string directoryPathOrders = selectedPath + "\\" + "Orders";
            bool folderExistsOrders = Directory.Exists(directoryPathOrders);
            if (!folderExistsOrders)
                Directory.CreateDirectory(directoryPathOrders);
            return directoryPathOrders;
        }

        private void OpenFolder(string selectedPath)
        {
            ////Method 1
            //try
            //{
            //    Process.Start("explorer.exe", selectedPath);
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(@"Exception: " + Environment.NewLine + exception.Message);
            //}

            ////Method 2
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = selectedPath,
                    UseShellExecute = true,
                    Verb = "open",
                    WindowStyle = ProcessWindowStyle.Normal,
                    ErrorDialog = true
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Exception: " + Environment.NewLine + exception.Message);
            }
        }

        #endregion
    }
}