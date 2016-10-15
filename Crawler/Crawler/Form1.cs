using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

using HtmlAgilityPack;
using System.Net;
using System.Xml;
namespace Crawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        bool stop = false;
        DataTable amzTable = new DataTable();
        DataTable ebayTable = new DataTable();
        List<string> _lsturl = new List<string>();
        List<string> _amazonurl = new List<string>();
        List<string> _ebayurl = new List<string>();
        string _Username = "Admin";
        string _Password = "tortoise" + DateTime.Now.Day;
        string _filenameextrension = "";
        string _LocalFileName = Application.StartupPath + "/Files/";
        string _Filedate = "";
        int gridindex = 0;
        private BackgroundWorker m_AsyncWorker = new BackgroundWorker();
        private BackgroundWorker m_AsyncWorker1 = new BackgroundWorker();
        DataTable table = new DataTable();
        DataTable dt = new DataTable();
        int time;
        int i = 0;
        int totalpage = 0;
        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();//to store html document for bacgroundwroker0


        HtmlAgilityPack.HtmlDocument document2 = new HtmlAgilityPack.HtmlDocument();//to store html document for bacgroundwroker1
        string url2, url1;
        WebClient wc = new WebClient();////for get the data from link for bacKgroundworker
        WebClient wc1 = new WebClient();//for get the data from link for bacgroundwroker1
        /************************end*********************************************/
        public void DisableControlpanel()
        {
            //  _Password = _Password + DateTime.Now.Day;
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[3].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
        }
        public class CsvRow : List<string> //Making each CSV rows
        {
            public string LineText { get; set; }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }
        private void btngo_Click(object sender, EventArgs e)
        {
            amzTable = new DataTable();
            ebayTable = new DataTable();
            _amazonurl.Clear();
            _ebayurl.Clear();
            _amazonurl = (from url in _lsturl
                          where url.ToLower().Contains("amazon")
                          select url).ToList();
            _ebayurl = (from url in _lsturl
                        where url.ToLower().Contains("ebay")
                        select url).ToList();
            lblwait.Visible = false;
            lblrecords.Visible = true;
            table.Clear();
            tabControl1.TabPages[3].Enabled = true;
            gridindex = 0;
            lblprocessed.Visible = true;

            btngo.Enabled = false;
            btnpause.Enabled = true;
            btnexporttocsv.Enabled = true;
            dataGridView1.Rows.Clear();
            tabControl1.TabPages[3].Enabled = true;
            int counter = 0;
            if (_amazonurl.Count() > 0)
            {

                lblrecords.Text = "Total No of Amazon records: " + _amazonurl.Count();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                /***************Grid view************************************/
                dataGridView1.Columns.Add("Rowid", "Rowid");
                dataGridView1.Columns.Add("ASIN", "ASIN");
                dataGridView1.Columns.Add("Product Title", "Product Title");
                dataGridView1.Columns.Add("Cost", "Cost");
                dataGridView1.Columns.Add("Availability", "Availability");
                dataGridView1.Columns[2].Width = 240;
                /****************BackGround worker *************************/
                lblprocessed.Text = "Amazon url Processed: 0";
                foreach (string url in _amazonurl)
                {
                    if (url.Trim() != "")
                    {
                        try
                        {
                            while (stop == true)
                            {
                                Application.DoEvents();
                            }
                            tim(2);
                            tim(2);
                            tim(2);
                            while (m_AsyncWorker.IsBusy && m_AsyncWorker1.IsBusy)
                            {
                                Application.DoEvents();
                            }
                            if (!m_AsyncWorker.IsBusy)
                            {
                                url2 = url;
                                m_AsyncWorker.RunWorkerAsync();
                            }
                            else
                            {
                                url1 = url;
                                m_AsyncWorker1.RunWorkerAsync();
                            }
                            tim(2);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[counter].Cells[0].Value = counter;
                        dataGridView2.Rows[counter].Cells[1].Value = "Url is empty. Please provide valid url";
                        counter = counter + 1;
                    }

                }
                while (m_AsyncWorker.IsBusy || m_AsyncWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
                lblprocessed.Text = "Amazon Url Processed :" + (_amazonurl.Count() - counter);
                tim(2);
                amzTable = GenerateTable();
            }
            counter = 0;
            gridindex = 0;
            counter = 0;
            if (_ebayurl.Count() > 0)
            {
                lblrecords.Text = "Total No of eBay records: " + _ebayurl.Count();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Rowid", "Rowid");
                dataGridView1.Columns.Add("ITEM ID", "ITEM ID");
                dataGridView1.Columns.Add("Item Title", "Item Title");
                dataGridView1.Columns.Add("Price", "Price");
                dataGridView1.Columns.Add("Leaf Category URL", "Leaf Category URL");
                dataGridView1.Columns.Add("Seller", "Seller");
                dataGridView1.Columns[2].Width = 150;
                lblprocessed.Text = "eBay url Processed: 0";
                foreach (string url in _ebayurl)
                {
                    if (url.Trim() != "")
                    {
                        try
                        {
                            while (stop == true)
                            {
                                Application.DoEvents();
                            }
                            tim(2);
                            tim(2);
                            tim(2);
                            while (m_AsyncWorker.IsBusy && m_AsyncWorker1.IsBusy)
                            {
                                Application.DoEvents();
                            }
                            if (!m_AsyncWorker.IsBusy)
                            {
                                url2 = url;
                                m_AsyncWorker.RunWorkerAsync();
                            }
                            else
                            {
                                url1 = url;
                                m_AsyncWorker1.RunWorkerAsync();
                            }
                            tim(2);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[counter].Cells[0].Value = counter;
                        dataGridView2.Rows[counter].Cells[1].Value = "Url is empty. Please provide valid url";
                        counter = counter + 1;
                    }

                }
                while (m_AsyncWorker.IsBusy || m_AsyncWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
                lblprocessed.Text = "eBay Url Processed :" + (_ebayurl.Count() - counter);
                ebayTable = GenerateTable();

            }

            MessageBox.Show("Process Completed");
            btnpause.Enabled = false;
            button2.Enabled = true;
            lblwait.Visible = false;
        }
        private void bwAsync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bwAsync1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bwAsync_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwAsync = sender as BackgroundWorker;
            try
            {
                document.LoadHtml(wc.DownloadString(url2));
            }
            catch (Exception) { }
        }
        private void bwAsync1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwAsync1 = sender as BackgroundWorker;
            try
            {
                document2.LoadHtml(wc1.DownloadString(url1));
            }
            catch (Exception) { }
        }

        private string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {

                return source;
            }
        }

        public string EliminateString(string price)
        {
            try
            {


                string result = string.Empty;
                foreach (var c in price)
                {
                    int ascii = (int)c;
                    if ((ascii >= 48 && ascii <= 57) || ascii == 44 || ascii == 46 || ascii == 45)
                        result += c;
                }

                return result;

            }
            catch
            {
                return price;
            }
        }

        public int GetIndexOfProperties(string ColumnName)
        {
            if (ColumnName == "brand name" || ColumnName == "brand")
            {
                return 9;
            }
            else if (ColumnName == "part number" || ColumnName == "manufacturer part number")
            {
                return 10;
            }
            else if (ColumnName == "upc")
            {
                return 11;
            }
            else if (ColumnName == "item model number" || ColumnName == "model number")
            {
                return 12;
            }
            else if (ColumnName == "material type" || ColumnName == "material")
            {
                return 13;
            }
            else if (ColumnName == "style")
            {
                return 14;
            }
            else if (ColumnName == "color")
            {
                return 15;
            }
            else if (ColumnName == "fixture features" || ColumnName == "additional product features")
            {
                return 16;
            }
            else if (ColumnName == "size" || ColumnName == "number of items" || ColumnName == "item package quantity" || ColumnName == "package quantity")
            {
                return 17;
            }
            else if (ColumnName == "shipping weight" || ColumnName == "weight")
            {
                return 18;
            }
            else if (ColumnName == "product dimensions" || ColumnName == "dimensions")
            {
                return 19;
            }
            else
            {
                return 0;
            }
        }

        private void bwAsync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                int index = 0;
                if (url2.ToLower().Contains("amazon.com"))
                {
                    index = gridindex;
                    gridindex++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = index;
                    #region title
                    if (document.DocumentNode.SelectNodes("//span[@id=\"productTitle\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[2].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@id=\"productTitle\"]")[0].InnerText).Trim();
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@id=\"btAsinTitle\"]") != null)
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[2].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@id=\"btAsinTitle\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    #endregion title

                    #region price
                    if (document.DocumentNode.SelectNodes("//span[@id=\"priceblock_saleprice\"]") != null)//scraping the links
                    {
                        try
                        {

                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document.DocumentNode.SelectNodes("//span[@id=\"priceblock_saleprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@id=\"priceblock_ourprice\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document.DocumentNode.SelectNodes("//span[@id=\"priceblock_ourprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//b[@class=\"priceLarge\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document.DocumentNode.SelectNodes("//b[@class=\"priceLarge\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@id=\"priceblock_dealprice\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document.DocumentNode.SelectNodes("//span[@id=\"priceblock_dealprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@class=\"priceLarge\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document.DocumentNode.SelectNodes("//span[@class=\"priceLarge\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    #endregion price

                    #region Availability
                    if (document.DocumentNode.SelectNodes("//span[@class=\"a-size-medium a-color-success\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@class=\"a-size-medium a-color-success\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@class=\"availGreen\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@class=\"availGreen\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//div[@id=\"availability_feature_div\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document.DocumentNode.SelectNodes("//div[@id=\"availability_feature_div\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document.DocumentNode.SelectNodes("//span[@id=\"availability_feature_div\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@class=\"availability_feature_div\"]")[0].InnerText);
                        }
                        catch { }
                    }


                    #endregion Availability

                    #region ASIN
                    try
                    {
                        dataGridView1.Rows[index].Cells[1].Value = url2.Split('/')[5];
                    }
                    catch { }
                    try
                    {
                        if (dataGridView1.Rows[index].Cells[1].Value == null)
                        {
                            dataGridView1.Rows[index].Cells[1].Value = url2.Split('/')[4];
                        }
                    }
                    catch { }
                    #endregion ASIN
                }
                else
                {
                    index = gridindex;
                    gridindex++;
                    dataGridView1.Rows.Add();
                    GetEbayData(index, url2, document);
                }
                tim(2);
                lblprocessed.Text = (url2.ToLower().Contains("amazon") ? "Amazon" : "Ebay") + "URL Processed :" + (index + 1);
            }
            catch
            {
            }
        }

        private void bwAsync1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                int index = 0;
                if (url1.ToLower().Contains("amazon.com"))
                {
                    index = gridindex;
                    gridindex++;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = index;

                    #region title
                    if (document2.DocumentNode.SelectNodes("//span[@id=\"productTitle\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[2].Value = StripHTML(document2.DocumentNode.SelectNodes("//span[@id=\"productTitle\"]")[0].InnerText).Trim();
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@id=\"btAsinTitle\"]") != null)
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[2].Value = StripHTML(document2.DocumentNode.SelectNodes("//span[@id=\"btAsinTitle\"]")[0].InnerText).Trim();
                        }
                        catch { }

                    }
                    #endregion title

                    #region price
                    if (document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_saleprice\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_saleprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_ourprice\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_ourprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//b[@class=\"priceLarge\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document2.DocumentNode.SelectNodes("//b[@class=\"priceLarge\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_dealprice\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document2.DocumentNode.SelectNodes("//span[@id=\"priceblock_dealprice\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@class=\"priceLarge\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[3].Value = EliminateString(document2.DocumentNode.SelectNodes("//span[@class=\"priceLarge\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    #endregion price

                    #region Availability
                    if (document.DocumentNode.SelectNodes("//span[@class=\"a-size-medium a-color-success\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document.DocumentNode.SelectNodes("//span[@class=\"a-size-medium a-color-success\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@class=\"availGreen\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document2.DocumentNode.SelectNodes("//span[@class=\"availGreen\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//div[@id=\"availability_feature_div\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document2.DocumentNode.SelectNodes("//div[@id=\"availability_feature_div\"]")[0].InnerText);
                        }
                        catch { }
                    }
                    else if (document2.DocumentNode.SelectNodes("//span[@id=\"availability_feature_div\"]") != null)//scraping the links
                    {
                        try
                        {
                            dataGridView1.Rows[index].Cells[4].Value = StripHTML(document2.DocumentNode.SelectNodes("//span[@class=\"availability_feature_div\"]")[0].InnerText);
                        }
                        catch { }
                    }


                    #endregion Availability

                    #region ASIN
                    try
                    {
                        dataGridView1.Rows[index].Cells[1].Value = url1.Split('/')[5];
                    }
                    catch { }
                    try
                    {
                        if (dataGridView1.Rows[index].Cells[1].Value == null)
                            dataGridView1.Rows[index].Cells[1].Value = url1.Split('/')[4];
                    }
                    catch { }
                    #endregion ASIN
                }
                else
                {
                    index = gridindex;
                    gridindex++;
                    dataGridView1.Rows.Add();
                    GetEbayData(index, url1, document2);
                }
                tim(2);
                lblprocessed.Text = (url1.ToLower().Contains("amazon") ? "Amazon" : "Ebay") + "URL Processed :" + (index + 1);
            }
            catch
            {
            }
        }
        public void GetEbayData(int Index, string Url, HtmlAgilityPack.HtmlDocument Doc)
        {
            dataGridView1.Rows[Index].Cells[0].Value = Index;
            try
            {
                string Itemno = "";
                try
                {
                    Itemno = Url;
                    if (Itemno.IndexOf("?") >= 0)
                        Itemno = Itemno.Substring(0, Itemno.IndexOf("?"));
                    Itemno = Itemno.Substring(Itemno.LastIndexOf("/") + 1, Itemno.Length - Itemno.LastIndexOf("/") - 1);
                    dataGridView1.Rows[Index].Cells[1].Value = Itemno;
                    string categoryID = "";
                    string catName = "";
                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        string address = "http://open.api.ebay.com/shopping?callname=GetSingleItem&responseencoding=XML&appid=GouravGu-db06-4f04-874a-b901a6b9a36c&siteid=EBAY-GB&version=515&ItemID=" + Itemno.TrimEnd().TrimStart() + "&IncludeSelector=Variations,ItemSpecifics,Details";
                        HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                        {
                            xmlDoc.Load(response.GetResponseStream());
                            XmlNodeList elemList = xmlDoc.GetElementsByTagName("Item");
                            for (int i = 0; i < 1; i++)
                            {
                                foreach (XmlNode Outer in elemList[i].SelectNodes("*"))
                                {

                                    if (Outer.Name == "PrimaryCategoryID")
                                    {
                                        categoryID = Outer.InnerText.TrimEnd().TrimStart();
                                    }
                                    else if (Outer.Name == "PrimaryCategoryName")
                                    {
                                        catName = Outer.InnerText.TrimEnd().TrimStart();
                                    }
                                    else if (Outer.Name == "CurrentPrice")
                                    {
                                        dataGridView1.Rows[Index].Cells[3].Value = Outer.InnerText.TrimEnd().TrimStart();
                                    }
                                    else if (Outer.Name == "Seller")
                                    {
                                        XmlNodeList node = Outer.ChildNodes;
                                        foreach (XmlNode inner in node)
                                        {
                                            if (inner.Name == "UserID")
                                            {
                                                dataGridView1.Rows[Index].Cells[5].Value = inner.InnerText.TrimEnd().TrimStart();
                                            }
                                        }
                                    }
                                    else if (Outer.Name == "Title")
                                    {
                                        dataGridView1.Rows[Index].Cells[2].Value = Outer.InnerText.TrimEnd().TrimStart();
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    if (!string.IsNullOrEmpty(categoryID) && !string.IsNullOrEmpty(catName))
                    {
                        try
                        {
                            string categoryUrl = "http://www.ebay.com/sch/";
                            string[] cats = catName.Split(':');
                            dataGridView1.Rows[Index].Cells[4].Value = categoryUrl + cats[cats.Length - 1] + "/" + categoryID + "/i.html";
                        }
                        catch { }
                    }
                }
                catch
                {

                }
            }
            catch { }

        }
        private void browsercontrol_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[3].Enabled = false;
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                _filenameextrension = openFileDialog1.SafeFileName.ToLower().Substring(openFileDialog1.SafeFileName.Length - 4);
                if (result == DialogResult.OK) // Test result.
                {

                    fileuploadtxt.Text = openFileDialog1.FileName;
                    btnupload.Enabled = true;
                }
            }
            catch
            {
            }

        }

        private void tclogin_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            table.Columns.Add("imgerc", typeof(string));
            table.Columns.Add("localimg", typeof(string));
            lblprocessed.Visible = false;
            dataGridView2.Columns.Add("Rowid", "Rowid");
            dataGridView2.Columns.Add("Error", "Error");


            /**************Background worker****************************/

            m_AsyncWorker.WorkerReportsProgress = true;
            m_AsyncWorker.WorkerSupportsCancellation = true;
            m_AsyncWorker.ProgressChanged += new ProgressChangedEventHandler(bwAsync_ProgressChanged);
            m_AsyncWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwAsync_RunWorkerCompleted);
            m_AsyncWorker.DoWork += new DoWorkEventHandler(bwAsync_DoWork);
            m_AsyncWorker1.WorkerReportsProgress = true;
            m_AsyncWorker1.WorkerSupportsCancellation = true;
            m_AsyncWorker1.ProgressChanged += new ProgressChangedEventHandler(bwAsync1_ProgressChanged);
            m_AsyncWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwAsync1_RunWorkerCompleted);
            m_AsyncWorker1.DoWork += new DoWorkEventHandler(bwAsync1_DoWork);


            /**********************end******************************************************************/
            DisableControlpanel();

        }

        public void ReadCsv()
        {
            int counter = 0;
            StreamReader Reader = new StreamReader(_LocalFileName + "/DownloadFile.csv");
            while (!Reader.EndOfStream)
            {
                var line = Reader.ReadLine();
                var values = line.Split(',');
                if (counter > 0)
                {
                    _lsturl.Add(values[0]);

                }
                counter = counter + 1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Length > 0)
            {
                if (txtpassword.Text.Length > 0)
                {
                    if (_Username == txtusername.Text && txtpassword.Text == _Password)
                    {
                        MessageBox.Show("Login succesfull. Now we are going to next step.");
                        tabControl1.TabPages[0].Enabled = false;
                        tabControl1.TabPages[1].Enabled = true;
                        tabControl1.SelectedIndex = 1;
                        btnupload.Enabled = false;
                        btnnext.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid login details.");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter Password.");
                }
            }
            else
            {

                MessageBox.Show("Please enter Username");
            }
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                _LocalFileName = Application.StartupPath + "/Files/";
                _Filedate = DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "");
                _LocalFileName = _LocalFileName + _Filedate;
                Directory.CreateDirectory(_LocalFileName);
                if (File.Exists(_LocalFileName + "/DownloadFile.csv"))
                {
                    File.Delete(_LocalFileName + "/DownloadFile.csv");
                }
                File.Copy(openFileDialog1.FileName, _LocalFileName + "/DownloadFile.csv");
                MessageBox.Show("File upload suceesfully. Please click on next button to proceed further.");
                btnupload.Enabled = false;
                btnnext.Enabled = true;
            }
            catch
            {
                MessageBox.Show("OOPS there is some issue occured. Please try again after some time.");
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            lblwait.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            btngo.Enabled = true;
            button2.Enabled = false;
            btnpause.Enabled = false;
            btnexporttocsv.Enabled = false;
            _lsturl.Clear();
            ReadCsv();
            if (_lsturl.Count() > 0)
            {
                tabControl1.TabPages[1].Enabled = false;
                tabControl1.TabPages[2].Enabled = true;
                tabControl1.SelectedIndex = 2;

            }
            else
            {
                MessageBox.Show("File doesn't contain any url to crawl.Please upload valid file having urls.");
                btnnext.Enabled = false;
                btnupload.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lblwait.Visible = false;
            lblrecords.Visible = false;
            btngo.Enabled = true;
            lblprocessed.Visible = false;
            fileuploadtxt.Text = "";
            btnupload.Enabled = false;
            tabControl1.TabPages[1].Enabled = true;
            tabControl1.TabPages[3].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
            tabControl1.SelectedIndex = 1;
            btnnext.Enabled = false;
            btnupload.Enabled = false;
        }




        public void tim(int t)
        {
            time = 0;
            timer1.Start();
            try
            {
                while (time <= t)
                {

                    Application.DoEvents();
                }
            }
            catch (Exception) { }
            timer1.Stop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void btnpause_Click(object sender, EventArgs e)
        {
            if (btnpause.Text.ToUpper() == "PAUSE")//for pause and resume process
            {
                stop = true;
                btnpause.Text = "RESUME";
            }
            else
            {
                stop = false;
                btnpause.Text = "Pause";
            }
        }
        public class CsvFileWriter : StreamWriter //Writing  data to CSV
        {
            public CsvFileWriter(Stream stream)
                : base(stream)
            {
            }

            public CsvFileWriter(string filename)
                : base(filename)
            {
            }


            public void WriteRow(CsvRow row)
            {
                StringBuilder builder = new StringBuilder();
                bool firstColumn = true;
                foreach (string value in row)
                {
                    builder.Append("\"" + value.Replace("\n", "") + "\",");
                }
                row.LineText = builder.ToString();
                WriteLine(row.LineText);
            }
        }
        public DataTable GenerateTable()
        {
            DataTable exceldt = new DataTable();
            try
            {
                for (int m = 0; m < dataGridView1.Columns.Count; m++)
                {
                    exceldt.Columns.Add(dataGridView1.Columns[m].Name);

                }
                //Code to Export data to CSV
                for (int m = 0; m < dataGridView1.Rows.Count; m++)
                {
                    exceldt.Rows.Add();
                    for (int n = 0; n < dataGridView1.Columns.Count; n++)
                    {
                        if (dataGridView1.Rows[m].Cells[n].Value == null || dataGridView1.Rows[m].Cells[n].Value == DBNull.Value || String.IsNullOrEmpty(dataGridView1.Rows[m].Cells[n].Value.ToString()))
                            continue;
                        exceldt.Rows[m][n] = dataGridView1.Rows[m].Cells[n].Value.ToString();
                    }
                }
            }
            catch { }
            return exceldt;
        }

        private void btnexporttocsv_Click(object sender, EventArgs e)
        {

            try
            {
                using (CsvFileWriter writer = new CsvFileWriter(_LocalFileName + "/" + "data.csv"))
                {
                    CsvRow row = new CsvRow();//HEADER FOR CSV FILE
                    for (int m = 0; m < amzTable.Columns.Count; m++)
                    {
                        row.Add(amzTable.Columns[m].ColumnName);
                    }
                    for (int m = 0; m < ebayTable.Columns.Count; m++)
                    {
                        row.Add(ebayTable.Columns[m].ColumnName);
                    }
                    writer.WriteRow(row);//INSERT TO CSV FILE HEADER
                    if (amzTable.Rows.Count > 0 && ebayTable.Rows.Count > 0)
                    {
                        if (amzTable.Rows.Count > ebayTable.Rows.Count)
                        {
                            for (int m = 0; m < amzTable.Rows.Count - 1; m++)
                            {
                                CsvRow row1 = new CsvRow();
                                for (int n = 0; n < amzTable.Columns.Count; n++)
                                {
                                    row1.Add(String.Format("{0}", amzTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                                }
                                if (ebayTable.Rows.Count > m)
                                {
                                    for (int n = 0; n < ebayTable.Columns.Count; n++)
                                    {
                                        row1.Add(String.Format("{0}", ebayTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                                    }
                                }
                                else
                                {
                                    for (int n = 0; n < ebayTable.Columns.Count; n++)
                                    {
                                        row1.Add(String.Format("{0}", ""));
                                    }
                                }

                                writer.WriteRow(row1);
                            }
                        }
                        else
                        {
                            for (int m = 0; m < ebayTable.Rows.Count - 1; m++)
                            {
                                CsvRow row1 = new CsvRow();
                                if (amzTable.Rows.Count > m)
                                {
                                    for (int n = 0; n < amzTable.Columns.Count; n++)
                                    {
                                        row1.Add(String.Format("{0}", amzTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                                    }
                                }
                                else
                                {
                                    for (int n = 0; n < amzTable.Columns.Count; n++)
                                    {
                                        row1.Add(String.Format("{0}", ""));
                                    }
                                }
                                if (ebayTable.Rows.Count > m)
                                {
                                    for (int n = 0; n < ebayTable.Columns.Count; n++)
                                    {
                                        row1.Add(String.Format("{0}", ebayTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                                    }
                                }
                                writer.WriteRow(row1);
                            }


                        }
                    }
                    else
                    {
                        for (int m = 0; m < amzTable.Rows.Count - 1; m++)
                        {
                            CsvRow row1 = new CsvRow();
                            for (int n = 0; n < amzTable.Columns.Count; n++)
                            {
                                row1.Add(String.Format("{0}", amzTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                            }
                            writer.WriteRow(row1);
                        }
                        for (int m = 0; m < ebayTable.Rows.Count - 1; m++)
                        {
                            CsvRow row1 = new CsvRow();
                            for (int n = 0; n < ebayTable.Columns.Count; n++)
                            {
                                row1.Add(String.Format("{0}", ebayTable.Rows[m][n].ToString().Replace("\n", "").Replace("\r", "").Replace(",", " ")));
                            }
                            writer.WriteRow(row1);
                        }
                    }
                }
                System.Diagnostics.Process.Start(_LocalFileName + "/" + "data.csv");//OPEN THE CSV FILE ,,CSV FILE NAMED AS DATA.CSV
            }
            catch (Exception) { MessageBox.Show("file is already open\nclose the file"); }
            return;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
