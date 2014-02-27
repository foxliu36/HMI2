using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMI.PublicUnit
{
    public partial class UserControl1 : UserControl
    {

        public event EventHandler insertClick;
        public event EventHandler deleteClick;
        public event EventHandler editClick;
        public event EventHandler saveClick;
        public event EventHandler cancelClick;


        public UserControl1()
        {
            InitializeComponent();

            foreach (var item in this.panel1.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    ((Button)item).Click += new EventHandler(Button_Click);
                }
            }
        }
        
        

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    EventHandler ball = this.welkEvent;
        //    ball(this, e);
        //}
        
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                string buName = ((Button)sender).Name;

                EventHandler ball = null;

                switch (buName)
                {
                    case "button1":
                        ball = this.insertClick;
                        //if判斷如果畫面沒有掛載不會出現錯誤
                        if (ball!=null)
                        {
                            ball(sender, e);
                        }
                        break;

                    case "button2":
                        ball = this.deleteClick;
                        if (ball != null)
                        {
                            ball(sender, e);
                        }
                        break;

                    case "button3":
                        ball = this.editClick;
                        if (ball != null)
                        {
                            ball(sender, e);
                        }
                        break;

                    case "button4":
                        ball = this.saveClick;
                        if (ball != null)
                        {
                            ball(sender, e);
                        }
                        break;

                    case "button5":
                        ball = this.cancelClick;
                        if (ball != null)
                        {
                            ball(sender, e);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Button btnInsert {
            get {
                return this.button1;
            }
        }

        public Button btnDelete
        {
            get
            {
                return this.button2;
            }
        }

        public Button btnEdit
        {
            get 
            {
                return this.button3;
            }
        }

        public Button btnSave
        {
            get
            {
                return this.button4;
            }
        }

        public Button btnCancel
        {
            get
            {
                return this.button5;
            }
        }
    }
}
