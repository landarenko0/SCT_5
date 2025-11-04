using Application.ViewModels;
using Core.Models;
using SCT_5.Factories;
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
	public partial class ServicesForm : Form
	{
		private readonly ServicesViewModel _servicesViewModel;

		private readonly ServiceFormFactory _serviceFormFactory;

		public ServicesForm(ServicesViewModel servicesViewModel, ServiceFormFactory serviceFormFactory)
		{
			InitializeComponent();

			updateServiceButton.Enabled = false;
			deleteServiceButton.Enabled = false;

			_servicesViewModel = servicesViewModel;
			_serviceFormFactory = serviceFormFactory;

			_servicesViewModel.OnError += ShowErrorDialog;
			_servicesViewModel.OnServicesChanged += UpdateServicesTable;
			_servicesViewModel.UpdateButtonsState += UpdateButtonsState;
			_servicesViewModel.ClearServicesTable += ClearServicesTable;

			FormClosing += (_, _) =>
			{
				_servicesViewModel.OnError -= ShowErrorDialog;
				_servicesViewModel.OnServicesChanged -= UpdateServicesTable;
				_servicesViewModel.UpdateButtonsState -= UpdateButtonsState;
				_servicesViewModel.ClearServicesTable -= ClearServicesTable;
			};
		}

		private void ShowErrorDialog(string description) => Invoke(() => { MessageBox.Show(description, "Ошибка", MessageBoxButtons.OK); });

		private void UpdateServicesTable(List<Service> services)
		{
			servicesGrid.Invoke(() =>
			{
				try
				{
					foreach (Service service in services)
					{
						servicesGrid.Rows.Add(service.Id, service.Title, service.Price);
					}
				}
				catch { }
			});
		}

		private void UpdateButtonsState(bool isActive)
		{
			updateServiceButton.Invoke(() => { updateServiceButton.Enabled = isActive; });
			deleteServiceButton.Invoke(() => { deleteServiceButton.Enabled = isActive; });
		}

		private void ClearServicesTable() => servicesGrid.Invoke(servicesGrid.Rows.Clear);

		private void OnDeleteServiceButtonClick(object sender, EventArgs e)
		{
			if (servicesGrid.CurrentRow is null) return;

			Service? selectedService = _servicesViewModel.GetSelectedService(servicesGrid.CurrentRow.Index);
			if (selectedService == null) return;

			DialogResult result = MessageBox.Show(
				$"Вы действительно хотите удалить услугу \"{selectedService.Title}\"?",
				"Подтвердите действие",
				MessageBoxButtons.YesNoCancel
			);

			if (result == DialogResult.Yes) _servicesViewModel.OnDeleteServiceConfirmed(servicesGrid.CurrentRow.Index);
		}

		private void OnCreateServiceButtonClick(object sender, EventArgs e)
		{
			ServiceForm serviceForm = _serviceFormFactory.CreateForm(_servicesViewModel.OnServiceFormSaveButtonClicked);
			serviceForm.ShowDialog();
		}

		private void OnEditServiceButtonClick(object sender, EventArgs e)
		{
			if (servicesGrid.CurrentRow is null) return;

			Service? selectedService = _servicesViewModel.GetSelectedService(servicesGrid.CurrentRow.Index);
			if (selectedService == null) return;

			ServiceForm serviceForm = _serviceFormFactory.CreateForm(_servicesViewModel.OnServiceFormSaveButtonClicked, selectedService);
			serviceForm.ShowDialog();
		}
	}
}

