namespace ClientChatApplication
{
    using System;
    using System.Windows.Forms;
    using ChatClientLibrary;
    using ChatClientLibrary.Chat.Action;
    using ChatClientLibrary.Chat.Factory;
    using ClientChatApplication.Utility;

    public partial class MainChatForm : Form
    {
        private IChatClient ChatClient = default(IChatClient);
        private string UniqueID = string.Empty;

        public MainChatForm()
        {
            InitializeComponent();
        }

        private void MainChatForm_Load(object sender, EventArgs e)
        {
            ChatFactory factory = new ChatFactory();
            this.ChatClient = factory.CreateConnection();
            this.ChatClient.LogEvent += chatClient_LogEvent;
            this.ChatClient.NewMessageEvent += chatClient_NewMessageEvent;
            this.ChatClient.NewUserEvent += chatClient_NewUserEvent;
            this.ChatClient.UserLeaveEvent += chatClient_UserLeaveEvent;

            this.UniqueID = Guid.NewGuid().ToString().Replace("-", "");

            setFormSettings();
        }

        #region Chat Client EventHandlers
        
        private void chatClient_UserLeaveEvent(object sender, ChatClientLibrary.Chat.Events.LeaveEventArgs e)
        {
            /// if e.User.UserUnqiueID not equal to uniqueID
            /// then show notifier form
        }

        private void chatClient_NewUserEvent(object sender, ChatClientLibrary.Chat.Events.NewUserEventArgs e)
        {
            /// if e.User.UserUnqiueID not equal to uniqueID
            if (!e.User.UserUnqiueID.Equals(this.UniqueID, StringComparison.InvariantCultureIgnoreCase))
            {
                /// then show notifier form
            }
            else
            {
                /// else enable ActivityBox and disable User Information box
                this.EnableControl(this.groupBox1, true);
                this.EnableControl(this.groupBox2, false);
            }
        }

        private void chatClient_NewMessageEvent(object sender, ChatClientLibrary.Chat.Events.NewMessageEventArgs e)
        {
        }

        private void chatClient_LogEvent(object sender, ChatClientLibrary.Chat.Events.LogEventArgs e)
        {
        } 

        #endregion

        private void JoinButton_Click(object sender, EventArgs e)
        {
            /// Join Action and SendAction to chatClient
            if (!string.IsNullOrEmpty(this.UsernameBox.Text))
                this.ChatClient.SendAction(new JoinAction(this.UsernameBox.Text, this.UniqueID));
        }

        private void MainChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChatClient.SendAction(new LeaveAction(this.UniqueID));
        }

        private void setFormSettings()
        {
            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = true;
        }
    }
}
