namespace ClientChatApplication.Utility
{
    using System.Windows.Forms;

    public static class FormUtility
    {
        public static void EnableControl(this Form form, Control control, bool flag)
        {
            MethodInvoker method = delegate { control.Enabled = flag; };
            form.Invoke(method);
        }
    }
}
