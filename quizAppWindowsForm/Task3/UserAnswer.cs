using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3.Models;

namespace Task3
{
    public partial class UserAnswer : Form
    {
        private readonly QuizDbContext _db;
        public UserAnswer(QuizDbContext db)
        {
            _db = db;
            InitializeComponent();
            dataGridView1.DataSource = _db.Quizzes.Where(x => x.Questions != null && x.Questions != "")
                .Select(x => new QuestionAnswerModel()
                {
                    Id = x.Id, 
                    Answer = string.Empty,
                    Question = x.Questions
                }).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<(string, string, string)> wrongAnswer = new();
            var totalTrue = 0;
            var aa = dataGridView1.Rows;
            List<Models.UserAnswer> answerUser = new();
            var Questions = GetQuestion();
            var name = textBox3.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Your username empty . Please re-enter ");
            }
            else {

                foreach (DataGridViewRow item in aa)
                {
                    var Id = int.Parse(item.Cells[0].Value.ToString());
                    var question = item.Cells[1].Value.ToString();
                    var answer = item.Cells[2].Value.ToString();
                    answerUser.Add(new Models.UserAnswer()
                    {
                        Name = "ahmet",
                        Answer = answer,
                        QuizId = Id
                    });
                    var answerCheck = CheckQuestionAnswer(Id);
                    if (answerCheck == answer)
                    {
                        totalTrue += 1;
                    }
                    else
                    {
                        wrongAnswer.Add((question, answer, answerCheck));

                    }
                }
                SetQuestionUser(answerUser);
                var percents = totalTrue * 100;
                var totalPercent = percents == 0 ? 0 : percents / Questions.Count();
                var strWrong = new List<WrongMessage>();
                var count = 0;
                foreach (var item in wrongAnswer)
                {
                    count += 1;
                    strWrong.Add(new WrongMessage()
                    {
                        Message = $"{count} :  Wrong Answer => Quenstion {item.Item1} , your Answer :  {item.Item2} , True Answer : {item.Item3} \n"
                    });
                }
                textBox1.Text = $"{name} Total Point {totalPercent}";
                dataGridView2.DataSource = strWrong;
            }
            
        }

        private string CheckQuestionAnswer(int Id)
        {
            var response = _db.Quizzes
                                .Where(x => x.Id == Id)
                                .Select(x => x.Answer).FirstOrDefault();
            return response;
        }


        private void SetQuestionUser(List<Task3.Models.UserAnswer> userAnswers)
        {
            _db.UserAnswers.AddRange(userAnswers);
            _db.SaveChanges();
        }


        private List<Quiz> GetQuestion()
        {
            var response = _db.Quizzes.Where(x => x.Questions != null && x.Questions != "").ToList();
            return response;
        }
    }
}
