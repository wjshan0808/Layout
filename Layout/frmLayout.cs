using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layout
{
    public partial class frmLayout : Form
    {
        public frmLayout()
        {
            InitializeComponent();
        }


        ViewItem oViewItemLevel00 = null;

        private void btnNewLayout_Click(object sender, EventArgs e)
        {
            //
            DateTime dtNow = DateTime.Now;
            Random oRandom = new Random(dtNow.Millisecond * dtNow.Second + dtNow.Second * dtNow.Minute + dtNow.Minute * dtNow.Hour);

            //
            int iId = 0x00;

            oViewItemLevel00 = new ViewItem();
            oViewItemLevel00.Id = (++iId).ToString();
            oViewItemLevel00.Content = string.Format("D:{0},  L:{1}", oViewItemLevel00.Id, oViewItemLevel00.Level);
            {
                int iLevel00 = oRandom.Next(0x01, 0x04);
                for (int i = 0x00; i < iLevel00; ++i)
                {
                    ViewItem oViewItemLevel01 = new ViewItem();
                    oViewItemLevel01.Id = (++iId).ToString();
                    oViewItemLevel01.Parent = oViewItemLevel00;
                    oViewItemLevel00.Children.Add(oViewItemLevel01);
                    oViewItemLevel01.Content = string.Format("D:{0},  L:{1}", oViewItemLevel01.Id, oViewItemLevel01.Level);

                    int iLevel01 = oRandom.Next(0x00, 0x03);
                    for (int j = 0x00; j < iLevel01; ++j)
                    {
                        ViewItem oViewItemLevel02 = new ViewItem();
                        oViewItemLevel02.Id = (++iId).ToString();
                        oViewItemLevel02.Parent = oViewItemLevel01;
                        oViewItemLevel01.Children.Add(oViewItemLevel02);
                        oViewItemLevel02.Content = string.Format("D:{0},  L:{1}", oViewItemLevel02.Id, oViewItemLevel02.Level);

                        int iLevel02 = oRandom.Next(0x00, 0x05);
                        for (int k = 0x00; k < iLevel02; ++k)
                        {
                            ViewItem oViewItemLevel03 = new ViewItem();
                            oViewItemLevel03.Id = (++iId).ToString();
                            oViewItemLevel03.Parent = oViewItemLevel02;
                            oViewItemLevel02.Children.Add(oViewItemLevel03);
                            oViewItemLevel03.Content = string.Format("D:{0},  L:{1}", oViewItemLevel03.Id, oViewItemLevel03.Level);

                            int iLevel03 = oRandom.Next(0x00, 0x04);
                            for (int x = 0x00; x < iLevel03; ++x)
                            {
                                ViewItem oViewItemLevel04 = new ViewItem();
                                oViewItemLevel04.Id = (++iId).ToString();
                                oViewItemLevel04.Parent = oViewItemLevel03;
                                oViewItemLevel03.Children.Add(oViewItemLevel04);
                                oViewItemLevel04.Content = string.Format("D:{0},  L:{1}", oViewItemLevel04.Id, oViewItemLevel04.Level);

                                int iLevel04 = oRandom.Next(0x00, 0x05);
                                for (int y = 0x00; y < iLevel04; ++y)
                                {
                                    ViewItem oViewItemLevel05 = new ViewItem();
                                    oViewItemLevel05.Id = (++iId).ToString();
                                    oViewItemLevel05.Parent = oViewItemLevel04;
                                    oViewItemLevel04.Children.Add(oViewItemLevel05);
                                    oViewItemLevel05.Content = string.Format("D:{0},  L:{1}", oViewItemLevel05.Id, oViewItemLevel05.Level);
                                }
                            }
                        }
                    }
                }

            };


            //
            //else if ("Linear" == this.cmbLayout.SelectedItem.ToString())
            {
                this.dcLinearLayout.Items.Clear();
                //
                this.dcLinearLayout.Items.AddRange(oViewItemLevel00.Linear());
            }
            {
                btnTreeLayout.PerformClick();
            }
        }

        private void btnTreeLayout_Click(object sender, EventArgs e)
        {
             
            //
            //else if ("Tree" == this.cmbLayout.SelectedItem.ToString())
            {
                this.dcTreeLayout.Items.Clear();
                //
                this.dcTreeLayout.Items.AddRange(oViewItemLevel00.Tree());
            } 

        }

    }
}
