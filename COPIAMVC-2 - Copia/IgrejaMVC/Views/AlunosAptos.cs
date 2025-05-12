using IgrejaMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgrejaMVC.Views
{
    public partial class AlunosAptos : Form
    {
        public AlunosAptos()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cmbFiltraGraph_SelectedIndexChanged(object sender, EventArgs e)
        {

            string filtro = cmbFiltraAptos.SelectedItem.ToString();

            // Oculta todos primeiro
            gridCultoJovens.Visible = false;
            gridCultoficial.Visible = false;
            gridOficializacao.Visible = false;



            switch (filtro)
            {
                case "Culto de Jovens":
                    gridCultoJovens.Visible = true;
                    break;
                case "Culto Oficial":
                    gridCultoficial.Visible = true;
                    break;
                case "Oficialização":
                    gridOficializacao.Visible = true;
                    break;
            }
        }

        private void AlunosAptos_Load(object sender, EventArgs e)
        {
            gridCultoficial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCultoJovens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOficializacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            gridCultoficial.ReadOnly = true;
            gridCultoJovens.ReadOnly = true;
            gridOficializacao.ReadOnly = true;

            // Define a fonte somente para os grids
            Font gridFont = new Font("Century Gothic", 12);

            gridCultoficial.DefaultCellStyle.Font = gridFont;
            gridCultoJovens.DefaultCellStyle.Font = gridFont;
            gridOficializacao.DefaultCellStyle.Font = gridFont;

            cmbFiltraAptos.Items.Add("Culto de Jovens");
            cmbFiltraAptos.Items.Add("Culto Oficial");
            cmbFiltraAptos.Items.Add("Oficialização");

            CarregarDataGrids();
            cmbFiltraAptos.SelectedIndex = 0; // Mostra o primeiro por padrão
        }

        private void CarregarDataGrids()
        {
            BancoDados banco = new BancoDados();

            // Alunos com 25 hinos ou mais → Culto de Jovens
            gridCultoJovens.DataSource = banco.ObterAlunosPorHinos(25);

            // Alunos com 50 hinos ou mais → Culto Oficial
            gridCultoficial.DataSource = banco.ObterAlunosPorHinos(50);

            // Alunos com 100 hinos ou mais → Oficialização
            gridOficializacao.DataSource = banco.ObterAlunosPorHinos(100);
        }

        private void gridOficializacao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView grid = (DataGridView)sender;

                // Supondo que a coluna "ID" esteja na posição 0 (ajuste se necessário)
                int idAluno = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[0].Value);

                // Abre a tela de hinos do aluno
                Hinos telaHinos = new Hinos(idAluno);
                telaHinos.ShowDialog();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gridCultoJovens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView grid = (DataGridView)sender;

                // Supondo que a coluna "ID" esteja na posição 0 (ajuste se necessário)
                int idAluno = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[0].Value);

                // Abre a tela de hinos do aluno
                Hinos telaHinos = new Hinos(idAluno);
                telaHinos.ShowDialog();
            }
        }

        private void gridCultoficial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView grid = (DataGridView)sender;

                // Supondo que a coluna "ID" esteja na posição 0 (ajuste se necessário)
                int idAluno = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[0].Value);

                // Abre a tela de hinos do aluno
                Hinos telaHinos = new Hinos(idAluno);
                telaHinos.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InformacoesAlunos form1 = new InformacoesAlunos();
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnInstrumento_Click(object sender, EventArgs e)
        {
            CadastrarInstrumentos cadastrarInstrumentos = new CadastrarInstrumentos();
            cadastrarInstrumentos.Show();
            this.Close();
        }

        private void btnProfessores_Click(object sender, EventArgs e)
        {
            InformacoesProfessores informacoesProfessores = new InformacoesProfessores();
            informacoesProfessores.Show();
            this.Close();
        }
    }
}
