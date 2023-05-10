using amanydb.classes;

namespace amanydb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists("record.csv"))
            {
                File.Create("record.csv").Close() ;
            }
            if (!File.Exists("files.csv"))
            {
                File.Create("files.csv").Close();
            }
            if (!File.Exists("order.txt"))
            {
                File.Create("order.txt").Close();
            }
            if (!File.Exists("sentrecord.txt"))
            {
                File.Create("sentrecord.txt").Close();
            }
            if (!File.Exists("sentfiles.txt"))
            {
                File.Create("sentfiles.txt").Close();
            }
            if (!File.Exists("id.txt"))
            {
                File.Create("id.txt").Close();
            }
            if (!File.Exists("orderid.txt"))
            {
                File.Create("orderid.txt").Close();
            }
            if (!File.Exists("orderidrecieved.txt"))
            {
                File.Create("orderidrecieved.txt").Close();
            }

        }
        string oldorder = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                oldorder = File.ReadAllText("orderidrecieved.txt");
                var k = File.ReadAllText("orderid.txt");
                if(oldorder!= k)
                {
                    oldorder= k;
                }
                else
                {
                    return;
                }
                var mydb = new db();
                var records = mydb.searchrecord.ToList();
                fill_records(records);
                var order = File.ReadAllText("order.txt");
                if (order != "save")
                {
                    try
                    {
                        var id = Convert.ToInt32(order);
                        var files = mydb.file.Where(i => i.record.id == id).ToList();
                        fill_files(files);
                    }
                    catch { }
                }
                else
                {
                    var rec = File.ReadAllText("sentrecord.txt");
                    var t = rec.Split(";");
                    Searchrecord sr=new Searchrecord();
                    sr.time = DateTime.Now;
                    sr.word= t[0];
                    mydb.searchrecord.Add(sr);
                    mydb.SaveChanges();
                    mydb=new db();
                    var record = mydb.searchrecord.FirstOrDefault(i => i.time == sr.time);
                    if (record != null)
                    {
                        List<file> files = new List<file>();
                        var fs = File.ReadLines("sentfiles.txt");
                        foreach (var line in fs)
                        {
                            var ss = line.Split(";");
                            file f=new file();
                            f.record = record;
                            f.name = ss[0];
                            mydb.file.Add(f);
                            files.Add(f);
                        }
                        mydb.SaveChanges();
                    }
                }
                Random rd=new Random();
                var s=rd.Next(int.MaxValue/2, int.MaxValue);
                File.WriteAllText("id.txt", s + "");
                File.WriteAllText("orderidrecieved.txt", oldorder);
            }
            catch { }
        }
        void fill_records(List< Searchrecord> records)
        {
            
            string s = "";
            var db=new db();
            foreach(var r in records)
            {
                var c=db.file.Where(i=>i.record.id==r.id).ToList();
                s += $"{r.id};{r.time.ToString("yyyy-MM-dd HH:mm:ss")};{r.word};{c.Count};\r\n";
            }
            File.WriteAllText("record.csv", s);
        }
        void fill_files(List<file> files)
        {
            string s = "";
            foreach (var r in files)
            {
                s += $"{r.id};{r.name};\r\n";
            }
            File.WriteAllText("files.csv", s);
        }
    }
}