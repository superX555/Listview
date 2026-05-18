using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listview
{
    public partial class lstBorrow : Form
    {
        string[] b_name = { "三國演義", "西遊記","唐詩三百首","楚辭",
                "西廂記","水滸傳","紅樓夢", "牡丹亭" }; //書名
        string[] author = {"羅貫中", "吳承恩", "孫洙", "劉向",
                "王實甫","施耐庵", "曹雪芹", "湯顯祖" }; //作者
        string[] kind = { "章回小說", "章回小說", "詩選", "詩歌", "戲曲",
                "章回小說","章回小說", "戲曲" }; //類別

        public lstBorrow()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void grpBorrow_Enter(object sender, EventArgs e)
        {
        }

        private void lstBorrow_Load(object sender, EventArgs e)
        {
            // 設定檢視方式下拉選單項目
            cmbView.Items.Add("大圖示");
            cmbView.Items.Add("詳細資料");
            cmbView.Items.Add("小圖示");
            cmbView.Items.Add("清單");
            cmbView.Items.Add("大圖示加詳細資料");
            cmbView.SelectedIndex = 0; //預設選取第一個項目 (大圖示)

            // 新增 ListView 欄位
            lvwBooks.Columns.Add("書名", 130);
            lvwBooks.Columns.Add("作者", 80);
            lvwBooks.Columns.Add("類別", 100);

            lvwBooks.BeginUpdate(); //暫停重繪，優化載入效能

            // 跑迴圈載入所有書籍資料
            for (int i = 0; i < b_name.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(b_name[i]);
                lvi.SubItems.Add(author[i]); //新增 作者 欄位資料
                lvi.SubItems.Add(kind[i]);   //新增 類別 欄位資料
                lvwBooks.Items.Add(lvi);     //新增項目
                lvwBooks.Items[i].ImageIndex = i; //指定影像的索引值
            }

            lvwBooks.EndUpdate(); //恢復重繪
        }

        private void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根據cmbView的SelectedIndex屬性值，設定檢視方式
            switch (cmbView.SelectedIndex)
            {
                case 0: //大圖示
                    lvwBooks.View = View.LargeIcon;
                    break;
                case 1: //詳細資料
                    lvwBooks.View = View.Details;
                    break;
                case 2: //小圖示
                    lvwBooks.View = View.SmallIcon;
                    break;
                case 3: //清單
                    lvwBooks.View = View.List;
                    break;
                case 4: //大圖示加詳細資料
                    lvwBooks.View = View.Tile;
                    break;
            }
        }

        private void lvwBooks_ItemActivate(object sender, EventArgs e)
        {
            // 確保使用者真的有選取項目，避免點擊空白處引發異常
            if (lvwBooks.SelectedIndices.Count > 0)
            {
                //取得選中的書名
                string strBookname = b_name[lvwBooks.SelectedIndices[0]];

                // 【關鍵修正】：將 lstBorrow.Items 改為 listBox1.Items
                bool exist = listBox1.Items.Contains(strBookname);

                if (exist != true) // 若選取的書名不存在借書清單中
                {
                    DialogResult dr = MessageBox.Show("確定要借閱嗎?",
                    strBookname, MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes) // 若按 <是> 鈕
                    {
                        // 【關鍵修正】：將項目新增到 listBox1 控制項中
                        listBox1.Items.Add(strBookname);
                    }
                }
            }
        }
    }
}
