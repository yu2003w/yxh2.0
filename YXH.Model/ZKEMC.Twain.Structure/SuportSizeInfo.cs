using System.Collections.Generic;
using System.ComponentModel;
using YXH.Twain.Structure.Enum;

namespace YXH.Twain.Structure
{
    /// <summary>
    /// 支持大小信息
    /// </summary>
    public class SuportSizeInfo
    {
        [DefaultValue(SuportSize.TWSS_NONE)]
        public SuportSize CurrentSize { get; set; }

        [DefaultValue(SuportSize.TWSS_NONE)]
        public SuportSize DefaultSize { get; set; }

        public List<SuportSize> DeviceSuportSizes { get; set; }
    }
}
