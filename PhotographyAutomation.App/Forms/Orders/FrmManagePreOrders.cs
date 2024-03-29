﻿using DevComponents.DotNetBar.Controls;
using Ookii.Dialogs.WinForms;
using PhotographyAutomation.App.Forms.Booking;
using PhotographyAutomation.App.Forms.Customers;
using PhotographyAutomation.App.Forms.EntranceToAtelier;
using PhotographyAutomation.DateLayer.Context;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.Utilities;
using PhotographyAutomation.Utilities.Convertor;
using PhotographyAutomation.Utilities.ExtentionMethods;
using PhotographyAutomation.ViewModels.Order;
using PhotographyAutomation.ViewModels.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotographyAutomation.App.Forms.Orders
{
    public partial class FrmManagePreOrders : Form
    {
        #region Variables

        private int _statusCode;
        //private int _customerId;

        private string _downloadSelectedPath;
        private string _downloadedAllPhotosPath;

        //private bool _customerIsSelectedOrderFiles;

        #endregion


        #region Form Events

        public FrmManagePreOrders()
        {
            InitializeComponent();
        }

        private void FrmManagePreOrders_Load(object sender, EventArgs e)
        {
            PopulateComboBox();

            menuStrip1.Enabled = false;
            btnShowOrders.Enabled = !backgroundWorker.IsBusy;
            btnClearSearch.Enabled = !backgroundWorker.IsBusy;
        }

        #endregion


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

            if (dgvUploads.Rows.Count > 0)
            {
                menuStrip1.Enabled = true;
            }
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

        #region Persian English Type

        private void txtCustomerInfo_Enter(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void txtCustomerInfo_Leave(object sender, EventArgs e)
        {
            var language = new System.Globalization.CultureInfo("en-US");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        #endregion Persian English Type

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
                    var listOfFiles = GetListOfFilesOfOrder(pathLocator);
                    if (listOfFiles is List<PhotoViewModel> list)
                    {
                        if (list.Any())
                        {
                            using (var frmViewUploadedPhotos = new FrmViewEditUploadedPhotos())
                            {
                                frmViewUploadedPhotos.ListOfPhotos = list;
                                frmViewUploadedPhotos.OrderCode =
                                    dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
                                frmViewUploadedPhotos.CustomerName = dgvUploads.SelectedRows[0]
                                    .Cells["clmCustomerFullName"]
                                    .Value.ToString();
                                frmViewUploadedPhotos.PhotographyDate =
                                    dgvUploads.SelectedRows[0].Cells["clmDate"].Value.ToString();
                                frmViewUploadedPhotos.TotalPhotos =
                                    (int)dgvUploads.SelectedRows[0].Cells["clmTotalFiles"].Value;
                                frmViewUploadedPhotos.OrderStatus =
                                    dgvUploads.SelectedRows[0].Cells["clmStatusName"].Value.ToString();

                                frmViewUploadedPhotos.ShowDialog();

                            }

                            GC.Collect();
                        }
                        else
                        {
                            var dialogResult = MessageBox.Show(
                                @"برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                                @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                                @"خطا در دریافت لیست عکس های سفارش",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Error);
                            if (dialogResult == DialogResult.Retry)
                            {
                                goto RetryGetListOfPhotos;
                            }
                        }
                    }
                    else if (listOfFiles is Exception exception)
                    {
                        ShowException(exception);
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show(
                            @"برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                            @"خطا در دریافت لیست عکس های سفارش",
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
                    MessageBox.Show(
                        @"برای رزرو انتخابی هنوز عکسی در سیستم قرار داده نشده است.",
                        @"عدم آپلود عکس برای رزرو انتخابی",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message);
            //}
        }

        private void dgvUploads_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvUploads.Rows.Count > 0)
                {
                    int currentMouseOverRow = dgvUploads.HitTest(e.X, e.Y).RowIndex;
                    if (currentMouseOverRow > -1)
                    {
                        dgvUploads.Rows[currentMouseOverRow].Selected = true;
                        //DataGridViewRow row = dgvBookings.Rows[currentMouseOverRow];
                    }
                    else
                    {
                        contextMenuDgvUploads.Visible = false;
                    }
                }
                else
                {
                    contextMenuDgvUploads.Visible = false;
                }
            }
        }

        #endregion DataGridView Events


        #region Methods

        private void ShowAllOrders()
        {
            try
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
                        MessageBox.Show(
                            @"هیچ سفارشی در سیستم ثبت نشده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void ShowOrdersByOrderCode(string orderCode)
        {
            try
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
                        MessageBox.Show(
                            @"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }

                dgvUploads.ClearSelection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }



        private void ShowOrders(string customerInfo)
        {
            try
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
                        MessageBox.Show(
                            @"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }

                dgvUploads.ClearSelection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowOrders(DateTime orderDate)
        {
            try
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
                        MessageBox.Show(
                            @"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }

                dgvUploads.ClearSelection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowOrders(int orderStatusId)
        {
            try
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
                        MessageBox.Show(
                            @"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }

                dgvUploads.ClearSelection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowOrders(int orderStatusId, DateTime statusDate)
        {
            try
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
                        MessageBox.Show(
                            @"برای مشتری با اطلاعات داده شده رزروی ثبت نگردیده است.",
                            @"",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvUploads.Rows.Clear();
                    }
                }

                dgvUploads.ClearSelection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }



        private void PopulateDataGridView(IReadOnlyList<CustomerOrderViewModel> ordersList)
        {
            dgvUploads.Rows.Clear();

            if (ordersList.Count > 0)
            {
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
                    dgvUploads.Rows[i].Cells["clmOrderCode"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                    dgvUploads.Rows[i].Cells["clmTotalFiles"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                    dgvUploads.Rows[i].Cells["clmPersonCount"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                    dgvUploads.Rows[i].Cells["clmUploadDate"].Style.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }


        private bool CheckInputs()
        {
            if (rbOrderCode.Checked)
            {
                if (string.IsNullOrEmpty(txtOrderCodeDate.Text.Trim()) ||
                    string.IsNullOrEmpty(txtOrderCodeCustomerIdBookingId.Text.Trim()))
                {
                    MessageBox.Show(
                        @"شناسه سفارش به درستی وارد نشده است.",
                        @"خطا در ورود اطلاعات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (rbCustomerInfo.Checked)
            {
                if (string.IsNullOrEmpty(txtCustomerInfo.Text.Trim()))
                {
                    MessageBox.Show(
                        @"اطلاعات مشتری وارد نشده است.",
                        @"خطا در ورود اطلاعات",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtCustomerInfo.Focus();
                    return false;
                }
            }

            return true;
        }





        private bool OrderDownloadedBefore(string folderBrowserSelectedPath, string orderCode)
        {
            bool result = false;

            string downloadPath = folderBrowserSelectedPath + "\\" + "Orders" + "\\" + orderCode;
            if (Directory.Exists(downloadPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(downloadPath);
                var filesOfDirectory = directoryInfo.GetFiles().ToList();
                if (filesOfDirectory.Any())
                    result = true;
            }

            return result;
        }


        private static string CreateOrderCodeDirectory(string orderCode, string directoryPathOrders)
        {
            try
            {
                string directoryPathOrderCode = directoryPathOrders + "\\" + orderCode + "\\";
                bool folderExistsOrderCode = Directory.Exists(directoryPathOrderCode);
                if (!folderExistsOrderCode)
                    Directory.CreateDirectory(directoryPathOrderCode);
                return directoryPathOrderCode;
            }

            #region catch

            catch (IOException ioException)
            {
                MessageBox.Show(@"ioException: " + Environment.NewLine +
                                ioException.Message);
                return null;
            }
            catch (UnauthorizedAccessException accessException)
            {
                MessageBox.Show(@"accessException: " + Environment.NewLine +
                                accessException.Message);
                return null;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(@"argumentException: " + Environment.NewLine +
                                argumentException.Message);
                return null;
            }
            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(@"notSupportedException: " + Environment.NewLine +
                                notSupportedException.Message);
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + Environment.NewLine +
                                exception.Message);
                return null;
            }

            #endregion
        }

        private static string CreateOrderDirectory(string selectedPath)
        {
            try
            {
                string directoryPathOrders = selectedPath + "\\" + "Orders";
                bool folderExistsOrders = Directory.Exists(directoryPathOrders);
                if (!folderExistsOrders)
                    Directory.CreateDirectory(directoryPathOrders);
                return directoryPathOrders;
            }

            #region catch

            catch (IOException ioException)
            {
                MessageBox.Show(@"ioException: " + Environment.NewLine +
                                ioException.Message);
                return null;
            }
            catch (UnauthorizedAccessException accessException)
            {
                MessageBox.Show(@"accessException: " + Environment.NewLine +
                                accessException.Message);
                return null;
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(@"argumentException: " + Environment.NewLine +
                                argumentException.Message);
                return null;
            }
            catch (NotSupportedException notSupportedException)
            {
                MessageBox.Show(@"notSupportedException: " + Environment.NewLine +
                                notSupportedException.Message);
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"exception: " + Environment.NewLine +
                                exception.Message);
                return null;
            }

            #endregion
        }





        private void PopulateComboBox()
        {
            try
            {
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    @"اطلاعات وضعیت رزروها از سیستم قابل دریافت نمی باشد." +
                    @" لطفا فرم را بسته و مجددا باز کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید. ",
                    @"خطا در دریافت اطلاعات از سیستم",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                MessageBox.Show(@"exception: " + exception.Message + Environment.NewLine +
                                @"Inner exception: " + exception.InnerException + Environment.NewLine +
                                @"HResult: " + exception.HResult + Environment.NewLine +
                                @"Source: " + exception.Source + Environment.NewLine);

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.OrderStatusGenericRepository.Get(x => x.Code != 10)
                        .Select(x => new OrderStatusViewModel
                        {
                            Id = x.Id,
                            StatusCode = x.Code,
                            Name = x.Name
                        }).ToList();

                    e.Result = result;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null /*&& e.Result is OrderStatusViewModel viewModel*/)
                {
                    cmbOrderStatus.DataSource = e.Result;
                    cmbOrderStatus.DisplayMember = "Name";
                    cmbOrderStatus.ValueMember = "Id";

                    btnShowOrders.Enabled = !backgroundWorker.IsBusy;
                    btnClearSearch.Enabled = !backgroundWorker.IsBusy;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion


        #region Top MenuStrip

        private void مشاهده_عکس_ها_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //مشاهده_عکس_ها_ToolStripMenuItem_Click(null, null);
        }

        private void دریافت_عکس_هاToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            دریافت_عکس_ها_ToolStripMenuItem_Click(null, null);
        }

        private void مشاهده_اطلاعات_مشتری_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            مشاهده_اطلاعات_مشتری_ToolStripMenuItem_Click(null, null);
        }

        private void مشاهده_اطلاعات_رزرو_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            مشاهده_اطلاعات_رزرو_ToolStripMenuItem_Click(null, null);

        }

        private void ثبت_پیش_فاکتور_ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ثبت_پیش_فاکتور_ToolStripMenuItem1_Click(null, null);
        }


        #endregion Top MenuStrip


        #region DataGridView Contextmenu

        private void contextMenuDgvUploads_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void مشاهده_عکس_ها_ToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //RetryGetListOfPhotos:
        //    try
        //    {
        //        if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
        //        {
        //            MessageBox.Show("رزروی برای مشاهده عکس انتخاب نشده است.");
        //            return;
        //        }

        //        var pathLocator = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();

        //        if (pathLocator != null)
        //        {
        //            List<PhotoViewModel> listOfFiles = GetListOfFilesOfOrder(pathLocator);
        //            if (listOfFiles != null)
        //            {
        //                using (var frmViewUploaded = new FrmViewEditUploadedPhotos())
        //                {
        //                    frmViewUploaded.ListOfPhotos = listOfFiles;
        //                    frmViewUploaded.OrderCode = dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
        //                    frmViewUploaded.CustomerName = dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"].Value.ToString();
        //                    frmViewUploaded.PhotographyDate = dgvUploads.SelectedRows[0].Cells["clmDate"].Value.ToString();
        //                    frmViewUploaded.TotalPhotos = (int)dgvUploads.SelectedRows[0].Cells["clmTotalFiles"].Value;
        //                    frmViewUploaded.OrderStatus = dgvUploads.SelectedRows[0].Cells["clmStatusName"].Value.ToString();
        //                    frmViewUploaded.ShowDialog();
        //                    GC.Collect();
        //                }
        //            }
        //            else
        //            {
        //                var dialogResult = MessageBox.Show(
        //                    "برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
        //                    "لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
        //                    "خطا در دریافت لیست عکس های سفارش",
        //                    MessageBoxButtons.RetryCancel,
        //                    MessageBoxIcon.Error);
        //                if (dialogResult == DialogResult.Retry)
        //                {
        //                    goto RetryGetListOfPhotos;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        if (exception.HResult == -2146233086)
        //        {
        //            MessageBox.Show("رزروی برای مشاهده عکس انتخاب نشده است.", "",
        //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        private void دریافت_عکس_ها_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUploads.SelectedRows[0] == null)
                {
                    MessageBox.Show(@"رزروی برای دریافت عکس انتخاب نشده است.");
                    return;
                }

                var photoPath = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();
                var orderCode = dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
                if (photoPath == null)
                {
                    MessageBox.Show(
                        @"عکسی برای این سفارش در سیستم ثبت نشده است.",
                        @"خطا در دریافت عکس های سفارش",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                bool resultDownload = DowloadOrderPhotos(photoPath, orderCode);
                if (resultDownload)
                {
                    if (MessageBox.Show(
                            @"فایل ها با موفقیت در سیستم دریافت شد. آیا فولدر نگهداری آنها باز شود؟",
                            @"",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)

                    {
                        _downloadedAllPhotosPath = _downloadSelectedPath + "\\" + "Orders" + "\\" + orderCode;
                        OpenFolder(_downloadedAllPhotosPath);
                        GC.Collect();
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146233086)
                {
                    MessageBox.Show(@"رزروی برای دریافت عکس انتخاب نشده است.", @"",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(exception.Message);
            }
        }





        private void مشاهده_اطلاعات_مشتری_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
                {
                    MessageBox.Show(@"مشتری برای مشاهده اطلاعات انتخاب نشده است.");
                    return;
                }

                if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value.ToString(),
                    out int customerId))
                {
                    MessageBox.Show(
                        @"مشتری برای مشاهده اطلاعات انتخاب نشده است و یا اطلاعات مشتری قابل دریافت نمی باشد.");
                    return;
                }

                using (var frmCustomerInfo = new FrmAddEditCustomerInfo())
                {
                    frmCustomerInfo.CustomerId = customerId;
                    frmCustomerInfo.NewCustomer = true;
                    frmCustomerInfo.IsViewOnly = true;
                    frmCustomerInfo.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146233086)
                {
                    MessageBox.Show(@"مشتری برای مشاهده اطلاعات انتخاب نشده است.", @"",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(exception.Message);
            }
        }

        private void مشاهده_اطلاعات_رزرو_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
                {
                    MessageBox.Show(@"رزروی برای مشاهده اطلاعات انتخاب نشده است.");
                    return;
                }

                //clmBookingId
                if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmBookingId"].Value.ToString(),
                        out int bookingId) ||
                    !int.TryParse(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value.ToString(),
                        out int customerId))
                {
                    MessageBox.Show(
                        @"رزروی برای مشاهده اطلاعات انتخاب نشده است و یا اطلاعات رزرو انتخابی قابل دریافت نمی باشد.");
                    return;
                }
                //if (!int.TryParse(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value.ToString(),
                //    out int customerId)) return;

                using (var frmAddEditBooking = new FrmAddEditBooking())
                {
                    frmAddEditBooking.BookingId = bookingId;
                    frmAddEditBooking.CustomerId = customerId;
                    frmAddEditBooking.IsViewOnly = true;
                    frmAddEditBooking.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146233086)
                {
                    MessageBox.Show(@"رزروی برای مشاهده اطلاعات انتخاب نشده است.", @"",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(exception.Message);
            }
        }

        private void ارسال_عکسهای_انتخاب_شده_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmUploadSelectedPhotos = new FrmUploadSelectedPhotos())
            {
                frmUploadSelectedPhotos.ShowDialog();
            }
        }

        private void ویرایش_عکسهای_انتخاب_شده_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void انتخاب_عکس_ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ////    آیا اصلا رکوردی از دیتاگرید ویو انتخاب شده است؟
        //    if (dgvUploads.CurrentRow == null || dgvUploads.SelectedRows[0] == null) return;

        //    var orderCode = dgvUploads.SelectedRows[0].Cells["clmOrderCode"].Value.ToString();
        //    var orderId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmId"].Value);

        //    ////    آیا عکس های اصلی آپلود شده است؟
        //    if (CheckIfOrderFilesUploaded(orderId) == false)
        //    {
        //        ////    مشاهده فرم آپلود عکس ها
        //        //ShowPhotoUploadingForm(orderId);  
        //        MessageBox.Show(
        //            "لطفا در ابتدا عکس های اصلی را در سیستم آپلود نمایید.",
        //            "ارسال عکس های اصلی به سرور",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    ////    آیا فاکتور برای همین مشتری صادر شود؟
        //    var customerName = dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"].Value.ToString();
        //    if (CheckPreFactorIssuedForThisCustomer(customerName) == false)
        //    {
        //        _customerId = ShowCustomerSearchForm();

        //        if (_customerId == 0) // user clicked no
        //        {
        //            MessageBox.Show(
        //                "هیچ کاربری برای ثبت پیش فاکتور انتخاب نگردید. " +
        //                $"پیش فاکتور به نام {customerName} صادر می گردد.",
        //                "ثبت پیش فاکتور",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //            _customerId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value);
        //        }
        //    }
        //    else
        //    {
        //        _customerId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value);
        //    }


        //    ////    آیا قبلا این مشتری برای این اوردر پیش فاکتوری داشته است؟
        //    var tt = CustomerHasOrderPrintForThisOrder(orderId, _customerId);
        //    if (tt is List<TblOrderPrint> list)
        //    {
        //        /*
        //        ////    فرایند انتخاب عکس
        //        ////     1-دانلود عکس های اصلی روی سیستم رتوش کار
        //        ////     1-1حذف عکس هایی که مشتری آنها را نمی خواهد از فلودر عکس های دانلود شده
        //        ////     2-مشاهده عکس های اصلی مشتری
        //        ////     3-انتخاب فولدر حاوی عکس های انتخابی مشتری
        //        ////     4-همگام سازی عکس های داخل فولدر با عکس های نشان داده شده
        //        ////     5-ارسال عکس های انتخابی به سرور
        //        ////     6-مشاهده فرم پیش فاکتور
        //        //////////////////////////////////////////////////////////////////////**/

        //        ////     1-دانلود عکس های اصلی روی سیستم رتوش کار
        //        ////
        //        ////     2-مشاهده عکس های اصلی مشتری

        //        var drDownloadAllCustomerPhotos = MessageBox.Show(
        //            "آیا می خواهید تمامی عکس ها روی سیستم دانلود شود؟",
        //            "",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);
        //        if (drDownloadAllCustomerPhotos == DialogResult.Yes)
        //        {
        //            var photoPath = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();
        //            if (DowloadOrderPhotos(photoPath, orderCode)) //=>_downloadedAllPhotosPath
        //            {

        //                ////     2-مشاهده عکس های اصلی مشتری
        //                if (MessageBox.Show(
        //                        "فایل ها با موفقیت در سیستم دریافت شد. " +
        //                        "آیا فولدر مربوطه باز شود؟",
        //                        "",
        //                        MessageBoxButtons.YesNo,
        //                        MessageBoxIcon.Question,
        //                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //                {
        //                    _downloadedAllPhotosPath = _downloadSelectedPath + "\\" + "Orders" + "\\" + orderCode;
        //                    OpenFolder(_downloadedAllPhotosPath);
        //                    GC.Collect();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }

        //        ////     3-انتخاب فولدر حاوی عکس های انتخابی مشتری
        //        var drCustomerSelectedPhotosReady = MessageBox.Show(
        //            "آیا عکس های انتخابی مشتری آماده آپلود است؟",
        //            "",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question,
        //            MessageBoxDefaultButton.Button2);
        //        if (drCustomerSelectedPhotosReady == DialogResult.Yes)
        //        {
        //            ////    نمایش فرم آپلود عکس های مشتری جهت ارسال عکس های انتخاب شده
        //            if (ShowPhotoUploadingForm(orderId))
        //            {
        //                ////     5-ارسال عکس های انتخابی به سرور

        //                ////    آیا مشتری انتخاب عکس خود را انجام داده است؟

        //                if (list.Any())
        //                {
        //                    ////     6-مشاهده فرم پیش فاکتور
        //                    ShowAddEditPreFactor(_customerId, orderId);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }



        //    }
        //    else if (tt is Exception exception)
        //    {
        //        MessageBox.Show(
        //            "دریافت اطلاعات پیش فاکتورهای قبلی مشتری از سیستم با مشکل مواجه شد. " +
        //            "لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید." + Environment.NewLine +
        //            "Message: " + exception.Message + Environment.NewLine +
        //            "Hresult: " + exception.HResult + Environment.NewLine +
        //            "Inner Exception: " + exception.InnerException,
        //            "بروز خطا در دریافت اطلاعات",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);

        //    }
        //    else
        //    {
        //        ////    چک کن ببین مشتری می خواهد تغییراتی در عکس های انتخابی خود داشته باشد یا خیر
        //        ///     اگر تغییرات دارد، فرم عکس های اصلی نشان داده شود و عکس های انتخابی تیک بخورد
        //        ///     عکس های انتخابی به سرور آپلود شود
        //        ///     مشاهده فرم پیش فاکتور قبلی      
        //        ///
        //        ///     اگر مشتری تغییراتی ندارد فرم پیش فاکتور نمایش داده شود
        //        ///     اگر قبلا پیش فاکتوری صادر شده است و وضعیت آن هنوز تکمیل نشده است، پیش فاکتور قبلی نمایش داده شود
        //        ///     اگر 
        //    }
        //}

        private object CustomerHasOrderPrintForThisOrder(int orderId, int customerId)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    List<TblOrderPrint> customerOrderPrintsList = db.OrderPrintGenericRepository.Get(
                            x =>
                                x.OrderId == orderId &&
                                x.CustomerId == customerId)
                        .ToList();
                    return customerOrderPrintsList;
                }
            }
            catch (Exception exception)
            {
                return exception;
            }
        }


        //private void ثبت_پیش_فاکتور_ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ////var customerId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value);
        //    ////if (CheckCustomerActivity(customerId) == false) return;



        //    ////    بررسی وضعیت سفارش
        //    ////    جهت ثبت پیش فاکتور


        //    ////    آیا اصلا رکوردی از دیتاگرید ویو انتخاب شده است؟
        //    if (dgvUploads.CurrentRow == null || dgvUploads.SelectedRows[0] == null) return;



        //    var orderCode = dgvUploads.SelectedRows[0].Cells["clmOrderCode"].Value.ToString();
        //    var orderId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmId"].Value);

        //    ////    آیا عکس های اصلی آپلود شده است؟
        //    if (CheckIfOrderFilesUploaded(orderId) == false)
        //    {
        //        ////    مشاهده فرم آپلود عکس ها
        //        ShowPhotoUploadingForm(orderId);
        //    }





        //    ////    چک کن ببین عکس های انتخابی مشتری ارسال شده است یا خیر؟
        //    if (CustomerSelectedFilesIsUploadedBefore() == false)
        //    {
        //        //چک کن ببین قبلا فایل  ها دانلود شده است؟
        //        var drDownloadAllCustomerPhotos = MessageBox.Show(
        //            "آیا می خواهید تمامی عکس ها روی سیستم دانلود شود؟",
        //            "",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);
        //        if (drDownloadAllCustomerPhotos == DialogResult.Yes)
        //        {
        //            var photoPath = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();
        //            if (DowloadOrderPhotos(photoPath, orderCode)) //=>_downloadedAllPhotosPath
        //            {
        //                if (MessageBox.Show(
        //                        "فایل ها با موفقیت در سیستم دریافت شد. " +
        //                        "آیا فولدر مربوطه باز شود؟",
        //                        "",
        //                        MessageBoxButtons.YesNo,
        //                        MessageBoxIcon.Question,
        //                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //                {
        //                    _downloadedAllPhotosPath = _downloadSelectedPath + "\\" + "Orders" + "\\" + orderCode;
        //                    OpenFolder(_downloadedAllPhotosPath);
        //                    GC.Collect();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }


        //        ////اگر عکس های انتخابی مشتری آماده شده است ولی هنوز آپلود نشده است. 
        //        var drCustomerSelectedPhotosReady = MessageBox.Show(
        //            "آیا عکس های انتخابی مشتری آماده آپلود است؟",
        //            "",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question,
        //            MessageBoxDefaultButton.Button2);
        //        if (drCustomerSelectedPhotosReady == DialogResult.Yes)
        //        {
        //            ////نمایش فرم آپلود عکس های مشتری جهت ارسال عکس های انتخاب شده
        //            if (ShowPhotoUploadingForm(orderId))
        //            {
        //                ////مشتری انتخاب عکس خود را انجام داده است.
        //                _customerIsSelectedOrderFiles = true;
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //        //
        //    }


        //    ////آیا فاکتور برای همین مشتری صادر شود؟
        //    var customerName = dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"].Value.ToString();
        //    if (CheckPreFactorIssuedForThisCustomer(customerName) == false)
        //    {
        //        _customerId = ShowCustomerSearchForm();

        //        if (_customerId == 0) // user clicked no
        //        {
        //            MessageBox.Show(
        //                "هیچ کاربری برای ثبت پیش فاکتور انتخاب نگردید. " +
        //                $"پیش فاکتور به نام {customerName} صادر می گردد.",
        //                "ثبت پیش فاکتور",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //            _customerId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value);
        //        }
        //    }
        //    else
        //    {
        //        _customerId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmCustomerId"].Value);
        //    }

        //    //if (CheckOrderPhotosIsSelected(_customerId, orderId) == true ||
        //    //    _customerIsSelectedOrderFiles == true) /*آیا مشتری انتخاب عکس انجام داده است؟*/
        //    //{
        //    //    if (CheckIfCustomerHasChangesInPhotosSelected()) /*آیا مشتری در سفارش خود می خواهد تغییراتی انجام دهد؟*/
        //    //    {
        //    //        if (CheckIfCustomerWantsToAddSomePhotosToSelectedPhotos())
        //    //        {
        //    //            string downloadPath = null;
        //    //            downloadPath = DownloadAllOrderPhotos();
        //    //            ShowDownloadedFolder(downloadPath);
        //    //            downloadPath = DownloadSelectedPhotos();
        //    //            ShowDownloadedFolder(downloadPath);
        //    //            ShowPhotoUploadingForm();
        //    //            ShowPreFactorForm();
        //    //        }
        //    //        else if (CheckIfCustomerWantsToAddSomePhotosToSelectedPhotos() == false)
        //    //        {
        //    //            ShowUploadedPhotos();
        //    //            ShowPreFactorForm();
        //    //        }
        //    //    }
        //    //    else if (CheckIfCustomerHasChangesInPhotosSelected() == false)
        //    //    {
        //    //        ShowUploadedPhotos();
        //    //        ShowPreFactorForm();
        //    //    }
        //    //}
        //    //else if (CheckOrderPhotosIsSelected(customerId, orderId) == false)
        //    //{
        //    //    string downloadPath = null;
        //    //    downloadPath = DownloadAllOrderPhotos();
        //    //    ShowDownloadedFolder(downloadPath);
        //    //    ShowPhotoUploadingForm();
        //    //    ShowPreFactorForm();
        //    //}
        //}


        private static int ShowCustomerSearchForm()
        {
            int customerId = 0;
            using (var searchCustomerForm = new FrmShowCustomer())
            {
                searchCustomerForm.CustomerIdForPreFactor = true;
                if (searchCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    customerId = searchCustomerForm.CustomerId;
                }
            }

            return customerId;
        }

        private static bool CheckPreFactorIssuedForThisCustomer(string customerName)
        {
            DialogResult dr = MessageBox.Show(
                $@"آیا پیش فاکتور به نام {customerName} صادر گردد؟",
                @"صدور فاکتور",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
                return true;
            return false;
        }




        private static bool CheckIfOrderFilesUploaded(int orderId)
        {
            var result = false;
            try
            {
                using (var db = new UnitOfWork())
                {
                    var orderFiles = db.OrderFilesGenericRepository.Get(x => x.OrderId == orderId);
                    result = orderFiles.Any();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result = false;
            }

            return result;
        }

        private bool CheckCustomerActivity(int customerId)
        {
            bool result = false;
            try
            {
                using (var db = new UnitOfWork())
                {
                    var customer = db.CustomerGenericRepository.GetById(customerId);
                    if (customer != null)
                    {
                        if (customer.IsActive != 0 && customer.IsDeleted != 0)
                            result = true;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result = false;
            }

            return result;
        }



        #endregion DataGridView Contextmenu


        /*********************************************************************************************************/
        private static void ShowException(Exception exception)
        {
            MessageBox.Show(@"خطا در سیستم.", @"", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var sb = new StringBuilder();
            sb.Append("Exception: " + Environment.NewLine);
            sb.Append($" Message: {exception.Message}" + Environment.NewLine);
            sb.Append($@"HResult: {exception.HResult}" + Environment.NewLine);
            sb.Append($@"Inner Exception: {exception.InnerException}");

            MessageBox.Show(sb.ToString(), @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





        private void ارسال_عکس_های_اصلی_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////    آیا اصلا رکوردی از دیتاگرید ویو انتخاب شده است؟
            if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
            {
                MessageBox.Show(@"رزروی برای مشاهده عکس انتخاب نشده است.");
                return;
            }


            var orderCode = dgvUploads.SelectedRows[0].Cells["clmOrderCode"].Value.ToString();
            var orderId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmId"].Value);

            var resultOrderFilesIsUploaded = OrderFilesIsUploaded(orderId);
            if (resultOrderFilesIsUploaded is List<TblOrderFiles> orderFilesIsUploaded)
            {
                if (orderFilesIsUploaded.Any())
                {
                    MessageBox.Show(
                        @"عکس های این سفارش قبلا آپلود شده است.",
                        @"",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    var tt = ShowPhotoUploadingForm(orderId);
                    if (tt is bool resultShowPhotoUploadingForm)
                    {
                        if (resultShowPhotoUploadingForm)
                        {
                            //نمایش وضعیت دیتاگرید ویو به آپلود شده تغییر یابد
                        }
                        else
                        {
                            //نمایش وضعیت دیتاگرید ویو به آپلود نشده تغییر یابد
                        }
                    }
                    else if (tt == null)
                    {
                        MessageBox.Show(@"خطا در دریافت اطلاعات سفارش." +
                                        @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر  سیستم تماس بگیرید.");
                    }
                    else if (tt is Exception exception)
                    {
                        ShowException(exception);
                    }
                }
            }
            else if (resultOrderFilesIsUploaded is Exception exception)
            {
                ShowException(exception);
            }
        }

        private static object OrderFilesIsUploaded(int orderId)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var result = db.OrderFilesGenericRepository.Get(x => x.OrderId == orderId).ToList();
                    return result;
                }
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        private static object ShowPhotoUploadingForm(int orderId)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    var order = db.OrderGenericRepository.GetById(orderId);
                    if (order != null)
                    {
                        using (var uploadForm = new FrmUploadPhotos())
                        {
                            uploadForm.OrderCode = order.OrderCode;
                            uploadForm.BookingId = order.BookingId;
                            uploadForm.CustomerId = order.CustomerId;
                            uploadForm.OrderId = orderId;

                            if (uploadForm.ShowDialog() == DialogResult.OK)
                            {
                                return true;
                            }

                            return false;
                        }
                    }

                    return null;
                }
            }
            catch (Exception exception)
            {
                return exception;
            }
        }




        private void مشاهده_همه_عکس_ها_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        RetryGetListOfPhotos:

            ////    آیا اصلا رکوردی از دیتاگرید ویو انتخاب شده است؟
            if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
            {
                MessageBox.Show(@"رزروی برای مشاهده عکس انتخاب نشده است.");
                return;
            }

            var pathLocator = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();

            if (pathLocator != null)
            {
                var files = GetListOfFilesOfOrder(pathLocator);

                if (files is List<PhotoViewModel> listOfFiles)
                {
                    if (listOfFiles.Any())
                    {
                        using (var frmViewUploaded = new FrmViewEditUploadedPhotos())
                        {
                            frmViewUploaded.ListOfPhotos = listOfFiles;

                            frmViewUploaded.OrderCode =
                                dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();

                            frmViewUploaded.CustomerName =
                                dgvUploads.SelectedRows[0].Cells["clmCustomerFullName"].Value.ToString();

                            frmViewUploaded.PhotographyDate =
                                dgvUploads.SelectedRows[0].Cells["clmDate"].Value.ToString();

                            frmViewUploaded.TotalPhotos =
                                (int)dgvUploads.SelectedRows[0].Cells["clmTotalFiles"].Value;

                            frmViewUploaded.OrderStatus =
                                dgvUploads.SelectedRows[0].Cells["clmStatusName"].Value.ToString();

                            frmViewUploaded.ShowDialog();
                            GC.Collect();
                        }
                    }
                    else
                    {
                        var dialogResult = MessageBox.Show(
                            @"برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                            @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                            @"خطا در دریافت لیست عکس های سفارش",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error);
                        if (dialogResult == DialogResult.Retry)
                        {
                            goto RetryGetListOfPhotos;
                        }
                    }

                }
                else if (files is Exception exception)
                {
                    if (exception.HResult == -2146233086)
                    {
                        MessageBox.Show(@"رزروی برای مشاهده عکس انتخاب نشده است.", @"",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        ShowException(exception);
                }
                else
                {
                    MessageBox.Show(@"سیستم قادر به نمایش عکس های مشتری نمی باشد. " +
                                    @"لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.");
                }
            }
        }

        public object GetListOfFilesOfOrder(string pathLocator)
        {
            try
            {
                using (var db = new UnitOfWork())
                {
                    List<PhotoViewModel> tt = db.PhotoRepository.GetListOfFilesInFolder(pathLocator);
                    return tt;
                }
            }
            catch (Exception exception)
            {
                return exception;
            }
        }




        private void دریافت_همه_عکس_ها_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUploads.SelectedRows[0] == null)
                {
                    MessageBox.Show(@"رزروی برای دریافت عکس انتخاب نشده است.");
                    return;
                }

                var photoPath = dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();
                var orderCode = dgvUploads.SelectedRows[0]?.Cells["clmOrderCode"].Value.ToString();
                if (photoPath == null)
                {
                    MessageBox.Show(
                        @"عکسی برای این سفارش در سیستم ثبت نشده است.",
                        @"خطا در دریافت عکس های سفارش",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                bool resultDownload = DowloadOrderPhotos(photoPath, orderCode);
                if (resultDownload)
                {
                    if (MessageBox.Show(
                            @"فایل ها با موفقیت در سیستم دریافت شد. آیا فولدر نگهداری آنها باز شود؟",
                            @"",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)

                    {
                        _downloadedAllPhotosPath = _downloadSelectedPath + "\\" + "Orders" + "\\" + orderCode;
                        OpenFolder(_downloadedAllPhotosPath);
                        GC.Collect();
                    }
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146233086)
                {
                    MessageBox.Show(@"رزروی برای دریافت عکس انتخاب نشده است.", @"",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(exception.Message);
            }
        }

        private bool DowloadOrderPhotos(string photoPath, string orderCode)
        {
            bool resultDownload = false;
            using (var folderBrowser = new VistaFolderBrowserDialog())
            {
                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowser.ShowNewFolderButton = true;
                folderBrowser.Description = @"لطفا محل ذخیره عکس های مشتری را انتخاب نمایید";
                folderBrowser.UseDescriptionForTitle = true;

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    //چک ببین قبلا در این مسیر این فایل ها دانلود شده است یا خیر؟
                    if (OrderDownloadedBefore(folderBrowser.SelectedPath, orderCode) == false)
                    {
                        _downloadSelectedPath = folderBrowser.SelectedPath;
                        resultDownload = DownloadPhotos(_downloadSelectedPath, photoPath, orderCode);
                    }
                    else
                    {
                        MessageBox.Show(@"قبلا این عکس ها در مسیر انتخابی دریافت شده است.", @"", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

            return resultDownload;
        }

        private static bool DownloadPhotos(string selectedPath, string photoPath, string orderCode)
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
                            RetryCreateFolders:
                                var directoryPathOrders = CreateOrderDirectory(selectedPath);

                                var directoryPathOrderCode = CreateOrderCodeDirectory(orderCode, directoryPathOrders);
                                if (directoryPathOrders == null || directoryPathOrderCode == null)
                                {
                                    DialogResult drCreateOrderFolders = MessageBox.Show(
                                        @"خطا در ساخت فولدر های مربوط به سفارش." +
                                        Environment.NewLine +
                                        @" لطفا دوباره تلاش کنید و در صورت تکرار با مدیر سیستم تماس بگیرید.",
                                        @"",
                                        MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1);
                                    if (drCreateOrderFolders == DialogResult.Retry)
                                        goto RetryCreateFolders;
                                    else
                                        return false;
                                }

                                string fileNameAndPath = directoryPathOrderCode + file.name;

                                bool fileExists = File.Exists(fileNameAndPath);

                                DialogResult dr = DialogResult.None;
                                if (fileExists)
                                {
                                    long length = new FileInfo(fileNameAndPath).Length;

                                    Debug.Assert(file.fileSize != null, "file.fileSize != null");
                                    if (length == file.fileSize.Value)
                                    {
                                        dr = MessageBox.Show(
                                            $@"فایل  {file.name}  قبلا در سیستم ثبت شده است. آیا می خواهید بازنویسی شود؟  " +
                                            Environment.NewLine +
                                            @"در صورت تایید محتوای فایل قبلی از بین می رود." +
                                            Environment.NewLine +
                                            @"در صورت انصراف، کل فرایند دریافت فایل ها متوقف خواهد شد.",
                                            @"تائید بازنویسی فایل",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                    else
                                    {
                                        dr = MessageBox.Show(
                                            @"فایلی با همین نام ولی با حجم متفاوت در مسیر دریافت عکس ها وجود دارد. " +
                                            Environment.NewLine +
                                            @"آیا می خواهید فایل روی سیستم شما بازنویسی شود؟" +
                                            @" در صورت بازنویسی محتوای قبلی فایل از بین خواهد رفت." +
                                            Environment.NewLine +
                                            @"در صورت انصراف، کل فرایند دریافت فایل ها متوقف خواهد شد.",
                                            @"وجود عکس هم نام با سایز متفاوت در مسیر دریافت عکس ها",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    }
                                }
                                else
                                {
                                    using (var fileStream = new FileStream(fileNameAndPath, FileMode.CreateNew,
                                        FileAccess.Write))
                                    {
                                        file.fileStream.WriteTo(fileStream);
                                        if (fileStream.Length == file.fileStream.Length)
                                        {
                                            fileStream.Flush();
                                            fileStream.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(
                                                $@"ذخیره فایل با نام {file.name} " +
                                                @" با مشکل مواجه شد. حجم فایل سرور با فایل ذخیره شده تطابق ندارد.",
                                                @"خطا در ذخیره فایل در سیستم کاربر",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }

                                if (dr == DialogResult.Yes)
                                {
                                    using (var fileStream = new FileStream(fileNameAndPath, FileMode.Create,
                                        FileAccess.Write))
                                    {
                                        file.fileStream.WriteTo(fileStream);
                                        if (fileStream.Length == file.fileStream.Length)
                                        {
                                            fileStream.Flush();
                                            fileStream.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show(
                                                $@"ذخیره فایل با نام {file.name} " +
                                                @" با مشکل مواجه شد. حجم فایل سرور با فایل ذخیره شده تطابق ندارد.",
                                                @"خطا در ذخیره فایل در سیستم کاربر",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else if (dr == DialogResult.Cancel)
                                {
                                    break;
                                }

                                counter++;
                            }
                        }

                        if (totalFiles > 0 && counter > 0 && counter == totalFiles)
                            result = true;
                    }
                }
            }

            #region catch

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

            #endregion

            return result;
        }

        private static void OpenFolder(string selectedPath)
        {
            #region Method 1

            //try
            //{
            //    Process.Start("explorer.exe", selectedPath);
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(@"Exception: " + Environment.NewLine + exception.Message);
            //}

            #endregion Method 1

            #region Method 2

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

            #endregion
        }




        private void ارسال_عکس_های_انتخاب_شده_مشتری_به_سرور_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            //string orderCode;
            //int orderId = -1;
            try
            {
                if (dgvUploads.SelectedRows[0] == null || dgvUploads.CurrentRow == null)
                {
                    throw new ArgumentOutOfRangeException("رزروی برای مشاهده عکس انتخاب نشده است.");
                }

                selectedRow = dgvUploads.SelectedRows[0];

                //orderCode = dgvUploads.SelectedRows[0].Cells["clmOrderCode"].Value.ToString();
                //orderId = Convert.ToInt32(dgvUploads.SelectedRows[0].Cells["clmId"].Value);
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                if (argumentOutOfRangeException.HResult == -2146233086)
                    MessageBox.Show(@"رزروی برای مشاهده عکس انتخاب نشده است.", @"", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        RetryGetListOfPhotos:

            var parentPathLocator =
                dgvUploads.SelectedRows[0]?.Cells["clmPhotosFolderLink"].Value?.ToString();

            if (parentPathLocator == null)
            {
                MessageBox.Show(
                    @"برای رزرو انتخابی هنوز عکسی در سیستم قرار داده نشده است.",
                    @"عدم آپلود عکس برای رزرو انتخابی",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var listOfFiles = GetListOfFilesOfOrder(parentPathLocator);
            if (listOfFiles is List<PhotoViewModel> list)
            {
                if (list.Any())
                {
                    using (var frm = new FrmUploadSelectedPhotos())
                    {
                        frm.ListOfPhotos = list;

                        if (int.TryParse(selectedRow?.Cells["clmId"].Value.ToString(), out var orderId))
                            frm.OrderId = orderId;
                        if (int.TryParse(selectedRow.Cells["clmCustomerId"].Value.ToString(), out var customerId))
                            frm.CustomerId = customerId;
                        if (int.TryParse(selectedRow.Cells["clmTotalFiles"].Value.ToString(), out var totalPhotos))
                            frm.TotalPhotos = totalPhotos;

                        frm.OrderCode = selectedRow?.Cells["clmOrderCode"].Value.ToString();
                        frm.CustomerName = selectedRow.Cells["clmCustomerFullName"].Value.ToString();
                        frm.PhotographyDate = selectedRow.Cells["clmDate"].Value.ToString();
                        frm.OrderStatus = selectedRow.Cells["clmStatusName"].Value.ToString();
                        frm.ParentPathLocator = parentPathLocator;
                        frm.ShowDialog();
                    }

                    GC.Collect();
                }
                else
                {
                    var dialogResult = MessageBox.Show(
                        @"برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                        @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                        @"خطا در دریافت لیست عکس های سفارش",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    if (dialogResult == DialogResult.Retry)
                    {
                        goto RetryGetListOfPhotos;
                    }
                }
            }
            else if (listOfFiles is Exception exception)
            {
                ShowException(exception);
            }
            else
            {
                var dialogResult = MessageBox.Show(
                    @"برای این سفارش در سیستم عکسی ثبت نشده است. " + Environment.NewLine +
                    @"لطفا دوباره تلاش کنید و در صورت تکرار مشکل با مدیر سیستم تماس بگیرید.",
                    @"خطا در دریافت لیست عکس های سفارش",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Retry)
                {
                    goto RetryGetListOfPhotos;
                }
            }
        }
    }
}