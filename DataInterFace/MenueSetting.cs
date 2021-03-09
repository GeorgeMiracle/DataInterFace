using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.Portal.Proxy.supports;

namespace DataInterFace
{
    public class MenueSetting : NetLoginable
    {
        public override object CallFunction(string cMenuId, string cMenuName, string cAuthId, string cCmdLine)
        {
            try
            {
                if (cMenuId == "UA1")
                {
                    this.ShowEmbedControl(new Form1(), cMenuId, true);

                }
                if (cMenuId == "UA2")
                {
                    this.ShowEmbedControl(new FrmAr(), cMenuId, true);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public override bool SubSysLogin()
        {
            return base.SubSysLogin();
        }

        public override bool SubSysLogOff()
        {
            return base.SubSysLogOff();
        }

        public static void InitU8Date(U8Login.clsLogin u8Login)
        {
            //    UFSoft.U8.Framework.Login.UI.clsLogin cl = new UFSoft.U8.Framework.Login.UI.clsLogin();
        }
    }
}
