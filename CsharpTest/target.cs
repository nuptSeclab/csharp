using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication
{
    /*  target.txt
        201683833,99,60,https://login.abc.com/login.aspx,200
    */

    class Target
    {
        public string auto_id;
        public int run_times;
        public double out_time;
        public string target_url;
        public string timing1;

        /*InitWithTxt 
            args:   String txt
            return  0 : failed
                    1 : success
        */
        public int InitWithTxt(String txt)
        {

            string[] results;
            results = txt.Split(',');

            if (results.Length == 5)
            {
                this.auto_id = results[0];
                this.run_times = Convert.ToInt32( results[1] );
                this.out_time = Convert.ToDouble( results[2] );
                this.target_url = results[3];
                this.timing1 = results[4];
                return 1;
            }
            else
                return 0;

        }
        public void Print()
        {
            Console.WriteLine(this.auto_id + this.run_times + this.out_time + this.target_url + this.timing1);
        }

        static void Main(string[] args)
        {
            string txt = "201683833,99,60,https://login.abc.com/login.aspx,200";
            Target target = new Target();
            int ret = target.InitWithTxt(txt);
            if (ret != 0)
                target.Print();
            else
                Console.WriteLine("error");

        }
    }
}
