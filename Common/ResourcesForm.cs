using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class ResourcesForm
    {
       public static void setForm(Form _form, string _titulo, int[] _sizeScreen)
        {
            _form.Text              = _titulo;
            _form.FormBorderStyle   = FormBorderStyle.Fixed3D;

            if (_sizeScreen!=null)
            {
                _form.Width = _sizeScreen[0] - 50;
                _form.Height = _sizeScreen[1] - 50;
            }         
            _form.MaximizeBox       = false;
           
           
        }

        public static Color setFocusColor()
        {
            return Color.LightYellow;
        }

        public static Color setLeaveColor()
        {
            return Color.White;
        }
    }
}
