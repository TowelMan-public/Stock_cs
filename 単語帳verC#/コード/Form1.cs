using System;
using System.Windows.Forms;

namespace word
{
    public partial class Form1 : Form
    {
        public bool flag_i;//登録ダイアログが開いているか
        public bool flag_r;//検索ダイアログか検索候補選択ダイアログが開いている
        public KIBAN kiban;//メインウィンドウでつかう単語の情報を扱うクラス

        public Form1()//コンストラクタ
        {
            InitializeComponent();
            kiban = new KIBAN();
            flag_i = flag_r = false;
        }
        private void button3_Click(object sender, EventArgs e)//変更ボタンクリック
        {
            var result = MessageBox.Show("内容をメインウィンドウのように変更しますか？", "確認",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            kiban.Run(textBox1.Text);//変更の実行
            MessageBox.Show("変更しました　失敗しているかはわかりません");
        }
        private void button2_Click(object sender, EventArgs e)//登録ボタンクリック
        {
            if (flag_i)
            {
                MessageBox.Show("既に登録ダイアログが開かれています！");
                return;
            }
            touroku touroku = new touroku(this);//登録ダイアログを生成
            touroku.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//使わない
        {

        }
        public void Picture_Paint()//画面を更新する関数
        {
            if (kiban.TF)
            {
                label3.Text = kiban.word;//ラベルの更新
                label4.Text = kiban.junl;
                textBox1.Text = kiban.info;
                if (kiban.pic)//画像がある
                {
                    pictureBox1.ImageLocation = kiban.file;//画像の表示
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)//検索ボタンクリック
        {
            if (flag_r)
            {
                MessageBox.Show("既に検索ダイアログか検索候補選択ダイアログが開かれています！");
                return;
            }
            kensaku1 kensaku1 = new kensaku1(this);//検索ダイアログ作成
            kensaku1.Show();
        }
    }
}