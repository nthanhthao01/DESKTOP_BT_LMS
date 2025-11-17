using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT1
{
    public partial class FrmMayTinhBoTui : Form
    {
        public FrmMayTinhBoTui()
        {
            InitializeComponent();
        }

        private void label1_Click (object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSoThuNhat_Click(object sender, EventArgs e)
        {

        }

        private void txtSoThuNhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoThuNhat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtSoThuHai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoThuHai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoThuNhat.Text) || string.IsNullOrWhiteSpace(txtSoThuHai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ hai số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double num1 = Convert.ToDouble(txtSoThuNhat.Text);
            double num2 = Convert.ToDouble(txtSoThuHai.Text);
            double result = num1 + num2;

            txtKetQua.Text = Convert.ToString(result);
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoThuNhat.Text) || string.IsNullOrWhiteSpace(txtSoThuHai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ hai số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double num1 = Convert.ToDouble(txtSoThuNhat.Text);
            double num2 = Convert.ToDouble(txtSoThuHai.Text);
            double result = num1 - num2;

            txtKetQua.Text = Convert.ToString(result);
        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoThuNhat.Text) || string.IsNullOrWhiteSpace(txtSoThuHai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ hai số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double num1 = Convert.ToDouble(txtSoThuNhat.Text);
            double num2 = Convert.ToDouble(txtSoThuHai.Text);
            double result = num1 * num2;

            txtKetQua.Text = Convert.ToString(result);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoThuNhat.Text) || string.IsNullOrWhiteSpace(txtSoThuHai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ hai số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double num1 = Convert.ToDouble(txtSoThuNhat.Text);
            double num2 = Convert.ToDouble(txtSoThuHai.Text);

            if (num2 == 0)
            {
                MessageBox.Show("Không thể chia cho 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double result = num1 / num2;

            txtKetQua.Text = Convert.ToString(result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtKetQua.Clear();
            txtSoThuNhat.Clear();
            txtSoThuHai.Clear();
        }
    }
}
