using SCT_5.Factories;

namespace SCT_5.Forms
{
    public partial class MainForm : Form
    {
        private readonly EmployeesFormFactory _employeesFormFactory;

        public MainForm(EmployeesFormFactory employeesFormFactory)
        {
            InitializeComponent();
            _employeesFormFactory = employeesFormFactory;
        }

        private void OnShowEmployeesFormButtonClick(object sender, EventArgs e) => _employeesFormFactory.CreateForm().Show();
    }
}
