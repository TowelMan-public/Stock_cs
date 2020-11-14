using System;
using System.Windows.Forms;

namespace word
{
    public partial class kensaku2 : Form//検索候補選択ダイアログボックス
    {
        private Form1 form1;//メインウィンドウの実体
        private KIBAN_KENSAKU ken;//単語の検索をするためのクラス
        private int now;//いま表示している件数を記憶するための変数(「now*5+チェックボックスの位置(１～５）」の公式で何件目の単語が選択されたかがわかる）
        private CheckBox[] boxes;//チェックボックスの実体をまとめるための配列

        public kensaku2(Form1 obj,KIBAN_KENSAKU Kobj)//コンストラクタ（引数１：メインウィンドウの実体のポインタ　引数2：引き継ぐ単語の検索をするためのクラスの実体
        {            
            InitializeComponent();
            form1 = obj;
            ken = Kobj;//引継ぎ
            now = 0;//初期値
            boxes = new CheckBox[5];
            boxes[0] = checkBox1;
            boxes[1] = checkBox2;
            boxes[2] = checkBox3;
            boxes[3] = checkBox4;
            boxes[4] = checkBox5;
            label1.Text = "次の中から選択してください" + ken.GetStats() + "件中　" + "1～" + (ken.GetStats() >= 5 ? 5 : ken.GetStats()) + "件目";//表示する文字列作成
            for(int i = 0; i < 5; i++)//チェックボックスにセットする
            {
                if (i >= ken.GetStats())//存在しない
                {
                    boxes[i].Text = "";
                    continue;
                }
                boxes[i].Text = ken.word + "：" + ken.Cjunl[i];
            }
        }
        private void button2_Click(object sender, EventArgs e)//次へボタンが押された
        {
            if ((now + 1) * 5 >= ken.GetStats())
            {
                MessageBox.Show("これ以上ありません！");
                return;
            }
            label1.Text = "次の中から選択してください" + ken.GetStats() + "件中　" +( (now+1)*5+1)+"～" + (ken.GetStats() >= (now + 2) * 5 ? (now + 2) * 5 : ken.GetStats()) + "件目";//表示する文字列作成
            for (int i = 0, j = (now + 1) * 5; i < 5; i++, j++)//チェックボックスにセットする
            {
                if (j >= ken.GetStats())//存在しない
                {
                    boxes[i].Text = "";
                    continue;
                }
                boxes[i].Text = ken.word + "：" + ken.Cjunl[j];
            }
            ++now;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//使わない
        {

        }
        private void button1_Click(object sender, EventArgs e)//戻るボタンが押された
        {
            if (now<1)
            {
                MessageBox.Show("既に最初のやつが表示されています！");
                return;
            }
            label1.Text = "次の中から選択してください" + ken.GetStats() + "件中　" + ((now - 1) * 5 + 1) + "～" + now * 5 + "件目";//表示する文字列作成
            for (int i = 0, j = (now - 1) * 5; i < 5; i++, j++)//チェックボックスにセットする
            {
                boxes[i].Text = ken.word + "：" + ken.Cjunl[j];
            }
            --now;
        }
        private void button3_Click(object sender, EventArgs e)//決定ボタンが押された
        {
            int CPoint = -100;//チェックボックスの位置記憶用・初期値-100
            for(int i = 0; i < 5; i++)//チェック位置を走査する
            {
                if (boxes[i].Checked)//チェックされている
                {
                    if (CPoint == -100) CPoint = i + 1;//チェックが一つ目
                    else
                    {//チェックが2つ目
                        CPoint = -77;//チェックが2つ以上されていることを表す
                        break;
                    }
                }
            }
            if (CPoint < 0)//「チェックは必ず一つにつける」という条件を満たしていない
            {
                MessageBox.Show("チェックは必ず一つにつけてください！");
                return;
            }
            if (CPoint + now * 5 > ken.GetStats())
            {
                MessageBox.Show("そこは対応していません！");
                return;
            }
            ken.Set(5 * now + CPoint);//単語情報のセット
            form1.kiban = ken;//単語情報をメインウィンドウに受け渡し
            form1.Picture_Paint();//メインウィンドウの画面更新
            form1.flag_r = false;//フラグ
            this.Close();
        }
        private void kensaku2_FormClosing(object sender, FormClosingEventArgs e)//×が押された
        {
            form1.flag_r = false;
        }
        private void button4_Click(object sender, EventArgs e)//キャンセルボタンが押された
        {
            form1.flag_r = false;
            this.Close();
        }
    }
}
