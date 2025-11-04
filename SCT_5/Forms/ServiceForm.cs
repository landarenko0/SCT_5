using Application.ViewModels;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCT_5.Forms
{
	public partial class ServiceForm : Form
	{
		private readonly ServiceViewModel _serviceViewModel;

		private event Action OnSaveButtonClick;

		public ServiceForm(ServiceViewModel serviceViewModel, Action onSaveButtonClick)
		{
			InitializeComponent();

			Text = "Создание услуги";

			_serviceViewModel = serviceViewModel;
			OnSaveButtonClick += onSaveButtonClick;

			RegisterEvents();
			FormClosing += (_, _) => UnregisterEvents();
		}

		public ServiceForm(ServiceViewModel serviceViewModel, Service service, Action onSaveButtonClick)
		{
			InitializeComponent();

			Text = "Редактирование услуги";

			titleTextBox.Text = service.Title;
			priceTextBox.Text = service.Price.ToString();

			_serviceViewModel = serviceViewModel;
			_serviceViewModel.Service = service;
			OnSaveButtonClick += onSaveButtonClick;

			RegisterEvents();
			FormClosing += (_, _) => UnregisterEvents();
		}

		private void RegisterEvents()
		{
			_serviceViewModel.OnError += ShowErrorDialog;
			_serviceViewModel.OnCloseForm += CloseForm;
			_serviceViewModel.UpdateButtonState += UpdateButtonState;
		}

		private void UnregisterEvents()
		{
			_serviceViewModel.OnError -= ShowErrorDialog;
			_serviceViewModel.OnCloseForm -= CloseForm;
			_serviceViewModel.UpdateButtonState -= UpdateButtonState;
		}

		private void ShowErrorDialog(string description) => Invoke(() => { MessageBox.Show(description, "Ошибка", MessageBoxButtons.OK); });

		private void CloseForm()
		{
			Invoke(() =>
			{
				OnSaveButtonClick();
				Close();
			});
		}

		private void UpdateButtonState(bool isActive) => saveButton.Invoke(() => { saveButton.Enabled = isActive; });

		private void OnSaveServiceButtonClick(object sender, EventArgs e)
		{
			string title = titleTextBox.Text;
			string price = priceTextBox.Text;

			_serviceViewModel.OnSaveButtonClick(title, price);
		}

		private void OnPriceConstraintGoodButtonClick(object sender, EventArgs e)
		{
			titleTextBox.Text = ServiceViewModel.RandomTitle;
			priceTextBox.Text = ServiceViewModel.RandomPrice.ToString();
		}

		private void OnPriceConstraintBadButtonClick(object sender, EventArgs e)
		{
			titleTextBox.Text = ServiceViewModel.RandomTitle;
			priceTextBox.Text = "-100";
		}
	}
}

