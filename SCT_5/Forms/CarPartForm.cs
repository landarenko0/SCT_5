using Application.ViewModels;
using Core.Models;

namespace SCT_5.Forms
{
    public partial class CarPartForm : Form
    {
        private readonly CarPartViewModel _carPartViewModel;
        private event Action OnSaveButtonClick;

        public CarPartForm(CarPartViewModel carPartViewModel, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Добавление запчасти";

            _carPartViewModel = carPartViewModel;
            OnSaveButtonClick += onSaveButtonClick;

            RegisterEvents();
            FormClosing += (_, _) => UnregisterEvents();
        }

        public CarPartForm(CarPartViewModel carPartViewModel, CarPart carPart, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Редактирование запчасти";

            titleTextBox.Text = carPart.Title;
            quantityTextBox.Text = carPart.Quantity.ToString();

            _carPartViewModel = carPartViewModel;
            _carPartViewModel.CarPart = carPart;
            OnSaveButtonClick += onSaveButtonClick;

            RegisterEvents();
            FormClosing += (_, _) => UnregisterEvents();
        }

        private void RegisterEvents()
        {
            _carPartViewModel.OnError += ShowErrorDialog;
            _carPartViewModel.OnCloseForm += CloseForm;
            _carPartViewModel.UpdateButtonState += UpdateButtonState;
        }

        private void UnregisterEvents()
        {
            _carPartViewModel.OnError -= ShowErrorDialog;
            _carPartViewModel.OnCloseForm -= CloseForm;
            _carPartViewModel.UpdateButtonState -= UpdateButtonState;
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

        private void OnSaveCarPartButtonClick(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string quantity = quantityTextBox.Text;

            _carPartViewModel.OnSaveButtonClick(title, quantity);
        }

        private void OnQuantityConstraintGoodButtonClick(object sender, EventArgs e)
        {
            titleTextBox.Text = CarPartViewModel.RandomTitle;
            quantityTextBox.Text = CarPartViewModel.RandomQuantity.ToString();
        }

        private void OnQuantityConstraintBadButtonClick(object sender, EventArgs e)
        {
            titleTextBox.Text = CarPartViewModel.RandomTitle;
            quantityTextBox.Text = "-10";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}