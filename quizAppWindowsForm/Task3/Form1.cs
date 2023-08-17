using Arch.EntityFrameworkCore;
using System.Collections.Immutable;
using Task3.Models;

namespace Task3
{
    public partial class Form1 : Form
    {

        private readonly QuizDbContext _db = new QuizDbContext();
        public Form1()
        {
                InitializeComponent();

        }

        private async void Form1_Load(object sender,DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = GetFullQuiz();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var Quiz = new Quiz()
            {
                Answer = textAnswer.Text,
                Questions = textQuestion.Text
            };
            _db.Quizzes.Add(Quiz);
            await _db.SaveChangesAsync();
            dataGridView1.DataSource = GetFullQuiz();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetFullQuiz();
        }




        private List<Quiz> GetFullQuiz()
        {
            return _db.Quizzes.Where(x=>x.Questions != null && x.Questions != "").ToList();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Quiz updateData = _dbs.Quizzes.Where(x => x.Id == id).FirstOrDefault();
            if (updateData != null)
            {
                updateData.Answer = textAnswer.Text;
                updateData.Questions = textQuestion.Text;
                _dbs.Update(updateData);
                _dbs.SaveChanges();
            }
            else
            {
                dataGridView1.UpdateRowErrorText(id);
            }
            dataGridView1.DataSource = GetFullQuiz();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Quiz updateData = _dbs.Quizzes.Where(x => x.Id == id).FirstOrDefault();
            if (updateData != null)
            {
                updateData.Answer = textAnswer.Text;
                updateData.Questions = textQuestion.Text;
                _dbs.Remove(updateData);
                _dbs.SaveChanges();
                dataGridView1.DataSource = GetFullQuiz();
            }
            else
            {
                dataGridView1.UpdateRowErrorText(id);
            }
        }

    }
}