using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickCommand
{
    public partial class FormCommand : MetroForm
    {
        private List<Command> commandList = null;
        private List<string> commandSerialList = null;
        public FormCommand()
        {
            InitializeComponent();
            LoadCommand();
            LoadSerialCommand();
        }

        private void LoadCommand()
        {
            commandList = Command.Load();

            if (commandList == null)
            {
                commandList = new List<Command>();
            }
        }

        private void LoadSerialCommand()
        {
            commandSerialList = Command.LoadSerialList();
            if (commandSerialList == null)
            {
                commandSerialList = new List<string>();
            }
        }

        private void SaveCommand()
        {
            Command.Save(commandList);
        }

        private void SaveSerialCommand()
        {
            Command.SaveSerialList(commandSerialList);
        }

        private void CloseWindows()
        {
            this.Close();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (cbCommand.Text.Trim().ToLower() == "-r")
            {
                CommandListForm form = new CommandListForm();
                form.CommandList = commandList;
                this.Visible = false;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    commandList.Clear();
                    for (int i = 0; i < form.CommandList.Count; i++)
                    {
                        commandList.Add(form.CommandList[i].Clone() as Command);
                    }
                    SaveCommand();
                }
                this.Visible = true;
            }
            else if (cbCommand.Text.Trim().ToLower() == "-l")
            {
                CommandSerialListForm form = new CommandSerialListForm(commandList);
                form.SerialListCommand = commandSerialList;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    commandSerialList.Clear();
                    for (int i = 0; i < form.SerialListCommand.Count; i++)
                    {
                        commandSerialList.Add(form.SerialListCommand[i] as string);
                    }
                    SaveSerialCommand();
                }
            }
            else if (cbCommand.Text.Trim().ToLower() == "-d")
            {
                try
                {
                    Command.Excute(commandList, commandSerialList);
                    CloseWindows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    bool success = Command.Excute(commandList, cbCommand.Text);
                    if (success)
                    {
                        CloseWindows();
                    }
                    else
                    {
                        MessageBox.Show("命令：" + cbCommand.Text + " 没有执行成功，请检查！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            cbCommand.Text = "";
        }

        private void cbCommand_TextUpdate(object sender, EventArgs e)
        {
            List<Command> list = Command.GetCommandByName(commandList, cbCommand.Text);

            int index = cbCommand.SelectionStart;
            cbCommand.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                cbCommand.Items.Add(list[i]);
            }

            if (cbCommand.Items.Count > 0)
            {
                cbCommand.DroppedDown = true;
                cbCommand.SelectionStart = index;
            }
        }

        private void cbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CloseWindows();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                String text = cbCommand.Text.Trim().ToLower();
                bool can = (text == "-r" || text == "-l" || text == "-d");
                if (can || cbCommand.Items.Count > 0)
                {
                    if (cbCommand.Items.Count > 0)
                    {
                        if (cbCommand.SelectedIndex == -1)
                        {
                            cbCommand.SelectedIndex = 0;
                        }
                    }
                    btnExcute_Click(this, null);
                }
            }
        }

        private void FormCommand_Load(object sender, EventArgs e)
        {
            DayOfWeek d = DateTime.Now.DayOfWeek;
            int i = (int)d;
            Image image = imageList.Images[i];
            notify.Icon = Icon.FromHandle(new Bitmap(image).GetHicon());
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (notify.Visible)
            {
                notify.Visible = false;
                this.Show();
            }
        }

        private void cbCommand_TextChanged(object sender, EventArgs e)
        {
            if (cbCommand.Items.Count > 0)
            {
                btnExcute.Enabled = true;
            }
            else
            {
                btnExcute.Enabled = false;
            }
        }
    }
}
