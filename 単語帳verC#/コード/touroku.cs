using System;
using System.Windows.Forms;

namespace word
{
    public partial class touroku : Form//登録ダイアログボックス
    {
        private KIBAN_TOUROKU tou;//単語の登録をするためのクラス
        private Form1 mobj;//メインウィンドウの実体

        public touroku(Form1 form1)//コンストラクタ(引数１：メインウィンドウの実体のポインタ)
        {
            InitializeComponent();
            tou = new KIBAN_TOUROKU();
            mobj = form1;
            mobj.flag_i = true;//フラグのセット
        }
        private void button1_Click(object sender, EventArgs e)//登録ボタンクリック
        {
            if (textBox1.TextLength != 0)//単語名が入力されてる(必須）
            {
                if(textBox2.TextLength != 0)//分類名が入力されてる(必須）
                {
                    if(textBox4.TextLength != 0)//内容が入力されている(必須）
                    {
                        tou.Set(textBox1.Text);//情報のセット
                        tou.Set( textBox2.Text);
                        tou.Set( textBox4.Text);
                        if (textBox3.TextLength != 0) tou.Set(textBox3.Text);//画像パスが入力されている
                        tou.Run();//登録の実行
                        mobj.kiban = tou;//メインウィンドウに情報の受け渡し
                        mobj.Picture_Paint();//メインウィンドウの画面の更新
                        mobj.flag_i = false;//フラグ
                        this.Close();
                        return;
                    }
                }
            }
            MessageBox.Show("必須項目に未入力があります！");
        }
        private void button2_Click(object sender, EventArgs e)//キャンセルボタンが押された
        {
            mobj.flag_i = false;
            this.Close();
        }
        private void touroku_FormClosing(object sender, FormClosingEventArgs e)//×が押された
        {
            mobj.flag_i = false;
        }
    }
}
