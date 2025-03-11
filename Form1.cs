using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        string path = "InD.txt"; // ���� � ����� ��� ������
        string pathOut = "Out.txt"; // ���� � ����� ��� ������
        string pathV = "InV.txt"; // ���� � ����� ��� ����� (���� �����)
        string Crypt, DeCrypt;
        string InText = null; // ����� �� ����� ��� ���� �����
        string OutText = null;
        static char[] alphabet = "�����Ũ��������������������������".ToCharArray();
        static int alphabetSize = alphabet.Length;

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("1");
            for (int i = 0; i < alphabetSize; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(" ");
                Console.WriteLine(alphabet[i] + "\n");
            }
        }

        static int GCD(int a, int b) // ����� ��� ���������� ���
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // ����� ��� ���������� ��������� �������� �� ������ ������� ��������
        static int ModInverse(int a, int m)
        {
            if (GCD(a, m) != 1)
                MessageBox.Show("Error!!!");

            a = a % m;
            int x;
            for (x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }
            return x;
        }

        string CaesarCipher(string text, int shift)
        {
            StringBuilder Enctext = new StringBuilder();
            text = text.ToUpper();
            foreach (char c in text)
            {
                int index = Array.IndexOf(alphabet, c);
                if (index != -1) // ���� ������ � ��������
                {
                    int newInd = (index * shift) % alphabet.Length;
                    Enctext.Append(alphabet[newInd]);
                }
                else
                {
                    Enctext.Append(c); // ���� ������ �� � ��������, ��������� ��� ��� ���������
                }
            }
            return Enctext.ToString();
        }

        // ����� ����������� ������� ���������
        public static string Decrypt(string text, int key)
        {
            StringBuilder decryptedText = new StringBuilder();
            text = text.ToUpper();
            int inverseKey = ModInverse(key, alphabetSize); // ������� �������� ����

            foreach (char c in text)
            {
                int index = Array.IndexOf(alphabet, c);
                if (index != -1) // ���� ������ � ��������
                {
                    int newIndex = (index * inverseKey) % alphabetSize; // ��������� ������������
                    decryptedText.Append(alphabet[newIndex]);
                }
                else
                {
                    decryptedText.Append(c); // ���� ������ �� � ��������, ��������� ��� ��� ���������
                }
            }
            return decryptedText.ToString();
        }

        private void inputB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*",
                Title = "�������� ����"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName; // ���������� ���� � ���������� �����
                InText = File.ReadAllText(path); // ������ �����
                richTextBox1.Text = InText; // ����������� ������ � richTextBox1
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*",
                Title = "�������� ����"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathOut = openFileDialog.FileName; // ���������� ���� � ���������� �����
                File.WriteAllText(pathOut, richTextBox2.Text); // ������ ������ � ����
            }
        }

        private void crypt1_Click(object sender, EventArgs e)
        {
            // ���������� ����� �� richTextBox1, ���� �� ����, ����� �� �����
            InText = richTextBox1.Text ?? File.ReadAllText(path);

            int key;
            string tmp = Key1.Text;
            if (int.TryParse(tmp, out key))
            {
                if (GCD(key, alphabetSize) == 1)
                {
                    Crypt = CaesarCipher(InText, key);
                    richTextBox2.Text = Crypt;
                }
                else
                {
                    MessageBox.Show("Error!!!");
                }
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void decript1_Click(object sender, EventArgs e)
        {
            // ���������� ����� �� richTextBox1, ���� �� ����, ����� �� �����
            InText = richTextBox1.Text ?? File.ReadAllText(path);

            int key;
            string tmp = Key1.Text;
            if (int.TryParse(tmp, out key))
            {
                if (GCD(key, alphabetSize) == 1)
                {
                    // ���� Crypt �� ��� ���������������, ���������� ����� �� richTextBox1
                    string textToDecrypt = Crypt ?? InText;
                    DeCrypt = Decrypt(textToDecrypt, key);
                    richTextBox2.Text = DeCrypt;
                }
                else
                {
                    MessageBox.Show("Error!!!");
                }
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void crypt2_Click(object sender, EventArgs e)
        {
            string InputKey = key2.Text;
            bool Flag = true;
            StringBuilder inputT = new StringBuilder();
            if (Flag)
            {
                // ���������� ����� �� richTextBox1, ���� �� ����, ����� �� �����
                InText = richTextBox1.Text ?? File.ReadAllText(pathV);

                foreach (char c in InText)
                {
                    if (Array.IndexOf(alphabet, char.ToUpper(c)) != -1)
                    {
                        inputT.Append(c);
                    }
                }

                InText = inputT.ToString();
                string cript = "";
                VigenereCipher V = new VigenereCipher();
                string generateKey = V.GenKey(InText.ToUpper(), InputKey);
                if (generateKey != null)
                {
                    MessageBox.Show("��������������� ����: " + generateKey);
                    cript = V.Encrypt(InText, generateKey);
                    richTextBox2.Text = cript;
                    File.WriteAllText(pathOut, cript);
                }
                else
                {
                    MessageBox.Show("Error!!!");
                }
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void decrypt2_Click(object sender, EventArgs e)
        {
            // ���������� ����� �� richTextBox1, ���� �� ����, ����� �� �����
            InText = richTextBox1.Text ?? File.ReadAllText(pathOut);

            string InputKey = key2.Text;
            InputKey = InputKey.ToUpper();
            StringBuilder Tkey = new StringBuilder();
            bool F = true;
            foreach (char c in InputKey)
            {
                if (Array.IndexOf(alphabet, c) == -1)
                {
                    F = false;
                }
                else
                {
                    F = true;
                    Tkey.Append(c);
                }
            }
            if (!F)
            {
                MessageBox.Show($"������������ ����");
            }
            else
            {
                string cript = "";
                VigenereCipher V = new VigenereCipher();
                cript = V.Decrypt(InText, Tkey.ToString());
                richTextBox2.Text = cript;
                File.WriteAllText(pathOut, cript);
            }
        }

        private void Key1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }

    class VigenereCipher
    {
        static char[] alphabet = "�����Ũ��������������������������".ToCharArray();
        static int alphabetSize = alphabet.Length;

        public string GenKey(string text, string K)
        {
            StringBuilder key = new StringBuilder();
            K = K.ToUpper();
            int keyIndex = 0;
            bool F = true;
            foreach (char c in K)
            {
                if (Array.IndexOf(alphabet, c) == -1)
                {
                    F = false;
                }
                else
                {
                    F = true;
                    key.Append(c);
                }
            }
            if (key == null)
            {
                MessageBox.Show($"������������ ����");
                return null;
            }

            int m = text.Length - key.Length;
            for (int i = 0; i < m; i++)
            {
                if (Array.IndexOf(alphabet, char.ToUpper(text[i])) != -1)
                {
                    key.Append(text[i]);
                    keyIndex++;
                }
                else
                {
                    keyIndex++;
                }
            }
            return key.ToString();
        }

        public string Encrypt(string Itext, string Key)
        {
            StringBuilder ciphertext = new StringBuilder();
            Key = Key.ToUpper();

            int keyIndex = 0;
            foreach (char c in Itext)
            {
                int charInd = Array.IndexOf(alphabet, char.ToUpper(c));
                if (charInd != -1) // ���� ������ � ��������
                {
                    int shift = Array.IndexOf(alphabet, char.ToUpper(Key[keyIndex % Key.Length]));
                    if (shift != -1)
                    {
                        char encryptedChar = alphabet[(charInd + shift) % alphabetSize];
                        ciphertext.Append(char.IsLower(c) ? char.ToLower(encryptedChar) : encryptedChar);
                        keyIndex++;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    ciphertext.Append(c); // ���� ������ �� � ��������, ��������� ��� ��� ���������
                }
            }
            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext, string Key)
        {
            StringBuilder plaintext = new StringBuilder();
            Key = Key.ToUpper();

            int tmpInd = Key.Length - 1;
            int keyIndex = 0;
            int j = 0;
            int shift = 0;
            foreach (char c in ciphertext)
            {
                int charInd = Array.IndexOf(alphabet, char.ToUpper(c));

                if (charInd != -1) // ���� ������ � ��������
                {
                    if (keyIndex > tmpInd)
                    {
                        string S = plaintext.ToString();
                        Key += S[j];
                        shift = Array.IndexOf(alphabet, char.ToUpper(S[j]));
                        j++;
                    }
                    else
                    {
                        shift = Array.IndexOf(alphabet, char.ToUpper(Key[keyIndex]));
                        keyIndex++;
                    }
                    int decryptedIndex = (charInd - shift + alphabetSize) % alphabetSize;
                    char decryptedChar = alphabet[decryptedIndex];

                    plaintext.Append(char.IsLower(c) ? char.ToLower(decryptedChar) : decryptedChar);
                }
                else
                {
                    plaintext.Append(c); // ���� ������ �� � ��������, ��������� ��� ��� ���������
                }
            }
            j++;
            return plaintext.ToString();
        }
    }
}