using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.View
{
    /// <summary>
    /// 基础视图项
    /// </summary>
    public abstract class BaseViewItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 根项
        /// </summary>
        public BaseViewItem Root
        {
            get
            {
                BaseViewItem oRoot = this;
                {
                    while (null != oRoot.Parent)
                    {
                        oRoot = oRoot.Parent;
                    }
                }
                return oRoot; 
            }
        }
        /// <summary>
        /// 父项
        /// </summary>
        public BaseViewItem Parent { get; set; } = null;
        /// <summary>
        /// 子项集合
        /// </summary>
        public List<BaseViewItem> Children { get; } = new List<BaseViewItem>();

        /// <summary>
        /// X坐标
        /// </summary>
        public float X { get; set; } = 0.0F;
        /// <summary>
        /// Y坐标
        /// </summary>
        public float Y { get; set; } = 0.0F;
        /// <summary>
        /// 高度
        /// </summary>
        public float Height { get; set; } = 46.0F;
        /// <summary>
        /// 宽度
        /// </summary>
        public float Width { get; set; } = 46.0F;
        
        /// <summary>
        /// 上下文
        /// </summary>
        public object Context { get; set; } = null;

        /// <summary>
        /// 标记
        /// </summary>
        public object Tag { get; set; } = null;


    }
}
