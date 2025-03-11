/*
 * Вариант 8.
Написать программу, которая выполняет шифрование и дешифрование текстового файла
любого размера, содержащего текст на заданном языке, используя следующие алгоритмы шифрования:
- Метод децимаций текст на русском языке;
- алгоритм Виженера, самогенерирующийся ключ, текст на русском языке. 
Для всех алгоритмов ключ задается с клавиатуры пользователем.
Программа должна игнорировать все символы, не являющиеся буквами заданного алфавита, 
и шифровать только текст на заданном языке. Все алгоритмы должны быть реализованы в одной программе. Программа не должна быть написана в консольном режиме. Результат работы программы – зашифрованный/расшифрованный файл/ы.

 */
namespace Lab_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            crypt1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            Key1 = new TextBox();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            decript1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            key2 = new TextBox();
            crypt2 = new Button();
            decrypt2 = new Button();
            save = new Button();
            inputB = new Button();
            SuspendLayout();
            // 
            // crypt1
            // 
            crypt1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            crypt1.Location = new Point(-1, 299);
            crypt1.Margin = new Padding(3, 2, 3, 2);
            crypt1.Name = "crypt1";
            crypt1.Size = new Size(192, 28);
            crypt1.TabIndex = 0;
            crypt1.Text = "Зашифровать";
            crypt1.UseVisualStyleBackColor = true;
            crypt1.Click += crypt1_Click;
            // 
            // Key1
            // 
            Key1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Key1.Location = new Point(-1, 266);
            Key1.Margin = new Padding(3, 2, 3, 2);
            Key1.Name = "Key1";
            Key1.Size = new Size(192, 29);
            Key1.TabIndex = 2;
            Key1.TextChanged += Key1_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(8, 38);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(363, 84);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox2.Location = new Point(10, 148);
            richTextBox2.Margin = new Padding(3, 2, 3, 2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(361, 84);
            richTextBox2.TabIndex = 4;
            richTextBox2.Text = "";
            // 
            // decript1
            // 
            decript1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            decript1.Location = new Point(-1, 331);
            decript1.Margin = new Padding(3, 2, 3, 2);
            decript1.Name = "decript1";
            decript1.Size = new Size(192, 28);
            decript1.TabIndex = 5;
            decript1.Text = "Расшифровать";
            decript1.UseVisualStyleBackColor = true;
            decript1.Click += decript1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 243);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 6;
            label1.Text = "Децимации";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 8);
            label2.Name = "label2";
            label2.Size = new Size(142, 21);
            label2.TabIndex = 7;
            label2.Text = "Шифруемый текст";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 124);
            label3.Name = "label3";
            label3.Size = new Size(173, 21);
            label3.TabIndex = 8;
            label3.Text = "Зашифрованный текст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(263, 243);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 9;
            label4.Text = "Вижинер";
            // 
            // key2
            // 
            key2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            key2.Location = new Point(209, 266);
            key2.Margin = new Padding(3, 2, 3, 2);
            key2.Name = "key2";
            key2.Size = new Size(162, 29);
            key2.TabIndex = 10;
            // 
            // crypt2
            // 
            crypt2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            crypt2.Location = new Point(209, 299);
            crypt2.Margin = new Padding(3, 2, 3, 2);
            crypt2.Name = "crypt2";
            crypt2.Size = new Size(162, 28);
            crypt2.TabIndex = 11;
            crypt2.Text = "Зашифровать";
            crypt2.UseVisualStyleBackColor = true;
            crypt2.Click += crypt2_Click;
            // 
            // decrypt2
            // 
            decrypt2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            decrypt2.Location = new Point(209, 331);
            decrypt2.Margin = new Padding(3, 2, 3, 2);
            decrypt2.Name = "decrypt2";
            decrypt2.Size = new Size(162, 28);
            decrypt2.TabIndex = 12;
            decrypt2.Text = "Расшифровать";
            decrypt2.UseVisualStyleBackColor = true;
            decrypt2.Click += decrypt2_Click;
            // 
            // save
            // 
            save.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            save.Location = new Point(102, 421);
            save.Margin = new Padding(3, 2, 3, 2);
            save.Name = "save";
            save.Size = new Size(211, 28);
            save.TabIndex = 13;
            save.Text = "Сохранить в файл";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // inputB
            // 
            inputB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            inputB.Location = new Point(102, 378);
            inputB.Margin = new Padding(3, 2, 3, 2);
            inputB.Name = "inputB";
            inputB.Size = new Size(211, 28);
            inputB.TabIndex = 14;
            inputB.Text = "Загрузить из файла";
            inputB.UseVisualStyleBackColor = true;
            inputB.Click += inputB_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(395, 519);
            Controls.Add(inputB);
            Controls.Add(save);
            Controls.Add(decrypt2);
            Controls.Add(crypt2);
            Controls.Add(key2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(decript1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(Key1);
            Controls.Add(crypt1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button crypt1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox Key1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button decript1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox key2;
        private Button crypt2;
        private Button decrypt2;
        private Button save;
        private Button inputB;
    }
}