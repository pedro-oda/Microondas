using MicroondasDataProvider;
using MicroondasDataProvider.Helpers;
using MicroondasDataProvider.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Microondas
{
    public partial class MicroWave : Form
    {
        ProgramService _service = new ProgramService();
        bool isWorking = false;
        int time = 0;
        string potencyStr = "";
        string globalFile = "";
        ProgramModel globalModel = new ProgramModel();

        public MicroWave()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void timer1_CustomTick(object sender, EventArgs e)
        {
            var elapsedTime = globalModel.Time;

            if (time == globalModel.Time)
            {
                timer1.Dispose();
                timer1.Stop();
                timer1.Tick -= timer1_CustomTick;
                timer1.Enabled = false;
                time = 0;
                txtTime.Text = "00:00";
                isWorking = false;
                _service.showHeatedMessage(txtProgram.Text);
                return;
            }
            txtTime.Text = ConvertSecondsToMask(elapsedTime.Value - time);
            txtProgram.Text += potencyStr;
            if (!globalFile.IsNull())
            {
                File.AppendAllText(globalFile, potencyStr);
            }
            time++;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new ProgramModel();
                var file = "";
                if (!txtProgram.Text.IsNull())
                {
                    var search = "";
                    if (File.Exists(txtProgram.Text))
                    {
                        search = File.ReadAllLines(txtProgram.Text).FirstOrDefault();
                        file = txtProgram.Text;
                    }
                    else search = txtProgram.Text;
                    model = _service.GetProgramModels(search).FirstOrDefault();
                }
                else if (!txtTime.Text.Replace(':', ' ').IsNull())
                {
                    model.Name = "";
                    model.Time = ConvertMaskToSeconds(txtTime.Text);
                    model.Potency = txtPotency.Text.ParseIntOrDefault(10);
                    model.HeatChar = ".";
                }
                else
                {
                    model.Name = "";
                    model.Time = 30;
                    model.Potency = 8;
                    model.HeatChar = ".";
                }

                var message = IsValid(model);

                if (message.IsNull())
                {
                    if (!isWorking)
                    {
                        isWorking = true;
                        clear();
                        Heat(model, file);
                    }
                }

                else _service.showErrorMessage(message);
            }
            catch (Exception)
            {
                _service.showErrorMessage("Não foi possivel aquecer o seu alimento");
            }

        }

        private void btnNewProgram_Click(object sender, EventArgs e)
        {
            var form = new NewProgram();
            form.ShowDialog();
            if (!form.IsDisposed)
                FillDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProgram.Text.IsNull())
            {
                _service.showErrorMessage("Por favor informe o nome do programa de aquecimento");
                return;
            }
            FillDataGrid(txtProgram.Text);
        }

        #region CustomMethods

        protected void FillDataGrid(string searchContent = "")
        {
            List<ProgramModel> listProgramModels = new List<ProgramModel>();

            if (searchContent.IsNull())
                listProgramModels = _service.GetProgramModels();
            else
                listProgramModels = _service.GetProgramModels(searchContent);

            DataTable table = new DataTable();

            table.Columns.Add("Programa");
            table.Columns.Add("Tempo(Segundos)");
            table.Columns.Add("Potência");
            table.Columns.Add("Instruções");
            table.Columns.Add("Aquecimento");

            foreach (var program in listProgramModels)
            {
                table.Rows.Add(program.Name, program.Time, program.Potency, program.Instructions, program.HeatChar);
            }

            if (table.Rows.Count > 0)
            {
                dgvPrograms.DataSource = table;
                dgvPrograms.Refresh();
            }
        }


        protected void Heat(ProgramModel model, string file = "")
        {
            potencyStr = PotencyString(model.Potency.Value, model.HeatChar);
            globalFile = file;
            globalModel = model;
            timer1.Tick += timer1_CustomTick;

            timer1.Start();


        }

        protected int? ConvertMaskToSeconds(string source)
        {
            var seconds = default(int?);
            var splitedSource = source.Split(':');
            if (splitedSource.Length > 1)
            {
                if (!splitedSource[0].IsNull() && !splitedSource[1].IsNull())
                {
                    seconds = (int.Parse(splitedSource[0]) * 60) + int.Parse(splitedSource[1]);
                }
                else if(splitedSource[0].IsNull() && !splitedSource[1].IsNull())
                {
                    seconds = int.Parse(splitedSource[1]);
                }
                else
                {
                    seconds = (int.Parse(splitedSource[0]) * 60);

                }
            }
            return seconds;
        }

        protected string ConvertSecondsToMask(int seconds)
        {
            var mask = "";
            mask = seconds > 59 ? $"0{(seconds / 60 == 0 ? 1 : seconds / 60).ToString()}:{(seconds % 60 < 10 ? "0" + (seconds % 60).ToString() : (seconds % 60).ToString())}"
                : $"00:{(seconds % 60 < 10 ? "0" + (seconds % 60).ToString() : (seconds % 60).ToString())}";

            return mask;
        }

        protected string IsValid(ProgramModel model)
        {
            var listProgramModels = new List<ProgramModel>();

            listProgramModels = _service.GetProgramModels();

            if (model.Name.IsNull() && !model.Potency.HasPositiveValue() || model.Potency < 1 || model.Potency > 10)
                return "Por favor informe uma potência entre 1 e 10";
            else if (model.Name.IsNull() && model.Time < 1 || model.Time > 120)
                return "Por favor informe um intervalo de tempo entre 1 segundo e 2 minutos";
            else if (!model.Potency.HasPositiveValue() && !model.Time.HasPositiveValue() && !listProgramModels.Select(p => p.Name.ToLower()).Contains(model.Name.ToLower()))
                return "Programa de aquecimento não encontrado";

            return "";
        }

        //Criar string de concatenação de texto
        protected string PotencyString(int potency, string heatChar)
        {
            var potencyString = "";

            for (int i = 0; i < potency; i++)
            {
                potencyString += heatChar;
            }

            return potencyString;
        }

        #endregion

        private void btnStartProgram_Click(object sender, EventArgs e)
        {
            if (!(dgvPrograms.SelectedRows.Count > 0))
            {
                _service.showErrorMessage("Por favor selecionar um programa de aquecimento");
                return;
            }
            var model = new ProgramModel();
            model.Name = dgvPrograms.SelectedRows[0].Cells[0].Value.ToString();
            model.Time = dgvPrograms.SelectedRows[0].Cells[1].Value.ToString().ParseIntOrDefault();
            model.Potency = dgvPrograms.SelectedRows[0].Cells[2].Value.ToString().ParseIntOrDefault();
            model.Instructions = dgvPrograms.SelectedRows[0].Cells[3].Value.ToString();
            model.HeatChar = dgvPrograms.SelectedRows[0].Cells[4].Value.ToString();
            if (!isWorking)
            {
                isWorking = true;
                clear();
                timer1.Enabled = true;
                Heat(model);
            }
        }

        //Fazer com que o click no datagrid selecione a linha inteira
        private void dgvPrograms_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            if (selectedIndex >= 0)
            {
                dgvPrograms.ClearSelection();
                dgvPrograms.Rows[selectedIndex].Selected = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Start();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            timer1.Stop();
            timer1.Tick -= timer1_CustomTick;
            timer1.Enabled = false;
            time = 0;
            isWorking = false;
            clear();
        }

        private void clear()
        {
            txtProgram.Text = "";
            txtPotency.Text = "";
            txtTime.Text = "";
        }

    }
}
