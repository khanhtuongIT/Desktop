using System;
using System.Collections.Generic;
using System.Text;

namespace Ecm.Domain
{
    public class Enumerators
    {
        [Flags]
        public enum EDocumentProcessStatus
        {
            NewDoc = 0,
            TestDoc = 1,
            VerifyDoc = 2,
        }

        [Flags]
        public enum ETrangthaiHopdongLaodong
        {
            DangHopdong = 0,
            TamhoanHopdong = 1,
            KetthucHopdong = 2,
            HethanHopdong = 3,
            GianhanHopdong = 4,
        }
    }
}
