using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace IgrejaMVC.Views
{
    public partial class CadastrarProfessor : Form
    {
        // String de conexão com MySQL (coloque aqui em cima mesmo, se preferir)
        public static string connectionString = ConfigurationManager.AppSettings["conexao"];

        public CadastrarProfessor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCadastrarprof_Click(object sender, EventArgs e)
        {
            // Pegando os dados dos campos
            // Pegando os dados dos campos
            string nome = txtCadNomeProfessor.Text;
            string senha = txtCadSenhaProfessor.Text;
            string confirmaSenha = textRepitaSenha.Text; // Campo adicional para confirmação da senha
            string perfil = cmbPerfil.Text;


            // Validação simples
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmaSenha))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            // Validação para verificar se a senha e a confirmação de senha são iguais
            if (senha != confirmaSenha)
            {
                MessageBox.Show("As senhas não coincidem. Tente novamente.");
                return;
            }

            // Comando SQL
            string query = "INSERT INTO Professores (Nome_professor, Senha_professor, perfil_professor) VALUES (@Nome, @Senha,@Perfil)";

            // Executando inserção
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.Parameters.AddWithValue("@Perfil", perfil);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Professor cadastrado com sucesso!");

                            // Abre a tela de login
                            Login loginForm = new Login();
                            loginForm.Show();

                            // Fecha a tela atual
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar professor.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }

        private void CadastrarProfessor_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
