using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace traco_opname
{
    public class Zijde
    {
        public double m_ankdepth = 0;
        public double m_ankdist = 0;
        public double m_ankdia = 0;

        public int ofl= -1;
        public int F1 = -1;
        public int F2 = -1;
        public int F3 = -1;
        public int F4 = -1;

        public double m_ad = -30;

        public SingZone m_singzone;

        //public double m_vbilengte = -1;
        //public double m_vbulengte = -1;

        Pen Pen_draw      = new Pen(Color.Black, 6);
        Pen Pen_dash_draw = new Pen(Color.Black, 5);
        float[] dashValues = { 5, 2, 15, 4 };

//        public int m_refmeethoek = 5;
        //public int m_richting = -1;

        public double m_afsmus_height_schuin = -1;
        public double m_afsmus_height_rest = -1;

        public int m_hoek_afs = 0;
        public int m_hoek_mus = 0;
        public int m_x = 0;
        public int m_y = 0;
        public int m_l = 0;

        public string m_typenaam = "";
 //       public string m_afwerking = "";

        public double m_Xstrt = 0;
        public double m_Ystrt = 0;
        public double m_Xend = 0;
        public double m_Yend = 0;
        public int m_lengte_a = 0;
        public int m_lengte_b = 0;
        public int m_lengte_c = 0;
        public int m_edgev_a = 0;
        public int m_edgev_b = 0;
        public int m_edgev_c = 0;
        public int m_edgea_a = 0;
        public int m_edgea_b = 0;
        public int m_edgea_c = 0;
        public int m_brdr_a = 0;
        public int m_brdr_b = 0;
        public int m_brdr_c = 0;
        public int m_afsy = 0;
        public int m_afsz = 0;
        public int m_musy = 0;
        public int m_musz = 0;
        public int m_ank1 = 0;
        public int m_ank2 = 0;
        public int m_ank3 = 0;
        public int m_drupstart = 0;
        public int m_drupstop = 0;
        public int m_hoek = 0;
        public int m_hoek2 = 0;
        public int m_opnamenr = 0;
        public int m_zagen = 0;
        public int m_cutoutdiepte = 0;
        public int m_cutoutdikte = 0; 
        public int m_calibdiepte = 0;
        public int m_calibdikte = 0;
        public int m_dgdikte = 0;
        public int m_drupdist = 0;

        public Zijde()
        {

        }

        public Zijde(Zijde z, int rotatiehoek)
        {
            m_ankdepth = z.m_ankdepth;
            m_ankdist = z.m_ankdist;
            m_ankdia = z.m_ankdia;

            m_drupdist = z.m_drupdist;

            ofl= z.ofl;
            F1 = z.F1;
            F2 = z.F2;
            F3 = z.F3;
            F4 = z.F4;

            //m_richting = z.m_richting;

            m_afsmus_height_schuin = z.m_afsmus_height_schuin;
            m_afsmus_height_rest = z.m_afsmus_height_rest;

      //      m_afwerking = z.m_afwerking;

            m_hoek_afs = z.m_hoek_afs;
            m_hoek_mus = z.m_hoek_mus;
            m_x = z.m_x;
            m_y = z.m_y;
            m_l = z.m_l;

            //m_afw = z.m_afw;

            m_typenaam = z.m_typenaam;

            if (rotatiehoek == 0)
            {
                m_Xstrt = z.m_Xstrt;
                m_Ystrt = z.m_Ystrt;
                m_Xend = z.m_Xend;
                m_Yend = z.m_Yend;

            }
            else if (rotatiehoek == 90)
            {
                //dat x'=-y
                //en y'=x

                m_Xstrt = -1 * z.m_Ystrt;
                m_Ystrt = z.m_Xstrt;
                m_Xend = -1 * z.m_Yend;
                m_Yend = z.m_Xend;

                
            }
            else if (rotatiehoek == 180)
            {
                m_Xstrt *= -1;
                m_Ystrt *= -1;
                m_Xend  *= -1;
                m_Yend  *= -1;

              
            }


            m_lengte_a = z.m_lengte_a;
            m_lengte_b = z.m_lengte_b;
            m_lengte_c = z.m_lengte_c;
            m_edgev_a = z.m_edgev_a;
            m_edgev_b = z.m_edgev_b;
            m_edgev_c = z.m_edgev_c;
            m_edgea_a = z.m_edgea_a;
            m_edgea_b = z.m_edgea_b;
            m_edgea_c = z.m_edgea_c;
            m_brdr_a = z.m_brdr_a;
            m_brdr_b = z.m_brdr_b;
            m_brdr_c = z.m_brdr_c;
            m_afsy = z.m_afsy;
            m_afsz = z.m_afsz;
            m_musy = z.m_musy;
            m_musz = z.m_musz;
            m_ank1 = z.m_ank1;
            m_ank2 = z.m_ank2;
            m_ank3 = z.m_ank3;
            m_drupstart = z.m_drupstart;
            m_drupstop = z.m_drupstop;
            m_hoek = z.m_hoek;
            m_hoek2 = z.m_hoek2;
            m_opnamenr = z.m_opnamenr;
            m_zagen = z.m_zagen;

            m_cutoutdiepte = z.m_cutoutdiepte;
            m_cutoutdikte = z.m_cutoutdikte; 
            m_calibdiepte = z.m_calibdiepte;
            m_calibdikte = z.m_calibdikte;
            m_dgdikte = z.m_dgdikte;
            m_drupdist = z.m_drupdist;
        }

        public Zijde(int Xstrt, int Ystrt, int Xend, int Yend, int lengte_a, int lengte_b, int lengte_c, int edgev_a, int edgev_b, int edgev_c, int edgea_a, int edgea_b, int edgea_c, int brdr_a, int brdr_b, int brdr_c, int afsy, int afsz, int mus1, int mus2, int ank1, int ank2, int drupstart, int drupstop, int hoek)
        {
            m_Xstrt = Xstrt;
            m_Ystrt = Ystrt;
            m_Xend = Xend;
            m_Yend = Yend;
            m_lengte_a = lengte_a;
            m_lengte_b = lengte_b;
            m_lengte_c = lengte_c;
            m_edgev_a = edgev_a;
            m_edgev_b = edgev_b;
            m_edgev_c = edgev_c;
            m_edgea_a = edgea_a;
            m_edgea_b = edgea_b;
            m_edgea_c = edgea_c;
            m_brdr_a = brdr_a;
            m_brdr_b = brdr_b;
            m_brdr_c = brdr_c;
            m_afsy = afsy;
            m_afsz = afsz;
            m_musy = mus1;
            m_musz = mus2;
            m_ank1 = ank1;
            m_ank2 = ank2;
            m_drupstart = drupstart;
            m_drupstop = drupstop;
            m_hoek = hoek;
        }

        public void draw(ref Graphics grp)
        {
            double hoek = 0;

            Pen_dash_draw.DashPattern = dashValues;
            Pen_dash_draw.DashCap = DashCap.Round;

            #region punten berekenen
            if (m_Xend == m_Xstrt) 
            {
                if (m_Yend > m_Ystrt)
                {
                    hoek = 0;
                }
                else
                {
                    hoek = 180;
                }
            }
            else if (m_Yend == m_Ystrt) 
            {
                if (m_Xend > m_Xstrt)
                {
                    hoek = 90;
                }
                else
                {
                    hoek = 270;
                }
            }
            else
            {
                hoek = Math.Atan((double)(m_Yend - m_Ystrt) / (double)(m_Xend - m_Xstrt)) * 180 / Math.PI;
                if (m_Yend > m_Ystrt && m_Xend < m_Xstrt) { hoek = (hoek + 90) * -1; } //hoek 1
                if (m_Yend < m_Ystrt && m_Xend < m_Xstrt) { hoek = (hoek + 90) * -1; } //hoek 2
                if (m_Yend < m_Ystrt && m_Xend > m_Xstrt) { hoek = -hoek + 90;       } //hoek 3
                if (m_Yend > m_Ystrt && m_Xend > m_Xstrt) { hoek = -hoek + 90;       } //hoek 4
            }
            #endregion

            #region 0,0 verleggen naar startpos
            grp.TranslateTransform((int)m_Ystrt, (int)m_Xstrt);
            grp.RotateTransform((float)hoek);
            #endregion

            int l = m_lengte_a + m_lengte_b + m_lengte_c;
            if (m_zagen == 11)
            {
                grp.DrawLine(Pen_dash_draw, 0, 0, l / 2, -l / 2);
                grp.DrawLine(Pen_dash_draw, l / 2, -l / 2, l, 0);
            }

            #region edgev
            if (m_edgev_a > 0)
            {
                if (m_edgev_a == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgev_a == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else 
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, 0, 0, m_lengte_a, 0);
                }
                else if (m_zagen == 1 || m_zagen == 2)
                {
                    grp.DrawLine(Pen_dash_draw, 0, 0, m_lengte_a, 0);
                }
            }
            else
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, 0, 0, m_lengte_a, 0);
                }
                else if (m_zagen == 1 || m_zagen == 2)
                {
                    grp.DrawLine(Pen_dash_draw, 0, 0, m_lengte_a, 0);
                }
            }
            if (m_edgev_b > 0)
            {
                if (m_edgev_b == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgev_b == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a, 0, m_lengte_a + m_lengte_b, 0);
                }
                else if (m_zagen == 1 || m_zagen == 2)
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a, 0, m_lengte_a + m_lengte_b, 0);
                }
            }
            else
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a, 0, m_lengte_a + m_lengte_b, 0);
                }
                else if (m_zagen == 1 || m_zagen == 2)
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a, 0, m_lengte_a + m_lengte_b, 0);
                }
            
            }
            if (m_edgev_c > 0)
            {
                if (m_edgev_c == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgev_c == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a + m_lengte_b, 0, m_lengte_a + m_lengte_b + m_lengte_c, 0);
                }
                else if (m_zagen == 1 || m_zagen == 2)
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a + m_lengte_b, 0, m_lengte_a + m_lengte_b + m_lengte_c, 0);
                }
            }
            #endregion

            #region edgea
            if (m_edgea_a > 0)
            {
                if (m_edgea_a == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgea_a == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, 0, 150, m_lengte_a, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, 0, 150, m_lengte_a, 150);
                }
            }
            else
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, 0, 150, m_lengte_a, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, 0, 150, m_lengte_a, 150);
                }
            }
            if (m_edgea_b > 0)
            {
                if (m_edgea_b == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgea_b == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a, 150, m_lengte_a + m_lengte_b, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a, 150, m_lengte_a + m_lengte_b, 150);
                }
            }
            else
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a, 150, m_lengte_a + m_lengte_b, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a, 150, m_lengte_a + m_lengte_b, 150);
                }

            }
            if (m_edgea_c > 0)
            {
                if (m_edgea_c == 1)
                {
                    Pen_draw.Color = Color.Red;
                    Pen_dash_draw.Color = Color.Red;
                }
                else if (m_edgea_c == 2)
                {
                    Pen_draw.Color = Color.LimeGreen;
                    Pen_dash_draw.Color = Color.LimeGreen;
                }
                else
                {
                    Pen_draw.Color = Color.Orange;
                    Pen_dash_draw.Color = Color.Orange;
                }

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a + m_lengte_b, 150, m_lengte_a + m_lengte_b + m_lengte_c, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a + m_lengte_b, 150, m_lengte_a + m_lengte_b + m_lengte_c, 150);
                }
            }
            else
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                if (m_zagen == 0)
                {
                    grp.DrawLine(Pen_draw, m_lengte_a + m_lengte_b, 150, m_lengte_a + m_lengte_b + m_lengte_c, 150);
                }
                else
                {
                    grp.DrawLine(Pen_dash_draw, m_lengte_a + m_lengte_b, 150, m_lengte_a + m_lengte_b + m_lengte_c, 150);
                }
            }
            #endregion

            #region Border
            if (m_brdr_a > 0)
            {
                if (m_brdr_a == 1)
                {
                    grp.FillRectangle(Brushes.LightGoldenrodYellow, 0, 10, m_lengte_a, 130);
                }
                if (m_brdr_a == 3)
                {
                    grp.FillRectangle(Brushes.LightBlue, 0, 10, m_lengte_a, 130);
                }
                else if (m_brdr_a == 5 || m_brdr_a == 6)
                {
                    grp.FillRectangle(Brushes.LightSalmon, 0, 10, m_lengte_a, 130);
                }
                else if (m_brdr_a == 7 || m_brdr_a == 8)
                {
                    grp.FillRectangle(Brushes.LightCoral, 0, 10, m_lengte_a, 130);
                }
                else if (m_brdr_a == 10)
                {
                    grp.FillRectangle(Brushes.Brown, 0, 10, m_lengte_a, 130);
                }
            }
           
            if (m_brdr_b > 0)
            {
                if (m_brdr_b == 3)
                {
                    grp.FillRectangle(Brushes.LightBlue, m_lengte_a, 10, m_lengte_b, 130);
                }
                else if (m_brdr_b == 5 || m_brdr_b == 6)
                {
                    grp.FillRectangle(Brushes.LightSalmon, m_lengte_a, 10, m_lengte_b, 130);
                }
                else if (m_brdr_b == 7 || m_brdr_b == 8)
                {
                    grp.FillRectangle(Brushes.LightCoral, m_lengte_a, 10, m_lengte_b, 130);
                }
                else if (m_brdr_b == 10)
                {
                    grp.FillRectangle(Brushes.Brown, m_lengte_a, 10, m_lengte_b, 130);
                }
            }
            
            if (m_brdr_c > 0)
            {
                if (m_brdr_c == 3)
                {
                    grp.FillRectangle(Brushes.LightBlue, m_lengte_a + m_lengte_b, 10, m_lengte_c, 130);
                }
                else if (m_brdr_c == 5 || m_brdr_c == 6)
                {
                    grp.FillRectangle(Brushes.LightSalmon, m_lengte_a + m_lengte_b, 10, m_lengte_c, 130);
                }
                else if (m_brdr_c == 7 || m_brdr_c == 8)
                {
                    grp.FillRectangle(Brushes.LightCoral, m_lengte_a + m_lengte_b, 10, m_lengte_c, 130);
                }
                else if (m_brdr_c == 10)
                {
                    grp.FillRectangle(Brushes.Brown, m_lengte_a + m_lengte_b, 10, m_lengte_c, 130);
                }
            }
            #endregion

            #region Corner
            Pen_draw.Color = Color.Black;
            grp.DrawLine(Pen_draw, 0, 0, 0, 150);

            if (m_hoek > 0 || m_hoek2 > 0)
            {
                if (m_hoek == 4) { Pen_draw.Color = Color.Red; }
                if (m_hoek == 2) { Pen_draw.Color = Color.LimeGreen; }
            }
            else
            {
                Pen_draw.Color = Color.Black;
            }
            int totall = m_lengte_a + m_lengte_b + m_lengte_c;
            grp.DrawLine(Pen_draw, totall, 0, l, 150);
            #endregion

            #region Drupgroef
            if (m_drupstart >= 0 && m_drupstop > 0)
            {
                Pen_draw.Color = Color.Black;
                Pen_dash_draw.Color = Color.Black;

                grp.DrawRectangle(Pen_dash_draw, m_drupstart, 20, m_drupstop-m_drupstart, 20);
            }
            #endregion

            #region Ankergaten
            if (m_ank1 > 0 || m_ank2 > 0)
            {
                grp.FillEllipse(Brushes.Purple, 20 , 60 , 20, 20);
                grp.FillEllipse(Brushes.Purple, l - 40, 60 , 20, 20);
            }
            #endregion

            #region AFS MUS
            if ((m_afsy > 0 && m_afsz > 0))//|| m_typenaam == "AFSZA" || m_typenaam == "AFSSP" || m_typenaam == "AFS" || m_typenaam == "MUS" || m_typenaam == "MUSSP" || m_typenaam == "VBI" || m_typenaam == "VBU")
            {
                //if (m_typenaam == "AFSZA" || m_typenaam == "AFSSP" || m_typenaam == "AFS" || m_typenaam == "VBI")
                //{
                //    grp.DrawLine(Pen_draw, 20, 100, l - 40, 100);
                //}
                //else
                //{
                grp.DrawLine(Pen_draw, 20, 100, l - 40, 100);
                //}
            }
            if ( (m_musy > 0 && m_musz >0) )//|| m_typenaam == "AFSZA" || m_typenaam == "AFSSP" || m_typenaam == "AFS" || m_typenaam == "MUS" || m_typenaam == "MUSSP" || m_typenaam == "VBI" || m_typenaam == "VBU")
            {
                //if (m_typenaam == "AFSZA" || m_typenaam == "AFSSP" || m_typenaam == "AFS" || m_typenaam == "VBI")
                //{
                //    grp.DrawLine(Pen_draw, 20, 100, l - 40, 100);
                //}
                //else
                //{
                    grp.DrawLine(Pen_dash_draw, 20, 100, l - 40, 100);
                //}
            }
            #endregion

            #region opnamenr
            string temp = "";
            if (m_opnamenr == 0)
            {
                temp = "0";
            }
            if (m_opnamenr == 1)
            {
                temp = "I";
            }
            if (m_opnamenr == 2)
            {
                temp = "II";
            }
            grp.DrawString(temp, new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular), new SolidBrush(Color.Black), ((m_lengte_a+m_lengte_b+m_lengte_c)/2), 20);

            if (m_hoek == 2 || m_hoek == 4)
            {
                grp.DrawString("hoek", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), new SolidBrush(Color.Black), ((m_lengte_a + m_lengte_b + m_lengte_c) / 2), 100);

            }
            else if (m_hoek2 == 2 || m_hoek2 == 4)
            {
                grp.DrawString("hoek2", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), new SolidBrush(Color.Black), ((m_lengte_a + m_lengte_b + m_lengte_c) / 2), 100);
            }
            #endregion

            #region calib
            if (m_calibdiepte > 0 && m_calibdikte > 0)
            {
                grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.Blue), 0, 0, 200, 30);
            }
            #endregion

            #region cutout
            if (m_cutoutdiepte > 0 && m_cutoutdikte > 0)
            {
                grp.FillRectangle(new HatchBrush(HatchStyle.Cross, Color.Blue), 0, 75, 50, 75);
            }
            #endregion

         }
    }

    public class Rechte
    {
        public int m_richting = -1;
        public double m_a = 0;
        public double m_b = 0;
        public bool m_ishor = false;
        public bool m_isver = false;

        public Rechte(double a, double b)
        {
            m_a = a;
            m_b = b;
        }

        public Rechte(double a, double b, bool hor, bool ver)
        {
            m_a = a;
            m_b = b;

            m_ishor = hor;
            m_isver = ver;
            //TODO: beter nog is zelf bereken bij aanmaken
        }
        public Rechte(double a, double b, bool hor, bool ver, int richting)
        {
            m_a = a;
            m_b = b;

            m_ishor = hor;
            m_isver = ver;

            m_richting = richting;
            //TODO: beter nog is zelf bereken bij aanmaken
        }

        public Rechte(Point p1, Point p2)
        {
            if (p1.X == p2.X)
            {
                m_isver = true;
            }
            else if (p1.Y == p2.Y)
            {
                m_ishor = true;
            }

            if (p1.X == p2.X)
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = p2.X;
            }
            else if (p1.Y == p2.Y)
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = p2.Y;
            }
            else
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = -m_a * p1.X + p1.Y;
            }
        }
        public Rechte(Kpoint p1, Kpoint p2)
        {
            if (p1.X == p2.X)
            {
                m_isver = true;
            }
            else if (p1.Y == p2.Y)
            {
                m_ishor = true;
            }

            if (p1.X == p2.X)
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = p2.X;
            }
            else if (p1.Y == p2.Y)
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = p2.Y;
            }
            else
            {
                m_a = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                m_b = -m_a * p1.X + p1.Y;
            }
        }
    }

    [Serializable()]
    public class Job_def : ISerializable
    {
        int m_orientatie_origineel = 0;

        int m_configoffset = 0;
        int m_configoffset2 = 0; 

        bool m_nietbewerkbarejob = false;

        bool manualgripper = false; //used to ignore gripperselector in job def constructor form ini file

        List<Kpoint> singlist;
        List<Kpoint> sing2list;

        public int m_palletnummer = -1;

        public string m_afwerkingsniveau = "";

        public string m_renierpreviewpath = "";

        bool m_edgesdoen = false;
        bool m_nietsdoen = false;
        bool m_frijndoen = false;
        bool m_bordersdoen = false;
        bool m_zaagdoen = false;
        bool m_ankerdoen = false;
        bool m_drupdoen = false;

        public int m_override = 100;

        int m_frijnrichting = 0;
        int m_tailleerrichting = 0;
        int m_gradineerrichting = 0;
        int m_afwerking_oppervlak = 0;
        int m_oppervlak_frijnen = 0;
        int m_drupgroef = 0;
        int m_kantjes_breken = 0;
        int m_orientatie_stuk = 0;

        public Graphics graphicsObj;
        Bitmap myBitmap;
        public Pen Pen_black = new Pen(System.Drawing.Color.Black, 14);
        public Pen Pen_green = new Pen(System.Drawing.Color.Green, 6);
        public Pen Pen_blue = new Pen(System.Drawing.Color.Blue, 6);
        public Pen Pen_blue2 = new Pen(System.Drawing.Color.LightBlue, 6);
        public Pen Pen_red = new Pen(System.Drawing.Color.Red, 6);

        public List<Zijde> m_zijdes = new List<Zijde>(); //zijdes 1 tot 4/8
        List<Kpoint> m_pointlist = new List<Kpoint>(); //originele punten voor tekening
        List<Rechte> m_rechtelist = new List<Rechte>(); //offset bepaling
        List<Kpoint> m_inset_pointlist = new List<Kpoint>();//inset points
        List<Rechte> m_rechtelist_singin = new List<Rechte>(); //sing bepaling
        List<Rechte> m_rechtelist_singuit = new List<Rechte>(); //sing bepaling
        List<Point> m_singin_pointlist = new List<Point>();//singin points
        List<Point> m_singuit_pointlist = new List<Point>();//singuit points

        List<Point> m_gripperpointlist = new List<Point>();//grijper tekenen

        public int m_voorvlak = 0;

        public int m_gewicht = 0;

        public int m_lenght = 1;
        public int m_width = 1;
        public int m_height = 1;
      
        public int m_materiaalnr = 1;
        public int m_presetnr = -1;

        public int m_materiaalnr_schuin = 1;
        public int m_presetnr_schuin = -1;

        public int m_materiaalnr_recht = 1;
        public int m_presetnr_recht = -1;

        public IniFile m_config;
        Gripperselecter m_selector;

        public bool m_puntinvlak = false;

        int[] m_available_grippers;
        public int m_bestgripper = -1;
        public int m_bestgripperoriginal = -1;

        int m_gripper_available = -1;

        public int m_gripperoffset_x1 = 0;//used for stop at pickup
        public int m_gripperoffset_y1 = 0;
        public int m_gripperoffset_x2 = 0;
        public int m_gripperoffset_y2 = 0;
        public int m_gripperangle1 = 0;
        public int m_gripperangle2 = 180;

        public DateTime m_starttime;

        public int m_time_estimate_sec = 0;

        public string m_jobname = ""; //plaats voor de barcode

        public string m_afw = "";

        public double m_opname_X = 0;
        public double m_opname_Y = 0;
        public double m_opname_A = 0;

        public string m_bottomdr = "";
        public string m_topdr = "";
        public string m_leftdr = "";
        public string m_rightdr = "";

        //public double m_dgdikte = 0;

        public List<Kpoint> m_ankergaten = new List<Kpoint>();
        //int m_gripper_chosen = -1;
        //public int[] m_tijdsberekening = new int[] { 0, 0, 0, 0, 0, 0, 0 };
       
        //public string m_previewlocation = "";
        //-------------------------------------------------------------------------------
        ////public string m_kleur = "";

        public Job_def()
        {

        }
        public Job_def(Job_def job, ref Gripperselecter selector)
        {
            m_selector = selector;

            m_config = job.m_config;
            m_palletnummer = job.m_palletnummer;
            m_frijnrichting = job.m_frijnrichting;
            m_tailleerrichting = job.m_tailleerrichting;
            m_gradineerrichting = job.m_gradineerrichting;
            m_afwerking_oppervlak = job.m_afwerking_oppervlak;
            m_oppervlak_frijnen = job.m_oppervlak_frijnen;
            m_drupgroef = job.m_drupgroef;
            m_kantjes_breken = job.m_kantjes_breken;
            m_orientatie_stuk = job.m_orientatie_stuk;

            //List<Zijde> m_zijdes = new List<Zijde>(); //zijdes 1 tot 4/8
            for (int i = 0; i < job.m_zijdes.Count; ++i)
            {
                m_zijdes.Add(new Zijde(job.m_zijdes[i],0));
            }
            singlist = new List<Kpoint>();
            sing2list = new List<Kpoint>();
            if (job.singlist != null)
            {
                for (int i = 0; i < job.singlist.Count; ++i)
                {
                    singlist.Add(new Kpoint(job.singlist[i].X, job.singlist[i].Y, 0));
                }
            }
            if (job.sing2list != null)
            {
                for (int i = 0; i < job.sing2list.Count; ++i)
                {
                    sing2list.Add(new Kpoint(job.sing2list[i].X, job.sing2list[i].Y, 0));
                }
            }
            //List<Point> m_pointlist = new List<Point>(); //originele punten voor tekening
            for (int i = 0; i < job.m_pointlist.Count; ++i)
            {
                m_pointlist.Add(new Kpoint(job.m_pointlist[i].X, job.m_pointlist[i].Y, job.m_pointlist[i].zaagpunt, job.m_pointlist[i].m_afw));
            }
            //List<Point> m_inset_pointlist = new List<Point>();//inset points
            for (int i = 0; i < job.m_inset_pointlist.Count; ++i)
            {
                m_inset_pointlist.Add(new Kpoint(job.m_inset_pointlist[i].X, job.m_inset_pointlist[i].Y,0));
            }
            //List<Point> m_singin_pointlist = new List<Point>();//singin points
            for (int i = 0; i < job.m_singin_pointlist.Count; ++i)
            {
                m_singin_pointlist.Add(new Point(job.m_singin_pointlist[i].X, job.m_singin_pointlist[i].Y));
            }
            //List<Point> m_singuit_pointlist = new List<Point>();//singuit points
            for (int i = 0; i < job.m_singin_pointlist.Count; ++i)
            {
                m_singuit_pointlist.Add(new Point(job.m_singuit_pointlist[i].X, job.m_singuit_pointlist[i].Y));
            }

            for (int i = 0; i < job.m_ankergaten.Count; ++i)
            {
                m_ankergaten.Add(new Kpoint(job.m_ankergaten[i].X, job.m_ankergaten[i].Y,job.m_ankergaten[i].m_diepte));
            }
            
            m_voorvlak = job.m_voorvlak;
            m_gewicht = job.m_gewicht;
            m_lenght = job.m_lenght;
            m_width = job.m_width;
            m_height = job.m_height;
            m_materiaalnr = job.m_materiaalnr;
            m_presetnr = job.m_presetnr;

            m_materiaalnr_recht = job.m_materiaalnr_recht;
            m_materiaalnr_schuin = job.m_materiaalnr_schuin;
            m_presetnr_recht = job.m_presetnr_recht;
            m_presetnr_schuin = job.m_presetnr_schuin;
            
            m_bestgripper = job.m_bestgripper;
            m_bestgripperoriginal = job.m_bestgripperoriginal;
            m_gripper_available = job.m_gripper_available;

            m_gripperoffset_x1 = job.m_gripperoffset_x1;//used for stop at pickup
            m_gripperoffset_y1 = job.m_gripperoffset_y1;
            m_gripperoffset_x2 = job.m_gripperoffset_x2;
            m_gripperoffset_y2 = job.m_gripperoffset_y2;
            m_gripperangle1 = job.m_gripperangle1;
            m_gripperangle2 = job.m_gripperangle2;

            m_starttime = job.m_starttime;

            m_jobname = job.m_jobname; //plaats voor de barcode

            // KC 28/06:
            m_opname_X = job.m_opname_X;
            m_opname_Y = job.m_opname_Y;
            m_opname_A = job.m_opname_A;

            //beetje nutteloos
            m_puntinvlak = job.m_puntinvlak;
            //ook niet zo nuttig meer denk ik 
            //int[] m_available_grippers;
            m_time_estimate_sec = job.m_time_estimate_sec;
        }
        public Job_def(SerializationInfo info, StreamingContext ctxt)
        {
            //try
            //{
            //    string version = (string)info.GetValue("Version", typeof(string));
            //}
            //catch {}

            //try
            //{
            //    //Version 1.0
            //    m_jobname = (string)info.GetValue("Jobname", typeof(string));
            //    m_materiaal = (string)info.GetValue("Materiaal", typeof(string));
            //    m_lenght = (int)info.GetValue("Lenght", typeof(int));
            //    m_width = (int)info.GetValue("Width", typeof(int));
            //    m_height = (int)info.GetValue("Height", typeof(int));
            //    m_grippernr = (int)info.GetValue("Grippernr", typeof(int));
            //    m_materiaalnr = (int)info.GetValue("Materiaalnr", typeof(int));
            //    m_presetnr = (int)info.GetValue("Presetnr", typeof(int));
            //    m_presetname = (string)info.GetValue("Presetname", typeof(string));
            //    m_zijdes = (List<Zijde>)info.GetValue("Zijdes", typeof(List<Zijde>));

            //}
            //catch {}
        }
        public Job_def(Component geladen_xml, ref Gripperselecter selector, ref IniFile configref)
        {
            
            int step = 0;
            try
            {
                //m_ankergaten.Clear();

                #region locatie
                double pickup_x = 0;
                double pickup_y = 0;
                double pickup_a = 0;


                //20170413, onderste laag op 1899
                //1727.2911  
                //-221.1409   
                //0.0080480  

                double robdx = 1288;
                double robdy = -3; // -10; // 27/07: KC -> 18mm extra
                //double robda = 0.0080480;
                double robda = 0.485; // (graden)
                //double robda_ingraden = robda * 180 / Math.PI;
                double xrotrob = 0;
                double yrotrob = 0;

                //geladen_xml.Resultaat.X = 1072.91;
                //geladen_xml.Resultaat.Y = 577.29;
                //geladen_xml.Resultaat.A = -0.02866;

                //xrotrob = 1000 * ( Math.Cos(robda) * geladen_xml.Resultaat.X + Math.Sin(robda) * geladen_xml.Resultaat.Y);
                //yrotrob = 1000 * (-1 * Math.Sin(robda) * geladen_xml.Resultaat.X + Math.Cos(robda) * geladen_xml.Resultaat.Y);

                xrotrob = 1000 *  geladen_xml.Resultaat.X;
                yrotrob = 1000 *  geladen_xml.Resultaat.Y;


                pickup_x = robdx - xrotrob;
                pickup_y = robdy + yrotrob;
                pickup_a = ( geladen_xml.Resultaat.A + robda);

                m_opname_A = pickup_a;
                m_opname_X = pickup_x;
                m_opname_Y = pickup_y;
                #endregion
                step = 1;
                #region tijdelijke variabelen
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
                step = 2;
                #region algemene toekenning
                m_voorvlak = 0;
                m_jobname = geladen_xml.Kommentar;
                m_config = configref;
                m_selector = selector;
                m_lenght = Convert.ToInt32(Convert.ToDouble(geladen_xml.Laenge.Replace(".", ",")));
                m_width = Convert.ToInt32(Convert.ToDouble(geladen_xml.Breite.Replace(".", ",")));
                m_height = Convert.ToInt32(Convert.ToDouble(geladen_xml.Dicke.Replace(".", ",")));



                //TODO:voorvlak
                //m_voorvlak = Convert.ToInt32(tempini.IniReadValue("JobWrite2", "i21"));
                //TODO:ankergaten
                //m_ankergaten.Clear();
                //for (int i = 1; i <= 8; ++i)
                //{
                //    double x = Convert.ToDouble(tempini.IniReadValue("VV", "x" + i));
                //    double y = Convert.ToDouble(tempini.IniReadValue("VV", "y" + i));
                //    m_ankergaten.Add(new Kpoint(x, y));
                //}
                //if (m_ankergaten.Count != 8)
                //{
                //    //error
                //}

                m_presetnr = 1;
                m_materiaalnr = 1;
                #endregion
                step = 3;
                #region basis geometrie
                double l = (double)m_lenght / 2;
                double b = (double)m_width / 2;
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
                step = 4;
                #region gewicht
                m_gewicht = (gewicht(m_pointlist, m_height));
                #endregion
               // throw new Exception();
                step = 5;
                #region jobzijdes
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
                    m_zijdes.Add(new Zijde());
                    m_zijdes[m_zijdes.Count - 1].m_Xstrt = m_pointlist[i1].Y;
                    m_zijdes[m_zijdes.Count - 1].m_Xend = m_pointlist[i2].Y;
                    m_zijdes[m_zijdes.Count - 1].m_Ystrt = m_pointlist[i1].X;
                    m_zijdes[m_zijdes.Count - 1].m_Yend = m_pointlist[i2].X;

                    m_zijdes[m_zijdes.Count - 1].m_lengte_a = calc_distance(new Point((int)m_zijdes[m_zijdes.Count - 1].m_Xstrt, (int)m_zijdes[m_zijdes.Count - 1].m_Ystrt), new Point((int)m_zijdes[m_zijdes.Count - 1].m_Xend, (int)m_zijdes[m_zijdes.Count - 1].m_Yend));
                    m_zijdes[m_zijdes.Count - 1].m_lengte_b = 0;
                    m_zijdes[m_zijdes.Count - 1].m_lengte_c = 0;

                    m_zijdes[m_zijdes.Count - 1].m_ank1 = 0;
                    m_zijdes[m_zijdes.Count - 1].m_ank2 = 0;
                    m_zijdes[m_zijdes.Count - 1].m_ank3 = 0;

                    m_zijdes[m_zijdes.Count - 1].m_ankdist = 0;
                    m_zijdes[m_zijdes.Count - 1].m_ankdepth = 0;
                    m_zijdes[m_zijdes.Count - 1].m_ankdia = 0;



                    #region Falldornbohrung
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Falldornbohrung();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Falldornbohrung();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Falldornbohrung();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Falldornbohrung();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        if (i == 0 )
                        {
                          //  if (m_zijdes[m_zijdes.Count - 1].m_ank1 == 0)
                            //{
                                m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.F4;
                                m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.F3;
                                m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.F2;
                                m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.F1;
                                m_ankergaten.Add(new Kpoint(tempbearbeitung.F4, tempbearbeitung.F7, Convert.ToDouble(tempbearbeitung.F6)));
                         //   }
                        //    else
                         //   {
                                m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.F4; 
                                m_ankergaten.Add(new Kpoint(m_lenght-tempbearbeitung.F4, tempbearbeitung.F7, Convert.ToDouble(tempbearbeitung.F6)));
                        //    }
                         
                        }
                        if (i == 1)
                        {
                          //  if (m_zijdes[m_zijdes.Count - 1].m_ank1 == 0)
                          //  {
                                m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.F4;
                                m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.F3;
                                m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.F2;
                                m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.F1;
                                m_ankergaten.Add(new Kpoint(tempbearbeitung.F7, tempbearbeitung.F4, Convert.ToDouble(tempbearbeitung.F6)));
                          //  }
                          //  else
                          //  {
                                m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.F4;
                                m_ankergaten.Add(new Kpoint(tempbearbeitung.F7,m_width-tempbearbeitung.F4,  Convert.ToDouble(tempbearbeitung.F6)));
                           // }
                        }
                        if (i == 2)
                        {
                          //  if (m_zijdes[m_zijdes.Count - 1].m_ank1 == 0)
                          //  {
                                m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.F4;
                                m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.F3;
                                m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.F2;
                                m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.F1;
                                m_ankergaten.Add(new Kpoint(tempbearbeitung.F4, m_width-tempbearbeitung.F7, Convert.ToDouble(tempbearbeitung.F6)));
                           // }
                         //   else
                          //  {
                                m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.F4;
                                m_ankergaten.Add(new Kpoint(m_lenght-tempbearbeitung.F4,  m_width-tempbearbeitung.F7, Convert.ToDouble(tempbearbeitung.F6)));
                         //   }
                        }
                        if (i == 3)
                        {
                         //   if (m_zijdes[m_zijdes.Count - 1].m_ank1 == 0)
                          //  {
                                m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.F4;
                                m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.F3;
                                m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.F2;
                                m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.F1;
                                m_ankergaten.Add(new Kpoint( m_lenght-tempbearbeitung.F7,m_width-tempbearbeitung.F4, Convert.ToDouble(tempbearbeitung.F6)));
                          //  }
                        ///    else
                        //    {
                                m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.F4;
                                m_ankergaten.Add(new Kpoint(  m_lenght-tempbearbeitung.F7,tempbearbeitung.F4, Convert.ToDouble(tempbearbeitung.F6)));
                        //    }
                        }
                    }
                    else
                    {
                        //geen toevoegen
                    }
                    #endregion


                    #region hinterschnittbohrung
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Hinterschnittbohrung();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Hinterschnittbohrung();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Hinterschnittbohrung();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Hinterschnittbohrung();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        if (i == 0)
                        {
                            m_ankergaten.Add(new Kpoint(m_lenght-tempbearbeitung.X3, tempbearbeitung.Y3, Convert.ToDouble(tempbearbeitung.X)));
                        }
                        if (i == 1)
                        {
                            m_ankergaten.Add(new Kpoint(tempbearbeitung.X1,  tempbearbeitung.Y1, Convert.ToDouble(tempbearbeitung.X)));
                        }
                        if (i == 2)
                        {
                            m_ankergaten.Add(new Kpoint(tempbearbeitung.X2, m_width - tempbearbeitung.Y2, Convert.ToDouble(tempbearbeitung.X)));
                        }
                        if (i == 3)
                        {
                            m_ankergaten.Add(new Kpoint(m_lenght - tempbearbeitung.X4, m_width - tempbearbeitung.Y4, Convert.ToDouble(tempbearbeitung.X)));
                        }
                    }
                    else
                    {
                        //geen toevoegen
                    }
                    #endregion
                    #region AFS
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Fase();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Fase();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Fase();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Fase();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].m_afsy = tempbearbeitung.F1;
                        m_zijdes[m_zijdes.Count - 1].m_afsz = tempbearbeitung.F2;

                        double d = Math.Atan((double)m_zijdes[m_zijdes.Count - 1].m_afsy / (double)m_zijdes[m_zijdes.Count - 1].m_afsz);
                        d = d * 180;/// Math.PI;
                        d /= Math.PI;
                        m_zijdes[m_zijdes.Count - 1].m_hoek_afs = Convert.ToInt32(d * 100);

                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin = Math.Sqrt((Math.Pow(m_zijdes[m_zijdes.Count - 1].m_afsy, 2)) + (Math.Pow(m_zijdes[m_zijdes.Count - 1].m_afsz, 2)));
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest = m_height - m_zijdes[m_zijdes.Count - 1].m_afsz;

                        //Default
                        m_materiaalnr_schuin = 1;
                        m_presetnr_schuin = 1;

                        afsmustoggle = true;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].m_afsy = 0;
                        m_zijdes[m_zijdes.Count - 1].m_afsz = 0;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                    }
                    #endregion
                    #region MUS
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Gehrungsschnitt();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Gehrungsschnitt();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Gehrungsschnitt();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Gehrungsschnitt();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].m_musy = tempbearbeitung.Y;
                        m_zijdes[m_zijdes.Count - 1].m_musz = tempbearbeitung.Z;

                        double d = Math.Atan((double)m_zijdes[m_zijdes.Count - 1].m_musz / (double)m_zijdes[m_zijdes.Count - 1].m_musy);
                        d = d * -180;/// Math.PI;
                        d /= Math.PI;
                        m_zijdes[m_zijdes.Count - 1].m_hoek_mus = Convert.ToInt32(d * 100);

                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin = Math.Sqrt((Math.Pow(m_zijdes[m_zijdes.Count - 1].m_musy, 2)) + (Math.Pow(m_zijdes[m_zijdes.Count - 1].m_musz, 2)));
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest = m_height - m_zijdes[m_zijdes.Count - 1].m_musy;

                        //Default
                        m_materiaalnr_schuin = 1;
                        m_presetnr_schuin = 1;

                        afsmustoggle = true;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].m_musy = 0;
                        m_zijdes[m_zijdes.Count - 1].m_musz = 0;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                    }
                    #endregion
                    #region sichtkant und fase
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Sichtkant_und_Fase();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Sichtkant_und_Fase();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Sichtkant_und_Fase();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Sichtkant_und_Fase();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].F1 = tempbearbeitung.F1;
                        m_zijdes[m_zijdes.Count - 1].F2 = tempbearbeitung.F2;
                        m_zijdes[m_zijdes.Count - 1].F3 = tempbearbeitung.F3;
                        m_zijdes[m_zijdes.Count - 1].F4 = tempbearbeitung.F4;
                        m_zijdes[m_zijdes.Count - 1].ofl = tempbearbeitung.OFL;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = edgev;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;

                        m_zijdes[m_zijdes.Count - 1].m_brdr_a = border;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_c = 0;

                        m_zijdes[m_zijdes.Count - 1].m_edgea_a = edgea;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_c = 0;
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].F1 = 0;
                        m_zijdes[m_zijdes.Count - 1].F2 = 0;
                        m_zijdes[m_zijdes.Count - 1].F3 = 0;
                        m_zijdes[m_zijdes.Count - 1].F4 = 0;
                        m_zijdes[m_zijdes.Count - 1].ofl = 0;
                        //Fase
                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                        //Sichtkante
                        m_zijdes[m_zijdes.Count - 1].m_brdr_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_c = 0;

                        m_zijdes[m_zijdes.Count - 1].m_edgea_a = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_c = 0;
                    }
                    #endregion
                    #region geschliffene Kante
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.geschliffene_Kante();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.geschliffene_Kante();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.geschliffene_Kante();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.geschliffene_Kante();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].F1 = tempbearbeitung.F1;
                        m_zijdes[m_zijdes.Count - 1].F2 = tempbearbeitung.F2;
                        m_zijdes[m_zijdes.Count - 1].F3 = tempbearbeitung.F3;
                        m_zijdes[m_zijdes.Count - 1].F4 = tempbearbeitung.F4;
                        m_zijdes[m_zijdes.Count - 1].ofl = tempbearbeitung.OFL;

                        m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;// edgev;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;

                        m_zijdes[m_zijdes.Count - 1].m_brdr_a = border;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_brdr_c = 0;

                        m_zijdes[m_zijdes.Count - 1].m_edgea_a = 0;// edgea;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_b = 0;
                        m_zijdes[m_zijdes.Count - 1].m_edgea_c = 0;
                    }
                    else
                    {
                        //als er al een sichkant+fase is niet op 0 zetten
                        //m_zijdes[m_zijdes.Count - 1].F1 = 0;
                        //m_zijdes[m_zijdes.Count - 1].F2 = 0;
                        //m_zijdes[m_zijdes.Count - 1].F3 = 0;
                        //m_zijdes[m_zijdes.Count - 1].F4 = 0;
                        //m_zijdes[m_zijdes.Count - 1].ofl = 0;
                        ////Fase
                        //m_zijdes[m_zijdes.Count - 1].m_edgev_a = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_edgev_b = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_edgev_c = 0;
                        ////Sichtkante
                        //m_zijdes[m_zijdes.Count - 1].m_brdr_a = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_brdr_b = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_brdr_c = 0;

                        //m_zijdes[m_zijdes.Count - 1].m_edgea_a = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_edgea_b = 0;
                        //m_zijdes[m_zijdes.Count - 1].m_edgea_c = 0;
                    }
                    #endregion
                    #region ankergaten
                    switch (i)
                    {
                        case 0://1 onder
                            tempbearbeitung = geladen_xml.Seite4.Ankergaten();
                            break;
                        case 1://2 links
                            tempbearbeitung = geladen_xml.Seite1.Ankergaten();
                            break;
                        case 2://3 boven
                            tempbearbeitung = geladen_xml.Seite2.Ankergaten();//2
                            break;
                        case 3://4 rechts
                            tempbearbeitung = geladen_xml.Seite3.Ankergaten();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        if (i == 0)
                        {
                            m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.x1;
                            m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.x3;
                            m_zijdes[m_zijdes.Count - 1].m_ank3 = tempbearbeitung.x5;

                            m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.M;
                            m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.t;
                            m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.N;
                        }
                        if (i == 1)
                        {
                            m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.y3;
                            m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.y1;
                            m_zijdes[m_zijdes.Count - 1].m_ank3 = m_zijdes[m_zijdes.Count - 1].m_l - tempbearbeitung.y5;

                            m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.M;
                            m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.t;
                            m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.N;
                        }
                        if (i == 2)
                        {
                            m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.x4;
                            m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.x2;
                            m_zijdes[m_zijdes.Count - 1].m_ank3 = m_zijdes[m_zijdes.Count - 1].m_l - tempbearbeitung.x6;

                            m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.M;
                            m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.t;
                            m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.N;
                        }
                        if (i == 3)
                        {
                            m_zijdes[m_zijdes.Count - 1].m_ank1 = tempbearbeitung.y2;
                            m_zijdes[m_zijdes.Count - 1].m_ank2 = tempbearbeitung.y4;
                            m_zijdes[m_zijdes.Count - 1].m_ank3 = tempbearbeitung.y6;

                            m_zijdes[m_zijdes.Count - 1].m_ankdist = tempbearbeitung.M;
                            m_zijdes[m_zijdes.Count - 1].m_ankdepth = tempbearbeitung.t;
                            m_zijdes[m_zijdes.Count - 1].m_ankdia = tempbearbeitung.N;
                        }
                    }
                    else
                    {
                        ;
                    }
                    #endregion
                    #region drupgroef
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Wassernase();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Wassernase();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Wassernase();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Wassernase();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        //if (m_dgdikte == 0) { m_dgdikte = tempbearbeitung.Br; }

                        if (i == 0)//d
                        {
                            m_zijdes[m_zijdes.Count - 1].m_dgdikte = tempbearbeitung.Br;
                            m_zijdes[m_zijdes.Count - 1].m_drupdist = tempbearbeitung.AV;
                            m_zijdes[m_zijdes.Count - 1].m_drupstart = tempbearbeitung.d2;
                            m_zijdes[m_zijdes.Count - 1].m_drupstop = m_zijdes[m_zijdes.Count - 1].m_lengte_a - tempbearbeitung.d1;
                        }
                        if (i == 1) //a
                        {
                            m_zijdes[m_zijdes.Count - 1].m_dgdikte = tempbearbeitung.Br;
                            m_zijdes[m_zijdes.Count - 1].m_drupdist = tempbearbeitung.AV;
                            m_zijdes[m_zijdes.Count - 1].m_drupstart = tempbearbeitung.a1;
                            m_zijdes[m_zijdes.Count - 1].m_drupstop = m_zijdes[m_zijdes.Count - 1].m_lengte_a - tempbearbeitung.a2;
                        }
                        if (i == 2) //b
                        {
                            m_zijdes[m_zijdes.Count - 1].m_dgdikte = tempbearbeitung.Br;
                            m_zijdes[m_zijdes.Count - 1].m_drupdist = tempbearbeitung.AV;
                            m_zijdes[m_zijdes.Count - 1].m_drupstart = tempbearbeitung.b1;
                            m_zijdes[m_zijdes.Count - 1].m_drupstop = m_zijdes[m_zijdes.Count - 1].m_lengte_a - tempbearbeitung.b2;
                        }
                        if (i == 3)//c
                        {
                            m_zijdes[m_zijdes.Count - 1].m_dgdikte = tempbearbeitung.Br;
                            m_zijdes[m_zijdes.Count - 1].m_drupdist = tempbearbeitung.AV;
                            m_zijdes[m_zijdes.Count - 1].m_drupstart = tempbearbeitung.c2;
                            m_zijdes[m_zijdes.Count - 1].m_drupstop = m_zijdes[m_zijdes.Count - 1].m_lengte_a - tempbearbeitung.c1;
                        }
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].m_drupstart = 0;
                        m_zijdes[m_zijdes.Count - 1].m_drupstop = 0;
                        m_zijdes[m_zijdes.Count - 1].m_dgdikte = 0;
                        m_zijdes[m_zijdes.Count - 1].m_drupdist = 0;
                    }
                    #endregion
                    #region Fugenfalz
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Fugenfalz();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Fugenfalz();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Fugenfalz();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Fugenfalz();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].m_cutoutdiepte = tempbearbeitung.X;
                        m_zijdes[m_zijdes.Count - 1].m_cutoutdikte = tempbearbeitung.Y;
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].m_cutoutdiepte = 0;
                        m_zijdes[m_zijdes.Count - 1].m_cutoutdikte = 0;
                    }
                    #endregion
                    #region kalibrierung
                    switch (i)
                    {
                        case 0:
                            tempbearbeitung = geladen_xml.Seite4.Kalibrierung();
                            break;
                        case 1:
                            tempbearbeitung = geladen_xml.Seite1.Kalibrierung();
                            break;
                        case 2:
                            tempbearbeitung = geladen_xml.Seite2.Kalibrierung();
                            break;
                        case 3:
                            tempbearbeitung = geladen_xml.Seite3.Kalibrierung();
                            break;
                    }
                    if (tempbearbeitung != null)
                    {
                        m_zijdes[m_zijdes.Count - 1].m_calibdiepte = tempbearbeitung.KT;
                        m_zijdes[m_zijdes.Count - 1].m_calibdikte = tempbearbeitung.RD;
                    }
                    else
                    {
                        m_zijdes[m_zijdes.Count - 1].m_calibdiepte = 0;
                        m_zijdes[m_zijdes.Count - 1].m_calibdikte = 0;
                    }
                    #endregion

                }
                #endregion
                step = 6;
                #region hoeken
                #region hoek1
                tempbearbeitung = geladen_xml.Seite1.hoek();
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
                    l11 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite1.Bearbeitung1.a1));//* 10
                    l12 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite1.Bearbeitung1.a2));//* 10
                }
                else
                {
                    hoek1 = 0;
                    l11 = 0;
                    l12 = 0;
                }
                #endregion
                #region hoek2
                tempbearbeitung = geladen_xml.Seite2.hoek();
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
                    l21 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite2.Bearbeitung1.b1));//* 10
                    l22 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite2.Bearbeitung1.b2));//* 10
                }
                else
                {
                    hoek2 = 0;
                    l21 = 0;
                    l22 = 0;
                }
                #endregion
                #region hoek3
                tempbearbeitung = geladen_xml.Seite3.hoek();
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
                    l31 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite3.Bearbeitung1.c1));//* 10
                    l32 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite3.Bearbeitung1.c2));//* 10
                }
                else
                {
                    hoek3 = 0;
                    l31 = 0;
                    l32 = 0;
                }
                #endregion
                #region hoek4
                tempbearbeitung = geladen_xml.Seite4.hoek();
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
                    l41 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite4.Bearbeitung1.d1));//* 10
                    l42 = Convert.ToInt32(Convert.ToDouble(geladen_xml.Seite4.Bearbeitung1.d2));//* 10
                }
                else
                {
                    hoek4 = 0;
                    l41 = 0;
                    l42 = 0;
                }
                #endregion
                #endregion
                step = 7;
                #region hoeken afzagen
                if (hoek1 > 0)
                {
                    //hoek 1 afkappen 
                    //origineel
                    m_pointlist[1] = new Kpoint(m_pointlist[1].X - l11, m_pointlist[1].Y, 1);
                    m_pointlist[2] = new Kpoint(m_pointlist[2].X, m_pointlist[2].Y - l12, 0);//hoek1);
                }

                if (hoek2 > 0)
                {
                    //hoek 2 afkappen 
                    m_pointlist[3] = new Kpoint(m_pointlist[3].X, m_pointlist[3].Y + l22, 1);
                    m_pointlist[4] = new Kpoint(m_pointlist[4].X - l21, m_pointlist[4].Y, 0);//hoek2);
                }

                if (hoek3 > 0)
                {
                    //hoek 3 afkappen 
                    m_pointlist[5] = new Kpoint(m_pointlist[5].X + l31, m_pointlist[5].Y, 1);
                    m_pointlist[6] = new Kpoint(m_pointlist[6].X, m_pointlist[6].Y + l32, 0);//hoek3);
                }

                if (hoek4 > 0)
                {
                    //hoek 4 afkappen 
                    //origineel
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
                    if (hoek4 > 0) { m_zijdes.Insert(4, new Zijde()); m_zijdes[4].m_zagen = hoek4; }
                    if (hoek3 > 0) { m_zijdes.Insert(3, new Zijde()); m_zijdes[3].m_zagen = hoek3; }
                    if (hoek2 > 0) { m_zijdes.Insert(2, new Zijde()); m_zijdes[2].m_zagen = hoek2; }
                    if (hoek1 > 0) { m_zijdes.Insert(1, new Zijde()); m_zijdes[1].m_zagen = hoek1; }
                }
                for (int i = 0; i < m_pointlist.Count; ++i)
                {
                    int i2 = i + 1;
                    if (i2 == m_pointlist.Count) { i2 = 0; }
                    //punt zelf
                    m_zijdes[i].m_Xstrt = m_pointlist[i].Y;
                    m_zijdes[i].m_Xend = m_pointlist[i2].Y;
                    m_zijdes[i].m_Ystrt = m_pointlist[i].X;
                    m_zijdes[i].m_Yend = m_pointlist[i2].X;
                    m_zijdes[i].m_lengte_a = calc_distance(new Point((int)m_zijdes[i].m_Xstrt, (int)m_zijdes[i].m_Ystrt), new Point((int)m_zijdes[i].m_Xend, (int)m_zijdes[i].m_Yend));

                    m_zijdes[i].m_singzone = new SingZone(m_zijdes[m_zijdes.Count - 1], this);
                }
                #endregion
                step = 8;
                #region create
                Create();
                #endregion
                step = 9;
                try
                {
                    geladen_xml.Check_waardes(200);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                double ankerdiepte = Convert.ToDouble(configref.IniReadValue("Settings", "drup_depth"));
                if (ankerdiepte < 0 || ankerdiepte > 10) { throw new Exception(); }
                step = 10;
                #region > 80
                if (m_height > 80)
                {
                    for (int i = 0; i < m_zijdes.Count; ++i)
                    {
                        m_zijdes[i].m_edgev_a = 0;
                        m_zijdes[i].m_edgev_b = 0;
                        m_zijdes[i].m_edgev_c = 0;

                        m_zijdes[i].m_edgea_a = 0;
                        m_zijdes[i].m_edgea_b = 0;
                        m_zijdes[i].m_edgea_c = 0;
                        m_zijdes[i].m_zagen = 0;
                        if (m_zijdes[i].m_brdr_a != 5 && m_zijdes[i].m_brdr_a != 6 && m_zijdes[i].m_brdr_a != 7 && m_zijdes[i].m_brdr_a != 8)
                        {
                            m_zijdes[i].m_brdr_a = 0;
                        }
                        if (m_zijdes[i].m_brdr_b != 5 && m_zijdes[i].m_brdr_b != 6 && m_zijdes[i].m_brdr_b != 7 && m_zijdes[i].m_brdr_b != 8)
                        {
                            m_zijdes[i].m_brdr_b = 0;
                        }
                        if (m_zijdes[i].m_brdr_c != 5 && m_zijdes[i].m_brdr_c != 6 && m_zijdes[i].m_brdr_c != 7 && m_zijdes[i].m_brdr_c != 8)
                        {
                            m_zijdes[i].m_brdr_c = 0;
                        }

                        m_zijdes[i].m_hoek_afs = 0;
                        m_zijdes[i].m_hoek_mus = 0;

                        m_zijdes[i].m_afsy = 0;
                        m_zijdes[i].m_afsz = 0;

                        m_zijdes[i].m_musy = 0;
                        m_zijdes[i].m_musz = 0;

                        m_zijdes[i].m_x = 0;
                        m_zijdes[i].m_y = 0;

                        m_zijdes[i].m_ank1 = 0;
                        m_zijdes[i].m_ank2 = 0;
                        m_zijdes[i].m_drupstart = 0;
                        m_zijdes[i].m_drupstop = 0;

                        m_zijdes[i].m_hoek = 0;

                        m_zijdes[i].m_hoek2 = 0;
                    }
                }
                #endregion
                step = 11;
                #region materiaal bepalen
                
                
                HashSet<int> uniquelist = new HashSet<int>();

                for(int i = 0; i < m_zijdes.Count; ++i)
                {
                    if (m_zijdes[i].ofl != 0 && m_zijdes[i].ofl != -1)
                    {
                        uniquelist.Add(m_zijdes[i].ofl);
                    }
                }
                if (uniquelist.Count > 1)
                {
                    throw new Exception("verschillende afwerkingen op verschillende zijdes");
                }
                else
                {
                    if (uniquelist.Count > 0)
                    {
                        //TODO: materiaal bepalen
                        int nr = uniquelist.ElementAt(0);

                        int quot = Convert.ToInt32(Math.Floor(Convert.ToDouble(nr) / 10));
                        int rest = nr - (quot * 10);
                        if (rest>0 && rest<=9){
                            m_presetnr = rest;
                        }
                        else m_presetnr = 1;
                        if (quot>0 && quot <=6)
                        {
                            m_materiaalnr = quot;
                        }
                        else m_materiaalnr = 1;
                    }
                    else 
                    {
                        m_materiaalnr = 1;
                        m_presetnr = 1;
                    }

                    //ANDERS IS JOBWRITE 4 LEEG -> SLAFS AFSBRD LEEG
                    m_materiaalnr_schuin = m_materiaalnr;
                    m_presetnr_schuin = m_presetnr;

                    m_materiaalnr_recht = m_materiaalnr;
                    m_presetnr_recht= m_presetnr;
                    
                }
                #endregion
            }
            catch(Exception ex)
            {
                string message = "";
                switch (step)
                {
                    case 0:
                        message = "Error in de locatie stap";
                        break;
                    case 1:
                        message = "Error in de tijdelijke variabele stap";
                        break;
                    case 2:
                        message = "Error in de algemene toekenning stap";
                        break;
                    case 3:
                        message = "Error in de basis geometrie stap";
                        break;
                    case 4:
                        message = "Error in de gewicht stap";
                        break;
                    case 5:
                        message = "Error in de jobzijde stap";
                        break;
                    case 6:
                        message = "Error in de hoeken stap";
                        break;
                    case 7:
                        message = "Error in de hoeken afzagen stap";
                        break;
                    case 8:
                        message = "Error in de create stap";
                        break;
                    case 9:
                        message = "Error in de checkwaardes : " + ex.Message;
                        break;
                    case 10:
                        message = "Error in de dikte groter dan 80 stap";
                        break;
                }
                throw new Exception(message, ex.InnerException);
            }
        }

        public Job_def(string inifilename_metdotini, ref Gripperselecter selector, ref IniFile configref)
        {
            #region algemene toekenning
            m_jobname = inifilename_metdotini;

            m_config = configref;
            m_selector = selector;

            string temppath = Application.StartupPath + "\\" + inifilename_metdotini; //+ ".ini"

            if (File.Exists(temppath) == false) { throw new Exception("file bestaat niet"); }

            IniFile tempini = new IniFile(temppath);

            m_voorvlak = Convert.ToInt32(tempini.IniReadValue("JobWrite2", "i21"));

            m_lenght = Convert.ToInt32(tempini.IniReadValue("JobWrite0", "i1"));
            m_width = Convert.ToInt32(tempini.IniReadValue("JobWrite0", "i2"));
            m_height = Convert.ToInt32(tempini.IniReadValue("JobWrite0", "i3"));

            m_ankergaten.Clear();
            for (int i = 1; i <= 8; ++i)
            {
                double x = Convert.ToDouble(tempini.IniReadValue("VV", "x" + i));
                double y = Convert.ToDouble(tempini.IniReadValue("VV", "y" + i));
                m_ankergaten.Add(new Kpoint(x, y));
            }
            if (m_ankergaten.Count != 8)
            {
                //error
            }

            if (tempini.IniReadValue("settings", "matnr") != "" && tempini.IniReadValue("settings", "presetnr") != "" && tempini.IniReadValue("settings", "afw") == "")
            {
                m_presetnr = Convert.ToInt32(tempini.IniReadValue("settings", "presetnr"));
                m_materiaalnr = Convert.ToInt32(tempini.IniReadValue("settings", "matnr"));
                switch (m_presetnr)
                {
                    case 1:
                        m_afw = "GRS";
                        break;
                    case 2:
                        m_afw = "BLS";
                        break;
                    case 3:
                        m_afw = "ZOE";
                        break;
                    case 4:
                        m_afw = "POL";
                        break;
                    case 5:
                        m_afw = "GRS";
                        break;
                    case 6:
                        m_afw = "BLS";
                        break;
                    case 7:
                        m_afw = "ZOE";
                        break;
                    case 8:
                        m_afw = "POL";
                        break;
                }
            }
            else if (tempini.IniReadValue("settings", "matnr") == "" && tempini.IniReadValue("settings", "presetnr") == "" && tempini.IniReadValue("settings", "afw") != "")
            {
                m_afw = tempini.IniReadValue("settings", "afw");
                materiaal_bepalen(m_height, ref m_materiaalnr, ref m_presetnr, m_afw);
            }
            else { MessageBox.Show("materiaal error"); }


            #endregion

            #region blad + gewicht
            for (int i = 1; i < 9; ++i)
            {
                Kpoint temp = new Kpoint();
                Kpoint temp2 = new Kpoint();
                temp.Y = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i1"));//omdraaien assenstelsel
                temp.X = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i3"));
                temp2.Y = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i2"));
                temp2.X = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i4"));

                if ((temp.X != 0 && temp.Y != 0) || (temp2.X != 0 && temp2.Y != 0))
                {
                    m_pointlist.Add(temp);

                    m_zijdes.Add(new Zijde());
                    m_zijdes[m_zijdes.Count - 1].m_Xstrt = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i1"));
                    m_zijdes[m_zijdes.Count - 1].m_Xend = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i2"));
                    m_zijdes[m_zijdes.Count - 1].m_Ystrt = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i3"));
                    m_zijdes[m_zijdes.Count - 1].m_Yend = Convert.ToDouble(tempini.IniReadValue("JobZijde" + i.ToString(), "i4"));
                    m_zijdes[m_zijdes.Count - 1].m_zagen = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i5"));
                    m_zijdes[m_zijdes.Count - 1].m_lengte_a = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i6"));
                    m_zijdes[m_zijdes.Count - 1].m_edgev_a = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i7"));
                    m_zijdes[m_zijdes.Count - 1].m_brdr_a = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i8"));
                    m_zijdes[m_zijdes.Count - 1].m_edgea_a = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i9"));
                    m_zijdes[m_zijdes.Count - 1].m_lengte_b = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i10"));
                    m_zijdes[m_zijdes.Count - 1].m_edgev_b = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i11"));
                    m_zijdes[m_zijdes.Count - 1].m_brdr_b = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i12"));
                    m_zijdes[m_zijdes.Count - 1].m_edgea_b = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i13"));
                    m_zijdes[m_zijdes.Count - 1].m_lengte_c = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i14"));
                    m_zijdes[m_zijdes.Count - 1].m_edgev_c = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i15"));
                    m_zijdes[m_zijdes.Count - 1].m_brdr_c = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i16"));
                    m_zijdes[m_zijdes.Count - 1].m_edgea_c = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i17"));
                    m_zijdes[m_zijdes.Count - 1].m_afsy = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i18"));
                    m_zijdes[m_zijdes.Count - 1].m_afsz = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i19"));
                    m_zijdes[m_zijdes.Count - 1].m_musy = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i20"));
                    m_zijdes[m_zijdes.Count - 1].m_musz = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i21"));
                    m_zijdes[m_zijdes.Count - 1].m_ank1 = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i22"));
                    m_zijdes[m_zijdes.Count - 1].m_ank2 = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i23"));
                    m_zijdes[m_zijdes.Count - 1].m_drupstart = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i24"));
                    m_zijdes[m_zijdes.Count - 1].m_drupstop = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i25"));
                    m_zijdes[m_zijdes.Count - 1].m_hoek = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i26"));

                    m_zijdes[m_zijdes.Count - 1].m_opnamenr = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i28"));
                    
                    m_zijdes[m_zijdes.Count - 1].m_ank3 = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i31"));
                    m_zijdes[m_zijdes.Count - 1].m_cutoutdiepte = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i32"));
                    m_zijdes[m_zijdes.Count - 1].m_cutoutdikte = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i33"));
                    m_zijdes[m_zijdes.Count - 1].m_calibdiepte = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i34"));
                    m_zijdes[m_zijdes.Count - 1].m_calibdikte = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i35"));

                    m_zijdes[m_zijdes.Count - 1].m_dgdikte = Convert.ToInt32(tempini.IniReadValue("JobZijde" + i.ToString(), "i38"));

                    //hoek van de afs of mus berekenen  
                    //afs1 moet y zijn
                    if (m_zijdes[m_zijdes.Count - 1].m_afsy > 0 && m_zijdes[m_zijdes.Count - 1].m_afsz > 0)
                    {
                        double d = Math.Atan((double)m_zijdes[m_zijdes.Count - 1].m_afsy / (double)m_zijdes[m_zijdes.Count - 1].m_afsz);
                        d = d * 180;/// Math.PI;
                        d /= 3.14;// Math.PI;
                        m_zijdes[m_zijdes.Count - 1].m_hoek_afs = Convert.ToInt32(d * 100);
                        //m_zijdes[m_zijdes.Count - 1].m_typenaam = "AFS"; //voor de tekening

                        //afs
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin = Math.Sqrt((Math.Pow(m_zijdes[m_zijdes.Count - 1].m_afsy, 2)) + (Math.Pow(m_zijdes[m_zijdes.Count - 1].m_afsz, 2)));
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest = m_height - m_zijdes[m_zijdes.Count - 1].m_afsz;
                        //m_zijdes[m_zijdes.Count - 1].m_typenaam = "AFS"; //voor de tekening
                        materiaal_bepalen((int)m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin, ref m_materiaalnr_schuin, ref m_presetnr_schuin, m_afw);
                        materiaal_bepalen((int)m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest, ref m_materiaalnr_recht, ref m_presetnr_recht, m_afw);

                    }
                    else if (m_zijdes[m_zijdes.Count - 1].m_musy > 0 && m_zijdes[m_zijdes.Count - 1].m_musz > 0)
                    {
                        double d = Math.Atan((double)m_zijdes[m_zijdes.Count - 1].m_musy / (double)m_zijdes[m_zijdes.Count - 1].m_musz);
                        d = d * 180 / Math.PI;
                        m_zijdes[m_zijdes.Count - 1].m_hoek_mus = Convert.ToInt32(d * 100) * -1;
                        //m_zijdes[m_zijdes.Count - 1].m_typenaam = "MUS"; //voor de tekening

                        //mus
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin = Math.Sqrt((Math.Pow(m_zijdes[m_zijdes.Count - 1].m_musy, 2)) + (Math.Pow(m_zijdes[m_zijdes.Count - 1].m_musz, 2)));
                        m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest = m_height - m_zijdes[m_zijdes.Count - 1].m_musz;
                        //m_zijdes[m_zijdes.Count - 1].m_typenaam = "MUS"; //voor de tekening
                        //materiaal_bepalen((int)m_zijdes[m_zijdes.Count - 1].m_afsmus_height_schuin, ref m_materiaalnr_schuin, ref m_presetnr_schuin, m_afwerkingsniveau);
                        materiaal_bepalen((int)m_zijdes[m_zijdes.Count - 1].m_afsmus_height_rest, ref m_materiaalnr_recht, ref m_presetnr_recht, m_afw);

                    }
                    else
                    {
                        //geen afs Of mus, dan laat ik mijn 2 var in de zijde op -1
                        //m_materiaalnr_schuin = -1;
                        //m_materiaalnr_recht = -1;
                        //m_presetnr_schuin = -1;
                        //m_presetnr_recht = -1;
                    }
                    m_zijdes[m_zijdes.Count - 1].m_singzone = new SingZone(m_zijdes[m_zijdes.Count - 1], this);
                }
            }



            m_gewicht = (gewicht(m_pointlist, m_height));
            #endregion

            Create();
            
        }


        public int moet_ik_zagen(Kpoint p1, Kpoint p2)
        {
            if (p1.zaagpunt == 0)
            {
                return 0;
            }

            double l = distance_twopoints(p1.Converttopoint(), p2.Converttopoint());

            if (l < 100)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        private bool moetikfrijnenzagenalgemeen()
        {
            for (int i = 0; i < m_zijdes.Count; ++i)
            {
                if (moetikfrijnenzagenzijde(i)) { return true; }
            }
            return false;
        }
        private bool moetikfrijnenzagenzijde(int zijdenr)
        {
            if (m_zijdes[zijdenr].m_zagen > 0) { return true; }
            if (m_zijdes[zijdenr].m_hoek_afs != 0) { return true; }
            if (m_zijdes[zijdenr].m_hoek_mus != 0) { return true; }
            if (m_zijdes[zijdenr].m_ank1 != 0) { return true; }
            if (m_zijdes[zijdenr].m_ank2 != 0) { return true; }
            if (m_zijdes[zijdenr].m_afsy > 0) { return true; }
            if (m_zijdes[zijdenr].m_afsz > 0) { return true; }
            if (m_zijdes[zijdenr].m_musy > 0) { return true; }
            if (m_zijdes[zijdenr].m_musz > 0) { return true; }
            if (m_zijdes[zijdenr].m_drupstart != 0) { return true; }
            if (m_zijdes[zijdenr].m_drupstop != 0) { return true; }
            if (m_zijdes[zijdenr].m_brdr_a == 6 || m_zijdes[zijdenr].m_brdr_a == 7 || m_zijdes[zijdenr].m_brdr_a == 8) { return true; }
            if (m_zijdes[zijdenr].m_brdr_b == 6 || m_zijdes[zijdenr].m_brdr_b == 7 || m_zijdes[zijdenr].m_brdr_b == 8) { return true; }
            if (m_zijdes[zijdenr].m_brdr_c == 6 || m_zijdes[zijdenr].m_brdr_c == 7 || m_zijdes[zijdenr].m_brdr_c == 8) { return true; }
            return false;
        }

        public int calc_distance(Point p1, Point p2)
        {
            double returner = 0;
            returner = Math.Sqrt(Math.Pow(p1.X - p2.X,2) + Math.Pow(p1.Y - p2.Y,2));
            return Convert.ToInt32(returner);
        }

        
        public int hoek_tussen_twee_lijnstukken(Point p1, Point p2, Point p3, Point p4)
        {
            double returner = 0;
            Rechte r1 = new Rechte(p1, p2);
            Rechte r2 = new Rechte(p3, p4);
            if ((r1.m_ishor && r2.m_isver) || (r2.m_ishor && r1.m_isver)) 
            {
                returner = 90; 
            }
            else 
            { 
                //TODO: algemene berekening
                // de rico's vermenigvuldigen en die komen dan op -1
                if (r1.m_a * r2.m_a == -1)
                {
                    returner = 90;
                }
                else
                {
                    //cos = u * v delen door lengte u * lengte v     (inwendig product)
                    double d1 = calc_distance(p1, p2);
                    double d2 = calc_distance(p3, p4);
                    returner = (double)((p1.X * p2.X) + (p3.Y * p4.Y)) /  d1 * d2;
                    returner = Math.Acos(returner);//* 180 / Math.PI;
                }
            }
            return Convert.ToInt32(returner);
        }

        private double ad_berekenen(double afs, double dikte)
        {
            double cos45 = Math.Cos(45.0 * Math.PI / 180);

            double c = (35.0 / cos45) -30;

            double temp =  c - (afs/cos45) -(dikte-afs)*cos45;

            if(temp > -30) { return -30;}
            else if(temp > -40) { return -40;}
            else if (temp > -50) { return -50; }
            else { return 0; }
        }

        private void Create()
        {
            //TODO: afwerking corner op 2 ipv 4 

            bool zijde_onmogelijk = false;

            #region afs dikte beperking
            //for (int i = 0; i < m_zijdes.Count; ++i)
            //{
            //    int afsy = m_zijdes[i].m_afsy;
            //    int afsz = m_zijdes[i].m_afsz;
            //    int afsa = m_zijdes[i].m_hoek_afs;
            //    if ((m_zijdes[i].m_typenaam != "AFSSP") && ((afsy > 0 && afsz > 0) || afsa != 0))
            //    {
            //        double alpha = 0;
            //        if (afsa != 0)
            //        {
            //            alpha = afsa / 100;
            //        }
            //        else
            //        {
            //            alpha = Math.Atan(afsz / afsy);
            //        }

            //        bool hoekok = true;
            //        double teshoek= Math.Abs(alpha)-45;
            //        if (teshoek < -0.1 || teshoek > 0.1)
            //        {
            //            hoekok = false; 
            //        }

            //        //check
            //        //(D-afsz) (cos(45-alpha) + sin(45-alpha)) < 70-2h

            //        //double leftside = (m_height - afsz) * (Math.Cos((45 - alpha) * Math.PI / 180) + Math.Sin((45 - alpha) * Math.PI / 180));

            //        ////h=sin(45+alpha) * y -D* cos(45+alpha)

            //        //double h = (Math.Sin((45 + alpha) * Math.PI / 180) * afsy) - (m_height * (Math.Cos((45 + alpha) * Math.PI / 180)));

            //        //double rightside = 70 - (2 * h);
                    
            //        double res = ad_berekenen(afsy, m_height);
                        
            //        if (hoekok && res!=0) //(leftside <= rightside) &&
            //        {
            //           //OK
            //            m_zijdes[i].m_ad = res;
            //           // double res = ad_berekenen(afsy, m_height);
            //         //   if(
            //        }
            //        else
            //        {
            //            //2015/02/18
            //            //opvangen in AFSZA
            //            m_zijdes[i].m_edgea_a = 0;
            //            m_zijdes[i].m_edgea_b = 0;
            //            m_zijdes[i].m_edgea_c = 0;
            //            m_zijdes[i].m_edgev_a = 0;
            //            m_zijdes[i].m_edgev_b = 0;
            //            m_zijdes[i].m_edgev_c = 0;
            //            //m_zijdes[i].m_typenaam = "AFSZA";
            //            //throw new Exception("AFS error voor deze dikte : afsy = " + afsy + " afsz = " + afsz + " dikte = " + m_height);
            //        }
            //    }
            //}
            #endregion

            #region SAFEDISTANCE (controle 400/500 edgev:a / frijn)

            int grijperonderkant = 0;
            int grijperbovenkant = 0;
            int grijperlinkerkant = 0;
            int grijperrechterkant = 0;

            //bepalen welke afwerkingen er zijn per zijde
            for (int i = 0; i < m_zijdes.Count; ++i)
            {
                m_nietsdoen = false;
                m_bordersdoen = false;
                m_edgesdoen = false;
                m_drupdoen = false;
                m_ankerdoen = false;
                m_zaagdoen = false;

                if(zijdeleeg(i))
                {
                    m_nietsdoen = true;
                }
                else
                {

                //border schuren
                if (m_zijdes[i].m_brdr_a == 1 || m_zijdes[i].m_brdr_a == 2 || m_zijdes[i].m_brdr_a == 3) { m_bordersdoen = true; }
                if (m_zijdes[i].m_brdr_b == 1 || m_zijdes[i].m_brdr_b == 2 || m_zijdes[i].m_brdr_b == 3) { m_bordersdoen = true; }
                if (m_zijdes[i].m_brdr_c == 1 || m_zijdes[i].m_brdr_c == 2 || m_zijdes[i].m_brdr_c == 3) { m_bordersdoen = true; }

                //edges bewerken
                if (m_zijdes[i].m_edgev_a == 11 || m_zijdes[i].m_edgev_a == 12 ) { m_edgesdoen = true; }
                if (m_zijdes[i].m_edgev_b == 11 || m_zijdes[i].m_edgev_a == 12 ) { m_edgesdoen = true; }
                if (m_zijdes[i].m_edgev_c == 11 || m_zijdes[i].m_edgev_a == 12 ) { m_edgesdoen = true; }
                if (m_zijdes[i].m_edgea_a == 21 || m_zijdes[i].m_edgev_a == 22) { m_edgesdoen = true; }
                if (m_zijdes[i].m_edgea_b == 21 || m_zijdes[i].m_edgev_a == 22) { m_edgesdoen = true; }
                if (m_zijdes[i].m_edgea_c == 21 || m_zijdes[i].m_edgev_a ==22) { m_edgesdoen = true; }

                //drupgroef
                if (m_zijdes[i].m_drupstart >= 0 && m_zijdes[i].m_drupstop > 0) { m_drupdoen = true; }

                //ankergaten
                if (m_zijdes[i].m_ank1 > 0 && m_zijdes[i].m_ank2 > 0) { m_ankerdoen = true; }

                //zagen
                if (m_zijdes[i].m_zagen == 1 || m_zijdes[i].m_zagen == 11 || m_zijdes[i].m_zagen == 12 || m_zijdes[i].m_zagen == 13 || m_zijdes[i].m_zagen == 14) { m_zaagdoen = true; }

                }
              
                //linksonder hoek en rechtsonder hoek en onderzijde hebben invloed op onderkant grijper
                // _______________
                //1       6       2
                //|               |
                //7               8
                //|               |
                //3_______5_______4

               
                switch (i)
                { 
                    //boven
                    case 2:
                        if (m_nietsdoen == false)
                        {
                            if (m_edgesdoen )
                            {
                                if (grijperbovenkant <2)
                                {
                                    grijperbovenkant = 2;
                                }
                            }
                            else if (m_drupdoen)
                            {
                                if (grijperbovenkant <1 )
                                {
                                    grijperbovenkant = 1;
                                }
                            }
                            else if (m_zaagdoen || m_bordersdoen || m_ankerdoen)
                            {
                                if (grijperbovenkant <0)
                                {
                                    grijperbovenkant = 0;
                                }
                            }
                           
                        }
                        else
                        {
                            //niets doen, dus eventueel zelf negatieve offset -15
                            if (grijperbovenkant == 0)
                            {
                                grijperbovenkant = -1;
                            }
                        }
                        break;
                    //onder
                    case 0:
                        if (m_nietsdoen == false)
                        {
                           if (m_edgesdoen)
                            {
                                if (grijperonderkant < 2)
                                {
                                    grijperonderkant = 2;
                                }
                            }
                            else if (m_drupdoen)
                            {
                                if (grijperonderkant < 1)
                                {
                                    grijperonderkant = 1;
                                }
                            }
                            else if (m_zaagdoen || m_bordersdoen || m_ankerdoen)
                            {
                                if (grijperonderkant < 0)
                                {
                                    grijperonderkant = 0;
                                }
                            }

                        }
                        else
                        {
                            //niets doen, dus eventueel zelf negatieve offset -15
                            if (grijperonderkant == 0)
                            {
                                grijperonderkant = -1;
                            }
                        }
                        break;
                   
                    case 1://links
                        if (m_nietsdoen == false)
                        {
                           if (m_edgesdoen)
                            {
                                if (grijperlinkerkant < 2)
                                {
                                    grijperlinkerkant = 2;
                                }
                            }
                            else if (m_drupdoen)
                            {
                                if (grijperlinkerkant < 1)
                                {
                                    grijperlinkerkant = 1;
                                }
                            }
                            else if (m_zaagdoen || m_bordersdoen || m_ankerdoen)
                            {
                                if (grijperlinkerkant < 0)
                                {
                                    grijperlinkerkant = 0;
                                }
                            }

                        }
                        else
                        {
                            //niets doen, dus eventueel zelf negatieve offset -15
                            if (grijperlinkerkant == 0)
                            {
                                grijperlinkerkant = -1;
                            }
                        }
                        break;
                    //rechts
                  
                    case 4:
                        if (m_nietsdoen == false)
                        {
                            if (m_edgesdoen)
                            {
                                if (grijperrechterkant < 2)
                                {
                                    grijperrechterkant = 2;
                                }
                            }
                            else if (m_drupdoen)
                            {
                                if (grijperrechterkant < 1)
                                {
                                    grijperrechterkant = 1;
                                }
                            }
                            else if (m_zaagdoen || m_bordersdoen || m_ankerdoen)
                            {
                                if (grijperrechterkant < 0)
                                {
                                    grijperrechterkant = 0;
                                }
                            }

                        }
                        else
                        {
                            //niets doen, dus eventueel zelf negatieve offset -15
                            if (grijperrechterkant == 0)
                            {
                                grijperrechterkant = -1;
                            }
                        }
                        break;
                }
            }
            #endregion
           
            #region grijpers die mogelijk zijn bepalen
            m_available_grippers = m_selector.Getallgrippers(m_gewicht, m_lenght, m_width);

            if (m_available_grippers.Length == 0)
            {
                MessageBox.Show("Geen grijpers voor deze afmetingen of dit gewicht gevonden.");
                //er zijn geen grijper beschikbaar die deze afmeetingen aankan
                throw (new Exception("geen grijper gevonden voor deze afmetingen"));
            }
            else
            {
                //aantal beschikbare grijpers bepalen
                 m_gripper_available = m_available_grippers.Count();
            }
            #endregion

            #region de best mogelijke grijper uit de lijst halen
            bool keeplooking = true;
            //voor elke grijper, startend met de beste, kijken of 0,0 mogelijk is
            for (int k = 0; k < m_gripper_available; ++k)
            {
                zijde_onmogelijk = false;

                if (keeplooking)
                {
                    m_bestgripperoriginal = m_available_grippers[k];
                    m_bestgripper = m_available_grippers[k];

                   if (m_bestgripper > 64)
                    {
                        if (m_bestgripper == 65) { m_bestgripper = 5; }
                        if (m_bestgripper == 66) { m_bestgripper = 6; }
                        if (m_bestgripper == 67) { m_bestgripper = 7; }
                        //m_bestgripper -= 64; 
                    }


                    int l = Convert.ToInt32(m_config.IniReadValue("Grijper" + m_bestgripper.ToString(), "minl"));
                    int b = Convert.ToInt32(m_config.IniReadValue("Grijper" + m_bestgripper.ToString(), "minb"));
                    int onderkant = 0;
                    int bovenkant = 0;
                    int linkerkant = 0;
                    int rechterkant = 0;

                     //TODO: de grijper virtueel groter maken aan de hand van safedistance als het grijper 1 of eventueel 2 is
                    //if (m_bestgripper == 1 || m_bestgripper == 5)
                    //{
                    //    //onderkant/bovenkant altijd 0 voorlopig
                    //    onderkant = 0;
                    //    bovenkant = 0;

                    //    //if (grijperonderkant == 2) { onderkant = 0; } 
                    //    //if (grijperonderkant == 1) { onderkant = 0; } 
                    //    //if (grijperonderkant == 0) { onderkant = 0; } 
                    //    //if (grijperonderkant == -1){ onderkant = 0; } 

                    //    //if (grijperbovenkant == 2) { bovenkant = 0; }
                    //    //if (grijperbovenkant == 1) { bovenkant = 0; }
                    //    //if (grijperbovenkant == 0) { bovenkant = 0; }
                    //    //if (grijperbovenkant == -1){ bovenkant = 0; }

                    //    if (grijperlinkerkant == 3) { linkerkant = 75; } //frijnene
                    //    if (grijperlinkerkant == 2) { linkerkant = 50; } //edgeva
                    //    if (grijperlinkerkant == 1) { linkerkant = 25; } //drup
                    //    if (grijperlinkerkant == 0) { linkerkant = 0;  } //veilige bewerkingen
                    //    if (grijperlinkerkant == -1){ linkerkant = -15;  } //niets

                    //    if (grijperrechterkant == 3) { rechterkant = 75; }
                    //    if (grijperrechterkant == 2) { rechterkant = 50; }
                    //    if (grijperrechterkant == 1) { rechterkant = 25; }
                    //    if (grijperrechterkant == 0) { rechterkant = 0;  }
                    //    if (grijperrechterkant == -1){ rechterkant = -15;  }

                    //    l += linkerkant + rechterkant;
                    //    b += onderkant + bovenkant;
                    //}
                    //else if (m_bestgripper == 2 || m_bestgripper == 6)
                    //{
                    //    if (grijperonderkant == 2) { onderkant = 0; } //edgeva of frijn
                    //    if (grijperonderkant == 1) { onderkant = 0; } //anker
                    //    if (grijperonderkant == 0) { onderkant = 0; }  //veilige bewerkingen
                    //    if (grijperonderkant == -1) { onderkant = 0; }  //niets

                    //    if (grijperbovenkant == 2) { bovenkant = 0; }
                    //    if (grijperbovenkant == 1) { bovenkant = 0; }
                    //    if (grijperbovenkant == 0) { bovenkant = 0; }
                    //    if (grijperbovenkant == -1) { bovenkant = 0; }

                    //    if (grijperlinkerkant == 2) { linkerkant = 10; }
                    //    if (grijperlinkerkant == 1) { linkerkant = 0; }
                    //    if (grijperlinkerkant == 0) { linkerkant = 0; }
                    //    if (grijperlinkerkant == -1) { linkerkant = -15; }

                    //    if (grijperrechterkant == 2) { rechterkant = 10; }
                    //    if (grijperrechterkant == 1) { rechterkant = 0; }
                    //    if (grijperrechterkant == 0) { rechterkant = 0; }
                    //    if (grijperrechterkant == -1) { rechterkant = -15; }

                    //    l += linkerkant + rechterkant;
                    //    b += onderkant + bovenkant;
                    //}
                    //else 
                    //{ 
                    //    //voor de andere grijpers voorlopig nog geen probleem
                    //}

                    //de groene zone moet verschoven worden over deze afstand
                    double hor_safedistance = linkerkant - rechterkant;
                    double ver_safedistance = bovenkant - onderkant;

                    l /= 2;
                    b /= 2;

                    #region inset punten bepalen
                    m_inset_pointlist.Clear();
                    m_rechtelist.Clear();
                    #region insetpoints aanmaken
                    for (int i = 0; i < m_pointlist.Count; ++i)
                    {
                        m_inset_pointlist.Add(new Kpoint(m_pointlist[i].X, m_pointlist[i].Y,0));
                    }
                    #endregion

                    #region afs in rekening brengen bij de opname bepaling
                    for (int i = 0; i < m_zijdes.Count; ++i)
                    {
                        //als er afs of mus is dan moeten we p3 en l3 berekenen
                        if (m_zijdes[i].m_hoek_afs > 0)
                        {
                           
                            int i1 = i - 1;
                            if (i1 < 0) { i1 = m_pointlist.Count - 1; }
                            int i2 = i;
                            int i3 = i2 + 1;
                            if (i3 == m_pointlist.Count) { i3 = 0; }
                            int i4 = i3 + 1;
                            if (i4 == m_pointlist.Count) { i4 = 0; }

                            if (m_zijdes[i].m_afsy != -1 && m_zijdes[i].m_afsz != -1)// gewone afs
                            {
                                Rechte r = nieuwe_evenwijdige_rechte(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint(), m_pointlist[i3].Converttopoint(), m_zijdes[i].m_afsy);
                                Kpoint p1 = snijpunt(r, new Rechte(m_inset_pointlist[i2], m_inset_pointlist[i1]));
                                Kpoint p2 = snijpunt(r, new Rechte(m_inset_pointlist[i3], m_inset_pointlist[i4]));
                                double dist = distance_twopoints(p1, p2);

                                m_inset_pointlist[i2] = new Kpoint(p1.X, p1.Y,0);
                                m_inset_pointlist[i3] = new Kpoint(p2.X, p2.Y,0);

                                m_zijdes[i].m_l = Convert.ToInt32(dist * (double)100);
                                m_zijdes[i].m_x = Convert.ToInt32(p2.X * (double)100);
                                m_zijdes[i].m_y = Convert.ToInt32(p2.Y * (double)100);
                            }
                            //else
                            //{ //vbi
                            //    double lengtevbi = 0;
                              
                            //    double hoek = Math.PI*(m_zijdes[i].m_hoek_afs) / 18000;

                            //    lengtevbi = (double)m_height * Math.Tan(hoek)-1;

                            //    Rechte r = nieuwe_evenwijdige_rechte(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint(), m_pointlist[i3].Converttopoint(), lengtevbi);
                            //    Kpoint p1 = snijpunt(r, new Rechte(m_inset_pointlist[i2], m_inset_pointlist[i1]));
                            //    Kpoint p2 = snijpunt(r, new Rechte(m_inset_pointlist[i3], m_inset_pointlist[i4]));
                            //    double dist = distance_twopoints(p1, p2);

                            //    m_inset_pointlist[i2] = new Kpoint(p1.X, p1.Y,0);
                            //    m_inset_pointlist[i3] = new Kpoint(p2.X, p2.Y,0);

                            //    m_zijdes[i].m_l = Convert.ToInt32(dist * (double)100);
                            //    m_zijdes[i].m_x = Convert.ToInt32(p2.X * (double)100);
                            //    m_zijdes[i].m_y = Convert.ToInt32(p2.Y * (double)100);

                            //    m_zijdes[i].m_vbilengte = lengtevbi;
                            //}
                        }
                        else if (m_zijdes[i].m_hoek_mus != 0)
                        {
                            int i1 = i - 1;
                            if (i1 < 0) { i1 = m_pointlist.Count - 1; }
                            int i2 = i;
                            int i3 = i2 + 1;
                            if (i3 == m_pointlist.Count) { i3 = 0; }
                   
                            int i4 = i3 + 1;
                            if (i4 == m_pointlist.Count) { i4 = 0; }

                            if (m_zijdes[i].m_musy != -1 && m_zijdes[i].m_musz != -1)// gewone mus		m_brdr_c	0	int

                            {
                                Rechte r = nieuwe_evenwijdige_rechte(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint(), m_pointlist[i3].Converttopoint(), m_zijdes[i].m_musy);
                                Kpoint p1 = snijpunt(r, new Rechte(m_inset_pointlist[i2], m_inset_pointlist[i1]));
                                Kpoint p2 = snijpunt(r, new Rechte(m_inset_pointlist[i3], m_inset_pointlist[i4]));
                                double dist = distance_twopoints(p1, p2);

                                //m_inset_pointlist[i2] = new Kpoint(p1.X, p1.Y,false);
                                //m_inset_pointlist[i3] = new Kpoint(p2.X, p2.Y,false);

                                m_zijdes[i].m_l = Convert.ToInt32(dist * (double)100);
                                m_zijdes[i].m_x = Convert.ToInt32(p2.X * (double)100);
                                m_zijdes[i].m_y = Convert.ToInt32(p2.Y * (double)100);
                            }
                            //else
                            //{//vbu
                            //    double lengtevbu = 0;
                            //    double hoek = Math.PI * (m_zijdes[i].m_hoek_mus) / 18000;


                            //    lengtevbu =-1*(double)m_height * Math.Tan(hoek)-1;

                            //    Rechte r = nieuwe_evenwijdige_rechte(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint(), m_pointlist[i3].Converttopoint(), lengtevbu);
                            //    Kpoint p1 = snijpunt(r, new Rechte(m_inset_pointlist[i2], m_inset_pointlist[i1]));
                            //    Kpoint p2 = snijpunt(r, new Rechte(m_inset_pointlist[i3], m_inset_pointlist[i4]));
                            //    double dist = distance_twopoints(p1, p2);

                            //    //m_inset_pointlist[i2] = new Kpoint(p1.X, p1.Y,false);
                            //    //m_inset_pointlist[i3] = new Kpoint(p2.X, p2.Y,false);

                            //    m_zijdes[i].m_l = Convert.ToInt32(dist * (double)100);
                            //    m_zijdes[i].m_x = Convert.ToInt32(p2.X * (double)100);
                            //    m_zijdes[i].m_y = Convert.ToInt32(p2.Y * (double)100);

                            //    m_zijdes[i].m_vbulengte = lengtevbu;
                            //}
                        }
                    }
                    #endregion

                    #region rechtes bepalen
                    
                  for (int i = 0; i < m_inset_pointlist.Count; ++i)
                    {
                        Point pmin;
                        Point pplu;
                        Point pnul = m_inset_pointlist[i].Converttopoint();
                        if (i == 0)
                        {
                            pmin = m_inset_pointlist[m_inset_pointlist.Count - 1].Converttopoint();
                        }
                        else
                        {
                            pmin = m_inset_pointlist[i - 1].Converttopoint();
                        }
                        if (i == m_inset_pointlist.Count - 1)
                        {
                            pplu = m_inset_pointlist[0].Converttopoint();
                        }
                        else
                        {
                            pplu = m_inset_pointlist[i + 1].Converttopoint();
                        }

                        m_rechtelist.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, l, b));//, offset));
                    }
                    #endregion

                    #region m_inset_pointlist
                    bool stopnow = false;

                    for (int i = 0; i < m_rechtelist.Count; ++i)
                    {
                        if (stopnow == false)
                        {
                            stopnow = true;


                            int i1 = i - 1;
                            int i2 = i + 1;
                            int i3 = i + 2;

                            int i4 = i - 2;
                            int i5 = i + 3;

                            if (i1 == -1) { i1 = m_inset_pointlist.Count - 1; }

                            if (i2 == m_inset_pointlist.Count) { i2 = 0; }

                            if (i3 == m_inset_pointlist.Count) { i3 = 0; }
                            if (i3 == m_inset_pointlist.Count + 1) { i3 = 1; }

                            if (i4 == -1) { i4 = m_inset_pointlist.Count - 1; }
                            if (i4 == -2) { i4 = m_inset_pointlist.Count - 2; }

                            if (i5 == m_inset_pointlist.Count) { i5 = 0; }
                            if (i5 == m_inset_pointlist.Count + 1) { i5 = 1; }
                            if (i5 == m_inset_pointlist.Count + 2) { i5 = 2; }


                            int richting = richting_bepalen(m_pointlist[i].Converttopoint(), m_pointlist[i2].Converttopoint());

                            bool temp1 = puntlangsjuistekant(m_rechtelist[i], m_inset_pointlist[i1].Converttopoint(), richting);
                            bool temp2 = puntlangsjuistekant(m_rechtelist[i], m_inset_pointlist[i3].Converttopoint(), richting);

                            bool verdersplitsen = false;

                            //andere punten ook checken
                            //als er nog een punt langs de verkeerde kant ligt doen we verder


                            for (int u = 0; u < m_inset_pointlist.Count; ++u)
                            {
                                bool check = puntlangsjuistekant(m_rechtelist[i], m_inset_pointlist[u].Converttopoint(), richting);
                                if (check == false)
                                {
                                    verdersplitsen = true;
                                }
                                else
                                {
                                    stopnow = false;
                                }
                            }
                            //maar als ze allemaal langs de verkeerde kant liggen dat zijn we klaar
                            if (stopnow == false)
                            {
                                if (temp1)
                                {
                                    if (verdersplitsen)
                                    {
                                        Point p = snijpunt(m_rechtelist[i], new Rechte(m_inset_pointlist[i], m_inset_pointlist[i1])).Converttopoint();
                                        m_inset_pointlist[i] = new Kpoint(p.X,p.Y,0);
                                    }
                                }
                                else
                                {
                                    if (verdersplitsen)
                                    {
                                        //verderzoeken
                                        Point p = snijpunt(m_rechtelist[i], new Rechte(m_inset_pointlist[i1], m_inset_pointlist[i4])).Converttopoint();
                                        m_inset_pointlist[i1] = new Kpoint(p.X, p.Y, 0);
                                        m_inset_pointlist[i] = new Kpoint(p.X, p.Y, 0);
                                    }
                                }
                                if (temp2)
                                {
                                    if (verdersplitsen)
                                    {
                                        Point p = snijpunt(m_rechtelist[i], new Rechte(m_inset_pointlist[i2], m_inset_pointlist[i3])).Converttopoint();
                                        m_inset_pointlist[i2] = new Kpoint(p.X, p.Y, 0);
                                    }
                                }
                                else
                                {
                                    if (verdersplitsen)
                                    {
                                        //verderzoeken
                                        Point p = snijpunt(m_rechtelist[i], new Rechte(m_inset_pointlist[i3], m_inset_pointlist[i5])).Converttopoint();
                                        m_inset_pointlist[i3] = new Kpoint(p.X, p.Y, 0);
                                        m_inset_pointlist[i2] = new Kpoint(p.X, p.Y, 0);// new Point(m_inset_pointlist[i].X, m_inset_pointlist[i].Y);//p;
                                    }
                                }

                            }
                        }
                    }
                    #endregion

                    samenvallendepunte(ref m_inset_pointlist);

                    for (int i = 0; i < m_inset_pointlist.Count; ++i)
                    {
                        m_inset_pointlist[i].X += hor_safedistance/-2;
                        m_inset_pointlist[i].Y += ver_safedistance/2;
                    }

                    List<Kpoint> config2list = new List<Kpoint>();
                    if (m_bestgripper > 4)
                    {
                        for (int i = 0; i < m_inset_pointlist.Count; ++i)
                        {
                            config2list.Add(new Kpoint(m_inset_pointlist[i].X, m_inset_pointlist[i].Y + ((double)25 / 2), 0));
                            m_inset_pointlist[i] = new Kpoint(m_inset_pointlist[i].X, m_inset_pointlist[i].Y - ((double)25 / 2), 0);
                        }
                       //alle punten met 12,5 verander, gezien het opname punt van de kleine grijper niet in midden van de 135 ligt
                    }

                    #endregion

                    bool config2nodig = false;

                    #region opname punten in de x
                    int config1breedte = m_width;
                    int config2breedte = m_width;
                    int onderafs = 0;
                    int bovenafs = 0;

                    for (int i = 0; i < m_zijdes.Count; ++i)
                    {
                        if (m_zijdes[i].m_afsy > 0 && m_zijdes[i].m_afsz > 0)
                        {
                            //er is een afs
                            if (i==0)//(m_zijdes[i].m_afw == 5)
                            {
                                onderafs = m_zijdes[i].m_afsy; 
                            }
                            else if (i==2)// (m_zijdes[i].m_afw == 6)
                            {
                                bovenafs = m_zijdes[i].m_afsy;
                            }
                        }
                    }
                    if (config1breedte >= 250)//300)
                    { m_gripperoffset_x1 = 0; }
                 
                    else if (config1breedte > 180)
                    {
                        m_gripperoffset_x1 = Convert.ToInt32(Convert.ToDouble(-25 - onderafs + bovenafs) / 2);
                        //m_gripperoffset_x1 = (config1breedte / 2 - 120) + config1afs;
                        //if (m_gripperoffset_x1 > 0) { m_gripperoffset_x1 = 0; }
                    }
                    else if (config1breedte <= 180 && config1breedte >= 140)
                    {
                        //if (config1breedte >= 180)
                        //{
                        //    m_gripperoffset_x1 = -32;
                        //}
                        //else
                        //{
                        //m_gripperoffset_x1 = -config1breedte / 2 + 55 + 6;
                        m_gripperoffset_x1 = (-config1breedte / 2 + 55 + 3) + bovenafs;
                        //}
                        //m_gripperoffset_x2 = m_gripperoffset_x1 * -1;
                    }
                    else if (config1breedte < 140)
                    {
                        throw new Exception("breedte kleiner dan 140");
                    }

                    if (config2breedte >= 300)
                    { m_gripperoffset_x2 = 0; }

                    else if (config2breedte > 180)
                    {
                        m_gripperoffset_x2 = Convert.ToInt32(Convert.ToDouble(25 - onderafs + bovenafs) / 2);
                        //m_gripperoffset_x2 = (-config2breedte / 2 + 120) - config2afs;
                        //if (m_gripperoffset_x2 < 0) { m_gripperoffset_x2 = 0; }
                    }
                    else if (config2breedte <= 180 && config2breedte >= 140)
                    {
                        // if (config2breedte >= 180)
                        // {
                        //     m_gripperoffset_x2 = 32;
                        // }
                        // else
                        //{
                        m_gripperoffset_x2 = (config2breedte / 2 - 55 - 3) - onderafs;
                        //m_gripperoffset_x2 = config2breedte / 2 - 55 - 6;
                        // }
                    }
                    else if (config2breedte < 140)
                    {
                        throw new Exception("breedte kleiner dan 140");
                    }
                    #endregion 

                    #region opnameconfig per zijde
                    if (m_bestgripperoriginal > 60)
                    {
                        List<Rechte> grotegrijperlist = new List<Rechte>();
                        List<Rechte> kleinegrijperlist = new List<Rechte>();

                        int grippernr = 0;

                        if (m_bestgripperoriginal > 64)
                        {
                            grippernr = m_bestgripperoriginal - 64;
                        }

                        int lengte = Convert.ToInt32(m_config.IniReadValue("Grijper" + grippernr.ToString(), "minl"));
                        int breedte = Convert.ToInt32(m_config.IniReadValue("Grijper" + grippernr.ToString(), "minb"));
                        int breedteklein = Convert.ToInt32(m_config.IniReadValue("Grijper" + (grippernr + 4).ToString(), "minb"));

                        lengte /= 2;
                        breedte /= 2;
                        breedteklein /= 2;

                        for (int i = 0; i < m_pointlist.Count; ++i)
                        {
                            Point pmin;
                            Point pplu;
                            Point pnul = m_pointlist[i].Converttopoint();
                            if (i == 0)
                            {
                                pmin = m_pointlist[m_pointlist.Count - 1].Converttopoint();
                            }
                            else
                            {
                                pmin = m_pointlist[i - 1].Converttopoint();
                            }
                            if (i == m_pointlist.Count - 1)
                            {
                                pplu = m_pointlist[0].Converttopoint();
                            }
                            else
                            {
                                pplu = m_pointlist[i + 1].Converttopoint();
                            }

                            grotegrijperlist.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, lengte, breedte));
                            kleinegrijperlist.Add(nieuwe_evenwijdige_rechte(pmin, pnul, pplu, lengte, breedteklein));
                        }
                        //ik heb alle rechtes voor de "grote" grijper, nu vergelijken met punt +70 omhoog of dat langs de goede kant ligt,
                        //als dat het geval is kan de zijde in config 1 doen anders in config 2

                        //eenmalig op nul zetten
                        m_configoffset = 0;
                        bool res50 = true;
                        bool resmin50 = true;
                        bool res100 = true;
                        bool res200 = true;
                        bool resmin100 = true;
                        bool resmin200 = true;
                        bool resnul = true;

                        bool res2_50 = true;
                        bool res2_min50 = true;
                        bool res2_100 = true;
                        bool res2_200 = true;
                        bool res2_min100 = true;
                        bool res2_min200 = true;
                        bool res2_nul = true;

                        //bepalen of -200 -100 0 100 200 mogelijk zijn
                        for (int i = 0; i < kleinegrijperlist.Count; ++i)
                        {
                            int i1 = i;
                            int i2 = i + 1;
                            if (i2 == m_pointlist.Count) { i2 = 0; }
                            int tempricht = richting_bepalen(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint());
                            if (tempricht == 0 || tempricht == 6 || tempricht == 2 || tempricht == 1 || tempricht == 7 || tempricht == 3 || tempricht == 5)
                            {
                                #region cfg1
                                bool configresult100 = puntlangsjuistekant(kleinegrijperlist[i], new Point(100, m_gripperoffset_x1), tempricht);
                                bool configresult200 = puntlangsjuistekant(kleinegrijperlist[i], new Point(200, m_gripperoffset_x1), tempricht);
                                bool configresultmin100 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-100, m_gripperoffset_x1), tempricht);
                                bool configresultmin200 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-200, m_gripperoffset_x1), tempricht);
                                bool configresultnul = puntlangsjuistekant(kleinegrijperlist[i], new Point(0, m_gripperoffset_x1), tempricht);

                                bool configresultmin50 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-50, m_gripperoffset_x1), tempricht);
                                bool configresult50 = puntlangsjuistekant(kleinegrijperlist[i], new Point(50, m_gripperoffset_x1), tempricht);


                                if (configresult100 == false) { res100 = false; }
                                if (configresult200 == false) { res200 = false; }
                                if (configresultmin100 == false) { resmin100 = false; }
                                if (configresultmin200 == false) { resmin200 = false; }
                                if (configresultnul == false) { resnul = false; }
                                if (configresultmin50 == false) { resmin50 = false; }
                                if (configresult50 == false) { res50 = false; }
                                #endregion
                            }
                            if (tempricht == 4 || tempricht == 6 || tempricht == 2 || tempricht == 1 || tempricht == 7 || tempricht == 3 || tempricht == 5)
                            {
                                #region cfg2
                                bool configresult2_100 = puntlangsjuistekant(kleinegrijperlist[i], new Point(100, m_gripperoffset_x2), tempricht);
                                bool configresult2_200 = puntlangsjuistekant(kleinegrijperlist[i], new Point(200, m_gripperoffset_x2), tempricht);
                                bool configresultmin2_100 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-100, m_gripperoffset_x2), tempricht);
                                bool configresultmin2_200 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-200, m_gripperoffset_x2), tempricht);
                                bool configresult2_nul = puntlangsjuistekant(kleinegrijperlist[i], new Point(0, m_gripperoffset_x2), tempricht);

                                bool configresult2_min50 = puntlangsjuistekant(kleinegrijperlist[i], new Point(-50, m_gripperoffset_x2), tempricht);
                                bool configresult2_50 = puntlangsjuistekant(kleinegrijperlist[i], new Point(50, m_gripperoffset_x2), tempricht);


                                if (configresult2_100 == false) { res2_100 = false; }
                                if (configresult2_200 == false) { res2_200 = false; }
                                if (configresultmin2_100 == false) { res2_min100 = false; }
                                if (configresultmin2_200 == false) { res2_min200 = false; }
                                if (configresult2_nul == false) { res2_nul = false; }
                                if (configresult2_min50 == false) { res2_min50 = false; }
                                if (configresult2_50 == false) { res2_50 = false; }
                                #endregion
                            }
                        }

                        for (int i = 0; i < grotegrijperlist.Count; ++i)
                        {
                            int i1 = i;
                            int i2 = i + 1;
                            if (i2 == m_pointlist.Count) { i2 = 0; }
                            int tempricht = richting_bepalen(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint());
                            
                            #region cfg1
                            bool configresult = puntlangsjuistekant(grotegrijperlist[i], new Point(0, -70 + m_gripperoffset_x1), tempricht) ;//&& resnul;
                            
                            bool configresult100 = puntlangsjuistekant(grotegrijperlist[i], new Point(100, -70 + m_gripperoffset_x1), tempricht);//&& res100;
                            bool configresult200 = puntlangsjuistekant(grotegrijperlist[i], new Point(200, -70 + m_gripperoffset_x1), tempricht);// && res200;
                            bool configresultmin100 = puntlangsjuistekant(grotegrijperlist[i], new Point(-100, -70 + m_gripperoffset_x1), tempricht);// && resmin100;
                            bool configresultmin200 = puntlangsjuistekant(grotegrijperlist[i], new Point(-200, -70 + m_gripperoffset_x1), tempricht);// && resmin200;

                            bool configresultmin50 = puntlangsjuistekant(grotegrijperlist[i], new Point(-50, -70 + m_gripperoffset_x1), tempricht);
                            bool configresult50 = puntlangsjuistekant(grotegrijperlist[i], new Point(50, -70 + m_gripperoffset_x1), tempricht);
                            #endregion

                            #region cfg2
                            bool configresult2 = puntlangsjuistekant(grotegrijperlist[i], new Point(0, (70 + m_gripperoffset_x2)), tempricht);

                            bool configresult2_100 = puntlangsjuistekant(grotegrijperlist[i], new Point(100, 70 + m_gripperoffset_x2), tempricht);//&& res100;
                            bool configresult2_200 = puntlangsjuistekant(grotegrijperlist[i], new Point(200, 70 + m_gripperoffset_x2), tempricht);// && res200;
                            bool configresult2_min100 = puntlangsjuistekant(grotegrijperlist[i], new Point(-100, 70 + m_gripperoffset_x2), tempricht);// && resmin100;
                            bool configresult2_min200 = puntlangsjuistekant(grotegrijperlist[i], new Point(-200, 70 + m_gripperoffset_x2), tempricht);// && resmin200;

                            bool configresult2_min50 = puntlangsjuistekant(grotegrijperlist[i], new Point(-50, 70 + m_gripperoffset_x2), tempricht);
                            bool configresult2_50 = puntlangsjuistekant(grotegrijperlist[i], new Point(50, 70 + m_gripperoffset_x2), tempricht);

                            #endregion

                            

                            if (zijdeleeg(i) == true)
                            {
                                m_zijdes[i].m_opnamenr = 0;
                            }
                            //else{}

                            else if (configresult)
                            {
                                //config 1

                                
                                    
                                    if (configresult100 == false) { res100 = false; }
                                    if (configresult200 == false) { res200 = false; }
                                    if (configresultmin100 == false) { resmin100 = false; }
                                    if (configresultmin200 == false) { resmin200 = false; }
                                    if (configresult == false) { resnul = false; }
                                    if (configresultmin50 == false) { resmin50 = false; }
                                    if (configresult50 == false) { res50 = false; }
                                        m_zijdes[i].m_opnamenr = 1;
                                    //}
                                
                            }
                            //proberen config 1 te gebruiken met offset
                            else if (((configresult50 && res50) || (configresult100 && res100) || (configresult200 && res200)) && (m_configoffset == 0 || m_configoffset == 50 || m_configoffset == 100 || m_configoffset == 200))
                            {
                                if (configresult50 && m_configoffset == 0) { m_configoffset = 50; }
                                else if (configresult100 && (m_configoffset == 50 || m_configoffset == 0)) { m_configoffset = 100; }
                                else if (configresult200 && (m_configoffset == 50 || m_configoffset == 100 || m_configoffset == 0)) { m_configoffset = 200; }
                                m_zijdes[i].m_opnamenr = 1;
                                if (configresult100 == false) { res100 = false; }
                                if (configresult200 == false) { res200 = false; }
                                if (configresultmin100 == false) { resmin100 = false; }
                                if (configresultmin200 == false) { resmin200 = false; }
                                if (configresult == false) { resnul = false; }
                                if (configresultmin50 == false) { resmin50 = false; }
                                if (configresult50 == false) { res50 = false; }

                            }
                            else if (((configresultmin50 && resmin50) || (configresultmin100 && resmin100) || (configresultmin200 && resmin200)) && (m_configoffset == 0 || m_configoffset == -50 || m_configoffset == -100 || m_configoffset == -200))
                            {
                                if (configresultmin50 && m_configoffset == 0) { m_configoffset = -50; }
                                else if (configresultmin100 && (m_configoffset == -50 || m_configoffset == 0)) { m_configoffset = -100; }
                                else if (configresultmin200 && (m_configoffset == -50 || m_configoffset == -100 || m_configoffset == 0)) { m_configoffset = -200; }
                                m_zijdes[i].m_opnamenr = 1;
                                if (configresult100 == false) { res100 = false; }
                                if (configresult200 == false) { res200 = false; }
                                if (configresultmin100 == false) { resmin100 = false; }
                                if (configresultmin200 == false) { resmin200 = false; }
                                if (configresult == false) { resnul = false; }
                                if (configresultmin50 == false) { resmin50 = false; }
                                if (configresult50 == false) { res50 = false; }
                            }
                            else if (configresult2)
                            {
                                //enkel config 2 mogelijk
                                m_zijdes[i].m_opnamenr = 2;
                                config2nodig = true;
                            }
                            else if ((configresult2_50 && res2_50) || (configresult2_100 && res2_100) || (configresult2_200 && res2_200))
                            {
                                m_zijdes[i].m_opnamenr = 2;
                                config2nodig = true;

                                if (configresult2_50 && m_configoffset2 == 0) { m_configoffset2 = 50; }
                                else if (configresult2_100 && (m_configoffset2 == 50 || m_configoffset2 == 0)) { m_configoffset2 = 100; }
                                else if (configresult2_200 && (m_configoffset2 == 50 || m_configoffset2 == 100 || m_configoffset2 == 0)) { m_configoffset2 = 200; }

                                if (configresult2_100 == false) { res2_100 = false; }
                                if (configresult2_200 == false) { res2_200 = false; }
                                if (configresult2_min100 == false) { res2_min100 = false; }
                                if (configresult2_min200 == false) { res2_min200 = false; }
                                if (configresult2 == false) { res2_nul = false; }
                                if (configresult2_min50 == false) { resmin50 = false; }
                                if (configresult2_50 == false) { res2_50 = false; }
                            }
                            else if ((configresult2_min50 && res2_min50) || (configresult2_min100 && res2_min100) || (configresult2_min200 && res2_min200))
                            {
                                m_zijdes[i].m_opnamenr = 2;
                                config2nodig = true;

                                if (configresult2_min50 && m_configoffset2 == 0) { m_configoffset2 = -50; }
                                else if (configresult2_min100 && (m_configoffset2 == -50 || m_configoffset2 == 0)) { m_configoffset2 = -100; }
                                else if (configresult2_min200 && (m_configoffset2 == -50 || m_configoffset2 == -100 || m_configoffset2 == 0)) { m_configoffset2 = -200; }

                                if (configresult2_100 == false) { res2_100 = false; }
                                if (configresult2_200 == false) { res2_200 = false; }
                                if (configresult2_min100 == false) { res2_min100 = false; }
                                if (configresult2_min200 == false) { res2_min200 = false; }
                                if (configresult2 == false) { res2_nul = false; }
                                if (configresult2_min50 == false) { resmin50 = false; }
                                if (configresult2_50 == false) { res2_50 = false; }
                            }
                            else
                            {
                                if (k < m_gripper_available-1)
                                {
                                    zijde_onmogelijk = true;
                                }
                                else
                                {
                                    throw new Exception("Geen goede opname config gevonden");
                                }
                            }

         
                        }//einde grotegripper for lus

                        #region probleemm met hoek 2(richt3) in cfg1 en cfg2 nodig
                        if (config2nodig)
                        {
                            for (int i = 0; i < m_zijdes.Count; ++i)
                            {
                                int i1 = i;
                                int i2 = i + 1;
                                if (i2 == m_pointlist.Count) { i2 = 0; }
                                int tempricht = richting_bepalen(m_pointlist[i1].Converttopoint(), m_pointlist[i2].Converttopoint());

                                if (tempricht == 3 && m_zijdes[i].m_opnamenr == 1)
                                {
                                    //probleem, de hoek 2 is afgezaagd in cfg1 en kan dus niet gemeten worden in cfg 2
                                    //dus deze zijde moet in cfg2 als dat mogelijk is

                                    bool configresult2 = puntlangsjuistekant(grotegrijperlist[i], new Point(0, (70 + m_gripperoffset_x2)), tempricht);
                                    bool configresult2_100 = puntlangsjuistekant(grotegrijperlist[i], new Point(100, 70 + m_gripperoffset_x2), tempricht);//&& res100;
                                    bool configresult2_200 = puntlangsjuistekant(grotegrijperlist[i], new Point(200, 70 + m_gripperoffset_x2), tempricht);// && res200;
                                    bool configresult2_min100 = puntlangsjuistekant(grotegrijperlist[i], new Point(-100, 70 + m_gripperoffset_x2), tempricht);// && resmin100;
                                    bool configresult2_min200 = puntlangsjuistekant(grotegrijperlist[i], new Point(-200, 70 + m_gripperoffset_x2), tempricht);// && resmin200;
                                    bool configresult2_min50 = puntlangsjuistekant(grotegrijperlist[i], new Point(-50, 70 + m_gripperoffset_x2), tempricht);
                                    bool configresult2_50 = puntlangsjuistekant(grotegrijperlist[i], new Point(50, 70 + m_gripperoffset_x2), tempricht);

                                    //kijken of de config2offset die we gekozen hadden ook nog gaat voor deze zijde
                                    bool ok = false;
                                    switch (m_configoffset2)
                                    {
                                        case 0:
                                            if (configresult2)
                                                ok = true;
                                            break;
                                        case 50:
                                            if (configresult2_50)
                                                ok = true;
                                            break;
                                        case 100:
                                            if (configresult2_100)
                                                ok = true;
                                            break;
                                        case 200:
                                            if (configresult2_200)
                                                ok = true;
                                            break;
                                        case -50:
                                            if (configresult2_min50)
                                                ok = true;
                                            break;
                                        case -100:
                                            if (configresult2_min100)
                                                ok = true;
                                            break;
                                        case -200:
                                            if (configresult2_min200)
                                                ok = true;
                                            break;
                                    }
                                    if (ok)
                                    {
                                        m_zijdes[i].m_opnamenr = 2;
                                    }
                                    else { zijde_onmogelijk = true; }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //alles met dezelfde opname pos, dezelfde config dus
                        for (int i = 0; i < m_zijdes.Count; ++i)
                        {
                            if (zijdeleeg(i) == false)
                            {
                                m_zijdes[i].m_opnamenr = 1;
                            }
                            else
                            {
                                m_zijdes[i].m_opnamenr = 0;
                            }
                        }
                    }
                    #endregion

                    #region config voor de hoeken bepalen
                    for (int i = 0; i < m_zijdes.Count; ++i)
                    {
                        int i2 = i + 1;
                        if (i2 == m_zijdes.Count) { i2 = 0; }
                        //als de zijde in config1 is en de volgende in config 2 dan moet de hoek van dezijde in hoek2 komen ipv hoek 1
                        if (m_zijdes[i].m_hoek > 0 && m_zijdes[i].m_opnamenr == 1 && m_zijdes[i2].m_opnamenr == 2)
                        {
                            m_zijdes[i].m_hoek2 = m_zijdes[i].m_hoek;
                            m_zijdes[i].m_hoek = 0;
                        }
                    }
                    #endregion

                    #region inset zone omzetten naar een lijnstuk op hoogte xoffset
                    //ruwe zone bepalen
                    double kleinste = -9999;
                    double grootste = -9999;
                    for (int i = 0; i < m_inset_pointlist.Count; ++i)
                    {
                        if (m_inset_pointlist[i].X > grootste || grootste == -9999)
                        {
                            grootste = m_inset_pointlist[i].X;
                        }
                        if (m_inset_pointlist[i].X < kleinste || kleinste == -9999)
                        {
                            kleinste = m_inset_pointlist[i].X;
                        }
                    }

                    double kleinsteconfig1 = -9999;
                    double grootsteconfig1 = -9999;
                    double kleinsteconfig2 = -9999;
                    double grootsteconfig2 = -9999;

                    #region config 1
                    //de zone nauwkeuriger maken
                    bool kleinstegevonden = false;
                    for (double i = kleinste; i < grootste + 1; ++i)
                    {
                        if (kleinstegevonden == false)
                        {
                            kleinstegevonden = puntinoppervlak(m_inset_pointlist, new Kpoint(i, m_gripperoffset_x1, 0), true);
                            if (kleinstegevonden) { kleinsteconfig1 = i; }
                        }
                    }
                    if (kleinstegevonden == false)
                    {
                        //throw new Exception("geen kleinste punt gevonden"); 
                    }

                    bool grootstegevonden = false;
                    for (double i = grootste; i > kleinste - 1; --i)
                    {
                        if (grootstegevonden == false)
                        {
                            grootstegevonden = puntinoppervlak(m_inset_pointlist, new Kpoint(i, m_gripperoffset_x1, 0), true);
                            if (grootstegevonden) { grootsteconfig1 = i; }
                        }
                    }
                    if (grootstegevonden == false)
                    {
                        //throw new Exception("geen grootste punt gevonden"); 
                    }
                    #endregion

                    #region config 2
                    //de zone nauwkeuriger maken
                    kleinstegevonden = false;
                    for (double i = kleinste; i < grootste + 1; ++i)
                    {
                        if (kleinstegevonden == false)
                        {
                            kleinstegevonden = puntinoppervlak(config2list, new Kpoint(i, m_gripperoffset_x2, 0), true);
                            if (kleinstegevonden) { kleinsteconfig2 = i; }
                        }
                    }
                    if (kleinstegevonden == false)
                    {
                        //throw new Exception("geen kleinste punt gevonden"); 
                    }

                    grootstegevonden = false;
                    for (double i = grootste; i > kleinste - 1; --i)
                    {
                        if (grootstegevonden == false)
                        {
                            grootstegevonden = puntinoppervlak(config2list, new Kpoint(i, m_gripperoffset_x2, 0), true);
                            if (grootstegevonden) { grootsteconfig2 = i; }
                        }
                    }
                    if (grootstegevonden == false)
                    {
                        //throw new Exception("geen grootste punt gevonden"); 
                    }
                    #endregion
                    #endregion

                    double singoffset1 = 0;
                    double singoffset2 = 0;


                    //probleem singuliere offset...

                    //singoffset1 = offset_config1_bepalen(kleinsteconfig1, grootsteconfig1);
                    //singoffset2 = offset_config2_bepalen(kleinsteconfig2, grootsteconfig2);

                    //de y waarde is de kleinste

                    #region punten testen
                    
                    bool result = false;
                    bool result2 = false;

                    result = puntinoppervlak(m_inset_pointlist, new Kpoint(singoffset1, m_gripperoffset_x1, 0), true);
                    result = true;

                    if (config2nodig)
                    {
                        result2 = puntinoppervlak(config2list, new Kpoint(singoffset2, m_gripperoffset_x2, 0), true);
                        if (result2 == false)
                        {
                            result = false;
                        }
                    }

                    #endregion
                    if ((result) && zijde_onmogelijk == false) //&& stopnow == false
                    {
                        keeplooking = false;
                        if (result)
                        {
                            m_gripperoffset_y1 = Convert.ToInt32(singoffset1);
                            m_gripperoffset_y2 = Convert.ToInt32(singoffset2);
                        }
                    }
                    else
                    {
                        m_rechtelist.Clear();
                        m_inset_pointlist.Clear();
                    }
                }
            }
            #endregion

            if (keeplooking)
            {
                DialogResult result = MessageBox.Show("Het blad kan niet gedaan worden met deze bewerkingen. Wilt u de bewerkingen verwijderen en het blad naar de uitvoer pallet laten brengen?","",MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                { 
                    //de bewerkingen verwijderen en grijper invullen
                    //bool zetten om rest van berekingen over te slaan of RETURN
                    m_bestgripperoriginal = m_available_grippers[0];//grootste beschikbare grijper
                    m_nietbewerkbarejob = true;
                    for (int i = 0; i < m_zijdes.Count; ++i)
                    { 
                        //zijdes leegmaken
                        m_zijdes[i].m_singzone = null;
                        //m_zijdes[i].m_vbilengte = -1;
                        //m_zijdes[i].m_vbulengte = -1;
                        //m_zijdes[i].m_refmeethoek = 5;
                        m_zijdes[i].m_afsmus_height_schuin = -1;
                        m_zijdes[i].m_afsmus_height_rest = -1;
                        m_zijdes[i].m_hoek_afs = 0;
                        m_zijdes[i].m_hoek_mus = 0;
                        m_zijdes[i].m_x = 0;
                        m_zijdes[i].m_y = 0;
                        m_zijdes[i].m_l = 0;
                        //m_zijdes[i].m_afwdb = 0;
                        //m_zijdes[i].m_afw = 0;
                        m_zijdes[i].m_typenaam = "";
                        //m_zijdes[i].m_afwerking = "";
        //public double m_Xstrt = 0;
        //public double m_Ystrt = 0;
        //public double m_Xend = 0;
        //public double m_Yend = 0;
        //public int m_lengte_a = 0;
        //public int m_lengte_b = 0;
        //public int m_lengte_c = 0;
                        m_zijdes[i].m_edgev_a = 0;
                        m_zijdes[i].m_edgev_b = 0;
                        m_zijdes[i].m_edgev_c = 0;
                        m_zijdes[i].m_edgea_a = 0;
                        m_zijdes[i].m_edgea_b = 0;
                        m_zijdes[i].m_edgea_c = 0;
                        m_zijdes[i].m_brdr_a = 0;
                        m_zijdes[i].m_brdr_b = 0;
                        m_zijdes[i].m_brdr_c = 0;
                        m_zijdes[i].m_afsy = 0;
                        m_zijdes[i].m_afsz = 0;
                        m_zijdes[i].m_musy = 0;
                        m_zijdes[i].m_musz = 0;
                        m_zijdes[i].m_ank1 = 0;
                        m_zijdes[i].m_ank2 = 0;
                        m_zijdes[i].m_drupstart = 0;
                        m_zijdes[i].m_drupstop = 0;
                        m_zijdes[i].m_hoek = 0;
                        m_zijdes[i].m_opnamenr = 0;
                        m_zijdes[i].m_zagen = 0;
                        m_zijdes[i].m_cutoutdiepte = 0;
                        m_zijdes[i].m_cutoutdikte = 0;
                        m_zijdes[i].m_calibdiepte = 0;
                        m_zijdes[i].m_calibdikte = 0;
                        m_zijdes[i].m_dgdikte = 0;
                        m_zijdes[i].ofl = 0;
                        m_zijdes[i].F1 = 0;
                        m_zijdes[i].F2 = 0;
                        m_zijdes[i].F3 = 0;
                        m_zijdes[i].F4 = 0;
                        m_zijdes[i].m_drupdist = 0;
                        m_zijdes[i].m_ankdepth = 0;
                        m_zijdes[i].m_ankdist = 0;
                        m_zijdes[i].m_ankdia = 0;
                    }
                }
                else
                {
                    throw (new Exception("geen grijper gevonden met een goeie opname positie"));
                }
            }

            if (m_nietbewerkbarejob==false)
            {
                #region override snelheid bepalen
                double ratio = m_selector.Get_weightratio(m_bestgripper, m_gewicht);
                if (ratio > 0.9 || m_lenght > 1900 || m_gewicht > 220) { m_override = 50; }        // override 50%
                else if (ratio > 0.8 || m_lenght > 1800 || m_gewicht > 200) { m_override = 60; }  // override 70%
                else if (ratio > 0.7 || m_lenght > 1600 || m_gewicht > 150) { m_override = 70; } // override 70%
                else if (ratio > 0.6 || m_lenght > 1300 || m_gewicht > 100) { m_override = 90; }// override 90%
                else if (ratio > 0.5) { m_override = 100; }// override 100%
                else { m_override = 100; }               // overide 100%
                #endregion

                Calc_estimate();
            }
        }
	
        private double offset_config1_bepalen(double kleinsteinset, double grootsteinset)
        {
            singlist = new List<Kpoint>();
             
            for (int i = 0; i < m_zijdes.Count; ++i)
            {
                singlist.AddRange(m_zijdes[i].m_singzone.minmaxlist);

                //TODO: activeren en testen
                if ((m_zijdes[i].m_zagen == 1 || m_zijdes[i].m_zagen == 2) && m_zijdes[i].m_opnamenr == 1)
                {
                    //als er gezaagt wordt dan is er een ectra sing zone, die afhankelijk is van de c offset en de config
                    Rechte hor = new Rechte(1, 1);

                    if (m_zijdes[i].m_opnamenr == 1)
                    {
                        hor = new Rechte(new Kpoint(kleinsteinset, m_gripperoffset_x1, 0), new Kpoint(grootsteinset, m_gripperoffset_x1, 0));
                    }
                    else if (m_zijdes[i].m_opnamenr == 2)
                    {
                        hor = new Rechte(new Kpoint(kleinsteinset, m_gripperoffset_x2, 0), new Kpoint(grootsteinset, m_gripperoffset_x2, 0));
                    }
                    else
                    {
                        //opname 0 + zagen kan niet
                        throw new Exception("opname : " + m_zijdes[i].m_opnamenr.ToString() + " + zagen!");
                    }
                    int min = Convert.ToInt32(m_config.IniReadValue("Settings", "singzagenmin"));
                    int max = Convert.ToInt32(m_config.IniReadValue("Settings", "singzagenmax"));

                    int i2 = i - 1;
                    if (i2 < 0) { i2 = m_zijdes.Count - 1; }

                    Rechte r1 = nieuwe_evenwijdige_rechte(new Point((int)m_zijdes[i2].m_Ystrt, (int)m_zijdes[i2].m_Xstrt), new Point((int)m_zijdes[i].m_Ystrt, (int)m_zijdes[i].m_Xstrt), new Point((int)m_zijdes[i].m_Yend, (int)m_zijdes[i].m_Xend), min);
                    Rechte r2 = nieuwe_evenwijdige_rechte(new Point((int)m_zijdes[i2].m_Ystrt, (int)m_zijdes[i2].m_Xstrt), new Point((int)m_zijdes[i].m_Ystrt, (int)m_zijdes[i].m_Xstrt), new Point((int)m_zijdes[i].m_Yend, (int)m_zijdes[i].m_Xend), max);

                    Kpoint snijpunt1 = snijpunt(r1, hor);
                    Kpoint snijpunt2 = snijpunt(r2, hor);
                    double klein = 0;
                    double groot = 0;
                    if (snijpunt1.X > snijpunt2.X)
                    {
                        groot = snijpunt1.X;
                        klein = snijpunt2.X;
                    }
                    else
                    {
                        groot = snijpunt2.X;
                        klein = snijpunt1.X;
                    }

                    singlist.Add(new Kpoint(groot, klein, 0));
                }
                //sing zone zagen
                
            }
            singlist = sortlist(singlist);
            singlist = mergelist(singlist);


            //nu heb ik een lijst van zones waar het niet kan en een zone waar het wel kan
            List<double> insetlist = new List<double>();

            for (double i = kleinsteinset; i < grootsteinset + 1; ++i)
            {
                bool add = true;

                for (int j = 0; j < singlist.Count; ++j)
                {
                    

                    if (!(singlist[j].X > i && singlist[j].Y < i))
                    {
                        
                    }
                    else
                    {
                        add = false;
                    }
                }

                if (add)
                {
                    insetlist.Add(i);
                }
            }
            //zijn er nog punten over
            if (insetlist.Count == 0) 
            {
                return 0;
                //throw new Exception("geen opname punt"); 
            }

            //insetlist bevat nu alle punten die WEL toegelaten zijn
            //opnieuw zones vormen maar nu met enkel de teogelaten punten

            List<Kpoint> okzones = new List<Kpoint>();
            okzones.Add(new Kpoint(insetlist[0], insetlist[0], 0));

            for (int i = 1; i < insetlist.Count; ++i)
            {
                if (insetlist[i] == okzones[okzones.Count - 1].Y + 1)
                {
                    //nieuw eind van de zone
                    okzones[okzones.Count - 1].Y = insetlist[i];
                }
                else
                { 
                    //nieuwe zone
                    okzones.Add(new Kpoint(insetlist[i], insetlist[i], 0));
                }
            }

            //zijn er nog zones over (moet wel als er nog punten zijn)
            if (okzones.Count == 0) 
            {
                return 0;
                //throw new Exception("geen opname zone"); 
            }

            //eerste checken offset_bepalen 0,0 gaat
            bool nulgaat = false;
            int nulzone = -1;

            for (int i = 0; i < okzones.Count; ++i)
            {
                if (okzones[i].X < 0 && okzones[i].Y > 0)
                {
                    nulgaat = true;
                    nulzone = i;
                }
            }

            if (nulgaat && m_configoffset == 0)
            {
                bool mingaat = false;
                bool maxgaat = false;

                //verder controleren of -5 en 5 ook gaan
                if (okzones[nulzone].X < -50)
                {
                    mingaat = true;
                }
                if (okzones[nulzone].Y > 50)
                {
                    maxgaat = true;
                }

                if (mingaat && maxgaat)
                {
                    //OK
                    return 0;
                }
                else if (mingaat && maxgaat == false)//-50 ligt erin;+50 niet
                {
                    return (okzones[nulzone].Y - 50);
                }
                else if (mingaat == false && maxgaat)//+50 ligt erin;-50 niet
                {
                    return (okzones[nulzone].X + 50);
                }
                else //if (mingaat == false && maxgaat == false)
                {
                    return (okzones[nulzone].X + okzones[nulzone].Y) / 2;
                }


                //return 0;
            }
            else //nulgaat niet of configoffset verschilt vaqn nul 
            {
                List<int> deletezones = new List<int>();

                if (m_configoffset < 0)
                {
                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].X > m_configoffset)
                        {
                            deletezones.Add(i);
                        }
                        if (okzones[i].X < m_configoffset)
                        {
                            if (okzones[i].Y > m_configoffset)
                            { okzones[i].Y = m_configoffset; }                            
                        }
                    }

                    if (deletezones.Count > 0)
                    {
                        for (int i = deletezones.Count - 1;i>=0 ; --i)
                        {
                            okzones.RemoveAt(deletezones[i]);
                        }
                    }
                }
                else if (m_configoffset > 0)
                {
                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].Y < m_configoffset)
                        {
                            deletezones.Add(i);
                        }
                        if (okzones[i].Y > m_configoffset)
                        {
                            if (okzones[i].X < m_configoffset)
                            { okzones[i].X = m_configoffset; }
                        }
                    }

                    if (deletezones.Count > 0)
                    {
                        for (int i = deletezones.Count - 1; i >= 0; --i)
                        {
                            okzones.RemoveAt(deletezones[i]);
                        }
                    }
                }
                //else { } //0 haakjes nog zetten

                if (okzones.Count == 0)
                {
                    //TODO: dit zou niet mogen gebeuren dat hij door configoffset alle zones gaat deleten

                    return m_configoffset;
                }
                //zoeken naar het punt het dichtste bij 0
                if(okzones.Count == 1)
                {
                    double lengtezone = Math.Abs(okzones[0].X - okzones[0].Y);

                    //zone ligt in negatief gebied
                    if (okzones[0].X < 0)
                    {
                        if (lengtezone > 100)
                        {
                            return okzones[0].Y - 50;
                        }
                        else
                        {
                            return okzones[0].Y - lengtezone / 2;
                        }
                    }
                    else if (okzones[0].X > 0)
                    {
                        //zone in positief gebied
                        if (lengtezone > 100)
                        {
                            return okzones[0].X + 50;
                        }
                        else
                        {
                            return okzones[0].X + lengtezone / 2;
                        }

                    }
                    return 0;
                }
                else if (okzones.Count > 1)
                {
                    double kleinstezoneneg = -9999;
                    double kleinstezonepos = -9999;
                    int neg_zone = -1;
                    int pos_zone = -1;

                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].X < 0)
                        { //neg zone
                            double offsetstart = 0;

                            if (okzones[i].X > okzones[i].Y)
                            {
                                offsetstart = okzones[i].X;
                            }
                            else
                            {
                                offsetstart = okzones[i].Y;
                            }

                            if (kleinstezoneneg == -9999 || kleinstezoneneg < offsetstart)
                            {
                                kleinstezoneneg = offsetstart;
                                neg_zone = i;
                            }
                        }
                        else if (okzones[i].X > 0)
                        { //pos zone
                            double offsetstart = 0;

                            if (okzones[i].X > okzones[i].Y)
                            {
                                offsetstart = okzones[i].Y;
                            }
                            else
                            {
                                offsetstart = okzones[i].X;
                            }

                            if (kleinstezonepos == -9999 || kleinstezonepos > offsetstart)
                            {
                                kleinstezonepos = offsetstart;
                                pos_zone = i;
                            }
                        }
                    }

                    if (neg_zone != -1)
                    {
                        //grootte van zone bepalen
                        double grootte = Math.Abs(okzones[neg_zone].X - okzones[neg_zone].Y);
                        if (grootte > 100)
                        {
                            return kleinstezoneneg - 50;
                        }
                        else
                        {
                            //midden zone bepalen
                            return (okzones[neg_zone].X + okzones[neg_zone].Y) / 2;
                        }
                    }
                    else if (pos_zone != -1)
                    {
                        //grootte van zone bepalen
                        double grootte = Math.Abs(okzones[pos_zone].X - okzones[pos_zone].Y);
                        if (grootte > 100)
                        {
                            return kleinstezonepos + 50;
                        }
                        else
                        {
                            //midden zone bepalen
                            return (okzones[pos_zone].X + okzones[pos_zone].Y) / 2;
                        }
                    }
                    else
                    {
                        return 0;
                        throw new Exception("offsetbepaling fout 1");
                    }
                }
                else 
                {
                    //return 0;
                    throw new Exception("offsetbepaling fout 2");
                }
            }
        }

        private double offset_config2_bepalen(double kleinsteinset, double grootsteinset)
        {
            sing2list = new List<Kpoint>();

            for (int i = 0; i < m_zijdes.Count; ++i)
            {
                sing2list.AddRange(m_zijdes[i].m_singzone.minmaxlist);

                //TODO: activeren en testen
                if ((m_zijdes[i].m_zagen == 1 || m_zijdes[i].m_zagen == 2) && m_zijdes[i].m_opnamenr == 2)
                {
                    //als er gezaagt wordt dan is er een ectra sing zone, die afhankelijk is van de c offset en de config
                    Rechte hor = new Rechte(1, 1);

                    //if (m_zijdes[i].m_opnamenr == 1)
                    //{
                    //    hor = new Rechte(new Kpoint(kleinsteinset, m_gripperoffset_x1, false), new Kpoint(grootsteinset, m_gripperoffset_x1, false));
                    //}
                    //else 
                    if (m_zijdes[i].m_opnamenr == 2)
                    {
                        hor = new Rechte(new Kpoint(kleinsteinset, m_gripperoffset_x2, 0), new Kpoint(grootsteinset, m_gripperoffset_x2, 0));
                    }
                    else
                    {
                        //opname 0 + zagen kan niet
                        throw new Exception("opname : " + m_zijdes[i].m_opnamenr.ToString() + " + zagen in offset config 2!");
                    }
                    int min = Convert.ToInt32(m_config.IniReadValue("Settings", "singzagenmin"));
                    int max = Convert.ToInt32(m_config.IniReadValue("Settings", "singzagenmax"));

                    int i2 = i - 1;
                    if (i2 < 0) { i2 = m_zijdes.Count - 1; }

                    Rechte r1 = nieuwe_evenwijdige_rechte(new Point((int)m_zijdes[i2].m_Ystrt, (int)m_zijdes[i2].m_Xstrt), new Point((int)m_zijdes[i].m_Ystrt, (int)m_zijdes[i].m_Xstrt), new Point((int)m_zijdes[i].m_Yend, (int)m_zijdes[i].m_Xend), min);
                    Rechte r2 = nieuwe_evenwijdige_rechte(new Point((int)m_zijdes[i2].m_Ystrt, (int)m_zijdes[i2].m_Xstrt), new Point((int)m_zijdes[i].m_Ystrt, (int)m_zijdes[i].m_Xstrt), new Point((int)m_zijdes[i].m_Yend, (int)m_zijdes[i].m_Xend), max);

                    Kpoint snijpunt1 = snijpunt(r1, hor);
                    Kpoint snijpunt2 = snijpunt(r2, hor);
                    double klein = 0;
                    double groot = 0;
                    if (snijpunt1.X > snijpunt2.X)
                    {
                        groot = snijpunt1.X;
                        klein = snijpunt2.X;
                    }
                    else
                    {
                        groot = snijpunt2.X;
                        klein = snijpunt1.X;
                    }

                    singlist.Add(new Kpoint(groot, klein, 0));
                }
                //sing zone zagen

            }
            sing2list = sortlist(sing2list);
            sing2list = mergelist(sing2list);


            //nu heb ik een lijst van zones waar het niet kan en een zone waar het wel kan
            List<double> insetlist = new List<double>();

            for (double i = kleinsteinset; i < grootsteinset + 1; ++i)
            {
                bool add = true;

                for (int j = 0; j < sing2list.Count; ++j)
                {


                    if (!(sing2list[j].X > i && sing2list[j].Y < i))
                    {

                    }
                    else
                    {
                        add = false;
                    }
                }

                if (add)
                {
                    insetlist.Add(i);
                }
            }
            //zijn er nog punten over
            if (insetlist.Count == 0)
            {
                return 0;
                //throw new Exception("geen opname punt"); 
            }

            //insetlist bevat nu alle punten die WEL toegelaten zijn
            //opnieuw zones vormen maar nu met enkel de teogelaten punten

            List<Kpoint> okzones = new List<Kpoint>();
            okzones.Add(new Kpoint(insetlist[0], insetlist[0], 0));

            for (int i = 1; i < insetlist.Count; ++i)
            {
                if (insetlist[i] == okzones[okzones.Count - 1].Y + 1)
                {
                    //nieuw eind van de zone
                    okzones[okzones.Count - 1].Y = insetlist[i];
                }
                else
                {
                    //nieuwe zone
                    okzones.Add(new Kpoint(insetlist[i], insetlist[i], 0));
                }
            }

            //zijn er nog zones over (moet wel als er nog punten zijn)
            if (okzones.Count == 0)
            {
                return 0;
                //throw new Exception("geen opname zone"); 
            }

            //eerste checken offset_bepalen 0,0 gaat
            bool nulgaat = false;
            int nulzone = -1;

            for (int i = 0; i < okzones.Count; ++i)
            {
                if (okzones[i].X < 0 && okzones[i].Y > 0)
                {
                    nulgaat = true;
                    nulzone = i;
                }
            }

            if (nulgaat && m_configoffset2 == 0)
            {
                bool mingaat = false;
                bool maxgaat = false;

                //verder controleren of -5 en 5 ook gaan
                if (okzones[nulzone].X < -50)
                {
                    mingaat = true;
                }
                if (okzones[nulzone].Y > 50)
                {
                    maxgaat = true;
                }

                if (mingaat && maxgaat)
                {
                    //OK
                    return 0;
                }
                else if (mingaat && maxgaat == false)//-50 ligt erin;+50 niet
                {
                    return (okzones[nulzone].Y - 50);
                }
                else if (mingaat == false && maxgaat)//+50 ligt erin;-50 niet
                {
                    return (okzones[nulzone].X + 50);
                }
                else //if (mingaat == false && maxgaat == false)
                {
                    return (okzones[nulzone].X + okzones[nulzone].Y) / 2;
                }


                //return 0;
            }
            else //nul gaat niet
            {
                List<int> deletezones = new List<int>();

                if (m_configoffset2 < 0)
                {
                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].X > m_configoffset2)
                        {
                            deletezones.Add(i);
                        }
                        if (okzones[i].X < m_configoffset2)
                        {
                            if (okzones[i].Y > m_configoffset2)
                            { okzones[i].Y = m_configoffset2; }
                        }
                    }

                    if (deletezones.Count > 0)
                    {
                        for (int i = deletezones.Count - 1; i >= 0; --i)
                        {
                            okzones.RemoveAt(deletezones[i]);
                        }
                    }
                }
                else if (m_configoffset2 > 0)
                {
                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].Y < m_configoffset2)
                        {
                            deletezones.Add(i);
                        }
                        if (okzones[i].Y > m_configoffset2)
                        {
                            if (okzones[i].X < m_configoffset2)
                            { okzones[i].X = m_configoffset2; }
                        }
                    }

                    if (deletezones.Count > 0)
                    {
                        for (int i = deletezones.Count - 1; i >= 0; --i)
                        {
                            okzones.RemoveAt(deletezones[i]);
                        }
                    }
                }
                //else { } //0 haakjes nog zette



                if (okzones.Count == 0)
                {
                    //kan niet meer gebeuren enkel door configoffset die zones delete
                    throw new Exception("");
                }
                //zoeken naar het punt het dichtste bij 0
                if (okzones.Count == 1)
                {
                    double lengtezone = Math.Abs(okzones[0].X - okzones[0].Y);

                    //zone ligt in negatief gebied
                    if (okzones[0].X < 0)
                    {
                        if (lengtezone > 100)
                        {
                            return okzones[0].Y - 50;
                        }
                        else
                        {
                            return okzones[0].Y - lengtezone / 2;
                        }
                    }
                    else if (okzones[0].X > 0)
                    {
                        //zone in positief gebied
                        if (lengtezone > 100)
                        {
                            return okzones[0].X + 50;
                        }
                        else
                        {
                            return okzones[0].X + lengtezone / 2;
                        }

                    }
                    return 0;
                }
                else if (okzones.Count > 1)
                {
                    double kleinstezoneneg = -9999;
                    double kleinstezonepos = -9999;
                    int neg_zone = -1;
                    int pos_zone = -1;

                    for (int i = 0; i < okzones.Count; ++i)
                    {
                        if (okzones[i].X < 0)
                        { //neg zone
                            double offsetstart = 0;

                            if (okzones[i].X > okzones[i].Y)
                            {
                                offsetstart = okzones[i].X;
                            }
                            else
                            {
                                offsetstart = okzones[i].Y;
                            }

                            if (kleinstezoneneg == -9999 || kleinstezoneneg < offsetstart)
                            {
                                kleinstezoneneg = offsetstart;
                                neg_zone = i;
                            }
                        }
                        else if (okzones[i].X > 0)
                        { //pos zone
                            double offsetstart = 0;

                            if (okzones[i].X > okzones[i].Y)
                            {
                                offsetstart = okzones[i].Y;
                            }
                            else
                            {
                                offsetstart = okzones[i].X;
                            }

                            if (kleinstezonepos == -9999 || kleinstezonepos > offsetstart)
                            {
                                kleinstezonepos = offsetstart;
                                pos_zone = i;
                            }
                        }
                    }

                    if (neg_zone != -1)
                    {
                        //grootte van zone bepalen
                        double grootte = Math.Abs(okzones[neg_zone].X - okzones[neg_zone].Y);
                        if (grootte > 100)
                        {
                            return kleinstezoneneg - 50;
                        }
                        else
                        {
                            //midden zone bepalen
                            return (okzones[neg_zone].X + okzones[neg_zone].Y) / 2;
                        }
                    }
                    else if (pos_zone != -1)
                    {
                        //grootte van zone bepalen
                        double grootte = Math.Abs(okzones[pos_zone].X - okzones[pos_zone].Y);
                        if (grootte > 100)
                        {
                            return kleinstezonepos + 50;
                        }
                        else
                        {
                            //midden zone bepalen
                            return (okzones[pos_zone].X + okzones[pos_zone].Y) / 2;
                        }
                    }
                    else
                    {
                        return 0;
                        throw new Exception("offsetbepaling fout 1");
                    }
                }
                else
                {
                    //return 0;
                    throw new Exception("offsetbepaling fout 2");
                }
            }
        }

        public List<Kpoint> sortlist(List<Kpoint> input)
        {
            List<Kpoint> returnlist = input.OrderBy(o => o.Y).ToList();
            return returnlist;
        }

        public List<Kpoint> mergelist(List<Kpoint> input)
        {
            if (input.Count > 1)
            {
                List<Kpoint> returnlist = new List<Kpoint>();

                returnlist.Add(input[0]);

                for (int i = 1; i < input.Count; ++i)
                {
                    if (input[i].Y <= returnlist[returnlist.Count - 1].X)
                    {
                        returnlist[returnlist.Count - 1].X = input[i].X;
                    }
                    else
                    {
                        returnlist.Add(input[i]);
                    }
                }

                return returnlist;
            }
            else
            {
                return input;
            }
        }

        private bool zijdeleeg(int zijdenr)
        {
            if (m_zijdes[zijdenr].m_zagen > 0)    { return false; }
            if (m_zijdes[zijdenr].m_hoek_afs > 0) { return false; }
            if (m_zijdes[zijdenr].m_hoek_mus != 0) { return false; }

            if (m_zijdes[zijdenr].m_edgev_a > 0) { return false; }
            if (m_zijdes[zijdenr].m_edgev_b > 0) { return false; }
            if (m_zijdes[zijdenr].m_edgev_c > 0) { return false; }

            if (m_zijdes[zijdenr].m_edgea_a > 0) { return false; }
            if (m_zijdes[zijdenr].m_edgea_b > 0) { return false; }
            if (m_zijdes[zijdenr].m_edgea_c > 0) { return false; }

            if (m_zijdes[zijdenr].m_brdr_a > 0) { return false; }
            if (m_zijdes[zijdenr].m_brdr_b > 0) { return false; }
            if (m_zijdes[zijdenr].m_brdr_c > 0) { return false; }

            if (m_zijdes[zijdenr].m_hoek > 0) { return false; }

            if (m_zijdes[zijdenr].m_drupstart > 0) { return false; }
            if (m_zijdes[zijdenr].m_drupstop > 0)  { return false; }

            if (m_zijdes[zijdenr].m_ank1 > 0) { return false; }
            if (m_zijdes[zijdenr].m_ank2 > 0) { return false; }

            if (m_zijdes[zijdenr].m_afsy > 0) { return false; }
            if (m_zijdes[zijdenr].m_afsz > 0) { return false; }

            if (m_zijdes[zijdenr].m_musy > 0) { return false; }
            if (m_zijdes[zijdenr].m_musz > 0) { return false; }

            if (m_zijdes[zijdenr].m_calibdiepte > 0) { return false; }
            if (m_zijdes[zijdenr].m_calibdikte > 0) { return false; }

            if (m_zijdes[zijdenr].m_cutoutdiepte > 0) { return false; }
            if (m_zijdes[zijdenr].m_cutoutdikte > 0) { return false; }

            return true;
        }

        private void materiaal_bepalen(int dikte, ref int materiaalnr, ref int presetnr, string algemafw)
        {
            //grijs blauw zoet pol

            materiaalnr = 0;
            presetnr = 0;

            //met de dikt en de afw GRS BLS ZOE POL een materiaal + preset bepalen
            if (dikte <= 40 && dikte > 0)
            {
                materiaalnr = 1;
                if (dikte >= 0 && dikte <= 20)
                {
                    //preset 1 2 3 4 voor diktes 00-19
                    switch (algemafw)
                    {
                        case "GRS":
                            presetnr = 9;
                            break;
                        case "BLS":
                            presetnr = 10;
                            break;
                        case "ZOE":
                            presetnr = 3;
                            break;
                        case "POL":
                            presetnr = 4;
                            break;
                        case "SCH":
                            //mag niet meer voorkomen, hebben we vervangen bij overlopen zijdes
                            //zelf per zijde kijken welke afwerkingen er zijn
                            break;
                        case "ZAA":
                            presetnr = -1;//enkel zagen
                            break;
                    }
                }
        
                else if (dikte > 20 && dikte <= 30)
                {
                    //preset 1 2 3 4 voor diktes 20-30
                    switch (algemafw)
                    {
                        case "GRS":
                            presetnr = 1;
                            break;
                        case "BLS":
                            presetnr = 2;
                            break;
                        case "ZOE":
                            presetnr = 3;
                            break;
                        case "POL":
                            presetnr = 4;
                            break;
                        case "SCH":
                            //mag niet meer voorkomen, hebben we vervangen bij overlopen zijdes
                            //zelf per zijde kijken welke afwerkingen er zijn
                            break;
                        case "ZAA":
                            presetnr = -1;//enkel zagen
                            break;
                    }
                }
                else if (dikte > 30 && dikte <= 40)
                {
                    //preset 5 6 7 8 voor diktes 30-40
                    switch (algemafw)
                    {
                        case "GRS":
                            presetnr = 5;
                            break;
                        case "BLS":
                            presetnr = 6;
                            break;
                        case "ZOE":
                            presetnr = 7;
                            break;
                        case "POL":
                            presetnr = 8;
                            break;
                        case "SCH":
                            //mag niet meer voorkomen, hebben we vervangen bij overlopen zijdes
                            //zelf per zijde kijken welke afwerkingen er zijn
                            break;
                        case "ZAA":
                            presetnr = -1;//enkel zagen
                            break;
                    }
                }
            }
            else if (dikte > 40 && dikte <= 80)
            {
                materiaalnr = 2;

                if (dikte > 40 && dikte <= 60)
                {
                    //preset 1 2 3 4 voor diktes 40-60
                    switch (algemafw)
                    {
                        case "GRS":
                            presetnr = 1;
                            break;
                        case "BLS":
                            presetnr = 2;
                            break;
                        case "ZOE":
                            presetnr = 3;
                            break;
                        case "POL":
                            presetnr = 4;
                            break;
                        case "SCH":
                            //mag niet meer voorkomen, hebben we vervangen bij overlopen zijdes
                            //zelf per zijde kijken welke afwerkingen er zijn
                            break;
                        case "ZAA":
                            presetnr = -1;//enkel zagen
                            break;
                    }
                }
                else if (dikte > 60 && dikte <= 80)
                {
                    //preset 5 6 7 8 voor diktes 60-80
                    switch (algemafw)
                    {
                        case "GRS":
                            presetnr = 5;
                            break;
                        case "BLS":
                            presetnr = 6;
                            break;
                        case "ZOE":
                            presetnr = 7;
                            break;
                        case "POL":
                            presetnr = 8;
                            break;
                        case "SCH":
                            //mag niet meer voorkomen, hebben we vervangen bij overlopen zijdes
                            //zelf per zijde kijken welke afwerkingen er zijn
                            break;
                        case "ZAA":
                            presetnr = -1;//enkel zagen
                            break;
                    }
                }
                
            }
            else if (dikte > 80 && dikte <= 200)
            {
                materiaalnr = 1;
                presetnr = 1;
            }
            else
            {
                materiaalnr = -1;
                presetnr = -1;
                throw new Exception("Geen materiaal beschikbaar voor deze dikte : " + dikte.ToString());
            }
        }
        //private void materiaal_bepalen(int dikte, ref int materiaalnr, ref int presetnr, int preset)
        //{
        //    //grijs blauw zoet pol
        //    string afw = "";

        //    switch (preset)
        //    {
        //        case 1:
        //            afw = "GRS";
        //            break;
        //        case 2:
        //            afw = "BLS";
        //            break;
        //        case 3:
        //            afw = "ZOE";
        //            break;
        //        case 4:
        //            afw = "POL";
        //            break;
        //        case 5:
        //            afw = "GRS";
        //            break;
        //        case 6:
        //            afw = "BLS";
        //            break;
        //        case 7:
        //            afw = "ZOE";
        //            break;
        //        case 8:
        //            afw = "POL";
        //            break;
        //    }
        //    materiaal_bepalen(dikte, ref materiaalnr, ref presetnr, afw);
        //}

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

        private int gewicht(List<Kpoint> plist, int dikte)
        {
            //A = 1/2 · (x0y1 - x1y0 + x1y2 - x2y1 +
            //    ... + xn-1yn - xnyn-1 + xny1 - x1yn)
            double gewicht = 0;
            double oppervlakte = 0;
            //double weight = (double)(l * b * h) * (double)((double)2800 / (double)1000000000);
            //int i1 = 0;
            //int i2 = 0;

            //for (int i = 0; i < plist.Count; ++i)
            //{
            //    i1 = i;
            //    if (i == plist.Count - 1)
            //    {
            //        i2 = 0;
            //    }
            //    else
            //    {
            //        i2 = i + 1;
            //    }
            //    oppervlakte += ((plist[i1].X * plist[i2].Y) - (plist[i2].X * plist[i1].Y));
            //}
            //oppervlakte /= 2;
            //oppervlakte = Math.Abs(oppervlakte);
            oppervlakte = m_lenght * m_width * m_height;
            //oppervlakte *= (double)dikte;//1 kubieke meter = 2,8 ton of 2800 kg en onze oppervlakte is in mm
            oppervlakte *= (double)((double)2800 / (double)1000000000);
            gewicht = oppervlakte;

            return (int)gewicht;
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

            return new Rechte(a2, b2, hor, ver);
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
            if (r1.m_ishor == false && r1.m_isver == false && r2.m_ishor == false && r2.m_isver == false)
            {
                intersectX0 = (double)((r2.m_b - r1.m_b)/(r1.m_a - r2.m_a));
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
            Kpoint preturn = new Kpoint(intersectX0,intersectY0,0,-1);
            return preturn;
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

        private void foutepuntenbepalen(ref List<Kpoint> plist)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 0; i < m_inset_pointlist.Count; ++i)
            {
                #region punten bepalen
                p1 = i;
                p2 = p1 + 1;

                if (p2 == m_inset_pointlist.Count)
                {
                    p2 = 0;
                }

                p3 = p2 + 1;

                if (p3 == m_inset_pointlist.Count)
                {
                    p3 = 0;
                }

                #endregion

                bool result = puntlangsjuistekant(plist[p1], plist[p2], plist[p3]);
                if (result == false)
                {
                    mergepoints(ref m_inset_pointlist, i);
                }
            }
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
                if(distance_twopoints(plist[i1],plist[i2]) < 2)
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
        private void mergepoints(ref List<Kpoint> plist, int foutpunt)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;

            p1 = foutpunt;
            p2 = p1 + 1;

            if (p2 == m_inset_pointlist.Count)
            {
                p2 = 0;
            }

            p3 = p2 + 1;

            if (p3 == m_inset_pointlist.Count)
            {
                p3 = 0;
            }

            p4 = p3 + 1;

            if (p4 == m_inset_pointlist.Count)
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

        private double distance_twopoints(Point p1, Point p2)
        {
            double temp = Math.Sqrt(Math.Pow((p1.X - p2.X),2) + Math.Pow((p1.Y -p2.Y),2));
            return temp;
        }

        private double distance_twopoints(Kpoint p1, Kpoint p2)
        {
            double temp = Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
            return temp;
        }

        public int loodrechte_afstand_lijn_en_punt(Point p1, Rechte r1)
        {
            //loodrechte rechte bepalen van origineel
            //Rechte loodrechte = new Rechte((((double)(-1)) / r1.m_a), r1.m_b);
            double dist = 0;
            
            if (r1.m_isver)
            {
                dist = Math.Abs(r1.m_b - p1.X);
            }
            else
            {
                dist = (Math.Abs(r1.m_a * p1.X + r1.m_b - p1.Y)) / (Math.Sqrt((r1.m_a * r1.m_a) + 1));
            }
            

            return Convert.ToInt32(dist);
        }

        public Bitmap getpreview(int X1, int Y1)
        {
            //X1 = m_gripperoffset_x1;
            //Y1 = m_gripperoffset_y1;

            #region grijper aanmaken
            int bestgripper = m_bestgripperoriginal;
            if (bestgripper > 64)
            {
                if (bestgripper == 65) { bestgripper = 5; }
                if (bestgripper == 66) { bestgripper = 6; }
                if (bestgripper == 67) { bestgripper = 7; }
            }

            int l = Convert.ToInt32(m_config.IniReadValue("Grijper" + bestgripper.ToString(), "minl"));
            int b = Convert.ToInt32(m_config.IniReadValue("Grijper" + bestgripper.ToString(), "minb"));

            l /= 2;
            b /= 2;
            //m_gripperpointlist.Clear();
            //m_gripperpointlist.Add(new Point(l + X1, b + Y1));
            //m_gripperpointlist.Add(new Point(-l + X1, b + Y1));
            //m_gripperpointlist.Add(new Point(-l + X1, -b + Y1));
            //m_gripperpointlist.Add(new Point(l + X1, -b + Y1));
            //m_gripperpointlist.Add(new Point(l + X1, b + Y1));

            List<Point> grotegrijper = new List<Point>();
            List<Point> veiligezonegrijper = new List<Point>();


            if (m_bestgripperoriginal > 64)
            {
                int bgroot = Convert.ToInt32(m_config.IniReadValue("Grijper" + (m_bestgripperoriginal - 64).ToString(), "minb"));
                int size = bgroot - 150;

                m_gripperpointlist.Clear();
                m_gripperpointlist.Add(new Point(l + X1, b + Y1+12));
                m_gripperpointlist.Add(new Point(-l + X1, b + Y1+12));
                m_gripperpointlist.Add(new Point(-l + X1, -b + Y1+12));
                m_gripperpointlist.Add(new Point(l + X1, -b + Y1+12));
                m_gripperpointlist.Add(new Point(l + X1, b + Y1+12));

                veiligezonegrijper.Clear();
                veiligezonegrijper.Add(new Point(m_gripperpointlist[0].X - 12, m_gripperpointlist[0].Y - 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[1].X + 12, m_gripperpointlist[1].Y - 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[2].X + 12, m_gripperpointlist[2].Y));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[3].X - 12, m_gripperpointlist[3].Y));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[0].X - 12, m_gripperpointlist[0].Y - 12));

                grotegrijper.Add(new Point(l + X1, -b + Y1+12));
                grotegrijper.Add(new Point(l + X1, -b + Y1 - size+12));
                grotegrijper.Add(new Point(-l + X1, -b + Y1 - size+12));
                grotegrijper.Add(new Point(-l + X1, -b + Y1+12));
            }
            else 
            {
                m_gripperpointlist.Clear();
                m_gripperpointlist.Add(new Point(l + X1, b + Y1));
                m_gripperpointlist.Add(new Point(-l + X1, b + Y1));
                m_gripperpointlist.Add(new Point(-l + X1, -b + Y1));
                m_gripperpointlist.Add(new Point(l + X1, -b + Y1));
                m_gripperpointlist.Add(new Point(l + X1, b + Y1));

                veiligezonegrijper.Clear();
                veiligezonegrijper.Add(new Point(m_gripperpointlist[0].X - 12, m_gripperpointlist[0].Y - 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[1].X + 12, m_gripperpointlist[1].Y - 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[2].X + 12, m_gripperpointlist[2].Y + 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[3].X - 12, m_gripperpointlist[3].Y + 12));
                veiligezonegrijper.Add(new Point(m_gripperpointlist[0].X - 12, m_gripperpointlist[0].Y - 12));
            }
            #endregion

            #region bitmap / graphicsobject
            myBitmap = new Bitmap(2000, 1000, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            graphicsObj = Graphics.FromImage(myBitmap);
            graphicsObj.Clear(Color.White);
            graphicsObj.SmoothingMode = SmoothingMode.AntiAlias;
            #endregion

            #region scale + transform
            float scale = 1.0f;

            float horscale = (float)2000 / (float)(m_lenght + 300);
            float verscale = (float)1000 / (float)(m_width + 300);

            if (horscale < verscale)
            {
                scale = horscale;
            }
            else
            {
                scale = verscale;
            }

            graphicsObj.TranslateTransform(1000, 500);
            graphicsObj.ScaleTransform(scale, scale);
            #endregion

            #region m_pointlist
            //graphicsObj.DrawLines(Pen_black, m_pointlist.ToArray());
            //graphicsObj.DrawLine(Pen_black, m_pointlist[m_pointlist.Count - 1], m_pointlist[0]);
            #endregion

            #region sign zone
            //singlist[0];
            if (singlist != null)
            {
                for (int i = 0; i < singlist.Count; ++i)
                {
                    if (singlist[i].Y > singlist[i].X)
                    {
                        graphicsObj.FillRectangle(Brushes.Red, Convert.ToInt32(singlist[i].X), (m_width / -2), Convert.ToInt32(Math.Abs(singlist[i].Y - singlist[i].X)), m_width);
                    }
                    else
                    {
                        graphicsObj.FillRectangle(Brushes.Red, Convert.ToInt32(singlist[i].Y), (m_width / -2), Convert.ToInt32(Math.Abs(singlist[i].Y - singlist[i].X)), m_width);
                    }

                }
            }
            #endregion

            #region grijper tekenen
            graphicsObj.DrawLines(Pen_blue, m_gripperpointlist.ToArray());

            graphicsObj.DrawLines(Pen_blue, veiligezonegrijper.ToArray());

            if (grotegrijper.Count > 0)
            {
                graphicsObj.DrawLines(Pen_blue2, grotegrijper.ToArray());
            }

            try
            {
                if (m_inset_pointlist.Count > 1)
                {
                    for (int i = 0; i < m_inset_pointlist.Count-1; ++i)
                    {
                        graphicsObj.DrawLine(Pen_green, m_inset_pointlist[i].Converttopoint(), m_inset_pointlist[i + 1].Converttopoint());
                    }
                    //graphicsObj.DrawLines(Pen_green, m_inset_pointlist.ToArray());
                    graphicsObj.DrawLine(Pen_green, m_inset_pointlist[m_inset_pointlist.Count - 1].Converttopoint(), m_inset_pointlist[0].Converttopoint());
                }
            }
            catch { MessageBox.Show("error"); }
            #endregion

            #region 0,0 tekenen
            graphicsObj.FillEllipse(Brushes.Black, X1 - 10, Y1 - 10, 20, 20);
            graphicsObj.FillEllipse(Brushes.Black, X1 - 1, (Y1 - 1)*-1, 2, 2);
            #endregion

            #region zijdes
            foreach (Zijde z in m_zijdes)
            {
                z.draw(ref graphicsObj);
                graphicsObj.ResetTransform();
                graphicsObj.TranslateTransform(1000, 500);
                graphicsObj.ScaleTransform(scale, scale);
            }
            #endregion

            #region tekst
            myBitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            graphicsObj.DrawString(m_gewicht.ToString() + "KG", new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular), new SolidBrush(Color.Black), 20, 0);
            graphicsObj.DrawString(m_override.ToString() + "%", new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular), new SolidBrush(Color.Black), 20, 70);

            int gripper = m_bestgripperoriginal;
            try
            {
                int maxweight = 0;
                for (int i = 0; i < m_selector.m_gripperlist.Count; ++i)
                {
                    if (gripper == m_selector.m_gripperlist[i].m_grippernr)
                    {
                        maxweight = m_selector.m_gripperlist[i].m_maxweight;
                    }
                }

                //gripper = m_selector.m_gripperlist[gripper - 1].m_maxweight;
                graphicsObj.DrawString(maxweight.ToString() + "KG", new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular), new SolidBrush(Color.Black), 20, 140);
            }
            catch { }
            #endregion

            graphicsObj.Dispose();

            #region opname punt
            //if (m_edgesdoen)
            //{
            //    m_puntinvlak = sz_edge.hittest(m_inset_pointlist, X1, Y1);
            //}
            //else { 
                m_puntinvlak = puntinoppervlak(m_inset_pointlist,new Kpoint( X1, Y1,0),true); 
            //}
            #endregion

            return myBitmap;
        }

        public void omslotenvierhoek()
        { 
        
        }

        public string getzijde(int zijdenr)
        {
            //afs mus feed
            int afs_feed = Convert.ToInt32(m_config.IniReadValue("Settings", "afs_feed"));
            int mus_feed = Convert.ToInt32(m_config.IniReadValue("Settings", "mus_feed"));
            int afs_feedresult = 0;
            int mus_feedresult = 0;
            int afs1 = 0;
            int afs2 = 0;
            int mus1 = 0;
            int mus2 = 0;
            double afsdikte = 0;
            double musdikte = 0;
            double edgev = 0;
            double edgea = 0;


            if (zijdenr - 1 < m_zijdes.Count)
            {            
                // Calc value offsetwheels assuming 45° angle
                edgev = Math.Sqrt(Math.Pow(m_zijdes[zijdenr - 1].F1, 2) + Math.Pow(m_zijdes[zijdenr - 1].F2, 2)) / 2;
                edgea = Math.Sqrt(Math.Pow(m_zijdes[zijdenr - 1].F3, 2) + Math.Pow(m_zijdes[zijdenr - 1].F4, 2)) / 2;


                if (m_zijdes[zijdenr - 1].m_afsy > 0 && m_zijdes[zijdenr - 1].m_afsz > 0)
                {
                    afs1 = m_zijdes[zijdenr - 1].m_afsy;
                    afs2 = m_zijdes[zijdenr - 1].m_afsz;

                    double afstemp = Math.Sqrt((afs1 * afs1) + (afs2 * afs2));
                    if (afstemp > afsdikte)
                    {
                        afsdikte = afstemp;
                    }
                }
                //else if (m_zijdes[zijdenr - 1].m_vbilengte > 0)
                //{
                //    if (m_zijdes[zijdenr - 1].m_vbilengte > afsdikte)
                //    {
                //        afsdikte = m_zijdes[zijdenr - 1].m_vbilengte;
                //    }
                //}
                else if (m_zijdes[zijdenr - 1].m_musy > 0 && m_zijdes[zijdenr - 1].m_musz > 0)
                {
                    mus1 = m_zijdes[zijdenr - 1].m_musy;
                    mus2 = m_zijdes[zijdenr - 1].m_musz;

                    double mustemp = Math.Sqrt((mus1 * mus1) + (mus2 * mus2));
                    if (mustemp > musdikte)
                    {
                        musdikte = mustemp;
                    }
                }
                //else if (m_zijdes[zijdenr - 1].m_vbulengte > 0)
                //{
                //    if (m_zijdes[zijdenr - 1].m_vbulengte > musdikte)
                //    {
                //        musdikte = m_zijdes[zijdenr - 1].m_vbulengte;
                //    }
                //}


                try
                {
                    afs_feedresult = Convert.ToInt32((afs_feed * 100) / afsdikte);
                    if (afs_feedresult < 60 || afs_feedresult > 2400)//6000)
                    {
                        //fout
                        afs_feedresult = 0;

                        throw new Exception("Fout in de afs feed");
                    }
                }
                catch { afs_feedresult = 0; }
                try
                {
                    mus_feedresult = Convert.ToInt32((mus_feed * 100) / musdikte);
                    if (mus_feedresult < 60 || mus_feedresult > 2400)//6000)
                    {
                        //fout
                        mus_feedresult = 0;

                        throw new Exception("Fout in de mus feed");
                    }
                }
                catch { mus_feedresult = 0; }
            }
            //

            string str = "";

            if (zijdenr <= m_zijdes.Count && zijdenr >= 0)
            {
                str = "{PeriparamType: ";
                str += "i1 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_Xstrt*100) + ",";
                str += "i2 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_Xend*100) + ",";
                str += "i3 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_Ystrt*100) + ",";
                str += "i4 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_Yend*100) + ",";
                str += "i5 " + m_zijdes[zijdenr - 1].m_zagen + ",";
                str += "i6 " + m_zijdes[zijdenr - 1].m_lengte_a + ",";
                str += "i7 " + m_zijdes[zijdenr - 1].m_edgev_a + ",";
                str += "i8 " + m_zijdes[zijdenr - 1].m_brdr_a + ",";
                str += "i9 " + m_zijdes[zijdenr - 1].m_edgea_a + ",";
                str += "i10 " + m_zijdes[zijdenr - 1].m_lengte_b + ",";
                str += "i11 " + m_zijdes[zijdenr - 1].m_edgev_b + ",";
                str += "i12 " + m_zijdes[zijdenr - 1].m_brdr_b + ",";
                str += "i13 " + m_zijdes[zijdenr - 1].m_edgea_b + ",";
                str += "i14 " + m_zijdes[zijdenr - 1].m_lengte_c + ",";
                str += "i15 " + m_zijdes[zijdenr - 1].m_edgev_c + ",";
                str += "i16 " + m_zijdes[zijdenr - 1].m_brdr_c + ",";
                str += "i17 " + m_zijdes[zijdenr - 1].m_edgea_c + ",";
                if (m_zijdes[zijdenr - 1].m_hoek_afs != 0)
                {
                    str += "i18 " + m_zijdes[zijdenr - 1].m_hoek_afs + ",";
                    str += "i19 " + "0" + ",";
                    str += "i20 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_y) + ",";
                    str += "i21 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_x) + ",";
                }
                else if (m_zijdes[zijdenr - 1].m_hoek_mus != 0)
                {
                    str += "i18 " + "0" + ",";
                    str += "i19 " + m_zijdes[zijdenr - 1].m_hoek_mus + ",";
                    str += "i20 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_y) + ",";
                    str += "i21 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_x) + ",";
                }
                else
                {
                    str += "i18 " + "0" + ",";
                    str += "i19 " + "0" + ",";
                    str += "i20 " + "0" + ",";
                    str += "i21 " + "0" + ",";
                }
                str += "i22 " + m_zijdes[zijdenr - 1].m_ank1 + ",";
                str += "i23 " + m_zijdes[zijdenr - 1].m_ank2 + ",";
                str += "i24 " + m_zijdes[zijdenr - 1].m_drupstart + ",";
                str += "i25 " + m_zijdes[zijdenr - 1].m_drupstop + ",";
                str += "i26 " + m_zijdes[zijdenr - 1].m_hoek + ",";
                str += "i27 " + m_zijdes[zijdenr - 1].m_hoek2 + ",";
                str += "i28 " + m_zijdes[zijdenr - 1].m_opnamenr + ",";
                str += "i29 " + m_zijdes[zijdenr - 1].m_l + ",";
                str += "i30 " + m_zijdes[zijdenr - 1].m_drupdist + ",";
                str += "i31 " + m_zijdes[zijdenr - 1].m_ank3 + ",";
                str += "i32 " + m_zijdes[zijdenr - 1].m_cutoutdikte + " ,";
                str += "i33 " + m_zijdes[zijdenr - 1].m_cutoutdiepte + " ,";
                str += "i34 " + m_zijdes[zijdenr - 1].m_calibdikte + " ,";
                str += "i35 " + m_zijdes[zijdenr - 1].m_calibdiepte + " ,";
                str += "i36 " + afs_feedresult + " ,";
                str += "i37 " + mus_feedresult + " ,";
                str += "i38 " + m_zijdes[zijdenr - 1].m_dgdikte + " ,";
                str += "i39 " + Convert.ToInt32(edgev * 1000) + " ,";
                str += "i40 " + Convert.ToInt32(edgea * 1000) + " ,";
                str += "i41 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_ankdepth) + " ,";
                str += "i42 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_ankdist) + " ,";
                str += "i43 " + Convert.ToInt32(m_zijdes[zijdenr - 1].m_ankdia);
                str += " }";
            }
            else
            {
                str = "";//niet bestaande zijde : " + zijdenr.ToString();
            }
            return str;
        }

        public void Calc_estimate()
        {
            //TODO: calc estimate  
            //m_time_estimate_sec
            //per zijde afwerkingen
            //herpakken van blad
            //opname/afleggen
            //...
            //de snelheden ophalen van de bewerkingen
            //dan per zijde kijken wat er gedaan moet worden
            string speedstring = m_config.IniReadValue("Mat" + m_materiaalnr, "iSpeeds" + m_presetnr);
            //List<string> speedlist = new List<string>();
            //speedlist = speedstring.Split(' ');

            for (int i = 0; i < m_zijdes.Count; ++i)
            { 
                //de lengte ophalen
                int l = m_zijdes[i].m_lengte_a + m_zijdes[i].m_lengte_b + m_zijdes[i].m_lengte_c;

                if (m_zijdes[i].m_edgev_a > 0 || m_zijdes[i].m_edgev_b > 0 || m_zijdes[i].m_edgev_c > 0)
                { //dan gaan we deze edgev doen
                    m_time_estimate_sec += 100;
                }

                if (m_zijdes[i].m_edgea_a > 0 || m_zijdes[i].m_edgea_b > 0 || m_zijdes[i].m_edgea_c > 0)
                { //dan gaan we deze edgea doen SAMEN OF APART!!!!! met edgev
                    m_time_estimate_sec += 100;
                }

                if (m_zijdes[i].m_brdr_a > 0 || m_zijdes[i].m_brdr_b > 0 || m_zijdes[i].m_brdr_c > 0)
                { //dan gaan we deze border doen
                    m_time_estimate_sec += 150;
                }

                if (m_zijdes[i].m_ank1 != 0 || m_zijdes[i].m_ank2 != 0)
                {
                    m_time_estimate_sec += 150;
                }

                if (m_zijdes[i].m_drupstart != 0 || m_zijdes[i].m_drupstop != 0)
                {
                    m_time_estimate_sec += 150;
                }

                if (m_zijdes[i].m_hoek > 0)
                {
                    m_time_estimate_sec += 50;
                }

                if (m_zijdes[i].m_zagen > 0) 
                {
                    m_time_estimate_sec += 200;
                }

                if (m_zijdes[i].m_hoek_afs > 0)
                {
                    m_time_estimate_sec += 200;
                }

                if (m_zijdes[i].m_hoek_mus > 0)
                {
                    m_time_estimate_sec += 200;
                }
            }
        } 

        public int Get_time_estimate()
        {
            return m_time_estimate_sec;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            ////version info
            //info.AddValue("Version", "1.0");
            ////v1
            //info.AddValue("Jobname", this.m_jobname);
            //info.AddValue("Materiaal", this.m_materiaal);
            //info.AddValue("Lenght", this.m_lenght);
            //info.AddValue("Width", this.m_width);
            //info.AddValue("Height", this.m_height);
            //info.AddValue("Zijdes", this.m_zijdes);
            //info.AddValue("Grippernr", this.m_grippernr);
            //info.AddValue("Materiaalnr", this.m_materiaalnr);
            //info.AddValue("Presetnr", this.m_presetnr);
            //info.AddValue("Presetname", this.m_presetname);
        }

        //public string Getdetails(Form_Main main)
        //{
        //    return "";
        //}

        //public void Setdatetime()
        //{
        //    string temp = "";
        //    DateTime date1 = DateTime.Now;
        //    temp += date1.Day;
        //    temp += "-";
        //    temp += date1.Month;
        //    temp += "-";
        //    temp += date1.Year;
        //    temp += "_";
        //    temp += date1.Hour;
        //    temp += ".";
        //    temp += date1.Minute;
        //    temp += ".";
        //    temp += date1.Second;
        //    m_time_added = temp;
        //}

        public string Getdetailsforlog()
        {
            string returner = " ";
            try
            {
                if (m_nietbewerkbarejob)
                {
                    returner += m_jobname + " ";
                    returner += m_palletnummer + " ";
                    returner += "het bewerken van dit blad was niet mogelijk";
                }
                else
                {
                    string materiaal = "";
                    materiaal = m_config.IniReadValue("Mat" + m_materiaalnr.ToString(), "name") + "::" + m_config.IniReadValue("Mat" + m_materiaalnr.ToString(), "presetname" + (m_presetnr).ToString());
                    materiaal = materiaal.Replace(" ", "_");

                    returner += m_jobname + " ";
                    returner += materiaal + " ";

                    returner += m_lenght + " ";
                    returner += m_width + " ";
                    returner += m_height + " ";
                    returner += m_palletnummer + " ";
                }
            }
            catch { }
            return returner;
        }
    }

    public enum eB
    {
        Ankergaten = 0,
        Ausklinkung = 1,
        Falz = 2,
        Fase = 3,
        Sichtkante = 4,
        Sichtkante_und_fase = 5,
        Schragschnitt = 6,
        Wassernaze = 7,
        Kalibrierung = 8,
    }

    public class Component
    {
        VisieRes m_resultaat = new VisieRes();

        string m_Auftragsnr = "";
        string m_Position = "";
        string m_Werkstuecknr = "";
        string m_Kommentar = "";
        string m_Erstellung = "";
        string m_Ersteller = "";
        string m_Anzahl_Soll = "";
        string m_Anzahl_Ist = "";
        string m_Laenge = "";
        string m_Breite = "";
        string m_Dicke = "";

        Seite m_Seite1 = new Seite();
        Seite m_Seite2 = new Seite();
        Seite m_Seite3 = new Seite();
        Seite m_Seite4 = new Seite();

        public Component()
        {
        }

        public Component(Component c)
        {
            m_resultaat = c.m_resultaat;

            m_Auftragsnr = c.m_Auftragsnr;
            m_Position = c.m_Position;
            m_Werkstuecknr = c.m_Werkstuecknr;
            m_Kommentar = c.m_Kommentar;
            m_Erstellung = c.m_Erstellung;
            m_Ersteller = c.m_Ersteller;
            m_Anzahl_Soll = c.m_Anzahl_Soll;
            m_Anzahl_Ist = c.m_Anzahl_Ist;
            m_Laenge = c.m_Laenge;
            m_Breite = c.m_Breite;
            m_Dicke = c.m_Dicke;

            m_Seite1 = new Seite(c.m_Seite1);
            m_Seite2 = new Seite(c.m_Seite2);

            m_Seite3 = new Seite(c.m_Seite3);
            m_Seite4 = new Seite(c.m_Seite4);
        }

        public void Check_waardes(double zuigerbreedte)
        {
            if (m_Laenge == "") { throw new Exception("Laenge is empty"); }
            if (m_Breite == "") { throw new Exception("Breite is empty"); }
            if (m_Dicke == "") { throw new Exception("Dicke is empty"); }

            if (Lengte < 100 || Lengte > 2000) { throw new Exception("Laenge value"); }
            if (Breedte < 100 || Breedte > 1000) { throw new Exception("Breite value"); }
            if (Dikte < 30 || Dikte > 100) { throw new Exception("Dicke value"); }

            try
            {
                m_Seite1.Check_waardes(Lengte, Dikte, Breedte, zuigerbreedte, 1);
            }
            catch (Exception ex)
            {
                throw new Exception("Seite1 : " + ex.Message);
            }
            try
            {
                m_Seite2.Check_waardes(Lengte, Dikte, Breedte, zuigerbreedte, 2);
            }
            catch (Exception ex)
            {
                throw new Exception("Seite2 : " + ex.Message);
            }
            try
            {
                m_Seite3.Check_waardes(Lengte, Dikte, Breedte, zuigerbreedte, 3);
            }
            catch (Exception ex)
            {
                throw new Exception("Seite3 : " + ex.Message);
            }
            try
            {
                m_Seite4.Check_waardes(Lengte, Dikte, Breedte, zuigerbreedte, 4);
            }
            catch (Exception ex)
            {
                throw new Exception("Seite4 : " + ex.Message);
            }
        }

        public VisieRes Resultaat
        {
            get
            {
                return m_resultaat;
            }
            set
            {
                m_resultaat = value; ;
            }
        }

        public string Auftragsnr
        {
            get
            {
                return m_Auftragsnr;
            }
            set
            {
                m_Auftragsnr = value; ;
            }
        }
        public string Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value; ;
            }
        }
        public string Werkstuecknr
        {
            get
            {
                return m_Werkstuecknr;
            }
            set
            {
                m_Werkstuecknr = value; ;
            }
        }
        public string Kommentar
        {
            get
            {
                return m_Kommentar;
            }
            set
            {
                m_Kommentar = value; ;
            }
        }
        public string Erstellung
        {
            get
            {
                return m_Erstellung;
            }
            set
            {
                m_Erstellung = value; ;
            }
        }
        public string Ersteller
        {
            get
            {
                return m_Ersteller;
            }
            set
            {
                m_Ersteller = value;
            }
        }
        public string Anzahl_Soll
        {
            get
            {
                return m_Anzahl_Soll;
            }
            set
            {
                m_Anzahl_Soll = value;
            }
        }
        public string Anzahl_Ist
        {
            get
            {
                return m_Anzahl_Ist;
            }
            set
            {
                m_Anzahl_Ist = value;
            }
        }

        [Category("Size")]
        public double Lengte
        {
            get
            {
                return Convert.ToDouble(m_Laenge.Replace(".", ","));
            }
            set
            {

            }
        }
        [Category("Size")]
        public double Breedte
        {
            get
            {
                return Convert.ToDouble(m_Breite.Replace(".", ","));
            }
            set
            {

            }
        }
        [Category("Size")]
        public double Dikte
        {
            get
            {
                return Convert.ToDouble(m_Dicke.Replace(".", ","));
            }
            set
            {

            }
        }
        [Category("Size")]
        public string Laenge
        {
            get
            {
                return m_Laenge;
            }
            set
            {
                m_Laenge = value; ;
            }
        }
        [Category("Size")]
        public string Breite
        {
            get
            {
                return m_Breite;
            }
            set
            {
                m_Breite = value; ;
            }
        }
        [Category("Size")]
        public string Dicke
        {
            get
            {
                return m_Dicke;
            }
            set
            {
                m_Dicke = value; ;
            }
        }
        [Category("Sides")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Seite Seite1
        {
            get
            {
                return m_Seite1;
            }
            set
            {
                m_Seite1 = value; ;
            }
        }
        [Category("Sides")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Seite Seite2
        {
            get
            {
                return m_Seite2;
            }
            set
            {
                m_Seite2 = value; ;
            }
        }
        [Category("Sides")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Seite Seite3
        {
            get
            {
                return m_Seite3;
            }
            set
            {
                m_Seite3 = value; ;
            }
        }
        [Category("Sides")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Seite Seite4
        {
            get
            {
                return m_Seite4;
            }
            set
            {
                m_Seite4 = value; ;
            }
        }
    }

    public class Seite
    {
        Bearbeitung m_Bearbeitung1 = new Bearbeitung();
        Bearbeitung m_Bearbeitung2 = new Bearbeitung();
        Bearbeitung m_Bearbeitung3 = new Bearbeitung();
        Bearbeitung m_Bearbeitung4 = new Bearbeitung();
        Bearbeitung m_Bearbeitung5 = new Bearbeitung();
        Bearbeitung m_Bearbeitung6 = new Bearbeitung();
        Bearbeitung m_Bearbeitung7 = new Bearbeitung();
        Bearbeitung m_Bearbeitung8 = new Bearbeitung();
        Bearbeitung m_Bearbeitung9 = new Bearbeitung();
        Bearbeitung m_Bearbeitung10 = new Bearbeitung();

        public Seite()
        {

        }
        public Seite(Seite s)
        {
            m_Bearbeitung1 = s.m_Bearbeitung1;
            m_Bearbeitung2 = s.m_Bearbeitung2;
            m_Bearbeitung3 = s.m_Bearbeitung3;
            m_Bearbeitung4 = s.m_Bearbeitung4;
            m_Bearbeitung5 = s.m_Bearbeitung5;
            m_Bearbeitung6 = s.m_Bearbeitung6;
            m_Bearbeitung7 = s.m_Bearbeitung7;
            m_Bearbeitung8 = s.m_Bearbeitung8;
            m_Bearbeitung9 = s.m_Bearbeitung9;
            m_Bearbeitung10 = s.m_Bearbeitung10;
        }

        public void Check_waardes(double bladlengte, double bladdikte, double bladbreedte, double zuigerbreedte, int seite)
        {
            try
            {
                m_Bearbeitung1.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung1 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung2.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung2 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung3.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung3 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung4.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung4 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung5.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung5 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung6.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung6 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung7.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung7 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung8.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung8 : " + ex.Message);
            }

            try
            {
                m_Bearbeitung9.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung9 : " + ex.Message);
            }
            try
            {
                m_Bearbeitung10.Check_waardes(bladlengte, bladdikte, bladbreedte, zuigerbreedte, seite);
            }
            catch (Exception ex)
            {
                throw new Exception("Bearbeitung10 : " + ex.Message);
            }
        }

        public Bearbeitung Gehrungsschnitt()
        {
            if (m_Bearbeitung1.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Gehrungsschnitt") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Hinterschnittbohrung()
        {
            if (m_Bearbeitung1.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Hinterschnittbohrung") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");

        }
        public Bearbeitung Falldornbohrung()
        {
            if (m_Bearbeitung1.Typ_Name == "Falldornbohrung") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Falldornbohrung") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Falldornbohrung") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Falldornbohrung") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Falldornbohrung") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Falldornbohrung") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Falldornbohrung") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Falldornbohrung") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Falldornbohrung") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Falldornbohrung") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }

        public Bearbeitung Wassernase()
        {
            if (m_Bearbeitung1.Typ_Name == "Wassernase" || m_Bearbeitung1.Typ_Name == "Wassernaze") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Wassernase" || m_Bearbeitung2.Typ_Name == "Wassernaze") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Wassernase" || m_Bearbeitung3.Typ_Name == "Wassernaze") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Wassernase" || m_Bearbeitung4.Typ_Name == "Wassernaze") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Wassernase" || m_Bearbeitung5.Typ_Name == "Wassernaze") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Wassernase" || m_Bearbeitung6.Typ_Name == "Wassernaze") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Wassernase" || m_Bearbeitung7.Typ_Name == "Wassernaze") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Wassernase" || m_Bearbeitung8.Typ_Name == "Wassernaze") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Wassernase" || m_Bearbeitung9.Typ_Name == "Wassernaze") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Wassernase" || m_Bearbeitung10.Typ_Name == "Wassernaze") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Ankergaten()
        {
            if (m_Bearbeitung1.Typ_Name == "Ankerlöcher") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Ankerlöcher") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Ankerlöcher") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Ankerlöcher") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Ankerlöcher") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Ankerlöcher") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Ankerlöcher") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Ankerlöcher") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Ankerlöcher") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Ankerlöcher") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Ausklinkung()
        {
            if (m_Bearbeitung1.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Fugenfalz()
        {
            if (m_Bearbeitung1.Typ_Name == "Fugenfalz") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Fugenfalz") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Fugenfalz") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Fugenfalz") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Fugenfalz") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Fugenfalz") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Fugenfalz") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Fugenfalz") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Fugenfalz") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Fugenfalz") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Fase()
        {
            if (m_Bearbeitung1.Typ_Name == "Fase") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Fase") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Fase") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Fase") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Fase") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Fase") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Fase") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Fase") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Fase") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Fase") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Schragschnitt()
        {
            if (m_Bearbeitung1.Typ_Name == "Schrägschnitt") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Schrägschnitt") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Schrägschnitt") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Schrägschnitt") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Schrägschnitt") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Schrägschnitt") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Schrägschnitt") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Schrägschnitt") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Schrägschnitt") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Schrägschnitt") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Sichtkant_und_Fase()
        {
            if (m_Bearbeitung1.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Sichtkante + Fase") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung geschliffene_Kante()
        {
            if (m_Bearbeitung1.Typ_Name == "geschliffene Kante") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "geschliffene Kante") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "geschliffene Kante") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "geschliffene Kante") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "geschliffene Kante") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "geschliffene Kante") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "geschliffene Kante") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "geschliffene Kante") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "geschliffene Kante") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "geschliffene Kante") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }
        public Bearbeitung Kalibrierung()
        {
            if (m_Bearbeitung1.Typ_Name == "Kalibrierung") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Kalibrierung") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Kalibrierung") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Kalibrierung") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Kalibrierung") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Kalibrierung") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Kalibrierung") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Kalibrierung") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Kalibrierung") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Kalibrierung") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }

        public Bearbeitung hoek()
        {
            if (m_Bearbeitung1.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Ausklinkung 2-seitig") { return m_Bearbeitung10; }
            if (m_Bearbeitung1.Typ_Name == "Schrägschnitt") { return m_Bearbeitung1; }
            if (m_Bearbeitung2.Typ_Name == "Schrägschnitt") { return m_Bearbeitung2; }
            if (m_Bearbeitung3.Typ_Name == "Schrägschnitt") { return m_Bearbeitung3; }
            if (m_Bearbeitung4.Typ_Name == "Schrägschnitt") { return m_Bearbeitung4; }
            if (m_Bearbeitung5.Typ_Name == "Schrägschnitt") { return m_Bearbeitung5; }
            if (m_Bearbeitung6.Typ_Name == "Schrägschnitt") { return m_Bearbeitung6; }
            if (m_Bearbeitung7.Typ_Name == "Schrägschnitt") { return m_Bearbeitung7; }
            if (m_Bearbeitung8.Typ_Name == "Schrägschnitt") { return m_Bearbeitung8; }
            if (m_Bearbeitung9.Typ_Name == "Schrägschnitt") { return m_Bearbeitung9; }
            if (m_Bearbeitung10.Typ_Name == "Schrägschnitt") { return m_Bearbeitung10; }
            return null;
            //throw new Exception("niet gevonden");
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung1
        {
            get
            {
                return m_Bearbeitung1;
            }
            set
            {
                m_Bearbeitung1 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung2
        {
            get
            {
                return m_Bearbeitung2;
            }
            set
            {
                m_Bearbeitung2 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung3
        {
            get
            {
                return m_Bearbeitung3;
            }
            set
            {
                m_Bearbeitung3 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung4
        {
            get
            {
                return m_Bearbeitung4;
            }
            set
            {
                m_Bearbeitung4 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung5
        {
            get
            {
                return m_Bearbeitung5;
            }
            set
            {
                m_Bearbeitung5 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung6
        {
            get
            {
                return m_Bearbeitung6;
            }
            set
            {
                m_Bearbeitung6 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung7
        {
            get
            {
                return m_Bearbeitung7;
            }
            set
            {
                m_Bearbeitung7 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung8
        {
            get
            {
                return m_Bearbeitung8;
            }
            set
            {
                m_Bearbeitung8 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung9
        {
            get
            {
                return m_Bearbeitung9;
            }
            set
            {
                m_Bearbeitung9 = value; ;
            }
        }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Bearbeitung Bearbeitung10
        {
            get
            {
                return m_Bearbeitung10;
            }
            set
            {
                m_Bearbeitung10 = value; ;
            }
        }
    }

    public class Bearbeitung
    {
        string m_Typ_Name = "";
        string m_Bild_Erfassung = "";
        string m_Bild_Typ = "";
        //P m_P1 = new P();
        //P m_P2 = new P();
        //P m_P3 = new P();
        int m_y1 = -1;
        int m_y3 = -1;
        int m_y5 = -1;

        int m_y2 = -1;
        int m_y4 = -1;
        int m_y6 = -1;

        int m_x1 = -1;
        int m_x3 = -1;
        int m_x5 = -1;

        int m_M = -1;
        int m_N = -1;
        int m_t = -1;

        int m_x2 = -1;
        int m_x4 = -1;
        int m_x6 = -1;

        int m_a1 = -1;
        int m_a2 = -1;

        int m_b1 = -1;
        int m_b2 = -1;

        int m_c1 = -1;
        int m_c2 = -1;

        int m_d1 = -1;
        int m_d2 = -1;

        int m_X = -1;
        int m_Y = -1;
        int m_Z = -1;

        int m_RD = -1;
        int m_KT = -1;

        int m_F1 = -1;
        int m_F2 = -1;
        int m_F3 = -1;
        int m_F4 = -1;
        int m_F5 = -1;
        int m_F6 = -1;
        int m_F7 = -1;

        int m_Br = -1;
        int m_AV = -1;

        int m_ofl = -1;

        public Bearbeitung()
        {

        }
        public Bearbeitung(Bearbeitung b)
        {
            m_Typ_Name = b.m_Typ_Name;
            m_Bild_Erfassung = b.m_Bild_Erfassung;
            m_Bild_Typ = b.m_Bild_Typ;
            //m_P1 = new P(b.m_P1);
            //m_P2 = new P(b.m_P2);
            //m_P3 = new P(b.m_P3);
            m_y1 = b.m_y1;
            m_y3 = b.m_y3;
            m_y5 = b.m_y5;

            m_y2 = b.m_y2;
            m_y4 = b.m_y4;
            m_y6 = b.m_y6;

            m_x2 = b.m_x2;
            m_x4 = b.m_x4;
            m_x6 = b.m_x6;

            m_a1 = b.m_a1;
            m_a2 = b.m_a2;

            m_b1 = b.m_b1;
            m_b2 = b.m_b2;

            m_c1 = b.m_c1;
            m_c2 = b.m_c2;

            m_d1 = b.m_d1;
            m_d2 = b.m_d2;

            m_Br = b.m_Br;
            m_AV = b.m_AV;
        }

        public void Check_waardes(double bladlengte, double bladdikte, double bladbreedte, double zuigerbreedte, int seite)
        {
            //if (m_Typ_Name == "") { return false; }
            //if (m_Bild_Erfassung == "") { return false; }
            //if (m_Bild_Typ == "") { return false; }


            //TODO: per type checks invoegen
            switch (m_Typ_Name)
            {
                case "":
                    break;
                case "Gehrungsschnitt":
                    break;
                case "Hinterschnittbohrung":
                    break;
                case "Wassernase":
                    if (AV > 100) { throw new Exception("Wassernase AV"); }
                    if (Br != 4 && Br != 8) { throw new Exception("Wassernase BR"); }
                    break;
                case "Wassernaze":
                    if (AV > 100) { throw new Exception("Wassernaze AV"); }
                    if (Br != 4 && Br != 8) { throw new Exception("Wassernaze BR"); }

                    switch (seite)
                    {
                        case 1://links
                            if (bladbreedte - (a1 + a2) < 100)
                            {
                                throw new Exception("Wassernaze a1 a2");
                            }
                            break;
                        case 2://boven
                            if (bladlengte - (b1 + b2) < 100)
                            {
                                throw new Exception("Wassernaze b1 b2");
                            }
                            break;
                        case 3://rechts
                            if (bladbreedte - (c1 + c2) < 100)
                            {
                                throw new Exception("Wassernaze c1 c2");
                            }
                            break;
                        case 4://onder
                            if (bladlengte - (d1 + d2) < 100)
                            {
                                throw new Exception("Wassernaze d1 d2");
                            }
                            break;
                        default:
                            throw new Exception("Wassernaze onbekende zijde");
                            break;
                    }
                    break;
                //
                case "Falldornbohrung":
                    if (F6 > 15) { throw new Exception("Falldornbohrung F6<15"); }
                    break;
                case "Ankerlöcher":
                    if (t > 60) { throw new Exception("Ankerlöcher t>60"); }

                    //switch(seite)
                    //{
                    //    case 1://links
                    //        if (y1 > 0 && y3 > 0)
                    //        {
                    //            if (Math.Abs(y1 - y3) < 160) { return false; }
                    //        }
                    //        break;
                    //    case 2://boven
                    //        if (x2 > 0 && x4 > 0)
                    //        {
                    //            if (Math.Abs(x2 - x4) < 160) { return false; }
                    //        }
                    //        break;
                    //    case 3://rechts
                    //        if (y2 > 0 && y4 > 0)
                    //        {
                    //            if (Math.Abs(y2 - y4) < 160) { return false; }
                    //        }
                    //        break;
                    //    case 4://onder
                    //        if (x1 > 0 && x3 > 0)
                    //        {
                    //            if (Math.Abs(x1 - x3) < 160) { return false; }
                    //        }
                    //        break;
                    //    default:
                    //        return false;
                    //        break;
                    //}
                    break;
                case "Ausklinkung 2-seitig":
                    switch (seite)
                    {
                        case 1://links
                            if (a1 > 100 || a2 > 100)
                            {
                                throw new Exception("Ausklinkung 2-seitig a1 a2");
                            }
                            break;
                        case 2://boven
                            if (b1 > 100 || b2 > 100)
                            {
                                throw new Exception("Ausklinkung 2-seitig b1 b2");
                            }
                            break;
                        case 3://rechts
                            if (c1 > 100 || c2 > 100)
                            {
                                throw new Exception("Ausklinkung 2-seitig c1 c2");
                            }
                            break;
                        case 4://onder
                            if (d1 > 100 || d2 > 100)
                            {
                                throw new Exception("Ausklinkung 2-seitig d1 d2");
                            }
                            break;
                        default:
                            throw new Exception("Ausklinkung 2-seitig onbekende zijde");
                            break;
                    }
                    break;
                case "Fugenfalz":
                    if (15 > Y) { throw new Exception("Fugenfalz 15>Y"); }
                    //if (Y < 15) { return false; }
                    if (Y > 70) { throw new Exception("Fugenfalz Y>70"); }
                    if (X > 100) { throw new Exception("Fugenfalz X>100"); }
                    break;
                case "Fase":
                    if (F1 != F2) { throw new Exception("Fase F1"); }
                    if (F1 < 10) { throw new Exception("Fase F1"); }
                    break;
                case "Schrägschnitt":
                    break;
                case "Sichtkante + Fase":
                    if (F1 != F2) { throw new Exception("Sichtkante + Fase F1!=F2"); }
                    if (F3 != F4) { throw new Exception("Sichtkante + Fase F3!=F4"); }
                    break;
                case "geschliffene Kante":
                    if (F1 != F2) { throw new Exception("geschliffene Kante F1!=F2"); }
                    if (F3 != F4) { throw new Exception("geschliffene Kante F1!=F2"); }
                    break;
                case "Kalibrierung":
                    if (RD > bladdikte) { throw new Exception("Kalibrierung RD"); }
                    if (bladdikte - 3 > RD) { throw new Exception("Kalibrierung RD"); }

                    if ((bladbreedte / 2) - (zuigerbreedte / 2) < KT) { throw new Exception("Kalibrierung KT"); }
                    if (KT <= 15) { throw new Exception("Kalibrierung KT"); }
                    //bladbreedte/2 - 200[zuigerbreedte]/2 >= KT > 15 [mm]
                    break;
                default:
                    throw new Exception("default, unknown type");
                    break;
            }
        }

        public string Typ_Name
        {
            get
            {
                return m_Typ_Name;
            }
            set
            {
                m_Typ_Name = value; ;
            }
        }
        public string Bild_Erfassung
        {
            get
            {
                return m_Bild_Erfassung;
            }
            set
            {
                m_Bild_Erfassung = value; ;
            }
        }
        public int X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value; ;
            }
        }
        public int Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value; ;
            }
        }
        public int Z
        {
            get
            {
                return m_Z;
            }
            set
            {
                m_Z = value; ;
            }
        }

        public int F1
        {
            get
            {
                return m_F1;
            }
            set
            {
                m_F1 = value; ;
            }
        }
        public int F2
        {
            get
            {
                return m_F2;
            }
            set
            {
                m_F2 = value; ;
            }
        }
        public int F3
        {
            get
            {
                return m_F3;
            }
            set
            {
                m_F3 = value; ;
            }
        }
        public int F4
        {
            get
            {
                return m_F4;
            }
            set
            {
                m_F4 = value; ;
            }
        }
        public int F5
        {
            get
            {
                return m_F5;
            }
            set
            {
                m_F5 = value; ;
            }
        }
        public int F6
        {
            get
            {
                return m_F6;
            }
            set
            {
                m_F6 = value; ;
            }
        }
        public int F7
        {
            get
            {
                return m_F7;
            }
            set
            {
                m_F7 = value; ;
            }
        }

        public int Br
        {
            get
            {
                return m_Br;
            }
            set
            {
                m_Br = value; ;
            }
        }
        public int AV
        {
            get
            {
                return m_AV;
            }
            set
            {
                m_AV = value; ;
            }
        }

        public int RD
        {
            get
            {
                return m_RD;
            }
            set
            {
                m_RD = value; ;
            }
        }
        public int KT
        {
            get
            {
                return m_KT;
            }
            set
            {
                m_KT = value; ;
            }
        }

        public int y1
        {
            get
            {
                return m_y1;
            }
            set
            {
                m_y1 = value; ;
            }
        }
        public int y3
        {
            get
            {
                return m_y3;
            }
            set
            {
                m_y3 = value; ;
            }
        }
        public int y5
        {
            get
            {
                return m_y5;
            }
            set
            {
                m_y5 = value; ;
            }
        }

        public int M
        {
            get
            {
                return m_M;
            }
            set
            {
                m_M = value; ;
            }
        }
        public int N
        {
            get
            {
                return m_N;
            }
            set
            {
                m_N = value; ;
            }
        }
        public int t
        {
            get
            {
                return m_t;
            }
            set
            {
                m_t = value; ;
            }
        }

        public int y2
        {
            get
            {
                return m_y2;
            }
            set
            {
                m_y2 = value; ;
            }
        }
        public int y4
        {
            get
            {
                return m_y4;
            }
            set
            {
                m_y4 = value; ;
            }
        }
        public int y6
        {
            get
            {
                return m_y6;
            }
            set
            {
                m_y6 = value; ;
            }
        }

        public int Y1
        {
            get
            {
                return m_y1;
            }
            set
            {
                m_y1 = value; ;
            }
        }
        public int Y3
        {
            get
            {
                return m_y3;
            }
            set
            {
                m_y3 = value; ;
            }
        }
        public int Y5
        {
            get
            {
                return m_y5;
            }
            set
            {
                m_y5 = value; ;
            }
        }

        public int Y2
        {
            get
            {
                return m_y2;
            }
            set
            {
                m_y2 = value; ;
            }
        }
        public int Y4
        {
            get
            {
                return m_y4;
            }
            set
            {
                m_y4 = value; ;
            }
        }
        public int Y6
        {
            get
            {
                return m_y6;
            }
            set
            {
                m_y6 = value; ;
            }
        }

        public int x1
        {
            get
            {
                return m_x1;
            }
            set
            {
                m_x1 = value; ;
            }
        }
        public int x3
        {
            get
            {
                return m_x3;
            }
            set
            {
                m_x3 = value; ;
            }
        }
        public int x5
        {
            get
            {
                return m_x5;
            }
            set
            {
                m_x5 = value; ;
            }
        }

        public int X1
        {
            get
            {
                return m_x1;
            }
            set
            {
                m_x1 = value; ;
            }
        }
        public int X3
        {
            get
            {
                return m_x3;
            }
            set
            {
                m_x3 = value; ;
            }
        }
        public int X5
        {
            get
            {
                return m_x5;
            }
            set
            {
                m_x5 = value; ;
            }
        }

        public int x2
        {
            get
            {
                return m_x2;
            }
            set
            {
                m_x2 = value; ;
            }
        }
        public int x4
        {
            get
            {
                return m_x4;
            }
            set
            {
                m_x4 = value; ;
            }
        }
        public int x6
        {
            get
            {
                return m_x6;
            }
            set
            {
                m_x6 = value; ;
            }
        }

        public int X2
        {
            get
            {
                return m_x2;
            }
            set
            {
                m_x2 = value; ;
            }
        }
        public int X4
        {
            get
            {
                return m_x4;
            }
            set
            {
                m_x4 = value; ;
            }
        }
        public int X6
        {
            get
            {
                return m_x6;
            }
            set
            {
                m_x6 = value; ;
            }
        }

        public int a1
        {
            get
            {
                return m_a1;
            }
            set
            {
                m_a1 = value; ;
            }
        }
        public int a2
        {
            get
            {
                return m_a2;
            }
            set
            {
                m_a2 = value; ;
            }
        }

        public int b1
        {
            get
            {
                return m_b1;
            }
            set
            {
                m_b1 = value; ;
            }
        }
        public int b2
        {
            get
            {
                return m_b2;
            }
            set
            {
                m_b2 = value; ;
            }
        }

        public int c1
        {
            get
            {
                return m_c1;
            }
            set
            {
                m_c1 = value; ;
            }
        }
        public int c2
        {
            get
            {
                return m_c2;
            }
            set
            {
                m_c2 = value; ;
            }
        }

        public int d1
        {
            get
            {
                return m_d1;
            }
            set
            {
                m_d1 = value; ;
            }
        }
        public int d2
        {
            get
            {
                return m_d2;
            }
            set
            {
                m_d2 = value; ;
            }
        }

        public int OFL
        {
            get
            {
                return m_ofl;
            }
            set
            {
                m_ofl = value; ;
            }
        }

        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public P P1
        //{
        //    get
        //    {
        //        return m_P1;
        //    }
        //    set
        //    {
        //        m_P1 = value; ;
        //    }
        //}
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public P P2
        //{
        //    get
        //    {
        //        return m_P2;
        //    }
        //    set
        //    {
        //        m_P2 = value; ;
        //    }
        //}
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public P P3
        //{
        //    get
        //    {
        //        return m_P3;
        //    }
        //    set
        //    {
        //        m_P3 = value; ;
        //    }
        //}
    }

    public class Kpoint
    {
        public double X = 0;
        public double Y = 0;
        public int zaagpunt = 0;
        public int m_afw = -1;

        public double m_diepte = 0;

        public Kpoint()
        {
        }
        public Kpoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Kpoint(double x, double y, double diepte)
        {
            X = x;
            Y = y;
            m_diepte = diepte;
        }
        public Kpoint(double x, double y, int zaagjanee)
        {
            X = x;
            Y = y;
            zaagpunt = zaagjanee;
        }
        public Kpoint(double x, double y, int zaagjanee, int afw)
        {
            X = x;
            Y = y;
            zaagpunt = zaagjanee;
            m_afw = afw;
        }

        public Point Converttopoint()
        {
            return new Point(Convert.ToInt32(this.X), Convert.ToInt32(this.Y));
        }

        public double _X
        {
            get
            {
                return X;
            }
            set
            {
                X = value;
            }
        }
        public double _Y
        {
            get
            {
                return Y;
            }
            set
            {
                Y = value;
            }
        }
    }

    public class VisieRes
    {
        double m_x = 0;
        double m_y = 0;
        double m_a = 0;
        double m_l = 0;
        double m_b = 0;
        bool m_xmlmatch = false;
        public VisieRes()
        {

        }
        public VisieRes(VisieRes v)
        {
            m_x = v.m_x;
            m_y = v.m_y;
            m_a = v.m_a;
            m_l = v.m_l;
            m_b = v.m_b;
            m_xmlmatch = v.m_xmlmatch;
        }
        public VisieRes(double x, double y, double a, double l, double b)
        {
            m_x = x;
            m_y = y;
            m_a = a;
            m_l = l;
            m_b = b;
            m_xmlmatch = false;
        }

        public double X
        {
            get
            {
                return m_x;
            }
            set
            {
                m_x = value; ;
            }
        }
        public double Y
        {
            get
            {
                return m_y;
            }
            set
            {
                m_y = value; ;
            }
        }
        public double A
        {
            get
            {
                return m_a;
            }
            set
            {
                m_a = value; ;
            }
        }
        public double L
        {
            get
            {
                return m_l;
            }
            set
            {
                m_l = value; ;
            }
        }
        public double B
        {
            get
            {
                return m_b;
            }
            set
            {
                m_b = value; ;
            }
        }
        public bool xmlmatch
        {
            get
            {
                return m_xmlmatch;
            }
            set
            {
                m_xmlmatch = value;
            }
        }
    }
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);



        public IniFile(string INIPath)
        {
            path = INIPath;
        }


        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }



        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
    }

    public struct Gripper
    {
        public int m_maxl, m_maxb, m_minl, m_minb, m_grippernr, m_maxweight, m_safedistance_links, m_safedistance_rechts, m_safedistance_boven, m_safedistance_onder;
        public Gripper(int maxl, int maxb, int minl, int minb, int nr, int maxweight)
        {
            m_safedistance_links = 0;
            m_safedistance_rechts = 0;
            m_safedistance_boven = 0;
            m_safedistance_onder = 0;
            m_maxl = maxl;
            m_maxb = maxb;
            m_minl = minl;
            m_minb = minb;
            m_grippernr = nr;
            m_maxweight = maxweight;
        }
    }
    public class Gripperselecter
    {
        IniFile myINIfile;

        public List<Gripper> m_gripperlist;

        public Gripperselecter(ref IniFile config)
        {
            m_gripperlist = new List<Gripper>();
            myINIfile = config;
        }

        public void Create()
        {
            m_gripperlist.Clear();

            if (myINIfile.IniReadValue("Grijper1", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper1", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper2", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper2", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper3", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper3", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper4", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper4", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper5", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper5", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper6", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper6", "maxweight"))
                                              ));
            }
            if (myINIfile.IniReadValue("Grijper7", "actief") == "1")
            {
                m_gripperlist.Add(new Gripper(Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "maxl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "maxb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "minl")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "minb")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "nr")),
                                              Convert.ToInt32(myINIfile.IniReadValue("Grijper7", "maxweight"))
                                              ));
            }
            //added the ' - ' to invert the sort biggest gripper first
            //m_gripperlist.Sort(delegate(Gripper g1, Gripper g2) { return -g1.m_maxl.CompareTo(g2.m_maxl); });
        }

        public int[] Getallgrippers(int l, int b, int h, int dichtheid)
        {
            double weight = (double)(l * b * h) * (double)((double)2800 / (double)1000000000);

            List<int> allokgrippers = new List<int>();

            foreach (Gripper g in m_gripperlist)
            {
                int m_maxl = g.m_maxl;
                if (m_maxl == 2000) { m_maxl = 2001; }
                // REMINDER = weggedaan bij max 
                if (l < m_maxl && b <= g.m_maxb && l >= g.m_minl && b >= g.m_minb)
                {
                    if (m_maxl / 2 >= l / 2)
                    {
                        if (weight <= g.m_maxweight)
                        {
                            allokgrippers.Add(g.m_grippernr);
                        }
                    }
                }
            }
            return allokgrippers.ToArray();
        }

        public int[] Getallgrippers(int gewicht, int l, int b)
        {
            bool g1 = false;
            bool g2 = false;
            bool g3 = false;
            bool g4 = false;
            bool g65 = false;
            bool g66 = false;
            bool g67 = false;

            List<int> allokgrippers = new List<int>();

            foreach (Gripper g in m_gripperlist)
            {
                int m_maxl = g.m_maxl;
                if (m_maxl == 2000) { m_maxl = 2001; }

                if (gewicht <= g.m_maxweight)
                {//terug toevoegen om rare dingen te vermijden
                    if (l < m_maxl && b <= g.m_maxb && l >= g.m_minl && b >= g.m_minb)
                    {

                        switch (g.m_grippernr)
                        {
                            case 1:
                                g1 = true;
                                break;
                            case 2:
                                g2 = true;
                                break;
                            case 3:
                                g3 = true;
                                break;
                            case 4:
                                g4 = true;
                                break;
                            case 65:
                                g65 = true;
                                break;
                            case 66:
                                g66 = true;
                                break;
                            case 67:
                                g67 = true;
                                break;
                        }
                    }
                    //allokgrippers.Add(g.m_grippernr);
                }
            }

            if (g4) { allokgrippers.Add(4); }
            if (g3) { allokgrippers.Add(3); }
            if (g2) { allokgrippers.Add(2); }
            if (g1) { allokgrippers.Add(1); }
            if (g67) { allokgrippers.Add(67); }
            if (g66) { allokgrippers.Add(66); }
            if (g65) { allokgrippers.Add(65); }

            return allokgrippers.ToArray();
        }

        public double Get_weightratio(int gnr, int gewicht)
        {
            int grippernr = gnr;
            if (grippernr == 7) { grippernr = 67; }
            if (grippernr == 6) { grippernr = 66; }
            if (grippernr == 5) { grippernr = 65; }
            double maxweight = 0;
            for (int i = 0; i < m_gripperlist.Count; ++i)
            {
                if (grippernr == m_gripperlist[i].m_grippernr)
                {
                    maxweight = m_gripperlist[i].m_maxweight;
                }
            }
            if (maxweight == 0) { return 1; }

            double ratio = gewicht / maxweight;

            return ratio;
            //int grippernr = gnr;
            //if (grippernr > 64) { grippernr -= 60; }
            //grippernr -= 1;

            //double maxweight = m_gripperlist[grippernr].m_maxweight;

            //double ratio = gewicht / maxweight;

            //return ratio;
        }
    }

    public class SingZone
    {
        Job_def m_jobpointer;

        double m_min_edgev = 0;
        double m_max_edgev = 0;

        double m_min_ank = 0;
        double m_max_ank = 0;

        double m_min_drup = 0;
        double m_max_drup = 0;

        double m_min_zaag = 0;
        double m_max_zaag = 0;

        bool m_edgev = false;
        bool m_edgea = false;
        bool m_border = false;
        bool m_drupgroef = false;
        bool m_ankergaten = false;

        public List<Kpoint> minmaxlist;

        public SingZone(Zijde z, Job_def jobpointer)
        {
            if ((z.m_edgev_a == 1 || z.m_edgev_a == 2) || (z.m_edgev_b == 1 || z.m_edgev_b == 2) || (z.m_edgev_c == 1 || z.m_edgev_c == 2))
            {
                m_edgev = true;
            }

            if ((z.m_edgea_a == 1 || z.m_edgea_a == 2) || (z.m_edgea_b == 1 || z.m_edgea_b == 2) || (z.m_edgea_c == 1 || z.m_edgea_c == 2))
            {
                m_edgea = true;
            }

            if (z.m_drupstart >= 0 && z.m_drupstop > 0)
            {
                m_drupgroef = true;
            }

            if (z.m_ank1 > 0 && z.m_ank2 > 0)
            {
                m_ankergaten = true;
            }

            //TODO: sing zone zagen/border
            ////border
            //tb_sing_border_min.Text = myINIfile.IniReadValue("Settings", "singbordermin");
            //tb_sing_border_max.Text = myINIfile.IniReadValue("Settings", "singbordermax");

            m_jobpointer = jobpointer;

            Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singedgemin"));

            m_min_edgev = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singedgemin")); //920;  //1840/2
            m_max_edgev = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singedgemax")); //1000; //2000/2

            m_min_ank = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singankermin")); //750;  //1500/2
            m_max_ank = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singankermax")); //850; //1700/2

            m_min_drup = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singdrupmin")); //850;  //1700/2
            m_max_drup = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singdrupmax")); //950; //1900/2

            m_min_zaag = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singzagenmin"));
            m_max_zaag = Convert.ToInt32(m_jobpointer.m_config.IniReadValue("Settings", "singzagenmax"));

            Rechte r = new Rechte(new Kpoint(z.m_Xstrt, z.m_Ystrt, 0), new Kpoint(z.m_Xend, z.m_Yend, 0));

            minmaxlist = new List<Kpoint>();

            double angle = Math.Abs(Math.Atan2((z.m_Yend - z.m_Ystrt), (z.m_Xend - z.m_Xstrt)));
            double angle2 = angle * 180 / Math.PI;
            if (angle2 != 90)
            {
                double costemp = Math.Cos(angle);
                m_min_edgev /= costemp;
                m_max_edgev /= costemp;

                m_min_ank /= costemp;
                m_max_ank /= costemp;

                m_min_drup /= costemp;
                m_max_drup /= costemp;
            }

            if (!r.m_isver)  //(r.m_b<0)
            {
                if (m_edgev || m_edgea)
                {
                    if (m_min_edgev > m_max_edgev)
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_min_edgev, r.m_b + m_max_edgev, 0));//origineel
                    }
                    else
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_max_edgev, r.m_b + m_min_edgev, 0));
                    }
                }
                if (m_ankergaten)
                {
                    if (m_min_ank > m_max_ank)
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_min_ank, r.m_b + m_max_ank, 0));//origineel
                    }
                    else
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_max_ank, r.m_b + m_min_ank, 0));
                    }
                }
                if (m_drupgroef)
                {
                    if (m_min_drup > m_max_drup)
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_min_drup, r.m_b + m_max_drup, 0));//origineel
                    }
                    else
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_max_drup, r.m_b + m_min_drup, 0));
                    }
                }
                if (true) //zagen
                {
                    if (m_min_zaag > m_max_zaag)
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_min_zaag, r.m_b + m_max_zaag, 0));//origineel
                    }
                    else
                    {
                        minmaxlist.Add(new Kpoint(r.m_b + m_max_zaag, r.m_b + m_min_zaag, 0));
                    }
                }
            }


            //nu zit in x de grootste en y de kleinste

            if (r.m_isver)
            {
                //weet ik nog niet
                //negeren 
            }

            minmaxlist = m_jobpointer.sortlist(minmaxlist);
            minmaxlist = m_jobpointer.mergelist(minmaxlist);

        }



        //public void drawzone()
        //{
        //    m_jobpointer.graphicsObj.DrawRectangle(m_jobpointer.Pen_red,
        //}

        //public bool hittest(List<Kpoint> m_inset_pointlist, int X1, int Y1)
        //{
        //    bool b1 = m_jobpointer.puntinoppervlak(m_inset_pointlist, new Kpoint(X1, Y1, false), true);
        //    bool b2 = m_jobpointer.puntinoppervlak(m_singin_pointlist, new Kpoint(X1, Y1, false), true);
        //    bool b3 = m_jobpointer.puntinoppervlak(m_singuit_pointlist, new Kpoint(X1, Y1, false), true);

        //    if (mylenght > m_min && mylenght < m_max)
        //    {
        //        //eenvoudig geval, de lengte is singulier dus er is geen tussenzone
        //        if (b1)
        //        {
        //            if (b3)
        //            {//sing zone
        //                return false;
        //            }
        //            else
        //            {//OK
        //                return true;
        //            }
        //        }
        //        else
        //        { //ligt niet in de goeie zone
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (b1)
        //        {
        //            if (b3 && b2 == false)
        //            {//sing zone
        //                return false;
        //            }
        //            else
        //            {//OK
        //                return true;
        //            }
        //        }
        //        else
        //        { //ligt niet in de goeie zone
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        //public int getoffset()
        //{
        //    int returner = 0;

        //    int templ = mylenght / 2;
        //    int templ2 = mylenght / 2;

        //    templ = Math.Abs((m_max/2) - templ);
        //    templ2 = Math.Abs((m_min / 2) - templ2);

        //    foreach(Kpoint p in m_singuit_pointlist)
        //    {
        //        if (p.X > returner)
        //        {
        //            returner = (int)p.X;
        //        }
        //    }

        //    if (templ2 > templ) { templ = templ2; }

        //    if (templ == returner)
        //    {
        //        return (templ + 1)*-1;
        //    }
        //    else if (templ > returner)
        //    {
        //        return templ*-1;
        //    }
        //    else
        //    { return 0; }
        //}
    }
}
