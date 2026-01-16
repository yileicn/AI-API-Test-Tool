using Newtonsoft.Json;

namespace APITestTool
{
    /// <summary>
    /// 文本转JSON字段对话框
    /// 用于将长文本转换为JSON字符串格式，自动处理转义字符
    /// </summary>
    public class TextToJsonDialog : Form
    {
        private TextBox txtFieldName = null!;
        private TextBox txtInputText = null!;
        private TextBox txtPreview = null!;
        private Button btnConvert = null!;
        private Button btnOk = null!;
        private Button btnCancel = null!;

        public string FieldName => txtFieldName.Text.Trim();
        public string ResultJson { get; private set; } = "";

        public TextToJsonDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "📝 文本转JSON字段";
            Size = new Size(800, 650);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(600, 500);
            BackColor = Color.FromArgb(30, 30, 46);

            var lblFieldName = new Label
            {
                Text = "字段名称:",
                Location = new Point(20, 20),
                Size = new Size(100, 20),
                ForeColor = Color.FromArgb(166, 227, 161),
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold)
            };

            txtFieldName = new TextBox
            {
                Location = new Point(20, 45),
                Size = new Size(300, 25),
                BackColor = Color.FromArgb(49, 50, 68),
                ForeColor = Color.FromArgb(205, 214, 244),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Cascadia Code", 10F),
                Text = "Instruction"
            };

            var lblInput = new Label
            {
                Text = "输入文本 (将被转换为JSON字符串):",
                Location = new Point(20, 85),
                Size = new Size(350, 20),
                ForeColor = Color.FromArgb(249, 226, 175),
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold)
            };

            txtInputText = new TextBox
            {
                Location = new Point(20, 110),
                Size = new Size(740, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.FromArgb(49, 50, 68),
                ForeColor = Color.FromArgb(205, 214, 244),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Cascadia Code", 9F),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                WordWrap = false,
                AcceptsReturn = true,
                AcceptsTab = true
            };
            txtInputText.TextChanged += (s, e) => UpdatePreview();

            btnConvert = new Button
            {
                Text = "🔄 转换预览",
                Location = new Point(20, 320),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(137, 180, 250),
                ForeColor = Color.FromArgb(30, 30, 46),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cascadia Code", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.Click += (s, e) => UpdatePreview();

            var lblPreview = new Label
            {
                Text = "转换预览 (转义后的JSON字符串):",
                Location = new Point(20, 360),
                Size = new Size(350, 20),
                ForeColor = Color.FromArgb(203, 166, 247),
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold)
            };

            txtPreview = new TextBox
            {
                Location = new Point(20, 385),
                Size = new Size(740, 150),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.FromArgb(49, 50, 68),
                ForeColor = Color.FromArgb(166, 227, 161),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Cascadia Code", 9F),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                WordWrap = false,
                ReadOnly = true
            };

            btnOk = new Button
            {
                Text = "✅ 插入到Body",
                Location = new Point(540, 555),
                Size = new Size(130, 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(166, 227, 161),
                ForeColor = Color.FromArgb(30, 30, 46),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtFieldName.Text))
                {
                    MessageBox.Show("请输入字段名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                UpdatePreview();
            };

            btnCancel = new Button
            {
                Text = "取消",
                Location = new Point(680, 555),
                Size = new Size(80, 40),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(166, 173, 200),
                ForeColor = Color.FromArgb(30, 30, 46),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Cascadia Code", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            Controls.AddRange(new Control[] { lblFieldName, txtFieldName, lblInput, txtInputText, btnConvert, lblPreview, txtPreview, btnOk, btnCancel });

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        private void UpdatePreview()
        {
            if (string.IsNullOrEmpty(txtInputText.Text))
            {
                txtPreview.Text = "";
                ResultJson = "";
                return;
            }

            // 将文本转换为JSON字符串（自动转义特殊字符）
            ResultJson = JsonConvert.SerializeObject(txtInputText.Text);
            // 移除首尾的引号，因为我们只需要内容
            if (ResultJson.StartsWith("\"") && ResultJson.EndsWith("\""))
            {
                ResultJson = ResultJson[1..^1];
            }

            txtPreview.Text = $"\"{txtFieldName.Text}\": \"{ResultJson}\"";
        }
    }
}

