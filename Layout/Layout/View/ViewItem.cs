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
    public partial class ViewItem : View.BaseViewItem, IEqualityComparer<ViewItem>
    {
        /// <summary>
        /// ThisGUID
        /// </summary>
        public string ThisGUID { get; } = Guid.NewGuid().ToString("B");

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 层级
        /// </summary>
        public int Level
        {
            get
            {
                ViewItem oParent = this.Parent as ViewItem;
                if (null == oParent)
                {
                    return 0x00;
                }
                return (oParent.Level + 0x01);
            }
        }
        /// <summary>
        /// 最大层级
        /// </summary>
        public int MaxLevel { get; set; } = 0x00;


        /// <summary>
        /// 视图结构布局
        /// </summary>
        /// <param name="acCallback">回调函数</param>
        private void Layout(Action<ViewItem> acCallback)
        {
            //根项
            Stack<ViewItem> stackViewItems = new Stack<ViewItem>();
            stackViewItems.Push(this);

            while (0x00 < stackViewItems.Count)
            {
                //父项
                ViewItem oViewItem = stackViewItems.Pop();
                if (null != acCallback)
                {
                    acCallback(oViewItem);
                }

                //子项
                int iChildrenCount = oViewItem.Children.Count;

                //从左向右, 由深到浅
                //for (int i = 0x00; i < iCount; ++i)
                //从右向左, 由浅入深
                for (int i = iChildrenCount - 0x01; i >= 0x00; --i)
                {
                    ViewItem oViewItemChild = oViewItem.Children[i] as ViewItem;
                    if (null != oViewItemChild)
                    {
                        stackViewItems.Push(oViewItemChild);
                    }
                }
            }
            //End_while
        }

        /// <summary>
        /// 锚点
        /// </summary>
        public int Anchor
        {
            get
            {
                ViewItem oRoot = this.Root as ViewItem;
                ViewItem oParent = this.Parent as ViewItem;
                if (null == oParent)
                {
                    return oRoot.MaxAnchor;
                }
                return (oRoot.MaxAnchor += (oParent.Children.IndexOf(this) + 0x01));
            }
        }
        /// <summary>
        /// 最大锚点
        /// </summary>
        public int MaxAnchor { get; set; } = 0x00;

        
        /// <summary>
        /// 隐式实现接口Equals
        /// </summary>
        /// <param name="oViewItemX">左视图项</param>
        /// <param name="oViewItemY">右视图项</param>
        /// <returns>True:相等, 否则不相等</returns>
        public bool Equals(ViewItem oViewItemX, ViewItem oViewItemY)
        {
            if (null == oViewItemX)
            {
                return (null == oViewItemY);
            }
            if (null == oViewItemY)
            {
                return (null == oViewItemX);
            }
            return (oViewItemX.ThisGUID == oViewItemY.ThisGUID);
        }
        /// <summary>
        /// 隐式实现接口GetHashCode
        /// </summary>
        /// <param name="oViewItem">视图项</param>
        /// <returns>Hash值</returns>
        public int GetHashCode(ViewItem oViewItem)
        {
            if (null == oViewItem)
            {
                return 0x00;
            }
            if (null == oViewItem.ThisGUID)
            {
                return 0x00;
            }
            return oViewItem.ThisGUID.GetHashCode();
        }
        
    }
}
