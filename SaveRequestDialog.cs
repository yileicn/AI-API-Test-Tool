namespace APITestTool
{
    /// <summary>
    /// 保存请求对话框
    /// 用于输入请求名称
    /// </summary>
    public class SaveRequestDialog : Form
    {
        private TextBox txtName = null!;
        private Button btnOk = null!;
        private Button btnCancel = null!;

        public string RequestName => txtName.Text.Trim();

        public SaveRequestDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "保存请求";
            Size = new Size(400, 180);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(30, 30, 46);

            var lblName = new Label
            {
                Text = "请求名称:",
                Location = new Point(20, 25),
                Size = new Size(80, 20),
                ForeColor = Color.FromArgb(205, 214, 244),
                Font = new Font("Cascadia Code", 10F)
            };

            txtName = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(340, 25),
                BackColor = Color.FromArgb(49, 50, 68),
                ForeColor = Color.FromArgb(205, 214, 244),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Cascadia Code", 10F)
            };

            btnOk = new Button
            {
                Text = "保存",
                DialogResult = DialogResult.OK,
                Location = new Point(180, 95),
                Size = new Size(85, 35),
                BackColor = Color.FromArgb(166, 227, 161),
                ForeColor = Color.FromArgb(30, 30, 46),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("请输入请求名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                }
            };

            btnCancel = new Button
            {
                Text = "取消",
                DialogResult = DialogResult.Cancel,
                Location = new Point(275, 95),
                Size = new Size(85, 35),
                BackColor = Color.FromArgb(166, 173, 200),
                ForeColor = Color.FromArgb(30, 30, 46),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            Controls.AddRange(new Control[] { lblName, txtName, btnOk, btnCancel });

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}

