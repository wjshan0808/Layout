using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Layout
{
    /// <summary>
    /// 视图项
    /// </summary>
    public partial class ViewItem
    {

               
        /// <summary>
        /// 树型布局
        /// </summary>
        /// <returns></returns>
        public DiagramItem[] Tree()
        {
            //等级坐标
            Dictionary<int, float> dicLastLevelX = new Dictionary<int, float>();

            //
            List<DiagramItem> lstTreeDiagramItems = new List<DiagramItem>();
            {
                //先前项
                ViewItem oViewItemPrior = null;
                {
                    Layout((oViewItem) =>
                    {
                        //布局
                        oViewItem.TreeLayout(dicLastLevelX, oViewItemPrior);

                        //绘图
                        List<DiagramItem> lstDiagramItems = oViewItem.TreeDiagram();
                        {
                            lstTreeDiagramItems.AddRange(lstDiagramItems);
                        }

                        //更新先前项
                        oViewItemPrior = oViewItem;
                    });

                    //模拟最后布局
                    if (null != oViewItemPrior)
                    {
                        oViewItemPrior.TreeLayout(dicLastLevelX, null);
                    }
                }
            }

            //更新坐标
            foreach (DiagramItem item in lstTreeDiagramItems)
            {
                ViewItem oViewItem = item.Tag as ViewItem;
                if (null != oViewItem)
                {
                    item.X = oViewItem.X;
                    item.Y = oViewItem.Y;
                }
            }

            //
            return lstTreeDiagramItems.ToArray();
        }


        /// <summary>
        /// 设计树型布局
        /// </summary>
        /// <param name="oViewItemPrior">先前视图项</param>
        private void TreeLayout(Dictionary<int, float> dicLastLevelX, ViewItem oViewItemPrior)
        {
            //布局参数
            float fIndentX = 16.0F;
            float fSpaceY = 28.0F;

            //Y坐标
            this.Y = (this.Height + fSpaceY) * this.Level;

            //层级坐标
            if (!dicLastLevelX.ContainsKey(this.Level))
            {
                //1.稀疏型(不向左延申)
                {
                    if (null != this.Parent)
                    {
                        //X坐标
                        //this.X = this.Parent.X;
                    }
                }

                //2.紧密型(尽可能向左延申至层级坐标)
                {
                    if (null != this.Parent)
                    {
                        //首项相对父项坐标左移量
                        float fShiftLeftParentX = 0.0F;
                        {
                            //子项之和
                            for (int i = 0x00; i < (this.Parent.Children.Count - 0x01); ++i)
                            {
                                fShiftLeftParentX += (this.Parent.Children[i].Width);
                                fShiftLeftParentX += (fIndentX);
                            }

                            //折半
                            fShiftLeftParentX /= (0x02);
                        }

                        //X坐标
                        this.X = (this.Parent.X - fShiftLeftParentX);
                    }
                }

                //更新层级坐标
                dicLastLevelX[this.Level] = this.X;

                //
                return;
            }

            //不存在先前项(首, 末)
            if (null == oViewItemPrior)
            {
                //更新父项层级坐标
                ViewItem oViewItemParent = this.Parent as ViewItem;
                while (null != oViewItemParent)
                {
                    //居中位项
                    int iChildrenCount = oViewItemParent.Children.Count;
                    {
                        int iRemainder = 0x00;
                        int iQuotient = Math.DivRem(iChildrenCount, 0x02, out iRemainder);
                        if (0x00 == iRemainder)
                        {
                            oViewItemParent.X = (oViewItemParent.Children[0x00].X + oViewItemParent.Children[iChildrenCount - 0x01].X) / 2.0F;
                        }
                        else
                        {
                            oViewItemParent.X = oViewItemParent.Children[iQuotient].X;
                        }
                    }

                    //更新层级坐标
                    dicLastLevelX[oViewItemParent.Level] = oViewItemParent.X;

                    //上一层级
                    oViewItemParent = oViewItemParent.Parent as ViewItem;
                }

                //
                return;
            }

            //先前层级结束(层级值由高变低)
            if (this.Level < oViewItemPrior.Level)
            {
                //更新先前层级坐标
                ViewItem oViewItemPriorParent = oViewItemPrior.Parent as ViewItem;
                while ((true)
                    && (null != oViewItemPriorParent)
                    && (this.Level <= oViewItemPriorParent.Level))
                {
                    //居中位项
                    int iChildrenCount = oViewItemPriorParent.Children.Count;
                    {
                        int iRemainder = 0x00;
                        int iQuotient = Math.DivRem(iChildrenCount, 0x02, out iRemainder);
                        if (0x00 == iRemainder)
                        {
                            oViewItemPriorParent.X = (oViewItemPriorParent.Children[0x00].X + oViewItemPriorParent.Children[iChildrenCount - 0x01].X) / 2.0F;
                        }
                        else
                        {
                            oViewItemPriorParent.X = oViewItemPriorParent.Children[iQuotient].X;
                        }
                    }

                    //更新层级坐标
                    dicLastLevelX[oViewItemPriorParent.Level] = oViewItemPriorParent.X;

                    //上一层级
                    oViewItemPriorParent = oViewItemPriorParent.Parent as ViewItem;
                }
            }

            //层级坐标
            {
                //X坐标
                this.X = (dicLastLevelX[this.Level] + this.Width) + (fIndentX);

                //层级补差
                if ((true)
                    && (null != this.Parent)
                    && (this == this.Parent.Children[0x00])
                    && (this.X < this.Parent.X))
                {
                    //1.稀疏型(不向左延申)
                    {
                        //X坐标
                        //this.X = this.Parent.X;
                    }

                    //2.紧密型(尽可能向左延申至层级坐标)
                    {
                        //首项相对父项坐标左移量
                        float fShiftLeftParentX = 0.0F;
                        {
                            //子项之和
                            for (int i = 0x00; i < (this.Parent.Children.Count - 0x01); ++i)
                            {
                                fShiftLeftParentX += (this.Parent.Children[i].Width);
                                fShiftLeftParentX += (fIndentX);
                            }

                            //折半
                            fShiftLeftParentX /= (0x02);
                        }
                        
                        //X坐标
                        this.X = (((this.Parent.X - fShiftLeftParentX) <= this.X) ? (this.X) : (this.Parent.X - fShiftLeftParentX));
                    }
                }
            }

            //更新层级坐标
            dicLastLevelX[this.Level] = this.X;

        }

        /// <summary>
        /// 绘制树型图
        /// </summary>
        private List<DiagramItem> TreeDiagram()
        {
            //形状集合
            List<DiagramItem> lstDiagramItems = new List<DiagramItem>();

            //当前形状
            DiagramShape oDiagramShapeThis = new DiagramShape()
            {
                Tag = this,
                X = this.X,
                Y = this.Y,
                Width = this.Width,
                Height = this.Height,
                Content = this.Content,
                Shape = BasicShapes.Rectangle,
            };
            this.Context = oDiagramShapeThis;
            lstDiagramItems.Add(oDiagramShapeThis);

            //父项
            ViewItem oViewItemParent = this.Parent as ViewItem;
            if (null != oViewItemParent)
            {
                if (null == oViewItemParent.Context)
                {
                    //父项形状
                    DiagramShape oDiagramShapeParent = new DiagramShape()
                    {
                        Tag = oViewItemParent,
                        X = oViewItemParent.X,
                        Y = oViewItemParent.Y,
                        Width = oViewItemParent.Width,
                        Height = oViewItemParent.Height,
                        Content = oViewItemParent.Content,
                        Shape = BasicShapes.Rectangle,
                    };
                    oViewItemParent.Context = oDiagramShapeParent;
                    lstDiagramItems.Add(oDiagramShapeParent);
                }

                //连线
                DiagramConnector oDiagramConnector = new DiagramConnector()
                {
                    //Type = ConnectorType.Straight,
                    EndPointRestrictions = ConnectorPointRestrictions.KeepConnected,
                    //Top:00, Right:01, Down:02, Left:03
                    EndItemPointIndex = 0x00,
                    EndItem = oDiagramShapeThis,
                    //Top:00, Right:01, Down:02, Left:03
                    BeginItemPointIndex = 0x02,
                    BeginItem = oViewItemParent.Context as DiagramShape,
                };
                lstDiagramItems.Add(oDiagramConnector);
            }

            //
            return lstDiagramItems;
        }
        

    }
}
