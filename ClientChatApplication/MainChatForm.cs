namespace ClientChatApplication
{
    using System;
    using System.Windows.Forms;
    using ChatClientLibrary;
    using ChatClientLibrary.Chat.Factory;

    public partial class MainChatForm : Form
    {
        private IChatClient chatClient = default(IChatClient);

        public MainChatForm()
        {
            InitializeComponent();
        }

        private void MainChatForm_Load(object sender, EventArgs e)
        {
            ChatFactory factory = new ChatFactory();
            this.chatClient = factory.CreateConnection();
            this.chatClient.LogEvent += chatClient_LogEvent;
            this.chatClient.NewMessageEvent += chatClient_NewMessageEvent;
            this.chatClient.NewUserEvent += chatClient_NewUserEvent;
            this.chatClient.UserLeaveEvent += chatClient_UserLeaveEvent;
        }

        #region Chat Client EventHandlers
        
        private void chatClient_UserLeaveEvent(object sender, ChatClientLibrary.Chat.Events.LeaveEventArgs e)
        {
        }

        private void chatClient_NewUserEvent(object sender, ChatClientLibrary.Chat.Events.NewUserEventArgs e)
        {
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
            /// Join Action
            /// and SendAction to chatClient
        }
    }
}
