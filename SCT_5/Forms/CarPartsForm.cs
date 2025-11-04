using Application.ViewModels;
using Core.Models;
using SCT_5.Factories;

namespace SCT_5.Forms
{
    public partial class CarPartsForm : Form
    {
        private readonly CarPartsViewModel _carPartsViewModel;
        private readonly CarPartFormFactory _carPartFormFactory;


        public CarPartsForm(CarPartsViewModel carPartsViewModel, CarPartFormFactory carPartFormFactory)
        {
            InitializeComponent();

            updateCarPartButton.Enabled = false;
            deleteCarPartButton.Enabled = false;

            _carPartsViewModel = carPartsViewModel;
            _carPartFormFactory = carPartFormFactory;

            _carPartsViewModel.OnError += ShowErrorDialog;
            _carPartsViewModel.OnCarPartsChanged += UpdateCarPartsTable;
            _carPartsViewModel.UpdateButtonsState += UpdateButtonsState;
            _carPartsViewModel.ClearCarPartsTable += ClearCarPartsTable;

            FormClosing += (_, _) =>
            {
                _carPartsViewModel.OnError -= ShowErrorDialog;
                _carPartsViewModel.OnCarPartsChanged -= UpdateCarPartsTable;
                _carPartsViewModel.UpdateButtonsState -= UpdateButtonsState;
                _carPartsViewModel.ClearCarPartsTable -= ClearCarPartsTable;
            };
        }

        private void ShowErrorDialog(string description) => Invoke(() => { MessageBox.Show(description, "Ошибка", MessageBoxButtons.OK); });

        private void UpdateCarPartsTable(List<CarPart> carParts)
        {
            carPartsGrid.Invoke(() =>
            {
                try
                {
                    foreach (CarPart carPart in carParts)
                    {
                        carPartsGrid.Rows.Add(carPart.Id, carPart.Title, carPart.Quantity);
                    }
                }
                catch { }
            });
        }

        private void UpdateButtonsState(bool isActive)
        {
            updateCarPartButton.Invoke(() => { updateCarPartButton.Enabled = isActive; });
            deleteCarPartButton.Invoke(() => { deleteCarPartButton.Enabled = isActive; });
        }

        private void ClearCarPartsTable() => carPartsGrid.Invoke(carPartsGrid.Rows.Clear);

        private void OnDeleteCarPartButtonClick(object sender, EventArgs e)
        {
            if (carPartsGrid.CurrentRow is null) return;

            CarPart? selectedCarPart = _carPartsViewModel.GetSelectedCarPart(carPartsGrid.CurrentRow.Index);
            if (selectedCarPart == null) return;

            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить запчасть '{selectedCarPart.Title}'?",
                "Подтвердите действие",
                MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Yes) _carPartsViewModel.OnDeleteCarPartConfirmed(carPartsGrid.CurrentRow.Index);
        }

        private void OnCreateCarPartButtonClick(object sender, EventArgs e)
        {
            CarPartForm carPartForm = _carPartFormFactory.CreateForm(_carPartsViewModel.OnCarPartFormSaveButtonClicked);
            carPartForm.ShowDialog();
        }

        private void OnEditCarPartButtonClick(object sender, EventArgs e)
        {
            if (carPartsGrid.CurrentRow is null) return;

            CarPart? selectedCarPart = _carPartsViewModel.GetSelectedCarPart(carPartsGrid.CurrentRow.Index);
            if (selectedCarPart == null) return;

            CarPartForm carPartForm = _carPartFormFactory.CreateForm(_carPartsViewModel.OnCarPartFormSaveButtonClicked, selectedCarPart);
            carPartForm.ShowDialog();
        }
    }
}