using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public static class ResourcesValidation
    {
        public static bool isNumber(this string msg)
        {
            bool isNumber;

            try
            {
                int.Parse(msg);
                isNumber = true;
            }
            catch
            {
                isNumber = false;
            }

            return isNumber;
        }

        public static bool ValidateDataset(this DataSet ds)
        {
            bool validate = false;

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        validate = true;
                    }
                }
            }
            return validate;
        }

        public static bool ValidateDataTable(this DataTable dt)
        {
            bool validate = false;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    validate = true;
                }


            }
            return validate;
        }
      

        public static bool ValidatePropertie(this string _value)
        {
            if ((_value != null) && (_value != string.Empty)) return true;
            else return false;
        }

        public static string ValidateTextBox(this TextBox _txt)
        {
            if (_txt.Text != string.Empty)
                return _txt.Text.Trim();
            else
                return "0";
        }

        public static bool ValidateInstacia_EXE(string _nameApp)
        {
            bool _instanceOne = false;
            Mutex mtex = new Mutex(true, _nameApp, out _instanceOne);
            return _instanceOne;
        }
    }
}
