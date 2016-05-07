using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication
{
    class File1
    {
        /*企业税号，是否重复报税（0代表提交1次，1代表重复），程序启动后重复登陆次数（3代表重复登陆次数），
         * 全部数据重复提交次数，UKEY密码存储，申报类型(0代表零申报，1代表小规模纳税人、2代表一般纳税人)，
         * 登陆认证网站地址，下一步参数获取地址
         * 32010782919111，1,3,4,666666,0,https://ca.jsds.gov.cn/sbLogin.do，
         * http://xxx/xxx/tax_report_files.jsp?id=18061683389&month=01&info=2（文件2）
         * 存储到本地taxfile1.txt*/
        public string taxNumber;
        public int repeatTax;
        public int loginTimes;
        public int submitTime;
        public string uKey;
        public int sbType;
        public string loginUrl;
        public string file2Url;

    }
}
