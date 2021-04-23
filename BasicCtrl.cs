using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace AdminTeleWorkList
{
    public partial class AdminTeleWorkList : Form
    {
        /// <summary>
        /// トグルスイッチクラスのインスタンス
        /// </summary>
        TglSwitch ModeTglSw;
        /// <summary>
        /// メッセージボックスの結果を受け取る。
        /// </summary>
        DialogResult judge;
        /// <summary>
        /// テレワーク端末リスト.csvの各行を読む際に使う。
        /// </summary>
        List<string> listReadLines;

        public AdminTeleWorkList()
        {
            InitializeComponent();
            // トグルスイッチについての設定
            ModeTglSw = new TglSwitch();
            EventHandler TglHandler = new EventHandler(ModeTgl_Change);
            ModeTglSw.Click += TglHandler;
            ModeTglSw.Location = new Point(440, 8);
            ModeTglSw.Size = new Size(38, 20);
            ModeTglSw.Cursor = Cursors.Hand;
            Controls.Add(ModeTglSw);
            ModeTglSw.Checked = true;
            ModeTglSw.BringToFront();

            // ショートカットキーを設定する。
            KeyPreview = true;
            KeyDown += AdminTWL_KeyDown;
            // フォームクローズ時イベントを使用する。
            FormClosing += AdminTWL_Closing;
        }
        /// <summary>
        /// 追加/更新ボタン押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_UpdateBtn_Click(object sender, EventArgs e)
        {
            // csvPathのテキストボックス入力値がない場合
            if (csvPathTxt.Text == "")
            {
                // csvファイルが選択されていない旨をメッセージボックスで出力する。
                MessageBox.Show( "csvファイルが選択されていません。",
                                 "csvファイル未選択",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                // 終了
                return;
            }
            try
            {
                // カウンタ
                int ic;
                // streamReaderで読み取る1行あたりの文字列情報
                string line;
                string OldInfo = "";
                // 新規情報の文字列をここに格納する。
                string NewInfo = "";
                // 変更後の現在の登録情報文字列をここに格納する。
                string CurrentInfo = "";
                // こいつのメモリ解放を明示的に行いたいが、やり方わからんくて未実装
                listReadLines = new List<string>();
                // ID入力値が異常(1~3桁)または管理者使用者氏名が全角で書かれていない場合のエラー
                if (   (old_ID.Value != 0 && old_ID.Value < 1000)
                    || (new_ID.Value != 0 && new_ID.Value < 1000)
                    || !IsFulLetrs(AdminName.Text)
                    || !IsFulLetrs(UserName.Text))
                {
                    MessageBox.Show("入力値が異常です。"
                          + "\n\n" + "入力IDが3桁または管理者使用者入力値が半角文字になっています。",
                                     "入力値異常",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                    // 終了
                    return;
                }
                // 更新モードの場合
                if (ModeTglSw.Checked)
                {
                    bool bUpdated = false;
                    using (StreamReader sr = new StreamReader(@csvPathTxt.Text, System.Text.Encoding.GetEncoding("shift_jis")))
                    {
                        // Read and display lines from the file until the end of
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(",,")        // 何も記載されてなくて","が2連続している場合
                            || line.Contains(",,,")       // 何も記載されてなくて","が3連続している場合
                            || line == ""                 // ただ改行されているだけの行
                            || line.IndexOf(",") == -1    // ","のない記述
                            || !IsFulLetrs(line))         // 全角文字列がない → 管理者使用者情報が登録されていない場合
                                continue;
                            listReadLines.Add(line);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(@csvPathTxt.Text, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
                    {
                        for (ic = 0; ic < listReadLines.Count; ic++)
                        {
                            if (listReadLines[ic].Contains(old_ID.Value.ToString()))
                            {
                                // 末尾に","があればトリムする。
                                listReadLines[ic] = listReadLines[ic].TrimEnd(',');
                                // 変更前の端末情報文字列をOldInfoに格納する。
                                OldInfo           = listReadLines[ic];
                                // 変更後の端末情報文字列をNewInfoに格納する。
                                NewInfo           = new_ID.Value + "," + AdminName.Text + "," + UserName.Text;
                                // 新規端末情報文字列を書き込む。
                                sw.Write(NewInfo);
                                // 更新フラグをtrueに切り替える。
                                bUpdated          = true;
                            }
                            else
                            {
                                sw.Write(listReadLines[ic]);
                            }
                            // 最後の行でなければ改行する。
                            if (ic < listReadLines.Count - 1)
                                sw.Write(Environment.NewLine);
                        }
                    }
                    if (bUpdated)
                    {
                        for (ic = 1; ic < listReadLines.Count; ic++)
                        {
                            listReadLines[ic] = listReadLines[ic].TrimEnd(',');

                            if (listReadLines[ic].Contains(old_ID.Value.ToString()))
                                CurrentInfo += NewInfo + " <= 更新";
                            else
                                CurrentInfo += listReadLines[ic];

                            if (ic < listReadLines.Count - 1)
                                CurrentInfo += "\n";
                        }
                        // csvパス以外の全ての入力情報をリセットする。
                        AllTxtReset();
                        MessageBox.Show("端末情報を更新しました。"
                            + "\n\n" + OldInfo + " => " + NewInfo
                              + "\n\n" + "登録情報："
                              + "\n" + CurrentInfo,
                                         "新規端末情報追加",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                }
                // 追加モードの場合
                else
                {
                    // 重複行 - 1の値
                    int  nDupLine = 0;
                    // 重複があったらこのフラグをtrueにする。
                    bool bDupFlg  = false;
                    // 一旦csvの中をreadしてみて、情報が既にあるか確認する。
                    using (StreamReader sr = new StreamReader(@csvPathTxt.Text, System.Text.Encoding.GetEncoding("shift_jis")))
                    {
                        // Read and display lines from the file until the end of
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains(",,")        // 何も記載されてなくて","が2連続している場合
                            || line.Contains(",,,")       // 何も記載されてなくて","が3連続している場合
                            || line == ""                 // ただ改行されているだけの行
                            || line.IndexOf(",") == -1    // ","のない記述
                            || !IsFulLetrs(line))         // 全角文字列がない → 管理者使用者情報が登録されていない場合
                                continue;
                            // 1行1行を読み取る。
                            listReadLines.Add(line);
                            // 情報が既にcsvファイル内にある場合
                            if (line.Substring(0, 4) == new_ID.Value.ToString())
                            {
                                judge = MessageBox.Show( "すでに同じIDが振られている端末がありますが、上書きしますか？",
                                                         "確認",
                                                         MessageBoxButtons.OKCancel,
                                                         MessageBoxIcon.Warning);
                                if (judge == DialogResult.OK)
                                {
                                    bDupFlg  = true;
                                    nDupLine = listReadLines.Count - 1;
                                }
                                else return;
                            }
                        }
                    }
                    // 入力情報と既存情報に重複がない場合
                    if (nDupLine == 0)
                    {
                        using (StreamWriter sw = new StreamWriter(@csvPathTxt.Text, true, System.Text.Encoding.GetEncoding("Shift_JIS")))
                        {
                            // 一旦改行する。
                            sw.Write(Environment.NewLine);
                            // 新規情報をstringに詰める。→ 新規端末のID,管理者氏名,使用者氏名
                            NewInfo = new_ID.Value.ToString() + "," + AdminName.Text + "," + UserName.Text;
                            // 新規情報を入力する。
                            sw.Write(NewInfo);
                        }
                    }
                    // 入力情報と既存情報に重複がある場合
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(@csvPathTxt.Text, false, System.Text.Encoding.GetEncoding("Shift_JIS")))
                        {
                            for (ic = 0; ic < listReadLines.Count; ic++)
                            {
                                if (ic == nDupLine)
                                {
                                    // 変更前の端末情報文字列をOldInfoに格納する。
                                    OldInfo = listReadLines[ic];
                                    // 変更後の端末情報文字列をNewInfoに格納する。→ 新規端末のID,管理者氏名,使用者氏名
                                    NewInfo = new_ID.Value.ToString() + "," + AdminName.Text + "," + UserName.Text;
                                    // 新規情報を入力する。
                                    sw.Write(NewInfo);
                                }
                                else
                                {
                                    // streamReaderのときにAddした文字列たちを書き込む。
                                    sw.Write(listReadLines[ic]);
                                }
                                // 最後の行でなければ改行する。
                                if (ic < listReadLines.Count - 1)
                                    sw.Write(Environment.NewLine);
                            }
                        }
                    }
                    // csvパス以外の全ての入力情報をリセットする。
                    AllTxtReset();
                    // 重複情報があった場合
                    if (bDupFlg)
                    {
                        for (ic = 1; ic < listReadLines.Count; ic++)
                        {
                            listReadLines[ic] = listReadLines[ic].TrimEnd(',');

                            if (listReadLines[ic].Contains(new_ID.Value.ToString()))
                                CurrentInfo += NewInfo + " <= 更新";
                            else
                                CurrentInfo += listReadLines[ic];

                            if (ic < listReadLines.Count - 1)
                                CurrentInfo += "\n";
                        }
                        MessageBox.Show("端末情報を更新しました。"
                            + "\n\n" + OldInfo + " => " + NewInfo
                              + "\n\n" + "登録情報："
                              + "\n" + CurrentInfo,
                                         "新規端末情報追加",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                    // 重複情報がなく、通常の追加だった場合
                    else
                    {
                        for (ic = 1; ic < listReadLines.Count; ic++)
                        {
                            listReadLines[ic] = listReadLines[ic].TrimEnd(',');

                            if (ic == listReadLines.Count - 1)
                                CurrentInfo += NewInfo + " <= 追加";
                            else
                                CurrentInfo += listReadLines[ic] + "\n";
                        }
                        MessageBox.Show("新規端末情報を追加しました。"
                              + "\n\n" + "追加情報：" + NewInfo
                              + "\n\n" + "登録情報："
                              + "\n" + CurrentInfo,
                                         "新規端末情報追加",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 参照ボタン押下時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog   = new OpenFileDialog();
            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\DeskTop\";
            // ダイアログのタイトルを指定する
            ofDialog.Title            = "ダイアログのタイトル";
            // 選択するファイルの拡張子をcsvで指定する。
            ofDialog.Filter           = "CSV (カンマ区切り)|*.csv";
            //ダイアログを表示する
            judge = ofDialog.ShowDialog();
            if (judge == DialogResult.OK)
            {
                if (ofDialog.FileName.Contains("テレワーク"))
                {
                    // テキストボックスにパスを格納する。
                    csvPathTxt.Text = ofDialog.FileName;
                    // オブジェクトを破棄する
                    ofDialog.Dispose();
                    // 終了
                    return;
                }
                // csvファイル名に"テレワーク"が含まれていない場合は、テレワーク端末リストと異なるファイルでないか確認する。(英語で書かれたファイルの可能性も考慮して一応念のため)
                if (MessageBox.Show("テレワーク端末リスト.csvを選択しましたか？",
                                     "選択間違ってない？",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning)
                                                    == DialogResult.Yes)
                {
                    // オブジェクトを破棄する
                    ofDialog.Dispose();
                    // 終了
                    return;
                }
                else
                {
                    // 参照ボタン押下時イベントを明示的に発生し、ファイル選択画面を再表示する。
                    ReferBtn.PerformClick();
                }
            }
            // オブジェクトを破棄する
            ofDialog.Dispose();
        }
        /// <summary>
        /// 追加/更新トグルスイッチ切り替え時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ModeTgl_Change(object sender, EventArgs e)
        {
            Add_UpdateBtnChange();
        }
        /// <summary>
        /// キーダウンイベントメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AdminTWL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_UpdateBtn.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
                Close();
        }
        /// <summary>
        /// ウィンドウクローズ時確認メッセージ出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminTWL_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(
                    "本当に終了しますか？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 追加/更新ボタンの表示を切り替える。
        /// </summary>
        private void Add_UpdateBtnChange()
        {
            if (ModeTglSw.Checked)
            {
                old_ID.Enabled          = true;
                Add_UpdateBtn.Text      = "更新";
                Add_UpdateBtn.BackColor = Color.RoyalBlue;
            }
            else
            {
                old_ID.Enabled          = false;
                Add_UpdateBtn.Text      = "追加";
                Add_UpdateBtn.BackColor = Color.Tomato;
            }
        }
        /// <summary>
        /// 全てのテキスト情報をリセットする。
        /// </summary>
        private void AllTxtReset()
        {
            old_ID.Value    = 0;
            new_ID.Value    = 0;
            AdminName.Text  = "";
            UserName.Text   = "";
        }
        /// <summary>
        /// 引数文字列の全角チェックを行う。
        /// </summary>
        /// <param name="s">チェック対象の文字列</param>
        /// <returns></returns>
        private bool IsFulLetrs(string s)
        {
            System.Text.Encoding Enc = System.Text.Encoding.GetEncoding("Shift-JIS");

            // 全角文字列が含まれている場合、文字数よりもバイト数の方が大きくなる。
            if (Enc.GetByteCount(s) > s.Length)
                return true;
            // 全て半角文字列の場合、文字数とバイト数は一致する。
            else
                return false;
        }
    }
}
