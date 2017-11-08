using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace traco_opname
{
    public partial class Form_main : Form
    {
        //List<Kpoint> m_inset_pointlist = new List<Kpoint>();

        Component c = new Component();
        Job_def Next_Job;
        Gripperselecter m_gripperselector;
        IniFile mySettings;

        //inlezen via xml
        List<Bewerking> m_bewerkinglist = new List<Bewerking>();
        public List<Grippervariant> m_grippervariantlist = new List<Grippervariant>();

        public Form_main()
        {
            InitializeComponent();
        }

        public bool serialize(List<Bewerking> b, List<Grippervariant> g)
        {
            try
            {
                XmlSerializer x = new XmlSerializer(b.GetType());
                string path = Application.StartupPath + "//bewerkingen.xml";
                FileStream file = File.Create(path);
                x.Serialize(file, b);
                file.Close();

                x = new XmlSerializer(g.GetType());
                path = Application.StartupPath + "//grippervarianten.xml";
                file = File.Create(path);
                x.Serialize(file, g);
                file.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            deserialize();

            num_grippervariant.Maximum = m_grippervariantlist.Count-1;
            num_bewerking.Maximum = m_bewerkinglist.Count;
            //num_grippervariant.Minimum = 1;
            //num_bewerking.Minimum = 1;

            //num_grippervariant.Value = 1;
            //num_bewerking.Value = 1;

            mySettings = new IniFile(Application.StartupPath + "\\ODconfig.ini");
            m_gripperselector = new Gripperselecter(ref mySettings);
        }

        public void deserialize()
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(m_bewerkinglist.GetType());
            string path = Application.StartupPath + "//bewerkingen.xml";
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                m_bewerkinglist = (List<Bewerking>)x.Deserialize(reader);
            }

            x = new System.Xml.Serialization.XmlSerializer(m_grippervariantlist.GetType());
            path = Application.StartupPath + "//grippervarianten.xml";
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                m_grippervariantlist = (List<Grippervariant>)x.Deserialize(reader);
            }
        }

        private void btn_serialize_Click(object sender, EventArgs e)
        {
            List<Bewerking> b = new List<Bewerking>();
            b.Add(new Bewerking());

            List<Grippervariant> g = new List<Grippervariant>();
            g.Add(new Grippervariant());
            serialize(b, g);
        }

        private void num_grippervariant_ValueChanged(object sender, EventArgs e)
        {
            cb_oplossingtotaal.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].Oplossingtotaal;
            cb_oplossing1.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde1;
            cb_oplossing2.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde2;
            cb_oplossing3.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde3;
            cb_oplossing4.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde4;

            cb_oplossing12.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde12;
            cb_oplossing34.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde34;

            cb_oplossing123.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde123;
            cb_oplossing124.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde124;

            pg_grippervarianten.SelectedObject = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)];
            pb_opname.BackgroundImage = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].getopnamezone((int)c.Lengte, (int)c.Breedte, comboBox1.SelectedIndex, cb_grijper.Checked);
        }

        private void num_bewerking_ValueChanged(object sender, EventArgs e)
        {
            pg_bewerkingen.SelectedObject = m_bewerkinglist[Convert.ToInt32(num_bewerking.Value - 1)];
        }

        private void btn_xml_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd_file = new OpenFileDialog();
                DialogResult res = ofd_file.ShowDialog();
               
                if (res == DialogResult.OK)
                {
                    XmlSerializer x = new XmlSerializer(c.GetType());
                    string filename = ofd_file.FileName;// @"\\OPTISRV2012\Folder Redirection\stijn.pelgrims\Desktop\Traco\XML\ankergaten\FA Werkstück01.xml";// Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//IN.xml";
                    using (Stream reader = new FileStream(filename, FileMode.Open))
                    {
                        c = (Component)x.Deserialize(reader);
                    }
                }

                Verwerk();
                //Next_Job = new Job_def(c, ref m_gripperselector, ref mySettings);
                //pb_next.BackgroundImage = Next_Job.getpreview(0, 0);
            }
            catch (Exception ex)
            {
                //pb_next.BackgroundImage = null;
                //pb_next.BackColor = Color.Red;
            }
        }

        public int calc_distance(Point p1, Point p2)
        {
            double returner = 0;
            returner = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return Convert.ToInt32(returner);
        }
        private double distance_twopoints(Kpoint p1, Kpoint p2)
        {
            double temp = Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
            return temp;
        }


        public Rechte nieuwe_evenwijdige_rechte(Point p, Point pplus, int x1, int y1, int x2, int y2)//, int offset)
        {
            #region slechte zones

            double a2 = 0;
            double b2 = 0;
            double alpha = 0;
            double gamma = 0;
            double diagonaal = 0;
            double distance = 0;

            bool hor = false;
            bool ver = false;

            if (pplus.X != p.X)
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = -a2 * pplus.X + pplus.Y;
            }
            else
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = p.X;
            }

            //alpha berekenen
            alpha = (Math.Atan2(Math.Abs(pplus.X - p.X), Math.Abs(pplus.Y - p.Y))) * 180 / Math.PI;





            //double alphagamma = 0;


            //enkel als het halve grijper is en de bovenste zijde!!!!!!
            //if (b < 250 && (p.Y == pplus.Y && p.X > pplus.X))
            //{
            //    distance -= 25;
            //}
            #endregion

            double angle = Math.Abs(Math.Atan2((pplus.Y - p.Y), (pplus.X - p.X)));//* 180 / Math.PI; // hoek in radians
            double angle2 = angle * 180 / Math.PI;


            if (p.X < pplus.X && p.Y < pplus.Y)
            {
                //gamma berekenen
                gamma = (Math.Atan2(y2, x1)) * 180 / Math.PI;
                //diagonaal berekenen
                diagonaal = Math.Sqrt((x1 * x1) + (y2 * y2));
                //distance berekenen
                if (alpha + gamma < 90)
                {
                    //alphagamma = alpha + gamma;
                    //!!!!!!!!!!!!!!!!!
                    distance = diagonaal * Math.Sin((alpha + gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                else
                {
                    //alphagamma = alpha - gamma;

                    distance = diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                if (angle2 != 90)
                {
                    double costemp = Math.Cos(angle);
                    distance /= costemp;
                }

                b2 = b2 - distance;
            }
            if (p.X < pplus.X && p.Y > pplus.Y)
            {
                //gamma berekenen
                gamma = (Math.Atan2(y2, x2)) * 180 / Math.PI;
                //diagonaal berekenen
                diagonaal = Math.Sqrt((x2 * x2) + (y2 * y2));
                //distance berekenen
                if (alpha + gamma < 90)
                {
                    //alphagamma = alpha + gamma;
                    //!!!!!!!!!!!!!!!!!
                    distance = diagonaal * Math.Sin((alpha + gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                else
                {
                    //alphagamma = alpha - gamma;

                    distance = diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                if (angle2 != 90)
                {
                    double costemp = Math.Cos(angle);
                    distance /= costemp;
                }

                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y < pplus.Y)
            {
                //gamma berekenen
                gamma = (Math.Atan2(y1, x1)) * 180 / Math.PI;
                //diagonaal berekenen
                diagonaal = Math.Sqrt((x1 * x1) + (y1 * y1));
                //distance berekenen
                if (alpha + gamma < 90)
                {
                    //alphagamma = alpha + gamma;
                    //!!!!!!!!!!!!!!!!!
                    distance = diagonaal * Math.Sin((alpha + gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                else
                {
                    //alphagamma = alpha - gamma;

                    distance = diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                if (angle2 != 90)
                {
                    double costemp = Math.Cos(angle);
                    distance /= costemp;
                }
                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y > pplus.Y)
            {//gamma berekenen
                gamma = (Math.Atan2(y1, x2)) * 180 / Math.PI;
                //diagonaal berekenen
                diagonaal = Math.Sqrt((x2 * x2) + (y1 * y1));
                //distance berekenen
                if (alpha + gamma < 90)
                {
                    //alphagamma = alpha + gamma;
                    //!!!!!!!!!!!!!!!!!
                    distance = diagonaal * Math.Sin((alpha + gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                else
                {
                    //alphagamma = alpha - gamma;

                    distance = diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;
                }
                if (angle2 != 90)
                {
                    double costemp = Math.Cos(angle);
                    distance /= costemp;
                }
                b2 = b2 - distance;
            }

            if (p.X == pplus.X && p.Y > pplus.Y)
            {
                distance = x2;//diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;

                b2 = b2 - distance;
                ver = true;
            }

            if (p.X == pplus.X && p.Y < pplus.Y)
            {
                distance = x1;
                b2 = b2 - distance;
                ver = true;
            }

            if (p.X < pplus.X && p.Y == pplus.Y)
            {
                distance = y2;
                b2 = b2 - distance;
                hor = true;
            }

            if (p.X > pplus.X && p.Y == pplus.Y)
            {
                distance = y1;
                b2 = b2 - distance;
                hor = true;
            }

            //if (b2 * 100 < 0)
            //{ b2 = 0; }
            int richting = richting_bepalen(p, pplus);
            return new Rechte(a2, b2, hor, ver,richting);
        }

        public Rechte nieuwe_evenwijdige_rechte(Point pmin, Point p, Point pplus, int l, int b)//, int offset)
        {
            #region slechte zones
            double a1 = 0;
            double a2 = 0;
            double b1 = 0;
            double b2 = 0;
            double alpha = 0;
            double gamma = 0;
            double diagonaal = 0;
            double distance = 0;

            bool hor = false;
            bool ver = false;

            if (pmin.X != p.X)
            {
                a1 = (double)(pmin.Y - p.Y) / (double)(pmin.X - p.X);
                b1 = -a1 * pmin.X + pmin.Y;
            }
            else
            {
                a1 = (double)(pmin.Y - p.Y) / (double)(pmin.X - p.X);
                b1 = p.X;
            }

            if (pplus.X != p.X)
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = -a2 * pplus.X + pplus.Y;
            }
            else
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = p.X;
            }

            //alpha berekenen
            alpha = (Math.Atan2(Math.Abs(pplus.X - p.X), Math.Abs(pplus.Y - p.Y))) * 180 / Math.PI;
            //gamma berekenen
            gamma = (Math.Atan2(l, b)) * 180 / Math.PI;

            //diagonaal berekenen
            diagonaal = Math.Sqrt((l * l) + (b * b));
            //distance berekenen
            //double alphagamma = 0;
            if (alpha + gamma < 90)
            {
                //alphagamma = alpha + gamma;
                //!!!!!!!!!!!!!!!!!
                distance = diagonaal * Math.Sin((alpha + gamma) * Math.PI / 180);// *180 / Math.PI;
            }
            else
            {
                //alphagamma = alpha - gamma;

                distance = diagonaal * Math.Sin((180 - alpha - gamma) * Math.PI / 180);// *180 / Math.PI;
            }

            //enkel als het halve grijper is en de bovenste zijde!!!!!!
            //if (b < 250 && (p.Y == pplus.Y && p.X > pplus.X))
            //{
            //    distance -= 25;
            //}
            #endregion

            double angle = Math.Abs(Math.Atan2((pplus.Y - p.Y), (pplus.X - p.X)));//* 180 / Math.PI; // hoek in radians
            double angle2 = angle * 180 / Math.PI;
            if (angle2 != 90)
            {
                double costemp = Math.Cos(angle);
                distance /= costemp;
            }

            if (p.X < pplus.X && p.Y < pplus.Y)
            {
                b2 = b2 - distance;
            }
            if (p.X < pplus.X && p.Y > pplus.Y)
            {
                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y < pplus.Y)
            {//was +
                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y > pplus.Y)
            {//TEST was + maar mss moet ik abs gebruiken ofzo?
                b2 = b2 - distance;
            }

            if (p.X == pplus.X && p.Y > pplus.Y)
            {
                b2 = b2 - distance;
                ver = true;
            }

            if (p.X == pplus.X && p.Y < pplus.Y)
            {
                b2 = b2 + distance;
                ver = true;
            }

            if (p.X < pplus.X && p.Y == pplus.Y)
            {
                b2 = b2 - distance;
                hor = true;
            }

            if (p.X > pplus.X && p.Y == pplus.Y)
            {
                b2 = b2 - distance;
                hor = true;
            }

            //if (b2 * 100 < 0)
            //{ b2 = 0; }
            int richting = richting_bepalen(p, pplus);

            return new Rechte(a2, b2, hor, ver,richting);
        }
        public Rechte nieuwe_evenwijdige_rechte(Point pmin, Point p, Point pplus, double distance)
        {
            #region slechte zones
            double a1 = 0;
            double a2 = 0;
            double b1 = 0;
            double b2 = 0;

            bool hor = false;
            bool ver = false;

            if (pmin.X != p.X)
            {
                a1 = (double)(pmin.Y - p.Y) / (double)(pmin.X - p.X);
                b1 = -a1 * pmin.X + pmin.Y;
            }
            else
            {
                a1 = (double)(pmin.Y - p.Y) / (double)(pmin.X - p.X);
                b1 = p.X;
            }

            if (pplus.X != p.X)
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = -a2 * pplus.X + pplus.Y;
            }
            else
            {
                a2 = (double)(pplus.Y - p.Y) / (double)(pplus.X - p.X);
                b2 = p.X;
            }

            #endregion

            double angle = Math.Abs(Math.Atan2((pplus.Y - p.Y), (pplus.X - p.X)));//* 180 / Math.PI; // hoek in radians
            double angle2 = angle * 180 / Math.PI;
            if (angle2 != 90)
            {
                double costemp = Math.Cos(angle);
                distance /= costemp;
            }

            if (p.X < pplus.X && p.Y < pplus.Y)
            {
                b2 = b2 - distance;
            }
            if (p.X < pplus.X && p.Y > pplus.Y)
            {
                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y < pplus.Y)
            {//was + //ok nu
                b2 = b2 - distance;
            }
            if (p.X > pplus.X && p.Y > pplus.Y)
            {//was + maar ook bij andere functie zo gedaan
                b2 = b2 - distance;
            }

            if (p.X == pplus.X && p.Y > pplus.Y)
            {//ok
                b2 = b2 - distance;
                ver = true;
            }

            if (p.X == pplus.X && p.Y < pplus.Y)
            {//ok
                b2 = b2 + distance;
                ver = true;
            }

            if (p.X < pplus.X && p.Y == pplus.Y)
            {
                b2 = b2 - distance;
                hor = true;
            }

            if (p.X > pplus.X && p.Y == pplus.Y)
            {
                b2 = b2 - distance;
                hor = true;
            }

            //if (b2 * 100 < 0) { b2 = 0; }

            return new Rechte(a2, b2, hor, ver);
        }
        public Kpoint snijpunt(Rechte r1, Rechte r2)
        {
            double intersectX0 = -1;
            double intersectY0 = -1;
            //snijpunt 1 en 2

            if (r1.m_ishor && r2.m_ishor)
            {
                if (r1.m_b == r2.m_b)
                {
                    throw new Exception("liggen op elkaar, snijpunt=?");
                    //liggen op elkaar
                }
            }
            if (r1.m_isver && r2.m_isver)
            {
                if (r1.m_a == r2.m_a)
                {
                    throw new Exception("liggen op elkaar, snijpunt=?");
                    //liggen op elkaar
                }
            }

            if (r1.m_ishor == false && r1.m_isver == false && r2.m_ishor == false && r2.m_isver == false)
            {
                intersectX0 = (double)((r2.m_b - r1.m_b) / (r1.m_a - r2.m_a));
                intersectY0 = (r1.m_a * intersectX0) + r1.m_b;
            }
            else
            {
                if ((r1.m_ishor == true || r1.m_isver == true) || (r2.m_ishor == true || r2.m_isver == true))
                {
                    if (r1.m_ishor)
                    {
                        intersectY0 = r1.m_b;
                        if (r2.m_isver)
                        {
                            intersectX0 = r2.m_b;
                        }
                        else
                        {
                            intersectX0 = ((intersectY0 - r2.m_b) / r2.m_a); //ipv 1 //CHANGE
                        }

                    }
                    else if (r1.m_isver)
                    {
                        intersectX0 = r1.m_b;
                        if (r2.m_ishor)
                        {
                            intersectY0 = r2.m_b;
                        }
                        else
                        {
                            intersectY0 = r2.m_a * intersectX0 + r2.m_b;
                        }
                    }
                    else
                    {
                        if (r2.m_ishor)
                        {
                            intersectY0 = r2.m_b;
                            intersectX0 = (intersectY0 - r1.m_b) / r1.m_a; // (intersectY0 / r1.m_a) - r1.m_b;
                        }
                        else if (r2.m_isver)
                        {
                            intersectX0 = r2.m_b;
                            intersectY0 = r1.m_a * intersectX0 + r1.m_b;//(intersectY0 / r1.m_a) - r1.m_b;//
                        }
                        //
                    }
                }
            }
            //graphicsObj.FillEllipse(Brushes.Red, (int)intersectX0 - 10, (int)intersectY0 - 10, 20, 20);
            Kpoint preturn = new Kpoint(intersectX0, intersectY0, 0, -1);
            return preturn;
        }

        public bool evenwijdig(Rechte r1, Rechte r2)
        {
            if (r1.m_ishor && r2.m_ishor)
            {
               // if (r1.m_b == r2.m_b)
               // {
                    return true;
              //  }
            }
            if (r1.m_isver && r2.m_isver)
            {
              ////  if (r1.m_a == r2.m_a)
              ////  {
                    return true;
               // }
            }


            if (r1.m_a == r2.m_a)//(r1.m_b == r2.m_b) &&
            {
                return true;
            }

            return false;
        }

        public bool samenvallend(Rechte r1, Rechte r2)
        {
            if (r1.m_ishor && r2.m_ishor)
            {
                 if (r1.m_b == r2.m_b)
                 {
                return true;
                 }
            }
            if (r1.m_isver && r2.m_isver)
            {
                if (r1.m_a == r2.m_a)
                {
                return true;
                 }
            }


            if ((r1.m_b == r2.m_b) && (r1.m_a == r2.m_a))//
            {
                return true;
            }

            return false;
        }


        public bool puntinoppervlak(List<Kpoint> plist, Kpoint p, bool inoppoferbuiten)
        {
            //punt invullen in alle rechtes
            //resultaat 0 -> op de lijn
            //resultaat + of - -> boven onder de lijn die snijdt met de Yas en niet de andere zoals ik eerder dacht
            bool result = true;
            List<int> intlist = new List<int>();

            int i1 = 0;
            int i2 = 0;

            if (plist.Count == 0)
            {
                return false;
            }
            else if (plist.Count == 1)
            {
                if (plist[0].X == p.X && plist[0].Y == p.Y)
                {
                    //OK
                }
                else
                {
                    return false;
                }
            }
            else if (plist.Count == 2)
            {
                //hor
                if (plist[0].Y == plist[1].Y)
                {
                    if (p.Y != plist[0].Y)
                    {
                        return false;
                    }
                    if (plist[0].X < plist[1].X && (p.X < plist[0].X || p.X > plist[1].X))
                    {
                        return false;
                    }
                    if (plist[0].X > plist[1].X && (p.X > plist[0].X || p.X < plist[1].X))
                    {
                        return false;
                    }
                }
                else if (plist[0].X == plist[1].X)
                {
                    if (p.X != plist[0].X)
                    {
                        return false;
                    }
                    if (plist[0].Y < plist[1].Y && (p.Y < plist[0].Y || p.Y > plist[1].Y))
                    {
                        return false;
                    }
                    if (plist[0].Y > plist[1].Y && (p.Y > plist[0].Y || p.Y < plist[1].Y))
                    {
                        return false;
                    }
                }
                else
                { //algemene berekining
                    //rechte maken
                    Rechte r = new Rechte(plist[0], plist[1]);
                    //punt invullen en kijken of het op de rechte ligt
                    int c = Convert.ToInt32(r.m_a * (double)p.X + r.m_b - (double)p.Y);
                    if (c == 0)
                    {
                        //ligt het dan ook nog op het lijnstuk?
                        if (plist[0].X < plist[1].X && (p.X < plist[0].X || p.X > plist[1].X))
                        {
                            return false;
                        }
                        if (plist[0].X > plist[1].X && (p.X > plist[0].X || p.X < plist[1].X))
                        {
                            return false;
                        }

                        if (plist[0].Y < plist[1].Y && (p.Y < plist[0].Y || p.Y > plist[1].Y))
                        {
                            return false;
                        }
                        if (plist[0].Y > plist[1].Y && (p.Y > plist[0].Y || p.Y < plist[1].Y))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < plist.Count; ++i)
                {
                    i1 = i;
                    i2 = i1 + 1;

                    if (i2 == plist.Count)
                    {
                        i2 = 0;
                    }

                    result = puntlangsjuistekant(plist[i1], plist[i2], p);
                    if (result == false)
                    {
                        return false;
                    }

                }
            }
            return result;
        }
        public bool puntlangsjuistekant(Kpoint zijdep1, Kpoint zijdep2, Kpoint p)
        {
            //besproken met Pascal
            //speciale gevallen
            bool result = true;




            if (zijdep2.Y == zijdep1.Y)
            {
                if (zijdep2.X > zijdep1.X) //(5)
                {
                    if (zijdep2.Y < p.Y)
                    {
                        result = false;
                    }
                }
                if (zijdep2.X < zijdep1.X) //(6)
                {
                    if (zijdep2.Y > p.Y) ///CHANNNGGEEEE > is juist ??????
                    {
                        result = false;
                    }
                }
            }
            else if (zijdep2.X == zijdep1.X)
            {
                if (zijdep2.Y < zijdep1.Y)
                {
                    if (zijdep2.X < p.X)
                    {
                        result = false;
                    }
                }
                if (zijdep2.Y > zijdep1.Y)
                {
                    if (zijdep2.X > p.X)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                //bereken a
                //bereken b
                //bereken c
                double a = (double)(zijdep2.Y - zijdep1.Y) / (double)(zijdep2.X - zijdep1.X);
                double b = -a * zijdep1.X + zijdep1.Y;
                double c = a * p.X - p.Y + b;//double c = a * p.X + p.Y;


                if (zijdep2.X < zijdep1.X)
                {
                    if (zijdep2.Y < zijdep1.Y)
                    {//richting 3
                        if (c > 0)
                        {
                            result = false;
                        }
                    }
                    else
                    {//richting 5
                        if (c > 0)
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    if (zijdep2.Y < zijdep1.Y)
                    {
                        if (c < 0)
                        {//richting 1
                            result = false;
                        }
                    }
                    else
                    {
                        if (c < 0)
                        {//richting 7
                            result = false;
                        }
                    }
                }
            }



            return result;
        }
        public bool puntlangsjuistekant(Rechte zijde, Point p, int richting)
        {
            bool result = true;

            zijde.m_b = Convert.ToInt32(zijde.m_b);

            if (richting == 0 || richting == 4)
            {
                if (richting == 0)
                {
                    if (zijde.m_b < p.Y)
                    {
                        result = false;
                    }
                }
                if (richting == 4)
                {
                    if (zijde.m_b > p.Y)
                    {
                        result = false;
                    }
                }
            }
            else if (richting == 2 || richting == 6)
            {
                if (richting == 2)
                {
                    if (zijde.m_b < p.X)
                    {
                        result = false;
                    }
                }
                if (richting == 6)
                {
                    if (zijde.m_b > p.X)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                double a = (double)(zijde.m_a);
                double b = (double)(zijde.m_b);
                double c = a * p.X - p.Y + b;

                if (richting == 3 || richting == 5)
                {
                    if (richting == 3)
                    {
                        if (c > 0)
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (c > 0)
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    if (richting == 1 || richting == 7)
                    {
                        if (c < 0)
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (c < 0)
                        {
                            result = false;
                        }
                    }
                }
            }



            return result;
        }
        public void samenvallendepunte(ref List<Kpoint> plist)
        {
            List<int> dubbels = new List<int>();

            for (int i = 0; i < plist.Count; ++i)
            {
                int i1 = i;
                int i2 = i1 + 1;
                if (i2 == plist.Count) { i2 = 0; }

                //dist tussen 2 punten
                if (distance_twopoints(plist[i1], plist[i2]) < 2)
                {
                    dubbels.Add(i);
                }
            }

            if (dubbels.Count == plist.Count)
            {
                //speciaal geval, alle punten vallen samen
                for (int i = plist.Count - 1; i > 0; --i)
                {
                    plist.RemoveAt(i);
                }
            }
            else if (dubbels.Count > 0)
            {
                dubbels.Reverse();

                for (int i = 0; i < dubbels.Count; ++i)
                {
                    plist.RemoveAt(dubbels[i]);
                }
            }
        }
        private void mergepoints(ref List<Kpoint> plist, int foutpunt, ref List<Kpoint> geometrie)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;

            p1 = foutpunt;
            p2 = p1 + 1;

            if (p2 == geometrie.Count)
            {
                p2 = 0;
            }

            p3 = p2 + 1;

            if (p3 == geometrie.Count)
            {
                p3 = 0;
            }

            p4 = p3 + 1;

            if (p4 == geometrie.Count)
            {
                p4 = 0;
            }



            Kpoint np1 = plist[p1];
            Kpoint np2 = plist[p2];
            Kpoint np3 = plist[p3];
            Kpoint np4 = plist[p4];
            Rechte r1 = new Rechte(np1, np2);
            Rechte r2 = new Rechte(np3, np4);

            Kpoint newp = snijpunt(r1, r2);
            plist[p2] = newp;
            plist[p3] = newp;
        }
        public int richting_bepalen(Point p1, Point p2)
        {
            int richting = -1;
            //richting bepalen
            if (p1.X == p2.X)
            {
                if (p1.Y < p2.Y)
                {
                    richting = 6;
                }
                else
                {
                    richting = 2;
                }
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X < p2.X)
                {
                    richting = 0;
                }
                else
                {
                    richting = 4;
                }
            }
            else
            {
                if (p1.Y < p2.Y)
                {
                    if (p1.X < p2.X)
                    {
                        richting = 7;
                    }
                    else
                    {
                        richting = 5;
                    }
                }
                else
                {
                    if (p1.X < p2.X)
                    {
                        richting = 1;
                    }
                    else
                    {
                        richting = 3;
                    }
                }
            }

            return richting;
        }

        private void Verwerk()
        {

            lb_totaal.Items.Clear();
            lb_zijde1.Items.Clear();
            lb_zijde2.Items.Clear();
            lb_zijde3.Items.Clear();
            lb_zijde4.Items.Clear();
            lb_12.Items.Clear();
            lb_34.Items.Clear();
            lb_123.Items.Clear();
            lb_124.Items.Clear();
            lb_134.Items.Clear();
            lb_234.Items.Clear();

            #region SETUP
            #region variabelen
            List<Bewerking> Z1limieten = new List<Bewerking>();
            List<Bewerking> Z2limieten = new List<Bewerking>();
            List<Bewerking> Z3limieten = new List<Bewerking>();
            List<Bewerking> Z4limieten = new List<Bewerking>();
            List<int> ZoneTotaal_zijdeindex = new List<int>();
      List<int> ZoneZijde1_zijdeindex = new List<int>();
       List<int> ZoneZijde2_zijdeindex = new List<int>(); 
         List<int> ZoneZijde3_zijdeindex = new List<int>();
         List<int> ZoneZijde4_zijdeindex = new List<int>();

            double z1safedistmax = 0;
            double z2safedistmax = 0;
            double z3safedistmax = 0;
            double z4safedistmax = 0;

            int hoek1 = 0;
            int hoek2 = 0;
            int hoek3 = 0;
            int hoek4 = 0;
            int l11 = 0;
            int l11correctie = 0;
            int l12 = 0;
            int l21 = 0;
            int l21correctie = 0;
            int l22 = 0;
            int l31 = 0;
            int l31correctie = 0;
            int l32 = 0;
            int l41 = 0;
            int l41correctie = 0;
            int l42 = 0;
            #endregion
            #region algemene toekenning
            double m_lenght = Convert.ToDouble(c.Laenge.Replace(".", ","));
            double m_width = Convert.ToDouble(c.Breite.Replace(".", ","));
            double m_height = Convert.ToDouble(c.Dicke.Replace(".", ","));
            #endregion
            #region Z1
            if (c.Seite1.Wassernase() != null) { Z2limieten.Add(m_bewerkinglist[0]); }
            if (c.Seite1.Ausklinkung() != null) { Z2limieten.Add(m_bewerkinglist[1]); }
            if (c.Seite1.Fugenfalz() != null) { Z2limieten.Add(m_bewerkinglist[2]); }
            if (c.Seite1.Fase() != null) { Z2limieten.Add(m_bewerkinglist[3]); }
            if (c.Seite1.Ankergaten() != null) { Z2limieten.Add(m_bewerkinglist[4]); }
            if (c.Seite1.Kalibrierung() != null) { Z2limieten.Add(m_bewerkinglist[5]); }
            if (c.Seite1.Sichtkant_und_Fase() != null) { Z2limieten.Add(m_bewerkinglist[6]); }
            if (c.Seite1.Gehrungsschnitt() != null) { Z2limieten.Add(m_bewerkinglist[7]); }
            if (c.Seite1.Hinterschnittbohrung() != null) { Z2limieten.Add(m_bewerkinglist[8]); }
            if (c.Seite1.Schragschnitt() != null) { Z2limieten.Add(m_bewerkinglist[9]); }
            if (c.Seite1.Falldornbohrung() != null) { Z2limieten.Add(m_bewerkinglist[10]); }
            if (c.Seite1.geschliffene_Kante() != null) { Z2limieten.Add(m_bewerkinglist[11]); }
            #endregion
            #region Z2
            if (c.Seite2.Wassernase() != null) { Z3limieten.Add(m_bewerkinglist[0]); }
            if (c.Seite2.Ausklinkung() != null) { Z3limieten.Add(m_bewerkinglist[1]); }
            if (c.Seite2.Fugenfalz() != null) { Z3limieten.Add(m_bewerkinglist[2]); }
            if (c.Seite2.Fase() != null) { Z3limieten.Add(m_bewerkinglist[3]); }
            if (c.Seite2.Ankergaten() != null) { Z3limieten.Add(m_bewerkinglist[4]); }
            if (c.Seite2.Kalibrierung() != null) { Z3limieten.Add(m_bewerkinglist[5]); }
            if (c.Seite2.Sichtkant_und_Fase() != null) { Z3limieten.Add(m_bewerkinglist[6]); }
            if (c.Seite2.Gehrungsschnitt() != null) { Z3limieten.Add(m_bewerkinglist[7]); }
            if (c.Seite2.Hinterschnittbohrung() != null) { Z3limieten.Add(m_bewerkinglist[8]); }
            if (c.Seite2.Schragschnitt() != null) { Z3limieten.Add(m_bewerkinglist[9]); }
            if (c.Seite2.Falldornbohrung() != null) { Z3limieten.Add(m_bewerkinglist[10]); }
            if (c.Seite2.geschliffene_Kante() != null) { Z3limieten.Add(m_bewerkinglist[11]); }
            #endregion
            #region Z3
            if (c.Seite3.Wassernase() != null) { Z4limieten.Add(m_bewerkinglist[0]); }
            if (c.Seite3.Ausklinkung() != null) { Z4limieten.Add(m_bewerkinglist[1]); }
            if (c.Seite3.Fugenfalz() != null) { Z4limieten.Add(m_bewerkinglist[2]); }
            if (c.Seite3.Fase() != null) { Z4limieten.Add(m_bewerkinglist[3]); }
            if (c.Seite3.Ankergaten() != null) { Z4limieten.Add(m_bewerkinglist[4]); }
            if (c.Seite3.Kalibrierung() != null) { Z4limieten.Add(m_bewerkinglist[5]); }
            if (c.Seite3.Sichtkant_und_Fase() != null) { Z4limieten.Add(m_bewerkinglist[6]); }
            if (c.Seite3.Gehrungsschnitt() != null) { Z4limieten.Add(m_bewerkinglist[7]); }
            if (c.Seite3.Hinterschnittbohrung() != null) { Z4limieten.Add(m_bewerkinglist[8]); }
            if (c.Seite3.Schragschnitt() != null) { Z4limieten.Add(m_bewerkinglist[9]); }
            if (c.Seite3.Falldornbohrung() != null) { Z4limieten.Add(m_bewerkinglist[10]); }
            if (c.Seite3.geschliffene_Kante() != null) { Z4limieten.Add(m_bewerkinglist[11]); }
            #endregion
            #region Z4
            if (c.Seite4.Wassernase() != null) { Z1limieten.Add(m_bewerkinglist[0]); }
            if (c.Seite4.Ausklinkung() != null) { Z1limieten.Add(m_bewerkinglist[1]); }
            if (c.Seite4.Fugenfalz() != null) { Z1limieten.Add(m_bewerkinglist[2]); }
            if (c.Seite4.Fase() != null) { Z1limieten.Add(m_bewerkinglist[3]); }
            if (c.Seite4.Ankergaten() != null) { Z1limieten.Add(m_bewerkinglist[4]); }
            if (c.Seite4.Kalibrierung() != null) { Z1limieten.Add(m_bewerkinglist[5]); }
            if (c.Seite4.Sichtkant_und_Fase() != null) { Z1limieten.Add(m_bewerkinglist[6]); }
            if (c.Seite4.Gehrungsschnitt() != null) { Z1limieten.Add(m_bewerkinglist[7]); }
            if (c.Seite4.Hinterschnittbohrung() != null) { Z1limieten.Add(m_bewerkinglist[8]); }
            if (c.Seite4.Schragschnitt() != null) { Z1limieten.Add(m_bewerkinglist[9]); }
            if (c.Seite4.Falldornbohrung() != null) { Z1limieten.Add(m_bewerkinglist[10]); }
            if (c.Seite4.geschliffene_Kante() != null) { Z1limieten.Add(m_bewerkinglist[11]); }
            #endregion

            List<double> safedistmax = new List<double>();
            List<int> refzijdeindex = new List<int>();
            double safezaagdist = 50;

            #region de grootste safedist per zijde zoeken
            foreach (Bewerking z in Z1limieten)
            {
                if (z.Safedist > z1safedistmax) { z1safedistmax = z.Safedist; }
            }
            foreach (Bewerking z in Z2limieten)
            {
                if (z.Safedist > z2safedistmax) { z2safedistmax = z.Safedist; }
            }
            foreach (Bewerking z in Z3limieten)
            {
                if (z.Safedist > z3safedistmax) { z3safedistmax = z.Safedist; }
            }
            foreach (Bewerking z in Z4limieten)
            {
                if (z.Safedist > z4safedistmax) { z4safedistmax = z.Safedist; }
            }
            #endregion
            safedistmax.Add(z1safedistmax);
            safedistmax.Add(z2safedistmax);
            safedistmax.Add(z3safedistmax);
            safedistmax.Add(z4safedistmax);
            refzijdeindex.Add(1); refzijdeindex.Add(2); refzijdeindex.Add(3); refzijdeindex.Add(4);
           


            #region basis geometrie
            List<Kpoint> m_pointlist = new List<Kpoint>();
            double l = m_lenght / 2;
            double b = m_width / 2;
            m_pointlist.Clear();
            m_pointlist.Add(new Kpoint(-l, b, 0));//0
            m_pointlist.Add(new Kpoint(l, b, 0));
            m_pointlist.Add(new Kpoint(l, b, 0));
            m_pointlist.Add(new Kpoint(l, -b, 0));
            m_pointlist.Add(new Kpoint(l, -b, 0));
            m_pointlist.Add(new Kpoint(-l, -b, 0));
            m_pointlist.Add(new Kpoint(-l, -b, 0));
            m_pointlist.Add(new Kpoint(-l, b, 0));//1
            #endregion
            #region jobzijdes
            List<Zijde> m_zijdeslokaal = new List<Zijde>();
            //TODO:afwerking van een zijde
            int border = 1;
            int afsmusborder = 2;
            int afsborder = 3;
            int musborder = 22;
            int edgev = 11;
            int afs = 12;
            int edgea = 21;
            int corner = 4;
            bool afsmustoggle = false;
            Bearbeitung tempbearbeitung = new Bearbeitung();
            for (int i = 0; i < 4; ++i)// m_pointlist.Count
            {
                int i1 = i * 2;
                int i2 = (i + 1) * 2;
                if (i2 == m_pointlist.Count) { i2 = 0; }

                //int richting = richting_bepalen(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint());
                //TODO: richting klopt mss niet meer doordat er verstek is gezaagt VTB dus afw hangt niet helemaal af van enkel de richting maar ook van VBT
                m_zijdeslokaal.Add(new Zijde());
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Xstrt = m_pointlist[i1].Y;
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Xend = m_pointlist[i2].Y;
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Ystrt = m_pointlist[i1].X;
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Yend = m_pointlist[i2].X;

                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_lengte_a = calc_distance(new Point((int)m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Xstrt, (int)m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Ystrt), new Point((int)m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Xend, (int)m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_Yend));
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_lengte_b = 0;
                m_zijdeslokaal[m_zijdeslokaal.Count - 1].m_lengte_c = 0;
            }
            #endregion
            #region hoeken
            #region hoek1
            tempbearbeitung = c.Seite1.hoek();
            if (tempbearbeitung != null)
            {
                if (tempbearbeitung.Typ_Name == "Ausklinkung 2-seitig")
                {
                    hoek1 = 11;
                }
                else
                {
                    hoek1 = 1;
                }
                l11 = Convert.ToInt32(Convert.ToDouble(c.Seite1.Bearbeitung1.a1));//* 10
                l12 = Convert.ToInt32(Convert.ToDouble(c.Seite1.Bearbeitung1.a2));//* 10
            }
            else
            {
                hoek1 = 0;
                l11 = 0;
                l12 = 0;
            }
            #endregion
            #region hoek2
            tempbearbeitung = c.Seite2.hoek();
            if (tempbearbeitung != null)
            {
                if (tempbearbeitung.Typ_Name == "Ausklinkung 2-seitig")
                {
                    hoek2 = 12;
                }
                else
                {
                    hoek2 = 1;
                }
                l21 = Convert.ToInt32(Convert.ToDouble(c.Seite2.Bearbeitung1.b1));//* 10
                l22 = Convert.ToInt32(Convert.ToDouble(c.Seite2.Bearbeitung1.b2));//* 10
            }
            else
            {
                hoek2 = 0;
                l21 = 0;
                l22 = 0;
            }
            #endregion
            #region hoek3
            tempbearbeitung = c.Seite3.hoek();
            if (tempbearbeitung != null)
            {
                if (tempbearbeitung.Typ_Name == "Ausklinkung 2-seitig")
                {
                    hoek3 = 13;
                }
                else
                {
                    hoek3 = 1;
                }
                l31 = Convert.ToInt32(Convert.ToDouble(c.Seite3.Bearbeitung1.c1));//* 10
                l32 = Convert.ToInt32(Convert.ToDouble(c.Seite3.Bearbeitung1.c2));//* 10
            }
            else
            {
                hoek3 = 0;
                l31 = 0;
                l32 = 0;
            }
            #endregion
            #region hoek4
            tempbearbeitung = c.Seite4.hoek();
            if (tempbearbeitung != null)
            {
                if (tempbearbeitung.Typ_Name == "Ausklinkung 2-seitig")
                {
                    hoek4 = 14;
                }
                else
                {
                    hoek4 = 1;
                }
                l41 = Convert.ToInt32(Convert.ToDouble(c.Seite4.Bearbeitung1.d1));//* 10
                l42 = Convert.ToInt32(Convert.ToDouble(c.Seite4.Bearbeitung1.d2));//* 10
            }
            else
            {
                hoek4 = 0;
                l41 = 0;
                l42 = 0;
            }
            #endregion
            #endregion

            #region hoeken afzagen
            int tller = 0;
            if (hoek1 > 0)
            {
                //hoek 1 afkappen 
                //origineel
                tller++;
                safedistmax.Insert(tller, safezaagdist);
                refzijdeindex.Insert(tller, 1);
                m_pointlist[1] = new Kpoint(m_pointlist[1].X - l11, m_pointlist[1].Y, 1);
                m_pointlist[2] = new Kpoint(m_pointlist[2].X, m_pointlist[2].Y - l12, 0);//hoek1);
            }
            tller++;
            if (hoek2 > 0)
            {
                //hoek 2 afkappen 
                tller++;
                safedistmax.Insert(tller, safezaagdist);
                refzijdeindex.Insert(tller, 2);
                m_pointlist[3] = new Kpoint(m_pointlist[3].X, m_pointlist[3].Y + l22, 1);
                m_pointlist[4] = new Kpoint(m_pointlist[4].X - l21, m_pointlist[4].Y, 0);//hoek2);
            }
            tller++;
            if (hoek3 > 0)
            {
                //hoek 3 afkappen 
                tller++;
                safedistmax.Insert(tller, safezaagdist);
                refzijdeindex.Insert(tller, 3);
                m_pointlist[5] = new Kpoint(m_pointlist[5].X + l31, m_pointlist[5].Y, 1);
                m_pointlist[6] = new Kpoint(m_pointlist[6].X, m_pointlist[6].Y + l32, 0);//hoek3);
            }
            tller++;
            if (hoek4 > 0)
            {
                //hoek 4 afkappen 
                //origineel
                tller++;
                safedistmax.Insert(tller, safezaagdist);
                refzijdeindex.Insert(tller, 4);
                m_pointlist[7] = new Kpoint(m_pointlist[7].X, m_pointlist[7].Y - l42, 1);
                m_pointlist[0] = new Kpoint(m_pointlist[0].X + l41, m_pointlist[0].Y, 0);//hoek4);
            }
            //dubbels mergen
            List<int> dubbels = new List<int>();
            for (int i = 0; i < m_pointlist.Count; ++i)
            {
                int i1 = i;
                int i2 = i1 + 1;
                if (i2 == m_pointlist.Count) { i2 = 0; }

                if (m_pointlist[i1].X == m_pointlist[i2].X && m_pointlist[i1].Y == m_pointlist[i2].Y)
                {
                    dubbels.Add(i);
                }
            }

            if (dubbels.Count > 0)
            {

                dubbels.Reverse();

                for (int i = 0; i < dubbels.Count; ++i)
                {
                    m_pointlist.RemoveAt(dubbels[i]);
                }
            }

            if (m_pointlist.Count > 4)
            {
                //m_zijdes
                //zijdes toevoegen
                if (hoek4 > 0) { m_zijdeslokaal.Insert(4, new Zijde()); m_zijdeslokaal[4].m_zagen = hoek4; }
                if (hoek3 > 0) { m_zijdeslokaal.Insert(3, new Zijde()); m_zijdeslokaal[3].m_zagen = hoek3; }
                if (hoek2 > 0) { m_zijdeslokaal.Insert(2, new Zijde()); m_zijdeslokaal[2].m_zagen = hoek2; }
                if (hoek1 > 0) { m_zijdeslokaal.Insert(1, new Zijde()); m_zijdeslokaal[1].m_zagen = hoek1; }
            }
            for (int i = 0; i < m_pointlist.Count; ++i)
            {
                int i2 = i + 1;
                if (i2 == m_pointlist.Count) { i2 = 0; }
                //punt zelf
                m_zijdeslokaal[i].m_Xstrt = m_pointlist[i].Y;
                m_zijdeslokaal[i].m_Xend = m_pointlist[i2].Y;
                m_zijdeslokaal[i].m_Ystrt = m_pointlist[i].X;
                m_zijdeslokaal[i].m_Yend = m_pointlist[i2].X;
                m_zijdeslokaal[i].m_lengte_a = calc_distance(new Point((int)m_zijdeslokaal[i].m_Xstrt, (int)m_zijdeslokaal[i].m_Ystrt), new Point((int)m_zijdeslokaal[i].m_Xend, (int)m_zijdeslokaal[i].m_Yend));

                //disabled
                //m_zijdes[i].m_singzone = new SingZone(m_zijdes[m_zijdes.Count - 1], this);
            }
            #endregion
            #endregion

            List<Rechte> m_rechtelisttotaal = new List<Rechte>();
            List<Rechte> m_rechtelistzijde1 = new List<Rechte>();
            List<Rechte> m_rechtelistzijde2 = new List<Rechte>();
            List<Rechte> m_rechtelistzijde3 = new List<Rechte>();
            List<Rechte> m_rechtelistzijde4 = new List<Rechte>();

            //List<Rechte> m_rechtelistzijde12 = new List<Rechte>();
            //List<Rechte> m_rechtelistzijde34 = new List<Rechte>();

            List<Kpoint> safezonetotaal = new List<Kpoint>();
            List<Kpoint> safezonezijde1 = new List<Kpoint>();
            List<Kpoint> safezonezijde2 = new List<Kpoint>();
            List<Kpoint> safezonezijde3 = new List<Kpoint>();
            List<Kpoint> safezonezijde4 = new List<Kpoint>();

            List<Kpoint> result12 = new List<Kpoint>();

            List<int> m_totaalindex = new List<int>();
            List<int> m_zijde1index = new List<int>();
            List<int> m_zijde2index = new List<int>();
            List<int> m_zijde3index = new List<int>();
            List<int> m_zijde4index = new List<int>();

            List<int> m_zijde124index = new List<int>();
            List<int> m_zijde234index = new List<int>();
            List<int> m_zijde123index = new List<int>();
            List<int> m_zijde134index = new List<int>();

            List<int> m_zijde12index = new List<int>();
            List<int> m_zijde34index = new List<int>();

            //1 maal berekenen, is voor alle grippervarianten hetzelfde
            List<Kpoint> geometrie = new List<Kpoint>();

            for (int i = 0; i < m_pointlist.Count; ++i)
            {
                geometrie.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
                safezonetotaal.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
                safezonezijde1.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
                safezonezijde2.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
                safezonezijde3.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
                safezonezijde4.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y, 0));
            }

            #region safedist
            for (int i = 0; i < m_zijdeslokaal.Count; ++i)
            {
               //// if (
               //     (i == 0 && z1safedistmax > 0)
               //     ||
               //     (i == 1 && z2safedistmax > 0)
               //     ||
               //     (i == 2 && z3safedistmax > 0)
               //     ||
               //     (i == 3 && z4safedistmax > 0)
               //     )
                    if ( safedistmax[i] > 0)
                {

                    int i1 = i - 1;
                    if (i1 < 0) { i1 = m_pointlist.Count - 1; }
                    int i2 = i;
                    int i3 = i2 + 1;
                    if (i3 == m_pointlist.Count) { i3 = 0; }
                    int i4 = i3 + 1;
                    if (i4 == m_pointlist.Count) { i4 = 0; }

                    //if (m_zijdes[i].m_afsy != -1 && m_zijdes[i].m_afsz != -1)// gewone afs
                    //{
                    double waarde = 50;
                    //afhankelijk van de zijde
                     waarde = safedistmax[i];

                    Rechte r = nieuwe_evenwijdige_rechte(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint(), m_pointlist[i3].Converttopoint(), waarde);
                    Kpoint p1 = snijpunt(r, new Rechte(safezonetotaal[i2], safezonetotaal[i1]));
                    Kpoint p2 = snijpunt(r, new Rechte(safezonetotaal[i3], safezonetotaal[i4]));
                    safezonetotaal[i2] = new Kpoint(p1.X, p1.Y, 85);
                    safezonetotaal[i3] = new Kpoint(p2.X, p2.Y, 0);
                    p1 = snijpunt(r, new Rechte(geometrie[i2], geometrie[i1]));
                    p2 = snijpunt(r, new Rechte(geometrie[i3], geometrie[i4]));

                    double dist = distance_twopoints(p1, p2);


                    if (refzijdeindex[i] == 1) //if (i == 0)
                    {
                        p1 = snijpunt(r, new Rechte(safezonezijde1[i2], safezonezijde1[i1]));
                        p2 = snijpunt(r, new Rechte(safezonezijde1[i3], safezonezijde1[i4]));
                        safezonezijde1[i2] = new Kpoint(p1.X, p1.Y, 85);
                        safezonezijde1[i3] = new Kpoint(p2.X, p2.Y, 0);
                    }
                    if (refzijdeindex[i] == 2)//(i == 1)
                    {
                        p1 = snijpunt(r, new Rechte(safezonezijde2[i2], safezonezijde2[i1]));
                        p2 = snijpunt(r, new Rechte(safezonezijde2[i3], safezonezijde2[i4]));
                        safezonezijde2[i2] = new Kpoint(p1.X, p1.Y, 85);
                        safezonezijde2[i3] = new Kpoint(p2.X, p2.Y, 0);
                    }
                    if (refzijdeindex[i] == 3) //if (i == 2)
                    {
                        p1 = snijpunt(r, new Rechte(safezonezijde3[i2], safezonezijde3[i1]));
                        p2 = snijpunt(r, new Rechte(safezonezijde3[i3], safezonezijde3[i4]));
                        safezonezijde3[i2] = new Kpoint(p1.X, p1.Y, 85);
                        safezonezijde3[i3] = new Kpoint(p2.X, p2.Y, 0);
                    }
                    if (refzijdeindex[i] == 4) //if (i == 3)
                    {
                        p1 = snijpunt(r, new Rechte(safezonezijde4[i2], safezonezijde4[i1]));
                        p2 = snijpunt(r, new Rechte(safezonezijde4[i3], safezonezijde4[i4]));
                        safezonezijde4[i2] = new Kpoint(p1.X, p1.Y, 85);
                        safezonezijde4[i3] = new Kpoint(p2.X, p2.Y, 0);
                    }

                    m_zijdeslokaal[i].m_l = Convert.ToInt32(dist * (double)100);
                    m_zijdeslokaal[i].m_x = Convert.ToInt32(p2.X * (double)100);
                    m_zijdeslokaal[i].m_y = Convert.ToInt32(p2.Y * (double)100);
                    //}
                }
            }
            #endregion

            samenvallendepunte(ref safezonetotaal);
            samenvallendepunte(ref safezonezijde1);
            samenvallendepunte(ref safezonezijde2);
            samenvallendepunte(ref safezonezijde3);
            samenvallendepunte(ref safezonezijde4);

            ////zijde 1 steeds hardware grens
            safezonetotaal[0].zaagpunt = 85;
            safezonezijde1[0].zaagpunt = 85;

            #region grippervariant list verkleinen door gewichtrestricties
            //Steen
            double density = 0.0000025;
            double steen = (m_lenght * m_width * m_height);
            double gewicht = steen * density; //==>  kg/ mm³
            for (int i = m_grippervariantlist.Count - 1; i >= 0; --i)
            {
                //zuiger
                double zuiger_opp = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                double zuiger_kracht = 0.0030; //300kg maximaal voor robot
                double zuiger_maxgewicht = zuiger_opp * zuiger_kracht;

                if (
                    gewicht > zuiger_maxgewicht + 1
                    )
                {
                    m_grippervariantlist.RemoveAt(i);
                }
            }
            #endregion

            //vertaal de refzijdeindex in een lijst per zonevariant
            for (int i = 0; i < m_zijdeslokaal.Count; ++i)
            {
                if (refzijdeindex[i] == 1) //if (i == 3)
                {
                    ZoneTotaal_zijdeindex.Add(i);
                    ZoneZijde1_zijdeindex.Add(i);
                }
                if (refzijdeindex[i] == 2) //if (i == 3)
                {
                    ZoneTotaal_zijdeindex.Add(i);
                    ZoneZijde2_zijdeindex.Add(i);
                }
                if (refzijdeindex[i] == 3) //if (i == 3)
                {
                    ZoneTotaal_zijdeindex.Add(i);
                    ZoneZijde3_zijdeindex.Add(i);
                }
                if (refzijdeindex[i] == 4) //if (i == 3)
                { ZoneTotaal_zijdeindex.Add(i);
                ZoneZijde4_zijdeindex.Add(i);
                }

            }

            //Voor elke variant
            for (int g = 0; g < m_grippervariantlist.Count; ++g)
            {
                m_grippervariantlist[g].Reset();

                foreach (Kpoint k in safezonetotaal)
                {
                    m_grippervariantlist[g].SafeZoneTotaal.Add(new Kpoint(k.X, k.Y, k.zaagpunt));
                }
                foreach (Kpoint k in safezonezijde1)
                {
                    m_grippervariantlist[g].SafeZoneZijde1.Add(new Kpoint(k.X, k.Y, k.zaagpunt));
                }
                foreach (Kpoint k in safezonezijde2)
                {
                    m_grippervariantlist[g].SafeZoneZijde2.Add(new Kpoint(k.X, k.Y, k.zaagpunt));
                }
                foreach (Kpoint k in safezonezijde3)
                {
                    m_grippervariantlist[g].SafeZoneZijde3.Add(new Kpoint(k.X, k.Y, k.zaagpunt));
                }
                foreach (Kpoint k in safezonezijde4)
                {
                    m_grippervariantlist[g].SafeZoneZijde4.Add(new Kpoint(k.X, k.Y, k.zaagpunt));
                }

                m_rechtelisttotaal.Clear();
                m_rechtelistzijde1.Clear();
                m_rechtelistzijde2.Clear();
                m_rechtelistzijde3.Clear();
                m_rechtelistzijde4.Clear();

                //m_rechtelistzijde12.Clear();
                //m_rechtelistzijde34.Clear();

                #region inset punten bepalen
                #region per zijde bepalen hoeveel de grijper van de kant moet blijven
                int lg = m_grippervariantlist[g].Outer.Width / 2;//halve grijperlengte
                int bg = m_grippervariantlist[g].Outer.Height / 2;//halve grijperbreedtes
                //vanaf de safe zone totaal de grijperbeperking bepalen
                for (int i = 0; i < m_grippervariantlist[g].SafeZoneTotaal.Count; ++i)
                {
                    int j = 0;
                    Point pmin;
                    Point pplu;
                    Point pnul = m_grippervariantlist[g].SafeZoneTotaal[i].Converttopoint();
                    if (i == 0)
                    {
                        pmin = m_grippervariantlist[g].SafeZoneTotaal[m_grippervariantlist[g].SafeZoneTotaal.Count - 1].Converttopoint();
                    }
                    else
                    {
                        pmin = m_grippervariantlist[g].SafeZoneTotaal[i - 1].Converttopoint();
                    }
                    if (i == m_grippervariantlist[g].SafeZoneTotaal.Count - 1)
                    {
                        pplu = m_grippervariantlist[g].SafeZoneTotaal[0].Converttopoint();
                        j = 0;
                    }
                    else
                    {
                        pplu = m_grippervariantlist[g].SafeZoneTotaal[i + 1].Converttopoint();
                        j = i + 1;
                    }

                    if (m_grippervariantlist[g].SafeZoneTotaal[i].zaagpunt == 85)
                    {
                        m_rechtelisttotaal.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, Convert.ToInt32(lg), Convert.ToInt32(bg)));//, offset));
                    }
                    else
                    {
                        m_rechtelisttotaal.Add(nieuwe_evenwijdige_rechte(pnul, pplu, Convert.ToInt32(m_grippervariantlist[g].Inner.X), Convert.ToInt32(m_grippervariantlist[g].Inner.Y), Convert.ToInt32(m_grippervariantlist[g].Inner.X + m_grippervariantlist[g].Inner.Width), Convert.ToInt32((m_grippervariantlist[g].Inner.Y + m_grippervariantlist[g].Inner.Height))));//, offset));
                    }
                }
                for (int i = 0; i < m_grippervariantlist[g].SafeZoneZijde1.Count; ++i)
                {
                    int j = 0;
                    Point pmin;
                    Point pplu;
                    Point pnul = m_grippervariantlist[g].SafeZoneZijde1[i].Converttopoint();
                    if (i == 0)
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde1[m_grippervariantlist[g].SafeZoneZijde1.Count - 1].Converttopoint();
                    }
                    else
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde1[i - 1].Converttopoint();
                    }
                    if (i == m_grippervariantlist[g].SafeZoneZijde1.Count - 1)
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde1[0].Converttopoint();
                        j = 0;
                    }
                    else
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde1[i + 1].Converttopoint();
                        j = i + 1;
                    }

                    if (m_grippervariantlist[g].SafeZoneZijde1[i].zaagpunt == 85)
                    {
                        m_rechtelistzijde1.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, Convert.ToInt32(lg), Convert.ToInt32(bg)));//, offset));
                    }
                    else
                    {
                        m_rechtelistzijde1.Add(nieuwe_evenwijdige_rechte(pnul, pplu, Convert.ToInt32(m_grippervariantlist[g].Inner.X), Convert.ToInt32(m_grippervariantlist[g].Inner.Y), Convert.ToInt32(m_grippervariantlist[g].Inner.X + m_grippervariantlist[g].Inner.Width), Convert.ToInt32((m_grippervariantlist[g].Inner.Y + m_grippervariantlist[g].Inner.Height))));
                    }
                }
                for (int i = 0; i < m_grippervariantlist[g].SafeZoneZijde2.Count; ++i)
                {
                    int j = 0;
                    Point pmin;
                    Point pplu;
                    Point pnul = m_grippervariantlist[g].SafeZoneZijde2[i].Converttopoint();
                    if (i == 0)
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde2[m_grippervariantlist[g].SafeZoneZijde2.Count - 1].Converttopoint();
                    }
                    else
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde2[i - 1].Converttopoint();
                    }
                    if (i == m_grippervariantlist[g].SafeZoneZijde2.Count - 1)
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde2[0].Converttopoint(); j = 0;
                    }
                    else
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde2[i + 1].Converttopoint(); j = i + 1;
                    }

                    if (m_grippervariantlist[g].SafeZoneZijde2[i].zaagpunt == 85)
                    {
                        m_rechtelistzijde2.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, Convert.ToInt32(lg), Convert.ToInt32(bg)));//, offset));
                    }
                    else
                    {
                        m_rechtelistzijde2.Add(nieuwe_evenwijdige_rechte(pnul, pplu, Convert.ToInt32(m_grippervariantlist[g].Inner.X), Convert.ToInt32(m_grippervariantlist[g].Inner.Y), Convert.ToInt32(m_grippervariantlist[g].Inner.X + m_grippervariantlist[g].Inner.Width), Convert.ToInt32((m_grippervariantlist[g].Inner.Y + m_grippervariantlist[g].Inner.Height))));
                    }
                }
                for (int i = 0; i < m_grippervariantlist[g].SafeZoneZijde3.Count; ++i)
                {
                    int j = 0;
                    Point pmin;
                    Point pplu;
                    Point pnul = m_grippervariantlist[g].SafeZoneZijde3[i].Converttopoint();
                    if (i == 0)
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde3[m_grippervariantlist[g].SafeZoneZijde3.Count - 1].Converttopoint();
                    }
                    else
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde3[i - 1].Converttopoint();
                    }
                    if (i == m_grippervariantlist[g].SafeZoneZijde3.Count - 1)
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde3[0].Converttopoint(); j = 0;
                    }
                    else
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde3[i + 1].Converttopoint(); j = i + 1;
                    }

                    if (m_grippervariantlist[g].SafeZoneZijde3[i].zaagpunt == 85)
                    {
                        m_rechtelistzijde3.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, Convert.ToInt32(lg), Convert.ToInt32(bg)));//, offset));
                    }
                    else
                    {
                        m_rechtelistzijde3.Add(nieuwe_evenwijdige_rechte(pnul, pplu, Convert.ToInt32(m_grippervariantlist[g].Inner.X), Convert.ToInt32(m_grippervariantlist[g].Inner.Y), Convert.ToInt32(m_grippervariantlist[g].Inner.X + m_grippervariantlist[g].Inner.Width), Convert.ToInt32((m_grippervariantlist[g].Inner.Y + m_grippervariantlist[g].Inner.Height))));
                    }
                }
                for (int i = 0; i < m_grippervariantlist[g].SafeZoneZijde4.Count; ++i)
                {
                    int j = 0;
                    Point pmin;
                    Point pplu;
                    Point pnul = m_grippervariantlist[g].SafeZoneZijde4[i].Converttopoint();
                    if (i == 0)
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde4[m_grippervariantlist[g].SafeZoneZijde4.Count - 1].Converttopoint();
                    }
                    else
                    {
                        pmin = m_grippervariantlist[g].SafeZoneZijde4[i - 1].Converttopoint();
                    }
                    if (i == m_grippervariantlist[g].SafeZoneZijde4.Count - 1)
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde4[0].Converttopoint(); j = 0;
                    }
                    else
                    {
                        pplu = m_grippervariantlist[g].SafeZoneZijde4[i + 1].Converttopoint(); j = i + 1;
                    }
                    if (m_grippervariantlist[g].SafeZoneZijde4[i].zaagpunt == 85)
                    {
                        m_rechtelistzijde4.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, Convert.ToInt32(lg), Convert.ToInt32(bg)));//, offset));
                    }
                    else
                    {
                        m_rechtelistzijde4.Add(nieuwe_evenwijdige_rechte(pnul, pplu, Convert.ToInt32(m_grippervariantlist[g].Inner.X), Convert.ToInt32(m_grippervariantlist[g].Inner.Y), Convert.ToInt32(m_grippervariantlist[g].Inner.X + m_grippervariantlist[g].Inner.Width), Convert.ToInt32((m_grippervariantlist[g].Inner.Y + m_grippervariantlist[g].Inner.Height))));
                    }
                }
                #endregion

                #region opnamezone in grippervariant steken
                //bool stopnow = false;
                foreach (Kpoint k in safezonetotaal)
                {
                    m_grippervariantlist[g].OpnameZone.Add(new Kpoint(k.X, k.Y));
                }
                foreach (Kpoint k in safezonezijde1)
                {
                    m_grippervariantlist[g].OpnameZoneZijde1.Add(new Kpoint(k.X, k.Y));
                }
                foreach (Kpoint k in safezonezijde2)
                {
                    m_grippervariantlist[g].OpnameZoneZijde2.Add(new Kpoint(k.X, k.Y));
                }
                foreach (Kpoint k in safezonezijde3)
                {
                    m_grippervariantlist[g].OpnameZoneZijde3.Add(new Kpoint(k.X, k.Y));
                }
                foreach (Kpoint k in safezonezijde4)
                {
                    m_grippervariantlist[g].OpnameZoneZijde4.Add(new Kpoint(k.X, k.Y));
                }
                #endregion

                #region alles
                bool allesgechecked = false;
                bool bcontinue = false;
                int ind = 0;
                while (m_rechtelisttotaal.Count > 2 && allesgechecked == false)
                {
                    bcontinue = true;
                    ind = 0;

                    while (ind < m_rechtelisttotaal.Count && bcontinue) //m_grippervariantlist[g].OpnameZone
                    {
                        int r1 = ind;
                        int r2 = ind + 1;
                        int r3 = ind + 2;

                        if (r2 > m_rechtelisttotaal.Count - 1) { r2 -= m_rechtelisttotaal.Count; }
                        if (r3 > m_rechtelisttotaal.Count - 1) { r3 -= m_rechtelisttotaal.Count; }

                        if (m_rechtelisttotaal[r1].m_a != m_rechtelisttotaal[r2].m_a && m_rechtelisttotaal[r3].m_a != m_rechtelisttotaal[r2].m_a)
                        {
                            Kpoint p1 = snijpunt(m_rechtelisttotaal[r1], m_rechtelisttotaal[r2]);
                            Kpoint p2 = snijpunt(m_rechtelisttotaal[r2], m_rechtelisttotaal[r3]);

                            bool bp1 = puntlangsjuistekant(m_rechtelisttotaal[r3], p1.Converttopoint(), m_rechtelisttotaal[r3].m_richting);//m_grippervariantlist[g].OpnameZone[r1], m_grippervariantlist[g].OpnameZone[r2], p2);
                            bool bp2 = puntlangsjuistekant(m_rechtelisttotaal[r1], p2.Converttopoint(), m_rechtelisttotaal[r1].m_richting);//m_grippervariantlist[g].OpnameZone[r3], m_grippervariantlist[g].OpnameZone[r3], p1);

                            if (bp1 && bp2)
                            {
                                //alles ok
                                ++ind;

                            }
                            else
                            {
                                //middelste rechte verwijderen
                                m_rechtelisttotaal.RemoveAt(r2);
                                bcontinue = false;
                            }
                        }
                        else
                        {
                            m_rechtelisttotaal.RemoveAt(r2);
                            bcontinue = false;

                            //twee evenwijdige rechtes die op elkaar volgen, volgens mij geen oplossing meer mogelijk
                        }
                    }
                    if (ind == m_rechtelisttotaal.Count) { allesgechecked = true; }
                }

                m_grippervariantlist[g].OpnameZone.Clear();
                //snijpunten pakken en toevoegen

                if (m_rechtelisttotaal.Count > 2)
                {// en wat als er slechts twee rechtes overschieten??
                    for (int i = 0; i < m_rechtelisttotaal.Count; ++i)
                    {
                        int r1 = i;
                        int r2 = i + 1;

                        if (r2 > m_rechtelisttotaal.Count - 1) { r2 -= m_rechtelisttotaal.Count; }

                        Kpoint sp1 = snijpunt(m_rechtelisttotaal[r1], m_rechtelisttotaal[r2]);
                        m_grippervariantlist[g].OpnameZone.Add(sp1);
                    }
                }

                if (m_grippervariantlist[g].OpnameZone.Count > 0)
                {
                    m_grippervariantlist[g].Oplossingtotaal = true;
                    m_totaalindex.Add(g);
                }
                else
                {
                    m_grippervariantlist[g].Oplossingtotaal = false;
                }
                #endregion
                #region z1
                allesgechecked = false;
                bcontinue = false;
                ind = 0;
                while (m_rechtelistzijde1.Count > 2 && allesgechecked == false)
                {
                    bcontinue = true;
                    ind = 0;

                    while (ind < m_rechtelistzijde1.Count && bcontinue) //m_grippervariantlist[g].OpnameZone
                    {
                        int r1 = ind;
                        int r2 = ind + 1;
                        int r3 = ind + 2;

                        if (r2 > m_rechtelistzijde1.Count - 1) { r2 -= m_rechtelistzijde1.Count; }
                        if (r3 > m_rechtelistzijde1.Count - 1) { r3 -= m_rechtelistzijde1.Count; }
                        if (m_rechtelistzijde1[r1].m_a != m_rechtelistzijde1[r2].m_a && m_rechtelistzijde1[r3].m_a != m_rechtelistzijde1[r2].m_a)
                        {

                            Kpoint p1 = snijpunt(m_rechtelistzijde1[r1], m_rechtelistzijde1[r2]);
                            Kpoint p2 = snijpunt(m_rechtelistzijde1[r2], m_rechtelistzijde1[r3]);

                            bool bp1 = puntlangsjuistekant(m_rechtelistzijde1[r3], p1.Converttopoint(), m_rechtelistzijde1[r3].m_richting);//m_grippervariantlist[g].OpnameZone[r1], m_grippervariantlist[g].OpnameZone[r2], p2);
                            bool bp2 = puntlangsjuistekant(m_rechtelistzijde1[r1], p2.Converttopoint(), m_rechtelistzijde1[r1].m_richting);//m_grippervariantlist[g].OpnameZone[r3], m_grippervariantlist[g].OpnameZone[r3], p1);

                            if (bp1 && bp2)
                            {
                                //alles ok
                                ++ind;

                            }
                            else
                            {
                                //middelste rechte verwijderen
                                m_rechtelistzijde1.RemoveAt(r2);
                                bcontinue = false;
                            }
                        }
                        else
                        {
                            //twee evenwijdige rechtes die op elkaar volgen, volgens mij geen oplossing meer mogelijk
                            m_rechtelistzijde1.RemoveAt(r2);
                            bcontinue = false;

                        }
                    }
                    if (ind == m_rechtelistzijde1.Count) { allesgechecked = true; }
                }

                m_grippervariantlist[g].OpnameZoneZijde1.Clear();
                //snijpunten pakken en toevoegen
                if (m_rechtelistzijde1.Count > 2)
                {
                    for (int i = 0; i < m_rechtelistzijde1.Count; ++i)
                    {
                        int r1 = i;
                        int r2 = i + 1;

                        if (r2 > m_rechtelistzijde1.Count - 1) { r2 -= m_rechtelistzijde1.Count; }

                        Kpoint sp1 = snijpunt(m_rechtelistzijde1[r1], m_rechtelistzijde1[r2]);
                        m_grippervariantlist[g].OpnameZoneZijde1.Add(sp1);
                    }
                }

                if (m_grippervariantlist[g].OpnameZoneZijde1.Count > 0)
                {
                    m_grippervariantlist[g].OplossingZijde1 = true;
                    m_zijde1index.Add(g);
                }
                else
                {
                    m_grippervariantlist[g].OplossingZijde1 = false;
                }
                #endregion
                #region z2
                allesgechecked = false;
                bcontinue = false;
                ind = 0;
                while (m_rechtelistzijde2.Count > 2 && allesgechecked == false)
                {
                    bcontinue = true;
                    ind = 0;

                    while (ind < m_rechtelistzijde2.Count && bcontinue) //m_grippervariantlist[g].OpnameZone
                    {
                        int r1 = ind;
                        int r2 = ind + 1;
                        int r3 = ind + 2;

                        if (r2 > m_rechtelistzijde2.Count - 1) { r2 -= m_rechtelistzijde2.Count; }
                        if (r3 > m_rechtelistzijde2.Count - 1) { r3 -= m_rechtelistzijde2.Count; }
                        if (m_rechtelistzijde2[r1].m_a != m_rechtelistzijde2[r2].m_a && m_rechtelistzijde2[r3].m_a != m_rechtelistzijde2[r2].m_a)
                        {

                            Kpoint p1 = snijpunt(m_rechtelistzijde2[r1], m_rechtelistzijde2[r2]);
                            Kpoint p2 = snijpunt(m_rechtelistzijde2[r2], m_rechtelistzijde2[r3]);

                            bool bp1 = puntlangsjuistekant(m_rechtelistzijde2[r3], p1.Converttopoint(), m_rechtelistzijde2[r3].m_richting);//m_grippervariantlist[g].OpnameZone[r1], m_grippervariantlist[g].OpnameZone[r2], p2);
                            bool bp2 = puntlangsjuistekant(m_rechtelistzijde2[r1], p2.Converttopoint(), m_rechtelistzijde2[r1].m_richting);//m_grippervariantlist[g].OpnameZone[r3], m_grippervariantlist[g].OpnameZone[r3], p1);

                            if (bp1 && bp2)
                            {
                                //alles ok
                                ++ind;

                            }
                            else
                            {
                                //middelste rechte verwijderen
                                m_rechtelistzijde2.RemoveAt(r2);
                                bcontinue = false;
                            }
                        }
                        else
                        {
                            m_rechtelistzijde2.RemoveAt(r2);
                            bcontinue = false;

                            //twee evenwijdige rechtes die op elkaar volgen, volgens mij geen oplossing meer mogelijk
                        }
                    }
                    if (ind == m_rechtelistzijde2.Count) { allesgechecked = true; }
                }

                m_grippervariantlist[g].OpnameZoneZijde2.Clear();
                //snijpunten pakken en toevoegen
                if (m_rechtelistzijde2.Count > 2)
                {
                    for (int i = 0; i < m_rechtelistzijde2.Count; ++i)
                    {
                        int r1 = i;
                        int r2 = i + 1;

                        if (r2 > m_rechtelistzijde2.Count - 1) { r2 -= m_rechtelistzijde2.Count; }

                        Kpoint sp1 = snijpunt(m_rechtelistzijde2[r1], m_rechtelistzijde2[r2]);
                        m_grippervariantlist[g].OpnameZoneZijde2.Add(sp1);
                    }
                }
                if (m_grippervariantlist[g].OpnameZoneZijde2.Count > 0)
                {
                    m_grippervariantlist[g].OplossingZijde2 = true;
                    m_zijde2index.Add(g);
                }
                else
                {
                    m_grippervariantlist[g].OplossingZijde2 = false;
                }
                #endregion

                #region 1 en 2
                if (m_grippervariantlist[g].OplossingZijde1 && m_grippervariantlist[g].OplossingZijde2)
                {
                    if (g == 2)
                    {
                    }


                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde1, ref m_grippervariantlist[g].m_opnamezonezijde2, ref m_rechtelistzijde2, ref  m_grippervariantlist[g].m_opnamezonezijde12);
                    


                }

                if (m_grippervariantlist[g].OpnameZoneZijde12.Count > 0) { m_grippervariantlist[g].OplossingZijde12 = true; m_zijde12index.Add(g); }
                  //  }
                #endregion
                #region z3
                allesgechecked = false;
                bcontinue = false;
                ind = 0;
                while (m_rechtelistzijde3.Count > 2 && allesgechecked == false)
                {
                    bcontinue = true;
                    ind = 0;

                    while (ind < m_rechtelistzijde3.Count && bcontinue) //m_grippervariantlist[g].OpnameZone
                    {
                        int r1 = ind;
                        int r2 = ind + 1;
                        int r3 = ind + 2;
                        if (r2 > m_rechtelistzijde3.Count - 1) { r2 -= m_rechtelistzijde3.Count; }
                        if (r3 > m_rechtelistzijde3.Count - 1) { r3 -= m_rechtelistzijde3.Count; }


                        if (m_rechtelistzijde3[r1].m_a != m_rechtelistzijde3[r2].m_a && m_rechtelistzijde3[r3].m_a != m_rechtelistzijde3[r2].m_a)
                        {


                            Kpoint p1 = snijpunt(m_rechtelistzijde3[r1], m_rechtelistzijde3[r2]);
                            Kpoint p2 = snijpunt(m_rechtelistzijde3[r2], m_rechtelistzijde3[r3]);

                            bool bp1 = puntlangsjuistekant(m_rechtelistzijde3[r3], p1.Converttopoint(), m_rechtelistzijde3[r3].m_richting);//m_grippervariantlist[g].OpnameZone[r1], m_grippervariantlist[g].OpnameZone[r2], p2);
                            bool bp2 = puntlangsjuistekant(m_rechtelistzijde3[r1], p2.Converttopoint(), m_rechtelistzijde3[r1].m_richting);//m_grippervariantlist[g].OpnameZone[r3], m_grippervariantlist[g].OpnameZone[r3], p1);

                            if (bp1 && bp2)
                            {
                                //alles ok
                                ++ind;

                            }
                            else
                            {
                                //middelste rechte verwijderen
                                m_rechtelistzijde3.RemoveAt(r2);
                                bcontinue = false;
                            }
                        }
                        else
                        {
                            m_rechtelistzijde3.RemoveAt(r2);
                            bcontinue = false;

                            //twee evenwijdige rechtes die op elkaar volgen, volgens mij geen oplossing meer mogelijk
                        }
                    }
                    if (ind == m_rechtelistzijde3.Count) { allesgechecked = true; }
                }

                m_grippervariantlist[g].OpnameZoneZijde3.Clear();
                //snijpunten pakken en toevoegen
                if (m_rechtelistzijde3.Count > 2)
                {
                    for (int i = 0; i < m_rechtelistzijde3.Count; ++i)
                    {
                        int r1 = i;
                        int r2 = i + 1;

                        if (r2 > m_rechtelistzijde3.Count - 1) { r2 -= m_rechtelistzijde3.Count; }

                        Kpoint sp1 = snijpunt(m_rechtelistzijde3[r1], m_rechtelistzijde3[r2]);
                        m_grippervariantlist[g].OpnameZoneZijde3.Add(sp1);
                    }
                }

                if (m_grippervariantlist[g].OpnameZoneZijde3.Count > 0)
                {
                    m_grippervariantlist[g].OplossingZijde3 = true;
                    m_zijde3index.Add(g);
                }
                else
                {
                    m_grippervariantlist[g].OplossingZijde3 = false;
                }
                #endregion

                #region 1 en 2 en 3
                if (m_grippervariantlist[g].OplossingZijde1 && m_grippervariantlist[g].OplossingZijde2 && m_grippervariantlist[g].OplossingZijde3)
                {
                    if (g == 2)
                    {
                    }


                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde12, ref m_grippervariantlist[g].m_opnamezonezijde3, ref m_rechtelistzijde3, ref  m_grippervariantlist[g].m_opnamezonezijde123);



                }

                if (m_grippervariantlist[g].OpnameZoneZijde123.Count > 0) { m_grippervariantlist[g].OplossingZijde123 = true; m_zijde123index.Add(g); }
                //  }
                #endregion
               
               

                #region z4
                allesgechecked = false;
                bcontinue = false;
                ind = 0;
                while (m_rechtelistzijde4.Count > 2 && allesgechecked == false)
                {
                    bcontinue = true;
                    ind = 0;

                    while (ind < m_rechtelistzijde4.Count && bcontinue) //m_grippervariantlist[g].OpnameZone
                    {
                        int r1 = ind;
                        int r2 = ind + 1;
                        int r3 = ind + 2;

                        if (r2 > m_rechtelistzijde4.Count - 1) { r2 -= m_rechtelistzijde4.Count; }
                        if (r3 > m_rechtelistzijde4.Count - 1) { r3 -= m_rechtelistzijde4.Count; }
                        if (m_rechtelistzijde4[r1].m_a != m_rechtelistzijde4[r2].m_a && m_rechtelistzijde4[r3].m_a != m_rechtelistzijde4[r2].m_a)
                        {

                            Kpoint p1 = snijpunt(m_rechtelistzijde4[r1], m_rechtelistzijde4[r2]);
                            Kpoint p2 = snijpunt(m_rechtelistzijde4[r2], m_rechtelistzijde4[r3]);

                            bool bp1 = puntlangsjuistekant(m_rechtelistzijde4[r3], p1.Converttopoint(), m_rechtelistzijde4[r3].m_richting);//m_grippervariantlist[g].OpnameZone[r1], m_grippervariantlist[g].OpnameZone[r2], p2);
                            bool bp2 = puntlangsjuistekant(m_rechtelistzijde4[r1], p2.Converttopoint(), m_rechtelistzijde4[r1].m_richting);//m_grippervariantlist[g].OpnameZone[r3], m_grippervariantlist[g].OpnameZone[r3], p1);

                            if (bp1 && bp2)
                            {
                                //alles ok
                                ++ind;

                            }
                            else
                            {
                                //middelste rechte verwijderen
                                m_rechtelistzijde4.RemoveAt(r2);
                                bcontinue = false;
                            }
                        }
                        else
                        {
                            //twee evenwijdige rechtes die op elkaar volgen, volgens mij geen oplossing meer mogelijk
                            m_rechtelistzijde4.RemoveAt(r2);
                            bcontinue = false;


                        }
                    }
                    if (ind == m_rechtelistzijde4.Count) { allesgechecked = true; }
                }

                m_grippervariantlist[g].OpnameZoneZijde4.Clear();
                //snijpunten pakken en toevoegen
                if (m_rechtelistzijde4.Count > 2)
                {
                    for (int i = 0; i < m_rechtelistzijde4.Count; ++i)
                    {
                        int r1 = i;
                        int r2 = i + 1;

                        if (r2 > m_rechtelistzijde4.Count - 1) { r2 -= m_rechtelistzijde4.Count; }

                        Kpoint sp1 = snijpunt(m_rechtelistzijde4[r1], m_rechtelistzijde4[r2]);
                        m_grippervariantlist[g].OpnameZoneZijde4.Add(sp1);
                    }
                }
                if (m_grippervariantlist[g].OpnameZoneZijde4.Count > 0)
                {
                    m_grippervariantlist[g].OplossingZijde4 = true;
                    m_zijde4index.Add(g);
                }
                else
                {
                    m_grippervariantlist[g].OplossingZijde4 = false;
                }
                #endregion
                #region 1 en 2 en 4
                if (m_grippervariantlist[g].OplossingZijde1 && m_grippervariantlist[g].OplossingZijde2 && m_grippervariantlist[g].OplossingZijde4)
                {
                    if (g == 2)
                    {
                    }


                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde12, ref m_grippervariantlist[g].m_opnamezonezijde4, ref m_rechtelistzijde4, ref  m_grippervariantlist[g].m_opnamezonezijde124);



                }
                if (m_grippervariantlist[g].OpnameZoneZijde124.Count > 0) { m_grippervariantlist[g].OplossingZijde124 = true; m_zijde124index.Add(g); }
                //  }
                #endregion

                #region 3 en 4
                if (m_grippervariantlist[g].OplossingZijde3 && m_grippervariantlist[g].OplossingZijde4)
                {

              

                    //OPROEP DOORSNEDE FUNCTIE
                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde3, ref m_grippervariantlist[g].m_opnamezonezijde4, ref m_rechtelistzijde4, ref  m_grippervariantlist[g].m_opnamezonezijde34);
               
                    ////foreach (Kpoint k in m_grippervariantlist[g].OpnameZoneZijde3)
                    ////{
                    ////    m_grippervariantlist[g].OpnameZoneZijde34.Add(k);
                    ////}

                    ////for (int i = 0; i < m_rechtelistzijde4.Count; ++i)
                    ////{
                    ////    int i1 = i - 1;
                    ////    if (i1 < 0) { i1 = m_pointlist.Count - 1; }
                    ////    int i2 = i;
                    ////    int i3 = i2 + 1;
                    ////    if (i3 == m_pointlist.Count) { i3 = 0; }
                    ////    int i4 = i3 + 1;
                    ////    if (i4 == m_pointlist.Count) { i4 = 0; }


                    ////    Rechte r = m_rechtelistzijde4[i3];//WAAROM i3 ipv i

                    ////    Kpoint p1 = snijpunt(r, new Rechte(m_grippervariantlist[g].OpnameZoneZijde34[i2], m_grippervariantlist[g].OpnameZoneZijde34[i1]));
                    ////    Kpoint p2 = snijpunt(r, new Rechte(m_grippervariantlist[g].OpnameZoneZijde34[i3], m_grippervariantlist[g].OpnameZoneZijde34[i4]));

                    ////    bool bp1 = false;
                    ////    bool bp2 = false;
                    ////    try
                    ////    {
                    ////        bp1 = puntlangsjuistekant(r, p1.Converttopoint(), r.m_richting);
                    ////        bp2 = puntlangsjuistekant(r, p2.Converttopoint(), r.m_richting);
                    ////    }
                    ////    catch
                    ////    {
                    ////        //snijpunt kan error throwen als rechtes op elkaar liggen / evenwijdig zijn waardoor p1/p2 NaN waardes bevatten
                    ////    }

                    ////    if (bp1 && bp2)
                    ////    {
                    ////        m_grippervariantlist[g].OpnameZoneZijde34[i2] = new Kpoint(p1.X, p1.Y, 0);
                    ////        m_grippervariantlist[g].OpnameZoneZijde34[i3] = new Kpoint(p2.X, p2.Y, 0);
                    ////    }
                    ////    else
                    ////    {

                    ////    }
                    ////}
                    if (m_grippervariantlist[g].OpnameZoneZijde34.Count > 0) { m_grippervariantlist[g].OplossingZijde34 = true; m_zijde34index.Add(g); }
                }
                #endregion
                #region 1 en 3 en 4
                if (m_grippervariantlist[g].OplossingZijde1 && m_grippervariantlist[g].OplossingZijde3 && m_grippervariantlist[g].OplossingZijde4)
                {
                    if (g == 2)
                    {
                    }


                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde34, ref m_grippervariantlist[g].m_opnamezonezijde1, ref m_rechtelistzijde1, ref  m_grippervariantlist[g].m_opnamezonezijde134);



                }
                if (m_grippervariantlist[g].OpnameZoneZijde134.Count > 0) { m_grippervariantlist[g].OplossingZijde134 = true; m_zijde134index.Add(g); }
                //  }
                #endregion
                #region 2 en 3 en 4
                if (m_grippervariantlist[g].OplossingZijde2 && m_grippervariantlist[g].OplossingZijde3 && m_grippervariantlist[g].OplossingZijde4)
                {
                    if (g == 2)
                    {
                    }


                    doorsnede(ref m_grippervariantlist[g].m_opnamezonezijde34, ref m_grippervariantlist[g].m_opnamezonezijde2, ref m_rechtelistzijde2, ref  m_grippervariantlist[g].m_opnamezonezijde234);



                }
                if (m_grippervariantlist[g].OpnameZoneZijde234.Count > 0) { m_grippervariantlist[g].OplossingZijde234 = true; m_zijde234index.Add(g); }
                //  }
                #endregion

               
                #endregion

                //centrum van de zone bepalen (opnamepunt)
                if (m_grippervariantlist[g].Oplossingtotaal)
                {
                    double centerx = 0;
                    double centery = 0;
                    berekenopnamepunt(ref m_grippervariantlist[g].m_opnamezone, ref centerx, ref centery);
                    m_grippervariantlist[g].OpnamePoint = new Kpoint(centerx, centery);
                }
                if (m_grippervariantlist[g].OplossingZijde12)
                {
                    double centerx = 0;
                    double centery = 0;
                    berekenopnamepunt(ref m_grippervariantlist[g].m_opnamezonezijde12, ref centerx, ref centery);
                    m_grippervariantlist[g].OpnamePointZijde12 = new Kpoint(centerx, centery);
                }
                if (m_grippervariantlist[g].OplossingZijde34)
                {
                    double centerx = 0;
                    double centery = 0;
                    berekenopnamepunt(ref m_grippervariantlist[g].m_opnamezonezijde34, ref centerx, ref centery);
                    m_grippervariantlist[g].OpnamePointZijde34 = new Kpoint(centerx, centery);
                }
                if (m_grippervariantlist[g].OplossingZijde124)
                {
                    double centerx = 0;
                    double centery = 0;
                    berekenopnamepunt(ref m_grippervariantlist[g].m_opnamezonezijde124, ref centerx, ref centery);
                    m_grippervariantlist[g].OpnamePointZijde124 = new Kpoint(centerx, centery);
                }
                if (m_grippervariantlist[g].OplossingZijde123)
                {
                    double centerx = 0;
                    double centery = 0;
                    berekenopnamepunt(ref m_grippervariantlist[g].m_opnamezonezijde123, ref centerx, ref centery);
                    m_grippervariantlist[g].OpnamePointZijde123 = new Kpoint(centerx, centery);
                }
            }//hoort bij for lus over alle grijpervarianten heen

            #region weergeven resultaten listbox
            foreach (int i in m_totaalindex)
            {
                lb_totaal.Items.Add(i);
            }
            foreach (int i in m_zijde1index)
            {
                lb_zijde1.Items.Add(i);

                //bool ok13 = false;
                //bool ok14 = false;

                //foreach (int n in m_zijde3index)
                //{
                //    if (i == n) { ok13 = true; }
                //}
                //foreach (int k in m_zijde4index)
                //{
                //    if (i == k) { ok14 = true; }
                //}
                //if (ok13 && ok14) { m_zijde134index.Add(i); }
            }
            foreach (int i in m_zijde2index)
            {
                lb_zijde2.Items.Add(i);

                //bool ok12 = false;
                //bool ok23 = false;
                //bool ok24 = false;

                //foreach (int j in m_zijde1index)
                //{
                //    if (i == j) { ok12 = true; }
                //}
                //foreach (int n in m_zijde3index)
                //{
                //    if (i == n) { ok23 = true; }
                //}
                //foreach (int k in m_zijde4index)
                //{
                //    if (i == k) { ok24 = true; }
                //}
                //if (ok23 && ok24) { m_zijde234index.Add(i); }
                //if (ok12 && ok24) { m_zijde124index.Add(i); }
                //if (ok12 && ok23) { m_zijde123index.Add(i); }
                ////if (ok12) { m_zijde12index.Add(i); }
            }

            //foreach (int i in m_zijde3index)
            //{
            //    bool ok34 = false;

            //    foreach (int n in m_zijde4index)
            //    {
            //        if (i == n) { ok34 = true; }
            //    }
            //    if (ok34) { m_zijde34index.Add(i); }
            //}

            foreach (int i in m_zijde3index)
            {
                lb_zijde3.Items.Add(i);
            }
            foreach (int i in m_zijde4index)
            {
                lb_zijde4.Items.Add(i);
            }

            foreach (int i in m_zijde234index)
            {
                lb_234.Items.Add(i);
            }
            foreach (int i in m_zijde124index)
            {
                lb_124.Items.Add(i);
            }
            foreach (int i in m_zijde123index)
            {
                lb_123.Items.Add(i);
            }
            foreach (int i in m_zijde134index)
            {
                lb_134.Items.Add(i);
            }

            foreach (int i in m_zijde34index)
            {
                lb_34.Items.Add(i);
            }
            foreach (int i in m_zijde12index)
            {
                lb_12.Items.Add(i);
            }
            #endregion

            //beste oplossing bepalen
            Grippervariant m_oplossing1;
            Grippervariant m_oplossing2;

            int beste_index = -1;
            int beste_opp = -1;
            int beste_index12 = -1;
            int beste_opp12 = -1;
            int beste_index34 = -1;
            int beste_opp34 = -1;

            int beste_index123 = -1;
            int beste_opp123 = -1;

            int beste_index124 = -1;
            int beste_opp124 = -1;

            int beste_index3 = -1;
            int beste_opp3 = -1;

            int beste_index4 = -1;
            int beste_opp4 = -1;

            for (int i = 0; i < m_grippervariantlist.Count; ++i)
            {

                if (m_grippervariantlist[i].Oplossingtotaal)
                {
                    if (i == 0)
                    {
                        beste_index = 0;
                        beste_opp = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                    }
                    else
                    {
                        if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                        {
                            beste_index = i;
                            beste_opp = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                    }
                }
            }

            //20170921
            int oplossing = -1;

            if (beste_index == -1)
            {
                //geen totaaloplossing gevonden
                //zoeken naar oplossing12

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde123)
                    {
                        if (i == 0)
                        {
                            beste_index123 = 0;
                            beste_opp123 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index123 = i;
                                beste_opp123 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde4)
                    {
                        if (i == 0)
                        {
                            beste_index4 = 0;
                            beste_opp4 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index4 = i;
                                beste_opp4 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde124)
                    {
                        if (i == 0)
                        {
                            beste_index124 = 0;
                            beste_opp124 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index124 = i;
                                beste_opp124 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde3)
                    {
                        if (i == 0)
                        {
                            beste_index3 = 0;
                            beste_opp3 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index3 = i;
                                beste_opp3 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde12)
                    {
                        if (i == 0)
                        {
                            beste_index12 = 0;
                            beste_opp12 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index12 = i;
                                beste_opp12 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                for (int i = 0; i < m_grippervariantlist.Count; ++i)
                {
                    if (m_grippervariantlist[i].OplossingZijde12)
                    {
                        if (i == 0)
                        {
                            beste_index34 = 0;
                            beste_opp34 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                        }
                        else
                        {
                            if (beste_opp < m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height)
                            {
                                beste_index34 = i;
                                beste_opp34 = m_grippervariantlist[i].Inner.Width * m_grippervariantlist[i].Inner.Height;
                            }
                        }
                    }
                }

                if (beste_index124 != -1 && beste_index3 != -1)
                {
                    m_oplossing1 = m_grippervariantlist[beste_index124];
                    m_oplossing2 = m_grippervariantlist[beste_index3];
                    lbl_config1.Text = "Config1: " + beste_index124.ToString();
                    lbl_config2.Text = "Config2: " + beste_index3.ToString();
                    oplossing = 124;
                }
                else if (beste_index123 != -1 && beste_index4 != -1)
                {
                    m_oplossing1 = m_grippervariantlist[beste_index123];
                    m_oplossing2 = m_grippervariantlist[beste_index4];
                    lbl_config1.Text = "Config1: " + beste_index123.ToString();
                    lbl_config2.Text = "Config2: " + beste_index4.ToString();
                    oplossing = 123;
                }
                else if (beste_index12 != -1 && beste_index34 != -1)
                {
                    m_oplossing1 = m_grippervariantlist[beste_index12];
                    m_oplossing2 = m_grippervariantlist[beste_index34];
                    lbl_config1.Text = "Config1: " + beste_index12.ToString();
                    lbl_config2.Text = "Config2: " + beste_index34.ToString();
                    oplossing = 12;
                }
                else
                {
                    m_oplossing1 = null;
                    m_oplossing2 = null;
                    lbl_config1.Text = "Config1: /";
                    lbl_config2.Text = "Config2: /";
                    oplossing = -1;
                }
            }
            else
            {
                m_oplossing1 = m_grippervariantlist[beste_index];
                m_oplossing2 = m_grippervariantlist[beste_index];

                lbl_config1.Text = "Config1: " + beste_index.ToString();
                lbl_config2.Text = "Config2: " + beste_index.ToString();

                oplossing = 0;
            }

            //m_zijdeslokaal
            //refzijdeindex
            for (int i = 0; i < m_zijdeslokaal.Count; ++i)
            {
                switch (refzijdeindex[i])
                {
                    case 1:
                        m_zijdeslokaal[i].m_opnamenr = 1;
                        break;
                    case 2:
                        m_zijdeslokaal[i].m_opnamenr = 1;
                        break;
                    case 3:
                        if (oplossing == 123) { m_zijdeslokaal[i].m_opnamenr = 1; }
                        else if (oplossing == 124 || oplossing == 12) { m_zijdeslokaal[i].m_opnamenr = 2; }
                        break;
                    case 4:
                        if (oplossing == 124) { m_zijdeslokaal[i].m_opnamenr = 1; }
                        else if (oplossing == 123 || oplossing == 12) { m_zijdeslokaal[i].m_opnamenr = 2; }
                        break;
                }
            }

        }



        public void doorsnede(ref List<Kpoint> plist1, ref List<Kpoint> plist2, ref List<Rechte> rlist2, ref List<Kpoint> plistresult)
        {
            List<Kpoint> locallist= new List<Kpoint>();
            List<Kpoint> localresult = new List<Kpoint>();
            foreach (Kpoint k in plist1)
            {//kopieren zone1 in de oplossing
                locallist.Add(k);
            }
            bool localresultcalculated = false;
            //pas zone12 aan rekening houdende met recht1 van zone2
            for (int i = 0; i < rlist2.Count; ++i) //voor elke rechte van zone2
            {
                int i1 = i + 1;
                if (i1 == rlist2.Count)
                {
                    i1 = 0;// m_pointlist.Count - 1; 
                }

                //   int i4 = i3 + 1;
                // if (i4 == m_pointlist.Count) { i4 = 0; }

                Rechte r = rlist2[i1];//WAAROM i3 ipv i
                //bereken de snijpunten met elklijnstuk van zone1 (dit kunnen er 0 zijn of 2)
                int snijpuntteller = 0;
                localresultcalculated = false;
                Kpoint snijpunt1 = new Kpoint(0, 0, 0);
                Kpoint snijpunt2 = new Kpoint(0, 0, 0);
                int snijindex1 = 0;
                int snijindex2 = 0;
                for (int j = 0; j < locallist.Count; ++j) //voor elke rechte van zone2
                {//snijpunt met elke zone berekenen maar enkel die overhouden die binnen de ljnstukken liggen
                    int i2 = j;
                    int i3 = i2 + 1;
                    if (i3 == locallist.Count) { i3 = 0; }


                    if (!evenwijdig(r, new Rechte(locallist[i2], locallist[i3])))
                    {
                        Kpoint p1 = snijpunt(r, new Rechte(locallist[i2], locallist[i3]));
                        if (((p1.X <= locallist[i2].X && p1.X >= locallist[i3].X) || (p1.X >= locallist[i2].X && p1.X <= locallist[i3].X))
                        && ((p1.Y <= locallist[i2].Y && p1.Y >= locallist[i3].Y) || (p1.Y >= locallist[i2].Y && p1.Y <= locallist[i3].Y))
                        )
                        {
                            if (snijpuntteller == 1) { snijpuntteller++; snijpunt2 = p1; snijindex2 = j; }
                            if (snijpuntteller == 0) { snijpuntteller++; snijpunt1 = p1; snijindex1 = j; }
                        }
                    }
                }
                localresult.Clear();
                if (snijpuntteller == 2)
                {// enkel die afkappingen doen waarbij een van de twee snijpunten ligt tussen begi n en eind punt van zone 2 linstuk liggen

                    if ((((snijpunt1.X <= plist2[i].X && snijpunt1.X >= plist2[i1].X) || (snijpunt1.X >= plist2[i].X && snijpunt1.X <= plist2[i1].X))
                             && ((snijpunt1.Y <= plist2[i].Y && snijpunt1.Y >= plist2[i1].Y) || (snijpunt1.Y >= plist2[i].Y && snijpunt1.Y <= plist2[i1].Y)))
                        || (((snijpunt2.X <= plist2[i].X && snijpunt2.X >= plist2[i1].X) || (snijpunt2.X >= plist2[i].X && snijpunt2.X <= plist2[i1].X))
                             && ((snijpunt2.Y <= plist2[i].Y && snijpunt2.Y >= plist2[i1].Y) || (snijpunt2.Y >= plist2[i].Y && snijpunt2.Y <= plist2[i1].Y))))
                    {// snijpunt 1  of 2 ligt er binnen opnamezone 2, dus afsnijden
                        localresultcalculated = true;
                        //Zone12 verkleinen aan de hand van die 2 snijpunten
                        for (int j = 0; j < locallist.Count; ++j)
                        {
                            Kpoint p1 = new Kpoint(locallist[j].X, locallist[j].Y, 0);
                            bool bp1 = false;

                            bp1 = puntlangsjuistekant(r, p1.Converttopoint(), r.m_richting);

                            if (bp1)
                            {
                                localresult.Add(p1);
                                if (j == snijindex1 && !(snijpunt1.X == p1.X && snijpunt1.Y == p1.Y)) localresult.Add(snijpunt1);//
                                if (j == snijindex2 && !(snijpunt2.X == p1.X && snijpunt2.Y == p1.Y)) localresult.Add(snijpunt2);//
                            }
                            else
                            {
                                if (j == snijindex1) localresult.Add(snijpunt1);
                                if (j == snijindex2) localresult.Add(snijpunt2);

                            }
                        }
                    }
                }
                if (localresultcalculated) 
                {

                samenvallendepunte(ref localresult);

                //    kopieer ocalresult in locallist en kijk naar volgende rechte indien er twee geldige snijpunten waren
                locallist.Clear();
                foreach (Kpoint k in localresult)
                {//kopieren zone1 in de oplossing
                    locallist.Add(k);
                }
                }


            }
            plistresult.Clear();
            foreach (Kpoint k in locallist)
            {//kopieren zone1 in de oplossing
                plistresult.Add(k);
            }
           
            //kopieer localresult in listresult
        }


        public void berekenopnamepunt(ref List<Kpoint> zone, ref double px, ref double py)
        {
            if (puntinoppervlak(zone, new Kpoint(0, 0), true))
            {
                px = 0;
                py = 0;
            }
            else
            {
                double somx = 0;
                double somy = 0;
                int aantal = 0;
                foreach (Kpoint k in zone)
                {
                    //kopieren zone1 in de oplossing
                    somx += k.X;
                    somy += k.Y;
                    aantal++;
                }
                px = somx / aantal;
                py = somy / aantal;
            }
        }        //private 
            
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_oplossingtotaal.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].Oplossingtotaal;
            cb_oplossing1.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde1;
            cb_oplossing2.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde2;
            cb_oplossing3.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde3;
            cb_oplossing4.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde4;

            cb_oplossing12.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde12;
            cb_oplossing34.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde34;

            cb_oplossing123.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde123;
            cb_oplossing124.Checked = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].OplossingZijde124;


            pb_opname.BackgroundImage = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].getopnamezone((int)c.Lengte, (int)c.Breedte, comboBox1.SelectedIndex, cb_grijper.Checked);
        }

        private void cb_grijper_CheckedChanged(object sender, EventArgs e)
        {
            pb_opname.BackgroundImage = m_grippervariantlist[Convert.ToInt32(num_grippervariant.Value)].getopnamezone((int)c.Lengte, (int)c.Breedte, comboBox1.SelectedIndex, cb_grijper.Checked);
        }
    }
}
 