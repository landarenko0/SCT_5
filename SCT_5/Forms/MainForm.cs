using SCT_5.Factories;

namespace SCT_5.Forms
{
    public partial class MainForm : Form
    {
        private readonly EmployeesFormFactory _employeesFormFactory;
        private readonly CarPartsFormFactory _carPartsFormFactory;
        private readonly ServicesFormFactory _servicesFormFactory;

        public MainForm(EmployeesFormFactory employeesFormFactory, ServicesFormFactory servicesFormFactory, CarPartsFormFactory carPartsFormFactory)
        {
            InitializeComponent();
            _employeesFormFactory = employeesFormFactory;
            _servicesFormFactory = servicesFormFactory;
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
        
        private void OnShowServicesFormButtonClick(object sender, EventArgs e)
		{
			ServicesForm servicesForm = _servicesFormFactory.CreateForm();
			servicesForm.FormClosed += (_, _) => { servicesButton.Enabled = true; };
			servicesForm.Show();
			servicesButton.Enabled = false;
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

		
	
}
