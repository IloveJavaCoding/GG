using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class GGNews : Form
    {
        protected string username;
        public GGNews(string username)
        {
            InitializeComponent();
            this.username = username;
        }
    }
}
