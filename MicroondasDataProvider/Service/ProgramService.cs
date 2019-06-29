using MicroondasDataProvider.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;
using System;
using System.Windows.Forms;

namespace MicroondasDataProvider.Service
{
    public class ProgramService
    {
        public List<ProgramModel> GetProgramModels(string SearchContent = "")
        {
            List<ProgramModel> listProgramModels = new List<ProgramModel>();

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var programodel = new ProgramModel();
            var file = @"C:\Users\Pedro\source\repos\Microondas\programs.txt";
            if (File.Exists(file))
            {
                var listPrograms = File.ReadAllLines(file);

                foreach (string program in listPrograms)
                {
                    programodel = serializer.Deserialize<ProgramModel>(program);
                    listProgramModels.Add(programodel);
                }

                if (!SearchContent.IsNull())
                {
                    var program = listProgramModels.Where(p => p.Name.ToLower().Contains(SearchContent.ToLower())).FirstOrDefault();
                    listProgramModels.Clear();
                    if (program != null)
                    {
                        listProgramModels.Add(program);
                    }
                }

            }
            return listProgramModels;
        }

        public void CreateProgram(ProgramModel model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var file = @"C:\Users\Pedro\source\repos\Microondas\programs.txt";
            if (File.Exists(file))
            {
                var line = serializer.Serialize(model);
                File.AppendAllText(file, line + Environment.NewLine);
            }
        }

        public void showHeatedMessage(string message)
        {
            MessageBox.Show(message, "Aquecido", MessageBoxButtons.OK);
        }

        public void showErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
