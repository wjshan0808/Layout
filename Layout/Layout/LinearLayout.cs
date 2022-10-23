using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using System;
using System.Collections;
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
        /// 线型布局
        /// </summary>
        /// <returns></returns>
        public DiagramItem[] Linear()
        {
            //
            List<DiagramItem> lstLinearDiagramItems = new List<DiagramItem>();
            {
                //先前项
                ViewItem oViewItemPrior = null;
                {
                    Layout((oViewItem) =>
                    {
                        //布局
                        oViewItem.LinearLayout(oViewItemPrior);

                        //绘图
                        List<DiagramItem> lstDiagramItems = oViewItem.LinearDiagram();
                        {
                            lstLinearDiagramItems.AddRange(lstDiagramItems);
                        }

                        //更新先前项
                        oViewItemPrior = oViewItem;
                    });
                }
            }

            //
            return lstLinearDiagramItems.ToArray();
        }


        /// <summary>
        /// 设计线型布局
        /// </summary>
        /// <param name="oViewItemPrior">先前视图项</param>
        private void LinearLayout(ViewItem oViewItemPrior)
        {
            //布局参数
            float fIndentX = 16.0F;
            float fSpaceY = 10.0F;

            //视图项布局
            {
                //X坐标
                this.X = (this.Width + fIndentX) * this.Level;

                //
                if (null != oViewItemPrior)
                {
                    this.Y = (oViewItemPrior.Y + oViewItemPrior.Height) + (fSpaceY);
                }
            }
        }

        /// <summary>
        /// 绘制线型图
        /// </summary>
        private List<DiagramItem> LinearDiagram()
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
                    EndItemPointIndex = 0x03,                  
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
