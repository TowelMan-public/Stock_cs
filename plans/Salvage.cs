using System;
using ClosedXML.Excel;

namespace plans
{
    public class Salvage
    {
        public int year { get; set; }
        public int moon { get; set; }
        public int dayCount { get; set; }
        public int farstWeek { get; set; }//0～6 日曜日から
        public DaysPlan[] Days { get; set; }

        //初期化
        public Salvage()
        {
            year = -1;
            moon = -1;
            dayCount = -1;
            farstWeek = -1;
        }

        public Salvage(int in_year,int in_moon)
        {
            //入力値の反映等
            year = in_year;
            moon = in_moon;
            dayCount = -1;
            farstWeek = -1;
            //ロード
            LoadPlans();
        }

        //予定の取得
        public void LoadPlans()
        {
            //入力値の確認
            if (year <= 0 || moon <= 0 || moon > 12)
                return;//TODO 出来れば例外投げたい

            //日付関係
            dayCount = DateTime.DaysInMonth(year, moon);
            Days = new DaysPlan[dayCount];
            for (int i = 0; i < dayCount; i++)
                Days[i] = new DaysPlan();
            //曜日
            DateTime getWeek = new DateTime(year, moon, 1);
            switch (getWeek.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    farstWeek = 0;
                    break;
                case DayOfWeek.Monday:
                    farstWeek = 1;
                    break;
                case DayOfWeek.Tuesday:
                    farstWeek = 2;
                    break;
                case DayOfWeek.Wednesday:
                    farstWeek = 3;
                    break;
                case DayOfWeek.Thursday:
                    farstWeek = 4;
                    break;
                case DayOfWeek.Friday:
                    farstWeek = 5;
                    break;
                case DayOfWeek.Saturday:
                    farstWeek = 6;
                    break;
            }

            //ファイル名の作成・ファイル確認・ロード
            string excelFileName = year.ToString() + "-" + moon.ToString() + ".xlsx";
            if (System.IO.File.Exists(excelFileName))//ファイルがある
            {
                using (var workbook = new XLWorkbook(excelFileName, XLEventTracking.Disabled))
                {
                    IXLWorksheet worksheet;
                    for (int i = 1; i <= 4; i++)
                    {
                        worksheet = workbook.Worksheet(i);
                        for (int j = 1; j <= dayCount; j++)
                        {
                            //worksheet.Cell(j, 1).Value = 1;
                            Days[j - 1].Plan[i - 1].title = worksheet.Cell(j, 1).Value.ToString();//予定のタイトル取得
                            Days[j - 1].Plan[i - 1].info = worksheet.Cell(j, 2).Value.ToString();//予定の内容の取得
                        }
                    }
                    // workbook.SaveAs(excelFileName);
                    workbook.Save();
                    workbook.Dispose();
                }
            }
            else//ファイルがない
            {
                //エクセルデータの作成
                using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
                {                   
                    //シートの作成
                    IXLWorksheet worksheet;
                    for (int i = 1; i < 5; i++)
                        worksheet = workbook.Worksheets.Add("sheet" + i.ToString());
                    //セーブ
                    workbook.SaveAs(excelFileName);
                    workbook.Dispose();
                }
            }
        }

        //破棄する時にする処理
        ~Salvage()
        {
            //反映する必要がないものを省く
            if (year <= 0 || moon <= 0 || moon > 12)
                return;
            //反映する
            string excelFileName = year.ToString() + "-" + moon.ToString() + ".xlsx";
            XLWorkbook workbook;
            try
            {
                workbook = new XLWorkbook(excelFileName, XLEventTracking.Disabled);
            }
            catch (System.Exception e) {
                workbook = new XLWorkbook(excelFileName, XLEventTracking.Disabled);
            }
            //シートの作成
            IXLWorksheet worksheet;
            for (int i = 1; i <= 4; i++)
            {
                worksheet = workbook.Worksheet(i);
                for (int j = 1; j <= dayCount; j++)
                {
                    worksheet.Cell(j, 1).Value = Days[j - 1].Plan[i - 1].title;//予定のタイトル反映
                    worksheet.Cell(j, 2).Value = Days[j - 1].Plan[i - 1].info;//予定の内容の反映
                }
            }
            //セーブ
            try
            {
                workbook.Save();
            }
            catch (System.Exception e)
            {
                workbook.Save();
            }
            workbook.Dispose();
        }
    }
}