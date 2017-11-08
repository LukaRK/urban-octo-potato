using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace traco_opname
{
    public class Bewerking
    {
        #region safedist
        double m_safedist = 0;
        public double Safedist
        {
            get
            {
                return m_safedist;
            }
            set
            {
                m_safedist = value;
            }
        }
        #endregion
        #region singzone_min
        double m_singzone_min = 0;
        public double Singzone_min
        {
            get
            {
                return m_singzone_min;
            }
            set
            {
                m_singzone_min = value;
            }
        }
        #endregion
        #region singzone_max
        double m_singzone_max = 0;
        public double Singzone_max
        {
            get
            {
                return m_singzone_max;
            }
            set
            {
                m_singzone_max = value;
            }
        }
        #endregion
        #region naam
        string m_naam = "bewerking";
        public string Naam
        {
            get
            {
                return m_naam;
            }
            set
            {
                m_naam = value;
            }
        }
        #endregion

        public Bewerking()
        {
            
        }
        public Bewerking(Bewerking b)
        {
            m_safedist = b.m_safedist;
            m_singzone_max = b.m_singzone_max;
            m_singzone_min = b.m_singzone_min;
            m_naam = b.m_naam;
        }
    }
    public class Grippervariant
    {

      
        #region toolnr
        double m_toolnr = 0;
        public double Toolnr
        {
            get
            {
                return m_toolnr;
            }
            set
            {
                m_toolnr = value;
            }
        }
        #endregion     



        #region Outer
        Rectangle m_outer = new Rectangle(0,0,0,0);
        public Rectangle Outer
        {
            get
            {
                return m_outer;
            }
            set
            {
                m_outer = value;
            }
        }
        #endregion
        #region Inner
        Rectangle m_inner = new Rectangle(0, 0, 0, 0);
        public Rectangle Inner
        {
            get
            {
                return m_inner;
            }
            set
            {
                m_inner = value;
            }
        }
        #endregion
        #region OpnameZone
        public List<Kpoint> m_opnamezone = new List<Kpoint>();
        public List<Kpoint> OpnameZone
        {
            get
            {
                return m_opnamezone;
            }
            set
            {
                m_opnamezone = value;
            }
        }
        public List<Point> OpnameZonePoints
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezone)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {
                
            }
        }
        #endregion
        #region SafeZoneTotaal
        List<Kpoint> m_safezonetotaal = new List<Kpoint>();
        public List<Kpoint> SafeZoneTotaal
        {
            get
            {
                return m_safezonetotaal;
            }
            set
            {
                m_safezonetotaal = value;
            }
        }
        public List<Point> SafeZonePointsTotaal
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_safezonetotaal)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region SafeZoneZijde1
        List<Kpoint> m_safezonezijde1 = new List<Kpoint>();
        public List<Kpoint> SafeZoneZijde1
        {
            get
            {
                return m_safezonezijde1;
            }
            set
            {
                m_safezonezijde1 = value;
            }
        }
        public List<Point> SafeZoneZijde1Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_safezonezijde1)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region SafeZoneZijde2
        List<Kpoint> m_safezonezijde2 = new List<Kpoint>();
        public List<Kpoint> SafeZoneZijde2
        {
            get
            {
                return m_safezonezijde2;
            }
            set
            {
                m_safezonezijde2 = value;
            }
        }
        public List<Point> SafeZoneZijde2Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_safezonezijde2)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region SafeZoneZijde3
        List<Kpoint> m_safezonezijde3 = new List<Kpoint>();
        public List<Kpoint> SafeZoneZijde3
        {
            get
            {
                return m_safezonezijde3;
            }
            set
            {
                m_safezonezijde3 = value;
            }
        }
        public List<Point> SafeZoneZijde3Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_safezonezijde3)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region SafeZoneZijde4
        List<Kpoint> m_safezonezijde4 = new List<Kpoint>();
        public List<Kpoint> SafeZoneZijde4
        {
            get
            {
                return m_safezonezijde4;
            }
            set
            {
                m_safezonezijde4 = value;
            }
        }
        public List<Point> SafeZoneZijde4Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_safezonezijde4)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region SteenToegelatenOpGewicht
        bool m_gewichtok = false;
        public bool SteenToegelatenOpGewicht
        {
            get
            {
                return m_gewichtok;
            }
            set
            {
                m_gewichtok = value;
            }
        }
        #endregion
        #region Oplossingtotaal
        bool m_oplossingtotaal = false;
        public bool Oplossingtotaal
        {
            get
            {
                return m_oplossingtotaal;
            }
            set
            {
                m_oplossingtotaal = value;
            }
        }
        #endregion
        #region OplossingZijde1
        bool m_oplossingzijde1 = false;
        public bool OplossingZijde1
        {
            get
            {
                return m_oplossingzijde1;
            }
            set
            {
                m_oplossingzijde1 = value;
            }
        }
        #endregion
        #region OplossingZijde2
        bool m_oplossingzijde2 = false;
        public bool OplossingZijde2
        {
            get
            {
                return m_oplossingzijde2;
            }
            set
            {
                m_oplossingzijde2 = value;
            }
        }
        #endregion
        #region OplossingZijde3
        bool m_oplossingzijde3 = false;
        public bool OplossingZijde3
        {
            get
            {
                return m_oplossingzijde3;
            }
            set
            {
                m_oplossingzijde3 = value;
            }
        }
        #endregion
        #region OplossingZijde4
        bool m_oplossingzijde4 = false;
        public bool OplossingZijde4
        {
            get
            {
                return m_oplossingzijde4;
            }
            set
            {
                m_oplossingzijde4 = value;
            }
        }
        #endregion

        #region OplossingZijde12
        bool m_oplossingzijde12 = false;
        public bool OplossingZijde12
        {
            get
            {
                return m_oplossingzijde12;
            }
            set
            {
                m_oplossingzijde12 = value;
            }
        }
        #endregion


        #region OplossingZijde123
        bool m_oplossingzijde123 = false;
        public bool OplossingZijde123
        {
            get
            {
                return m_oplossingzijde123;
            }
            set
            {
                m_oplossingzijde123 = value;
            }
        }
        #endregion

        #region OplossingZijde124
        bool m_oplossingzijde124 = false;
        public bool OplossingZijde124
        {
            get
            {
                return m_oplossingzijde124;
            }
            set
            {
                m_oplossingzijde124 = value;
            }
        }
        #endregion
        #region OplossingZijde134
        bool m_oplossingzijde134 = false;
        public bool OplossingZijde134
        {
            get
            {
                return m_oplossingzijde134;
            }
            set
            {
                m_oplossingzijde134 = value;
            }
        }
        #endregion
        #region OplossingZijde234
        bool m_oplossingzijde234 = false;
        public bool OplossingZijde234
        {
            get
            {
                return m_oplossingzijde234;
            }
            set
            {
                m_oplossingzijde234 = value;
            }
        }
        #endregion

        #region OplossingZijde34
        bool m_oplossingzijde34 = false;
        public bool OplossingZijde34
        {
            get
            {
                return m_oplossingzijde34;
            }
            set
            {
                m_oplossingzijde34 = value;
            }
        }
        #endregion

        #region OpnameZoneZijde1
  

        public List<Kpoint> m_opnamezonezijde1 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde1
        {
            get
            {
                return m_opnamezonezijde1;
            }
            set
            {
                m_opnamezonezijde1 = value;
            }
        }
        public List<Point> OpnameZoneZijde1Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde1)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        

        #endregion
        #region OpnameZoneZijde2
        public List<Kpoint> m_opnamezonezijde2 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde2
        {
            get
            {
                return m_opnamezonezijde2;
            }
            set
            {
                m_opnamezonezijde2 = value;
            }
        }
        public List<Point> OpnameZoneZijde2Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde2)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region OpnameZoneZijde3
        public List<Kpoint> m_opnamezonezijde3 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde3
        {
            get
            {
                return m_opnamezonezijde3;
            }
            set
            {
                m_opnamezonezijde3 = value;
            }
        }
        public List<Point> OpnameZoneZijde3Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde3)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region OpnameZoneZijde4
        public List<Kpoint> m_opnamezonezijde4 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde4
        {
            get
            {
                return m_opnamezonezijde4;
            }
            set
            {
                m_opnamezonezijde4 = value;
            }
        }
        public List<Point> OpnameZoneZijde4Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde4)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region OpnameZoneZijde12
        public List<Kpoint> m_opnamezonezijde12 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde12
        {
            get
            {
                return m_opnamezonezijde12;
            }
            set
            {
                m_opnamezonezijde12 = value;
            }
        }
        public List<Point> OpnameZoneZijde12Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde12)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion
        #region OpnameZoneZijde34
        public List<Kpoint> m_opnamezonezijde34 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde34
        {
            get
            {
                return m_opnamezonezijde34;
            }
            set
            {
                m_opnamezonezijde34 = value;
            }
        }
        public List<Point> OpnameZoneZijde34Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde34)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region OpnameZoneZijde123
        public List<Kpoint> m_opnamezonezijde123 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde123
        {
            get
            {
                return m_opnamezonezijde123;
            }
            set
            {
                m_opnamezonezijde123 = value;
            }
        }
        public List<Point> OpnameZoneZijde123Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde123)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region OpnameZoneZijde124
        public List<Kpoint> m_opnamezonezijde124 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde124
        {
            get
            {
                return m_opnamezonezijde124;
            }
            set
            {
                m_opnamezonezijde124 = value;
            }
        }
        public List<Point> OpnameZoneZijde124Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde124)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region OpnameZoneZijde234
        public List<Kpoint> m_opnamezonezijde234 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde234
        {
            get
            {
                return m_opnamezonezijde234;
            }
            set
            {
                m_opnamezonezijde234 = value;
            }
        }
        public List<Point> OpnameZoneZijde234Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde234)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion

        #region OpnameZoneZijde134
        public List<Kpoint> m_opnamezonezijde134 = new List<Kpoint>();
        public List<Kpoint> OpnameZoneZijde134
        {
            get
            {
                return m_opnamezonezijde134;
            }
            set
            {
                m_opnamezonezijde134 = value;
            }
        }
        public List<Point> OpnameZoneZijde134Points
        {
            get
            {
                List<Point> p = new List<Point>();
                foreach (Kpoint k in m_opnamezonezijde134)
                {
                    p.Add(new Point((int)k.X, (int)k.Y));
                }

                return p;
            }
            set
            {

            }
        }
        #endregion



        #region OpnamePoint
        Kpoint m_opnamepoint = new Kpoint();
        public Kpoint OpnamePoint
        {
            get
            {
                return m_opnamepoint;
            }
            set
            {
                m_opnamepoint = value;
            }
        }
        #endregion
        #region OpnamePointZijde12
        Kpoint m_opnamepointzijde12 = new Kpoint();
        public Kpoint OpnamePointZijde12
        {
            get
            {
                return m_opnamepointzijde12;
            }
            set
            {
                m_opnamepointzijde12 = value;
            }
        }
        #endregion
        #region OpnamePointZijde34
        Kpoint m_opnamepointzijde34 = new Kpoint();
        public Kpoint OpnamePointZijde34
        {
            get
            {
                return m_opnamepointzijde34;
            }
            set
            {
                m_opnamepointzijde34 = value;
            }
        }
        #endregion

        public Grippervariant()
        {
            
        }
        public Grippervariant(Grippervariant g)
        {
            m_toolnr = g.m_toolnr;
            m_outer = g.m_outer;
            m_inner = g.m_inner;
            m_opnamezone = g.m_opnamezone;
        }

        public void Reset()
        { 
            m_opnamezone.Clear();
            m_safezonetotaal.Clear();
            m_safezonezijde1.Clear();
            m_safezonezijde2.Clear();
            m_safezonezijde3.Clear();
            m_safezonezijde4.Clear();
            m_gewichtok = false;

            m_oplossingtotaal = false;
            m_oplossingzijde1 = false;
            m_oplossingzijde2 = false;
            m_oplossingzijde3 = false;
            m_oplossingzijde4 = false;

            m_oplossingzijde12 = false;
            m_oplossingzijde34 = false;

            m_opnamezonezijde1.Clear();
            m_opnamezonezijde2.Clear();
            m_opnamezonezijde3.Clear();
            m_opnamezonezijde4.Clear();
        }

        //public Bitmap getpreview()
        //{
        //    Graphics graphicsObj;
        //    Bitmap b = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    graphicsObj = Graphics.FromImage(b);
        //    graphicsObj.Clear(Color.White);
        //    graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
        //    graphicsObj.TranslateTransform((1000) / 2, (800) / 2);
        //    //graphicsObj.ScaleTransform(1, -1);
            
        //    graphicsObj.DrawRectangle(Pens.Black, Outer);
        //    graphicsObj.DrawRectangle(Pens.LimeGreen, Inner);


        //    graphicsObj.DrawLine(Pens.Red, 10, 0, 100, 0);//X
        //    graphicsObj.DrawLine(Pens.Blue, 0, 10, 0, 100);//Y
        //    return b;
        //}

        public Bitmap getopnamezone(int l, int w, int zijde, bool grijper)
        {
            int centersize = 10;

            Graphics graphicsObj;
            Bitmap b = new Bitmap(2000, 2000, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            graphicsObj = Graphics.FromImage(b);
            graphicsObj.Clear(Color.White);
            graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
            graphicsObj.TranslateTransform((2000) / 2, (2000) / 2);
            //graphicsObj.ScaleTransform(1, -1);
            //
            graphicsObj.DrawRectangle(Pens.Black, new Rectangle(-l/2, -w/2, l, w));
            //graphicsObj.FillRectangle(Brushes.Gray, new Rectangle(-250, -100, 500, 200));
            switch(zijde)
            {
                case 0:
                    if (OpnameZonePoints.Count > 0)
                    {
                        graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZonePoints.ToArray());
                    }
                    if (SafeZonePointsTotaal.Count > 0)
                    {
                        graphicsObj.DrawPolygon(Pens.Red, SafeZonePointsTotaal.ToArray());
                    }
                    if (Oplossingtotaal)
                    {
                        graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePoint.X - centersize / 2, (int)OpnamePoint.Y - centersize / 2, centersize, centersize);
                    }
                break;
                case 1:
                if (OpnameZoneZijde1Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde1Points.ToArray());
                }
                if (SafeZoneZijde1Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde1Points.ToArray());
                }
                break;
                case 2:
                if (OpnameZoneZijde2Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde2Points.ToArray());
                }
                if (SafeZoneZijde2Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde2Points.ToArray());
                }
                break;
                case 3:
                if (OpnameZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                break;
                case 4:
                if (OpnameZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde4Points.ToArray());
                }
                if (SafeZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                break;
                case 5:
                if (OpnameZoneZijde12Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde12Points.ToArray());
                }
                if (SafeZoneZijde1Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde1Points.ToArray());
                }
                if (SafeZoneZijde2Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde2Points.ToArray());
                }
                if (OplossingZijde12) 
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde12.X - centersize / 2, (int)OpnamePointZijde12.Y - centersize / 2, centersize, centersize);
                }
                break;
                case 6:
                if (OpnameZoneZijde34Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde34Points.ToArray());
                }
                if (SafeZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                if (OplossingZijde34)
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde34.X - centersize / 2, (int)OpnamePointZijde34.Y - centersize / 2, centersize, centersize);
                }
                break;
                case 7:
                if (OpnameZoneZijde124Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde124Points.ToArray());
                }
                if (SafeZoneZijde1Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde2Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                if (OplossingZijde124)
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde34.X - centersize / 2, (int)OpnamePointZijde34.Y - centersize / 2, centersize, centersize);
                }
                break;
                case 8:
                if (OpnameZoneZijde134Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde134Points.ToArray());
                }
                if (SafeZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                if (OplossingZijde134)
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde34.X - centersize / 2, (int)OpnamePointZijde34.Y - centersize / 2, centersize, centersize);
                }
                break;
                case 9:
                if (OpnameZoneZijde123Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde123Points.ToArray());
                }
                if (SafeZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                if (OplossingZijde123)
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde34.X - centersize / 2, (int)OpnamePointZijde34.Y - centersize / 2, centersize, centersize);
                }
                break;
                case 10:
                if (OpnameZoneZijde234Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.LimeGreen, OpnameZoneZijde234Points.ToArray());
                }
                if (SafeZoneZijde3Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde3Points.ToArray());
                }
                if (SafeZoneZijde4Points.Count > 0)
                {
                    graphicsObj.DrawPolygon(Pens.Red, SafeZoneZijde4Points.ToArray());
                }
                if (OplossingZijde234)
                {
                    graphicsObj.FillEllipse(Brushes.LimeGreen, (int)OpnamePointZijde34.X - centersize / 2, (int)OpnamePointZijde34.Y - centersize / 2, centersize, centersize);
                }
                break;
            }
            graphicsObj.DrawLine(Pens.Red, 10, 0, 100, 0);//X
            graphicsObj.DrawLine(Pens.Blue, 0, 10, 0, 100);//Y

            if (grijper)
            {
                graphicsObj.FillRectangle(Brushes.Black, Outer);
                graphicsObj.FillRectangle(Brushes.LimeGreen, Inner);
            }
            return b;
        }
    }
}
