using IgrejaMVC.Models;
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
    public partial class InformacoesAlunos : Form
    {

        public InformacoesAlunos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            txtCPF.ReadOnly = true;
            txtCPF.TabStop = false;
            txtCPF.Cursor = Cursors.No;
        }
        DataGridView gridAluno = new DataGridView();
        private string caminhoFoto;
        private void InformacoesAlunos_Load(object sender, EventArgs e)
        {
            // Pegando o CPF do aluno (verifique de onde ele vem)
            string cpfAluno = txtCPF.Text;

            // Preenchendo o ComboBox com todos os instrumentos e garantindo que o escolhido pelo aluno apareça
            DataTable dt = BancoDados.PesquisarInstrumentoComEscolhido(cpfAluno);
            txtInstrumento.DataSource = dt;
            txtInstrumento.DisplayMember = "nome_instrumento";
            txtInstrumento.ValueMember = "id";

            // Definir o instrumento do aluno como selecionado
            int instrumentoSelecionado = BancoDados.ObterInstrumentoDoAluno(cpfAluno);
            if (instrumentoSelecionado != -1)
            {
                txtInstrumento.SelectedValue = instrumentoSelecionado;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtNome.Text;
            aluno.CPF = txtCPF.Text;
            aluno.DtNascimento = DateTime.Parse(txtDtNascimento.Text);
            aluno.Instrumento = int.Parse(txtInstrumento.SelectedValue.ToString());
            aluno.Telefone = txtTelefone.Text;
            aluno.Email = txtEmail.Text;
            aluno.CEP = txtCEP.Text;
            aluno.Endereco = txtEndereco.Text;
            aluno.Numero = txtNumero.Text;
            aluno.Bairro = txtBairro.Text;
            aluno.Cidade = txtCidade.Text;
            aluno.Estado = txtEstado.Text;
            aluno.EstadoCivil = txtEstadoCivil.Text;
            aluno.FotoPerfil = pictureBox1.Image != null ? ImageToByteArray(pictureBox1.Image) : new byte[0];

            bool success = BancoDados.AtualizarAluno(aluno);
            if (success)
            {
                MessageBox.Show("Aluno atualizado com sucesso.");

                // Criar a instância da tela Home antes de fechar a atual
                Home formHome = new Home();

                // Esconder a tela atual antes de abrir a nova
                this.Hide();
                formHome.ShowDialog();

                // Fechar a tela atual após a Home ser fechada
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao atualizar o aluno.");
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }





        private void txtDtCadastro_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filtrar para exibir apenas arquivos de imagem
                openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";

                // Abrir a janela para selecionar um arquivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obter o caminho do arquivo escolhido
                    string caminhoArquivo = openFileDialog.FileName;

                    // Exibir a imagem no PictureBox
                    pictureBox1.Image = Image.FromFile(caminhoArquivo);

                    // (Opcional) Armazene o caminho para uso futuro, se necessário
                    caminhoFoto = caminhoArquivo;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            txtCEP.MaxLength = 8; // Define o limite máximo de 14 caracteres

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            txtCPF.MaxLength = 11; // Define o limite máximo de 14 caracteres

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.MaxLength = 11;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.ShowDialog();
        }

        private void btnInstrumento_Click(object sender, EventArgs e)
        {
            CadastrarInstrumentos form = new CadastrarInstrumentos();
            form.ShowDialog();
        }

        private void txtInstrumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public string Professor { get; set; }
        public string Perfil { get; set; }
        private void btnProfessores_Click(object sender, EventArgs e)
        {
            InformacoesProfessores form = new InformacoesProfessores();
            form.Professor = this.Professor;
            form.Perfil = this.Perfil;
            form.ShowDialog();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
