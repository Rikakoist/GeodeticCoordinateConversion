using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    //消息对话框类
    class MessageBoxes
    {
        internal static void SaveToFileSuccess(string Content, string Path)
        {
            MessageBox.Show("成功保存" + Content + "数据至\r\n\"" + Path + "\"！", "嘎哈呀！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        internal static void SaveToPicSuccess(string Content, string Path)
        {
            MessageBox.Show("成功保存" + Content + "至\r\n\"" + Path + "\"！", "嘎哈呀！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        internal static void ReadFromFileSuccess(string Content, string Path)
        {
            MessageBox.Show("成功从\r\n\"" + Path + "\"读取" + Content + "并绘制！", "嘎哈呀！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        internal static string Success(string Content)
        {
            MessageBox.Show(Content, "好的。", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return "OK";
        }

        internal static string Confirm(string Content)
        {
            if (MessageBox.Show(Content, "Emmmmmm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                return "OK";
            }
            else
            {
                return "Cancel";
            }
        }

        internal static void OperationCanceledByUser()
        {
            MessageBox.Show("操作被用户取消。", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        internal static void EmptyInput()
        {
            MessageBox.Show("Input can't be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static string Error(string Err)
        {
            MessageBox.Show(Err, "啊哦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "OK";
        }

        internal static void Warning(string Warn, string Title)
        {
            MessageBox.Show(Warn, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal static void LoginForbidden(string Message, string Title)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //输出作者信息
        internal static void Author()
        {
            MessageBox.Show("大地坐标转换程序, 由Rikakoist编写", "LOL!");
        }
    }
}
