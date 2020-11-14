using System;
using System.Windows.Forms;

namespace word
{    
    public partial class kensaku1 : Form//検索ダイアログボックス
    {
        private Form1 mobj;//メインウィンドウの実体
        private KIBAN_KENSAKU ken;//単語の検索をするためのクラス

        public kensaku1(Form1 form1)//コンストラクタ(引数１：メインウィンドウの実体のポインタ)
        {
            InitializeComponent();
            mobj = form1;
            mobj.flag_r = true;//フラグのセット
            ken = new KIBAN_KENSAKU();
        }
        private void button1_Click(object sender, EventArgs e)//検索ボタンが押された
        {
            if (textBox1.TextLength == 0)//単語名(必須）が入力されてない
            {
                MessageBox.Show("単語名を入力してください！");
                return;
            }
            ken.Set(textBox1.Text);//セット
            if (textBox2.TextLength != 0) ken.Set(textBox2.Text);//分類名が入力されてる
            if (ken.Run() == -1)
            {
                MessageBox.Show("エラー発生！");
                return;
            }
            if (ken.GetStats() == 1)//単語が一つヒット
            {
                mobj.kiban = ken;//メインウィンドウに単語情報を渡す
                mobj.Picture_Paint();//メインウィンドウの画面の更新
            }
            else//複数ヒット
            {
                kensaku2 kensaku2 = new kensaku2(mobj,ken);//検索候補選択ダイアログ生成
                kensaku2.Show();
            }
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)//キャンセルボタンが押された
        {
            mobj.flag_r = false;
            this.Close();
        }
        private void kensaku1_Load(object sender, EventArgs e)//使わない
        {
           
        }
        private void kensaku1_FormClosing(object sender, FormClosingEventArgs e)//×が押された
        {
            mobj.flag_r = false;
        }
    }
}
