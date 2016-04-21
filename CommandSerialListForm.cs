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
    public partial class CommandSerialListForm : MetroForm
    {
        private List<Command> allCommand;
        private List<string> serialListCommand;

        public List<string> SerialListCommand
        {
            get
            {
                return serialListCommand;
            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    this.serialListCommand.Add(value[i]);
                }
            }
        }

        public CommandSerialListForm(List<Command> allCommand)
        {
            InitializeComponent();
            this.allCommand = allCommand;
            this.serialListCommand = new List<string>();
        }

        private void CommandSerialListForm_Load(object sender, EventArgs e)
        {;
            cbCommand.Items.Clear();
            lvCommand.Items.Clear();
            for (int i = 0; i < allCommand.Count; i++)
            {
                if (!serialListCommand.Contains(allCommand[i].Name))
                {
                    cbCommand.Items.Add(allCommand[i].Name);
                }
                else
                {
                    ListViewItem item = CreateListViewItem(allCommand[i]);
                    lvCommand.Items.Add(item);
                }
            }

            if (cbCommand.Items.Count > 0)
            {
                cbCommand.SelectedIndex = 0;            
            }

            if (lvCommand.Items.Count > 0)
            {
                lvCommand.Items[0].Selected = true;
            }
        }

        private ListViewItem CreateListViewItem(Command command)
        {
            ListViewItem item = new ListViewItem(new string[] { command.Name, command.FullPath, command.ParamText, command.RunType.ToString() });
            item.Tag = command;

            return item;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbCommand.SelectedItem != null)
            {
                string current = cbCommand.SelectedItem as string;
                cbCommand.Items.Remove(current);
                if (cbCommand.Items.Count > 0)
                {
                    cbCommand.SelectedIndex = 0;
                }

                for (int i = 0; i < allCommand.Count; i++)
			    {
                    if( allCommand[i].Name == current )
                    {
                        ListViewItem item = CreateListViewItem(allCommand[i]);
                        lvCommand.Items.Add(item);
                        serialListCommand.Add(current);
                    }
			    }
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCommand.SelectedItems.Count> 0)
            {
                ListViewItem currentItem = lvCommand.SelectedItems[0];
                Command current = currentItem.Tag as Command;

                lvCommand.Items.Remove(currentItem);
                cbCommand.Items.Add(current.Name);
                serialListCommand.Remove(current.Name);

                cbCommand.SelectedItem = current;
            }
        }
    }
}
