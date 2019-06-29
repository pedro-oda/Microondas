using MicroondasDataProvider;
using MicroondasDataProvider.Helpers;
using MicroondasDataProvider.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microondas
{
    public partial class NewProgram : Form
    {
        ProgramService _service = new ProgramService();
        public NewProgram()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var model = new ProgramModel();
            var message = IsValid();
            if (!message.IsNull())
            {
                _service.showErrorMessage(message);
                return;
            }

            model.Name = txtName.Text;
            model.Time = int.Parse(txtTime.Text);
            model.Potency = int.Parse(txtPotency.Text);
            model.HeatChar = txtHeatChar.Text;
            model.Instructions = txtInstructions.Text;
            _service.CreateProgram(model);

            this.Close();
        }

        protected string IsValid()
        {
            var listProgramModels = new List<ProgramModel>();

            listProgramModels = _service.GetProgramModels();

            if (txtName.Text.IsNull())
                return "Por favor informe o campo nome";
            else if (txtPotency.Text.IsNull())
                return "Por favor informe o campo potência";
            else if (txtTime.Text.IsNull())
                return "Por favor informe o campo tempo";
            else if (txtHeatChar.Text.IsNull())
                return "Por favor informe o campo caracter de aquecimento";
            else if (txtInstructions.Text.IsNull())
                return "Por favor informe o campo instruções";
            else if (txtTime.Text.ParseIntOrDefault() < 1 || txtTime.Text.ParseIntOrDefault() > 120)
                return "Por favor informe um intervalo de tempo entre 1 e 120 segundos";
            else if (txtPotency.Text.ParseIntOrDefault() < 1 || txtPotency.Text.ParseIntOrDefault() > 10)
                return "Por favor informe uma potência entre 1 e 10";

            return "";
        }

    }
}
