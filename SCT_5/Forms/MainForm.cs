using SCT_5.Factories;

namespace SCT_5.Forms
{
    public partial class MainForm : Form
    {
        private readonly EmployeesFormFactory _employeesFormFactory;
        private readonly CarPartsFormFactory _carPartsFormFactory;

        public MainForm(EmployeesFormFactory employeesFormFactory, CarPartsFormFactory carPartsFormFactory)
        {
            InitializeComponent();
            _employeesFormFactory = employeesFormFactory;
            _carPartsFormFactory = carPartsFormFactory;
        }

        private void OnShowEmployeesFormButtonClick(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = _employeesFormFactory.CreateForm();
            employeesForm.FormClosed += (_, _) => { employeesButton.Enabled = true; };
            employeesForm.Show();
            employeesButton.Enabled = false;
        }

        private void OnShowCarPartsFormButtonClick(object sender, EventArgs e)
        {
            CarPartsForm carPartsForm = _carPartsFormFactory.CreateForm();
            carPartsForm.FormClosed += (_, _) => { carPartsButton.Enabled = true; };
            carPartsForm.Show();
            carPartsButton.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
