using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Wpfsoustitre
{
    class Tri
    {
        public List<Subtitle> subi;

        public Tri(TextBlock T)
        {
          
            subi = Stock();
            Task t = Affichage(subi,T);
        }

        public List<Subtitle> Stock()
        {
            
            List<Subtitle> subs = new List<Subtitle>();
            Regex regex2 = new Regex("^[0-9]{1,}$");
            Regex regex = new Regex("-->");
            using (StreamReader sr = new StreamReader(@"C:\Users\Antoine\Desktop\INGESUP\cours\C#\Fellowship.Of.The.Ring.2001.EC.BluRay.1080p.10bit.6.1.x265.HEVC-Qman.FR.srt"))
            {

                string lineq = "";
                string line;
                string[] lines = new string[2];
                while ((line = sr.ReadLine()) != null)
                {


                    if (regex2.Match(line).Success)
                        continue;
                    else if (regex.Match(line).Success)
                    {

                        string[] stringSeparators = new string[] { "-->" };
                        lines = line.Split(stringSeparators, 2, StringSplitOptions.None);

                    }
                    else
                    {
                        if (line.Length != 0)
                        {
                            lineq += line + "\n";

                        }
                        else
                        {
                            subs.Add(new Subtitle(lineq, lines[0], lines[1]));
                            lineq = "";
                        }
                    }
                }
            }
            return subs;
        }

        public async Task Affichage(List<Subtitle> subs,TextBlock T)
        {
            await Task.Delay((int)subs[0].TimeStart.TotalMilliseconds);
            T.Text = subs[0].subt;
            await Task.Delay((int)subs[0].TimeEnd.TotalMilliseconds - (int)subs[0].TimeStart.TotalMilliseconds);
            T.Text = "";
            for (int i = 1; i < subs.Count; i++)
            {
                await Task.Delay((int)subs[i].TimeStart.TotalMilliseconds - (int)subs[i - 1].TimeEnd.TotalMilliseconds);
                T.Text = (subs[i].subt);
                await Task.Delay((int)subs[i].TimeEnd.TotalMilliseconds - (int)subs[i].TimeStart.TotalMilliseconds);
               T.Text = "";
            }
        }
    }
}
