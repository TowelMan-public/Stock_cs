namespace word
{
    public class KIBAN//単語を扱う基クラス
    {
        public string word;//単語名
        public string junl;//分類名
        public string info;//内容
        public string file;//画像パス
        public bool TF;//読み取っていいかのフラグ
        public bool pic;//画像が存在するかのフラグ

        public KIBAN()//コンストラクタ（初期化）
        {
            TF = pic = false;
        }
        public void Run(string str)//変更の実行
        {
            string InfoFilePass = word + "\\" + junl+"\\info.txt";//パス作成
            info = str;//内容をセット
            System.IO.FileInfo f1 = new System.IO.FileInfo(InfoFilePass);//ファイルポインタ的なやつ
            f1.Delete();//元の内容が入ってるファイルの削除
            System.IO.FileStream fs = f1.Create();//ファイルストリーム作成
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);//書き込みストリーム作成
            sw.Write(info);//新しい内容のファイルへの反映
            sw.Close();
            fs.Close();
        }
    }
    public class KIBAN_TOUROKU : KIBAN//単語の登録をする派生クラス
    {
        private int count;//単語情報の取り込み（セット）がどの段階化を表す

        public KIBAN_TOUROKU()//コンストラクタ(初期化）
        {
            count = 0;//初期値
            TF = false;
        }
        public void Set(string str)//単語のセット(取り込み)をおこなう
        {
            switch (count)
            {
                case 0:
                    word = str;
                    ++count;
                    return;
                case 1:
                    junl = str;
                    ++count;
                    return;
                case 2:
                    info = str;
                    ++count;
                    return;
                case 3:
                    file = str;
                    ++count;
                    return;
                default:
                    return;
            }
        }
        public void Run()//単語の登録の実行
        {
            string InfoFilePass = word + "\\" + junl + "\\";//ディレクトリパス作成
            System.IO.Directory.CreateDirectory(InfoFilePass);//ディレクトリの作成
            InfoFilePass += "info.txt";//パス作成
            System.IO.FileInfo f1 = new System.IO.FileInfo(InfoFilePass);//ファイルポインタ的なやつ作成
            System.IO.FileStream fs = f1.Create();//ファイルストリーム作成
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);//書き込みストリーム作成
            sw.Write(info);//内容のファイルへの反映
            sw.Close();
            fs.Close();
            if (count != 4)//画像パスが未指定
            {
                TF = true;
                return;
            }
            InfoFilePass = word + "\\" + junl + "\\pic" + file.Substring(file.IndexOf("."));//画像を保存する場所を表すパスの作成
            System.IO.File.Copy(file, InfoFilePass);//画像のコピー
            InfoFilePass = word + "\\" + junl + "\\pic.txt";//拡張子を保存するファイルのパス作成
            f1= new System.IO.FileInfo(InfoFilePass);//ファイルポインタ的なやつ作成
            fs = f1.Create();//ファイルストリーム作成
            sw = new System.IO.StreamWriter(fs);//書き込みストリーム作成
            sw.Write(file.Substring(file.IndexOf(".")));//拡張子を保存
            sw.Close();
            fs.Close();
            TF = true;
            pic = true;
        }
    }
    public class KIBAN_KENSAKU : KIBAN//単語の検索をする派生クラス
    {
        private int count;//単語情報の取り込み（セット）がどの段階化を表す
        private int JCount;//検索候補数を記憶
        public string[] Cjunl;//検索候補の分類名を保存する文字列の配列

        public KIBAN_KENSAKU()//コンストラクタ(初期化）
        {
            count = 0;//初期値
            JCount = -100;//初期値
            TF = pic = false;
        }
        public void Set(string str)//単語のセット(取り込み)をおこなう
        {
            switch (count)
            {
                case 0:
                    word = str;
                    ++count;
                    return;
                case 1:
                    junl = str;
                    ++count;
                    return;
                default:
                    return;
            }
        }
        public int  Run()//検索の実行
        {           
            if (count == 2)//分類名も指定されている
            {
                string str = word + "\\" + junl + "\\info.txt";//探すべきパスの作成
                if (!System.IO.File.Exists(str)) return -1;//ファイルが存在しない＝その単語は存在しない
                JCount = 1;//単語が一つのみということが確定
                System.IO.StreamReader sw = new System.IO.StreamReader(str);//読み込みストリーム作成
                info = sw.ReadToEnd();//内容の読み込み
                sw.Close();
                TF = true;
                str = word + "\\" + junl + "\\pic.txt";//画像の拡張子の保存されてるファイルのパス作成
                if (!System.IO.File.Exists(str)) return 0;//画像が存在しない
                sw = new System.IO.StreamReader(str);////読み込みストリーム作成
                str = sw.ReadToEnd();//拡張子の読み込み
                file = word + "\\" + junl + "\\pic" + str;//画像パス作成
                pic = true;
                return 0;
            }
            else
            {
                switch (GetStats())//検索候補がいくつあるのかを知らなかったべて、候補の分類名を取得する
                {
                    case -1://エラー
                        return -1;
                    case 1://一つのみヒット
                        junl = Cjunl[0];
                        count = 2;
                        return Run();//再帰的に呼びだしてその戻り値をそのまま返す(必ず一度しかここを通らない）
                    default://複数ヒット
                        return 0;
                }
            }
        }
        public int GetStats()//検索候補がいくつあるのかを知らなかったべて、候補の分類名を取得する
        {
            if (JCount != -100) return JCount;//既に検索候補数がわかっている
            JCount = 0;//ヒットしなかったらこのまま
            string str = word + "\\";//検索するディレクトリのパス作成
            if (!System.IO.Directory.Exists(str))//一つもない
            {
                JCount = 0;
                return -1;
            }
            string[] subFolders = System.IO.Directory.GetDirectories(str, "*", System.IO.SearchOption.AllDirectories);//ヒットしたディレクトリのパスの記憶
            foreach (string fstr in subFolders)//検索候補数を調べる
            {
                ++JCount;
            }
            Cjunl = new string[JCount];//検索候補数分検索候補の分類名を記憶する文字列配列の確保
            for(int i = 0; i < JCount; i++)//分類名の取得
            {
                Cjunl[i] = subFolders[i].Substring(subFolders[i].IndexOf("\\")+1);
            }
            return JCount;
        }
        public int Set(int a)//実際にこのクラス（実体）にセットする検索候補の選択（セット）
        {
            junl = Cjunl[a - 1];//検索候補の分類名のセット
            count = 2;
            return Run();//内容等の取り込みを実行し、その結果を戻り値として返す
        }
    }
}