using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MetroFramework.Forms;

namespace QuickCommand
{
    public partial class CommandListForm : MetroForm
    {
        public CommandListForm()
        {
            InitializeComponent();

            commandList = new List<Command>();
        }

        private List<Command> commandList;

        public List<Command> CommandList
        {
            get
            {
                return commandList;
            }
            set
            {
                SetCommandList(value);
            }
        }

        private ListViewItem CreateListViewItem(Command command)
        {
            ListViewItem item = new ListViewItem(new string[] { command.Name, command.FullPath, command.ParamText, command.RunType.ToString() });
            item.Tag = command;

            return item;
        }

        private void ShowCommandList()
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                lvCommand.Items.Add(CreateListViewItem(commandList[i]));
            }
        }

        private void SetCommandList(List<Command> list)
        {
            if (commandList != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    commandList.Add(list[i].Clone() as Command);
                }

                commandList.Sort(Command.Comparer);

                ShowCommandList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Command tempCMD = new Command(txtName.Text.Trim(), txtPath.Text.Trim(), txtParam.Text.Trim(), (CommandType)cbType.SelectedItem);

            bool contains = false;
            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Name == tempCMD.Name)
                {
                    contains = true;
                }
            }

            if (contains)
            {
                MessageBox.Show("快捷命令：" + tempCMD.Name + " 已经存在！");
            }
            else
            {
                commandList.Add(tempCMD);
                ListViewItem item = CreateListViewItem(tempCMD);
                lvCommand.Items.Add(item);

                lvCommand.Focus();
                item.Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCommand.SelectedItems[0];
            Command cmd = item.Tag as Command;

            if (MessageBox.Show("是否要删除命令：" + cmd.Name, "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                lvCommand.Items.Remove(item);
                commandList.Remove(cmd);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCommand.SelectedItems[0];
            Command cmd = item.Tag as Command;

            if (MessageBox.Show("是否要修改命令：" + cmd.Name, "修改提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                cmd.Name = txtName.Text;
                cmd.FullPath = txtPath.Text;
                cmd.ParamText = txtParam.Text;
                cmd.RunType = (CommandType)cbType.SelectedItem;

                item.SubItems[0].Text = cmd.Name;
                item.SubItems[1].Text = cmd.FullPath;
                item.SubItems[2].Text = cmd.ParamText;
                item.SubItems[3].Text = cmd.RunType.ToString();
            }

            lvCommand.Focus();
            item.Selected = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            commandList.Sort(Command.Comparer);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Multiselect = false;

            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = dia.FileName;
                txtName.Text = GetName(dia.FileName);
            }
        }

        private string GetName(string filepath)
        {
            FileInfo info = new FileInfo(filepath);
            return info.Name.TrimEnd(info.Extension.ToCharArray());
        }

        private void lvCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCommand.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCommand.SelectedItems[0];
                Command command = item.Tag as Command;

                txtName.Text = command.Name;
                txtPath.Text = command.FullPath;
                txtParam.Text = command.ParamText;
                cbType.SelectedItem = command.RunType;

                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void CommandListForm_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            foreach (CommandType type in Enum.GetValues(typeof(CommandType)))
            {
                cbType.Items.Add(type);
            }

            cbType.SelectedIndex = 0;
        }
    }
}
