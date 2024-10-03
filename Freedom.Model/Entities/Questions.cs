using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedom.Model.Entities
{
    public class Questions
    {
        public Guid id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string descr { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public bool answer { get; set; } = false;
        public DateTime? answer_date { get; set; }

        /*public Questions(string fullname_, string email_, string subject_, string descr_, DateTime answer_date_, bool answer_ = false)
        {
            this.fullname = fullname_;
            this.email = email_;
            this.subject = subject_;
            this.descr = descr_;
            this.answer = answer_;
            this.answer_date = answer_date_;
        }*/
    }
}
